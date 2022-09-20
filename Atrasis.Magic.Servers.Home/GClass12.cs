using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;

namespace ns0
{
	// Token: 0x02000011 RID: 17
	public static class GClass12
	{
		// Token: 0x0600007F RID: 127 RVA: 0x00002898 File Offset: 0x00000A98
		public static int smethod_0()
		{
			return GClass12.dictionary_0.Count;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000028A4 File Offset: 0x00000AA4
		public static int smethod_1()
		{
			return GClass12.gclass11_0.Length;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004E08 File Offset: 0x00003008
		public static void smethod_2()
		{
			GClass12.dictionary_0 = new Dictionary<long, GClass11>();
			GClass12.gclass11_0 = new GClass11[Environment.ProcessorCount * 2];
			for (int i = 0; i < Environment.ProcessorCount * 2; i++)
			{
				GClass12.gclass11_0[i] = new GClass11(i, -1);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004E50 File Offset: 0x00003050
		public static void smethod_3(StartServerSessionMessage startServerSessionMessage_0)
		{
			if (GClass12.dictionary_0.ContainsKey(startServerSessionMessage_0.SessionId))
			{
				throw new Exception("GameModeClusterManager.onStartSessionMessageReceived: session already started!");
			}
			GClass11 gclass = GClass12.smethod_6();
			if (gclass != null)
			{
				GClass12.dictionary_0.Add(startServerSessionMessage_0.SessionId, gclass);
				gclass.SendMessage(startServerSessionMessage_0);
				return;
			}
			if (startServerSessionMessage_0.BindRequestMessage != null)
			{
				ServerRequestManager.SendResponse(new BindServerSocketResponseMessage(), startServerSessionMessage_0.BindRequestMessage);
			}
			ServerMessageManager.SendMessage(new StartServerSessionFailedMessage
			{
				SessionId = startServerSessionMessage_0.SessionId
			}, startServerSessionMessage_0.Sender);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004ED0 File Offset: 0x000030D0
		public static void smethod_4(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass11 gclass;
			if (GClass12.dictionary_0.Remove(stopServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.SendMessage(stopServerSessionMessage_0);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004EF8 File Offset: 0x000030F8
		public static void smethod_5(ServerSessionMessage serverSessionMessage_0)
		{
			GClass11 gclass;
			if (GClass12.dictionary_0.TryGetValue(serverSessionMessage_0.SessionId, out gclass))
			{
				gclass.SendMessage(serverSessionMessage_0);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004F20 File Offset: 0x00003120
		private static GClass11 smethod_6()
		{
			GClass11 gclass = null;
			int i = 0;
			int num = int.MaxValue;
			while (i < GClass12.gclass11_0.Length)
			{
				GClass11 gclass2 = GClass12.gclass11_0[i];
				long num2 = gclass2.method_0();
				if (num2 <= 2000L && (gclass == null || num2 < (long)num))
				{
					gclass = gclass2;
					num = (int)num2;
				}
				i++;
			}
			return gclass;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000028AD File Offset: 0x00000AAD
		public static void smethod_7(long long_1)
		{
			GClass12.long_0 += long_1;
			GClass12.int_0++;
			if (GClass12.int_0 >= 1000)
			{
				GClass12.long_0 /= (long)GClass12.int_0;
				GClass12.int_0 = 1;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000028EA File Offset: 0x00000AEA
		public static long smethod_8()
		{
			if (GClass12.int_0 != 0)
			{
				return GClass12.long_0 / (long)GClass12.int_0;
			}
			return 0L;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004F74 File Offset: 0x00003174
		public static void smethod_9()
		{
			for (int i = 0; i < GClass12.gclass11_0.Length; i++)
			{
				GClass12.gclass11_0[i].SendPing();
			}
		}

		// Token: 0x0400002C RID: 44
		private static Dictionary<long, GClass11> dictionary_0;

		// Token: 0x0400002D RID: 45
		private static GClass11[] gclass11_0;

		// Token: 0x0400002E RID: 46
		private static long long_0;

		// Token: 0x0400002F RID: 47
		private static int int_0;
	}
}
