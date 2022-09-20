using System;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using ns0;

namespace Atrasis.Magic.Servers.Core.Network.Message
{
	// Token: 0x0200002D RID: 45
	public abstract class ServerMessageManager
	{
		// Token: 0x060000EF RID: 239
		public abstract void OnReceiveAccountMessage(ServerAccountMessage message);

		// Token: 0x060000F0 RID: 240
		public abstract void OnReceiveRequestMessage(ServerRequestMessage message);

		// Token: 0x060000F1 RID: 241
		public abstract void OnReceiveSessionMessage(ServerSessionMessage message);

		// Token: 0x060000F2 RID: 242
		public abstract void OnReceiveCoreMessage(ServerCoreMessage message);

		// Token: 0x060000F3 RID: 243 RVA: 0x0000B488 File Offset: 0x00009688
		internal static bool smethod_0(ServerCoreMessage serverCoreMessage_0)
		{
			ServerMessageType messageType = serverCoreMessage_0.GetMessageType();
			if (messageType == ServerMessageType.PING)
			{
				ServerMessageManager.SendMessage(new PongMessage(), serverCoreMessage_0.Sender);
				return true;
			}
			if (messageType != ServerMessageType.SERVER_STATUS)
			{
				return false;
			}
			ServerStatusMessage serverStatusMessage = (ServerStatusMessage)serverCoreMessage_0;
			ServerStatus.SetStatus(serverStatusMessage.Type, serverStatusMessage.Time, serverStatusMessage.NextTime);
			return true;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00004F3B File Offset: 0x0000313B
		public static void SendMessage(ServerMessage message, ServerSocket socket)
		{
			Class2.smethod_5(message, socket);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004F44 File Offset: 0x00003144
		public static void SendMessage(ServerMessage message, int serverType, int serverId)
		{
			Class2.smethod_5(message, ServerManager.GetSocket(serverType, serverId));
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004F53 File Offset: 0x00003153
		public static void SendMessage(ServerAccountMessage message, int serverType)
		{
			Class2.smethod_5(message, ServerManager.GetDocumentSocket(serverType, message.AccountId));
		}

		// Token: 0x0200002E RID: 46
		// (Invoke) Token: 0x060000F9 RID: 249
		public delegate void ReceiveServerCoreMessage(ServerCoreMessage message);
	}
}
