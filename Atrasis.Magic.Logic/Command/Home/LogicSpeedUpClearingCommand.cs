using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C9 RID: 457
	public sealed class LogicSpeedUpClearingCommand : LogicCommand
	{
		// Token: 0x06001824 RID: 6180 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpClearingCommand()
		{
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x0000FF62 File Offset: 0x0000E162
		public LogicSpeedUpClearingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x0000FF71 File Offset: 0x0000E171
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x0000FF86 File Offset: 0x0000E186
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x0000FF9B File Offset: 0x0000E19B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_CLEARING;
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x0005B490 File Offset: 0x00059690
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.OBSTACLE)
			{
				return -1;
			}
			if (!((LogicObstacle)gameObjectByID).SpeedUpClearing())
			{
				return -2;
			}
			return 0;
		}

		// Token: 0x04000D13 RID: 3347
		private int int_1;
	}
}
