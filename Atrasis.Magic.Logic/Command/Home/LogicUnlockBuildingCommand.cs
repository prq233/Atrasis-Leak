using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DD RID: 477
	public sealed class LogicUnlockBuildingCommand : LogicCommand
	{
		// Token: 0x060018AA RID: 6314 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicUnlockBuildingCommand()
		{
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00010628 File Offset: 0x0000E828
		public LogicUnlockBuildingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00010637 File Offset: 0x0000E837
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x0001064C File Offset: 0x0000E84C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x00010661 File Offset: 0x0000E861
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UNLOCK_BUILDING;
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x0005C6C4 File Offset: 0x0005A8C4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
				if (logicBuilding.IsLocked() && logicBuilding.GetUpgradeLevel() == 0 && logicBuilding.CanUnlock(true))
				{
					LogicBuildingData buildingData = logicBuilding.GetBuildingData();
					if (buildingData.GetConstructionTime(0, level, 0) == 0 || level.HasFreeWorkers(this, -1))
					{
						LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
						LogicResourceData buildResource = buildingData.GetBuildResource(0);
						int buildCost = buildingData.GetBuildCost(0, level);
						if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false))
						{
							playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
							logicBuilding.StartConstructing(true);
							logicBuilding.GetListener().RefreshState();
							return 0;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x04000D36 RID: 3382
		private int int_1;
	}
}
