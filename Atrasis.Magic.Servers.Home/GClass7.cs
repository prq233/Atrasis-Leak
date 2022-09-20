using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000C RID: 12
	public class GClass7 : LogicAvatarChangeListener
	{
		// Token: 0x06000044 RID: 68 RVA: 0x000022B7 File Offset: 0x000004B7
		public GClass7(GClass6 gclass6_1, LogicClientAvatar logicClientAvatar_1)
		{
			this.gclass6_0 = gclass6_1;
			this.logicClientAvatar_0 = logicClientAvatar_1;
			this.logicArrayList_0 = new LogicArrayList<AvatarChange>(16);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000022DA File Offset: 0x000004DA
		public LogicArrayList<AvatarChange> method_0()
		{
			LogicArrayList<AvatarChange> logicArrayList = new LogicArrayList<AvatarChange>();
			logicArrayList.AddAll(this.logicArrayList_0);
			this.logicArrayList_0.Clear();
			return logicArrayList;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000022F8 File Offset: 0x000004F8
		public override void FreeDiamondsAdded(int count, int mode)
		{
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002311 File Offset: 0x00000511
		public override void DiamondPurchaseMade(int type, int globalId, int level, int count, int villageType)
		{
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = -count
			});
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000232C File Offset: 0x0000052C
		public override void CommodityCountChanged(int commodityType, LogicData data, int count)
		{
			this.logicArrayList_0.Add(new CommodityCountAvatarChange
			{
				Type = commodityType,
				Data = data,
				Count = count
			});
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004768 File Offset: 0x00002968
		public override void WarPreferenceChanged(int preference)
		{
			ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
			{
				AccountId = this.logicClientAvatar_0.GetId(),
				ServerCommand = new LogicPersonalWarPreferenceCommand(preference)
			}, 9);
			this.logicArrayList_0.Add(new WarPreferenceAvatarChange
			{
				Preference = preference
			});
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002353 File Offset: 0x00000553
		public override void ExpPointsGained(int count)
		{
			this.logicArrayList_0.Add(new ExpPointsAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000236C File Offset: 0x0000056C
		public override void ExpLevelGained(int count)
		{
			this.logicArrayList_0.Add(new ExpLevelAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002385 File Offset: 0x00000585
		public override void AllianceJoined(LogicLong allianceId, string allianceName, int allianceBadgeId, int allianceExpLevel, LogicAvatarAllianceRole allianceRole)
		{
			this.logicArrayList_0.Add(new AllianceJoinedAvatarChange
			{
				AllianceId = allianceId,
				AllianceName = allianceName,
				AllianceBadgeId = allianceBadgeId,
				AllianceExpLevel = allianceExpLevel,
				AllianceRole = allianceRole
			});
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000023BC File Offset: 0x000005BC
		public override void AllianceLeft()
		{
			this.logicArrayList_0.Add(new AllianceLeftAvatarChange());
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000023CE File Offset: 0x000005CE
		public override void AllianceLevelChanged(int expLevel)
		{
			this.logicArrayList_0.Add(new AllianceLevelAvatarChange
			{
				Level = expLevel
			});
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000023E7 File Offset: 0x000005E7
		public override void AllianceUnitAdded(LogicCombatItemData data, int upgLevel)
		{
			this.logicArrayList_0.Add(new AllianceUnitAddedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002407 File Offset: 0x00000607
		public override void AllianceUnitRemoved(LogicCombatItemData data, int upgLevel)
		{
			this.logicArrayList_0.Add(new AllianceUnitRemovedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002427 File Offset: 0x00000627
		public override void AllianceUnitCountChanged(LogicCombatItemData data, int upgLevel, int count)
		{
			this.logicArrayList_0.Add(new AllianceUnitCountAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel,
				Count = count
			});
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000244E File Offset: 0x0000064E
		public override void SetAllianceCastleLevel(int count)
		{
			this.logicArrayList_0.Add(new AllianceCastleLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002467 File Offset: 0x00000667
		public override void SetTownHallLevel(int count)
		{
			this.logicArrayList_0.Add(new TownHallLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002480 File Offset: 0x00000680
		public override void SetVillage2TownHallLevel(int count)
		{
			this.logicArrayList_0.Add(new TownHallV2LevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002499 File Offset: 0x00000699
		public override void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
		{
			this.logicArrayList_0.Add(new LegendSeasonScoreAvatarChange
			{
				Entry = ((villageType == 0) ? this.logicClientAvatar_0.GetLegendSeasonEntry() : this.logicClientAvatar_0.GetLegendSeasonEntryVillage2())
			});
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000024CD File Offset: 0x000006CD
		public override void ScoreChanged(LogicLong allianceId, int scoreGain, int minScoreGain, bool attacker, LogicLeagueData leagueData, LogicLeagueData prevLeagueData, int destructionPercentage)
		{
			this.logicArrayList_0.Add(new ScoreAvatarChange
			{
				Attacker = attacker,
				LeagueData = leagueData,
				PrevLeagueData = prevLeagueData,
				ScoreGain = scoreGain
			});
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000024FE File Offset: 0x000006FE
		public override void DuelScoreChanged(LogicLong allianceId, int duelScoreGain, int resultType, bool attacker)
		{
			this.logicArrayList_0.Add(new DuelScoreAvatarChange
			{
				Attacker = attacker,
				DuelScoreGain = duelScoreGain,
				ResultType = resultType
			});
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002526 File Offset: 0x00000726
		public override void LeagueChanged(int leagueType, LogicLong leagueInstanceId)
		{
			this.logicArrayList_0.Add(new LeagueAvatarChange
			{
				LeagueInstanceId = leagueInstanceId,
				LeagueType = leagueType
			});
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002546 File Offset: 0x00000746
		public override void AttackShieldReduceCounterChanged(int count)
		{
			this.logicArrayList_0.Add(new AttackShieldReduceCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000255F File Offset: 0x0000075F
		public override void DefenseVillageGuardCounterChanged(int count)
		{
			this.logicArrayList_0.Add(new DefenseVillageGuardCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002578 File Offset: 0x00000778
		public override void REDPackageStateChanged(int value)
		{
			this.logicArrayList_0.Add(new REDPackageStateAvatarChange
			{
				State = value
			});
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002591 File Offset: 0x00000791
		public void method_1(string string_0, int int_0)
		{
			this.logicArrayList_0.Add(new NameAvatarChange
			{
				Name = string_0,
				NameChangeState = int_0
			});
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000025B1 File Offset: 0x000007B1
		public override void SendClanMail(string message)
		{
			ServerMessageManager.SendMessage(new AllianceCreateMailMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				Message = message
			}, 11);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000025E8 File Offset: 0x000007E8
		public override void ShareReplay(LogicLong replayId, string message)
		{
			ServerMessageManager.SendMessage(new AllianceShareReplayMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				ReplayId = replayId,
				Message = message
			}, 11);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002626 File Offset: 0x00000826
		public override void ShareDuelReplay(LogicLong replayId, string message)
		{
			ServerMessageManager.SendMessage(new AllianceShareDuelReplayMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				ReplayId = replayId
			}, 11);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000047B8 File Offset: 0x000029B8
		public override void RequestAllianceUnits(int upgLevel, int usedCapacity, int maxCapacity, int spellUsedCapacity, int maxSpellCapacity, string message)
		{
			ServerMessageManager.SendMessage(new AllianceRequestAllianceUnitsMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				Message = message,
				CastleUpgradeLevel = upgLevel,
				CastleUsedCapacity = usedCapacity,
				CastleTotalCapacity = maxCapacity,
				CastleSpellUsedCapacity = spellUsedCapacity,
				CastleSpellTotalCapacity = maxSpellCapacity
			}, 11);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004820 File Offset: 0x00002A20
		public override void AllianceUnitDonateOk(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
			ServerMessageManager.SendMessage(new AllianceUnitDonateResponseMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				MemberName = this.logicClientAvatar_0.GetName(),
				StreamId = streamId,
				Data = data,
				UpgradeLevel = upgLevel,
				QuickDonate = quickDonate,
				Success = true
			}, 11);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004890 File Offset: 0x00002A90
		public override void AllianceUnitDonateFailed(LogicCombatItemData data, int upgLevel, LogicLong streamId, bool quickDonate)
		{
			ServerMessageManager.SendMessage(new AllianceUnitDonateResponseMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				StreamId = streamId,
				Data = data,
				UpgradeLevel = upgLevel,
				QuickDonate = quickDonate
			}, 11);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000048E8 File Offset: 0x00002AE8
		public override void SendChallengeRequest(string message, int layoutId, bool warLayout, int villageType)
		{
			if (villageType == 0)
			{
				ServerMessageManager.SendMessage(new AllianceChallengeRequestMessage
				{
					AccountId = this.logicClientAvatar_0.GetAllianceId(),
					MemberId = this.logicClientAvatar_0.GetId(),
					HomeJSON = this.gclass6_0.method_14(),
					Message = message,
					WarLayout = warLayout
				}, 11);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000265D File Offset: 0x0000085D
		public override void KickPlayer(LogicLong playerId, string message)
		{
			ServerMessageManager.SendMessage(new AllianceKickMemberMessage
			{
				AccountId = this.logicClientAvatar_0.GetAllianceId(),
				MemberId = this.logicClientAvatar_0.GetId(),
				KickMemberId = playerId,
				Message = message
			}, 11);
		}

		// Token: 0x0400001E RID: 30
		private readonly GClass6 gclass6_0;

		// Token: 0x0400001F RID: 31
		private readonly LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000020 RID: 32
		private readonly LogicArrayList<AvatarChange> logicArrayList_0;
	}
}
