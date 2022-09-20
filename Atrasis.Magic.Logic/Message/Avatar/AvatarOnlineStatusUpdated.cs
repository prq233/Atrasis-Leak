using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000087 RID: 135
	public class AvatarOnlineStatusUpdated : PiranhaMessage
	{
		// Token: 0x060005C3 RID: 1475 RVA: 0x0000559D File Offset: 0x0000379D
		public AvatarOnlineStatusUpdated() : this(0)
		{
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarOnlineStatusUpdated(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x000055A6 File Offset: 0x000037A6
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.int_0 = this.m_stream.ReadVInt();
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x000055D0 File Offset: 0x000037D0
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteVInt(this.int_0);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000055FA File Offset: 0x000037FA
		public override short GetMessageType()
		{
			return 20206;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00005601 File Offset: 0x00003801
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00005610 File Offset: 0x00003810
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00005618 File Offset: 0x00003818
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00005621 File Offset: 0x00003821
		public int GetState()
		{
			return this.int_0;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00005629 File Offset: 0x00003829
		public void SetState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0400022C RID: 556
		public const int MESSAGE_TYPE = 20206;

		// Token: 0x0400022D RID: 557
		private LogicLong logicLong_0;

		// Token: 0x0400022E RID: 558
		private int int_0;
	}
}
