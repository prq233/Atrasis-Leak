using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C6 RID: 198
	public class RespondToAllianceJoinRequestMessage : PiranhaMessage
	{
		// Token: 0x0600088E RID: 2190 RVA: 0x00006E52 File Offset: 0x00005052
		public RespondToAllianceJoinRequestMessage() : this(0)
		{
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0000328E File Offset: 0x0000148E
		public RespondToAllianceJoinRequestMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00006E5B File Offset: 0x0000505B
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.bool_0 = this.m_stream.ReadBoolean();
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00006E85 File Offset: 0x00005085
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00006EAF File Offset: 0x000050AF
		public override short GetMessageType()
		{
			return 14321;
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00006EB6 File Offset: 0x000050B6
		public LogicLong GetStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00006EBE File Offset: 0x000050BE
		public void SetStreamEntryId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00006EC7 File Offset: 0x000050C7
		public bool IsAccepted()
		{
			return this.bool_0;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00006ECF File Offset: 0x000050CF
		public void SetAccepted(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x04000346 RID: 838
		public const int MESSAGE_TYPE = 14321;

		// Token: 0x04000347 RID: 839
		private LogicLong logicLong_0;

		// Token: 0x04000348 RID: 840
		private bool bool_0;
	}
}
