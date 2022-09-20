using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000AB RID: 171
	public class AllianceHeaderEntry
	{
		// Token: 0x06000766 RID: 1894 RVA: 0x0000645D File Offset: 0x0000465D
		public AllianceHeaderEntry()
		{
			this.logicLong_0 = new LogicLong();
			this.int_11 = 1;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0001FCCC File Offset: 0x0001DECC
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.allianceType_0 = (AllianceType)stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.logicData_0 = ByteStreamHelper.ReadDataReference(stream);
			this.int_9 = stream.ReadInt();
			this.logicData_1 = ByteStreamHelper.ReadDataReference(stream);
			this.int_10 = stream.ReadInt();
			this.int_11 = stream.ReadInt();
			this.int_12 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			stream.ReadInt();
			this.bool_1 = stream.ReadBoolean();
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0001FDD8 File Offset: 0x0001DFD8
		public void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			stream.WriteString(this.string_0);
			stream.WriteInt(this.int_0);
			stream.WriteInt((int)this.allianceType_0);
			stream.WriteInt(this.int_1);
			stream.WriteInt(this.int_2);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.int_6);
			stream.WriteInt(this.int_7);
			stream.WriteInt(this.int_8);
			ByteStreamHelper.WriteDataReference(stream, this.logicData_0);
			stream.WriteInt(this.int_9);
			ByteStreamHelper.WriteDataReference(stream, this.logicData_1);
			stream.WriteInt(this.int_10);
			stream.WriteInt(this.int_11);
			stream.WriteInt(this.int_12);
			stream.WriteBoolean(this.bool_0);
			stream.WriteInt(0);
			stream.WriteBoolean(this.bool_1);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00006477 File Offset: 0x00004677
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0000647F File Offset: 0x0000467F
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00006488 File Offset: 0x00004688
		public string GetAllianceName()
		{
			return this.string_0;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00006490 File Offset: 0x00004690
		public void SetAllianceName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00006499 File Offset: 0x00004699
		public AllianceType GetAllianceType()
		{
			return this.allianceType_0;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x000064A1 File Offset: 0x000046A1
		public void SetAllianceType(AllianceType value)
		{
			this.allianceType_0 = value;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x000064AA File Offset: 0x000046AA
		public int GetRequiredScore()
		{
			return this.int_4;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x000064B2 File Offset: 0x000046B2
		public void SetRequiredScore(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x000064BB File Offset: 0x000046BB
		public int GetRequiredDuelScore()
		{
			return this.int_5;
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x000064C3 File Offset: 0x000046C3
		public void SetRequiredDuelScore(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x000064CC File Offset: 0x000046CC
		public LogicData GetOriginData()
		{
			return this.logicData_1;
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000064D4 File Offset: 0x000046D4
		public void SetOriginData(LogicData value)
		{
			this.logicData_1 = value;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000064DD File Offset: 0x000046DD
		public int GetNumberOfMembers()
		{
			return this.int_1;
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x000064E5 File Offset: 0x000046E5
		public void SetNumberOfMembers(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x000064EE File Offset: 0x000046EE
		public int GetAllianceBadgeId()
		{
			return this.int_0;
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x000064F6 File Offset: 0x000046F6
		public void SetAllianceBadgeId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x000064FF File Offset: 0x000046FF
		public int GetWarFrequency()
		{
			return this.int_9;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00006507 File Offset: 0x00004707
		public void SetWarFrequency(int value)
		{
			this.int_9 = value;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00006510 File Offset: 0x00004710
		public bool IsPublicWarLog()
		{
			return this.bool_0;
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00006518 File Offset: 0x00004718
		public void SetPublicWarLog(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00006521 File Offset: 0x00004721
		public bool IsAmicalWarEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00006529 File Offset: 0x00004729
		public void SetArrangedWarEnabled(bool enabled)
		{
			this.bool_1 = enabled;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00006532 File Offset: 0x00004732
		public int GetScore()
		{
			return this.int_2;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0000653A File Offset: 0x0000473A
		public void SetScore(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00006543 File Offset: 0x00004743
		public int GetDuelScore()
		{
			return this.int_3;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0000654B File Offset: 0x0000474B
		public void SetDuelScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00006554 File Offset: 0x00004754
		public int GetAllianceLevel()
		{
			return this.int_11;
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0000655C File Offset: 0x0000475C
		public void SetAllianceLevel(int value)
		{
			this.int_11 = value;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00006565 File Offset: 0x00004765
		public int GetAllianceExpPoints()
		{
			return this.int_10;
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0000656D File Offset: 0x0000476D
		public void SetAllianceExpPoints(int value)
		{
			this.int_10 = value;
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0001FEDC File Offset: 0x0001E0DC
		public void Load(LogicJSONObject jsonObject)
		{
			this.string_0 = jsonObject.GetJSONString("alliance_name").GetStringValue();
			this.int_0 = jsonObject.GetJSONNumber("badge_id").GetIntValue();
			this.allianceType_0 = (AllianceType)jsonObject.GetJSONNumber("type").GetIntValue();
			this.int_1 = jsonObject.GetJSONNumber("member_count").GetIntValue();
			this.int_2 = jsonObject.GetJSONNumber("score").GetIntValue();
			this.int_3 = jsonObject.GetJSONNumber("duel_score").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("required_score").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("required_duel_score").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("win_war_count").GetIntValue();
			this.int_7 = jsonObject.GetJSONNumber("lost_war_count").GetIntValue();
			this.int_8 = jsonObject.GetJSONNumber("draw_war_count").GetIntValue();
			this.int_9 = jsonObject.GetJSONNumber("war_freq").GetIntValue();
			this.int_11 = jsonObject.GetJSONNumber("xp_level").GetIntValue();
			this.int_10 = jsonObject.GetJSONNumber("xp_points").GetIntValue();
			this.int_12 = jsonObject.GetJSONNumber("cons_win_war_count").GetIntValue();
			this.bool_0 = jsonObject.GetJSONBoolean("public_war_log").IsTrue();
			this.bool_1 = jsonObject.GetJSONBoolean("amical_war_enabled").IsTrue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("locale");
			if (jsonnumber != null)
			{
				this.logicData_0 = LogicDataTables.GetDataById(jsonnumber.GetIntValue());
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("origin");
			if (jsonnumber2 != null)
			{
				this.logicData_1 = LogicDataTables.GetDataById(jsonnumber2.GetIntValue());
			}
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x000200A0 File Offset: 0x0001E2A0
		public void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("alliance_name", new LogicJSONString(this.string_0));
			jsonObject.Put("badge_id", new LogicJSONNumber(this.int_0));
			jsonObject.Put("type", new LogicJSONNumber((int)this.allianceType_0));
			jsonObject.Put("member_count", new LogicJSONNumber(this.int_1));
			jsonObject.Put("score", new LogicJSONNumber(this.int_2));
			jsonObject.Put("duel_score", new LogicJSONNumber(this.int_3));
			jsonObject.Put("required_score", new LogicJSONNumber(this.int_4));
			jsonObject.Put("required_duel_score", new LogicJSONNumber(this.int_5));
			jsonObject.Put("win_war_count", new LogicJSONNumber(this.int_6));
			jsonObject.Put("lost_war_count", new LogicJSONNumber(this.int_7));
			jsonObject.Put("draw_war_count", new LogicJSONNumber(this.int_8));
			jsonObject.Put("war_freq", new LogicJSONNumber(this.int_9));
			jsonObject.Put("xp_level", new LogicJSONNumber(this.int_11));
			jsonObject.Put("xp_points", new LogicJSONNumber(this.int_10));
			jsonObject.Put("cons_win_war_count", new LogicJSONNumber(this.int_12));
			jsonObject.Put("public_war_log", new LogicJSONBoolean(this.bool_0));
			jsonObject.Put("amical_war_enabled", new LogicJSONBoolean(this.bool_1));
			if (this.logicData_0 != null)
			{
				jsonObject.Put("locale", new LogicJSONNumber(this.logicData_0.GetGlobalID()));
			}
			if (this.logicData_1 != null)
			{
				jsonObject.Put("origin", new LogicJSONNumber(this.logicData_1.GetGlobalID()));
			}
		}

		// Token: 0x040002C8 RID: 712
		private LogicLong logicLong_0;

		// Token: 0x040002C9 RID: 713
		private LogicData logicData_0;

		// Token: 0x040002CA RID: 714
		private LogicData logicData_1;

		// Token: 0x040002CB RID: 715
		private string string_0;

		// Token: 0x040002CC RID: 716
		private int int_0;

		// Token: 0x040002CD RID: 717
		private AllianceType allianceType_0;

		// Token: 0x040002CE RID: 718
		private int int_1;

		// Token: 0x040002CF RID: 719
		private int int_2;

		// Token: 0x040002D0 RID: 720
		private int int_3;

		// Token: 0x040002D1 RID: 721
		private int int_4;

		// Token: 0x040002D2 RID: 722
		private int int_5;

		// Token: 0x040002D3 RID: 723
		private int int_6;

		// Token: 0x040002D4 RID: 724
		private int int_7;

		// Token: 0x040002D5 RID: 725
		private int int_8;

		// Token: 0x040002D6 RID: 726
		private int int_9;

		// Token: 0x040002D7 RID: 727
		private int int_10;

		// Token: 0x040002D8 RID: 728
		private int int_11;

		// Token: 0x040002D9 RID: 729
		private int int_12;

		// Token: 0x040002DA RID: 730
		private bool bool_0;

		// Token: 0x040002DB RID: 731
		private bool bool_1;
	}
}
