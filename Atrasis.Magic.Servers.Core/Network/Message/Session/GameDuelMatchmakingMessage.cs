using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000032 RID: 50
	public class GameDuelMatchmakingMessage : ServerSessionMessage
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600011E RID: 286 RVA: 0x000050F0 File Offset: 0x000032F0
		// (set) Token: 0x0600011F RID: 287 RVA: 0x000050F8 File Offset: 0x000032F8
		public byte[] Snapshot { get; set; }

		// Token: 0x06000120 RID: 288 RVA: 0x00005101 File Offset: 0x00003301
		public override void Encode(ByteStream stream)
		{
			stream.WriteBytes(this.Snapshot, this.Snapshot.Length);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005117 File Offset: 0x00003317
		public override void Decode(ByteStream stream)
		{
			this.Snapshot = stream.ReadBytes(stream.ReadBytesLength(), 900000);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005130 File Offset: 0x00003330
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_DUEL_MATCHMAKING;
		}

		// Token: 0x040000DB RID: 219
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
