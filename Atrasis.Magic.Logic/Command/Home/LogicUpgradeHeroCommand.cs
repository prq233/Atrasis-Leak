using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DF RID: 479
	public sealed class LogicUpgradeHeroCommand : LogicCommand
	{
		// Token: 0x060018B9 RID: 6329 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicUpgradeHeroCommand()
		{
		}

		// Token: 0x060018BA RID: 6330 RVA: 0x000106C7 File Offset: 0x0000E8C7
		public LogicUpgradeHeroCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x000106D6 File Offset: 0x0000E8D6
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x000106EB File Offset: 0x0000E8EB
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060018BD RID: 6333 RVA: 0x00010700 File Offset: 0x0000E900
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UPGRADE_HERO;
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x0005CA80 File Offset: 0x0005AC80
		public override int Execute(LogicLevel level)
		{
			LogicBuilding logicBuilding = (LogicBuilding)level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (logicBuilding.IsLocked())
			{
				return -23;
			}
			if (logicBuilding.GetBuildingData().GetVillageType() == level.GetVillageType())
			{
				LogicHeroBaseComponent heroBaseComponent = logicBuilding.GetHeroBaseComponent();
				if (heroBaseComponent != null && heroBaseComponent.CanStartUpgrading(true))
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					LogicHeroData heroData = logicBuilding.GetBuildingData().GetHeroData();
					int unitUpgradeLevel = playerAvatar.GetUnitUpgradeLevel(heroData);
					int upgradeCost = heroData.GetUpgradeCost(unitUpgradeLevel);
					LogicResourceData upgradeResource = heroData.GetUpgradeResource(unitUpgradeLevel);
					if (playerAvatar.HasEnoughResources(upgradeResource, upgradeCost, true, this, false) && level.HasFreeWorkers(this, -1))
					{
						playerAvatar.CommodityCountChangeHelper(0, upgradeResource, -upgradeCost);
						heroBaseComponent.StartUpgrading();
						return 0;
					}
				}
				return -1;
			}
			return -32;
		}

		// Token: 0x04000D39 RID: 3385
		private int int_1;
	}
}
