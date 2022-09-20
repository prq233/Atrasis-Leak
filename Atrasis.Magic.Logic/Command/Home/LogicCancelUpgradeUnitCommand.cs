using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019A RID: 410
	public sealed class LogicCancelUpgradeUnitCommand : LogicCommand
	{
		// Token: 0x060016F3 RID: 5875 RVA: 0x0000EFFE File Offset: 0x0000D1FE
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x0000F013 File Offset: 0x0000D213
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x0000F028 File Offset: 0x0000D228
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_UPGRADE_UNIT;
		}

		// Token: 0x060016F6 RID: 5878 RVA: 0x0000F02F File Offset: 0x0000D22F
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x00002B32 File Offset: 0x00000D32
		public override int Execute(LogicLevel level)
		{
			return -1;
		}

		// Token: 0x04000CB7 RID: 3255
		private int int_1;
	}
}
