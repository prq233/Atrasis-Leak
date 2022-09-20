using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B9 RID: 185
	public class InitializeLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00007B43 File Offset: 0x00005D43
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x00007B4B File Offset: 0x00005D4B
		public byte[] StreamData { get; set; }

		// Token: 0x06000536 RID: 1334 RVA: 0x00007B54 File Offset: 0x00005D54
		public override void Encode(ByteStream stream)
		{
			stream.WriteBytes(this.StreamData, this.StreamData.Length);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00007B6A File Offset: 0x00005D6A
		public override void Decode(ByteStream stream)
		{
			this.StreamData = stream.ReadBytes(stream.ReadBytesLength(), 900000);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00007B83 File Offset: 0x00005D83
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.INITIALIZE_LIVE_REPLAY;
		}

		// Token: 0x04000220 RID: 544
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
