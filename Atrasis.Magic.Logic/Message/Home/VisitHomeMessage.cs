using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000060 RID: 96
	public class VisitHomeMessage : PiranhaMessage
	{
		// Token: 0x06000457 RID: 1111 RVA: 0x000048D5 File Offset: 0x00002AD5
		public VisitHomeMessage() : this(0)
		{
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000328E File Offset: 0x0000148E
		public VisitHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x000048DE File Offset: 0x00002ADE
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00004908 File Offset: 0x00002B08
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00004932 File Offset: 0x00002B32
		public override short GetMessageType()
		{
			return 14113;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00004939 File Offset: 0x00002B39
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00004948 File Offset: 0x00002B48
		public int GetVisitType()
		{
			return this.int_0;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00004950 File Offset: 0x00002B50
		public void SetVillageType(int villageType)
		{
			this.int_0 = villageType;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00004959 File Offset: 0x00002B59
		public LogicLong RemoveHomeId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00004968 File Offset: 0x00002B68
		public void SetHomeId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x040001A7 RID: 423
		public const int MESSAGE_TYPE = 14113;

		// Token: 0x040001A8 RID: 424
		private LogicLong logicLong_0;

		// Token: 0x040001A9 RID: 425
		private int int_0;
	}
}
