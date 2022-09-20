using System;
using Atrasis.Magic.Logic.Message.Alliance.War.Event;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000CC RID: 204
	public class AllianceWarFullEntryMessage : PiranhaMessage
	{
		// Token: 0x060008E0 RID: 2272 RVA: 0x0000712B File Offset: 0x0000532B
		public AllianceWarFullEntryMessage() : this(0)
		{
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceWarFullEntryMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00021210 File Offset: 0x0001F410
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.allianceWarEntry_0 = new AllianceWarEntry();
			this.allianceWarEntry_0.Decode(this.m_stream);
			if (this.m_stream.ReadBoolean())
			{
				this.allianceWarEntry_1 = new AllianceWarEntry();
				this.allianceWarEntry_1.Decode(this.m_stream);
			}
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.m_stream.ReadInt();
			int num = this.m_stream.ReadInt();
			if (num >= 0)
			{
				this.logicArrayList_0 = new LogicArrayList<WarEventEntry>(num);
				for (int i = num - 1; i >= 0; i--)
				{
					WarEventEntry warEventEntry = WarEventEntryFactory.CreateWarEventEntryByType(this.m_stream.ReadInt());
					warEventEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(warEventEntry);
				}
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00021308 File Offset: 0x0001F508
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.allianceWarEntry_0.Encode(this.m_stream);
			if (this.allianceWarEntry_1 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.allianceWarEntry_1.Encode(this.m_stream);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.m_stream.WriteInt(1);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteInt(this.logicArrayList_0[i].GetWarEventEntryType());
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00007134 File Offset: 0x00005334
		public override short GetMessageType()
		{
			return 24335;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0000713B File Offset: 0x0000533B
		public override int GetServiceNodeType()
		{
			return 25;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0000713F File Offset: 0x0000533F
		public int GetWarState()
		{
			return this.int_0;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00007147 File Offset: 0x00005347
		public void SetWarState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00007150 File Offset: 0x00005350
		public int GetWarStateRemainingSeconds()
		{
			return this.int_1;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00007158 File Offset: 0x00005358
		public void SetWarStateRemainingSeconds(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00007161 File Offset: 0x00005361
		public LogicLong GetWarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00007169 File Offset: 0x00005369
		public void SetWarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00007172 File Offset: 0x00005372
		public AllianceWarEntry GetOwnAllianceWarEntry()
		{
			return this.allianceWarEntry_0;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0000717A File Offset: 0x0000537A
		public void SetOwnAllianceWarEntry(AllianceWarEntry value)
		{
			this.allianceWarEntry_0 = value;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00007183 File Offset: 0x00005383
		public AllianceWarEntry GetEnemyAllianceWarEntry()
		{
			return this.allianceWarEntry_1;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0000718B File Offset: 0x0000538B
		public void SetEnemyAllianceWarEntry(AllianceWarEntry value)
		{
			this.allianceWarEntry_1 = value;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00007194 File Offset: 0x00005394
		public LogicArrayList<WarEventEntry> GetWarEventEntryList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0000719C File Offset: 0x0000539C
		public void SetWarEventEntryList(LogicArrayList<WarEventEntry> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x04000365 RID: 869
		public const int MESSAGE_TYPE = 24335;

		// Token: 0x04000366 RID: 870
		private int int_0;

		// Token: 0x04000367 RID: 871
		private int int_1;

		// Token: 0x04000368 RID: 872
		private LogicLong logicLong_0;

		// Token: 0x04000369 RID: 873
		private AllianceWarEntry allianceWarEntry_0;

		// Token: 0x0400036A RID: 874
		private AllianceWarEntry allianceWarEntry_1;

		// Token: 0x0400036B RID: 875
		private LogicArrayList<WarEventEntry> logicArrayList_0;
	}
}
