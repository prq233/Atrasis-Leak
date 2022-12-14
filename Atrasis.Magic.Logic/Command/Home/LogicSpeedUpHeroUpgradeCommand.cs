using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CC RID: 460
	public sealed class LogicSpeedUpHeroUpgradeCommand : LogicCommand
	{
		// Token: 0x06001839 RID: 6201 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpHeroUpgradeCommand()
		{
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x00010059 File Offset: 0x0000E259
		public LogicSpeedUpHeroUpgradeCommand(int gameObjectId, int villageType)
		{
			this.int_1 = gameObjectId;
			this.int_2 = villageType;
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x0001006F File Offset: 0x0000E26F
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x00010090 File Offset: 0x0000E290
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x000100B1 File Offset: 0x0000E2B1
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_HERO_UPGRADE;
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x0005B5C4 File Offset: 0x000597C4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject logicGameObject = (this.int_2 > 1 || level.GetGameObjectManagerAt(this.int_2) == null) ? level.GetGameObjectManager().GetGameObjectByID(this.int_1) : level.GetGameObjectManagerAt(this.int_2).GetGameObjectByID(this.int_1);
			if (logicGameObject != null && logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)logicGameObject).GetHeroBaseComponent();
				if (heroBaseComponent != null)
				{
					if (!heroBaseComponent.SpeedUp())
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D18 RID: 3352
		private int int_1;

		// Token: 0x04000D19 RID: 3353
		private int int_2;
	}
}
