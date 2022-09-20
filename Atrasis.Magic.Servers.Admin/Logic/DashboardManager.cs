using System;
using System.Threading;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Couchbase.N1QL;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000009 RID: 9
	public static class DashboardManager
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002224 File Offset: 0x00000424
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000222B File Offset: 0x0000042B
		public static int[] TotalUsers { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002233 File Offset: 0x00000433
		// (set) Token: 0x0600003C RID: 60 RVA: 0x0000223A File Offset: 0x0000043A
		public static int[] DailyActiveUsers { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002242 File Offset: 0x00000442
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002249 File Offset: 0x00000449
		public static int[] NewUsers { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002251 File Offset: 0x00000451
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002258 File Offset: 0x00000458
		public static int[] MaxOnlineUsers { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002260 File Offset: 0x00000460
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002267 File Offset: 0x00000467
		public static DateTime LastUpdate { get; private set; }

		// Token: 0x06000043 RID: 67 RVA: 0x00002BFC File Offset: 0x00000DFC
		public static void Init()
		{
			DashboardManager.TotalUsers = new int[7];
			DashboardManager.DailyActiveUsers = new int[7];
			DashboardManager.NewUsers = new int[7];
			DashboardManager.MaxOnlineUsers = new int[7];
			DashboardManager.m_thread = new Thread(new ThreadStart(DashboardManager.Update));
			DashboardManager.m_thread.Start();
			DashboardManager.Load();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002C5C File Offset: 0x00000E5C
		private static void Update()
		{
			Thread.Sleep(5000);
			for (;;)
			{
				DateTime utcNow = DateTime.UtcNow;
				if (utcNow.Date > DashboardManager.LastUpdate.Date)
				{
					Array.Copy(DashboardManager.TotalUsers, 1, DashboardManager.TotalUsers, 0, 6);
					Array.Copy(DashboardManager.DailyActiveUsers, 1, DashboardManager.DailyActiveUsers, 0, 6);
					Array.Copy(DashboardManager.NewUsers, 1, DashboardManager.NewUsers, 0, 6);
					Array.Copy(DashboardManager.MaxOnlineUsers, 1, DashboardManager.MaxOnlineUsers, 0, 6);
					DashboardManager.m_tempMaxOnlineUsers = ServerManager.OnlineUsers;
				}
				DashboardManager.LastUpdate = utcNow;
				int timestamp = TimeUtil.GetTimestamp(utcNow.Date);
				int num = timestamp + 86400;
				IQueryResult<JObject> result = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>("SELECT COUNT(*) FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\"").Result;
				IQueryResult<JObject> result2 = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>(string.Concat(new object[]
				{
					"SELECT COUNT(*) FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\" AND lastSessionTime BETWEEN ",
					timestamp,
					" AND ",
					num
				})).Result;
				IQueryResult<JObject> result3 = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>("SELECT COUNT(*) FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\" AND createTime >= " + timestamp).Result;
				if (result.Success)
				{
					DashboardManager.TotalUsers[6] = (int)result.Rows[0]["$1"];
				}
				if (result2.Success)
				{
					DashboardManager.DailyActiveUsers[6] = (int)result2.Rows[0]["$1"];
				}
				if (result3.Success)
				{
					DashboardManager.NewUsers[6] = (int)result3.Rows[0]["$1"];
				}
				DashboardManager.MaxOnlineUsers[6] = DashboardManager.m_tempMaxOnlineUsers;
				DashboardManager.Save();
				Thread.Sleep(LogicMath.Min((int)utcNow.Date.AddDays(1.0).Subtract(utcNow).TotalMilliseconds + 1000, 30000));
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000226F File Offset: 0x0000046F
		public static void OnOnlineUsersChanged(int count)
		{
			if (count > DashboardManager.m_tempMaxOnlineUsers)
			{
				DashboardManager.m_tempMaxOnlineUsers = count;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002E5C File Offset: 0x0000105C
		private static async void Load()
		{
			RedisValue redisValue = await ServerAdmin.AdminDatabase.Get("dashboard");
			RedisValue value = redisValue;
			if (!value.IsNullOrEmpty)
			{
				LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(value);
				LogicJSONArray jsonarray = logicJSONObject.GetJSONArray("totalUsers");
				LogicJSONArray jsonarray2 = logicJSONObject.GetJSONArray("dailyActiveUsers");
				LogicJSONArray jsonarray3 = logicJSONObject.GetJSONArray("newUsers");
				LogicJSONArray jsonarray4 = logicJSONObject.GetJSONArray("maxOnlineUsers");
				for (int i = 0; i < 7; i++)
				{
					DashboardManager.TotalUsers[i] = jsonarray.GetJSONNumber(i).GetIntValue();
					DashboardManager.DailyActiveUsers[i] = jsonarray2.GetJSONNumber(i).GetIntValue();
					DashboardManager.NewUsers[i] = jsonarray3.GetJSONNumber(i).GetIntValue();
					DashboardManager.MaxOnlineUsers[i] = jsonarray4.GetJSONNumber(i).GetIntValue();
				}
				DashboardManager.m_tempMaxOnlineUsers = DashboardManager.MaxOnlineUsers[6];
				DashboardManager.LastUpdate = TimeUtil.GetDateTimeFromTimestamp(logicJSONObject.GetJSONNumber("time").GetIntValue());
				while (DateTime.UtcNow.Date > DashboardManager.LastUpdate)
				{
					Array.Copy(DashboardManager.TotalUsers, 1, DashboardManager.TotalUsers, 0, 6);
					Array.Copy(DashboardManager.DailyActiveUsers, 1, DashboardManager.DailyActiveUsers, 0, 6);
					Array.Copy(DashboardManager.NewUsers, 1, DashboardManager.NewUsers, 0, 6);
					Array.Copy(DashboardManager.MaxOnlineUsers, 1, DashboardManager.MaxOnlineUsers, 0, 6);
				}
			}
			else
			{
				DashboardManager.LastUpdate = DateTime.UtcNow;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002E90 File Offset: 0x00001090
		private static void Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONArray logicJSONArray = new LogicJSONArray(7);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(7);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray(7);
			LogicJSONArray logicJSONArray4 = new LogicJSONArray(7);
			for (int i = 0; i < 7; i++)
			{
				logicJSONArray.Add(new LogicJSONNumber(DashboardManager.TotalUsers[i]));
				logicJSONArray2.Add(new LogicJSONNumber(DashboardManager.DailyActiveUsers[i]));
				logicJSONArray3.Add(new LogicJSONNumber(DashboardManager.NewUsers[i]));
				logicJSONArray4.Add(new LogicJSONNumber(DashboardManager.MaxOnlineUsers[i]));
			}
			logicJSONObject.Put("totalUsers", logicJSONArray);
			logicJSONObject.Put("dailyActiveUsers", logicJSONArray2);
			logicJSONObject.Put("newUsers", logicJSONArray3);
			logicJSONObject.Put("maxOnlineUsers", logicJSONArray4);
			logicJSONObject.Put("time", new LogicJSONNumber(TimeUtil.GetTimestamp(DashboardManager.LastUpdate)));
			ServerAdmin.AdminDatabase.Set("dashboard", LogicJSONParser.CreateJSONString(logicJSONObject, 20));
		}

		// Token: 0x04000016 RID: 22
		private static int m_tempMaxOnlineUsers;

		// Token: 0x04000017 RID: 23
		private static Thread m_thread;
	}
}
