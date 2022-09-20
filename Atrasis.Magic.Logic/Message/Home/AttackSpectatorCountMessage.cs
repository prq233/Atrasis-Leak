using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000044 RID: 68
	public class AttackSpectatorCountMessage : PiranhaMessage
	{
		// Token: 0x06000325 RID: 805 RVA: 0x00003EA7 File Offset: 0x000020A7
		public AttackSpectatorCountMessage() : this(0)
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000328E File Offset: 0x0000148E
		public AttackSpectatorCountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00003EB0 File Offset: 0x000020B0
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00003EDA File Offset: 0x000020DA
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00003F04 File Offset: 0x00002104
		public override short GetMessageType()
		{
			return 24125;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00003F0F File Offset: 0x0000210F
		public void SetViewerCount(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00003F18 File Offset: 0x00002118
		public int GetViewerCount()
		{
			return this.int_0;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00003F20 File Offset: 0x00002120
		public void SetEnemyViewerCount(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00003F29 File Offset: 0x00002129
		public int GetEnemyViewerCount()
		{
			return this.int_1;
		}

		// Token: 0x0400013E RID: 318
		public const int MESSAGE_TYPE = 24125;

		// Token: 0x0400013F RID: 319
		private int int_0;

		// Token: 0x04000140 RID: 320
		private int int_1;
	}
}
