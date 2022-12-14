using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000D1 RID: 209
	public class AllianceWarSearchDataMessage : PiranhaMessage
	{
		// Token: 0x06000918 RID: 2328 RVA: 0x000072C9 File Offset: 0x000054C9
		public AllianceWarSearchDataMessage() : this(0)
		{
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceWarSearchDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x000219C0 File Offset: 0x0001FBC0
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num >= 0)
			{
				this.logicArrayList_0 = new LogicArrayList<AllianceWarMemberEntry>();
				this.logicArrayList_0.EnsureCapacity(num);
				for (int i = 0; i < num; i++)
				{
					AllianceWarMemberEntry allianceWarMemberEntry = new AllianceWarMemberEntry();
					allianceWarMemberEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(allianceWarMemberEntry);
				}
			}
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00021A24 File Offset: 0x0001FC24
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Encode(this.m_stream);
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x000072D2 File Offset: 0x000054D2
		public override short GetMessageType()
		{
			return 24325;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0000713B File Offset: 0x0000533B
		public override int GetServiceNodeType()
		{
			return 25;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000072D9 File Offset: 0x000054D9
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x000072E8 File Offset: 0x000054E8
		public LogicArrayList<AllianceWarMemberEntry> GetWarMemberEntryList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x000072F0 File Offset: 0x000054F0
		public void SetWarMemberEntryList(LogicArrayList<AllianceWarMemberEntry> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x04000385 RID: 901
		public const int MESSAGE_TYPE = 24325;

		// Token: 0x04000386 RID: 902
		private LogicArrayList<AllianceWarMemberEntry> logicArrayList_0;
	}
}
