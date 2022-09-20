using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000194 RID: 404
	public sealed class LogicBuyWallBlockCommand : LogicCommand
	{
		// Token: 0x060016CB RID: 5835 RVA: 0x0000EEA3 File Offset: 0x0000D0A3
		public LogicBuyWallBlockCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicVector2>();
		}

		// Token: 0x060016CC RID: 5836 RVA: 0x000575D8 File Offset: 0x000557D8
		public override void Decode(ByteStream stream)
		{
			int num = LogicMath.Min(stream.ReadInt(), 10);
			for (int i = 0; i < num; i++)
			{
				this.logicArrayList_0.Add(new LogicVector2(stream.ReadInt(), stream.ReadInt()));
			}
			this.logicBuildingData_0 = (LogicBuildingData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.BUILDING);
			base.Decode(stream);
		}

		// Token: 0x060016CD RID: 5837 RVA: 0x00057634 File Offset: 0x00055834
		public override void Encode(ChecksumEncoder encoder)
		{
			int num = LogicMath.Min(this.logicArrayList_0.Size(), 10);
			encoder.WriteInt(num);
			for (int i = 0; i < num; i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i].m_x);
				encoder.WriteInt(this.logicArrayList_0[i].m_y);
			}
			ByteStreamHelper.WriteDataReference(encoder, this.logicBuildingData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016CE RID: 5838 RVA: 0x0000EEB6 File Offset: 0x0000D0B6
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_WALL_BLOCK;
		}

		// Token: 0x060016CF RID: 5839 RVA: 0x000576A8 File Offset: 0x000558A8
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_0 != null)
			{
				for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
				{
					this.logicArrayList_0[i].Destruct();
					this.logicArrayList_0.Remove(i);
				}
				this.logicArrayList_0 = null;
			}
			this.logicBuildingData_0 = null;
		}

		// Token: 0x060016D0 RID: 5840 RVA: 0x00057708 File Offset: 0x00055908
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 1)
			{
				return -32;
			}
			if (this.logicBuildingData_0 == null || !this.logicBuildingData_0.GetBuildingClass().CanBuy() || !this.logicBuildingData_0.IsWall())
			{
				return 0;
			}
			if (this.logicBuildingData_0.GetWallBlockCount() == 0)
			{
				return -1;
			}
			if (this.logicBuildingData_0.GetWallBlockCount() != this.logicArrayList_0.Size())
			{
				return -2;
			}
			if (this.logicArrayList_0.Size() <= 10)
			{
				int i = 0;
				int num = -1;
				while (i < this.logicArrayList_0.Size())
				{
					LogicVector2 logicVector = this.logicArrayList_0[0];
					LogicVector2 logicVector2 = this.logicArrayList_0[i];
					if (i > 0)
					{
						int wallBlockIndex = this.logicBuildingData_0.GetWallBlockIndex(logicVector2.m_x - logicVector.m_x, logicVector2.m_y - logicVector.m_y, i);
						if (num == -1)
						{
							num = wallBlockIndex;
						}
						if (wallBlockIndex != -1)
						{
							if (wallBlockIndex == num)
							{
								num = wallBlockIndex;
								goto IL_E4;
							}
						}
						Debugger.Error("LogicBuyWallBlockCommand shape incorrect");
						return -4;
					}
					IL_E4:
					if (!level.IsValidPlaceForBuilding(logicVector2.m_x, logicVector2.m_y, this.logicBuildingData_0.GetWidth(), this.logicBuildingData_0.GetHeight(), null))
					{
						Debugger.Error("LogicBuyWallBlockCommand invalid place.");
						return -5;
					}
					i++;
				}
				if (!level.IsBuildingCapReached(this.logicBuildingData_0, true))
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					LogicResourceData buildResource = this.logicBuildingData_0.GetBuildResource(0);
					int buildCost = this.logicBuildingData_0.GetBuildCost(0, level);
					if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false) && (this.logicBuildingData_0.IsWorkerBuilding() || (this.logicBuildingData_0.GetConstructionTime(0, level, 0) <= 0 && !LogicDataTables.GetGlobals().WorkerForZeroBuilTime()) || level.HasFreeWorkers(this, -1)))
					{
						if (buildResource.IsPremiumCurrency())
						{
							playerAvatar.UseDiamonds(buildCost);
							playerAvatar.GetChangeListener().DiamondPurchaseMade(1, this.logicBuildingData_0.GetGlobalID(), 0, buildCost, level.GetVillageType());
						}
						else
						{
							playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
						}
						LogicGameObjectManager gameObjectManager = level.GetGameObjectManager();
						int highestWallIndex = gameObjectManager.GetHighestWallIndex(this.logicBuildingData_0);
						for (int j = 0; j < this.logicArrayList_0.Size(); j++)
						{
							LogicVector2 logicVector3 = this.logicArrayList_0[j];
							LogicBuilding logicBuilding = (LogicBuilding)LogicGameObjectFactory.CreateGameObject(this.logicBuildingData_0, level, level.GetVillageType());
							logicBuilding.StartConstructing(false);
							logicBuilding.SetInitialPosition(logicVector3.m_x << 9, logicVector3.m_y << 9);
							logicBuilding.SetWallObjectId(highestWallIndex, j, j == 0);
							gameObjectManager.AddGameObject(logicBuilding, -1);
							int widthInTiles = logicBuilding.GetWidthInTiles();
							int heightInTiles = logicBuilding.GetHeightInTiles();
							for (int k = 0; k < widthInTiles; k++)
							{
								for (int l = 0; l < heightInTiles; l++)
								{
									LogicObstacle tallGrass = level.GetTileMap().GetTile(logicVector3.m_x + k, logicVector3.m_y + l).GetTallGrass();
									if (tallGrass != null)
									{
										level.GetGameObjectManager().RemoveGameObject(tallGrass);
									}
								}
							}
						}
					}
				}
				return 0;
			}
			return -3;
		}

		// Token: 0x04000CAE RID: 3246
		private LogicBuildingData logicBuildingData_0;

		// Token: 0x04000CAF RID: 3247
		private LogicArrayList<LogicVector2> logicArrayList_0;
	}
}
