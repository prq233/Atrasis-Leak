using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CB RID: 459
	public sealed class LogicSpeedUpHeroHealthCommand : LogicCommand
	{
		// Token: 0x06001832 RID: 6194 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpHeroHealthCommand()
		{
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x0000FFFA File Offset: 0x0000E1FA
		public LogicSpeedUpHeroHealthCommand(int gameObjectId, int villageType)
		{
			this.int_1 = gameObjectId;
			this.int_2 = villageType;
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x00010010 File Offset: 0x0000E210
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x00010031 File Offset: 0x0000E231
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x00010052 File Offset: 0x0000E252
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_HERO_HEALTH;
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x0005B558 File Offset: 0x00059758
		public override int Execute(LogicLevel level)
		{
			LogicGameObject logicGameObject = (this.int_2 <= 1) ? level.GetGameObjectManagerAt(this.int_2).GetGameObjectByID(this.int_1) : level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (logicGameObject != null && logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)logicGameObject).GetHeroBaseComponent();
				if (heroBaseComponent != null)
				{
					if (!heroBaseComponent.SpeedUpHealth())
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D16 RID: 3350
		private int int_1;

		// Token: 0x04000D17 RID: 3351
		private int int_2;
	}
}
