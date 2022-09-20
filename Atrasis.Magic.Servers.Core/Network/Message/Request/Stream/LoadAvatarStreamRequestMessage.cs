using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000090 RID: 144
	public class LoadAvatarStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00006EB4 File Offset: 0x000050B4
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00006EBC File Offset: 0x000050BC
		public LogicLong Id { get; set; }

		// Token: 0x060003EE RID: 1006 RVA: 0x00006EC5 File Offset: 0x000050C5
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.Id);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00006ED3 File Offset: 0x000050D3
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadLong();
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00006EE1 File Offset: 0x000050E1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_REQUEST;
		}

		// Token: 0x040001CD RID: 461
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
