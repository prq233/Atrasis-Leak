using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BD RID: 189
	public class ChangeAllianceMemberRoleMessage : PiranhaMessage
	{
		// Token: 0x0600081B RID: 2075 RVA: 0x00006A38 File Offset: 0x00004C38
		public ChangeAllianceMemberRoleMessage() : this(0)
		{
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0000328E File Offset: 0x0000148E
		public ChangeAllianceMemberRoleMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00006A41 File Offset: 0x00004C41
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)this.m_stream.ReadInt();
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00006A6B File Offset: 0x00004C6B
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteInt((int)this.logicAvatarAllianceRole_0);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00006A95 File Offset: 0x00004C95
		public override short GetMessageType()
		{
			return 14306;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00006A9C File Offset: 0x00004C9C
		public LogicLong RemoveMemberId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x00006AAB File Offset: 0x00004CAB
		public LogicAvatarAllianceRole GetMemberRole()
		{
			return this.logicAvatarAllianceRole_0;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x00006AB3 File Offset: 0x00004CB3
		public void SetAllianceData(LogicLong memberId, LogicAvatarAllianceRole memberRole)
		{
			this.logicLong_0 = memberId;
			this.logicAvatarAllianceRole_0 = memberRole;
		}

		// Token: 0x0400031F RID: 799
		public const int MESSAGE_TYPE = 14306;

		// Token: 0x04000320 RID: 800
		private LogicLong logicLong_0;

		// Token: 0x04000321 RID: 801
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;
	}
}
