using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000047 RID: 71
	public class GameNpcDuelState : GameState
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00005813 File Offset: 0x00003A13
		// (set) Token: 0x060001DC RID: 476 RVA: 0x0000581B File Offset: 0x00003A1B
		public LogicNpcAvatar NpcAvatar { get; set; }

		// Token: 0x060001DD RID: 477 RVA: 0x00005824 File Offset: 0x00003A24
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.NpcAvatar.Encode(stream);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00005839 File Offset: 0x00003A39
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.NpcAvatar = new LogicNpcAvatar();
			this.NpcAvatar.Decode(stream);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00005859 File Offset: 0x00003A59
		public override GameStateType GetGameStateType()
		{
			return GameStateType.NPC_DUEL;
		}

		// Token: 0x0400010D RID: 269
		[CompilerGenerated]
		private LogicNpcAvatar logicNpcAvatar_0;
	}
}
