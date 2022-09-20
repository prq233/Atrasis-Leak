using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007F RID: 127
	public class LiveReplayAddSpectatorRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000386 RID: 902 RVA: 0x000069D8 File Offset: 0x00004BD8
		// (set) Token: 0x06000387 RID: 903 RVA: 0x000069E0 File Offset: 0x00004BE0
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000388 RID: 904 RVA: 0x000069E9 File Offset: 0x00004BE9
		// (set) Token: 0x06000389 RID: 905 RVA: 0x000069F1 File Offset: 0x00004BF1
		public long SessionId { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600038A RID: 906 RVA: 0x000069FA File Offset: 0x00004BFA
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00006A02 File Offset: 0x00004C02
		public int SlotId { get; set; }

		// Token: 0x0600038C RID: 908 RVA: 0x00006A0B File Offset: 0x00004C0B
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.LiveReplayId);
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.SlotId);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00006A31 File Offset: 0x00004C31
		public override void Decode(ByteStream stream)
		{
			this.LiveReplayId = stream.ReadLong();
			this.SessionId = stream.ReadLongLong();
			this.SlotId = stream.ReadVInt();
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00006A57 File Offset: 0x00004C57
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_REQUEST;
		}

		// Token: 0x040001A8 RID: 424
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001A9 RID: 425
		[CompilerGenerated]
		private long long_1;

		// Token: 0x040001AA RID: 426
		[CompilerGenerated]
		private int int_2;
	}
}
