using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F1 RID: 241
	public class SeasonDocument : CouchbaseDocument
	{
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x00008F86 File Offset: 0x00007186
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x00008F8E File Offset: 0x0000718E
		public LogicArrayList<AllianceRankingEntry>[] AllianceRankingList { get; private set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00008F97 File Offset: 0x00007197
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x00008F9F File Offset: 0x0000719F
		public LogicArrayList<AvatarRankingEntry> AvatarRankingList { get; private set; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00008FA8 File Offset: 0x000071A8
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x00008FB0 File Offset: 0x000071B0
		public LogicArrayList<AvatarDuelRankingEntry> AvatarDuelRankingList { get; private set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00008FB9 File Offset: 0x000071B9
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x00008FC1 File Offset: 0x000071C1
		public DateTime NextCheckTime { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x00008FCA File Offset: 0x000071CA
		public int Year
		{
			get
			{
				return base.Id.GetHigherInt();
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00008FD7 File Offset: 0x000071D7
		public int Month
		{
			get
			{
				return base.Id.GetLowerInt();
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00008FE4 File Offset: 0x000071E4
		public DateTime EndTime
		{
			get
			{
				return new DateTime(this.Year, this.Month, 1, 0, 0, 0);
			}
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00016B74 File Offset: 0x00014D74
		public SeasonDocument()
		{
			this.AllianceRankingList = new LogicArrayList<AllianceRankingEntry>[2];
			this.AllianceRankingList[0] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AllianceRankingList[1] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AvatarRankingList = new LogicArrayList<AvatarRankingEntry>(1000);
			this.AvatarDuelRankingList = new LogicArrayList<AvatarDuelRankingEntry>(1000);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00016BD8 File Offset: 0x00014DD8
		public SeasonDocument(LogicLong id) : base(id)
		{
			this.AllianceRankingList = new LogicArrayList<AllianceRankingEntry>[2];
			this.AllianceRankingList[0] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AllianceRankingList[1] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AvatarRankingList = new LogicArrayList<AvatarRankingEntry>(1000);
			this.AvatarDuelRankingList = new LogicArrayList<AvatarDuelRankingEntry>(1000);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00016C3C File Offset: 0x00014E3C
		protected sealed override void Encode(ByteStream stream)
		{
			for (int i = 0; i < 2; i++)
			{
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				stream.WriteVInt(logicArrayList.Size());
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					logicArrayList[j].Encode(stream);
				}
			}
			stream.WriteVInt(this.AvatarRankingList.Size());
			for (int k = 0; k < this.AvatarRankingList.Size(); k++)
			{
				this.AvatarRankingList[k].Encode(stream);
			}
			stream.WriteVInt(this.AvatarDuelRankingList.Size());
			for (int l = 0; l < this.AvatarDuelRankingList.Size(); l++)
			{
				this.AvatarDuelRankingList[l].Encode(stream);
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00016D00 File Offset: 0x00014F00
		protected sealed override void Decode(ByteStream stream)
		{
			for (int i = 0; i < 2; i++)
			{
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				for (int j = stream.ReadVInt(); j > 0; j--)
				{
					AllianceRankingEntry allianceRankingEntry = new AllianceRankingEntry();
					allianceRankingEntry.Decode(stream);
					logicArrayList.Add(allianceRankingEntry);
				}
			}
			for (int k = stream.ReadVInt(); k > 0; k--)
			{
				AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
				avatarRankingEntry.Decode(stream);
				this.AvatarRankingList.Add(avatarRankingEntry);
			}
			for (int l = stream.ReadVInt(); l > 0; l--)
			{
				AvatarDuelRankingEntry avatarDuelRankingEntry = new AvatarDuelRankingEntry();
				avatarDuelRankingEntry.Decode(stream);
				this.AvatarDuelRankingList.Add(avatarDuelRankingEntry);
			}
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00016DAC File Offset: 0x00014FAC
		protected sealed override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(1000);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray(1000);
			for (int i = 0; i < 2; i++)
			{
				LogicJSONArray logicJSONArray4 = new LogicJSONArray(1000);
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					logicJSONArray4.Add(logicArrayList[j].Save());
				}
				logicJSONArray.Add(logicJSONArray4);
			}
			for (int k = 0; k < this.AvatarRankingList.Size(); k++)
			{
				logicJSONArray2.Add(this.AvatarRankingList[k].Save());
			}
			for (int l = 0; l < this.AvatarDuelRankingList.Size(); l++)
			{
				logicJSONArray3.Add(this.AvatarDuelRankingList[l].Save());
			}
			jsonObject.Put("allianceRankings", logicJSONArray);
			jsonObject.Put("avatarRankings", logicJSONArray2);
			jsonObject.Put("avatarDuelRankings", logicJSONArray3);
			jsonObject.Put("nextCheckTime", new LogicJSONString(this.NextCheckTime.ToString("O")));
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00016ED8 File Offset: 0x000150D8
		protected sealed override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("allianceRankings");
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("avatarRankings");
			LogicJSONArray jsonarray3 = jsonObject.GetJSONArray("avatarDuelRankings");
			for (int i = 0; i < 2; i++)
			{
				LogicJSONArray jsonarray4 = jsonarray.GetJSONArray(i);
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				for (int j = 0; j < jsonarray4.Size(); j++)
				{
					AllianceRankingEntry allianceRankingEntry = new AllianceRankingEntry();
					allianceRankingEntry.Load(jsonarray4.GetJSONObject(j));
					logicArrayList.Add(allianceRankingEntry);
				}
			}
			for (int k = 0; k < jsonarray2.Size(); k++)
			{
				AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
				avatarRankingEntry.Load(jsonarray2.GetJSONObject(k));
				this.AvatarRankingList.Add(avatarRankingEntry);
			}
			for (int l = 0; l < jsonarray3.Size(); l++)
			{
				AvatarDuelRankingEntry avatarDuelRankingEntry = new AvatarDuelRankingEntry();
				avatarDuelRankingEntry.Load(jsonarray3.GetJSONObject(l));
				this.AvatarDuelRankingList.Add(avatarDuelRankingEntry);
			}
			this.NextCheckTime = DateTime.Parse(jsonObject.GetJSONString("nextCheckTime").GetStringValue());
		}

		// Token: 0x0400040F RID: 1039
		private const string string_0 = "allianceRankings";

		// Token: 0x04000410 RID: 1040
		private const string string_1 = "avatarRankings";

		// Token: 0x04000411 RID: 1041
		private const string string_2 = "avatarDuelRankings";

		// Token: 0x04000412 RID: 1042
		private const string string_3 = "nextCheckTime";

		// Token: 0x04000413 RID: 1043
		protected const int RANKING_LIST_SIZE = 1000;

		// Token: 0x04000414 RID: 1044
		[CompilerGenerated]
		private LogicArrayList<AllianceRankingEntry>[] logicArrayList_0;

		// Token: 0x04000415 RID: 1045
		[CompilerGenerated]
		private LogicArrayList<AvatarRankingEntry> logicArrayList_1;

		// Token: 0x04000416 RID: 1046
		[CompilerGenerated]
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_2;

		// Token: 0x04000417 RID: 1047
		[CompilerGenerated]
		private DateTime dateTime_0;
	}
}
