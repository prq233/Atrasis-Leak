using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000AF RID: 175
	public class AllianceInvitationSentOkMessage : PiranhaMessage
	{
		// Token: 0x06000792 RID: 1938 RVA: 0x000065C9 File Offset: 0x000047C9
		public AllianceInvitationSentOkMessage() : this(0)
		{
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceInvitationSentOkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x000065D2 File Offset: 0x000047D2
		public override short GetMessageType()
		{
			return 24322;
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040002EA RID: 746
		public const int MESSAGE_TYPE = 24322;
	}
}
