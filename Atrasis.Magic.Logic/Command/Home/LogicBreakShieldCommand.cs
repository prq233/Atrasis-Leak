using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018E RID: 398
	public sealed class LogicBreakShieldCommand : LogicCommand
	{
		// Token: 0x060016A2 RID: 5794 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060016A3 RID: 5795 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060016A4 RID: 5796 RVA: 0x0000EBFD File Offset: 0x0000CDFD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BREAK_SHIELD;
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016A6 RID: 5798 RVA: 0x00056AFC File Offset: 0x00054CFC
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() == 0)
			{
				LogicGameMode gameMode = level.GetGameMode();
				if (gameMode.GetShieldRemainingSeconds() <= 0)
				{
					gameMode.SetShieldRemainingSeconds(0);
					gameMode.SetGuardRemainingSeconds(0);
					gameMode.GetLevel().GetHome().GetChangeListener().ShieldActivated(0, 0);
				}
				else
				{
					int guardRemainingSeconds = gameMode.GetGuardRemainingSeconds();
					gameMode.SetShieldRemainingSeconds(0);
					gameMode.SetGuardRemainingSeconds(guardRemainingSeconds);
					gameMode.SetPersonalBreakCooldownSeconds(LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds());
					level.GetHome().GetChangeListener().ShieldActivated(0, guardRemainingSeconds);
				}
				return 0;
			}
			return -32;
		}
	}
}
