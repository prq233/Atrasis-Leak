using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Facebook
{
	// Token: 0x02000073 RID: 115
	public class FacebookAccountBoundMessage : PiranhaMessage
	{
		// Token: 0x0600050C RID: 1292 RVA: 0x00004F6A File Offset: 0x0000316A
		public FacebookAccountBoundMessage() : this(0)
		{
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000328E File Offset: 0x0000148E
		public FacebookAccountBoundMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00004F73 File Offset: 0x00003173
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00004F8C File Offset: 0x0000318C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00004FA5 File Offset: 0x000031A5
		public override short GetMessageType()
		{
			return 24201;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00004FAC File Offset: 0x000031AC
		public int GetResultCode()
		{
			return this.int_0;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00004FB4 File Offset: 0x000031B4
		public void SetResultCode(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001E8 RID: 488
		public const int MESSAGE_TYPE = 24201;

		// Token: 0x040001E9 RID: 489
		private int int_0;
	}
}
