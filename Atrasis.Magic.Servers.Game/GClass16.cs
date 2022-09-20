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
	// Token: 0x0200001D RID: 29
	public class GClass16 : LogicAvatarChangeListener
	{
		// Token: 0x060000CB RID: 203 RVA: 0x00002816 File Offset: 0x00000A16
		public GClass16(LogicClientAvatar logicClientAvatar_1)
		{
			this.logicClientAvatar_0 = logicClientAvatar_1;
			this.logicArrayList_0 = new LogicArrayList<AvatarChange>();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00002830 File Offset: 0x00000A30
		public bool method_0()
		{
			return this.logicArrayList_0.Size() != 0;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00002840 File Offset: 0x00000A40
		public LogicArrayList<AvatarChange> method_1()
		{
			LogicArrayList<AvatarChange> logicArrayList = new LogicArrayList<AvatarChange>();
			logicArrayList.AddAll(this.logicArrayList_0);
			this.logicArrayList_0.Clear();
			return logicArrayList;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000285E File Offset: 0x00000A5E
		public override void FreeDiamondsAdded(int count, int mode)
		{
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00002877 File Offset: 0x00000A77
		public override void DiamondPurchaseMade(int type, int globalId, int level, int count, int villageType)
		{
			this.logicArrayList_0.Add(new DiamondAvatarChange
			{
				Count = -count
			});
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00002892 File Offset: 0x00000A92
		public override void CommodityCountChanged(int commodityType, LogicData data, int count)
		{
			this.logicArrayList_0.Add(new CommodityCountAvatarChange
			{
				Type = commodityType,
				Data = data,
				Count = count
			});
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00006F68 File Offset: 0x00005168
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

		// Token: 0x060000D2 RID: 210 RVA: 0x000028B9 File Offset: 0x00000AB9
		public override void ExpPointsGained(int count)
		{
			this.logicArrayList_0.Add(new ExpPointsAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000028D2 File Offset: 0x00000AD2
		public override void ExpLevelGained(int count)
		{
			this.logicArrayList_0.Add(new ExpLevelAvatarChange
			{
				Points = count
			});
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000028EB File Offset: 0x00000AEB
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

		// Token: 0x060000D5 RID: 213 RVA: 0x00002922 File Offset: 0x00000B22
		public override void AllianceLeft()
		{
			this.logicArrayList_0.Add(new AllianceLeftAvatarChange());
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002934 File Offset: 0x00000B34
		public override void AllianceLevelChanged(int expLevel)
		{
			this.logicArrayList_0.Add(new AllianceLevelAvatarChange
			{
				Level = expLevel
			});
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000294D File Offset: 0x00000B4D
		public override void AllianceUnitAdded(LogicCombatItemData data, int upgLevel)
		{
			this.logicArrayList_0.Add(new AllianceUnitAddedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000296D File Offset: 0x00000B6D
		public override void AllianceUnitRemoved(LogicCombatItemData data, int upgLevel)
		{
			this.logicArrayList_0.Add(new AllianceUnitRemovedAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel
			});
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000298D File Offset: 0x00000B8D
		public override void AllianceUnitCountChanged(LogicCombatItemData data, int upgLevel, int count)
		{
			this.logicArrayList_0.Add(new AllianceUnitCountAvatarChange
			{
				Data = data,
				UpgradeLevel = upgLevel,
				Count = count
			});
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000029B4 File Offset: 0x00000BB4
		public override void SetAllianceCastleLevel(int count)
		{
			this.logicArrayList_0.Add(new AllianceCastleLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000029CD File Offset: 0x00000BCD
		public override void SetTownHallLevel(int count)
		{
			this.logicArrayList_0.Add(new TownHallLevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000029E6 File Offset: 0x00000BE6
		public override void SetVillage2TownHallLevel(int count)
		{
			this.logicArrayList_0.Add(new TownHallV2LevelAvatarChange
			{
				Level = count
			});
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000029FF File Offset: 0x00000BFF
		public override void LegendSeasonScoreChanged(int state, int score, int scoreChange, bool bestSeason, int villageType)
		{
			this.logicArrayList_0.Add(new LegendSeasonScoreAvatarChange
			{
				Entry = ((villageType == 0) ? this.logicClientAvatar_0.GetLegendSeasonEntry() : this.logicClientAvatar_0.GetLegendSeasonEntryVillage2())
			});
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002A33 File Offset: 0x00000C33
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

		// Token: 0x060000DF RID: 223 RVA: 0x00002A64 File Offset: 0x00000C64
		public override void DuelScoreChanged(LogicLong allianceId, int duelScoreGain, int resultType, bool attacker)
		{
			this.logicArrayList_0.Add(new DuelScoreAvatarChange
			{
				Attacker = attacker,
				DuelScoreGain = duelScoreGain,
				ResultType = resultType
			});
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00002A8C File Offset: 0x00000C8C
		public override void LeagueChanged(int leagueType, LogicLong leagueInstanceId)
		{
			this.logicArrayList_0.Add(new LeagueAvatarChange
			{
				LeagueInstanceId = leagueInstanceId,
				LeagueType = leagueType
			});
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00002AAC File Offset: 0x00000CAC
		public override void AttackShieldReduceCounterChanged(int count)
		{
			this.logicArrayList_0.Add(new AttackShieldReduceCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00002AC5 File Offset: 0x00000CC5
		public override void DefenseVillageGuardCounterChanged(int count)
		{
			this.logicArrayList_0.Add(new DefenseVillageGuardCounterAvatarChange
			{
				Count = count
			});
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00002ADE File Offset: 0x00000CDE
		public override void REDPackageStateChanged(int value)
		{
			this.logicArrayList_0.Add(new REDPackageStateAvatarChange
			{
				State = value
			});
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006FB8 File Offset: 0x000051B8
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

		// Token: 0x060000E5 RID: 229 RVA: 0x00007028 File Offset: 0x00005228
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

		// Token: 0x04000048 RID: 72
		private readonly LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000049 RID: 73
		private readonly LogicArrayList<AvatarChange> logicArrayList_0;
	}
}
