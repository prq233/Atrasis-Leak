using System;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Servers.Core.Network.Message.Session;

namespace ns0
{
	// Token: 0x0200000D RID: 13
	public class GClass8 : LogicGameListener
	{
		// Token: 0x06000065 RID: 101 RVA: 0x0000269B File Offset: 0x0000089B
		public GClass8(GClass6 gclass6_1)
		{
			this.gclass6_0 = gclass6_1;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000026AA File Offset: 0x000008AA
		public override void MatchmakingCommandExecuted()
		{
			this.gclass6_0.method_8().SendMessage(new GameMatchmakingMessage(), 9);
			this.gclass6_0.method_7();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000026CE File Offset: 0x000008CE
		public override void MatchmakingVillage2CommandExecuted()
		{
			this.gclass6_0.method_8().SendMessage(new GameDuelMatchmakingMessage
			{
				Snapshot = this.gclass6_0.method_15()
			}, 9);
			this.gclass6_0.method_7();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002703 File Offset: 0x00000903
		public override void NameChanged(string name)
		{
			this.gclass6_0.method_11().method_1(name, this.gclass6_0.method_10().GetNameChangeState());
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002726 File Offset: 0x00000926
		public override void ShieldActivated(int hours)
		{
			base.ShieldActivated(hours);
		}

		// Token: 0x04000021 RID: 33
		private readonly GClass6 gclass6_0;
	}
}
