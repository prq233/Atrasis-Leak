using System;
using System.Collections.Generic;
using System.Threading;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Util;
using Couchbase.N1QL;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200000F RID: 15
	public static class ServerManager
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003208 File Offset: 0x00001408
		public static int OnlineUsers
		{
			get
			{
				int num = 0;
				ServerPerformance[] array = ServerManager.m_entry[1];
				for (int i = 0; i < array.Length; i++)
				{
					num += array[i].SessionCount;
				}
				return num;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000323C File Offset: 0x0000143C
		public static int AveragePings
		{
			get
			{
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < 30; i++)
				{
					ServerPerformance[] array = ServerManager.m_entry[i];
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j].Status == ServerPerformanceStatus.ONLINE)
						{
							num++;
							num2 = array[j].Ping;
						}
					}
				}
				if (num <= 0)
				{
					return 0;
				}
				return num2 / num;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003298 File Offset: 0x00001498
		public static void Init()
		{
			ServerManager.m_entry = new ServerPerformance[30][];
			for (int i = 0; i < 30; i++)
			{
				ServerPerformance[] array = new ServerPerformance[ServerManager.GetServerCount(i)];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = new ServerPerformance(ServerManager.GetSocket(i, j));
				}
				ServerManager.m_entry[i] = array;
			}
			ServerManager.m_warningIPList = new List<string>();
			ServerManager.m_thread = new Thread(new ThreadStart(ServerManager.Update));
			ServerManager.m_thread.Start();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000331C File Offset: 0x0000151C
		private static void Update()
		{
			Thread.Sleep(5000);
			int num = 0;
			int num2 = TimeUtil.GetTimestamp();
			for (;;)
			{
				if (ServerStatus.Status == ServerStatusType.SHUTDOWN_STARTED && ServerStatus.Time - TimeUtil.GetTimestamp() < 0)
				{
					ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, ServerStatus.NextTime + TimeUtil.GetTimestamp(), 0);
				}
				if (ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE && ServerStatus.Time - TimeUtil.GetTimestamp() < 0)
				{
					ServerStatus.SetStatus(ServerStatusType.NORMAL, 0, 0);
				}
				if (num++ % 20 == 0)
				{
					for (int i = 0; i < 30; i++)
					{
						ServerPerformance[] array = ServerManager.m_entry[i];
						for (int j = 0; j < array.Length; j++)
						{
							array[j].SendPingMessage();
						}
					}
					for (int k = 0; k < 30; k++)
					{
						ServerPerformance[] array2 = ServerManager.m_entry[k];
						for (int l = 0; l < array2.Length; l++)
						{
							ServerMessageManager.SendMessage(new ServerPerformanceMessage(), array2[l].Socket);
						}
					}
					int timestamp = TimeUtil.GetTimestamp();
					ServerManager.CheckAccountIP(timestamp - num2);
					num2 = timestamp;
					if (num == 20)
					{
						num = 1;
					}
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003438 File Offset: 0x00001638
		private static void CheckAccountIP(int timestamp)
		{
			IQueryResult<JObject> result = ServerAdmin.AccountDatabase.ExecuteCommand<JObject>(string.Format("SELECT createIpAddr FROM `%BUCKET%` WHERE meta().id LIKE \"%KEY_PREFIX%%\" AND createTime >= {0}", timestamp)).Result;
			if (result.Success)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				foreach (JObject jobject in result.Rows)
				{
					JToken value;
					if (jobject.TryGetValue("createIpAddr", out value))
					{
						string text = (string)value;
						if (!dictionary.TryAdd(text, 1))
						{
							Dictionary<string, int> dictionary2 = dictionary;
							string key = text;
							dictionary2[key]++;
						}
					}
				}
				foreach (KeyValuePair<string, int> keyValuePair in dictionary)
				{
					if (keyValuePair.Value >= 10 && ServerManager.m_warningIPList.IndexOf(keyValuePair.Key) == -1)
					{
						Logging.Error(string.Format("Malicious action detected. Several accounts ({0}) have been created from this ip address: {1}", keyValuePair.Value, keyValuePair.Key));
						ServerManager.m_warningIPList.Add(keyValuePair.Key);
					}
				}
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000023D2 File Offset: 0x000005D2
		public static void OnPongMessageReceived(PongMessage message)
		{
			ServerManager.m_entry[message.SenderType][message.SenderId].OnPongMessageReceived();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000023EC File Offset: 0x000005EC
		public static void OnServerPerformanceDataMessageReceived(ServerPerformanceDataMessage message)
		{
			ServerManager.m_entry[message.SenderType][message.SenderId].OnServerPerformanceDataMessageReceived(message);
			if (message.SenderType == 1)
			{
				DashboardManager.OnOnlineUsersChanged(ServerManager.OnlineUsers);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000241A File Offset: 0x0000061A
		public static void OnClusterPerformanceDataMessageReceived(ClusterPerformanceDataMessage message)
		{
			ServerManager.m_entry[message.SenderType][message.SenderId].OnClusterPerformanceDataMessageReceived(message);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003580 File Offset: 0x00001780
		public static JObject Save()
		{
			JObject jobject = new JObject();
			JArray jarray = new JArray();
			for (int i = 0; i < 30; i++)
			{
				ServerPerformance[] array = ServerManager.m_entry[i];
				for (int j = 0; j < array.Length; j++)
				{
					jarray.Add(array[j].Save());
				}
			}
			jobject.Add("slots", jarray);
			jobject.Add("status", new JObject
			{
				{
					"type",
					(int)ServerStatus.Status
				},
				{
					"arg",
					ServerStatus.Time
				}
			});
			return jobject;
		}

		// Token: 0x0400002A RID: 42
		private static ServerPerformance[][] m_entry;

		// Token: 0x0400002B RID: 43
		private static Thread m_thread;

		// Token: 0x0400002C RID: 44
		private static List<string> m_warningIPList;
	}
}
