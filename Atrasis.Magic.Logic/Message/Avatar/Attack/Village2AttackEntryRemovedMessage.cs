using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x020000A2 RID: 162
	public class Village2AttackEntryRemovedMessage : PiranhaMessage
	{
		// Token: 0x060006F2 RID: 1778 RVA: 0x00006031 File Offset: 0x00004231
		public Village2AttackEntryRemovedMessage() : this(0)
		{
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0000328E File Offset: 0x0000148E
		public Village2AttackEntryRemovedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0000603A File Offset: 0x0000423A
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00006053 File Offset: 0x00004253
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0000606C File Offset: 0x0000426C
		public override short GetMessageType()
		{
			return 24373;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00006073 File Offset: 0x00004273
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0000607B File Offset: 0x0000427B
		public void SetStreamId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0400029A RID: 666
		public const int MESSAGE_TYPE = 24373;

		// Token: 0x0400029B RID: 667
		private LogicLong logicLong_0;
	}
}
