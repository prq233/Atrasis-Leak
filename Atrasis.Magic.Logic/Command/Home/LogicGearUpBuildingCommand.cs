using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A5 RID: 421
	public sealed class LogicGearUpBuildingCommand : LogicCommand
	{
		// Token: 0x06001738 RID: 5944 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicGearUpBuildingCommand()
		{
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x0000F2EC File Offset: 0x0000D4EC
		public LogicGearUpBuildingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0000F2FB File Offset: 0x0000D4FB
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x0000F310 File Offset: 0x0000D510
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x0000F325 File Offset: 0x0000D525
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.GEAR_UP_BUILDING;
		}

		// Token: 0x0600173D RID: 5949 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600173E RID: 5950 RVA: 0x000588D8 File Offset: 0x00056AD8
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -1;
			}
			LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
			LogicBuildingData buildingData = logicBuilding.GetBuildingData();
			if (buildingData.GetVillageType() != level.GetVillageType())
			{
				return -32;
			}
			if (level.IsBuildingGearUpCapReached(buildingData, true))
			{
				return -31;
			}
			if (logicBuilding.GetGearLevel() != 0)
			{
				return -35;
			}
			int upgradeLevel = logicBuilding.GetUpgradeLevel();
			int gearUpCost = buildingData.GetGearUpCost(upgradeLevel);
			if (gearUpCost <= 0)
			{
				return -36;
			}
			if (upgradeLevel < buildingData.GetMinUpgradeLevelForGearUp())
			{
				return -37;
			}
			if (level.GetGameObjectManagerAt(1).GetHighestBuildingLevel(buildingData.GetGearUpBuildingData()) < buildingData.GetGearUpLevelRequirement())
			{
				return -1;
			}
			LogicResourceData gearUpResource = buildingData.GetGearUpResource();
			if (gearUpResource != null)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (playerAvatar.HasEnoughResources(gearUpResource, gearUpCost, true, this, false) && level.HasFreeWorkers(this, 1))
				{
					playerAvatar.CommodityCountChangeHelper(0, gearUpResource, -gearUpCost);
					logicBuilding.StartUpgrading(true, true);
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CC8 RID: 3272
		private int int_1;
	}
}
