using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000195 RID: 405
	public sealed class LogicCancelAllianceWarCommand : LogicCommand
	{
		// Token: 0x060016D1 RID: 5841 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060016D2 RID: 5842 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060016D3 RID: 5843 RVA: 0x0000EEBD File Offset: 0x0000D0BD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_ALLIANCE_WAR;
		}

		// Token: 0x060016D4 RID: 5844 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016D5 RID: 5845 RVA: 0x0000EEC4 File Offset: 0x0000D0C4
		public override int Execute(LogicLevel level)
		{
			level.GetHomeOwnerAvatar().GetChangeListener().CancelWar();
			return 0;
		}
	}
}
