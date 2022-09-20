using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A0 RID: 416
	public sealed class LogicEditModeShownCommand : LogicCommand
	{
		// Token: 0x0600171B RID: 5915 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x0600171C RID: 5916 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x0000F159 File Offset: 0x0000D359
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.EDIT_MODE_SHOWN;
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0000F160 File Offset: 0x0000D360
		public override int Execute(LogicLevel level)
		{
			level.SetEditModeShown();
			return 0;
		}
	}
}
