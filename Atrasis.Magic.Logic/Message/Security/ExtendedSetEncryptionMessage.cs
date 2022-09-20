﻿using System;
using Atrasis.Magic.Titan.Message.Security;

namespace Atrasis.Magic.Logic.Message.Security
{
	// Token: 0x0200002A RID: 42
	public class ExtendedSetEncryptionMessage : SetEncryptionMessage
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x00003228 File Offset: 0x00001428
		public ExtendedSetEncryptionMessage() : this(0)
		{
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00003231 File Offset: 0x00001431
		public ExtendedSetEncryptionMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000323A File Offset: 0x0000143A
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00003253 File Offset: 0x00001453
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000326C File Offset: 0x0000146C
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00003274 File Offset: 0x00001474
		public int GetNonceMethod()
		{
			return this.int_0;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000327C File Offset: 0x0000147C
		public void SetNonceMethod(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000A5 RID: 165
		public const string INTEGRATION_NONCE = "77035c098d0a04753b77167c7133cdd4b7052813ed47c461";

		// Token: 0x040000A6 RID: 166
		public const string STAGE_NONCE = "4c444a4b4c396876736b6c3b6473766b666c73676a90fbef";

		// Token: 0x040000A7 RID: 167
		public const string DEFAULT_NONCE = "nonce";

		// Token: 0x040000A8 RID: 168
		private int int_0;
	}
}
