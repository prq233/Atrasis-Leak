using System;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Home.Change;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;

namespace ns0
{
	// Token: 0x0200000E RID: 14
	public class GClass9 : LogicHomeChangeListener
	{
		// Token: 0x0600006A RID: 106 RVA: 0x0000272F File Offset: 0x0000092F
		public GClass9(GClass6 gclass6_1, LogicClientHome logicClientHome_1)
		{
			this.logicClientHome_0 = logicClientHome_1;
			this.gclass6_0 = gclass6_1;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002745 File Offset: 0x00000945
		public override void GuardActivated(int guard)
		{
			ServerMessageManager.SendMessage(new GameHomeProtectionUpdateMessage
			{
				AccountId = this.logicClientHome_0.GetHomeId(),
				GuardTime = guard
			}, 9);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000276B File Offset: 0x0000096B
		public override void ShieldActivated(int shield, int guard)
		{
			ServerMessageManager.SendMessage(new GameHomeProtectionUpdateMessage
			{
				AccountId = this.logicClientHome_0.GetHomeId(),
				ShieldTime = shield,
				GuardTime = guard
			}, 9);
		}

		// Token: 0x04000022 RID: 34
		private readonly LogicClientHome logicClientHome_0;

		// Token: 0x04000023 RID: 35
		private readonly GClass6 gclass6_0;
	}
}
