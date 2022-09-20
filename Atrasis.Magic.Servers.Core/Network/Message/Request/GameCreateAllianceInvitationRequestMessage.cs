using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000079 RID: 121
	public class GameCreateAllianceInvitationRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000364 RID: 868 RVA: 0x0000688C File Offset: 0x00004A8C
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00006894 File Offset: 0x00004A94
		public LogicLong AccountId { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000689D File Offset: 0x00004A9D
		// (set) Token: 0x06000367 RID: 871 RVA: 0x000068A5 File Offset: 0x00004AA5
		public AllianceInvitationAvatarStreamEntry Entry { get; set; }

		// Token: 0x06000368 RID: 872 RVA: 0x000068AE File Offset: 0x00004AAE
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			this.Entry.Encode(stream);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000068C8 File Offset: 0x00004AC8
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.Entry = new AllianceInvitationAvatarStreamEntry();
			this.Entry.Decode(stream);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000068ED File Offset: 0x00004AED
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_REQUEST;
		}

		// Token: 0x04000191 RID: 401
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000192 RID: 402
		[CompilerGenerated]
		private AllianceInvitationAvatarStreamEntry allianceInvitationAvatarStreamEntry_0;
	}
}
