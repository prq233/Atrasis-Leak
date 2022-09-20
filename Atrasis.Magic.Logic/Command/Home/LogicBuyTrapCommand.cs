using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000193 RID: 403
	public sealed class LogicBuyTrapCommand : LogicCommand
	{
		// Token: 0x060016C4 RID: 5828 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicBuyTrapCommand()
		{
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x0000EE01 File Offset: 0x0000D001
		public LogicBuyTrapCommand(int x, int y, LogicTrapData trapData)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.logicTrapData_0 = trapData;
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x0000EE1E File Offset: 0x0000D01E
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicTrapData_0 = (LogicTrapData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.TRAP);
			base.Decode(stream);
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x0000EE52 File Offset: 0x0000D052
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicTrapData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x0000EE7F File Offset: 0x0000D07F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_TRAP;
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x0000EE86 File Offset: 0x0000D086
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
			this.int_2 = 0;
			this.logicTrapData_0 = null;
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x00057404 File Offset: 0x00055604
		public override int Execute(LogicLevel level)
		{
			if (this.logicTrapData_0 == null)
			{
				return -1;
			}
			if (this.logicTrapData_0.GetVillageType() == level.GetVillageType())
			{
				if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, this.logicTrapData_0.GetWidth(), this.logicTrapData_0.GetHeight(), null))
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					LogicResourceData buildResource = this.logicTrapData_0.GetBuildResource();
					int buildCost = this.logicTrapData_0.GetBuildCost(0);
					if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false) && !level.IsTrapCapReached(this.logicTrapData_0, true) && level.GetGameMode().GetCalendar().IsEnabled(this.logicTrapData_0))
					{
						if (buildResource.IsPremiumCurrency())
						{
							playerAvatar.UseDiamonds(buildCost);
							playerAvatar.GetChangeListener().DiamondPurchaseMade(1, this.logicTrapData_0.GetGlobalID(), 0, buildCost, level.GetVillageType());
						}
						else
						{
							playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
						}
						LogicTrap logicTrap = (LogicTrap)LogicGameObjectFactory.CreateGameObject(this.logicTrapData_0, level, level.GetVillageType());
						if (this.logicTrapData_0.GetBuildTime(0) == 0)
						{
							logicTrap.FinishConstruction(false);
						}
						logicTrap.SetInitialPosition(this.int_1 << 9, this.int_2 << 9);
						level.GetGameObjectManager().AddGameObject(logicTrap, -1);
						if (level.IsTrapCapReached(this.logicTrapData_0, false))
						{
							level.GetGameListener().TrapCapReached(this.logicTrapData_0);
						}
						int widthInTiles = logicTrap.GetWidthInTiles();
						int heightInTiles = logicTrap.GetHeightInTiles();
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
						return 0;
					}
				}
				return -1;
			}
			return -32;
		}

		// Token: 0x04000CAB RID: 3243
		private int int_1;

		// Token: 0x04000CAC RID: 3244
		private int int_2;

		// Token: 0x04000CAD RID: 3245
		private LogicTrapData logicTrapData_0;
	}
}
