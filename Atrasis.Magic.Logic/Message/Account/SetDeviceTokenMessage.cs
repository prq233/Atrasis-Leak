using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F9 RID: 249
	public class SetDeviceTokenMessage : PiranhaMessage
	{
		// Token: 0x06000B67 RID: 2919 RVA: 0x00008637 File Offset: 0x00006837
		public SetDeviceTokenMessage() : this(0)
		{
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0000328E File Offset: 0x0000148E
		public SetDeviceTokenMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x00025AD8 File Offset: 0x00023CD8
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadBytesLength();
			if (this.int_0 > 1000)
			{
				Debugger.Error("Illegal byte array length encountered.");
			}
			this.byte_0 = this.m_stream.ReadBytes(this.int_0, 900000);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00008640 File Offset: 0x00006840
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBytes(this.byte_0, this.int_0);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0000865F File Offset: 0x0000685F
		public override short GetMessageType()
		{
			return 10113;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00008666 File Offset: 0x00006866
		public override void Destruct()
		{
			base.Destruct();
			this.byte_0 = null;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00008675 File Offset: 0x00006875
		public byte[] GetDeviceToken()
		{
			return this.byte_0;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0000867D File Offset: 0x0000687D
		public int GetDeviceTokenLength()
		{
			return this.int_0;
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x00008685 File Offset: 0x00006885
		public void SetDeviceToken(byte[] value, int length)
		{
			this.byte_0 = value;
			this.int_0 = length;
		}

		// Token: 0x0400047C RID: 1148
		public const int MESSAGE_TYPE = 10113;

		// Token: 0x0400047D RID: 1149
		private byte[] byte_0;

		// Token: 0x0400047E RID: 1150
		private int int_0;
	}
}
