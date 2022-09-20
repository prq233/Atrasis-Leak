using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018F RID: 399
	public sealed class LogicBuyBuildingCommand : LogicCommand
	{
		// Token: 0x060016A8 RID: 5800 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicBuyBuildingCommand()
		{
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x0000EC04 File Offset: 0x0000CE04
		public LogicBuyBuildingCommand(int x, int y, LogicBuildingData buildingData)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.logicBuildingData_0 = buildingData;
		}

		// Token: 0x060016AA RID: 5802 RVA: 0x0000EC21 File Offset: 0x0000CE21
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicBuildingData_0 = (LogicBuildingData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.BUILDING);
			base.Decode(stream);
		}

		// Token: 0x060016AB RID: 5803 RVA: 0x0000EC54 File Offset: 0x0000CE54
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicBuildingData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016AC RID: 5804 RVA: 0x0000EC81 File Offset: 0x0000CE81
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_BUILDING;
		}

		// Token: 0x060016AD RID: 5805 RVA: 0x0000EC88 File Offset: 0x0000CE88
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
			this.int_2 = 0;
			this.logicBuildingData_0 = null;
		}

		// Token: 0x060016AE RID: 5806 RVA: 0x00056B84 File Offset: 0x00054D84
		public override int Execute(LogicLevel level)
		{
			int villageType = level.GetVillageType();
			if (this.logicBuildingData_0.GetVillageType() != villageType)
			{
				return -32;
			}
			if (this.logicBuildingData_0.GetWallBlockCount() <= 1 && this.logicBuildingData_0.GetBuildingClass().CanBuy() && level.IsValidPlaceForBuilding(this.int_1, this.int_2, this.logicBuildingData_0.GetWidth(), this.logicBuildingData_0.GetHeight(), null) && !level.IsBuildingCapReached(this.logicBuildingData_0, true) && level.GetCalendar().IsEnabled(this.logicBuildingData_0))
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				LogicResourceData buildResource = this.logicBuildingData_0.GetBuildResource(0);
				int buildCost = this.logicBuildingData_0.GetBuildCost(0, level);
				if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false) && (this.logicBuildingData_0.IsWorkerBuilding() || (this.logicBuildingData_0.GetConstructionTime(0, level, 0) <= 0 && !LogicDataTables.GetGlobals().WorkerForZeroBuilTime()) || level.HasFreeWorkers(this, -1)))
				{
					if (buildResource.IsPremiumCurrency())
					{
						playerAvatar.UseDiamonds(buildCost);
						playerAvatar.GetChangeListener().DiamondPurchaseMade(1, this.logicBuildingData_0.GetGlobalID(), 0, buildCost, villageType);
					}
					else
					{
						playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
					}
					LogicBuilding logicBuilding = (LogicBuilding)LogicGameObjectFactory.CreateGameObject(this.logicBuildingData_0, level, villageType);
					logicBuilding.SetInitialPosition(this.int_1 << 9, this.int_2 << 9);
					level.GetGameObjectManager().AddGameObject(logicBuilding, -1);
					logicBuilding.StartConstructing(false);
					if (this.logicBuildingData_0.IsWall() && level.IsBuildingCapReached(this.logicBuildingData_0, false))
					{
						level.GetGameListener().BuildingCapReached(this.logicBuildingData_0);
					}
					int widthInTiles = logicBuilding.GetWidthInTiles();
					int heightInTiles = logicBuilding.GetHeightInTiles();
					for (int i = 0; i < widthInTiles; i++)
					{
						for (int j = 0; j < heightInTiles; j++)
						{
							LogicObstacle tallGrass = level.GetTileMap().GetTile(this.int_1 + i, this.int_2 + j).GetTallGrass();
							if (tallGrass != null)
							{
								level.GetGameObjectManager().RemoveGameObject(tallGrass);
							}
						}
					}
				}
				return 0;
			}
			return -33;
		}

		// Token: 0x04000C9F RID: 3231
		private int int_1;

		// Token: 0x04000CA0 RID: 3232
		private int int_2;

		// Token: 0x04000CA1 RID: 3233
		private LogicBuildingData logicBuildingData_0;
	}
}
