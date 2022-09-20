using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.IO;
using Couchbase.N1QL;
using Couchbase.Views;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Core.Database
{
	// Token: 0x020000E7 RID: 231
	public class CouchbaseDatabase
	{
		// Token: 0x060006AA RID: 1706 RVA: 0x000153BC File Offset: 0x000135BC
		public CouchbaseDatabase(string type, string keyPrefix)
		{
			EnvironmentSettings.CouchbaseServerEntry couchbaseServerEntry;
			EnvironmentSettings.CouchbaseBucketEntry couchbaseBucketEntry;
			if (EnvironmentSettings.Couchbase.TryGetBucketData(type, out couchbaseServerEntry, out couchbaseBucketEntry))
			{
				this.icluster_0 = new Cluster(new ClientConfiguration
				{
					Servers = new List<Uri>(couchbaseServerEntry.Hosts)
				});
				this.icluster_0.Authenticate(couchbaseServerEntry.Username, couchbaseServerEntry.Password);
				this.ibucket_0 = this.icluster_0.OpenBucket(couchbaseBucketEntry.Name);
				this.string_1 = couchbaseBucketEntry.Name;
				this.string_2 = keyPrefix + "-";
				return;
			}
			Logging.Error("CouchbaseDatabase::ctor: no database available for type " + type);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00008A4A File Offset: 0x00006C4A
		public void CreateIndex(string indexName, params string[] args)
		{
			this.ExecuteCommand<object>(string.Format("CREATE INDEX {0} ON `%BUCKET%` ({1})", indexName, string.Join(",", args))).Wait();
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00008A6D File Offset: 0x00006C6D
		public void CreateIndexWithFilter(string indexName, string filter, params string[] args)
		{
			this.ExecuteCommand<object>(string.Format("CREATE INDEX {0} ON `%BUCKET%` ({1}) WHERE {2}", indexName, string.Join(",", args), filter)).Wait();
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00015460 File Offset: 0x00013660
		public long GetDocumentHigherID()
		{
			this.CreateIndexWithFilter("higherId", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id"
			});
			IQueryResult<JObject> result = this.ExecuteCommand<JObject>("SELECT MAX(BITOR(BITSHIFT(id_hi, 32), id_lo)) FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%'").Result;
			if (!result.Success)
			{
				throw new Exception("Query failed!");
			}
			JToken jtoken = result.Rows[0]["$1"];
			if (jtoken.Type == JTokenType.Integer)
			{
				return (long)jtoken;
			}
			return 0L;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000154E0 File Offset: 0x000136E0
		public int[] GetCounterHigherIDs()
		{
			int higherIdCounterSize = EnvironmentSettings.HigherIdCounterSize;
			int[] array = new int[higherIdCounterSize];
			for (int i = 0; i < higherIdCounterSize; i++)
			{
				IOperationResult<string> operationResult = this.ibucket_0.Get<string>("counter_" + i);
				if (operationResult.Status != ResponseStatus.Success && operationResult.Status != ResponseStatus.KeyNotFound)
				{
					throw new Exception("Db in loading state!");
				}
				if (operationResult.Value != null)
				{
					array[i] = (int)ulong.Parse(operationResult.Value);
				}
			}
			return array;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00008A91 File Offset: 0x00006C91
		public void Destruct()
		{
			this.ibucket_0.Dispose();
			this.icluster_0.Dispose();
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00008AA9 File Offset: 0x00006CA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string BuildKeyName(long id)
		{
			return this.string_2 + id;
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00008ABC File Offset: 0x00006CBC
		public Task<IQueryResult<T>> ExecuteCommand<T>(string query)
		{
			return this.ibucket_0.QueryAsync<T>(query.Replace("%BUCKET%", this.string_1).Replace("%KEY_PREFIX%", this.string_2));
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00008AEA File Offset: 0x00006CEA
		public Task<IViewResult<T>> ExecuteCommand<T>(IViewQuery query)
		{
			return this.ibucket_0.QueryAsync<T>(query);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public Task<IOperationResult<string>> Get(long key)
		{
			return this.ibucket_0.GetAsync<string>(this.BuildKeyName(key));
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00008B0C File Offset: 0x00006D0C
		public Task<IDocumentResult<string>[]> Get(IEnumerable<string> ids)
		{
			return this.ibucket_0.GetDocumentsAsync<string>(ids);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001555C File Offset: 0x0001375C
		public Task<IDocumentResult<string>[]> Get(LogicArrayList<LogicLong> ids)
		{
			string[] array = new string[ids.Size()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.BuildKeyName(ids[i]);
			}
			return this.ibucket_0.GetDocumentsAsync<string>(array);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00008B1A File Offset: 0x00006D1A
		public Task<IOperationResult<string>> Insert(long key, string json)
		{
			return this.ibucket_0.InsertAsync<string>(this.BuildKeyName(key), json);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00008B2F File Offset: 0x00006D2F
		public Task<IOperationResult<string>> InsertOrUpdate(long key, string json)
		{
			return this.ibucket_0.UpsertAsync<string>(this.BuildKeyName(key), json);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00008B44 File Offset: 0x00006D44
		public Task<IOperationResult<string>> Update(long key, string json)
		{
			return this.ibucket_0.ReplaceAsync<string>(this.BuildKeyName(key), json);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00008B59 File Offset: 0x00006D59
		public Task<IOperationResult<string>> Update(long key, string json, ulong cas)
		{
			return this.ibucket_0.ReplaceAsync<string>(this.BuildKeyName(key), json, cas);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00008B6F File Offset: 0x00006D6F
		public Task<IOperationResult> Remove(long key)
		{
			return this.ibucket_0.RemoveAsync(this.BuildKeyName(key));
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000155A4 File Offset: 0x000137A4
		public Task<IOperationResult<ulong>> IncrementSeed()
		{
			int num = this.int_0;
			this.int_0 = num + 1;
			int num2 = num % EnvironmentSettings.HigherIdCounterSize;
			return this.ibucket_0.IncrementAsync("counter_" + num2, 1UL, (ulong)((long)num2 << 32 | 1L));
		}

		// Token: 0x040003B2 RID: 946
		private const string string_0 = "SELECT MAX(BITOR(BITSHIFT(id_hi, 32), id_lo)) FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%'";

		// Token: 0x040003B3 RID: 947
		private readonly string string_1;

		// Token: 0x040003B4 RID: 948
		private readonly string string_2;

		// Token: 0x040003B5 RID: 949
		private readonly ICluster icluster_0;

		// Token: 0x040003B6 RID: 950
		private readonly IBucket ibucket_0;

		// Token: 0x040003B7 RID: 951
		private int int_0;
	}
}
