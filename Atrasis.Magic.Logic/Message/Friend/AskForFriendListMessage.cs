using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006B RID: 107
	public class AskForFriendListMessage : PiranhaMessage
	{
		// Token: 0x060004AC RID: 1196 RVA: 0x00004C1C File Offset: 0x00002E1C
		public AskForFriendListMessage() : this(0)
		{
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForFriendListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00004C25 File Offset: 0x00002E25
		public override short GetMessageType()
		{
			return 10504;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001C9 RID: 457
		public const int MESSAGE_TYPE = 10504;
	}
}
