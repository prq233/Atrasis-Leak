using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008A RID: 138
	public class CreateReplayStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00006D39 File Offset: 0x00004F39
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x00006D41 File Offset: 0x00004F41
		public LogicLong Id { get; set; }

		// Token: 0x060003CA RID: 970 RVA: 0x00006D4A File Offset: 0x00004F4A
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteLong(this.Id);
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00006D60 File Offset: 0x00004F60
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Id = stream.ReadLong();
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00006D76 File Offset: 0x00004F76
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_REPLAY_STREAM_RESPONSE;
		}

		// Token: 0x040001C2 RID: 450
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
