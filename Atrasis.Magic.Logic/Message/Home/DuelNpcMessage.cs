using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000049 RID: 73
	public class DuelNpcMessage : PiranhaMessage
	{
		// Token: 0x06000349 RID: 841 RVA: 0x00003FFD File Offset: 0x000021FD
		public DuelNpcMessage() : this(0)
		{
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000328E File Offset: 0x0000148E
		public DuelNpcMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00004006 File Offset: 0x00002206
		public override void Decode()
		{
			base.Decode();
			this.logicNpcData_0 = (LogicNpcData)ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.NPC);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00004026 File Offset: 0x00002226
		public override void Encode()
		{
			base.Encode();
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicNpcData_0);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000403F File Offset: 0x0000223F
		public override short GetMessageType()
		{
			return 14135;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00004046 File Offset: 0x00002246
		public override void Destruct()
		{
			base.Destruct();
			this.logicNpcData_0 = null;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00004055 File Offset: 0x00002255
		public LogicNpcData GetNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000405D File Offset: 0x0000225D
		public void SetNpcData(LogicNpcData data)
		{
			this.logicNpcData_0 = data;
		}

		// Token: 0x0400014A RID: 330
		public const int MESSAGE_TYPE = 14135;

		// Token: 0x0400014B RID: 331
		private LogicNpcData logicNpcData_0;
	}
}
