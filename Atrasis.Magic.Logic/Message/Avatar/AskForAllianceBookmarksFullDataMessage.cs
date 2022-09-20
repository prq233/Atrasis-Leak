using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200007F RID: 127
	public class AskForAllianceBookmarksFullDataMessage : PiranhaMessage
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x0000535E File Offset: 0x0000355E
		public AskForAllianceBookmarksFullDataMessage() : this(0)
		{
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForAllianceBookmarksFullDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00005367 File Offset: 0x00003567
		public override short GetMessageType()
		{
			return 14341;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000210 RID: 528
		public const int MESSAGE_TYPE = 14341;
	}
}
