using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008E RID: 142
	public class ClaimDiamondsStreamEntryMessage : PiranhaMessage
	{
		// Token: 0x06000604 RID: 1540 RVA: 0x00005884 File Offset: 0x00003A84
		public ClaimDiamondsStreamEntryMessage() : this(0)
		{
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000328E File Offset: 0x0000148E
		public ClaimDiamondsStreamEntryMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000588D File Offset: 0x00003A8D
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000058A6 File Offset: 0x00003AA6
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000058BF File Offset: 0x00003ABF
		public override short GetMessageType()
		{
			return 14407;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x000058C6 File Offset: 0x00003AC6
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x000058D5 File Offset: 0x00003AD5
		public LogicLong RemoveStreamEntryId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x04000242 RID: 578
		public const int MESSAGE_TYPE = 14407;

		// Token: 0x04000243 RID: 579
		private LogicLong logicLong_0;
	}
}
