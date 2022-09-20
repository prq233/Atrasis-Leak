using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000A8 RID: 168
	public class AllianceDataMessage : PiranhaMessage
	{
		// Token: 0x06000748 RID: 1864 RVA: 0x00006364 File Offset: 0x00004564
		public AllianceDataMessage() : this(0)
		{
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0000636D File Offset: 0x0000456D
		public override void Decode()
		{
			base.Decode();
			this.allianceFullEntry_0 = new AllianceFullEntry();
			this.allianceFullEntry_0.Decode(this.m_stream);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00006391 File Offset: 0x00004591
		public override void Encode()
		{
			base.Encode();
			this.allianceFullEntry_0.Encode(this.m_stream);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x000063AA File Offset: 0x000045AA
		public override short GetMessageType()
		{
			return 24301;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000063B1 File Offset: 0x000045B1
		public override void Destruct()
		{
			base.Destruct();
			this.allianceFullEntry_0 = null;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000063C0 File Offset: 0x000045C0
		public AllianceFullEntry RemoveAllianceFullEntry()
		{
			AllianceFullEntry result = this.allianceFullEntry_0;
			this.allianceFullEntry_0 = null;
			return result;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000063CF File Offset: 0x000045CF
		public void SetAllianceFullEntry(AllianceFullEntry entry)
		{
			this.allianceFullEntry_0 = entry;
		}

		// Token: 0x040002BE RID: 702
		public const int MESSAGE_TYPE = 24301;

		// Token: 0x040002BF RID: 703
		private AllianceFullEntry allianceFullEntry_0;
	}
}
