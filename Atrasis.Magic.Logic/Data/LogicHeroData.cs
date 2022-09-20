using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000154 RID: 340
	public class LogicHeroData : LogicCharacterData
	{
		// Token: 0x060013C6 RID: 5062 RVA: 0x0000D135 File Offset: 0x0000B335
		public LogicHeroData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x000504D0 File Offset: 0x0004E6D0
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_47 = (base.GetIntegerValue("MaxSearchRadiusForDefender", 0) << 9) / 100;
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.logicSpellData_3 = new LogicSpellData[biggestArraySize];
			this.int_68 = new int[biggestArraySize];
			this.int_69 = new int[biggestArraySize];
			this.int_57 = new int[biggestArraySize];
			this.int_58 = new int[biggestArraySize];
			this.int_59 = new int[biggestArraySize];
			this.int_60 = new int[biggestArraySize];
			this.int_61 = new int[biggestArraySize];
			this.int_62 = new int[biggestArraySize];
			this.int_63 = new int[biggestArraySize];
			this.int_64 = new int[biggestArraySize];
			this.int_65 = new int[biggestArraySize];
			this.int_66 = new int[biggestArraySize];
			this.int_67 = new int[biggestArraySize];
			this.int_70 = new int[biggestArraySize];
			for (int i = 0; i < biggestArraySize; i++)
			{
				this.int_68[i] = 60 * base.GetClampedIntegerValue("RegenerationTimeMinutes", i);
				this.int_69[i] = base.GetClampedIntegerValue("RequiredTownHallLevel", i) - 1;
				this.int_57[i] = base.GetClampedIntegerValue("AbilityTime", i);
				this.int_58[i] = base.GetClampedIntegerValue("AbilitySpeedBoost", i);
				this.int_59[i] = base.GetClampedIntegerValue("AbilitySpeedBoost2", i);
				this.int_60[i] = base.GetClampedIntegerValue("AbilityDamageBoostPercent", i);
				this.int_61[i] = base.GetClampedIntegerValue("AbilitySummonTroopCount", i);
				this.int_62[i] = base.GetClampedIntegerValue("AbilityHealthIncrease", i);
				this.int_63[i] = base.GetClampedIntegerValue("AbilityShieldProjectileSpeed", i);
				this.int_64[i] = base.GetClampedIntegerValue("AbilityShieldProjectileDamageMod", i);
				this.logicSpellData_3[i] = LogicDataTables.GetSpellByName(base.GetClampedValue("AbilitySpell", i), this);
				this.int_65[i] = base.GetClampedIntegerValue("AbilitySpellLevel", i);
				this.int_66[i] = base.GetClampedIntegerValue("AbilityDamageBoostOffset", i);
				int damagePerMS = this.m_attackerItemData[i].GetDamagePerMS(0, false);
				int num = this.int_66[i];
				this.int_67[i] = (100 * (damagePerMS + num) + damagePerMS / 2) / damagePerMS - 100;
				this.int_70[i] = base.GetClampedIntegerValue("StrengthWeight2", i);
			}
			this.int_51 = (base.GetIntegerValue("AlertRadius", 0) << 9) / 100;
			this.bool_18 = base.GetBooleanValue("AbilityStealth", 0);
			this.int_52 = base.GetIntegerValue("AbilityRadius", 0);
			this.bool_19 = base.GetBooleanValue("AbilityAffectsHero", 0);
			this.logicCharacterData_2 = LogicDataTables.GetCharacterByName(base.GetValue("AbilityAffectsCharacter", 0), this);
			this.logicEffectData_7 = LogicDataTables.GetEffectByName(base.GetValue("AbilityTriggerEffect", 0), this);
			this.bool_17 = base.GetBooleanValue("AbilityOnce", 0);
			this.int_48 = base.GetIntegerValue("AbilityCooldown", 0);
			this.logicCharacterData_3 = LogicDataTables.GetCharacterByName(base.GetValue("AbilitySummonTroop", 0), this);
			this.logicEffectData_8 = LogicDataTables.GetEffectByName(base.GetValue("SpecialAbilityEffect", 0), this);
			this.logicEffectData_9 = LogicDataTables.GetEffectByName(base.GetValue("CelebrateEffect", 0), this);
			this.int_53 = (base.GetIntegerValue("SleepOffsetX", 0) << 9) / 100;
			this.int_54 = (base.GetIntegerValue("SleepOffsetY", 0) << 9) / 100;
			this.int_55 = (base.GetIntegerValue("PatrolRadius", 0) << 9) / 100;
			this.string_8 = base.GetValue("SmallPictureSWF", 0);
			this.string_9 = base.GetValue("SmallPicture", 0);
			this.string_10 = base.GetValue("AbilityTID", 0);
			this.string_11 = base.GetValue("AbilityDescTID", 0);
			this.string_12 = base.GetValue("AbilityIcon", 0);
			this.int_56 = base.GetIntegerValue("AbilityDelay", 0);
			this.string_13 = base.GetValue("AbilityBigPictureExportName", 0);
			this.bool_20 = base.GetBooleanValue("HasAltMode", 0);
			this.bool_21 = base.GetBooleanValue("AltModeFlying", 0);
			this.bool_16 = base.GetBooleanValue("NoDefence", 0);
			this.int_49 = base.GetIntegerValue("ActivationTime", 0);
			this.int_50 = base.GetIntegerValue("ActiveDuration", 0);
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x0000D13F File Offset: 0x0000B33F
		public bool GetAbilityStealth()
		{
			return this.bool_18;
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x0000D147 File Offset: 0x0000B347
		public bool GetAbilityAffectsHero()
		{
			return this.bool_19;
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x0000D14F File Offset: 0x0000B34F
		public int GetAbilityHealthIncrease(int upgLevel)
		{
			return this.int_62[upgLevel];
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x0000D159 File Offset: 0x0000B359
		public bool HasHasAltMode()
		{
			return this.bool_20;
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x0000D161 File Offset: 0x0000B361
		public bool GetAltModeFlying()
		{
			return this.bool_21;
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0000D169 File Offset: 0x0000B369
		public int GetMaxSearchRadiusForDefender()
		{
			return this.int_47;
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x0000D171 File Offset: 0x0000B371
		public int GetActivationTime()
		{
			return this.int_49;
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0000D179 File Offset: 0x0000B379
		public int GetActiveDuration()
		{
			return this.int_50;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0000D181 File Offset: 0x0000B381
		public int GetAlertRadius()
		{
			return this.int_51;
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0000D189 File Offset: 0x0000B389
		public int GetAbilityRadius()
		{
			return this.int_52;
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x0000D191 File Offset: 0x0000B391
		public int GetSleepOffsetX()
		{
			return this.int_53;
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x0000D199 File Offset: 0x0000B399
		public int GetSleepOffsetY()
		{
			return this.int_54;
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x0000D1A1 File Offset: 0x0000B3A1
		public int GetPatrolRadius()
		{
			return this.int_55;
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x0000D1A9 File Offset: 0x0000B3A9
		public int GetAbilityDelay()
		{
			return this.int_56;
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x0000D1B1 File Offset: 0x0000B3B1
		public string GetSmallPictureSWF()
		{
			return this.string_8;
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0000D1B9 File Offset: 0x0000B3B9
		public string GetSmallPicture()
		{
			return this.string_9;
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x0000D1C1 File Offset: 0x0000B3C1
		public string GetAbilityTID()
		{
			return this.string_10;
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x0000D1C9 File Offset: 0x0000B3C9
		public string GetAbilityDescTID()
		{
			return this.string_11;
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x0000D1D1 File Offset: 0x0000B3D1
		public string GetAbilityIcon()
		{
			return this.string_12;
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x0000D1D9 File Offset: 0x0000B3D9
		public string GetAbilityBigPictureExportName()
		{
			return this.string_13;
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x0000D1E1 File Offset: 0x0000B3E1
		public LogicCharacterData GetAbilityAffectsCharacter()
		{
			return this.logicCharacterData_2;
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x0000D1E9 File Offset: 0x0000B3E9
		public LogicCharacterData GetAbilitySummonTroop()
		{
			return this.logicCharacterData_3;
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x0000D1F1 File Offset: 0x0000B3F1
		public LogicEffectData GetAbilityTriggerEffect()
		{
			return this.logicEffectData_7;
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x0000D1F9 File Offset: 0x0000B3F9
		public LogicEffectData GetSpecialAbilityEffect()
		{
			return this.logicEffectData_8;
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x0000D201 File Offset: 0x0000B401
		public LogicEffectData GetCelebreateEffect()
		{
			return this.logicEffectData_9;
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x0000D209 File Offset: 0x0000B409
		public LogicSpellData GetAbilitySpell(int upgLevel)
		{
			return this.logicSpellData_3[upgLevel];
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x0000D213 File Offset: 0x0000B413
		public int GetAbilitySpellLevel(int upgLevel)
		{
			return this.int_65[upgLevel];
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x0000D21D File Offset: 0x0000B41D
		public int GetRequiredTownHallLevel(int index)
		{
			return this.int_69[index];
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x0000D227 File Offset: 0x0000B427
		public int GetAbilityShieldProjectileSpeed(int upgLevel)
		{
			return this.int_63[upgLevel];
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x0000D231 File Offset: 0x0000B431
		public int GetAbilityShieldProjectileDamageMod(int upgLevel)
		{
			return this.int_64[upgLevel];
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x0000D23B File Offset: 0x0000B43B
		public int GetAbilityTime(int index)
		{
			return this.int_57[index];
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x0000D245 File Offset: 0x0000B445
		public int GetAbilityCooldown()
		{
			return this.int_48;
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x0000D24D File Offset: 0x0000B44D
		public int GetAbilitySpeedBoost(int index)
		{
			return this.int_58[index];
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x0000D257 File Offset: 0x0000B457
		public int GetAbilitySpeedBoost2(int index)
		{
			return this.int_59[index];
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0000D261 File Offset: 0x0000B461
		public int GetAbilityDamageBoostPercent(int index)
		{
			return this.int_60[index];
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x0000D26B File Offset: 0x0000B46B
		public int GetAbilityDamageBoost(int index)
		{
			return this.int_67[index];
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x0000D275 File Offset: 0x0000B475
		public int GetAbilitySummonTroopCount(int index)
		{
			return this.int_61[index];
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x0000D27F File Offset: 0x0000B47F
		public bool HasNoDefence()
		{
			return this.bool_16;
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x0000D287 File Offset: 0x0000B487
		public bool HasOnceAbility()
		{
			return this.bool_17;
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x0005092C File Offset: 0x0004EB2C
		public int GetHeroHitpoints(int hp, int upgLevel)
		{
			hp = LogicMath.Max(0, hp);
			int num = this.int_68[upgLevel];
			int num2 = this.m_hitpoints[upgLevel];
			if (num != 0)
			{
				num2 = num2 * (LogicMath.Max(num - hp, 0) / 60) / (num / 60);
			}
			return num2;
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x0000D28F File Offset: 0x0000B48F
		public bool HasEnoughHealthForAttack(int hp, int upgLevel)
		{
			return this.m_hitpoints[upgLevel] == hp;
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x0000D29C File Offset: 0x0000B49C
		public bool HasAbility(int upgLevel)
		{
			return this.int_57[upgLevel] > 0 || this.logicSpellData_3[upgLevel] != null;
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x0000D2B6 File Offset: 0x0000B4B6
		public int GetFullRegenerationTimeSec(int upgLevel)
		{
			return this.int_68[upgLevel];
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x0000D2C0 File Offset: 0x0000B4C0
		public int GetSecondsToFullHealth(int hp, int upgLevel)
		{
			return 60 * (this.int_68[upgLevel] / 60 * (this.m_hitpoints[upgLevel] - LogicMath.Clamp(hp, 0, this.m_hitpoints[upgLevel])) / this.m_hitpoints[upgLevel]);
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x0000D2F2 File Offset: 0x0000B4F2
		public int GetStrengthWeight2(int upgLevel)
		{
			return this.int_70[upgLevel];
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x0000D2FC File Offset: 0x0000B4FC
		public bool IsFlying(int mode)
		{
			if (mode == 1 && this.bool_20)
			{
				return this.bool_21;
			}
			return base.IsFlying();
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x00002B58 File Offset: 0x00000D58
		public override LogicCombatItemType GetCombatItemType()
		{
			return LogicCombatItemType.HERO;
		}

		// Token: 0x04000A12 RID: 2578
		private bool bool_16;

		// Token: 0x04000A13 RID: 2579
		private bool bool_17;

		// Token: 0x04000A14 RID: 2580
		private bool bool_18;

		// Token: 0x04000A15 RID: 2581
		private bool bool_19;

		// Token: 0x04000A16 RID: 2582
		private bool bool_20;

		// Token: 0x04000A17 RID: 2583
		private bool bool_21;

		// Token: 0x04000A18 RID: 2584
		private int int_47;

		// Token: 0x04000A19 RID: 2585
		private int int_48;

		// Token: 0x04000A1A RID: 2586
		private int int_49;

		// Token: 0x04000A1B RID: 2587
		private int int_50;

		// Token: 0x04000A1C RID: 2588
		private int int_51;

		// Token: 0x04000A1D RID: 2589
		private int int_52;

		// Token: 0x04000A1E RID: 2590
		private int int_53;

		// Token: 0x04000A1F RID: 2591
		private int int_54;

		// Token: 0x04000A20 RID: 2592
		private int int_55;

		// Token: 0x04000A21 RID: 2593
		private int int_56;

		// Token: 0x04000A22 RID: 2594
		private int[] int_57;

		// Token: 0x04000A23 RID: 2595
		private int[] int_58;

		// Token: 0x04000A24 RID: 2596
		private int[] int_59;

		// Token: 0x04000A25 RID: 2597
		private int[] int_60;

		// Token: 0x04000A26 RID: 2598
		private int[] int_61;

		// Token: 0x04000A27 RID: 2599
		private int[] int_62;

		// Token: 0x04000A28 RID: 2600
		private int[] int_63;

		// Token: 0x04000A29 RID: 2601
		private int[] int_64;

		// Token: 0x04000A2A RID: 2602
		private int[] int_65;

		// Token: 0x04000A2B RID: 2603
		private int[] int_66;

		// Token: 0x04000A2C RID: 2604
		private int[] int_67;

		// Token: 0x04000A2D RID: 2605
		private int[] int_68;

		// Token: 0x04000A2E RID: 2606
		private int[] int_69;

		// Token: 0x04000A2F RID: 2607
		private int[] int_70;

		// Token: 0x04000A30 RID: 2608
		private string string_8;

		// Token: 0x04000A31 RID: 2609
		private string string_9;

		// Token: 0x04000A32 RID: 2610
		private string string_10;

		// Token: 0x04000A33 RID: 2611
		private string string_11;

		// Token: 0x04000A34 RID: 2612
		private string string_12;

		// Token: 0x04000A35 RID: 2613
		private string string_13;

		// Token: 0x04000A36 RID: 2614
		private LogicCharacterData logicCharacterData_2;

		// Token: 0x04000A37 RID: 2615
		private LogicCharacterData logicCharacterData_3;

		// Token: 0x04000A38 RID: 2616
		private LogicEffectData logicEffectData_7;

		// Token: 0x04000A39 RID: 2617
		private LogicEffectData logicEffectData_8;

		// Token: 0x04000A3A RID: 2618
		private LogicEffectData logicEffectData_9;

		// Token: 0x04000A3B RID: 2619
		private LogicSpellData[] logicSpellData_3;
	}
}
