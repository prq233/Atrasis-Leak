using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000EA RID: 234
	public class AccountDocument : CouchbaseDocument
	{
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00008C6B File Offset: 0x00006E6B
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x00008C73 File Offset: 0x00006E73
		public string PassToken { get; private set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00008C7C File Offset: 0x00006E7C
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x00008C84 File Offset: 0x00006E84
		public string Country { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x00008C8D File Offset: 0x00006E8D
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x00008C95 File Offset: 0x00006E95
		public string FacebookId { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x00008C9E File Offset: 0x00006E9E
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x00008CA6 File Offset: 0x00006EA6
		public string GamecenterId { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x00008CAF File Offset: 0x00006EAF
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x00008CB7 File Offset: 0x00006EB7
		public int CreateTime { get; private set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x00008CC0 File Offset: 0x00006EC0
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x00008CC8 File Offset: 0x00006EC8
		public int LastSessionTime { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00008CD1 File Offset: 0x00006ED1
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x00008CD9 File Offset: 0x00006ED9
		public int SessionCount { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00008CE2 File Offset: 0x00006EE2
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x00008CEA File Offset: 0x00006EEA
		public int PlayTimeSeconds { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00008CF3 File Offset: 0x00006EF3
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x00008CFB File Offset: 0x00006EFB
		public AccountState State { get; set; }

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00008D04 File Offset: 0x00006F04
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x00008D0C File Offset: 0x00006F0C
		public AccountRankingType Rank { get; set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00008D15 File Offset: 0x00006F15
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00008D1D File Offset: 0x00006F1D
		public string StateArg { get; set; }

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00008D26 File Offset: 0x00006F26
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x00008D2E File Offset: 0x00006F2E
		public string CreateIPAddress { get; set; }

		// Token: 0x060006E3 RID: 1763 RVA: 0x00008D37 File Offset: 0x00006F37
		public AccountDocument()
		{
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00008D3F File Offset: 0x00006F3F
		public AccountDocument(LogicLong id) : base(id)
		{
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x000158A0 File Offset: 0x00013AA0
		public void Init()
		{
			char[] array = new char[40];
			for (int i = 0; i < 40; i++)
			{
				array[i] = "abcdefghijklmnopqrstuvwxyz0123456789"[ServerCore.Random.Rand("abcdefghijklmnopqrstuvwxyz0123456789".Length)];
			}
			this.PassToken = new string(array);
			this.State = AccountState.NORMAL;
			this.Rank = AccountRankingType.NORMAL;
			this.CreateTime = TimeUtil.GetTimestamp();
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00015908 File Offset: 0x00013B08
		protected override void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("passToken", new LogicJSONString(this.PassToken));
			jsonObject.Put("state", new LogicJSONNumber((int)this.State));
			if (this.State != AccountState.NORMAL && this.StateArg != null)
			{
				jsonObject.Put("stateArg", new LogicJSONString(this.StateArg));
			}
			jsonObject.Put("rankingType", new LogicJSONNumber((int)this.Rank));
			jsonObject.Put("country", new LogicJSONString(this.Country));
			if (this.FacebookId != null)
			{
				jsonObject.Put("facebookId", new LogicJSONString(this.FacebookId));
			}
			if (this.GamecenterId != null)
			{
				jsonObject.Put("gamecenterId", new LogicJSONString(this.GamecenterId));
			}
			jsonObject.Put("createTime", new LogicJSONNumber(this.CreateTime));
			jsonObject.Put("lastSessionTime", new LogicJSONNumber(this.LastSessionTime));
			jsonObject.Put("sessionCount", new LogicJSONNumber(this.SessionCount));
			jsonObject.Put("playTimeSecs", new LogicJSONNumber(this.PlayTimeSeconds));
			jsonObject.Put("createIpAddr", new LogicJSONString(this.CreateIPAddress));
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00015A40 File Offset: 0x00013C40
		protected override void Load(LogicJSONObject jsonObject)
		{
			this.PassToken = jsonObject.GetJSONString("passToken").GetStringValue();
			this.State = (AccountState)jsonObject.GetJSONNumber("state").GetIntValue();
			if (this.State != AccountState.NORMAL)
			{
				LogicJSONString jsonstring = jsonObject.GetJSONString("stateArg");
				this.StateArg = ((jsonstring != null) ? jsonstring.GetStringValue() : null);
			}
			this.Rank = (AccountRankingType)jsonObject.GetJSONNumber("rankingType").GetIntValue();
			this.Country = jsonObject.GetJSONString("country").GetStringValue();
			LogicJSONString jsonstring2 = jsonObject.GetJSONString("facebookId");
			this.FacebookId = ((jsonstring2 != null) ? jsonstring2.GetStringValue() : null);
			LogicJSONString jsonstring3 = jsonObject.GetJSONString("gamecenterId");
			this.GamecenterId = ((jsonstring3 != null) ? jsonstring3.GetStringValue() : null);
			this.CreateTime = jsonObject.GetJSONNumber("createTime").GetIntValue();
			this.LastSessionTime = jsonObject.GetJSONNumber("lastSessionTime").GetIntValue();
			this.SessionCount = jsonObject.GetJSONNumber("sessionCount").GetIntValue();
			this.PlayTimeSeconds = jsonObject.GetJSONNumber("playTimeSecs").GetIntValue();
			LogicJSONString jsonstring4 = jsonObject.GetJSONString("createIpAddr");
			this.CreateIPAddress = ((jsonstring4 != null) ? jsonstring4.GetStringValue() : null);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00015B7C File Offset: 0x00013D7C
		protected override void Encode(ByteStream stream)
		{
			stream.WriteString(this.PassToken);
			stream.WriteVInt((int)this.State);
			stream.WriteVInt((int)this.Rank);
			stream.WriteString(this.Country);
			stream.WriteString(this.FacebookId);
			stream.WriteString(this.GamecenterId);
			stream.WriteVInt(this.CreateTime);
			stream.WriteVInt(this.LastSessionTime);
			stream.WriteVInt(this.SessionCount);
			stream.WriteVInt(this.PlayTimeSeconds);
			stream.WriteString(this.CreateIPAddress);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00015C10 File Offset: 0x00013E10
		protected override void Decode(ByteStream stream)
		{
			this.PassToken = stream.ReadString(900000);
			this.State = (AccountState)stream.ReadVInt();
			this.Rank = (AccountRankingType)stream.ReadVInt();
			this.Country = stream.ReadString(900000);
			this.FacebookId = stream.ReadString(900000);
			this.GamecenterId = stream.ReadString(900000);
			this.CreateTime = stream.ReadVInt();
			this.LastSessionTime = stream.ReadVInt();
			this.SessionCount = stream.ReadVInt();
			this.PlayTimeSeconds = stream.ReadVInt();
			this.CreateIPAddress = stream.ReadString(900000);
		}

		// Token: 0x040003C1 RID: 961
		private const string string_0 = "passToken";

		// Token: 0x040003C2 RID: 962
		private const string string_1 = "state";

		// Token: 0x040003C3 RID: 963
		private const string string_2 = "stateArg";

		// Token: 0x040003C4 RID: 964
		private const string string_3 = "rankingType";

		// Token: 0x040003C5 RID: 965
		private const string string_4 = "country";

		// Token: 0x040003C6 RID: 966
		private const string string_5 = "facebookId";

		// Token: 0x040003C7 RID: 967
		private const string string_6 = "gamecenterId";

		// Token: 0x040003C8 RID: 968
		private const string string_7 = "createTime";

		// Token: 0x040003C9 RID: 969
		private const string string_8 = "lastSessionTime";

		// Token: 0x040003CA RID: 970
		private const string string_9 = "sessionCount";

		// Token: 0x040003CB RID: 971
		private const string string_10 = "playTimeSecs";

		// Token: 0x040003CC RID: 972
		private const string string_11 = "createIpAddr";

		// Token: 0x040003CD RID: 973
		public const string CHARS = "abcdefghijklmnopqrstuvwxyz0123456789";

		// Token: 0x040003CE RID: 974
		public const int PASS_TOKEN_LENGTH = 40;

		// Token: 0x040003CF RID: 975
		[CompilerGenerated]
		private string string_12;

		// Token: 0x040003D0 RID: 976
		[CompilerGenerated]
		private string string_13;

		// Token: 0x040003D1 RID: 977
		[CompilerGenerated]
		private string string_14;

		// Token: 0x040003D2 RID: 978
		[CompilerGenerated]
		private string string_15;

		// Token: 0x040003D3 RID: 979
		[CompilerGenerated]
		private int int_0;

		// Token: 0x040003D4 RID: 980
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040003D5 RID: 981
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040003D6 RID: 982
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040003D7 RID: 983
		[CompilerGenerated]
		private AccountState accountState_0;

		// Token: 0x040003D8 RID: 984
		[CompilerGenerated]
		private AccountRankingType accountRankingType_0;

		// Token: 0x040003D9 RID: 985
		[CompilerGenerated]
		private string string_16;

		// Token: 0x040003DA RID: 986
		[CompilerGenerated]
		private string string_17;
	}
}
