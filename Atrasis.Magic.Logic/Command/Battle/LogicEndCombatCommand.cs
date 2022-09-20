using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001E8 RID: 488
	public sealed class LogicEndCombatCommand : LogicCommand
	{
		// Token: 0x060018FB RID: 6395 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x000108FE File Offset: 0x0000EAFE
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.END_COMBAT;
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x00010905 File Offset: 0x0000EB05
		public override int Execute(LogicLevel level)
		{
			if (level.GetBattleLog().GetBattleStarted())
			{
				level.EndBattle();
				level.GetGameListener().BattleEndedByPlayer();
				return 0;
			}
			return -1;
		}
	}
}
