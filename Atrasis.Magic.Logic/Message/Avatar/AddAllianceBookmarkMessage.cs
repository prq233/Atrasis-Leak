using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200007D RID: 125
	public class AddAllianceBookmarkMessage : PiranhaMessage
	{
		// Token: 0x06000573 RID: 1395 RVA: 0x000052CC File Offset: 0x000034CC
		public AddAllianceBookmarkMessage() : this(0)
		{
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0000328E File Offset: 0x0000148E
		public AddAllianceBookmarkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000052D5 File Offset: 0x000034D5
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x000052EE File Offset: 0x000034EE
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00005307 File Offset: 0x00003507
		public override short GetMessageType()
		{
			return 14343;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000530E File Offset: 0x0000350E
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0000531D File Offset: 0x0000351D
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00005325 File Offset: 0x00003525
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0400020C RID: 524
		public const int MESSAGE_TYPE = 14343;

		// Token: 0x0400020D RID: 525
		private LogicLong logicLong_0;
	}
}
