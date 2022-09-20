using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A8 RID: 168
	public class AllianceKickMemberMessage : ServerAccountMessage
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x00007587 File Offset: 0x00005787
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x0000758F File Offset: 0x0000578F
		public LogicLong MemberId { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x00007598 File Offset: 0x00005798
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x000075A0 File Offset: 0x000057A0
		public LogicLong KickMemberId { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x000075A9 File Offset: 0x000057A9
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x000075B1 File Offset: 0x000057B1
		public string Message { get; set; }

		// Token: 0x0600049A RID: 1178 RVA: 0x000075BA File Offset: 0x000057BA
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.KickMemberId);
			stream.WriteString(this.Message);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x000075E0 File Offset: 0x000057E0
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.KickMemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000760B File Offset: 0x0000580B
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_KICK_MEMBER;
		}

		// Token: 0x040001F2 RID: 498
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001F3 RID: 499
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x040001F4 RID: 500
		[CompilerGenerated]
		private string string_0;
	}
}
