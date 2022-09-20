using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008F RID: 143
	public class RemoveAllianceBookmarkMessage : PiranhaMessage
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x000058E4 File Offset: 0x00003AE4
		public RemoveAllianceBookmarkMessage() : this(0)
		{
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0000328E File Offset: 0x0000148E
		public RemoveAllianceBookmarkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000058ED File Offset: 0x00003AED
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00005906 File Offset: 0x00003B06
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0000591F File Offset: 0x00003B1F
		public override short GetMessageType()
		{
			return 14344;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00005926 File Offset: 0x00003B26
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00005935 File Offset: 0x00003B35
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0000593D File Offset: 0x00003B3D
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000244 RID: 580
		public const int MESSAGE_TYPE = 14344;

		// Token: 0x04000245 RID: 581
		private LogicLong logicLong_0;
	}
}
