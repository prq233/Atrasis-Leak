using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x0200009D RID: 157
	public class Village2AttackEntry
	{
		// Token: 0x060006BA RID: 1722 RVA: 0x00005E31 File Offset: 0x00004031
		public Village2AttackEntry()
		{
			this.logicLong_0 = new LogicLong();
			this.bool_0 = true;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001ECF8 File Offset: 0x0001CEF8
		public virtual void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(this.bool_1);
			if (!this.bool_1)
			{
				encoder.WriteLong(this.logicLong_0);
				if (this.logicLong_4 != null)
				{
					encoder.WriteBoolean(true);
					encoder.WriteLong(this.logicLong_4);
					encoder.WriteString(this.string_1);
					encoder.WriteInt(this.int_0);
					encoder.WriteInt(this.int_1);
				}
				else
				{
					encoder.WriteBoolean(false);
				}
				encoder.WriteLong(this.logicLong_1);
				encoder.WriteLong(this.logicLong_2);
				encoder.WriteString(this.string_0);
				encoder.WriteInt(-1);
				if (this.logicLong_3 != null)
				{
					encoder.WriteBoolean(true);
					encoder.WriteLong(this.logicLong_3);
				}
				else
				{
					encoder.WriteBoolean(false);
				}
				encoder.WriteVInt(99999);
				encoder.WriteVInt(99999);
				encoder.WriteVInt(this.int_3);
				encoder.WriteVInt(this.int_4);
				encoder.WriteBoolean(this.bool_2);
				encoder.WriteVInt(this.int_2);
			}
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0001EE14 File Offset: 0x0001D014
		public virtual void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			this.bool_1 = stream.ReadBoolean();
			if (!this.bool_1)
			{
				this.logicLong_0 = stream.ReadLong();
				if (stream.ReadBoolean())
				{
					this.logicLong_4 = stream.ReadLong();
					this.string_1 = stream.ReadString(900000);
					this.int_0 = stream.ReadInt();
					this.int_1 = stream.ReadInt();
				}
				this.logicLong_1 = stream.ReadLong();
				this.logicLong_2 = stream.ReadLong();
				this.string_0 = stream.ReadString(900000);
				stream.ReadInt();
				if (stream.ReadBoolean())
				{
					this.logicLong_3 = stream.ReadLong();
				}
				stream.ReadVInt();
				stream.ReadVInt();
				this.int_3 = stream.ReadVInt();
				this.int_4 = stream.ReadVInt();
				this.bool_2 = stream.ReadBoolean();
				this.int_2 = stream.ReadVInt();
			}
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x00002467 File Offset: 0x00000667
		public virtual Village2AttackEntryType GetAttackEntryType()
		{
			return Village2AttackEntryType.BASE;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00005E4B File Offset: 0x0000404B
		public bool IsNew()
		{
			return this.bool_0;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00005E53 File Offset: 0x00004053
		public void SetNew(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00005E5C File Offset: 0x0000405C
		public bool IsRemoved()
		{
			return this.bool_1;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00005E64 File Offset: 0x00004064
		public void SetRemoved(bool value)
		{
			this.bool_1 = value;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00005E6D File Offset: 0x0000406D
		public LogicLong GetId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00005E75 File Offset: 0x00004075
		public void SetId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00005E7E File Offset: 0x0000407E
		public LogicLong GetAccountId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00005E86 File Offset: 0x00004086
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00005E8F File Offset: 0x0000408F
		public LogicLong GetAvatarId()
		{
			return this.logicLong_2;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00005E97 File Offset: 0x00004097
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00005EA0 File Offset: 0x000040A0
		public LogicLong GetHomeId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00005EA8 File Offset: 0x000040A8
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00005EB1 File Offset: 0x000040B1
		public LogicLong GetAllianceId()
		{
			return this.logicLong_4;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00005EB9 File Offset: 0x000040B9
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_4 = value;
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00005EC2 File Offset: 0x000040C2
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00005ECA File Offset: 0x000040CA
		public void SetName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00005ED3 File Offset: 0x000040D3
		public string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00005EDB File Offset: 0x000040DB
		public void SetAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00005EE4 File Offset: 0x000040E4
		public int GetAllianceBadgeId()
		{
			return this.int_0;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00005EEC File Offset: 0x000040EC
		public void SetAllianceBadgeId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00005EF5 File Offset: 0x000040F5
		public int GetAllianceExpLevel()
		{
			return this.int_1;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00005EFD File Offset: 0x000040FD
		public void SetAllianceExpLevel(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00005F06 File Offset: 0x00004106
		public int GetRemainingSeconds()
		{
			return this.int_2;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00005F0E File Offset: 0x0000410E
		public void SetRemainingSeconds(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00005F17 File Offset: 0x00004117
		public int GetBonusGoldCount()
		{
			return this.int_3;
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00005F1F File Offset: 0x0000411F
		public void SetBonusGoldCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00005F28 File Offset: 0x00004128
		public int GetBonusElixirCount()
		{
			return this.int_4;
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00005F30 File Offset: 0x00004130
		public void SetBonusElixirCount(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00005F39 File Offset: 0x00004139
		public bool GetBonus()
		{
			return this.bool_2;
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00005F41 File Offset: 0x00004141
		public void SetBonus(bool bonus)
		{
			this.bool_2 = bonus;
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0001EF10 File Offset: 0x0001D110
		public virtual void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("alliance_id_hi");
			if (jsonnumber != null)
			{
				this.logicLong_4 = new LogicLong(jsonnumber.GetIntValue(), jsonObject.GetJSONNumber("alliance_id_lo").GetIntValue());
				this.string_1 = jsonObject.GetJSONString("alliance_name").GetStringValue();
				this.int_0 = jsonObject.GetJSONNumber("alliance_badge").GetIntValue();
				this.int_1 = jsonObject.GetJSONNumber("alliance_xp_lvl").GetIntValue();
			}
			this.logicLong_1 = new LogicLong(jsonObject.GetJSONNumber("acc_id_hi").GetIntValue(), jsonObject.GetJSONNumber("acc_id_lo").GetIntValue());
			this.logicLong_2 = new LogicLong(jsonObject.GetJSONNumber("avatar_id_hi").GetIntValue(), jsonObject.GetJSONNumber("avatar_id_lo").GetIntValue());
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("home_id_hi");
			if (jsonnumber2 != null)
			{
				this.logicLong_3 = new LogicLong(jsonnumber2.GetIntValue(), jsonObject.GetJSONNumber("home_id_lo").GetIntValue());
			}
			this.string_0 = jsonObject.GetJSONString("name").GetStringValue();
			this.int_2 = jsonObject.GetJSONNumber("remainingSecs").GetIntValue();
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("bonus");
			if (jsonboolean != null && jsonboolean.IsTrue())
			{
				this.bool_2 = true;
				this.int_3 = jsonObject.GetJSONNumber("bonusGoldCount").GetIntValue();
				this.int_4 = jsonObject.GetJSONNumber("bonusElixirCount").GetIntValue();
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x0001F08C File Offset: 0x0001D28C
		public virtual void Save(LogicJSONObject jsonObject)
		{
			if (this.logicLong_4 != null)
			{
				jsonObject.Put("alliance_id_hi", new LogicJSONNumber(this.logicLong_4.GetHigherInt()));
				jsonObject.Put("alliance_id_lo", new LogicJSONNumber(this.logicLong_4.GetLowerInt()));
				jsonObject.Put("alliance_name", new LogicJSONString(this.string_1));
				jsonObject.Put("alliance_badge", new LogicJSONNumber(this.int_0));
				jsonObject.Put("alliance_xp_lvl", new LogicJSONNumber(this.int_1));
			}
			jsonObject.Put("acc_id_hi", new LogicJSONNumber(this.logicLong_1.GetHigherInt()));
			jsonObject.Put("acc_id_lo", new LogicJSONNumber(this.logicLong_1.GetLowerInt()));
			jsonObject.Put("avatar_id_hi", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
			jsonObject.Put("avatar_id_lo", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("home_id_hi", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("home_id_lo", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
			jsonObject.Put("name", new LogicJSONString(this.string_0));
			jsonObject.Put("remainingSecs", new LogicJSONNumber(this.int_2));
			if (this.bool_2)
			{
				jsonObject.Put("bonus", new LogicJSONBoolean(true));
				jsonObject.Put("bonusGoldCount", new LogicJSONNumber(this.int_3));
				jsonObject.Put("bonusElixirCount", new LogicJSONNumber(this.int_4));
			}
		}

		// Token: 0x04000283 RID: 643
		private bool bool_0;

		// Token: 0x04000284 RID: 644
		private bool bool_1;

		// Token: 0x04000285 RID: 645
		private bool bool_2;

		// Token: 0x04000286 RID: 646
		private LogicLong logicLong_0;

		// Token: 0x04000287 RID: 647
		private LogicLong logicLong_1;

		// Token: 0x04000288 RID: 648
		private LogicLong logicLong_2;

		// Token: 0x04000289 RID: 649
		private LogicLong logicLong_3;

		// Token: 0x0400028A RID: 650
		private LogicLong logicLong_4;

		// Token: 0x0400028B RID: 651
		private string string_0;

		// Token: 0x0400028C RID: 652
		private string string_1;

		// Token: 0x0400028D RID: 653
		private int int_0;

		// Token: 0x0400028E RID: 654
		private int int_1;

		// Token: 0x0400028F RID: 655
		private int int_2;

		// Token: 0x04000290 RID: 656
		private int int_3;

		// Token: 0x04000291 RID: 657
		private int int_4;
	}
}
