using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C0 RID: 448
	public sealed class LogicSetAccountFlagToLevelCommand : LogicCommand
	{
		// Token: 0x060017E8 RID: 6120 RVA: 0x0000FC48 File Offset: 0x0000DE48
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x0000FC69 File Offset: 0x0000DE69
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x060017EA RID: 6122 RVA: 0x0000FC8A File Offset: 0x0000DE8A
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_ACCOUNT_FLAG_TO_LEVEL;
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x0005B198 File Offset: 0x00059398
		public override int Execute(LogicLevel level)
		{
			switch (this.int_1)
			{
			case 0:
				level.SetHelpOpened(this.bool_0);
				break;
			case 1:
				level.SetEditModeShown();
				break;
			case 2:
				level.SetShieldCostPopupShown(this.bool_0);
				break;
			case 3:
				break;
			default:
				return -1;
			}
			return 0;
		}

		// Token: 0x04000D04 RID: 3332
		private int int_1;

		// Token: 0x04000D05 RID: 3333
		private bool bool_0;
	}
}
