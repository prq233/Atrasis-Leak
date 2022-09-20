using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Servers.Core.Cluster;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Request;

namespace ns0
{
	// Token: 0x0200001B RID: 27
	public class GClass14 : ClusterInstance
	{
		// Token: 0x060000BB RID: 187 RVA: 0x00002784 File Offset: 0x00000984
		public GClass14() : base(0, LogicDataTables.GetGlobals().GetLiveReplayUpdateFrequencySecs() * 1000)
		{
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000279D File Offset: 0x0000099D
		protected override void Tick()
		{
			GClass15.smethod_1(this.m_logicUpdateFrequency);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006C44 File Offset: 0x00004E44
		protected override void ReceiveMessage(ServerMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType > ServerMessageType.END_LIVE_REPLAY)
			{
				switch (messageType)
				{
				case ServerMessageType.INITIALIZE_LIVE_REPLAY:
					GClass14.smethod_0((InitializeLiveReplayMessage)message);
					return;
				case ServerMessageType.LEAVE_ALLIANCE_MEMBER:
				case ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_RESPONSE:
					break;
				case ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_REQUEST:
					GClass14.smethod_4((LiveReplayAddSpectatorRequestMessage)message);
					return;
				case ServerMessageType.LIVE_REPLAY_REMOVE_SPECTATOR:
					GClass14.smethod_5((LiveReplayRemoveSpectatorMessage)message);
					break;
				default:
					if (messageType != ServerMessageType.SERVER_UPDATE_LIVE_REPLAY)
					{
						return;
					}
					GClass14.smethod_2((ServerUpdateLiveReplayMessage)message);
					return;
				}
				return;
			}
			if (messageType == ServerMessageType.CLIENT_UPDATE_LIVE_REPLAY)
			{
				GClass14.smethod_1((ClientUpdateLiveReplayMessage)message);
				return;
			}
			if (messageType != ServerMessageType.END_LIVE_REPLAY)
			{
				return;
			}
			GClass14.smethod_3((EndLiveReplayMessage)message);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006CE4 File Offset: 0x00004EE4
		private static void smethod_0(InitializeLiveReplayMessage initializeLiveReplayMessage_0)
		{
			GClass12 gclass;
			if (GClass15.smethod_5(initializeLiveReplayMessage_0.AccountId, out gclass))
			{
				gclass.method_6(initializeLiveReplayMessage_0.StreamData);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006D0C File Offset: 0x00004F0C
		private static void smethod_1(ClientUpdateLiveReplayMessage clientUpdateLiveReplayMessage_0)
		{
			GClass12 gclass;
			if (GClass15.smethod_5(clientUpdateLiveReplayMessage_0.AccountId, out gclass))
			{
				gclass.method_7(clientUpdateLiveReplayMessage_0.SubTick, clientUpdateLiveReplayMessage_0.Commands);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006D3C File Offset: 0x00004F3C
		private static void smethod_2(ServerUpdateLiveReplayMessage serverUpdateLiveReplayMessage_0)
		{
			GClass12 gclass;
			if (GClass15.smethod_5(serverUpdateLiveReplayMessage_0.AccountId, out gclass))
			{
				gclass.method_9(serverUpdateLiveReplayMessage_0.Milliseconds);
				if (gclass.method_4())
				{
					GClass15.smethod_4(gclass.method_0());
				}
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00006D78 File Offset: 0x00004F78
		private static void smethod_3(EndLiveReplayMessage endLiveReplayMessage_0)
		{
			GClass12 gclass;
			if (GClass15.smethod_5(endLiveReplayMessage_0.AccountId, out gclass))
			{
				gclass.method_8();
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00006D9C File Offset: 0x00004F9C
		private static void smethod_4(LiveReplayAddSpectatorRequestMessage liveReplayAddSpectatorRequestMessage_0)
		{
			GClass12 gclass;
			if (!GClass15.smethod_5(liveReplayAddSpectatorRequestMessage_0.LiveReplayId, out gclass) || gclass.method_11(liveReplayAddSpectatorRequestMessage_0.SessionId, liveReplayAddSpectatorRequestMessage_0.SlotId) || !gclass.method_2())
			{
				ServerRequestManager.SendResponse(new LiveReplayAddSpectatorResponseMessage
				{
					ErrorCode = LiveReplayAddSpectatorResponseMessage.Reason.NOT_EXISTS
				}, liveReplayAddSpectatorRequestMessage_0);
				return;
			}
			if (gclass.method_10())
			{
				ServerRequestManager.SendResponse(new LiveReplayAddSpectatorResponseMessage
				{
					ErrorCode = LiveReplayAddSpectatorResponseMessage.Reason.FULL
				}, liveReplayAddSpectatorRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new LiveReplayAddSpectatorResponseMessage
			{
				Success = true
			}, liveReplayAddSpectatorRequestMessage_0);
			gclass.method_12(liveReplayAddSpectatorRequestMessage_0.SessionId, liveReplayAddSpectatorRequestMessage_0.SlotId);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006E28 File Offset: 0x00005028
		private static void smethod_5(LiveReplayRemoveSpectatorMessage liveReplayRemoveSpectatorMessage_0)
		{
			GClass12 gclass;
			if (GClass15.smethod_5(liveReplayRemoveSpectatorMessage_0.AccountId, out gclass))
			{
				gclass.method_13(liveReplayRemoveSpectatorMessage_0.SessionId, liveReplayRemoveSpectatorMessage_0.SlotId);
			}
		}
	}
}
