using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C8 RID: 456
	public sealed class LogicSpeedUpBoostCooldownCommand : LogicCommand
	{
		// Token: 0x0600181D RID: 6173 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpBoostCooldownCommand()
		{
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x0000FF22 File Offset: 0x0000E122
		public LogicSpeedUpBoostCooldownCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x0000FF31 File Offset: 0x0000E131
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x0000FF46 File Offset: 0x0000E146
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x0000FF5B File Offset: 0x0000E15B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_BOOST_COOLDOWN;
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x0005B434 File Offset: 0x00059634
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -1;
			}
			LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
			bool flag = logicBuilding.SpeedUpBoostCooldown();
			if (logicBuilding.GetBuildingData().IsClockTower())
			{
				logicBuilding.GetListener().RefreshState();
			}
			if (!flag)
			{
				return -2;
			}
			return 0;
		}

		// Token: 0x04000D12 RID: 3346
		private int int_1;
	}
}
