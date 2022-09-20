using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000046 RID: 70
	public class GameNpcAttackState : GameState
	{
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x000057CA File Offset: 0x000039CA
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x000057D2 File Offset: 0x000039D2
		public LogicNpcAvatar NpcAvatar { get; set; }

		// Token: 0x060001D7 RID: 471 RVA: 0x000057DB File Offset: 0x000039DB
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.NpcAvatar.Encode(stream);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000057F0 File Offset: 0x000039F0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.NpcAvatar = new LogicNpcAvatar();
			this.NpcAvatar.Decode(stream);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00005810 File Offset: 0x00003A10
		public override GameStateType GetGameStateType()
		{
			return GameStateType.NPC_ATTACK;
		}

		// Token: 0x0400010C RID: 268
		[CompilerGenerated]
		private LogicNpcAvatar logicNpcAvatar_0;
	}
}
