using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B6 RID: 182
	public class AllianceMemberEntry
	{
		// Token: 0x060007BE RID: 1982 RVA: 0x00020408 File Offset: 0x0001E608
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)stream.ReadInt();
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.int_9 = stream.ReadInt();
			this.int_10 = stream.ReadInt();
			this.int_11 = stream.ReadInt();
			this.int_12 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_1 = stream.ReadLong();
			}
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000204F0 File Offset: 0x0001E6F0
		public void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			stream.WriteString(this.string_0);
			stream.WriteInt((int)this.logicAvatarAllianceRole_0);
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_1);
			stream.WriteInt(this.int_2);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.int_6);
			stream.WriteInt(this.int_7);
			stream.WriteInt(this.int_8);
			stream.WriteInt(this.int_9);
			stream.WriteInt(this.int_10);
			stream.WriteInt(this.int_11);
			stream.WriteInt(this.int_12);
			if (this.logicLong_1 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_1);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x000066F5 File Offset: 0x000048F5
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x000066FD File Offset: 0x000048FD
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00006706 File Offset: 0x00004906
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0000670E File Offset: 0x0000490E
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00006717 File Offset: 0x00004917
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0000671F File Offset: 0x0000491F
		public void SetName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00006728 File Offset: 0x00004928
		public LogicAvatarAllianceRole GetAllianceRole()
		{
			return this.logicAvatarAllianceRole_0;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00006730 File Offset: 0x00004930
		public void SetAllianceRole(LogicAvatarAllianceRole value)
		{
			this.logicAvatarAllianceRole_0 = value;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x00006739 File Offset: 0x00004939
		public int GetExpLevel()
		{
			return this.int_0;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00006741 File Offset: 0x00004941
		public void SetExpLevel(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0000674A File Offset: 0x0000494A
		public int GetLeagueType()
		{
			return this.int_1;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00006752 File Offset: 0x00004952
		public void SetLeagueType(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0000675B File Offset: 0x0000495B
		public int GetScore()
		{
			return this.int_2;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00006763 File Offset: 0x00004963
		public void SetScore(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0000676C File Offset: 0x0000496C
		public int GetDuelScore()
		{
			return this.int_3;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00006774 File Offset: 0x00004974
		public void SetDuelScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0000677D File Offset: 0x0000497D
		public int GetDonations()
		{
			return this.int_4;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00006785 File Offset: 0x00004985
		public void SetDonations(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0000678E File Offset: 0x0000498E
		public int GetReceivedDonations()
		{
			return this.int_5;
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00006796 File Offset: 0x00004996
		public void SetReceivedDonations(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0000679F File Offset: 0x0000499F
		public int GetOrder()
		{
			return this.int_6;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000067A7 File Offset: 0x000049A7
		public void SetOrder(int order)
		{
			this.int_6 = order;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000067B0 File Offset: 0x000049B0
		public int GetPreviousOrder()
		{
			return this.int_7;
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x000067B8 File Offset: 0x000049B8
		public void SetPreviousOrder(int order)
		{
			this.int_7 = order;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x000067C1 File Offset: 0x000049C1
		public int GetOrderVillage2()
		{
			return this.int_8;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x000067C9 File Offset: 0x000049C9
		public void SetOrderVillage2(int order)
		{
			this.int_8 = order;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x000067D2 File Offset: 0x000049D2
		public int GetPreviousOrderVillage2()
		{
			return this.int_9;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x000067DA File Offset: 0x000049DA
		public void SetPreviousOrderVillage2(int order)
		{
			this.int_9 = order;
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x000067E3 File Offset: 0x000049E3
		public bool IsNewMember()
		{
			return this.int_10 < 259200;
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x000067F2 File Offset: 0x000049F2
		public int GetCreatedTime()
		{
			return this.int_10;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x000067FA File Offset: 0x000049FA
		public void SetCreatedTime(int value)
		{
			this.int_10 = value;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00006803 File Offset: 0x00004A03
		public int GetWarCooldown()
		{
			return this.int_11;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0000680B File Offset: 0x00004A0B
		public void SetWarCooldown(int value)
		{
			this.int_11 = value;
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x00006814 File Offset: 0x00004A14
		public int GetWarPreference()
		{
			return this.int_12;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0000681C File Offset: 0x00004A1C
		public void SetWarPreference(int value)
		{
			this.int_12 = value;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x000205E0 File Offset: 0x0001E7E0
		public bool HasLowerRoleThan(LogicAvatarAllianceRole role)
		{
			switch (role)
			{
			case LogicAvatarAllianceRole.LEADER:
				return this.logicAvatarAllianceRole_0 != LogicAvatarAllianceRole.LEADER;
			case LogicAvatarAllianceRole.ELDER:
				return this.logicAvatarAllianceRole_0 == LogicAvatarAllianceRole.MEMBER;
			case LogicAvatarAllianceRole.CO_LEADER:
				return this.logicAvatarAllianceRole_0 != LogicAvatarAllianceRole.LEADER && this.logicAvatarAllianceRole_0 != LogicAvatarAllianceRole.CO_LEADER;
			default:
				return false;
			}
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00006825 File Offset: 0x00004A25
		public static bool HasLowerRole(LogicAvatarAllianceRole role1, LogicAvatarAllianceRole role2)
		{
			switch (role2)
			{
			case LogicAvatarAllianceRole.LEADER:
				return role1 != LogicAvatarAllianceRole.LEADER;
			case LogicAvatarAllianceRole.ELDER:
				return role1 == LogicAvatarAllianceRole.MEMBER;
			case LogicAvatarAllianceRole.CO_LEADER:
				return role1 != LogicAvatarAllianceRole.LEADER && role1 != LogicAvatarAllianceRole.CO_LEADER;
			default:
				return false;
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00020634 File Offset: 0x0001E834
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("avatar_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("avatar_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_0 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("home_id_high");
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("home_id_low");
			if (jsonnumber3 != null && jsonnumber4 != null)
			{
				this.logicLong_1 = new LogicLong(jsonnumber3.GetIntValue(), jsonnumber4.GetIntValue());
			}
			this.string_0 = LogicJSONHelper.GetString(jsonObject, "name");
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)LogicJSONHelper.GetInt(jsonObject, "alliance_role");
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "xp_level");
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "league_type");
			this.int_2 = LogicJSONHelper.GetInt(jsonObject, "score");
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "duel_score");
			this.int_4 = LogicJSONHelper.GetInt(jsonObject, "donations");
			this.int_5 = LogicJSONHelper.GetInt(jsonObject, "received_donations");
			this.int_6 = LogicJSONHelper.GetInt(jsonObject, "order");
			this.int_7 = LogicJSONHelper.GetInt(jsonObject, "prev_order");
			this.int_8 = LogicJSONHelper.GetInt(jsonObject, "order_v2");
			this.int_9 = LogicJSONHelper.GetInt(jsonObject, "prev_order_v2");
			this.int_11 = LogicJSONHelper.GetInt(jsonObject, "war_cooldown");
			this.int_12 = LogicJSONHelper.GetInt(jsonObject, "war_preference");
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0002079C File Offset: 0x0001E99C
		public LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("avatar_id_high", new LogicJSONNumber(this.logicLong_0.GetHigherInt()));
			logicJSONObject.Put("avatar_id_low", new LogicJSONNumber(this.logicLong_0.GetLowerInt()));
			if (this.logicLong_1 != null)
			{
				logicJSONObject.Put("home_id_high", new LogicJSONNumber(this.logicLong_1.GetHigherInt()));
				logicJSONObject.Put("home_id_low", new LogicJSONNumber(this.logicLong_1.GetLowerInt()));
			}
			logicJSONObject.Put("name", new LogicJSONString(this.string_0));
			logicJSONObject.Put("alliance_role", new LogicJSONNumber((int)this.logicAvatarAllianceRole_0));
			logicJSONObject.Put("xp_level", new LogicJSONNumber(this.int_0));
			logicJSONObject.Put("league_type", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("score", new LogicJSONNumber(this.int_2));
			logicJSONObject.Put("duel_score", new LogicJSONNumber(this.int_3));
			logicJSONObject.Put("donations", new LogicJSONNumber(this.int_4));
			logicJSONObject.Put("received_donations", new LogicJSONNumber(this.int_5));
			logicJSONObject.Put("order", new LogicJSONNumber(this.int_6));
			logicJSONObject.Put("prev_order", new LogicJSONNumber(this.int_7));
			logicJSONObject.Put("order_v2", new LogicJSONNumber(this.int_8));
			logicJSONObject.Put("prev_order_v2", new LogicJSONNumber(this.int_9));
			logicJSONObject.Put("war_cooldown", new LogicJSONNumber(this.int_11));
			logicJSONObject.Put("war_preference", new LogicJSONNumber(this.int_12));
			return logicJSONObject;
		}

		// Token: 0x04000303 RID: 771
		private LogicLong logicLong_0;

		// Token: 0x04000304 RID: 772
		private LogicLong logicLong_1;

		// Token: 0x04000305 RID: 773
		private string string_0;

		// Token: 0x04000306 RID: 774
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;

		// Token: 0x04000307 RID: 775
		private int int_0;

		// Token: 0x04000308 RID: 776
		private int int_1;

		// Token: 0x04000309 RID: 777
		private int int_2;

		// Token: 0x0400030A RID: 778
		private int int_3;

		// Token: 0x0400030B RID: 779
		private int int_4;

		// Token: 0x0400030C RID: 780
		private int int_5;

		// Token: 0x0400030D RID: 781
		private int int_6;

		// Token: 0x0400030E RID: 782
		private int int_7;

		// Token: 0x0400030F RID: 783
		private int int_8;

		// Token: 0x04000310 RID: 784
		private int int_9;

		// Token: 0x04000311 RID: 785
		private int int_10;

		// Token: 0x04000312 RID: 786
		private int int_11;

		// Token: 0x04000313 RID: 787
		private int int_12;
	}
}
