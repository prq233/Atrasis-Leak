using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D0 RID: 464
	public sealed class LogicSpeedUpUpgradeUnitCommand : LogicCommand
	{
		// Token: 0x06001854 RID: 6228 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpUpgradeUnitCommand()
		{
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x00010144 File Offset: 0x0000E344
		public LogicSpeedUpUpgradeUnitCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x00010153 File Offset: 0x0000E353
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x00010168 File Offset: 0x0000E368
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x0001017D File Offset: 0x0000E37D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_UPGRADE_UNIT;
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00010184 File Offset: 0x0000E384
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x0005B868 File Offset: 0x00059A68
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicUnitUpgradeComponent unitUpgradeComponent = ((LogicBuilding)gameObjectByID).GetUnitUpgradeComponent();
				if (unitUpgradeComponent.GetCurrentlyUpgradedUnit() != null)
				{
					if (!unitUpgradeComponent.SpeedUp())
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D1C RID: 3356
		private int int_1;
	}
}
