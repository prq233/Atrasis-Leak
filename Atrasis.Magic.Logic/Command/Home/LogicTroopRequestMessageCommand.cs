using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DC RID: 476
	public sealed class LogicTroopRequestMessageCommand : LogicCommand
	{
		// Token: 0x060018A4 RID: 6308 RVA: 0x000105D4 File Offset: 0x0000E7D4
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x000105EE File Offset: 0x0000E7EE
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x00010603 File Offset: 0x0000E803
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TROOP_REQUEST_MESSAGE;
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x0001060A File Offset: 0x0000E80A
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00010619 File Offset: 0x0000E819
		public override int Execute(LogicLevel level)
		{
			level.SetTroopRequestMessage(this.string_0);
			return 0;
		}

		// Token: 0x04000D35 RID: 3381
		private string string_0;
	}
}
