using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Battle
{
	// Token: 0x0200007A RID: 122
	public class AttackEventMessage : PiranhaMessage
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x0000519C File Offset: 0x0000339C
		public AttackEventMessage() : this(0)
		{
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0000328E File Offset: 0x0000148E
		public AttackEventMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000051A5 File Offset: 0x000033A5
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000051CF File Offset: 0x000033CF
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x000051F9 File Offset: 0x000033F9
		public override short GetMessageType()
		{
			return 25027;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00005200 File Offset: 0x00003400
		public int GetEventType()
		{
			return this.int_0;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00005208 File Offset: 0x00003408
		public void SetEventType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00005211 File Offset: 0x00003411
		public int GetEventArg()
		{
			return this.int_1;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00005219 File Offset: 0x00003419
		public void SetEventArg(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x04000200 RID: 512
		public const int MESSAGE_TYPE = 25027;

		// Token: 0x04000201 RID: 513
		private int int_0;

		// Token: 0x04000202 RID: 514
		private int int_1;
	}
}
