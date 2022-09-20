using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007A RID: 122
	public class GameCreateAllianceInvitationResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600036C RID: 876 RVA: 0x000068F4 File Offset: 0x00004AF4
		// (set) Token: 0x0600036D RID: 877 RVA: 0x000068FC File Offset: 0x00004AFC
		public GameCreateAllianceInvitationResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x0600036E RID: 878 RVA: 0x00006905 File Offset: 0x00004B05
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorReason);
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000691B File Offset: 0x00004B1B
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorReason = (GameCreateAllianceInvitationResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00006931 File Offset: 0x00004B31
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_RESPONSE;
		}

		// Token: 0x04000193 RID: 403
		[CompilerGenerated]
		private GameCreateAllianceInvitationResponseMessage.Reason reason_0;

		// Token: 0x0200007B RID: 123
		public enum Reason
		{
			// Token: 0x04000195 RID: 405
			GENERIC,
			// Token: 0x04000196 RID: 406
			NO_CASTLE,
			// Token: 0x04000197 RID: 407
			ALREADY_IN_ALLIANCE,
			// Token: 0x04000198 RID: 408
			ALREADY_HAS_AN_INVITE,
			// Token: 0x04000199 RID: 409
			HAS_TOO_MANY_INVITES
		}
	}
}
