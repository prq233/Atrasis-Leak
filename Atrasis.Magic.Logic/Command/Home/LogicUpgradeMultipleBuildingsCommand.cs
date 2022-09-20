﻿using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001E0 RID: 480
	public sealed class LogicUpgradeMultipleBuildingsCommand : LogicCommand
	{
		// Token: 0x060018C0 RID: 6336 RVA: 0x00010707 File Offset: 0x0000E907
		public LogicUpgradeMultipleBuildingsCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>(300);
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x0005CB3C File Offset: 0x0005AD3C
		public override void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			int num = stream.ReadInt();
			if (num > 300)
			{
				num = 300;
			}
			for (int i = 0; i < num; i++)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
			}
			base.Decode(stream);
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x0005CB90 File Offset: 0x0005AD90
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			int num = this.logicArrayList_0.Size();
			if (num > 300)
			{
				num = 300;
			}
			encoder.WriteInt(num);
			for (int i = 0; i < num; i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x0001071F File Offset: 0x0000E91F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UPGRADE_MULTIPLE_BUILDINGS;
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0005CBF0 File Offset: 0x0005ADF0
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicResourceData logicResourceData = null;
				int num = 0;
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[i]);
					if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
						LogicBuildingData buildingData = logicBuilding.GetBuildingData();
						if (buildingData.IsTownHallVillage2())
						{
							return -76;
						}
						int num2 = logicBuilding.GetUpgradeLevel() + 1;
						if (logicBuilding.CanUpgrade(false) && buildingData.GetUpgradeLevelCount() > num2 && buildingData.GetAmountCanBeUpgraded(num2) == 0)
						{
							logicResourceData = buildingData.GetBuildResource(num2);
							if (this.bool_0)
							{
								logicResourceData = buildingData.GetAltBuildResource(num2);
							}
							num += buildingData.GetBuildCost(num2, level);
						}
					}
				}
				if (logicResourceData != null)
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					if (playerAvatar.HasEnoughResources(logicResourceData, num, true, this, false) && level.HasFreeWorkers(this, -1))
					{
						bool updateListener = true;
						for (int j = 0; j < this.logicArrayList_0.Size(); j++)
						{
							LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[j]);
							if (gameObjectByID2 != null && gameObjectByID2.GetGameObjectType() == LogicGameObjectType.BUILDING)
							{
								LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByID2;
								LogicBuildingData buildingData2 = logicBuilding2.GetBuildingData();
								int num3 = logicBuilding2.GetUpgradeLevel() + 1;
								if (logicBuilding2.CanUpgrade(false) && buildingData2.GetUpgradeLevelCount() > num3 && buildingData2.GetAmountCanBeUpgraded(num3) == 0)
								{
									if (this.logicArrayList_0.Size() > 6)
									{
										updateListener = ((logicBuilding2.GetTileX() + logicBuilding2.GetTileY()) % (this.logicArrayList_0.Size() / 4) == 0);
									}
									logicBuilding2.StartUpgrading(updateListener, false);
								}
							}
						}
						playerAvatar.CommodityCountChangeHelper(0, logicResourceData, -num);
						return 0;
					}
				}
			}
			return -2;
		}

		// Token: 0x04000D3A RID: 3386
		private bool bool_0;

		// Token: 0x04000D3B RID: 3387
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
