using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000196 RID: 406
	public sealed class LogicCancelChallengeCommand : LogicCommand
	{
		// Token: 0x060016D7 RID: 5847 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0000EED7 File Offset: 0x0000D0D7
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_CHALLENGE;
		}

		// Token: 0x060016DA RID: 5850 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016DB RID: 5851 RVA: 0x0000EEDE File Offset: 0x0000D0DE
		public override int Execute(LogicLevel level)
		{
			if (LogicDataTables.GetGlobals().UseVersusBattle())
			{
				level.GetGameListener().CancelFriendlyVersusBattle();
				return 0;
			}
			return -2;
		}
	}
}
