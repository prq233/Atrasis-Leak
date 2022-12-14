using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D8 RID: 472
	public sealed class LogicToggleHeroSleepCommand : LogicCommand
	{
		// Token: 0x06001888 RID: 6280 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicToggleHeroSleepCommand()
		{
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00010415 File Offset: 0x0000E615
		public LogicToggleHeroSleepCommand(int gameObjectId, bool enabled)
		{
			this.int_1 = gameObjectId;
			this.bool_0 = enabled;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x0001042B File Offset: 0x0000E62B
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x0001044C File Offset: 0x0000E64C
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x0001046D File Offset: 0x0000E66D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TOGGLE_HERO_SLEEP;
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x0005C2E4 File Offset: 0x0005A4E4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -1;
			}
			LogicHeroBaseComponent heroBaseComponent = ((LogicBuilding)gameObjectByID).GetHeroBaseComponent();
			if (heroBaseComponent == null)
			{
				return -4;
			}
			if (heroBaseComponent.GetHeroData().HasNoDefence())
			{
				return -3;
			}
			if (!heroBaseComponent.SetSleep(this.bool_0))
			{
				return -2;
			}
			return 0;
		}

		// Token: 0x04000D2B RID: 3371
		private int int_1;

		// Token: 0x04000D2C RID: 3372
		private bool bool_0;
	}
}
