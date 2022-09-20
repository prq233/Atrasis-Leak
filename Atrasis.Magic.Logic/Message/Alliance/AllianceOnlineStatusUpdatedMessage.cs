using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B9 RID: 185
	public class AllianceOnlineStatusUpdatedMessage : PiranhaMessage
	{
		// Token: 0x060007FA RID: 2042 RVA: 0x00006934 File Offset: 0x00004B34
		public AllianceOnlineStatusUpdatedMessage() : this(0)
		{
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceOnlineStatusUpdatedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0000693D File Offset: 0x00004B3D
		public override void Decode()
		{
			base.Decode();
			this.int_1 = this.m_stream.ReadVInt();
			this.int_0 = this.m_stream.ReadVInt();
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00006967 File Offset: 0x00004B67
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteVInt(this.int_1);
			this.m_stream.WriteVInt(this.int_0);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00006991 File Offset: 0x00004B91
		public override short GetMessageType()
		{
			return 20207;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00006998 File Offset: 0x00004B98
		public int GetMembersOnline()
		{
			return this.int_1;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x000069A0 File Offset: 0x00004BA0
		public void SetMembersOnline(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x000069A9 File Offset: 0x00004BA9
		public int GetMembersCount()
		{
			return this.int_0;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x000069B1 File Offset: 0x00004BB1
		public void SetMembersCount(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000318 RID: 792
		public const int MESSAGE_TYPE = 20207;

		// Token: 0x04000319 RID: 793
		private int int_0;

		// Token: 0x0400031A RID: 794
		private int int_1;
	}
}
