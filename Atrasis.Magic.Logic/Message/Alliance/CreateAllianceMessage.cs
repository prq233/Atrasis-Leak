using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BF RID: 191
	public class CreateAllianceMessage : PiranhaMessage
	{
		// Token: 0x0600083C RID: 2108 RVA: 0x00006B72 File Offset: 0x00004D72
		public CreateAllianceMessage() : this(0)
		{
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0000328E File Offset: 0x0000148E
		public CreateAllianceMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00020AD4 File Offset: 0x0001ECD4
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.logicData_0 = ByteStreamHelper.ReadDataReference(this.m_stream);
			this.bool_0 = this.m_stream.ReadBoolean();
			this.bool_1 = this.m_stream.ReadBoolean();
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00020B9C File Offset: 0x0001ED9C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicData_0);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteBoolean(this.bool_1);
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00006B7B File Offset: 0x00004D7B
		public override short GetMessageType()
		{
			return 14301;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00006B82 File Offset: 0x00004D82
		public string GetAllianceName()
		{
			return this.string_0;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00006B8A File Offset: 0x00004D8A
		public void SetAllianceName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00006B93 File Offset: 0x00004D93
		public string GetAllianceDescription()
		{
			return this.string_1;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00006B9B File Offset: 0x00004D9B
		public void SetAllianceDescription(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00006BA4 File Offset: 0x00004DA4
		public int GetAllianceBadgeId()
		{
			return this.int_1;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00006BAC File Offset: 0x00004DAC
		public void SetAllianceBadgeId(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00006BB5 File Offset: 0x00004DB5
		public int GetAllianceType()
		{
			return this.int_0;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00006BBD File Offset: 0x00004DBD
		public void SetAllianceType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00006BC6 File Offset: 0x00004DC6
		public int GetRequiredScore()
		{
			return this.int_2;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00006BCE File Offset: 0x00004DCE
		public void SetRequiredScore(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00006BD7 File Offset: 0x00004DD7
		public int GetRequiredDuelScore()
		{
			return this.int_3;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00006BDF File Offset: 0x00004DDF
		public void SetRequiredDuelScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00006BE8 File Offset: 0x00004DE8
		public LogicData GetOriginData()
		{
			return this.logicData_0;
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00006BF0 File Offset: 0x00004DF0
		public void SetOriginData(LogicData data)
		{
			this.logicData_0 = data;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00006BF9 File Offset: 0x00004DF9
		public int GetWarFrequency()
		{
			return this.int_4;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00006C01 File Offset: 0x00004E01
		public bool GetArrangedWarEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00006C09 File Offset: 0x00004E09
		public void SetAmicalWarEnabled(bool enabled)
		{
			this.bool_1 = enabled;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00006C12 File Offset: 0x00004E12
		public bool GetPublicWarLog()
		{
			return this.bool_0;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00006C1A File Offset: 0x00004E1A
		public void SetPublicWarLog(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x0400032C RID: 812
		public const int MESSAGE_TYPE = 14301;

		// Token: 0x0400032D RID: 813
		private LogicData logicData_0;

		// Token: 0x0400032E RID: 814
		private string string_0;

		// Token: 0x0400032F RID: 815
		private string string_1;

		// Token: 0x04000330 RID: 816
		private int int_0;

		// Token: 0x04000331 RID: 817
		private int int_1;

		// Token: 0x04000332 RID: 818
		private int int_2;

		// Token: 0x04000333 RID: 819
		private int int_3;

		// Token: 0x04000334 RID: 820
		private int int_4;

		// Token: 0x04000335 RID: 821
		private bool bool_0;

		// Token: 0x04000336 RID: 822
		private bool bool_1;
	}
}
