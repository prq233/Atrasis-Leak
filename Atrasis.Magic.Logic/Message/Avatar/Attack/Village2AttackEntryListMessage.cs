using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x020000A1 RID: 161
	public class Village2AttackEntryListMessage : PiranhaMessage
	{
		// Token: 0x060006E9 RID: 1769 RVA: 0x00005FFA File Offset: 0x000041FA
		public Village2AttackEntryListMessage() : this(0)
		{
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0000328E File Offset: 0x0000148E
		public Village2AttackEntryListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001F234 File Offset: 0x0001D434
		public override void Decode()
		{
			base.Decode();
			this.bool_0 = this.m_stream.ReadBoolean();
			int num = this.m_stream.ReadInt();
			if (num != -1)
			{
				this.logicArrayList_0 = new LogicArrayList<Village2AttackEntry>(num);
				for (int i = 0; i < num; i++)
				{
					Village2AttackEntry village2AttackEntry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)this.m_stream.ReadInt());
					village2AttackEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(village2AttackEntry);
				}
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0001F2AC File Offset: 0x0001D4AC
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBoolean(this.bool_0);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteInt((int)this.logicArrayList_0[i].GetAttackEntryType());
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00006003 File Offset: 0x00004203
		public override short GetMessageType()
		{
			return 24370;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0000600A File Offset: 0x0000420A
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00006019 File Offset: 0x00004219
		public LogicArrayList<Village2AttackEntry> RemoveStreamEntries()
		{
			LogicArrayList<Village2AttackEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00006028 File Offset: 0x00004228
		public void SetStreamEntries(LogicArrayList<Village2AttackEntry> entry)
		{
			this.logicArrayList_0 = entry;
		}

		// Token: 0x04000297 RID: 663
		public const int MESSAGE_TYPE = 24370;

		// Token: 0x04000298 RID: 664
		private bool bool_0;

		// Token: 0x04000299 RID: 665
		private LogicArrayList<Village2AttackEntry> logicArrayList_0;
	}
}
