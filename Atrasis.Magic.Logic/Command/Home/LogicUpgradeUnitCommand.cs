using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001E1 RID: 481
	public sealed class LogicUpgradeUnitCommand : LogicCommand
	{
		// Token: 0x060018C6 RID: 6342 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicUpgradeUnitCommand()
		{
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x00010726 File Offset: 0x0000E926
		public LogicUpgradeUnitCommand(LogicCombatItemData combatItemData, int gameObjectId)
		{
			this.logicCombatItemData_0 = combatItemData;
			this.int_1 = gameObjectId;
			this.logicDataType_0 = this.logicCombatItemData_0.GetDataType();
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x0001074D File Offset: 0x0000E94D
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.logicDataType_0 = (LogicDataType)stream.ReadInt();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (this.logicDataType_0 != LogicDataType.BUILDING) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			base.Decode(stream);
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x0001078C File Offset: 0x0000E98C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt((int)this.logicDataType_0);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			base.Encode(encoder);
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x000107B9 File Offset: 0x0000E9B9
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UPGRADE_UNIT;
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x000107C0 File Offset: 0x0000E9C0
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
			this.logicDataType_0 = LogicDataType.BUILDING;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x0005CDC4 File Offset: 0x0005AFC4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
				if (this.logicCombatItemData_0 != null)
				{
					LogicUnitUpgradeComponent unitUpgradeComponent = logicBuilding.GetUnitUpgradeComponent();
					if (unitUpgradeComponent != null && unitUpgradeComponent.CanStartUpgrading(this.logicCombatItemData_0))
					{
						LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
						int unitUpgradeLevel = playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0);
						int upgradeCost = this.logicCombatItemData_0.GetUpgradeCost(unitUpgradeLevel);
						LogicResourceData upgradeResource = this.logicCombatItemData_0.GetUpgradeResource(unitUpgradeLevel);
						if (playerAvatar.HasEnoughResources(upgradeResource, upgradeCost, true, this, false))
						{
							playerAvatar.CommodityCountChangeHelper(0, upgradeResource, -upgradeCost);
							unitUpgradeComponent.StartUpgrading(this.logicCombatItemData_0);
							return 0;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x04000D3C RID: 3388
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000D3D RID: 3389
		private LogicDataType logicDataType_0;

		// Token: 0x04000D3E RID: 3390
		private int int_1;
	}
}
