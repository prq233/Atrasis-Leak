using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000070 RID: 112
	public class AvatarRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000318 RID: 792 RVA: 0x000065B9 File Offset: 0x000047B9
		// (set) Token: 0x06000319 RID: 793 RVA: 0x000065C1 File Offset: 0x000047C1
		public LogicLong AccountId { get; set; }

		// Token: 0x0600031A RID: 794 RVA: 0x000065CA File Offset: 0x000047CA
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000065D8 File Offset: 0x000047D8
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000065E6 File Offset: 0x000047E6
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.AVATAR_REQUEST;
		}

		// Token: 0x04000175 RID: 373
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
