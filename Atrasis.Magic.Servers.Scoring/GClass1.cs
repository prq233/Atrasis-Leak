using System;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public class GClass1 : ServerMessageManager
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000020C1 File Offset: 0x000002C1
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020C1 File Offset: 0x000002C1
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020C8 File Offset: 0x000002C8
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE)
			{
				GClass1.smethod_0((ForwardLogicRequestMessage)message);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022D4 File Offset: 0x000004D4
		private static void smethod_0(ForwardLogicRequestMessage forwardLogicRequestMessage_0)
		{
			PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicRequestMessage_0.MessageType);
			if (piranhaMessage == null)
			{
				throw new Exception("logicMessage should not be NULL!");
			}
			piranhaMessage.GetByteStream().SetByteArray(forwardLogicRequestMessage_0.MessageBytes, forwardLogicRequestMessage_0.MessageLength);
			piranhaMessage.SetMessageVersion((int)forwardLogicRequestMessage_0.MessageVersion);
			piranhaMessage.Decode();
			if (!piranhaMessage.IsServerToClientMessage())
			{
				switch (piranhaMessage.GetMessageType())
				{
				case 14401:
					GClass1.smethod_1((AskForAllianceRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14402:
				case 14405:
				case 14407:
					break;
				case 14403:
					GClass1.smethod_2((AskForAvatarRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14404:
					GClass1.smethod_3((AskForAvatarLocalRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14406:
					GClass1.smethod_4((AskForAvatarLastSeasonRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14408:
					GClass1.smethod_5((AskForAvatarDuelLastSeasonRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023A8 File Offset: 0x000005A8
		private static void smethod_1(AskForAllianceRankingListMessage askForAllianceRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			if (askForAllianceRankingListMessage_0.GetLocalRanking())
			{
				AllianceLocalRankingListMessage allianceLocalRankingListMessage = new AllianceLocalRankingListMessage();
				allianceLocalRankingListMessage.SetAllianceRankingList(new LogicArrayList<AllianceRankingEntry>(0));
				allianceLocalRankingListMessage.SetVillageType(askForAllianceRankingListMessage_0.GetVillageType());
				ServerMessageManager.SendMessage(GClass1.smethod_6(allianceLocalRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
				return;
			}
			AllianceRankingListMessage allianceRankingListMessage = new AllianceRankingListMessage();
			allianceRankingListMessage.SetAllianceRankingList(GClass2.smethod_11(askForAllianceRankingListMessage_0.GetVillageType(), askForAllianceRankingListMessage_0.RemoveAllianceId()));
			allianceRankingListMessage.SetDiamondPrizes(GClass2.smethod_5());
			allianceRankingListMessage.SetNextEndTimeSeconds(GClass2.smethod_6());
			allianceRankingListMessage.SetVillageType(askForAllianceRankingListMessage_0.GetVillageType());
			ServerMessageManager.SendMessage(GClass1.smethod_6(allianceRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002450 File Offset: 0x00000650
		private static void smethod_2(AskForAvatarRankingListMessage askForAvatarRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			if (askForAvatarRankingListMessage_0.GetVillageType() == 1)
			{
				AvatarDuelRankingListMessage avatarDuelRankingListMessage = new AvatarDuelRankingListMessage();
				LogicLong logicLong_ = askForAvatarRankingListMessage_0.RemoveAvatarId();
				avatarDuelRankingListMessage.SetAvatarRankingList(GClass2.smethod_15(logicLong_));
				avatarDuelRankingListMessage.SetNextEndTimeSeconds(GClass2.smethod_6());
				avatarDuelRankingListMessage.SetSeasonMonth(GClass2.smethod_8());
				avatarDuelRankingListMessage.SetSeasonYear(GClass2.smethod_7());
				avatarDuelRankingListMessage.SetLastSeasonAvatarRankingList(GClass2.smethod_16(logicLong_));
				avatarDuelRankingListMessage.SetLastSeasonMonth(GClass2.smethod_10());
				avatarDuelRankingListMessage.SetLastSeasonYear(GClass2.smethod_9());
				ServerMessageManager.SendMessage(GClass1.smethod_6(avatarDuelRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
				return;
			}
			AvatarRankingListMessage avatarRankingListMessage = new AvatarRankingListMessage();
			LogicLong logicLong_2 = askForAvatarRankingListMessage_0.RemoveAvatarId();
			avatarRankingListMessage.SetAvatarRankingList(GClass2.smethod_13(logicLong_2));
			avatarRankingListMessage.SetNextEndTimeSeconds(GClass2.smethod_6());
			avatarRankingListMessage.SetSeasonMonth(GClass2.smethod_8());
			avatarRankingListMessage.SetSeasonYear(GClass2.smethod_7());
			avatarRankingListMessage.SetLastSeasonAvatarRankingList(GClass2.smethod_14(logicLong_2));
			avatarRankingListMessage.SetLastSeasonMonth(GClass2.smethod_10());
			avatarRankingListMessage.SetLastSeasonYear(GClass2.smethod_9());
			ServerMessageManager.SendMessage(GClass1.smethod_6(avatarRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020E2 File Offset: 0x000002E2
		private static void smethod_3(AskForAvatarLocalRankingListMessage askForAvatarLocalRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			AvatarLocalRankingListMessage avatarLocalRankingListMessage = new AvatarLocalRankingListMessage();
			avatarLocalRankingListMessage.SetAvatarRankingList(new LogicArrayList<AvatarRankingEntry>(0));
			ServerMessageManager.SendMessage(GClass1.smethod_6(avatarLocalRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002554 File Offset: 0x00000754
		private static void smethod_4(AskForAvatarLastSeasonRankingListMessage askForAvatarLastSeasonRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			AvatarLastSeasonRankingListMessage avatarLastSeasonRankingListMessage = new AvatarLastSeasonRankingListMessage();
			avatarLastSeasonRankingListMessage.SetAvatarRankingList(GClass2.smethod_14(askForAvatarLastSeasonRankingListMessage_0.RemoveAvatarId()));
			avatarLastSeasonRankingListMessage.SetSeasonYear(GClass2.smethod_9());
			avatarLastSeasonRankingListMessage.SetSeasonMonth(GClass2.smethod_10());
			ServerMessageManager.SendMessage(GClass1.smethod_6(avatarLastSeasonRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000025A8 File Offset: 0x000007A8
		private static void smethod_5(AskForAvatarDuelLastSeasonRankingListMessage askForAvatarDuelLastSeasonRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			AvatarDuelLastSeasonRankingListMessage avatarDuelLastSeasonRankingListMessage = new AvatarDuelLastSeasonRankingListMessage();
			avatarDuelLastSeasonRankingListMessage.SetAvatarRankingList(GClass2.smethod_16(askForAvatarDuelLastSeasonRankingListMessage_0.RemoveAvatarId()));
			avatarDuelLastSeasonRankingListMessage.SetSeasonYear(GClass2.smethod_9());
			avatarDuelLastSeasonRankingListMessage.SetSeasonMonth(GClass2.smethod_10());
			ServerMessageManager.SendMessage(GClass1.smethod_6(avatarDuelLastSeasonRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000025FC File Offset: 0x000007FC
		private static ForwardLogicMessage smethod_6(PiranhaMessage piranhaMessage_0, long long_0)
		{
			if (piranhaMessage_0.GetEncodingLength() == 0)
			{
				piranhaMessage_0.Encode();
			}
			return new ForwardLogicMessage
			{
				SessionId = long_0,
				MessageType = piranhaMessage_0.GetMessageType(),
				MessageVersion = (short)piranhaMessage_0.GetMessageVersion(),
				MessageLength = piranhaMessage_0.GetEncodingLength(),
				MessageBytes = piranhaMessage_0.GetMessageBytes()
			};
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002654 File Offset: 0x00000854
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType != ServerMessageType.SCORING_SYNC)
			{
				if (messageType == ServerMessageType.SERVER_PERFORMANCE)
				{
					ServerMessageManager.SendMessage(new ServerPerformanceDataMessage(), message.Sender);
					return;
				}
			}
			else
			{
				GClass2.smethod_4((ScoringSyncMessage)message);
			}
		}
	}
}
