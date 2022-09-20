using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000030 RID: 48
	public class AskForAvatarLastSeasonRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000214 RID: 532 RVA: 0x000034F9 File Offset: 0x000016F9
		public AskForAvatarLastSeasonRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForAvatarLastSeasonRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00003502 File Offset: 0x00001702
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00003528 File Offset: 0x00001728
		public override void Encode()
		{
			base.Encode();
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00003562 File Offset: 0x00001762
		public override short GetMessageType()
		{
			return 14406;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00003569 File Offset: 0x00001769
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00003578 File Offset: 0x00001778
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00003587 File Offset: 0x00001787
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x040000BF RID: 191
		public const int MESSAGE_TYPE = 14406;

		// Token: 0x040000C0 RID: 192
		private LogicLong logicLong_0;
	}
}
