using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000ED RID: 237
	public class AllianceDocument : CouchbaseDocument
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x00008D48 File Offset: 0x00006F48
		// (set) Token: 0x060006EB RID: 1771 RVA: 0x00008D50 File Offset: 0x00006F50
		public string Description { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x00008D59 File Offset: 0x00006F59
		public AllianceHeaderEntry Header { get; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x00008D61 File Offset: 0x00006F61
		public Dictionary<long, AllianceMemberEntry> Members { get; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x00008D69 File Offset: 0x00006F69
		public Dictionary<long, DateTime> KickedMembersTimes { get; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x00008D71 File Offset: 0x00006F71
		public LogicArrayList<LogicLong> StreamEntryList { get; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x00008D79 File Offset: 0x00006F79
		// (set) Token: 0x060006F1 RID: 1777 RVA: 0x00008D81 File Offset: 0x00006F81
		public DateTime DonationTime { get; set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x00008D8A File Offset: 0x00006F8A
		// (set) Token: 0x060006F3 RID: 1779 RVA: 0x00008D92 File Offset: 0x00006F92
		public DateTime CheckRankingTime { get; set; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00008D9B File Offset: 0x00006F9B
		// (set) Token: 0x060006F5 RID: 1781 RVA: 0x00008DA3 File Offset: 0x00006FA3
		public DateTime LastUpdateTime { get; set; }

		// Token: 0x060006F6 RID: 1782 RVA: 0x00008DAC File Offset: 0x00006FAC
		public AllianceDocument()
		{
			this.Description = string.Empty;
			this.Header = new AllianceHeaderEntry();
			this.Members = new Dictionary<long, AllianceMemberEntry>();
			this.KickedMembersTimes = new Dictionary<long, DateTime>();
			this.StreamEntryList = new LogicArrayList<LogicLong>();
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00015CBC File Offset: 0x00013EBC
		public AllianceDocument(LogicLong id) : base(id)
		{
			this.Description = string.Empty;
			this.Header = new AllianceHeaderEntry();
			this.Header.SetAllianceId(id);
			this.Members = new Dictionary<long, AllianceMemberEntry>();
			this.KickedMembersTimes = new Dictionary<long, DateTime>();
			this.StreamEntryList = new LogicArrayList<LogicLong>();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00008DEB File Offset: 0x00006FEB
		public bool IsFull()
		{
			return this.Header.GetNumberOfMembers() >= 50;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00007F27 File Offset: 0x00006127
		protected sealed override void Encode(ByteStream stream)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00007F27 File Offset: 0x00006127
		protected sealed override void Decode(ByteStream stream)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00015D14 File Offset: 0x00013F14
		protected sealed override void Save(LogicJSONObject jsonObject)
		{
			this.Header.Save(jsonObject);
			jsonObject.Put("description", new LogicJSONString(this.Description));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.Members.Count);
			foreach (AllianceMemberEntry allianceMemberEntry in this.Members.Values)
			{
				logicJSONArray.Add(allianceMemberEntry.Save());
			}
			jsonObject.Put("members", logicJSONArray);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(this.KickedMembersTimes.Count);
			foreach (KeyValuePair<long, DateTime> keyValuePair in this.KickedMembersTimes)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray3 = new LogicJSONArray(2);
				logicJSONArray3.Add(new LogicJSONNumber((int)(keyValuePair.Key >> 32)));
				logicJSONArray3.Add(new LogicJSONNumber((int)keyValuePair.Key));
				logicJSONObject.Put("id", logicJSONArray3);
				logicJSONObject.Put("t", new LogicJSONString(keyValuePair.Value.ToString("O")));
				logicJSONArray2.Add(logicJSONObject);
			}
			jsonObject.Put("kickedMembers", logicJSONArray2);
			LogicJSONArray logicJSONArray4 = new LogicJSONArray(this.StreamEntryList.Size());
			for (int i = 0; i < this.StreamEntryList.Size(); i++)
			{
				LogicLong logicLong = this.StreamEntryList[i];
				LogicJSONArray logicJSONArray5 = new LogicJSONArray(2);
				logicJSONArray5.Add(new LogicJSONNumber(logicLong.GetHigherInt()));
				logicJSONArray5.Add(new LogicJSONNumber(logicLong.GetLowerInt()));
				logicJSONArray4.Add(logicJSONArray5);
			}
			jsonObject.Put("streams", logicJSONArray4);
			jsonObject.Put("checkRankingT", new LogicJSONNumber(TimeUtil.GetTimestamp(this.CheckRankingTime)));
			jsonObject.Put("donationT", new LogicJSONNumber(TimeUtil.GetTimestamp(this.DonationTime)));
			jsonObject.Put("lastUpdateT", new LogicJSONNumber(TimeUtil.GetTimestamp(this.LastUpdateTime)));
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00015F54 File Offset: 0x00014154
		protected sealed override void Load(LogicJSONObject jsonObject)
		{
			this.Header.Load(jsonObject);
			this.Header.SetAllianceId(base.Id);
			this.Description = jsonObject.GetJSONString("description").GetStringValue();
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("members");
			for (int i = 0; i < jsonarray.Size(); i++)
			{
				AllianceMemberEntry allianceMemberEntry = new AllianceMemberEntry();
				allianceMemberEntry.Load(jsonarray.GetJSONObject(i));
				this.Members.Add(allianceMemberEntry.GetAvatarId(), allianceMemberEntry);
			}
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("kickedMembers");
			for (int j = 0; j < jsonarray2.Size(); j++)
			{
				LogicJSONObject jsonobject = jsonarray2.GetJSONObject(j);
				LogicJSONArray jsonarray3 = jsonobject.GetJSONArray("id");
				LogicLong @long = new LogicLong(jsonarray3.GetJSONNumber(0).GetIntValue(), jsonarray3.GetJSONNumber(1).GetIntValue());
				DateTime value = DateTime.Parse(jsonobject.GetJSONString("t").GetStringValue());
				this.KickedMembersTimes.Add(@long, value);
			}
			LogicJSONArray jsonarray4 = jsonObject.GetJSONArray("streams");
			for (int k = 0; k < jsonarray4.Size(); k++)
			{
				LogicJSONArray jsonarray5 = jsonarray4.GetJSONArray(k);
				LogicLong item = new LogicLong(jsonarray5.GetJSONNumber(0).GetIntValue(), jsonarray5.GetJSONNumber(1).GetIntValue());
				this.StreamEntryList.Add(item);
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("checkRankingT");
			if (jsonnumber != null)
			{
				this.CheckRankingTime = TimeUtil.GetDateTimeFromTimestamp(jsonnumber.GetIntValue());
				this.DonationTime = TimeUtil.GetDateTimeFromTimestamp(jsonObject.GetJSONNumber("donationT").GetIntValue());
				this.LastUpdateTime = TimeUtil.GetDateTimeFromTimestamp(jsonObject.GetJSONNumber("lastUpdateT").GetIntValue());
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			this.CheckRankingTime = utcNow.Date;
			this.DonationTime = new DateTime(utcNow.Year, utcNow.Month, 1);
			this.LastUpdateTime = utcNow;
		}

		// Token: 0x040003E3 RID: 995
		private const string string_0 = "description";

		// Token: 0x040003E4 RID: 996
		private const string string_1 = "members";

		// Token: 0x040003E5 RID: 997
		private const string string_2 = "kickedMembers";

		// Token: 0x040003E6 RID: 998
		private const string string_3 = "id";

		// Token: 0x040003E7 RID: 999
		private const string string_4 = "t";

		// Token: 0x040003E8 RID: 1000
		private const string string_5 = "streams";

		// Token: 0x040003E9 RID: 1001
		private const string string_6 = "donationT";

		// Token: 0x040003EA RID: 1002
		private const string string_7 = "checkRankingT";

		// Token: 0x040003EB RID: 1003
		private const string string_8 = "lastUpdateT";

		// Token: 0x040003EC RID: 1004
		[CompilerGenerated]
		private string string_9;

		// Token: 0x040003ED RID: 1005
		[CompilerGenerated]
		private readonly AllianceHeaderEntry allianceHeaderEntry_0;

		// Token: 0x040003EE RID: 1006
		[CompilerGenerated]
		private readonly Dictionary<long, AllianceMemberEntry> dictionary_0;

		// Token: 0x040003EF RID: 1007
		[CompilerGenerated]
		private readonly Dictionary<long, DateTime> dictionary_1;

		// Token: 0x040003F0 RID: 1008
		[CompilerGenerated]
		private readonly LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x040003F1 RID: 1009
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x040003F2 RID: 1010
		[CompilerGenerated]
		private DateTime dateTime_1;

		// Token: 0x040003F3 RID: 1011
		[CompilerGenerated]
		private DateTime dateTime_2;
	}
}
