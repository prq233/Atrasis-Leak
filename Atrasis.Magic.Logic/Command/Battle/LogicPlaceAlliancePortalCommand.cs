using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001E9 RID: 489
	public sealed class LogicPlaceAlliancePortalCommand : LogicCommand
	{
		// Token: 0x06001901 RID: 6401 RVA: 0x00010928 File Offset: 0x0000EB28
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicAlliancePortalData_0 = (LogicAlliancePortalData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.ALLIANCE_PORTAL);
			base.Decode(stream);
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x0001095C File Offset: 0x0000EB5C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicAlliancePortalData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x00010989 File Offset: 0x0000EB89
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PLACE_ALLIANCE_PORTAL;
		}

		// Token: 0x06001904 RID: 6404 RVA: 0x00010990 File Offset: 0x0000EB90
		public override void Destruct()
		{
			base.Destruct();
			this.logicAlliancePortalData_0 = null;
		}

		// Token: 0x06001905 RID: 6405 RVA: 0x0005EFC4 File Offset: 0x0005D1C4
		public override int Execute(LogicLevel level)
		{
			if (level.IsReadyForAttack() && level.GetVillageType() == 0)
			{
				if (LogicDataTables.GetGlobals().AllowClanCastleDeployOnObstacles())
				{
					if (!level.GetTileMap().IsValidAttackPos(this.int_1 >> 9, this.int_2 >> 9))
					{
						return -2;
					}
				}
				else
				{
					LogicTile tile = level.GetTileMap().GetTile(this.int_1 >> 9, this.int_2 >> 9);
					if (tile == null)
					{
						return -4;
					}
					if (tile.GetPassableFlag() == 0)
					{
						return -3;
					}
				}
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (playerAvatar != null && this.logicAlliancePortalData_0 != null)
				{
					LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(0);
					if (gameObjectManagerAt.GetGameObjectCountByData(this.logicAlliancePortalData_0) <= 0 && playerAvatar.GetAllianceCastleUsedCapacity() > 0)
					{
						LogicAlliancePortal logicAlliancePortal = (LogicAlliancePortal)LogicGameObjectFactory.CreateGameObject(this.logicAlliancePortalData_0, level, level.GetVillageType());
						LogicBunkerComponent bunkerComponent = logicAlliancePortal.GetBunkerComponent();
						logicAlliancePortal.SetInitialPosition(this.int_1, this.int_2);
						if (bunkerComponent != null)
						{
							bunkerComponent.SetMaxCapacity(playerAvatar.GetAllianceCastleTotalCapacity());
							if (level.GetBattleLog() != null && !level.GetBattleLog().HasDeployedUnits() && level.GetTotalAttackerHeroPlaced() == 0)
							{
								level.UpdateLastUsedArmy();
							}
							if (level.GetGameMode().IsInAttackPreparationMode())
							{
								level.GetGameMode().EndAttackPreparation();
							}
							bunkerComponent.RemoveAllUnits();
							LogicArrayList<LogicUnitSlot> allianceUnits = playerAvatar.GetAllianceUnits();
							for (int i = 0; i < allianceUnits.Size(); i++)
							{
								LogicUnitSlot logicUnitSlot = allianceUnits[i];
								LogicCombatItemData logicCombatItemData = (LogicCombatItemData)logicUnitSlot.GetData();
								if (logicCombatItemData != null)
								{
									int count = logicUnitSlot.GetCount();
									if (logicCombatItemData.GetCombatItemType() == LogicCombatItemType.CHARACTER)
									{
										for (int j = 0; j < count; j++)
										{
											if (bunkerComponent.GetUnusedCapacity() >= logicCombatItemData.GetHousingSpace())
											{
												bunkerComponent.AddUnitImpl(logicCombatItemData, logicUnitSlot.GetLevel());
											}
										}
									}
								}
								else
								{
									Debugger.Error("LogicPlaceAlliancePortalCommand::execute - NULL alliance character");
								}
							}
						}
						gameObjectManagerAt.AddGameObject(logicAlliancePortal, -1);
						return 0;
					}
				}
				return -5;
			}
			return -1;
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x0005F1A4 File Offset: 0x0005D3A4
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicPlaceAlliancePortalCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicAlliancePortalData_0 = (LogicAlliancePortalData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.ALLIANCE_PORTAL);
			}
			if (this.logicAlliancePortalData_0 == null)
			{
				Debugger.Error("Replay LogicPlaceAlliancePortalCommand load failed! Data is NULL!");
			}
			this.int_1 = jsonRoot.GetJSONNumber("x").GetIntValue();
			this.int_2 = jsonRoot.GetJSONNumber("y").GetIntValue();
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x0005F238 File Offset: 0x0005D438
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicAlliancePortalData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicAlliancePortalData_0.GetGlobalID()));
			}
			logicJSONObject.Put("x", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("y", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x04000D8C RID: 3468
		private int int_1;

		// Token: 0x04000D8D RID: 3469
		private int int_2;

		// Token: 0x04000D8E RID: 3470
		private LogicAlliancePortalData logicAlliancePortalData_0;
	}
}
