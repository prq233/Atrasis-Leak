using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000092 RID: 146
	public class LoadReplayStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x00006F4E File Offset: 0x0000514E
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x00006F56 File Offset: 0x00005156
		public LogicLong Id { get; set; }

		// Token: 0x060003FA RID: 1018 RVA: 0x00006F5F File Offset: 0x0000515F
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.Id);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00006F6D File Offset: 0x0000516D
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadLong();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00006F7B File Offset: 0x0000517B
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_REPLAY_STREAM_REQUEST;
		}

		// Token: 0x040001CF RID: 463
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
