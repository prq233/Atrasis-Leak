using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x020000A4 RID: 164
	public class Village2BattleResultAttackEntry : Village2AttackEntry
	{
		// Token: 0x06000704 RID: 1796 RVA: 0x0001F344 File Offset: 0x0001D544
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteVInt(this.int_5);
			encoder.WriteInt(this.int_6);
			encoder.WriteInt(this.int_7);
			encoder.WriteInt(this.int_8);
			encoder.WriteInt(this.int_9);
			encoder.WriteInt(this.int_10);
			encoder.WriteInt(this.int_11);
			encoder.WriteInt(this.int_12);
			encoder.WriteBoolean(this.bool_3);
			if (this.logicLong_5 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_5);
				encoder.WriteInt(this.int_13);
				encoder.WriteInt(this.int_15);
				encoder.WriteInt(this.int_16);
				encoder.WriteInt(this.int_17);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			if (this.logicLong_6 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_6);
				encoder.WriteInt(this.int_14);
				encoder.WriteInt(this.int_18);
				encoder.WriteInt(this.int_19);
				encoder.WriteInt(this.int_20);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteInt(0);
			encoder.WriteString(this.string_2);
			encoder.WriteString(this.string_3);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0001F48C File Offset: 0x0001D68C
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_5 = stream.ReadVInt();
			this.int_6 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.int_9 = stream.ReadInt();
			this.int_10 = stream.ReadInt();
			this.int_11 = stream.ReadInt();
			this.int_12 = stream.ReadInt();
			this.bool_3 = stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.logicLong_5 = stream.ReadLong();
				this.int_13 = stream.ReadInt();
				this.int_15 = stream.ReadInt();
				this.int_16 = stream.ReadInt();
				this.int_17 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_6 = stream.ReadLong();
				this.int_14 = stream.ReadInt();
				this.int_18 = stream.ReadInt();
				this.int_19 = stream.ReadInt();
				this.int_20 = stream.ReadInt();
			}
			stream.ReadInt();
			this.string_2 = stream.ReadString(900000);
			this.string_3 = stream.ReadString(900000);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00002B38 File Offset: 0x00000D38
		public override Village2AttackEntryType GetAttackEntryType()
		{
			return Village2AttackEntryType.BATTLE_RESULT;
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0000611E File Offset: 0x0000431E
		public bool IsBattleEnded()
		{
			return this.bool_3;
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00006126 File Offset: 0x00004326
		public void SetBattleEnded(bool ended)
		{
			this.bool_3 = ended;
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0000612F File Offset: 0x0000432F
		public int GetResultType()
		{
			return this.int_5;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00006137 File Offset: 0x00004337
		public void SetResultType(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00006140 File Offset: 0x00004340
		public int GetAttackerStars()
		{
			return this.int_6;
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00006148 File Offset: 0x00004348
		public void SetAttackerStars(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00006151 File Offset: 0x00004351
		public int GetAttackerDestructionPercentage()
		{
			return this.int_7;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00006159 File Offset: 0x00004359
		public void SetAttackerDestructionPercentage(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00006162 File Offset: 0x00004362
		public int GetOpponentStars()
		{
			return this.int_8;
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0000616A File Offset: 0x0000436A
		public void SetOpponentStars(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00006173 File Offset: 0x00004373
		public int GetOpponentDestructionPercentage()
		{
			return this.int_9;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0000617B File Offset: 0x0000437B
		public void SetOpponentDestructionPercentage(int value)
		{
			this.int_9 = value;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00006184 File Offset: 0x00004384
		public int GetGoldCount()
		{
			return this.int_10;
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0000618C File Offset: 0x0000438C
		public void SetGoldCount(int value)
		{
			this.int_10 = value;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00006195 File Offset: 0x00004395
		public int GetElixirCount()
		{
			return this.int_11;
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0000619D File Offset: 0x0000439D
		public void SetElixirCount(int value)
		{
			this.int_11 = value;
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x000061A6 File Offset: 0x000043A6
		public int GetScoreCount()
		{
			return this.int_12;
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x000061AE File Offset: 0x000043AE
		public void SetScoreCount(int value)
		{
			this.int_12 = value;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x000061B7 File Offset: 0x000043B7
		public int GetAttackerReplayShardId()
		{
			return this.int_13;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x000061BF File Offset: 0x000043BF
		public void SetAttackerReplayShardId(int value)
		{
			this.int_13 = value;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x000061C8 File Offset: 0x000043C8
		public int GetOpponentReplayShardId()
		{
			return this.int_14;
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x000061D0 File Offset: 0x000043D0
		public void SetOpponentReplayShardId(int value)
		{
			this.int_14 = value;
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x000061D9 File Offset: 0x000043D9
		public int GetAttackerReplayMajorVersion()
		{
			return this.int_15;
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000061E1 File Offset: 0x000043E1
		public void SetAttackerReplayMajorVersion(int value)
		{
			this.int_15 = value;
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x000061EA File Offset: 0x000043EA
		public int GetAttackerReplayBuildVersion()
		{
			return this.int_16;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000061F2 File Offset: 0x000043F2
		public void SetAttackerReplayBuildVersion(int value)
		{
			this.int_16 = value;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000061FB File Offset: 0x000043FB
		public int GetAttackerReplayContentVersion()
		{
			return this.int_17;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00006203 File Offset: 0x00004403
		public void SetAttackerReplayContentVersion(int value)
		{
			this.int_17 = value;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0000620C File Offset: 0x0000440C
		public int GetOpponentReplayMajorVersion()
		{
			return this.int_18;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00006214 File Offset: 0x00004414
		public void SetOpponentReplayMajorVersion(int value)
		{
			this.int_18 = value;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0000621D File Offset: 0x0000441D
		public int GetOpponentReplayBuildVersion()
		{
			return this.int_19;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00006225 File Offset: 0x00004425
		public void SetOpponentReplayBuildVersion(int value)
		{
			this.int_19 = value;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0000622E File Offset: 0x0000442E
		public int GetOpponentReplayContentVersion()
		{
			return this.int_20;
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00006236 File Offset: 0x00004436
		public void SetOpponentReplayContentVersion(int value)
		{
			this.int_20 = value;
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0000623F File Offset: 0x0000443F
		public LogicLong GetAttackerReplayId()
		{
			return this.logicLong_5;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00006247 File Offset: 0x00004447
		public void SetAttackerReplayId(LogicLong value)
		{
			this.logicLong_5 = value;
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00006250 File Offset: 0x00004450
		public LogicLong GetOpponentReplayId()
		{
			return this.logicLong_6;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00006258 File Offset: 0x00004458
		public void SetOpponentReplayId(LogicLong value)
		{
			this.logicLong_6 = value;
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00006261 File Offset: 0x00004461
		public string GetAttackerBattleLog()
		{
			return this.string_2;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00006269 File Offset: 0x00004469
		public void SetAttackerBattleLog(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00006272 File Offset: 0x00004472
		public string GetOpponentBattleLog()
		{
			return this.string_3;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0000627A File Offset: 0x0000447A
		public void SetOpponentBattleLog(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject.GetJSONObject("base"));
			this.int_5 = jsonObject.GetJSONNumber("battle_result").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("attacker_stars").GetIntValue();
			this.int_7 = jsonObject.GetJSONNumber("attacker_destruction_percentage").GetIntValue();
			this.int_8 = jsonObject.GetJSONNumber("opponent_stars").GetIntValue();
			this.int_9 = jsonObject.GetJSONNumber("opponent_destruction_percentage").GetIntValue();
			this.int_10 = jsonObject.GetJSONNumber("golds").GetIntValue();
			this.int_11 = jsonObject.GetJSONNumber("elixirs").GetIntValue();
			this.int_12 = jsonObject.GetJSONNumber("scores").GetIntValue();
			this.bool_3 = jsonObject.GetJSONBoolean("battle_ended").IsTrue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("attacker_replay_id_hi");
			if (jsonnumber != null)
			{
				this.logicLong_5 = new LogicLong(jsonnumber.GetIntValue(), jsonObject.GetJSONNumber("attacker_replay_id_lo").GetIntValue());
				this.int_13 = jsonObject.GetJSONNumber("attacker_replay_shard_id").GetIntValue();
				this.int_15 = jsonObject.GetJSONNumber("attacker_replay_major_v").GetIntValue();
				this.int_16 = jsonObject.GetJSONNumber("attacker_replay_build_v").GetIntValue();
				this.int_17 = jsonObject.GetJSONNumber("attacker_replay_content_v").GetIntValue();
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("opponent_replay_id_hi");
			if (jsonnumber2 != null)
			{
				this.logicLong_6 = new LogicLong(jsonnumber2.GetIntValue(), jsonObject.GetJSONNumber("opponent_replay_id_lo").GetIntValue());
				this.int_14 = jsonObject.GetJSONNumber("opponent_replay_shard_id").GetIntValue();
				this.int_18 = jsonObject.GetJSONNumber("opponent_replay_major_v").GetIntValue();
				this.int_19 = jsonObject.GetJSONNumber("opponent_replay_build_v").GetIntValue();
				this.int_20 = jsonObject.GetJSONNumber("opponent_replay_content_v").GetIntValue();
			}
			this.string_2 = jsonObject.GetJSONString("attacker_battleLog").GetStringValue();
			this.string_3 = jsonObject.GetJSONString("opponent_battleLog").GetStringValue();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0001F7E0 File Offset: 0x0001D9E0
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("battle_result", new LogicJSONNumber(this.int_5));
			jsonObject.Put("attacker_stars", new LogicJSONNumber(this.int_6));
			jsonObject.Put("attacker_destruction_percentage", new LogicJSONNumber(this.int_7));
			jsonObject.Put("opponent_stars", new LogicJSONNumber(this.int_8));
			jsonObject.Put("opponent_destruction_percentage", new LogicJSONNumber(this.int_9));
			jsonObject.Put("golds", new LogicJSONNumber(this.int_10));
			jsonObject.Put("elixirs", new LogicJSONNumber(this.int_11));
			jsonObject.Put("scores", new LogicJSONNumber(this.int_12));
			jsonObject.Put("battle_ended", new LogicJSONBoolean(this.bool_3));
			if (this.logicLong_5 != null)
			{
				jsonObject.Put("attacker_replay_id_hi", new LogicJSONNumber(this.logicLong_5.GetHigherInt()));
				jsonObject.Put("attacker_replay_id_lo", new LogicJSONNumber(this.logicLong_5.GetLowerInt()));
				jsonObject.Put("attacker_replay_shard_id", new LogicJSONNumber(this.int_13));
				jsonObject.Put("attacker_replay_major_v", new LogicJSONNumber(this.int_15));
				jsonObject.Put("attacker_replay_build_v", new LogicJSONNumber(this.int_16));
				jsonObject.Put("attacker_replay_content_v", new LogicJSONNumber(this.int_17));
			}
			if (this.logicLong_6 != null)
			{
				jsonObject.Put("opponent_replay_id_hi", new LogicJSONNumber(this.logicLong_6.GetHigherInt()));
				jsonObject.Put("opponent_replay_id_lo", new LogicJSONNumber(this.logicLong_6.GetLowerInt()));
				jsonObject.Put("opponent_replay_shard_id", new LogicJSONNumber(this.int_14));
				jsonObject.Put("opponent_replay_major_v", new LogicJSONNumber(this.int_18));
				jsonObject.Put("opponent_replay_build_v", new LogicJSONNumber(this.int_19));
				jsonObject.Put("opponent_replay_content_v", new LogicJSONNumber(this.int_20));
			}
			jsonObject.Put("attacker_battleLog", new LogicJSONString(this.string_2));
			jsonObject.Put("opponent_battleLog", new LogicJSONString(this.string_3));
		}

		// Token: 0x0400029E RID: 670
		private int int_5;

		// Token: 0x0400029F RID: 671
		private int int_6;

		// Token: 0x040002A0 RID: 672
		private int int_7;

		// Token: 0x040002A1 RID: 673
		private int int_8;

		// Token: 0x040002A2 RID: 674
		private int int_9;

		// Token: 0x040002A3 RID: 675
		private int int_10;

		// Token: 0x040002A4 RID: 676
		private int int_11;

		// Token: 0x040002A5 RID: 677
		private int int_12;

		// Token: 0x040002A6 RID: 678
		private int int_13;

		// Token: 0x040002A7 RID: 679
		private int int_14;

		// Token: 0x040002A8 RID: 680
		private int int_15;

		// Token: 0x040002A9 RID: 681
		private int int_16;

		// Token: 0x040002AA RID: 682
		private int int_17;

		// Token: 0x040002AB RID: 683
		private int int_18;

		// Token: 0x040002AC RID: 684
		private int int_19;

		// Token: 0x040002AD RID: 685
		private int int_20;

		// Token: 0x040002AE RID: 686
		private LogicLong logicLong_5;

		// Token: 0x040002AF RID: 687
		private LogicLong logicLong_6;

		// Token: 0x040002B0 RID: 688
		private string string_2;

		// Token: 0x040002B1 RID: 689
		private string string_3;

		// Token: 0x040002B2 RID: 690
		private bool bool_3;
	}
}
