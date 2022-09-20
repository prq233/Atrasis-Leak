using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Core.Settings;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Core.Database
{
	// Token: 0x020000E8 RID: 232
	public class RedisDatabase
	{
		// Token: 0x060006BC RID: 1724 RVA: 0x000155FC File Offset: 0x000137FC
		public RedisDatabase(string name, int idx = -1)
		{
			EnvironmentSettings.RedisSettings.RedisDatabaseEntry redisDatabaseEntry;
			if (!EnvironmentSettings.Redis.TryGetDatabase(name, out redisDatabaseEntry))
			{
				throw new Exception("Unknown redis database: " + name);
			}
			this.connectionMultiplexer_0 = ConnectionMultiplexer.Connect(redisDatabaseEntry.ConnectionString, null);
			this.idatabase_0 = this.connectionMultiplexer_0.GetDatabase(idx, null);
			EndPoint[] endPoints = this.connectionMultiplexer_0.GetEndPoints(false);
			LuaScript luaScript = LuaScript.Prepare("\r\n                local value = redis.call('GET', KEYS[1])\r\n                if value == ARGV[1] then\r\n                    return redis.call('DEL', KEYS[1]);\r\n                end\r\n                return false;");
			for (int i = 0; i < endPoints.Length; i++)
			{
				byte[] hash = luaScript.Load(this.connectionMultiplexer_0.GetServer(endPoints[i], null), CommandFlags.None).Hash;
				if (hash.Length != 20)
				{
					throw new Exception("RedisDatabase.ctor: hash length != 20");
				}
				if (this.byte_0 != null)
				{
					for (int j = 0; j < 20; j++)
					{
						if (this.byte_0[j] != hash[j])
						{
							throw new Exception("RedisDatabase.ctor: hash mismatch");
						}
					}
				}
				else
				{
					this.byte_0 = hash;
				}
			}
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x00008B83 File Offset: 0x00006D83
		public Task<bool> Exists(long id)
		{
			return this.idatabase_0.KeyExistsAsync(id.ToString(), CommandFlags.None);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00008B9D File Offset: 0x00006D9D
		public Task<bool> Exists(string id)
		{
			return this.idatabase_0.KeyExistsAsync(id, CommandFlags.None);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00008BB1 File Offset: 0x00006DB1
		public Task<bool> Delete(long id)
		{
			return this.idatabase_0.KeyDeleteAsync(id.ToString(), CommandFlags.None);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00008BCB File Offset: 0x00006DCB
		public Task<bool> Delete(string id)
		{
			return this.idatabase_0.KeyDeleteAsync(id, CommandFlags.None);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000156F8 File Offset: 0x000138F8
		public Task<bool> Set(long id, string value)
		{
			return this.idatabase_0.StringSetAsync(id.ToString(), value, null, When.Always, CommandFlags.None);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00015730 File Offset: 0x00013930
		public Task<bool> Set(string id, string value)
		{
			return this.idatabase_0.StringSetAsync(id, value, null, When.Always, CommandFlags.None);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00008BDF File Offset: 0x00006DDF
		public Task<bool> Set(string id, string value, TimeSpan expireDelay)
		{
			return this.idatabase_0.StringSetAsync(id, value, new TimeSpan?(expireDelay), When.Always, CommandFlags.None);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00008C00 File Offset: 0x00006E00
		public Task<RedisValue> GetSet(long id, string value)
		{
			return this.idatabase_0.StringGetSetAsync(id.ToString(), value, CommandFlags.None);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00008C20 File Offset: 0x00006E20
		public Task<RedisValue> Get(long id)
		{
			return this.idatabase_0.StringGetAsync(id.ToString(), CommandFlags.None);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00008C3A File Offset: 0x00006E3A
		public Task<RedisValue> Get(string id)
		{
			return this.idatabase_0.StringGetAsync(id, CommandFlags.None);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00008C4E File Offset: 0x00006E4E
		public Task<RedisValue[]> Get(RedisKey[] ids)
		{
			return this.idatabase_0.StringGetAsync(ids, CommandFlags.None);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00015760 File Offset: 0x00013960
		public void DeleteIfEquals(long id, string value)
		{
			RedisDatabase.Struct1 @struct;
			@struct.redisDatabase_0 = this;
			@struct.long_0 = id;
			@struct.string_0 = value;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<RedisDatabase.Struct1>(ref @struct);
		}

		// Token: 0x040003B8 RID: 952
		private readonly IDatabase idatabase_0;

		// Token: 0x040003B9 RID: 953
		private readonly ConnectionMultiplexer connectionMultiplexer_0;

		// Token: 0x040003BA RID: 954
		private readonly byte[] byte_0;
	}
}
