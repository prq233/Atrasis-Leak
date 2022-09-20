using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003B RID: 59
	public class SendAvatarStreamsToClientMessage : ServerSessionMessage
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00005393 File Offset: 0x00003593
		// (set) Token: 0x0600015D RID: 349 RVA: 0x0000539B File Offset: 0x0000359B
		public LogicArrayList<LogicLong> StreamIds { get; set; }

		// Token: 0x0600015E RID: 350 RVA: 0x0000B608 File Offset: 0x00009808
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.StreamIds.Size());
			for (int i = 0; i < this.StreamIds.Size(); i++)
			{
				stream.WriteLong(this.StreamIds[i]);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000B650 File Offset: 0x00009850
		public override void Decode(ByteStream stream)
		{
			this.StreamIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.StreamIds.Add(stream.ReadLong());
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000053A4 File Offset: 0x000035A4
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SEND_AVATAR_STREAMS_TO_CLIENT;
		}

		// Token: 0x040000E8 RID: 232
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
