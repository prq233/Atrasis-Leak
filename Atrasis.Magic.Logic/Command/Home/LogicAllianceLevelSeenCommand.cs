using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018A RID: 394
	public sealed class LogicAllianceLevelSeenCommand : LogicCommand
	{
		// Token: 0x06001683 RID: 5763 RVA: 0x0000EAF3 File Offset: 0x0000CCF3
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0000EB08 File Offset: 0x0000CD08
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0000EB1D File Offset: 0x0000CD1D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_LEVEL_SEEN;
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001687 RID: 5767 RVA: 0x0000EB24 File Offset: 0x0000CD24
		public override int Execute(LogicLevel level)
		{
			level.SetLastAllianceLevel(this.int_1);
			return 0;
		}

		// Token: 0x04000C9A RID: 3226
		private int int_1;
	}
}
