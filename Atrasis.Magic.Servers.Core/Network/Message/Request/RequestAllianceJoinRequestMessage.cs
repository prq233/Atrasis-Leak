using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000082 RID: 130
	public class RequestAllianceJoinRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00006AA2 File Offset: 0x00004CA2
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00006AAA File Offset: 0x00004CAA
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00006AB3 File Offset: 0x00004CB3
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00006ABB File Offset: 0x00004CBB
		public LogicClientAvatar Avatar { get; set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00006AC4 File Offset: 0x00004CC4
		// (set) Token: 0x0600039B RID: 923 RVA: 0x00006ACC File Offset: 0x00004CCC
		public string Message { get; set; }

		// Token: 0x0600039C RID: 924 RVA: 0x00006AD5 File Offset: 0x00004CD5
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.Message);
			stream.WriteLong(this.AllianceId);
			this.Avatar.Encode(stream);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00006AFB File Offset: 0x00004CFB
		public override void Decode(ByteStream stream)
		{
			this.Message = stream.ReadString(900000);
			this.AllianceId = stream.ReadLong();
			this.Avatar = new LogicClientAvatar();
			this.Avatar.Decode(stream);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00006B31 File Offset: 0x00004D31
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REQUEST_ALLIANCE_JOIN_REQUEST;
		}

		// Token: 0x040001AF RID: 431
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001B0 RID: 432
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x040001B1 RID: 433
		[CompilerGenerated]
		private string string_0;
	}
}
