using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B7 RID: 183
	public class AllianceMemberMessage : PiranhaMessage
	{
		// Token: 0x060007E8 RID: 2024 RVA: 0x00006857 File Offset: 0x00004A57
		public AllianceMemberMessage() : this(0)
		{
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceMemberMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00006860 File Offset: 0x00004A60
		public override void Decode()
		{
			base.Decode();
			this.allianceMemberEntry_0 = new AllianceMemberEntry();
			this.allianceMemberEntry_0.Decode(this.m_stream);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00006884 File Offset: 0x00004A84
		public override void Encode()
		{
			base.Encode();
			this.allianceMemberEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0000689D File Offset: 0x00004A9D
		public override short GetMessageType()
		{
			return 24308;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x000068A4 File Offset: 0x00004AA4
		public override void Destruct()
		{
			base.Destruct();
			this.allianceMemberEntry_0 = null;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x000068B3 File Offset: 0x00004AB3
		public AllianceMemberEntry RemoveAllianceMemberEntry()
		{
			AllianceMemberEntry result = this.allianceMemberEntry_0;
			this.allianceMemberEntry_0 = null;
			return result;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000068C2 File Offset: 0x00004AC2
		public void SetAllianceMemberEntry(AllianceMemberEntry value)
		{
			this.allianceMemberEntry_0 = value;
		}

		// Token: 0x04000314 RID: 788
		public const int MESSAGE_TYPE = 24308;

		// Token: 0x04000315 RID: 789
		private AllianceMemberEntry allianceMemberEntry_0;
	}
}
