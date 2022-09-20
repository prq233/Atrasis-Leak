using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x0200009C RID: 156
	public class RemoveAvatarStreamEntryMessage : PiranhaMessage
	{
		// Token: 0x060006B1 RID: 1713 RVA: 0x00005DCF File Offset: 0x00003FCF
		public RemoveAvatarStreamEntryMessage() : this(0)
		{
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0000328E File Offset: 0x0000148E
		public RemoveAvatarStreamEntryMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00005DD8 File Offset: 0x00003FD8
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00005DF1 File Offset: 0x00003FF1
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00005E0A File Offset: 0x0000400A
		public override short GetMessageType()
		{
			return 14418;
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00005E11 File Offset: 0x00004011
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00005E20 File Offset: 0x00004020
		public LogicLong GetStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00005E28 File Offset: 0x00004028
		public void SetStreamEntryId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000281 RID: 641
		public const int MESSAGE_TYPE = 14418;

		// Token: 0x04000282 RID: 642
		private LogicLong logicLong_0;
	}
}
