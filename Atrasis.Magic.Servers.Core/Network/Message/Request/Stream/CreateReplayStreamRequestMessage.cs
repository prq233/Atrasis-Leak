using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000089 RID: 137
	public class CreateReplayStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x00006D00 File Offset: 0x00004F00
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x00006D08 File Offset: 0x00004F08
		public string JSON { get; set; }

		// Token: 0x060003C4 RID: 964 RVA: 0x00006D11 File Offset: 0x00004F11
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.JSON);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00006D1F File Offset: 0x00004F1F
		public override void Decode(ByteStream stream)
		{
			this.JSON = stream.ReadString(900000);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00006D32 File Offset: 0x00004F32
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_REPLAY_STREAM_REQUEST;
		}

		// Token: 0x040001C1 RID: 449
		[CompilerGenerated]
		private string string_0;
	}
}
