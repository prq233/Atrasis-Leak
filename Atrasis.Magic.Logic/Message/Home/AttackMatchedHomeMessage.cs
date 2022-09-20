using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000042 RID: 66
	public class AttackMatchedHomeMessage : PiranhaMessage
	{
		// Token: 0x06000315 RID: 789 RVA: 0x00003E1E File Offset: 0x0000201E
		public AttackMatchedHomeMessage() : this(0)
		{
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000328E File Offset: 0x0000148E
		public AttackMatchedHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00003E37 File Offset: 0x00002037
		public override short GetMessageType()
		{
			return 14123;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400013B RID: 315
		public const int MESSAGE_TYPE = 14123;
	}
}
