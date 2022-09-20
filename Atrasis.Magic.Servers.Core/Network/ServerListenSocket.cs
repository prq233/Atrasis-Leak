using System;
using System.Threading;
using Atrasis.Magic.Servers.Core.Settings;
using NetMQ;
using NetMQ.Sockets;
using ns0;

namespace Atrasis.Magic.Servers.Core.Network
{
	// Token: 0x0200001E RID: 30
	public static class ServerListenSocket
	{
		// Token: 0x060000AA RID: 170 RVA: 0x0000AA44 File Offset: 0x00008C44
		internal static void smethod_0()
		{
			EnvironmentSettings.ServerConnectionEntry serverConnectionEntry = EnvironmentSettings.Servers[ServerCore.Type][ServerCore.Id];
			ServerListenSocket.bool_0 = true;
			ServerListenSocket.netMQSocket_0 = new PullSocket(string.Format("@tcp://{0}:{1}", serverConnectionEntry.ServerIP, serverConnectionEntry.ServerPort));
			ServerListenSocket.netMQSocket_0.Options.ReceiveHighWatermark = 10000;
			ServerListenSocket.thread_0 = new Thread(new ThreadStart(ServerListenSocket.smethod_1));
			ServerListenSocket.thread_0.Start();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004C29 File Offset: 0x00002E29
		public static void DeInit()
		{
			ServerListenSocket.bool_0 = false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000AAC8 File Offset: 0x00008CC8
		private static void smethod_1()
		{
			while (ServerListenSocket.bool_0)
			{
				NetMQMessage netMQMessage = ServerListenSocket.netMQSocket_0.ReceiveMultipartMessage(4);
				while (!netMQMessage.IsEmpty)
				{
					ServerListenSocket.smethod_2(netMQMessage.Pop().Buffer);
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004C31 File Offset: 0x00002E31
		private static void smethod_2(byte[] byte_0)
		{
			Class2.smethod_2(byte_0, byte_0.Length);
		}

		// Token: 0x04000044 RID: 68
		private static NetMQSocket netMQSocket_0;

		// Token: 0x04000045 RID: 69
		private static Thread thread_0;

		// Token: 0x04000046 RID: 70
		private static bool bool_0;
	}
}
