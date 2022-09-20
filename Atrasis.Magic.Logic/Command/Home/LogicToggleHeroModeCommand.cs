using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D7 RID: 471
	public sealed class LogicToggleHeroModeCommand : LogicCommand
	{
		// Token: 0x06001881 RID: 6273 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicToggleHeroModeCommand()
		{
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x000103B6 File Offset: 0x0000E5B6
		public LogicToggleHeroModeCommand(int gameObjectId, int mode)
		{
			this.int_1 = gameObjectId;
			this.int_2 = mode;
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x000103CC File Offset: 0x0000E5CC
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x000103ED File Offset: 0x0000E5ED
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x0001040E File Offset: 0x0000E60E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TOGGLE_HERO_MODE;
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x0005C28C File Offset: 0x0005A48C
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)gameObjectByID).GetHeroBaseComponent();
				if (heroBaseComponent != null && this.int_2 <= 1)
				{
					if (!heroBaseComponent.SetHeroMode(this.int_2))
					{
						return -2;
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D29 RID: 3369
		private int int_1;

		// Token: 0x04000D2A RID: 3370
		private int int_2;
	}
}
