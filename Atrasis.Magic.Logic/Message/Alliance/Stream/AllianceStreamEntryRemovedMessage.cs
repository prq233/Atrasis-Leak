using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000D9 RID: 217
	public class AllianceStreamEntryRemovedMessage : PiranhaMessage
	{
		// Token: 0x0600094A RID: 2378 RVA: 0x00007506 File Offset: 0x00005706
		public AllianceStreamEntryRemovedMessage() : this(0)
		{
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceStreamEntryRemovedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0000750F File Offset: 0x0000570F
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00007528 File Offset: 0x00005728
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00007541 File Offset: 0x00005741
		public override short GetMessageType()
		{
			return 24318;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00007548 File Offset: 0x00005748
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00007557 File Offset: 0x00005757
		public LogicLong GetStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0000755F File Offset: 0x0000575F
		public void SetStreamEntryId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x040003A8 RID: 936
		public const int MESSAGE_TYPE = 24318;

		// Token: 0x040003A9 RID: 937
		private LogicLong logicLong_0;
	}
}
