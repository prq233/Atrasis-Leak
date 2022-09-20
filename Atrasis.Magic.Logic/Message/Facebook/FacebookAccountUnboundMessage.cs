using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Facebook
{
	// Token: 0x02000074 RID: 116
	public class FacebookAccountUnboundMessage : PiranhaMessage
	{
		// Token: 0x06000515 RID: 1301 RVA: 0x00004FBD File Offset: 0x000031BD
		public FacebookAccountUnboundMessage() : this(0)
		{
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000328E File Offset: 0x0000148E
		public FacebookAccountUnboundMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00004FC6 File Offset: 0x000031C6
		public override short GetMessageType()
		{
			return 24214;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001EA RID: 490
		public const int MESSAGE_TYPE = 24214;
	}
}
