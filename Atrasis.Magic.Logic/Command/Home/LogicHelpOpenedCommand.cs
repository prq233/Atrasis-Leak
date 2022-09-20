using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A6 RID: 422
	public sealed class LogicHelpOpenedCommand : LogicCommand
	{
		// Token: 0x0600173F RID: 5951 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x0000F32C File Offset: 0x0000D52C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.HELP_OPENED;
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001743 RID: 5955 RVA: 0x0000F333 File Offset: 0x0000D533
		public override int Execute(LogicLevel level)
		{
			level.SetHelpOpened(true);
			return 0;
		}
	}
}
