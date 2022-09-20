using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200004E RID: 78
	public class GameVisitState : GameState
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00005961 File Offset: 0x00003B61
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00005969 File Offset: 0x00003B69
		public LogicClientAvatar HomeOwnerAvatar { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00005972 File Offset: 0x00003B72
		// (set) Token: 0x060001FA RID: 506 RVA: 0x0000597A File Offset: 0x00003B7A
		public int VisitType { get; set; }

		// Token: 0x060001FB RID: 507 RVA: 0x00005983 File Offset: 0x00003B83
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.HomeOwnerAvatar.Encode(stream);
			stream.WriteVInt(this.VisitType);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000059A4 File Offset: 0x00003BA4
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.HomeOwnerAvatar = new LogicClientAvatar();
			this.HomeOwnerAvatar.Decode(stream);
			this.VisitType = stream.ReadVInt();
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000059D0 File Offset: 0x00003BD0
		public override GameStateType GetGameStateType()
		{
			return GameStateType.VISIT;
		}

		// Token: 0x0400011E RID: 286
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x0400011F RID: 287
		[CompilerGenerated]
		private int int_1;
	}
}
