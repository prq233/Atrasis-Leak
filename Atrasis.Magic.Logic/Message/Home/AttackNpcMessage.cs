using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000043 RID: 67
	public class AttackNpcMessage : PiranhaMessage
	{
		// Token: 0x0600031C RID: 796 RVA: 0x00003E3E File Offset: 0x0000203E
		public AttackNpcMessage() : this(0)
		{
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000328E File Offset: 0x0000148E
		public AttackNpcMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00003E47 File Offset: 0x00002047
		public override void Decode()
		{
			base.Decode();
			this.logicNpcData_0 = (LogicNpcData)ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.NPC);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00003E67 File Offset: 0x00002067
		public override void Encode()
		{
			base.Encode();
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicNpcData_0);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00003E80 File Offset: 0x00002080
		public override short GetMessageType()
		{
			return 14134;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00003E87 File Offset: 0x00002087
		public override void Destruct()
		{
			base.Destruct();
			this.logicNpcData_0 = null;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00003E96 File Offset: 0x00002096
		public LogicNpcData GetNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00003E9E File Offset: 0x0000209E
		public void SetNpcData(LogicNpcData data)
		{
			this.logicNpcData_0 = data;
		}

		// Token: 0x0400013C RID: 316
		public const int MESSAGE_TYPE = 14134;

		// Token: 0x0400013D RID: 317
		private LogicNpcData logicNpcData_0;
	}
}
