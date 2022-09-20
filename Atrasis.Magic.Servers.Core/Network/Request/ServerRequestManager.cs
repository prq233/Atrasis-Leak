using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using ns0;

namespace Atrasis.Magic.Servers.Core.Network.Request
{
	// Token: 0x02000026 RID: 38
	public static class ServerRequestManager
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00004DEE File Offset: 0x00002FEE
		public static void Init()
		{
			ServerRequestManager.bool_0 = true;
			ServerRequestManager.concurrentDictionary_0 = new ConcurrentDictionary<long, ServerRequestArgs>();
			ServerRequestManager.thread_0 = new Thread(new ThreadStart(ServerRequestManager.smethod_0));
			ServerRequestManager.thread_0.Start();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000AD94 File Offset: 0x00008F94
		private static void smethod_0()
		{
			while (ServerRequestManager.bool_0)
			{
				DateTime utcNow = DateTime.UtcNow;
				foreach (KeyValuePair<long, ServerRequestArgs> keyValuePair in ServerRequestManager.concurrentDictionary_0)
				{
					ServerRequestArgs serverRequestArgs;
					if (utcNow > keyValuePair.Value.ExpireTime && ServerRequestManager.concurrentDictionary_0.TryRemove(keyValuePair.Key, out serverRequestArgs))
					{
						keyValuePair.Value.method_0();
					}
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000AE2C File Offset: 0x0000902C
		public static ServerRequestArgs Create(ServerRequestMessage message, ServerSocket socket, int timeout = 30)
		{
			ServerRequestArgs serverRequestArgs = new ServerRequestArgs(timeout);
			long num = Interlocked.Increment(ref ServerRequestManager.long_0);
			message.RequestId = num;
			if (!ServerRequestManager.concurrentDictionary_0.TryAdd(num, serverRequestArgs))
			{
				throw new Exception("Unable to add new message");
			}
			Class2.smethod_5(message, socket);
			return serverRequestArgs;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004E20 File Offset: 0x00003020
		public static void SendResponse(ServerResponseMessage response, ServerRequestMessage request)
		{
			response.RequestId = request.RequestId;
			Class2.smethod_5(response, ServerManager.GetSocket(request.SenderType, request.SenderId));
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000AE74 File Offset: 0x00009074
		internal static void smethod_1(ServerResponseMessage serverResponseMessage_0)
		{
			ServerRequestArgs serverRequestArgs;
			if (ServerRequestManager.concurrentDictionary_0.TryRemove(serverResponseMessage_0.RequestId, out serverRequestArgs))
			{
				serverRequestArgs.method_1(serverResponseMessage_0);
			}
		}

		// Token: 0x04000058 RID: 88
		private static ConcurrentDictionary<long, ServerRequestArgs> concurrentDictionary_0;

		// Token: 0x04000059 RID: 89
		private static Thread thread_0;

		// Token: 0x0400005A RID: 90
		private static bool bool_0;

		// Token: 0x0400005B RID: 91
		private static long long_0;
	}
}
