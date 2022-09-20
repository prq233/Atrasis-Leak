using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BE RID: 190
	public abstract class ServerAccountMessage : ServerMessage
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x00007C29 File Offset: 0x00005E29
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x00007C31 File Offset: 0x00005E31
		public LogicLong AccountId { get; set; }

		// Token: 0x06000552 RID: 1362 RVA: 0x00007C3A File Offset: 0x00005E3A
		public sealed override void EncodeHeader(ByteStream stream)
		{
			base.EncodeHeader(stream);
			stream.WriteLong(this.AccountId);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00007C4F File Offset: 0x00005E4F
		public sealed override void DecodeHeader(ByteStream stream)
		{
			base.DecodeHeader(stream);
			this.AccountId = stream.ReadLong();
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0000574A File Offset: 0x0000394A
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.ACCOUNT;
		}

		// Token: 0x04000224 RID: 548
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
