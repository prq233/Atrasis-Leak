using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BB RID: 187
	public class LiveReplayRemoveSpectatorMessage : ServerAccountMessage
	{
		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x00007BBE File Offset: 0x00005DBE
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x00007BC6 File Offset: 0x00005DC6
		public long SessionId { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x00007BCF File Offset: 0x00005DCF
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x00007BD7 File Offset: 0x00005DD7
		public int SlotId { get; set; }

		// Token: 0x06000544 RID: 1348 RVA: 0x00007BE0 File Offset: 0x00005DE0
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.SlotId);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00007BFA File Offset: 0x00005DFA
		public override void Decode(ByteStream stream)
		{
			this.SessionId = stream.ReadLongLong();
			this.SlotId = stream.ReadVInt();
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00007C14 File Offset: 0x00005E14
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LIVE_REPLAY_REMOVE_SPECTATOR;
		}

		// Token: 0x04000222 RID: 546
		[CompilerGenerated]
		private long long_0;

		// Token: 0x04000223 RID: 547
		[CompilerGenerated]
		private int int_2;
	}
}
