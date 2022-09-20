using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000086 RID: 134
	public abstract class ServerResponseMessage : ServerMessage
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00006BB7 File Offset: 0x00004DB7
		// (set) Token: 0x060003AD RID: 941 RVA: 0x00006BBF File Offset: 0x00004DBF
		internal long RequestId { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00006BC8 File Offset: 0x00004DC8
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00006BD0 File Offset: 0x00004DD0
		public bool Success { get; set; }

		// Token: 0x060003B0 RID: 944 RVA: 0x00006BD9 File Offset: 0x00004DD9
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLongLong(this.RequestId);
			stream.WriteBoolean(this.Success);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00006BFA File Offset: 0x00004DFA
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.RequestId = stream.ReadLongLong();
			this.Success = stream.ReadBoolean();
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00005859 File Offset: 0x00003A59
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.RESPONSE;
		}

		// Token: 0x040001BC RID: 444
		[CompilerGenerated]
		private long long_0;

		// Token: 0x040001BD RID: 445
		[CompilerGenerated]
		private bool bool_0;
	}
}
