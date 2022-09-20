using System;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;

namespace Atrasis.Magic.Servers.Admin
{
	// Token: 0x02000003 RID: 3
	public static class ServerAdmin
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00000278
		// (set) Token: 0x06000005 RID: 5 RVA: 0x0000207F File Offset: 0x0000027F
		public static CouchbaseDatabase AccountDatabase { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002087 File Offset: 0x00000287
		// (set) Token: 0x06000007 RID: 7 RVA: 0x0000208E File Offset: 0x0000028E
		public static CouchbaseDatabase GameDatabase { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002096 File Offset: 0x00000296
		// (set) Token: 0x06000009 RID: 9 RVA: 0x0000209D File Offset: 0x0000029D
		public static RedisDatabase SessionDatabase { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020A5 File Offset: 0x000002A5
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020AC File Offset: 0x000002AC
		public static RedisDatabase AdminDatabase { get; private set; }

		// Token: 0x0600000C RID: 12 RVA: 0x0000283C File Offset: 0x00000A3C
		public static void Init()
		{
			ServerAdmin.AccountDatabase = new CouchbaseDatabase("magic-players", "account");
			ServerAdmin.AccountDatabase.CreateIndexWithFilter("accountIndex", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id",
				"createTime",
				"lastSessionTime"
			});
			ServerAdmin.GameDatabase = new CouchbaseDatabase("magic-players", "game");
			ServerAdmin.GameDatabase.CreateIndexWithFilter("gameIndex", "meta().id LIKE '%KEY_PREFIX%%'", new string[]
			{
				"meta().id",
				"name",
				"xp_level",
				"score",
				"alliance_name"
			});
			ServerAdmin.SessionDatabase = new RedisDatabase("magic-session", -1);
			ServerAdmin.AdminDatabase = new RedisDatabase("magic-admin", 1);
			DashboardManager.Init();
			Atrasis.Magic.Servers.Admin.Logic.ServerManager.Init();
			UserManager.Init();
			LogManager.Init();
			ServerStatus.OnServerStatusChanged = new ServerStatus.ServerStatusChanged(ServerAdmin.OnServerStatusChanged);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000292C File Offset: 0x00000B2C
		private static void OnServerStatusChanged(ServerStatusType type, int time, int nextTime)
		{
			for (int i = 1; i < 30; i++)
			{
				int j = 0;
				int serverCount = Atrasis.Magic.Servers.Core.Network.ServerManager.GetServerCount(i);
				while (j < serverCount)
				{
					ServerMessageManager.SendMessage(new ServerStatusMessage
					{
						Type = type,
						Time = time,
						NextTime = nextTime
					}, i, j);
					j++;
				}
			}
		}
	}
}
