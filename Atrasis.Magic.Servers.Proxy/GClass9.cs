using System;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000013 RID: 19
	public class GClass9 : ServerMessageManager
	{
		// Token: 0x06000076 RID: 118 RVA: 0x000024A1 File Offset: 0x000006A1
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000024A3 File Offset: 0x000006A3
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.BIND_SERVER_SOCKET_REQUEST)
			{
				GClass9.smethod_0((BindServerSocketRequestMessage)message);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000466C File Offset: 0x0000286C
		private static void smethod_0(BindServerSocketRequestMessage bindServerSocketRequestMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_5(bindServerSocketRequestMessage_0.SessionId, out gclass))
			{
				ServerSocket serverSocket = (bindServerSocketRequestMessage_0.ServerId != -1) ? ServerManager.GetSocket(bindServerSocketRequestMessage_0.ServerType, bindServerSocketRequestMessage_0.ServerId) : ServerManager.GetNextSocket(bindServerSocketRequestMessage_0.ServerType);
				if (serverSocket == null)
				{
					ServerRequestManager.SendResponse(new BindServerSocketResponseMessage
					{
						ServerType = bindServerSocketRequestMessage_0.ServerType,
						ServerId = bindServerSocketRequestMessage_0.ServerId,
						Success = false
					}, bindServerSocketRequestMessage_0);
					return;
				}
				gclass.method_2(serverSocket, bindServerSocketRequestMessage_0);
				if (bindServerSocketRequestMessage_0.InitSessionMessage != null)
				{
					gclass.SendMessage(bindServerSocketRequestMessage_0.InitSessionMessage, serverSocket.ServerType);
					return;
				}
			}
			else
			{
				ServerRequestManager.SendResponse(new BindServerSocketResponseMessage
				{
					ServerType = bindServerSocketRequestMessage_0.ServerType,
					ServerId = bindServerSocketRequestMessage_0.ServerId,
					Success = false
				}, bindServerSocketRequestMessage_0);
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000472C File Offset: 0x0000292C
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType == ServerMessageType.FORWARD_LOGIC_MESSAGE)
			{
				GClass9.smethod_5((ForwardLogicMessage)message);
				return;
			}
			switch (messageType)
			{
			case ServerMessageType.START_SERVER_SESSION_FAILED:
				GClass9.smethod_1((StartServerSessionFailedMessage)message);
				return;
			case ServerMessageType.STOP_SERVER_SESSION:
				GClass9.smethod_3((StopServerSessionMessage)message);
				return;
			case ServerMessageType.STOP_SESSION:
				GClass9.smethod_2((StopSessionMessage)message);
				return;
			case ServerMessageType.STOP_SPECIFIED_SERVER_SESSION:
				GClass9.smethod_4((StopSpecifiedServerSessionMessage)message);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000047A0 File Offset: 0x000029A0
		private static void smethod_1(StartServerSessionFailedMessage startServerSessionFailedMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_5(startServerSessionFailedMessage_0.SessionId, out gclass) && gclass.IsBoundToServerType(startServerSessionFailedMessage_0.SenderType) && gclass.method_4(startServerSessionFailedMessage_0.SenderType).ServerId == startServerSessionFailedMessage_0.SenderId)
			{
				gclass.method_3(startServerSessionFailedMessage_0.SenderType, true);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000047F0 File Offset: 0x000029F0
		private static void smethod_2(StopSessionMessage stopSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_5(stopSessionMessage_0.SessionId, out gclass))
			{
				GClass4.smethod_7(gclass.method_0(), stopSessionMessage_0.Reason);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00004820 File Offset: 0x00002A20
		private static void smethod_3(StopServerSessionMessage stopServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_5(stopServerSessionMessage_0.SessionId, out gclass))
			{
				ServerSocket serverSocket = gclass.method_4(stopServerSessionMessage_0.SenderType);
				if (serverSocket != null && serverSocket.ServerId == stopServerSessionMessage_0.SenderId)
				{
					gclass.method_3(stopServerSessionMessage_0.SenderType, false);
				}
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004868 File Offset: 0x00002A68
		private static void smethod_4(StopSpecifiedServerSessionMessage stopSpecifiedServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_5(stopSpecifiedServerSessionMessage_0.SessionId, out gclass))
			{
				ServerSocket serverSocket = gclass.method_4(stopSpecifiedServerSessionMessage_0.ServerType);
				if (serverSocket != null && serverSocket.ServerId == stopSpecifiedServerSessionMessage_0.ServerId)
				{
					gclass.method_3(stopSpecifiedServerSessionMessage_0.ServerType, true);
				}
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000048B0 File Offset: 0x00002AB0
		private static void smethod_5(ForwardLogicMessage forwardLogicMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_5(forwardLogicMessage_0.SessionId, out gclass))
			{
				PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicMessage_0.MessageType);
				if (piranhaMessage == null)
				{
					Logging.Error("ProxyMessageManager.onForwardLogicMessageReceived: unknown logic message type: " + forwardLogicMessage_0.MessageType);
					return;
				}
				piranhaMessage.SetMessageVersion((int)forwardLogicMessage_0.MessageVersion);
				piranhaMessage.GetByteStream().SetByteArray(forwardLogicMessage_0.MessageBytes, forwardLogicMessage_0.MessageLength);
				piranhaMessage.GetByteStream().SetOffset(forwardLogicMessage_0.MessageLength);
				gclass.method_0().method_1().method_10(piranhaMessage);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000024BD File Offset: 0x000006BD
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage
				{
					SessionCount = GClass2.smethod_0()
				}, message.Sender);
			}
		}
	}
}
