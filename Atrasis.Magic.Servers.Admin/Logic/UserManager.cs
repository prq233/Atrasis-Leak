using System;
using System.Text;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase;
using Couchbase.N1QL;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000013 RID: 19
	public static class UserManager
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000037F8 File Offset: 0x000019F8
		public static void Init()
		{
			UserManager.m_presetLevels = new LogicArrayList<string>();
			UserManager.m_presetRandom = new LogicRandom(TimeUtil.GetTimestamp());
			LogicArrayList<string> presetLevelFiles = EnvironmentSettings.Settings.Admin.PresetLevelFiles;
			for (int i = 0; i < presetLevelFiles.Size(); i++)
			{
				string text = ServerHttpClient.DownloadString("data/" + presetLevelFiles[i]);
				if (text != null)
				{
					UserManager.m_presetLevels.Add(text);
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003868 File Offset: 0x00001A68
		public static async Task<AccountDocument> GetAccount(long id)
		{
			IOperationResult<string> operationResult = await ServerAdmin.AccountDatabase.Get(id);
			IOperationResult<string> operationResult2 = operationResult;
			AccountDocument result;
			if (operationResult2.Success)
			{
				result = CouchbaseDocument.Load<AccountDocument>(operationResult2.Value);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000038B0 File Offset: 0x00001AB0
		public static async void SaveAccount(AccountDocument document)
		{
			await ServerAdmin.AccountDatabase.Update(document.Id, CouchbaseDocument.Save(document));
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000038EC File Offset: 0x00001AEC
		public static async Task<GameDocument> GetAvatar(long id)
		{
			IOperationResult<string> operationResult = await ServerAdmin.GameDatabase.Get(id);
			IOperationResult<string> operationResult2 = operationResult;
			GameDocument result;
			if (operationResult2.Success)
			{
				result = CouchbaseDocument.Load<GameDocument>(operationResult2.Value);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000252C File Offset: 0x0000072C
		public static string GetPresetLevel()
		{
			return UserManager.m_presetLevels[UserManager.m_presetRandom.Rand(UserManager.m_presetLevels.Size())];
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003934 File Offset: 0x00001B34
		public static async Task<JArray> Search(string name, int expLevel, int score, string allianceName)
		{
			StringBuilder stringBuilder = new StringBuilder("SELECT id_hi,id_lo,name,xp_level,score,alliance_name FROM `%BUCKET%` WHERE meta().id LIKE '%KEY_PREFIX%%'");
			if (!string.IsNullOrEmpty(name))
			{
				stringBuilder.Append(" AND LOWER(name) LIKE '%" + name.ToLowerInvariant() + "%'");
			}
			if (expLevel != 0)
			{
				stringBuilder.Append(" AND xp_level == " + expLevel);
			}
			if (score != 0)
			{
				stringBuilder.Append(" AND score == " + score);
			}
			if (!string.IsNullOrEmpty(allianceName))
			{
				stringBuilder.Append(" AND LOWER(alliance_name) LIKE '%" + allianceName.ToLowerInvariant() + "%'");
			}
			stringBuilder.Append(" LIMIT 100");
			IQueryResult<JObject> queryResult = await ServerAdmin.GameDatabase.ExecuteCommand<JObject>(stringBuilder.ToString());
			IQueryResult<JObject> queryResult2 = queryResult;
			JArray result;
			if (queryResult2.Success)
			{
				JArray jarray = new JArray();
				for (int i = 0; i < queryResult2.Rows.Count; i++)
				{
					JObject jobject = queryResult2.Rows[i];
					JObject jobject2 = new JObject();
					LogicLong logicLong = new LogicLong((int)jobject["id_hi"], (int)jobject["id_lo"]);
					jobject2.Add("id", logicLong);
					jobject2.Add("tag", HashTagCodeGenerator.m_instance.ToCode(logicLong));
					jobject2.Add("name", jobject["name"]);
					jobject2.Add("level", jobject["xp_level"]);
					jobject2.Add("score", jobject["score"]);
					if (jobject.ContainsKey("alliance_name"))
					{
						jobject2.Add("allianceName", jobject["alliance_name"]);
					}
					jarray.Add(jobject2);
				}
				result = jarray;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0400003A RID: 58
		private static LogicArrayList<string> m_presetLevels;

		// Token: 0x0400003B RID: 59
		private static LogicRandom m_presetRandom;
	}
}
