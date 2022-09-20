using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004E RID: 78
	public class HomeBattleReplayDataMessage : PiranhaMessage
	{
		// Token: 0x06000397 RID: 919 RVA: 0x0000426D File Offset: 0x0000246D
		public HomeBattleReplayDataMessage() : this(0)
		{
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000328E File Offset: 0x0000148E
		public HomeBattleReplayDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00004276 File Offset: 0x00002476
		public override void Decode()
		{
			base.Decode();
			this.byte_0 = this.m_stream.ReadBytes(this.m_stream.ReadBytesLength(), 900000);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000429F File Offset: 0x0000249F
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBytes(this.byte_0, this.byte_0.Length);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000042C0 File Offset: 0x000024C0
		public byte[] RemoveReplayData()
		{
			byte[] result = this.byte_0;
			this.byte_0 = null;
			return result;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x000042CF File Offset: 0x000024CF
		public void SetReplayData(byte[] data)
		{
			this.byte_0 = data;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000042D8 File Offset: 0x000024D8
		public override short GetMessageType()
		{
			return 24114;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000167 RID: 359
		public const int MESSAGE_TYPE = 24114;

		// Token: 0x04000168 RID: 360
		private byte[] byte_0;
	}
}
