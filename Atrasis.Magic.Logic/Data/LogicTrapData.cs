using System;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000166 RID: 358
	public class LogicTrapData : LogicGameObjectData
	{
		// Token: 0x0600154A RID: 5450 RVA: 0x0000B477 File Offset: 0x00009677
		public LogicTrapData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x000530D0 File Offset: 0x000512D0
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_24 = base.GetIntegerValue("Width", 0);
			this.int_25 = base.GetIntegerValue("Height", 0);
			this.int_0 = this.m_row.GetBiggestArraySize();
			this.int_17 = new int[this.int_0];
			this.int_18 = new int[this.int_0];
			this.int_16 = new int[this.int_0];
			this.int_19 = new int[this.int_0];
			this.int_20 = new int[this.int_0];
			this.int_21 = new int[this.int_0];
			this.int_22 = new int[this.int_0];
			this.int_23 = new int[this.int_0];
			this.int_15 = new int[this.int_0];
			this.logicProjectileData_0 = new LogicProjectileData[this.int_0];
			for (int i = 0; i < this.int_0; i++)
			{
				this.int_17[i] = base.GetClampedIntegerValue("BuildCost", i);
				this.int_18[i] = base.GetClampedIntegerValue("RearmCost", i);
				this.int_16[i] = LogicMath.Max(base.GetClampedIntegerValue("TownHallLevel", i) - 1, 0);
				this.int_19[i] = base.GetClampedIntegerValue("StrengthWeight", i);
				this.int_20[i] = LogicGamePlayUtil.DPSToSingleHit(base.GetClampedIntegerValue("Damage", i), 1000);
				this.int_21[i] = (base.GetClampedIntegerValue("DamageRadius", i) << 9) / 100;
				this.int_22[i] = base.GetIntegerValue("EjectHousingLimit", i);
				this.int_23[i] = base.GetClampedIntegerValue("NumSpawns", i);
				this.int_15[i] = 86400 * base.GetClampedIntegerValue("BuildTimeD", i) + 3600 * base.GetClampedIntegerValue("BuildTimeH", i) + 60 * base.GetClampedIntegerValue("BuildTimeM", i) + base.GetClampedIntegerValue("BuildTimeS", i);
				this.logicProjectileData_0[i] = LogicDataTables.GetProjectileByName(base.GetValue("Projectile", i), this);
			}
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(base.GetValue("PreferredTarget", 0), this);
			this.int_1 = base.GetIntegerValue("PreferredTargetDamageMod", 0);
			if (this.int_1 == 0)
			{
				this.int_1 = 100;
			}
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("BuildResource", 0), this);
			if (this.logicResourceData_0 == null)
			{
				Debugger.Error("build resource is not defined for trap: " + base.GetName());
			}
			this.bool_2 = base.GetBooleanValue("EjectVictims", 0);
			this.int_8 = 1000 * base.GetIntegerValue("ActionFrame", 0) / 24;
			this.int_9 = base.GetIntegerValue("Pushback", 0);
			this.bool_3 = base.GetBooleanValue("DoNotScalePushByDamage", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("Effect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("Effect2", 0), this);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(base.GetValue("EffectBroken", 0), this);
			this.logicEffectData_3 = LogicDataTables.GetEffectByName(base.GetValue("DamageEffect", 0), this);
			this.logicEffectData_4 = LogicDataTables.GetEffectByName(base.GetValue("PickUpEffect", 0), this);
			this.logicEffectData_5 = LogicDataTables.GetEffectByName(base.GetValue("PlacingEffect", 0), this);
			this.logicEffectData_6 = LogicDataTables.GetEffectByName(base.GetValue("AppearEffect", 0), this);
			this.logicEffectData_7 = LogicDataTables.GetEffectByName(base.GetValue("ToggleAttackModeEffect", 0), this);
			this.int_6 = (base.GetIntegerValue("TriggerRadius", 0) << 9) / 100;
			this.int_7 = base.GetIntegerValue("DirectionCount", 0);
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(base.GetValue("Spell", 0), this);
			this.bool_4 = base.GetBooleanValue("AirTrigger", 0);
			this.bool_5 = base.GetBooleanValue("GroundTrigger", 0);
			this.bool_6 = base.GetBooleanValue("HealerTrigger", 0);
			this.int_10 = base.GetIntegerValue("SpeedMod", 0);
			this.int_11 = base.GetIntegerValue("DamageMod", 0);
			this.int_12 = base.GetIntegerValue("DurationMS", 0);
			this.int_13 = base.GetIntegerValue("HitDelayMS", 0);
			this.int_14 = base.GetIntegerValue("HitCnt", 0);
			this.int_2 = base.GetIntegerValue("MinTriggerHousingLimit", 0);
			this.logicCharacterData_1 = LogicDataTables.GetCharacterByName(base.GetValue("SpawnedCharGround", 0), this);
			this.logicCharacterData_2 = LogicDataTables.GetCharacterByName(base.GetValue("SpawnedCharAir", 0), this);
			this.int_3 = base.GetIntegerValue("TimeBetweenSpawnsMs", 0);
			this.int_4 = base.GetIntegerValue("SpawnInitialDelayMs", 0);
			this.int_5 = base.GetIntegerValue("ThrowDistance", 0);
			this.bool_1 = base.GetBooleanValue("HasAltMode", 0);
			this.bool_0 = base.GetBooleanValue("EnabledByCalendar", 0);
			if (this.bool_0 && this.int_0 > 1)
			{
				Debugger.Error("Temporary traps should not have upgrade levels!");
			}
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0000DE36 File Offset: 0x0000C036
		public int GetWidth()
		{
			return this.int_24;
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x0000DE3E File Offset: 0x0000C03E
		public int GetHeight()
		{
			return this.int_25;
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x0000DE46 File Offset: 0x0000C046
		public int GetUpgradeLevelCount()
		{
			return this.int_0;
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0000DE4E File Offset: 0x0000C04E
		public int GetSpawnInitialDelayMS()
		{
			return this.int_4;
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0000DE56 File Offset: 0x0000C056
		public int GetNumSpawns(int upgLevel)
		{
			return this.int_23[upgLevel];
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0000DE60 File Offset: 0x0000C060
		public int GetBuildTime(int upgLevel)
		{
			return this.int_15[upgLevel];
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0000DE6A File Offset: 0x0000C06A
		public LogicResourceData GetBuildResource()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0000DE72 File Offset: 0x0000C072
		public int GetBuildCost(int upgLevel)
		{
			return this.int_17[upgLevel];
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0000DE7C File Offset: 0x0000C07C
		public int GetRequiredTownHallLevel(int upgLevel)
		{
			return this.int_16[upgLevel];
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0000DE86 File Offset: 0x0000C086
		public LogicCharacterData GetSpawnedCharAir()
		{
			return this.logicCharacterData_2;
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0000DE8E File Offset: 0x0000C08E
		public LogicCharacterData GetSpawnedCharGround()
		{
			return this.logicCharacterData_1;
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0000DE96 File Offset: 0x0000C096
		public bool HasAlternativeMode()
		{
			return this.bool_1;
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0000DE9E File Offset: 0x0000C09E
		public int GetThrowDistance()
		{
			return this.int_5;
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0000DEA6 File Offset: 0x0000C0A6
		public int GetDirectionCount()
		{
			return this.int_7;
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0000DEAE File Offset: 0x0000C0AE
		public int GetDamage(int idx)
		{
			return this.int_20[idx];
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0000DEB8 File Offset: 0x0000C0B8
		public int GetDamageRadius(int idx)
		{
			return this.int_21[idx];
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0000DEC2 File Offset: 0x0000C0C2
		public override bool IsEnableByCalendar()
		{
			return this.bool_0;
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0000DECA File Offset: 0x0000C0CA
		public int GetRearmCost(int idx)
		{
			return this.int_18[idx];
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0000DED4 File Offset: 0x0000C0D4
		public int GetStrengthWeight(int idx)
		{
			return this.int_19[idx];
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x0000DEDE File Offset: 0x0000C0DE
		public int GetEjectHousingLimit(int idx)
		{
			return this.int_22[idx];
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x0000DEE8 File Offset: 0x0000C0E8
		public int GetPushback()
		{
			return this.int_9;
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x00053600 File Offset: 0x00051800
		public int GetMaxUpgradeLevelForTownHallLevel(int townHallLevel)
		{
			int i = this.int_0;
			while (i > 0)
			{
				if (this.GetRequiredTownHallLevel(--i) <= townHallLevel)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0000DEF0 File Offset: 0x0000C0F0
		public bool GetEjectVictims()
		{
			return this.bool_2;
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
		public bool GetDoNotScalePushByDamage()
		{
			return this.bool_3;
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0000DF00 File Offset: 0x0000C100
		public bool GetAirTrigger()
		{
			return this.bool_4;
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x0000DF08 File Offset: 0x0000C108
		public bool GetGroundTrigger()
		{
			return this.bool_5;
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0000DF10 File Offset: 0x0000C110
		public bool GetHealerTrigger()
		{
			return this.bool_6;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0000DF18 File Offset: 0x0000C118
		public int GetMinTriggerHousingLimit()
		{
			return this.int_2;
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0000DF20 File Offset: 0x0000C120
		public int GetTimeBetweenSpawnsMS()
		{
			return this.int_3;
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0000DF28 File Offset: 0x0000C128
		public int GetTriggerRadius()
		{
			return this.int_6;
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x0000DF30 File Offset: 0x0000C130
		public int GetActionFrame()
		{
			return this.int_8;
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x0000DF38 File Offset: 0x0000C138
		public int GetSpeedMod()
		{
			return this.int_10;
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x0000DF40 File Offset: 0x0000C140
		public int GetDamageMod()
		{
			return this.int_11;
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0000DF48 File Offset: 0x0000C148
		public int GetDurationMS()
		{
			return this.int_12;
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x0000DF50 File Offset: 0x0000C150
		public int GetHitDelayMS()
		{
			return this.int_13;
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x0000DF58 File Offset: 0x0000C158
		public int GetHitCount()
		{
			return this.int_14;
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x0000DF60 File Offset: 0x0000C160
		public LogicSpellData GetSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x0000DF68 File Offset: 0x0000C168
		public LogicProjectileData GetProjectile(int idx)
		{
			return this.logicProjectileData_0[idx];
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0000DF72 File Offset: 0x0000C172
		public LogicEffectData GetEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0000DF7A File Offset: 0x0000C17A
		public LogicEffectData GetEffect2()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x0000DF82 File Offset: 0x0000C182
		public LogicEffectData GetEffectBroken()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0000DF8A File Offset: 0x0000C18A
		public LogicEffectData GetDamageEffect()
		{
			return this.logicEffectData_3;
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0000DF92 File Offset: 0x0000C192
		public LogicEffectData GetPickUpEffect()
		{
			return this.logicEffectData_4;
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0000DF9A File Offset: 0x0000C19A
		public LogicEffectData GetPlacingEffect()
		{
			return this.logicEffectData_5;
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0000DFA2 File Offset: 0x0000C1A2
		public LogicEffectData GetAppearEffect()
		{
			return this.logicEffectData_6;
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x0000DFAA File Offset: 0x0000C1AA
		public LogicEffectData GetToggleAttackModeEffect()
		{
			return this.logicEffectData_7;
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x0000DFB2 File Offset: 0x0000C1B2
		public LogicCharacterData GetPreferredTarget()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x0000DFBA File Offset: 0x0000C1BA
		public int GetPreferredTargetDamageMod()
		{
			return this.int_1;
		}

		// Token: 0x04000B7C RID: 2940
		private bool bool_0;

		// Token: 0x04000B7D RID: 2941
		private bool bool_1;

		// Token: 0x04000B7E RID: 2942
		private bool bool_2;

		// Token: 0x04000B7F RID: 2943
		private bool bool_3;

		// Token: 0x04000B80 RID: 2944
		private bool bool_4;

		// Token: 0x04000B81 RID: 2945
		private bool bool_5;

		// Token: 0x04000B82 RID: 2946
		private bool bool_6;

		// Token: 0x04000B83 RID: 2947
		private int int_0;

		// Token: 0x04000B84 RID: 2948
		private int int_1;

		// Token: 0x04000B85 RID: 2949
		private int int_2;

		// Token: 0x04000B86 RID: 2950
		private int int_3;

		// Token: 0x04000B87 RID: 2951
		private int int_4;

		// Token: 0x04000B88 RID: 2952
		private int int_5;

		// Token: 0x04000B89 RID: 2953
		private int int_6;

		// Token: 0x04000B8A RID: 2954
		private int int_7;

		// Token: 0x04000B8B RID: 2955
		private int int_8;

		// Token: 0x04000B8C RID: 2956
		private int int_9;

		// Token: 0x04000B8D RID: 2957
		private int int_10;

		// Token: 0x04000B8E RID: 2958
		private int int_11;

		// Token: 0x04000B8F RID: 2959
		private int int_12;

		// Token: 0x04000B90 RID: 2960
		private int int_13;

		// Token: 0x04000B91 RID: 2961
		private int int_14;

		// Token: 0x04000B92 RID: 2962
		private int[] int_15;

		// Token: 0x04000B93 RID: 2963
		private int[] int_16;

		// Token: 0x04000B94 RID: 2964
		private int[] int_17;

		// Token: 0x04000B95 RID: 2965
		private int[] int_18;

		// Token: 0x04000B96 RID: 2966
		private int[] int_19;

		// Token: 0x04000B97 RID: 2967
		private int[] int_20;

		// Token: 0x04000B98 RID: 2968
		private int[] int_21;

		// Token: 0x04000B99 RID: 2969
		private int[] int_22;

		// Token: 0x04000B9A RID: 2970
		private int[] int_23;

		// Token: 0x04000B9B RID: 2971
		private int int_24;

		// Token: 0x04000B9C RID: 2972
		private int int_25;

		// Token: 0x04000B9D RID: 2973
		private LogicProjectileData[] logicProjectileData_0;

		// Token: 0x04000B9E RID: 2974
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000B9F RID: 2975
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000BA0 RID: 2976
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000BA1 RID: 2977
		private LogicEffectData logicEffectData_2;

		// Token: 0x04000BA2 RID: 2978
		private LogicEffectData logicEffectData_3;

		// Token: 0x04000BA3 RID: 2979
		private LogicEffectData logicEffectData_4;

		// Token: 0x04000BA4 RID: 2980
		private LogicEffectData logicEffectData_5;

		// Token: 0x04000BA5 RID: 2981
		private LogicEffectData logicEffectData_6;

		// Token: 0x04000BA6 RID: 2982
		private LogicEffectData logicEffectData_7;

		// Token: 0x04000BA7 RID: 2983
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000BA8 RID: 2984
		private LogicCharacterData logicCharacterData_1;

		// Token: 0x04000BA9 RID: 2985
		private LogicCharacterData logicCharacterData_2;

		// Token: 0x04000BAA RID: 2986
		private LogicResourceData logicResourceData_0;
	}
}
