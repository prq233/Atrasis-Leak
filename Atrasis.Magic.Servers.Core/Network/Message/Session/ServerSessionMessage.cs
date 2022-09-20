using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003D RID: 61
	public abstract class ServerSessionMessage : ServerMessage
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000168 RID: 360 RVA: 0x000053C3 File Offset: 0x000035C3
		// (set) Token: 0x06000169 RID: 361 RVA: 0x000053CB File Offset: 0x000035CB
		public long SessionId { get; set; }

		// Token: 0x0600016A RID: 362 RVA: 0x000053D4 File Offset: 0x000035D4
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLongLong(this.SessionId);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000053E9 File Offset: 0x000035E9
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.SessionId = stream.ReadLongLong();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000053FE File Offset: 0x000035FE
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.SESSION;
		}

		// Token: 0x040000EA RID: 234
		[CompilerGenerated]
		private long long_0;
	}
}
