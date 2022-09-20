using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001E6 RID: 486
	public sealed class LogicChangeUnitVillage2Command : LogicCommand
	{
		// Token: 0x060018EB RID: 6379 RVA: 0x00010874 File Offset: 0x0000EA74
		public override void Decode(ByteStream stream)
		{
			this.logicCharacterData_1 = (LogicCharacterData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.CHARACTER);
			this.logicCharacterData_0 = (LogicCharacterData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.CHARACTER);
			base.Decode(stream);
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x000108A1 File Offset: 0x0000EAA1
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicCharacterData_1);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCharacterData_0);
			base.Encode(encoder);
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x000108C2 File Offset: 0x0000EAC2
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_UNIT_VILLAGE_2;
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x000108C9 File Offset: 0x0000EAC9
		public override void Destruct()
		{
			base.Destruct();
			this.logicCharacterData_0 = null;
			this.logicCharacterData_1 = null;
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x0005ED60 File Offset: 0x0005CF60
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (level.GetVillageType() != 1)
			{
				return -10;
			}
			LogicGameMode gameMode = level.GetGameMode();
			if (!gameMode.IsInAttackPreparationMode() && gameMode.GetState() != 5)
			{
				return -9;
			}
			if (this.logicCharacterData_0 == null || this.logicCharacterData_1 == null || !gameMode.GetCalendar().IsProductionEnabled(this.logicCharacterData_1))
			{
				return -7;
			}
			if (!this.logicCharacterData_1.IsUnlockedForBarrackLevel(playerAvatar.GetVillage2BarrackLevel()) && gameMode.GetState() != 7)
			{
				return -7;
			}
			int unitCountVillage = playerAvatar.GetUnitCountVillage2(this.logicCharacterData_0);
			int unitsInCamp = this.logicCharacterData_0.GetUnitsInCamp(playerAvatar.GetUnitUpgradeLevel(this.logicCharacterData_0));
			if (unitCountVillage >= unitsInCamp)
			{
				int unitCountVillage2 = playerAvatar.GetUnitCountVillage2(this.logicCharacterData_1);
				int unitsInCamp2 = this.logicCharacterData_1.GetUnitsInCamp(playerAvatar.GetUnitUpgradeLevel(this.logicCharacterData_1));
				playerAvatar.SetUnitCountVillage2(this.logicCharacterData_0, unitCountVillage - unitsInCamp);
				playerAvatar.SetUnitCountVillage2(this.logicCharacterData_1, unitCountVillage2 + unitsInCamp2);
				LogicArrayList<LogicDataSlot> unitsNewVillage = playerAvatar.GetUnitsNewVillage2();
				for (int i = 0; i < unitsNewVillage.Size(); i++)
				{
					LogicDataSlot logicDataSlot = unitsNewVillage[i];
					if (logicDataSlot.GetCount() > 0)
					{
						playerAvatar.CommodityCountChangeHelper(8, logicDataSlot.GetData(), -logicDataSlot.GetCount());
					}
				}
				return 0;
			}
			return -23;
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x0005EEAC File Offset: 0x0005D0AC
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicChangeUnitVillage2Command load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("n");
			if (jsonnumber != null)
			{
				this.logicCharacterData_1 = (LogicCharacterData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.CHARACTER);
			}
			LogicJSONNumber jsonnumber2 = jsonRoot.GetJSONNumber("o");
			if (jsonnumber2 != null)
			{
				this.logicCharacterData_0 = (LogicCharacterData)LogicDataTables.GetDataById(jsonnumber2.GetIntValue(), LogicDataType.CHARACTER);
			}
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x0005EF28 File Offset: 0x0005D128
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicCharacterData_1 != null)
			{
				logicJSONObject.Put("n", new LogicJSONNumber(this.logicCharacterData_1.GetGlobalID()));
			}
			if (this.logicCharacterData_0 != null)
			{
				logicJSONObject.Put("o", new LogicJSONNumber(this.logicCharacterData_0.GetGlobalID()));
			}
			return logicJSONObject;
		}

		// Token: 0x04000D8A RID: 3466
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000D8B RID: 3467
		private LogicCharacterData logicCharacterData_1;
	}
}
