using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007D RID: 125
	public class GameJoinAllianceResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00006994 File Offset: 0x00004B94
		// (set) Token: 0x06000381 RID: 897 RVA: 0x0000699C File Offset: 0x00004B9C
		public GameJoinAllianceResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x06000382 RID: 898 RVA: 0x000069A5 File Offset: 0x00004BA5
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorReason);
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000069BB File Offset: 0x00004BBB
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorReason = (GameJoinAllianceResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x000069D1 File Offset: 0x00004BD1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_JOIN_ALLIANCE_RESPONSE;
		}

		// Token: 0x0400019F RID: 415
		[CompilerGenerated]
		private GameJoinAllianceResponseMessage.Reason reason_0;

		// Token: 0x0200007E RID: 126
		public enum Reason
		{
			// Token: 0x040001A1 RID: 417
			NO_CASTLE,
			// Token: 0x040001A2 RID: 418
			ALREADY_IN_ALLIANCE,
			// Token: 0x040001A3 RID: 419
			GENERIC,
			// Token: 0x040001A4 RID: 420
			FULL,
			// Token: 0x040001A5 RID: 421
			CLOSED,
			// Token: 0x040001A6 RID: 422
			SCORE,
			// Token: 0x040001A7 RID: 423
			BANNED
		}
	}
}
