using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000077 RID: 119
	public class GameAvatarRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00006814 File Offset: 0x00004A14
		// (set) Token: 0x06000359 RID: 857 RVA: 0x0000681C File Offset: 0x00004A1C
		public LogicLong AccountId { get; set; }

		// Token: 0x0600035A RID: 858 RVA: 0x00006825 File Offset: 0x00004A25
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00006833 File Offset: 0x00004A33
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00006841 File Offset: 0x00004A41
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_AVATAR_REQUEST;
		}

		// Token: 0x0400018F RID: 399
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
