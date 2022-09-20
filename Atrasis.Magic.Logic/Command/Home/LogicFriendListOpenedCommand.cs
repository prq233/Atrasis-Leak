using System;
using Atrasis.Magic.Logic.Level;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A4 RID: 420
	public sealed class LogicFriendListOpenedCommand : LogicCommand
	{
		// Token: 0x06001734 RID: 5940 RVA: 0x0000F2D7 File Offset: 0x0000D4D7
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.FRIEND_LIST_OPENED;
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x0000F2DE File Offset: 0x0000D4DE
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().UpdateLastFriendListOpened();
			return 0;
		}
	}
}
