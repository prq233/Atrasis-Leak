using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000198 RID: 408
	public sealed class LogicCancelHeroUpgradeCommand : LogicCommand
	{
		// Token: 0x060016E4 RID: 5860 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicCancelHeroUpgradeCommand()
		{
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0000EF3B File Offset: 0x0000D13B
		public LogicCancelHeroUpgradeCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0000EF4A File Offset: 0x0000D14A
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x0000EF5F File Offset: 0x0000D15F
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0000EF74 File Offset: 0x0000D174
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_HERO_UPGRADE;
		}

		// Token: 0x060016E9 RID: 5865 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016EA RID: 5866 RVA: 0x00057B18 File Offset: 0x00055D18
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)gameObjectByID).GetHeroBaseComponent();
				if (heroBaseComponent != null)
				{
					heroBaseComponent.CancelUpgrade();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CB1 RID: 3249
		private int int_1;
	}
}
