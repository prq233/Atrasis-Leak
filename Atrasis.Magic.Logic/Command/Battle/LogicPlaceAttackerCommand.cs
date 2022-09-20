using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EA RID: 490
	public sealed class LogicPlaceAttackerCommand : LogicCommand
	{
		// Token: 0x06001909 RID: 6409 RVA: 0x0001099F File Offset: 0x0000EB9F
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicCharacterData_0 = (LogicCharacterData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.CHARACTER);
			base.Decode(stream);
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x000109D2 File Offset: 0x0000EBD2
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCharacterData_0);
			base.Encode(encoder);
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x000109FF File Offset: 0x0000EBFF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PLACE_ATTACKER;
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x00010A06 File Offset: 0x0000EC06
		public override void Destruct()
		{
			base.Destruct();
			this.logicCharacterData_0 = null;
		}

		// Token: 0x0600190D RID: 6413 RVA: 0x0005F2AC File Offset: 0x0005D4AC
		public override int Execute(LogicLevel level)
		{
			if (!level.IsReadyForAttack())
			{
				return -1;
			}
			int x = this.int_1 >> 9;
			int y = this.int_2 >> 9;
			if (level.GetTileMap().GetTile(x, y) == null)
			{
				return -3;
			}
			if (!level.GetTileMap().IsPassablePathFinder(this.int_1 >> 8, this.int_2 >> 8))
			{
				return -2;
			}
			if (!level.GetTileMap().IsValidAttackPos(x, y))
			{
				return -4;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar == null)
			{
				return -5;
			}
			if (((level.GetVillageType() == 1) ? playerAvatar.GetUnitCountVillage2(this.logicCharacterData_0) : playerAvatar.GetUnitCount(this.logicCharacterData_0)) > 0)
			{
				if (level.GetBattleLog() != null && !level.GetBattleLog().HasDeployedUnits() && level.GetTotalAttackerHeroPlaced() == 0)
				{
					level.UpdateLastUsedArmy();
				}
				if (level.GetGameMode().IsInAttackPreparationMode())
				{
					level.GetGameMode().EndAttackPreparation();
				}
				LogicCharacter logicCharacter = LogicPlaceAttackerCommand.PlaceAttacker(playerAvatar, this.logicCharacterData_0, level, this.int_1, this.int_2);
				if (logicCharacter != null && logicCharacter.HasSpecialAbility())
				{
					if (this.logicCharacterData_0.GetSpecialAbilityType() == 0)
					{
						LogicSpellData specialAbilitySpell = this.logicCharacterData_0.GetSpecialAbilitySpell();
						level.BoostGameObject(logicCharacter, specialAbilitySpell.GetSpeedBoost(0), specialAbilitySpell.GetSpeedBoost2(0), specialAbilitySpell.GetDamageBoostPercent(0), specialAbilitySpell.GetAttackSpeedBoost(0), 60 * this.logicCharacterData_0.GetSpecialAbilityAttribute(logicCharacter.GetUpgradeLevel()), specialAbilitySpell.GetBoostLinkedToPoison());
					}
					else if (this.logicCharacterData_0.GetSpecialAbilityType() == 2)
					{
						logicCharacter.SetStealthTime(15 * this.logicCharacterData_0.GetSpecialAbilityAttribute(logicCharacter.GetUpgradeLevel()));
					}
				}
				return 0;
			}
			return -7;
		}

		// Token: 0x0600190E RID: 6414 RVA: 0x0005F450 File Offset: 0x0005D650
		public static LogicCharacter PlaceAttacker(LogicAvatar avatar, LogicCharacterData characterData, LogicLevel level, int x, int y)
		{
			avatar.CommodityCountChangeHelper((level.GetVillageType() == 1) ? 7 : 0, characterData, -1);
			LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(characterData, level, level.GetVillageType());
			int num = avatar.GetUnitUpgradeLevel(characterData);
			if (level.GetMissionManager().GetMissionByCategory(2) != null && level.GetVillageType() == 1 && level.GetHomeOwnerAvatar() != null && level.GetHomeOwnerAvatar().IsNpcAvatar())
			{
				num = LogicMath.Clamp(LogicDataTables.GetGlobals().GetVillage2StartUnitLevel(), 0, characterData.GetUpgradeLevelCount() - 1);
			}
			logicCharacter.SetUpgradeLevel(num);
			logicCharacter.SetInitialPosition(x, y);
			if (characterData.IsJumper())
			{
				logicCharacter.GetMovementComponent().EnableJump(3600000);
				logicCharacter.GetCombatComponent().RefreshTarget(true);
			}
			level.GetGameObjectManager().AddGameObject(logicCharacter, -1);
			level.GetGameListener().AttackerPlaced(characterData);
			LogicBattleLog battleLog = level.GetBattleLog();
			if (battleLog != null)
			{
				battleLog.IncrementDeployedAttackerUnits(characterData, 1);
				battleLog.SetCombatItemLevel(characterData, num);
			}
			logicCharacter.UpdateAutoMerge();
			return logicCharacter;
		}

		// Token: 0x0600190F RID: 6415 RVA: 0x0005F540 File Offset: 0x0005D740
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicPlaceAttackerCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicCharacterData_0 = (LogicCharacterData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.CHARACTER);
			}
			if (this.logicCharacterData_0 == null)
			{
				Debugger.Error("Replay LogicPlaceAttackerCommand load failed! Character is NULL!");
			}
			this.int_1 = jsonRoot.GetJSONNumber("x").GetIntValue();
			this.int_2 = jsonRoot.GetJSONNumber("y").GetIntValue();
		}

		// Token: 0x06001910 RID: 6416 RVA: 0x0005F5D4 File Offset: 0x0005D7D4
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicCharacterData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicCharacterData_0.GetGlobalID()));
			}
			logicJSONObject.Put("x", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("y", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x04000D8F RID: 3471
		private int int_1;

		// Token: 0x04000D90 RID: 3472
		private int int_2;

		// Token: 0x04000D91 RID: 3473
		private LogicCharacterData logicCharacterData_0;
	}
}
