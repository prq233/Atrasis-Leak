using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000197 RID: 407
	public sealed class LogicCancelConstructionCommand : LogicCommand
	{
		// Token: 0x060016DD RID: 5853 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicCancelConstructionCommand()
		{
		}

		// Token: 0x060016DE RID: 5854 RVA: 0x0000EEFB File Offset: 0x0000D0FB
		public LogicCancelConstructionCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060016DF RID: 5855 RVA: 0x0000EF0A File Offset: 0x0000D10A
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x0000EF1F File Offset: 0x0000D11F
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x0000EF34 File Offset: 0x0000D134
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_CONSTRUCTION;
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x00057A30 File Offset: 0x00055C30
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (!LogicDataTables.GetGlobals().AllowCancelBuildingConstruction() && logicBuilding.GetUpgradeLevel() == 0 && logicBuilding.IsConstructing() && !logicBuilding.IsUpgrading())
					{
						return -2;
					}
					if (logicBuilding.IsConstructing())
					{
						logicBuilding.GetListener().CancelNotification();
						logicBuilding.CancelConstruction();
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.OBSTACLE)
				{
					LogicObstacle logicObstacle = (LogicObstacle)gameObjectByID;
					if (logicObstacle.IsClearingOnGoing())
					{
						LogicObstacleData obstacleData = logicObstacle.GetObstacleData();
						level.GetPlayerAvatar().CommodityCountChangeHelper(0, obstacleData.GetClearResourceData(), obstacleData.GetClearCost());
						logicObstacle.CancelClearing();
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.IsConstructing())
					{
						logicTrap.GetListener().CancelNotification();
						logicTrap.CancelConstruction();
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000CB0 RID: 3248
		private int int_1;
	}
}
