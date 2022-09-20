using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EB RID: 235
	public class AppleBillingRequestMessage : PiranhaMessage
	{
		// Token: 0x06000A94 RID: 2708 RVA: 0x00007FE8 File Offset: 0x000061E8
		public AppleBillingRequestMessage() : this(0)
		{
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0000328E File Offset: 0x0000148E
		public AppleBillingRequestMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00024B54 File Offset: 0x00022D54
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.string_2 = this.m_stream.ReadString(900000);
			this.string_3 = this.m_stream.ReadString(900000);
			int num = this.m_stream.ReadBytesLength();
			if (num > 300000)
			{
				Debugger.Error("Illegal byte array length encountered.");
			}
			this.byte_0 = this.m_stream.ReadBytes(num, 900000);
			this.m_stream.ReadVInt();
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00024C00 File Offset: 0x00022E00
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteString(this.string_2);
			this.m_stream.WriteString(this.string_3);
			this.m_stream.WriteBytes(this.byte_0, this.byte_0.Length);
			this.m_stream.WriteVInt(0);
			this.m_stream.WriteInt(0);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00007FF1 File Offset: 0x000061F1
		public override short GetMessageType()
		{
			return 10150;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00007FF8 File Offset: 0x000061F8
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.byte_0 = null;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00008023 File Offset: 0x00006223
		public string GetTID()
		{
			return this.string_0;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0000802B File Offset: 0x0000622B
		public void SetTID(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00008034 File Offset: 0x00006234
		public string GetProdID()
		{
			return this.string_1;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0000803C File Offset: 0x0000623C
		public void SetProdID(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00008045 File Offset: 0x00006245
		public string GetCurrencyCode()
		{
			return this.string_2;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0000804D File Offset: 0x0000624D
		public void SetCurrencyCode(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00008056 File Offset: 0x00006256
		public byte[] GetReceiptData()
		{
			return this.byte_0;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00024C88 File Offset: 0x00022E88
		public void SetReceiptData(byte[] data, int length)
		{
			this.byte_0 = null;
			if (length > -1)
			{
				this.byte_0 = new byte[length];
				for (int i = 0; i < length; i++)
				{
					this.byte_0[i] = data[i];
				}
			}
		}

		// Token: 0x04000423 RID: 1059
		public const int MESSAGE_TYPE = 10150;

		// Token: 0x04000424 RID: 1060
		private string string_0;

		// Token: 0x04000425 RID: 1061
		private string string_1;

		// Token: 0x04000426 RID: 1062
		private string string_2;

		// Token: 0x04000427 RID: 1063
		private string string_3;

		// Token: 0x04000428 RID: 1064
		private byte[] byte_0;
	}
}
