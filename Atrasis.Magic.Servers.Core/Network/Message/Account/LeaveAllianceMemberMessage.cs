using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BA RID: 186
	public class LeaveAllianceMemberMessage : ServerAccountMessage
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x00007B8A File Offset: 0x00005D8A
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x00007B92 File Offset: 0x00005D92
		public LogicLong MemberId { get; set; }

		// Token: 0x0600053C RID: 1340 RVA: 0x00007B9B File Offset: 0x00005D9B
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00007BA9 File Offset: 0x00005DA9
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00007BB7 File Offset: 0x00005DB7
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LEAVE_ALLIANCE_MEMBER;
		}

		// Token: 0x04000221 RID: 545
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
