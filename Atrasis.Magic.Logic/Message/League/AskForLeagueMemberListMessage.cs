using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.League
{
	// Token: 0x0200003C RID: 60
	public class AskForLeagueMemberListMessage : PiranhaMessage
	{
		// Token: 0x060002CA RID: 714 RVA: 0x00003B09 File Offset: 0x00001D09
		public AskForLeagueMemberListMessage() : this(0)
		{
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForLeagueMemberListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00003B12 File Offset: 0x00001D12
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00003B38 File Offset: 0x00001D38
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

		// Token: 0x060002CE RID: 718 RVA: 0x00003B72 File Offset: 0x00001D72
		public override short GetMessageType()
		{
			return 14503;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00003B79 File Offset: 0x00001D79
		public override int GetServiceNodeType()
		{
			return 13;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00003B7D File Offset: 0x00001D7D
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00003B8C File Offset: 0x00001D8C
		public LogicLong GetLeagueInstanceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00003B94 File Offset: 0x00001D94
		public void SetLeagueInstanceId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x04000113 RID: 275
		public const int MESSAGE_TYPE = 14503;

		// Token: 0x04000114 RID: 276
		private LogicLong logicLong_0;
	}
}
