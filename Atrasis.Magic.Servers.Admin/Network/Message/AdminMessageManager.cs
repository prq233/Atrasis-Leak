using System;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace Atrasis.Magic.Servers.Admin.Network.Message
{
	// Token: 0x02000005 RID: 5
	public class AdminMessageManager : ServerMessageManager
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000020DA File Offset: 0x000002DA
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020DA File Offset: 0x000002DA
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020DA File Offset: 0x000002DA
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000029D0 File Offset: 0x00000BD0
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.CLUSTER_PERFORMANCE_DATA)
			{
				if (messageType == ServerMessageType.ASK_FOR_SERVER_STATUS)
				{
					ServerMessageManager.SendMessage(new ServerStatusMessage
					{
						Type = ServerStatus.Status,
						Time = ServerStatus.Time,
						NextTime = ServerStatus.NextTime
					}, message.Sender);
					return;
				}
				if (messageType != ServerMessageType.CLUSTER_PERFORMANCE_DATA)
				{
					return;
				}
				ServerManager.OnClusterPerformanceDataMessageReceived((ClusterPerformanceDataMessage)message);
				return;
			}
			else
			{
				if (messageType == ServerMessageType.GAME_LOG)
				{
					LogManager.OnGameLogMessage((GameLogMessage)message);
					return;
				}
				if (messageType == ServerMessageType.PONG)
				{
					ServerManager.OnPongMessageReceived((PongMessage)message);
					return;
				}
				switch (messageType)
				{
				case ServerMessageType.SERVER_LOG:
					LogManager.OnServerLogMessage((ServerLogMessage)message);
					return;
				case ServerMessageType.SERVER_PERFORMANCE:
					ServerMessageManager.SendMessage(new ServerPerformanceDataMessage(), message.SenderType, message.SenderId);
					return;
				case ServerMessageType.SERVER_PERFORMANCE_DATA:
					ServerManager.OnServerPerformanceDataMessageReceived((ServerPerformanceDataMessage)message);
					return;
				default:
					return;
				}
			}
		}
	}
}
