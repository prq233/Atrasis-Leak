using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019B RID: 411
	public sealed class LogicChallengeCommand : LogicCommand
	{
		// Token: 0x060016F9 RID: 5881 RVA: 0x00057D30 File Offset: 0x00055F30
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			this.int_1 = stream.ReadVInt();
			this.bool_2 = stream.ReadBoolean();
			this.bool_1 = stream.ReadBoolean();
			this.bool_0 = stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.logicLong_0 = stream.ReadLong();
			}
			base.Decode(stream);
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x00057D9C File Offset: 0x00055F9C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_2);
			encoder.WriteBoolean(this.bool_1);
			encoder.WriteBoolean(this.bool_0);
			if (this.logicLong_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x0000F03E File Offset: 0x0000D23E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHALLENGE;
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016FD RID: 5885 RVA: 0x00057E10 File Offset: 0x00056010
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 7)
			{
				return -21;
			}
			if (this.bool_0 && this.int_1 != 0 && this.int_1 != 2 && this.int_1 != 3)
			{
				return -22;
			}
			if (!LogicDataTables.GetGlobals().UseVersusBattle())
			{
				return 2;
			}
			int villageType = this.bool_0 ? 1 : 0;
			if (level.GetTownHallLevel(villageType) < level.GetRequiredTownHallLevelForLayout(this.int_1, villageType))
			{
				return -3;
			}
			if (level.GetPlayerAvatar() == null)
			{
				return -10;
			}
			LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
			LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
			level.GetGameObjectManagerAt(this.bool_0 ? 1 : 0).GetGameObjects(logicArrayList, logicGameObjectFilter);
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				LogicVector2 positionLayout = logicArrayList[i].GetPositionLayout(this.int_1, false);
				if (((long)this.int_1 & 4294967294L) != 6L)
				{
					if (positionLayout.m_x != -1)
					{
						if (positionLayout.m_y != -1)
						{
							goto IL_103;
						}
					}
					return -5;
				}
				IL_103:;
			}
			logicArrayList.Destruct();
			logicGameObjectFilter.Destruct();
			if (!this.bool_0)
			{
				LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
				if ((homeOwnerAvatar == null || homeOwnerAvatar.IsChallengeStarted()) && level.GetLayoutCooldown(this.int_1) > 0)
				{
					return -7;
				}
			}
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle == null)
			{
				return -3;
			}
			LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
			if (bunkerComponent != null && bunkerComponent.GetChallengeCooldownTime() == 0)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (!this.bool_1 && playerAvatar.GetChallengeId() != null)
				{
					int challengeState = playerAvatar.GetChallengeState();
					if (challengeState != 2 && challengeState != 4)
					{
						Debugger.Warning("chal state: " + challengeState);
						return -8;
					}
				}
				int friendlyBattleCost = LogicDataTables.GetGlobals().GetFriendlyBattleCost(playerAvatar.GetTownHallLevel());
				if (friendlyBattleCost != 0)
				{
					if (!playerAvatar.HasEnoughResources(LogicDataTables.GetGoldData(), friendlyBattleCost, true, this, false))
					{
						return 0;
					}
					if (friendlyBattleCost > 0)
					{
						playerAvatar.CommodityCountChangeHelper(0, LogicDataTables.GetGoldData(), friendlyBattleCost);
					}
				}
				bunkerComponent.StartChallengeCooldownTime();
				bool warLayout = this.int_1 == 1 || this.int_1 == 4 || this.int_1 == 5;
				if (this.bool_0)
				{
					if (this.bool_1)
					{
						playerAvatar.GetChangeListener().SendChallengeRequest(this.string_0, this.int_1, warLayout, villageType);
					}
					else
					{
						playerAvatar.GetChangeListener().SendFriendlyBattleRequest(this.string_0, this.logicLong_0, this.int_1, warLayout, villageType);
					}
				}
				else
				{
					this.SaveChallengeLayout(level, warLayout);
					if (this.bool_1)
					{
						playerAvatar.GetChangeListener().SendChallengeRequest(this.string_0, this.int_1, warLayout, villageType);
					}
					else
					{
						playerAvatar.GetChangeListener().SendFriendlyBattleRequest(this.string_0, this.logicLong_0, this.int_1, warLayout, villageType);
					}
					playerAvatar.SetVariableByName("ChallengeStarted", 1);
				}
				return 0;
			}
			return -6;
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x00058100 File Offset: 0x00056300
		public void SaveChallengeLayout(LogicLevel level, bool warLayout)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetVariableByName("ChallengeLayoutIsWar", warLayout ? 1 : 0);
			}
			level.SaveLayout(this.int_1, 6);
		}

		// Token: 0x04000CB8 RID: 3256
		private int int_1;

		// Token: 0x04000CB9 RID: 3257
		private bool bool_0;

		// Token: 0x04000CBA RID: 3258
		private bool bool_1;

		// Token: 0x04000CBB RID: 3259
		private bool bool_2;

		// Token: 0x04000CBC RID: 3260
		private string string_0;

		// Token: 0x04000CBD RID: 3261
		private LogicLong logicLong_0;
	}
}
