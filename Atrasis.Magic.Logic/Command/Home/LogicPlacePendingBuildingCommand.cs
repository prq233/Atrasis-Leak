using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B3 RID: 435
	public sealed class LogicPlacePendingBuildingCommand : LogicCommand
	{
		// Token: 0x06001792 RID: 6034 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicPlacePendingBuildingCommand()
		{
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x0000F811 File Offset: 0x0000DA11
		public LogicPlacePendingBuildingCommand(int x, int y, int upgradeLevel, LogicGameObjectData gameObjectData)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.int_3 = upgradeLevel;
			this.logicGameObjectData_0 = gameObjectData;
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x0000F836 File Offset: 0x0000DA36
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicGameObjectData_0 = (LogicGameObjectData)ByteStreamHelper.ReadDataReference(stream);
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x0000F874 File Offset: 0x0000DA74
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicGameObjectData_0);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x06001796 RID: 6038 RVA: 0x0000F8AD File Offset: 0x0000DAAD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PLACE_PENDING_BUILDING;
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x0000F8B4 File Offset: 0x0000DAB4
		public override void Destruct()
		{
			base.Destruct();
			this.logicGameObjectData_0 = null;
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x00059D58 File Offset: 0x00057F58
		public override int Execute(LogicLevel level)
		{
			if (this.logicGameObjectData_0 == null || level.GetUnplacedObjectCount(this.logicGameObjectData_0) <= 0)
			{
				return 0;
			}
			if (level.GetVillageType() != this.logicGameObjectData_0.GetVillageType())
			{
				return -35;
			}
			LogicDataType dataType = this.logicGameObjectData_0.GetDataType();
			if (dataType == LogicDataType.BUILDING)
			{
				LogicBuildingData logicBuildingData = (LogicBuildingData)this.logicGameObjectData_0;
				if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, logicBuildingData.GetWidth(), logicBuildingData.GetHeight(), null))
				{
					if (!level.RemoveUnplacedObject(this.logicGameObjectData_0, this.int_3))
					{
						return -63;
					}
					LogicBuilding logicBuilding = (LogicBuilding)LogicGameObjectFactory.CreateGameObject(this.logicGameObjectData_0, level, level.GetVillageType());
					logicBuilding.SetPositionXY(this.int_1 << 9, this.int_2 << 9);
					level.GetGameObjectManager().AddGameObject(logicBuilding, -1);
					logicBuilding.FinishConstruction(false, true);
					logicBuilding.SetUpgradeLevel(this.int_3);
				}
				return 0;
			}
			if (dataType == LogicDataType.TRAP)
			{
				LogicTrapData logicTrapData = (LogicTrapData)this.logicGameObjectData_0;
				if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, logicTrapData.GetWidth(), logicTrapData.GetHeight(), null))
				{
					if (!level.RemoveUnplacedObject(this.logicGameObjectData_0, this.int_3))
					{
						return -64;
					}
					LogicTrap logicTrap = (LogicTrap)LogicGameObjectFactory.CreateGameObject(this.logicGameObjectData_0, level, level.GetVillageType());
					logicTrap.SetPositionXY(this.int_1 << 9, this.int_2 << 9);
					logicTrap.FinishConstruction(false);
					logicTrap.SetUpgradeLevel(this.int_3);
					level.GetGameObjectManager().AddGameObject(logicTrap, -1);
				}
				return 0;
			}
			if (dataType == LogicDataType.DECO)
			{
				LogicDecoData logicDecoData = (LogicDecoData)this.logicGameObjectData_0;
				if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, logicDecoData.GetWidth(), logicDecoData.GetHeight(), null))
				{
					if (!level.RemoveUnplacedObject(this.logicGameObjectData_0, this.int_3))
					{
						return -65;
					}
					LogicDeco logicDeco = (LogicDeco)LogicGameObjectFactory.CreateGameObject(this.logicGameObjectData_0, level, level.GetVillageType());
					logicDeco.SetPositionXY(this.int_1 << 9, this.int_2 << 9);
					level.RemoveUnplacedObject(this.logicGameObjectData_0, this.int_3);
					level.GetGameObjectManager().AddGameObject(logicDeco, -1);
				}
				return 0;
			}
			return -3;
		}

		// Token: 0x04000CE6 RID: 3302
		private int int_1;

		// Token: 0x04000CE7 RID: 3303
		private int int_2;

		// Token: 0x04000CE8 RID: 3304
		private int int_3;

		// Token: 0x04000CE9 RID: 3305
		private LogicGameObjectData logicGameObjectData_0;
	}
}
