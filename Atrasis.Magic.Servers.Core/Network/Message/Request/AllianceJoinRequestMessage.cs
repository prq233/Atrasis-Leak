using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200006D RID: 109
	public class AllianceJoinRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00006482 File Offset: 0x00004682
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000648A File Offset: 0x0000468A
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00006493 File Offset: 0x00004693
		// (set) Token: 0x060002FF RID: 767 RVA: 0x0000649B File Offset: 0x0000469B
		public LogicClientAvatar Avatar { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000300 RID: 768 RVA: 0x000064A4 File Offset: 0x000046A4
		// (set) Token: 0x06000301 RID: 769 RVA: 0x000064AC File Offset: 0x000046AC
		public bool Created { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000302 RID: 770 RVA: 0x000064B5 File Offset: 0x000046B5
		// (set) Token: 0x06000303 RID: 771 RVA: 0x000064BD File Offset: 0x000046BD
		public bool Invited { get; set; }

		// Token: 0x06000304 RID: 772 RVA: 0x000064C6 File Offset: 0x000046C6
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AllianceId);
			stream.WriteBoolean(this.Created);
			stream.WriteBoolean(this.Invited);
			this.Avatar.Encode(stream);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x000064F8 File Offset: 0x000046F8
		public override void Decode(ByteStream stream)
		{
			this.AllianceId = stream.ReadLong();
			this.Created = stream.ReadBoolean();
			this.Invited = stream.ReadBoolean();
			this.Avatar = new LogicClientAvatar();
			this.Avatar.Decode(stream);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00006535 File Offset: 0x00004735
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_JOIN_REQUEST;
		}

		// Token: 0x04000165 RID: 357
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000166 RID: 358
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000167 RID: 359
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000168 RID: 360
		[CompilerGenerated]
		private bool bool_1;
	}
}
