using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C0 RID: 192
	public class DonateAllianceUnitMessage : PiranhaMessage
	{
		// Token: 0x06000856 RID: 2134 RVA: 0x00006C23 File Offset: 0x00004E23
		public DonateAllianceUnitMessage() : this(0)
		{
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0000328E File Offset: 0x0000148E
		public DonateAllianceUnitMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00020C5C File Offset: 0x0001EE5C
		public override void Decode()
		{
			base.Decode();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(this.m_stream, (this.m_stream.ReadInt() != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.logicLong_0 = this.m_stream.ReadLong();
			this.bool_0 = this.m_stream.ReadBoolean();
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00006C2C File Offset: 0x00004E2C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.logicCombatItemData_0.GetCombatItemType());
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicCombatItemData_0);
			this.m_stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00006C6C File Offset: 0x00004E6C
		public override short GetMessageType()
		{
			return 14310;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00006C73 File Offset: 0x00004E73
		public override void Destruct()
		{
			base.Destruct();
			this.logicCombatItemData_0 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00006C89 File Offset: 0x00004E89
		public LogicCombatItemData GetAllianceUnitData()
		{
			return this.logicCombatItemData_0;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00006C91 File Offset: 0x00004E91
		public void SetAllianceUnitData(LogicCombatItemData data)
		{
			this.logicCombatItemData_0 = data;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00006C9A File Offset: 0x00004E9A
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00006CA2 File Offset: 0x00004EA2
		public void SetStreamId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00006CAB File Offset: 0x00004EAB
		public bool UseQuickDonate()
		{
			return this.bool_0;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00006CB3 File Offset: 0x00004EB3
		public void SetQuickDonate(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x04000337 RID: 823
		public const int MESSAGE_TYPE = 14310;

		// Token: 0x04000338 RID: 824
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000339 RID: 825
		private LogicLong logicLong_0;

		// Token: 0x0400033A RID: 826
		private bool bool_0;
	}
}
