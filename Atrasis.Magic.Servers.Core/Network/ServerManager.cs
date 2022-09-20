using System;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network
{
	// Token: 0x0200001F RID: 31
	public static class ServerManager
	{
		// Token: 0x060000AE RID: 174 RVA: 0x0000AB08 File Offset: 0x00008D08
		public static void Init()
		{
			ServerManager.bool_0 = true;
			ServerManager.int_0 = new int[30];
			ServerManager.serverSocket_0 = new ServerSocket[30][];
			for (int i = 0; i < 30; i++)
			{
				EnvironmentSettings.ServerConnectionEntry[] array = EnvironmentSettings.Servers[i];
				ServerManager.serverSocket_0[i] = new ServerSocket[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					ServerManager.serverSocket_0[i][j] = new ServerSocket(i, j, array[j].ServerIP, array[j].ServerPort);
				}
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004C3C File Offset: 0x00002E3C
		public static bool IsInit()
		{
			return ServerManager.bool_0;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AB90 File Offset: 0x00008D90
		public static void DeInit()
		{
			if (ServerManager.serverSocket_0 != null)
			{
				for (int i = 0; i < 30; i++)
				{
					ServerSocket[] array = ServerManager.serverSocket_0[i];
					for (int j = 0; j < array.Length; j++)
					{
						array[j].Destruct();
					}
				}
				ServerManager.serverSocket_0 = null;
			}
			ServerManager.int_0 = null;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004C43 File Offset: 0x00002E43
		public static ServerSocket GetSocket(int type, int id)
		{
			return ServerManager.serverSocket_0[type][id];
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000ABDC File Offset: 0x00008DDC
		public static ServerSocket GetNextSocket(int type)
		{
			if (ServerManager.serverSocket_0[type].Length != 0)
			{
				int num = ServerManager.int_0[type];
				ServerManager.int_0[type] = (ServerManager.int_0[type] + 1 & ServerManager.serverSocket_0[type].Length - 1);
				return ServerManager.serverSocket_0[type][num];
			}
			return null;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004C4E File Offset: 0x00002E4E
		public static ServerSocket GetDocumentSocket(int type, LogicLong id)
		{
			if (ServerManager.serverSocket_0[type].Length != 0 && id.GetLowerInt() > 0)
			{
				return ServerManager.serverSocket_0[type][(id.GetLowerInt() - 1) % ServerManager.serverSocket_0[type].Length];
			}
			return null;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004C7F File Offset: 0x00002E7F
		public static ServerSocket GetProxySocket(long sessionId)
		{
			return ServerManager.serverSocket_0[1][(int)(sessionId >> 55)];
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004C8E File Offset: 0x00002E8E
		public static int GetServerCount(int type)
		{
			return ServerManager.serverSocket_0[type].Length;
		}

		// Token: 0x04000047 RID: 71
		private static bool bool_0;

		// Token: 0x04000048 RID: 72
		private static int[] int_0;

		// Token: 0x04000049 RID: 73
		private static ServerSocket[][] serverSocket_0;
	}
}
