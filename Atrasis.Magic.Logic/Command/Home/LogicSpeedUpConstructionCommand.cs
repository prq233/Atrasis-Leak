using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CA RID: 458
	public sealed class LogicSpeedUpConstructionCommand : LogicCommand
	{
		// Token: 0x0600182B RID: 6187 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpConstructionCommand()
		{
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x0000FFA2 File Offset: 0x0000E1A2
		public LogicSpeedUpConstructionCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x0000FFB1 File Offset: 0x0000E1B1
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x0000FFD2 File Offset: 0x0000E1D2
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600182F RID: 6191 RVA: 0x0000FFF3 File Offset: 0x0000E1F3
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_CONSTRUCTION;
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x0005B4D0 File Offset: 0x000596D0
		public override int Execute(LogicLevel level)
		{
			if (this.int_2 <= 1 && level.GetGameObjectManagerAt(this.int_2) != null)
			{
				LogicGameObject gameObjectByID = level.GetGameObjectManagerAt(this.int_2).GetGameObjectByID(this.int_1);
				if (gameObjectByID != null)
				{
					LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
					if (gameObjectType == LogicGameObjectType.BUILDING)
					{
						if (!((LogicBuilding)gameObjectByID).SpeedUpConstruction())
						{
							return -1;
						}
						return 0;
					}
					else if (gameObjectType == LogicGameObjectType.TRAP)
					{
						if (!((LogicTrap)gameObjectByID).SpeedUpConstruction())
						{
							return -2;
						}
						return 0;
					}
					else if (gameObjectType == LogicGameObjectType.VILLAGE_OBJECT)
					{
						if (!((LogicVillageObject)gameObjectByID).SpeedUpCostruction())
						{
							return -1;
						}
						return 0;
					}
				}
			}
			return -3;
		}

		// Token: 0x04000D14 RID: 3348
		private int int_1;

		// Token: 0x04000D15 RID: 3349
		private int int_2;
	}
}
