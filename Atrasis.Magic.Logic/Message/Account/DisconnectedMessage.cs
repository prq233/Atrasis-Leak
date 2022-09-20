using System;
using Atrasis.Magic.Titan.Message.Account;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000ED RID: 237
	public class DisconnectedMessage : TitanDisconnectedMessage
	{
		// Token: 0x06000AAA RID: 2730 RVA: 0x00008078 File Offset: 0x00006278
		public DisconnectedMessage() : this(0)
		{
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00008081 File Offset: 0x00006281
		public DisconnectedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0000808A File Offset: 0x0000628A
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00008092 File Offset: 0x00006292
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0000809A File Offset: 0x0000629A
		public override void Destruct()
		{
			base.Destruct();
		}
	}
}
