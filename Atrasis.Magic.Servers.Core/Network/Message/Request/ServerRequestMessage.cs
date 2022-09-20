using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000085 RID: 133
	public abstract class ServerRequestMessage : ServerMessage
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00006B7C File Offset: 0x00004D7C
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00006B84 File Offset: 0x00004D84
		internal long RequestId { get; set; }

		// Token: 0x060003A8 RID: 936 RVA: 0x00006B8D File Offset: 0x00004D8D
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLongLong(this.RequestId);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00006BA2 File Offset: 0x00004DA2
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.RequestId = stream.ReadLongLong();
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00005810 File Offset: 0x00003A10
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.REQUEST;
		}

		// Token: 0x040001BB RID: 443
		[CompilerGenerated]
		private long long_0;
	}
}
