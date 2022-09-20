using System;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013B RID: 315
	public class LogicAttackerItemData
	{
		// Token: 0x060010C0 RID: 4288 RVA: 0x0004AB9C File Offset: 0x00048D9C
		public void CreateReferences(CSVRow row, LogicData data, int idx)
		{
			this.csvrow_0 = row;
			this.logicData_0 = data;
			this.int_0 = idx;
			this.int_1 = row.GetClampedIntegerValue("PushBack", idx);
			this.bool_0 = row.GetClampedBooleanValue("AirTargets", idx);
			this.bool_1 = row.GetClampedBooleanValue("GroundTargets", idx);
			this.bool_2 = row.GetClampedBooleanValue("AltAttackMode", idx);
			this.int_2 = 100 * row.GetClampedIntegerValue("Damage", idx);
			int clampedIntegerValue = row.GetClampedIntegerValue("DPS", idx);
			int clampedIntegerValue2 = row.GetClampedIntegerValue("AttackSpeed", idx);
			int num = row.GetClampedIntegerValue("AltDPS", idx);
			int num2 = row.GetClampedIntegerValue("AltAttackSpeed", idx);
			if (this.bool_2 && num2 == 0)
			{
				num2 = clampedIntegerValue2;
			}
			int num3 = row.GetClampedIntegerValue("CoolDownOverride", idx);
			if (num3 == 0)
			{
				int num4 = (int)((long)((clampedIntegerValue | this.int_2) >> 31) & 4294965996L) + 1500;
				if (clampedIntegerValue2 > num4)
				{
					num3 = clampedIntegerValue2 - num4;
				}
			}
			this.int_6 = row.GetClampedIntegerValue("PrepareSpeed", idx);
			this.int_3 = clampedIntegerValue2 - num3;
			this.int_4 = num2 - num3;
			this.int_5 = num3;
			this.int_7 = 100 * row.GetClampedIntegerValue("DamageMulti", idx);
			this.int_8 = 100 * row.GetClampedIntegerValue("DamageLv2", idx);
			this.int_9 = 100 * row.GetClampedIntegerValue("DamageLv3", idx);
			this.int_10 = this.int_2;
			if (clampedIntegerValue != 0)
			{
				if (num == 0)
				{
					num = clampedIntegerValue;
				}
				this.int_2 = LogicGamePlayUtil.DPSToSingleHit(clampedIntegerValue, this.int_3 + this.int_5);
				this.int_10 = LogicGamePlayUtil.DPSToSingleHit(num, this.int_4 + this.int_5);
				this.int_7 = LogicGamePlayUtil.DPSToSingleHit(row.GetClampedIntegerValue("DPSMulti", idx), this.int_3 + this.int_5);
				this.int_8 = LogicGamePlayUtil.DPSToSingleHit(row.GetClampedIntegerValue("DPSLv2", idx), this.int_3 + this.int_5);
				this.int_9 = LogicGamePlayUtil.DPSToSingleHit(row.GetClampedIntegerValue("DPSLv3", idx), this.int_3 + this.int_5);
			}
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(row.GetClampedValue("HitEffect", idx), data);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(row.GetClampedValue("HitEffect2", idx), data);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(row.GetClampedValue("HitEffectActive", idx), data);
			this.int_11 = (row.GetClampedIntegerValue("AttackRange", idx) << 9) / 100;
			this.int_12 = (row.GetClampedIntegerValue("DamageRadius", idx) << 9) / 100;
			this.logicEffectData_3 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffect", idx), data);
			this.logicEffectData_5 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectAlt", idx), data);
			this.int_13 = row.GetClampedIntegerValue("AmmoCount", idx);
			this.logicEffectData_4 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffect2", idx), data);
			this.logicEffectData_6 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectLv2", idx), data);
			this.logicEffectData_7 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectLv3", idx), data);
			this.logicEffectData_8 = LogicDataTables.GetEffectByName(row.GetClampedValue("TransitionEffectLv2", idx), data);
			this.logicEffectData_9 = LogicDataTables.GetEffectByName(row.GetClampedValue("TransitionEffectLv3", idx), data);
			this.int_14 = row.GetClampedIntegerValue("AltNumMultiTargets", idx);
			this.int_15 = row.GetClampedIntegerValue("Lv2SwitchTime", idx);
			this.int_16 = row.GetClampedIntegerValue("Lv3SwitchTime", idx);
			this.int_17 = row.GetClampedIntegerValue("StatusEffectTime", idx);
			this.int_18 = row.GetClampedIntegerValue("SpeedMod", idx);
			this.int_19 = (row.GetClampedIntegerValue("AltAttackRange", idx) << 9) / 100;
			this.logicProjectileData_0 = LogicDataTables.GetProjectileByName(row.GetClampedValue("Projectile", idx), data);
			this.logicProjectileData_1 = LogicDataTables.GetProjectileByName(row.GetClampedValue("AltProjectile", idx), data);
			this.int_20 = row.GetClampedIntegerValue("ShockwavePushStrength", idx);
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(row.GetClampedValue("HitSpell", idx), data);
			this.int_21 = row.GetClampedIntegerValue("HitSpellLevel", idx);
			this.int_22 = 100 * row.GetClampedIntegerValue("Damage2", idx);
			this.int_23 = (row.GetClampedIntegerValue("Damage2Radius", idx) << 9) / 100;
			this.int_24 = row.GetClampedIntegerValue("Damage2Delay", idx);
			this.int_25 = 100 * row.GetClampedIntegerValue("Damage2Min", idx);
			this.int_26 = (row.GetClampedIntegerValue("Damage2FalloffStart", idx) << 9) / 100;
			this.int_27 = (row.GetClampedIntegerValue("Damage2FalloffStart", idx) << 9) / 100;
			if (this.int_27 < this.int_26)
			{
				Debugger.Error("Building " + row.GetName() + " has falloff end less than falloff start!");
			}
			if (this.int_27 > this.int_23)
			{
				Debugger.Error("Building " + row.GetName() + " has falloff end greater than the damage radius!");
			}
			this.logicEffectData_10 = LogicDataTables.GetEffectByName(row.GetClampedValue("PreAttackEffect", idx), data);
			this.logicEffectData_11 = LogicDataTables.GetEffectByName(row.GetClampedValue("BecomesTargetableEffect", idx), data);
			this.bool_4 = row.GetClampedBooleanValue("IncreasingDamage", idx);
			this.bool_5 = row.GetClampedBooleanValue("PreventsHealing", idx);
			this.int_28 = row.GetClampedIntegerValue("AlternatePickNewTargetDelay", idx);
			this.int_29 = row.GetClampedIntegerValue("ShockwaveArcLength", idx);
			this.int_30 = row.GetClampedIntegerValue("ShockwaveExpandRadius", idx);
			this.int_31 = row.GetClampedIntegerValue("TargetingConeAngle", idx);
			this.bool_6 = row.GetClampedBooleanValue("PenetratingProjectile", idx);
			this.int_32 = (row.GetClampedIntegerValue("PenetratingRadius", idx) << 9) / 100;
			this.int_33 = (row.GetClampedIntegerValue("PenetratingExtraRange", idx) << 9) / 100;
			this.bool_7 = row.GetClampedBooleanValue("TargetGroups", idx);
			this.bool_8 = row.GetClampedBooleanValue("FightWithGroups", idx);
			this.int_34 = (row.GetClampedIntegerValue("TargetGroupsRadius", idx) << 9) / 100;
			this.int_35 = (row.GetClampedIntegerValue("TargetGroupsRange", idx) << 9) / 100;
			this.int_36 = row.GetClampedIntegerValue("TargetGroupsMinWeight", idx);
			this.int_37 = row.GetClampedIntegerValue("WakeUpSpace", idx);
			this.int_38 = row.GetClampedIntegerValue("WakeUpSpeed", idx);
			this.logicData_1 = LogicDataTables.GetCharacterByName(row.GetClampedValue("PreferredTarget", idx), data);
			this.int_39 = row.GetClampedIntegerValue("PreferredTargetDamageMod", idx);
			this.bool_9 = row.GetClampedBooleanValue("PreferredTargetNoTargeting", idx);
			this.bool_10 = row.GetClampedBooleanValue("AltAirTargets", idx);
			this.bool_11 = row.GetClampedBooleanValue("AltGroundTargets", idx);
			this.bool_12 = row.GetClampedBooleanValue("AltMultiTargets", idx);
			this.int_40 = (row.GetClampedIntegerValue("MinAttackRange", idx) << 9) / 100;
			if (this.logicData_1 == null)
			{
				this.logicData_1 = LogicDataTables.GetBuildingClassByName(row.GetClampedValue("PreferedTargetBuildingClass", idx), data);
				if (this.logicData_1 == null)
				{
					this.logicData_1 = LogicDataTables.GetBuildingByName(row.GetClampedValue("PreferedTargetBuilding", idx), data);
				}
				this.int_39 = row.GetClampedIntegerValue("PreferedTargetDamageMod", idx);
				if (this.int_39 == 0)
				{
					this.int_39 = 100;
				}
			}
			this.int_41 = row.GetClampedIntegerValue("SummonTroopCount", idx);
			this.int_42 = row.GetClampedIntegerValue("SummonCooldown", idx);
			this.logicEffectData_13 = LogicDataTables.GetEffectByName(row.GetClampedValue("SummonEffect", idx), data);
			this.int_43 = row.GetClampedIntegerValue("SummonLimit", idx);
			this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(row.GetClampedValue("SummonTroop", idx), data);
			this.bool_13 = row.GetClampedBooleanValue("SpawnOnAttack", idx);
			this.logicEffectData_12 = LogicDataTables.GetEffectByName(row.GetClampedValue("HideEffect", idx), data);
			this.logicProjectileData_2 = LogicDataTables.GetProjectileByName(row.GetClampedValue("RageProjectile", idx), data);
			this.int_44 = row.GetClampedIntegerValue("ProjectileBounces", idx);
			this.bool_3 = row.GetClampedBooleanValue("SelfAsAoeCenter", idx);
			if (this.int_24 > this.int_5 + this.int_3)
			{
				Debugger.Error(row.GetName() + " has Damage2Delay greater than the attack speed!");
			}
			if (this.int_13 > 0 && (this.int_3 & 63) != 0)
			{
				Debugger.Error(string.Format("Invalid attack speed {0} (must be multiple of 64)", this.int_3));
			}
			this.int_45 = row.GetClampedIntegerValue("BurstCount", idx);
			this.int_46 = row.GetClampedIntegerValue("BurstDelay", idx);
			this.int_47 = row.GetClampedIntegerValue("AltBurstCount", idx);
			this.int_48 = row.GetClampedIntegerValue("AltBurstDelay", idx);
			this.int_49 = row.GetClampedIntegerValue("DummyProjectileCount", idx);
			this.logicEffectData_14 = LogicDataTables.GetEffectByName(row.GetClampedValue("AttackEffectShared", idx), data);
			this.int_50 = row.GetClampedIntegerValue("ChainAttackDistance", idx);
			this.int_51 = row.GetClampedIntegerValue("NewTargetAttackDelay", idx);
			if (this.int_51 > 0)
			{
				this.int_51 = LogicMath.Clamp(clampedIntegerValue2 - this.int_51, 0, clampedIntegerValue2);
			}
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x0000B4A8 File Offset: 0x000096A8
		public int GetDamage(int type, bool multi)
		{
			if (multi)
			{
				return this.int_7;
			}
			Debugger.DoAssert(type < 3, string.Empty);
			if (type == 1)
			{
				return this.int_8;
			}
			if (type != 2)
			{
				return this.int_2;
			}
			return this.int_9;
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x0000B4DF File Offset: 0x000096DF
		public int GetAltDamage(int level, bool alt)
		{
			Debugger.DoAssert(level < 3, string.Empty);
			if (alt)
			{
				return this.int_7;
			}
			return this.int_10;
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0004B4CC File Offset: 0x000496CC
		public int GetDamagePerMS(int type, bool multi)
		{
			int damage = this.GetDamage(type, multi);
			int num = this.int_3 + this.int_5;
			if (num != 0)
			{
				return 1000 * damage / (100 * num);
			}
			return 0;
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0000B500 File Offset: 0x00009700
		public int GetDamage2()
		{
			return this.int_22;
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0000B508 File Offset: 0x00009708
		public int GetDamage2Delay()
		{
			return this.int_24;
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0000B510 File Offset: 0x00009710
		public int GetAttackCooldownOverride()
		{
			return this.int_5;
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x0000B518 File Offset: 0x00009718
		public int GetShockwavePushStrength()
		{
			return this.int_20;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x0000B520 File Offset: 0x00009720
		public LogicSpellData GetHitSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0000B528 File Offset: 0x00009728
		public bool HasAlternativeAttackMode()
		{
			return this.bool_2;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0000B530 File Offset: 0x00009730
		public int GetAmmoCount()
		{
			return this.int_13;
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0000B538 File Offset: 0x00009738
		public int GetTargetingConeAngle()
		{
			return this.int_31;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0000B540 File Offset: 0x00009740
		public LogicData GetPreferredTargetData()
		{
			return this.logicData_1;
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0000B548 File Offset: 0x00009748
		public LogicEffectData GetHitEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x0000B550 File Offset: 0x00009750
		public LogicEffectData GetHitEffect2()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x0000B558 File Offset: 0x00009758
		public LogicEffectData GetHitEffectActive()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x0000B560 File Offset: 0x00009760
		public LogicEffectData GetAttackEffect()
		{
			return this.logicEffectData_3;
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x0000B568 File Offset: 0x00009768
		public LogicEffectData GetAttackEffect2()
		{
			return this.logicEffectData_4;
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x0000B570 File Offset: 0x00009770
		public LogicEffectData GetAltAttackEffect()
		{
			return this.logicEffectData_5;
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x0000B578 File Offset: 0x00009778
		public LogicEffectData GetAttackEffectLv2()
		{
			return this.logicEffectData_6;
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x0000B580 File Offset: 0x00009780
		public LogicEffectData GetAttackEffectLv3()
		{
			return this.logicEffectData_7;
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0000B588 File Offset: 0x00009788
		public LogicEffectData GetTransitionEffectLv2()
		{
			return this.logicEffectData_8;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x0000B590 File Offset: 0x00009790
		public LogicEffectData GetTransitionEffectLv3()
		{
			return this.logicEffectData_9;
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0000B598 File Offset: 0x00009798
		public LogicEffectData GetPreAttackEffect()
		{
			return this.logicEffectData_10;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0000B5A0 File Offset: 0x000097A0
		public LogicEffectData GetBecomesTargetableEffect()
		{
			return this.logicEffectData_11;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0000B5A8 File Offset: 0x000097A8
		public LogicEffectData GetHideEffect()
		{
			return this.logicEffectData_12;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0000B5B0 File Offset: 0x000097B0
		public LogicEffectData GetSummonEffect()
		{
			return this.logicEffectData_13;
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0000B5B8 File Offset: 0x000097B8
		public LogicEffectData GetAttackEffectShared()
		{
			return this.logicEffectData_14;
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0000B5C0 File Offset: 0x000097C0
		public LogicProjectileData GetProjectile(bool alt)
		{
			if (alt)
			{
				return this.logicProjectileData_1;
			}
			return this.logicProjectileData_0;
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0000B5D2 File Offset: 0x000097D2
		public LogicCharacterData GetSummonTroop()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0000B5DA File Offset: 0x000097DA
		public LogicProjectileData GetRageProjectile()
		{
			return this.logicProjectileData_2;
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0000B5E2 File Offset: 0x000097E2
		public int GetPushBack()
		{
			return this.int_1;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0000B5EA File Offset: 0x000097EA
		public int GetAttackSpeed()
		{
			return this.int_3;
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0000B5F2 File Offset: 0x000097F2
		public int GetAltAttackSpeed()
		{
			return this.int_4;
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0000B5FA File Offset: 0x000097FA
		public int GetPrepareSpeed()
		{
			return this.int_6;
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0000B602 File Offset: 0x00009802
		public int GetAttackRange(bool alt)
		{
			if (alt)
			{
				return this.int_19;
			}
			return this.int_11;
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0000B614 File Offset: 0x00009814
		public int GetDamageRadius()
		{
			return this.int_12;
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0000B61C File Offset: 0x0000981C
		public int GetDamage2Radius()
		{
			return this.int_23;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0000B624 File Offset: 0x00009824
		public int GetAltNumMultiTargets()
		{
			return this.int_14;
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0000B62C File Offset: 0x0000982C
		public int GetSwitchTimeLv2()
		{
			return this.int_15;
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0000B634 File Offset: 0x00009834
		public int GetSwitchTimeLv3()
		{
			return this.int_16;
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0000B63C File Offset: 0x0000983C
		public int GetStatusEffectTime()
		{
			return this.int_17;
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0000B644 File Offset: 0x00009844
		public int GetSpeedMod()
		{
			return this.int_18;
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0000B64C File Offset: 0x0000984C
		public int GetHitSpellLevel()
		{
			return this.int_21;
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0000B654 File Offset: 0x00009854
		public int GetDamage2Min()
		{
			return this.int_25;
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0000B65C File Offset: 0x0000985C
		public int GetAlternatePickNewTargetDelay()
		{
			return this.int_28;
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x0000B664 File Offset: 0x00009864
		public int GetShockwaveArcLength()
		{
			return this.int_29;
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x0000B66C File Offset: 0x0000986C
		public int GetShockwaveExpandRadius()
		{
			return this.int_30;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0000B674 File Offset: 0x00009874
		public int GetPenetratingRadius()
		{
			return this.int_32;
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x0000B67C File Offset: 0x0000987C
		public int GetPenetratingExtraRange()
		{
			return this.int_33;
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0000B684 File Offset: 0x00009884
		public int GetTargetGroupsRadius()
		{
			return this.int_34;
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0000B68C File Offset: 0x0000988C
		public int GetTargetGroupsRange()
		{
			return this.int_35;
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x0000B694 File Offset: 0x00009894
		public int GetTargetGroupsMinWeight()
		{
			return this.int_36;
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x0000B69C File Offset: 0x0000989C
		public int GetWakeUpSpace()
		{
			return this.int_37;
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0000B6A4 File Offset: 0x000098A4
		public int GetWakeUpSpeed()
		{
			return this.int_38;
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x0000B6AC File Offset: 0x000098AC
		public int GetPreferredTargetDamageMod()
		{
			return this.int_39;
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x0000B6B4 File Offset: 0x000098B4
		public int GetMinAttackRange()
		{
			return this.int_40;
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x0000B6BC File Offset: 0x000098BC
		public int GetSummonTroopCount()
		{
			return this.int_41;
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x0000B6C4 File Offset: 0x000098C4
		public int GetSummonCooldown()
		{
			return this.int_42;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0000B6CC File Offset: 0x000098CC
		public int GetSummonLimit()
		{
			return this.int_43;
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x0000B6D4 File Offset: 0x000098D4
		public int GetProjectileBounces()
		{
			return this.int_44;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x0000B6DC File Offset: 0x000098DC
		public int GetBurstCount()
		{
			return this.int_45;
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x0000B6E4 File Offset: 0x000098E4
		public int GetBurstDelay()
		{
			return this.int_46;
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x0000B6EC File Offset: 0x000098EC
		public int GetAltBurstCount()
		{
			return this.int_47;
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x0000B6F4 File Offset: 0x000098F4
		public int GetAltBurstDelay()
		{
			return this.int_48;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x0000B6FC File Offset: 0x000098FC
		public int GetDummyProjectileCount()
		{
			return this.int_49;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x0000B704 File Offset: 0x00009904
		public int GetChainAttackDistance()
		{
			return this.int_50;
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0000B70C File Offset: 0x0000990C
		public int GetNewTargetAttackDelay()
		{
			return this.int_51;
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x0000B714 File Offset: 0x00009914
		public bool GetTrackAirTargets(bool alt)
		{
			if (alt)
			{
				return this.bool_10;
			}
			return this.bool_0;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0000B726 File Offset: 0x00009926
		public bool GetTrackGroundTargets(bool alt)
		{
			return this.bool_1;
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x0000B72E File Offset: 0x0000992E
		public bool IsSelfAsAoeCenter()
		{
			return this.bool_3;
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x0000B736 File Offset: 0x00009936
		public bool IsIncreasingDamage()
		{
			return this.bool_4;
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x0000B73E File Offset: 0x0000993E
		public bool GetPreventsHealing()
		{
			return this.bool_5;
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x0000B746 File Offset: 0x00009946
		public bool IsPenetratingProjectile()
		{
			return this.bool_6;
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0000B74E File Offset: 0x0000994E
		public bool GetTargetGroups()
		{
			return this.bool_7;
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x0000B756 File Offset: 0x00009956
		public bool GetFightWithGroups()
		{
			return this.bool_8;
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0000B75E File Offset: 0x0000995E
		public bool GetPreferredTargetNoTargeting()
		{
			return this.bool_9;
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x0000B766 File Offset: 0x00009966
		public bool GetSpawnOnAttack()
		{
			return this.bool_13;
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0000B76E File Offset: 0x0000996E
		public bool GetMultiTargets(bool alt)
		{
			return alt && this.bool_12;
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0000B77B File Offset: 0x0000997B
		public LogicAttackerItemData Clone()
		{
			LogicAttackerItemData logicAttackerItemData = new LogicAttackerItemData();
			logicAttackerItemData.CreateReferences(this.csvrow_0, this.logicData_0, this.int_0);
			return logicAttackerItemData;
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x0000B79A File Offset: 0x0000999A
		public void AddAttackRange(int value)
		{
			this.int_11 += value;
			this.int_19 += value;
		}

		// Token: 0x040006FF RID: 1791
		private LogicData logicData_0;

		// Token: 0x04000700 RID: 1792
		private CSVRow csvrow_0;

		// Token: 0x04000701 RID: 1793
		private int int_0;

		// Token: 0x04000702 RID: 1794
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000703 RID: 1795
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000704 RID: 1796
		private LogicEffectData logicEffectData_2;

		// Token: 0x04000705 RID: 1797
		private LogicEffectData logicEffectData_3;

		// Token: 0x04000706 RID: 1798
		private LogicEffectData logicEffectData_4;

		// Token: 0x04000707 RID: 1799
		private LogicEffectData logicEffectData_5;

		// Token: 0x04000708 RID: 1800
		private LogicEffectData logicEffectData_6;

		// Token: 0x04000709 RID: 1801
		private LogicEffectData logicEffectData_7;

		// Token: 0x0400070A RID: 1802
		private LogicEffectData logicEffectData_8;

		// Token: 0x0400070B RID: 1803
		private LogicEffectData logicEffectData_9;

		// Token: 0x0400070C RID: 1804
		private LogicEffectData logicEffectData_10;

		// Token: 0x0400070D RID: 1805
		private LogicEffectData logicEffectData_11;

		// Token: 0x0400070E RID: 1806
		private LogicEffectData logicEffectData_12;

		// Token: 0x0400070F RID: 1807
		private LogicEffectData logicEffectData_13;

		// Token: 0x04000710 RID: 1808
		private LogicEffectData logicEffectData_14;

		// Token: 0x04000711 RID: 1809
		private LogicProjectileData logicProjectileData_0;

		// Token: 0x04000712 RID: 1810
		private LogicProjectileData logicProjectileData_1;

		// Token: 0x04000713 RID: 1811
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000714 RID: 1812
		private LogicData logicData_1;

		// Token: 0x04000715 RID: 1813
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x04000716 RID: 1814
		private LogicProjectileData logicProjectileData_2;

		// Token: 0x04000717 RID: 1815
		private int int_1;

		// Token: 0x04000718 RID: 1816
		private int int_2;

		// Token: 0x04000719 RID: 1817
		private int int_3;

		// Token: 0x0400071A RID: 1818
		private int int_4;

		// Token: 0x0400071B RID: 1819
		private int int_5;

		// Token: 0x0400071C RID: 1820
		private int int_6;

		// Token: 0x0400071D RID: 1821
		private int int_7;

		// Token: 0x0400071E RID: 1822
		private int int_8;

		// Token: 0x0400071F RID: 1823
		private int int_9;

		// Token: 0x04000720 RID: 1824
		private int int_10;

		// Token: 0x04000721 RID: 1825
		private int int_11;

		// Token: 0x04000722 RID: 1826
		private int int_12;

		// Token: 0x04000723 RID: 1827
		private int int_13;

		// Token: 0x04000724 RID: 1828
		private int int_14;

		// Token: 0x04000725 RID: 1829
		private int int_15;

		// Token: 0x04000726 RID: 1830
		private int int_16;

		// Token: 0x04000727 RID: 1831
		private int int_17;

		// Token: 0x04000728 RID: 1832
		private int int_18;

		// Token: 0x04000729 RID: 1833
		private int int_19;

		// Token: 0x0400072A RID: 1834
		private int int_20;

		// Token: 0x0400072B RID: 1835
		private int int_21;

		// Token: 0x0400072C RID: 1836
		private int int_22;

		// Token: 0x0400072D RID: 1837
		private int int_23;

		// Token: 0x0400072E RID: 1838
		private int int_24;

		// Token: 0x0400072F RID: 1839
		private int int_25;

		// Token: 0x04000730 RID: 1840
		private int int_26;

		// Token: 0x04000731 RID: 1841
		private int int_27;

		// Token: 0x04000732 RID: 1842
		private int int_28;

		// Token: 0x04000733 RID: 1843
		private int int_29;

		// Token: 0x04000734 RID: 1844
		private int int_30;

		// Token: 0x04000735 RID: 1845
		private int int_31;

		// Token: 0x04000736 RID: 1846
		private int int_32;

		// Token: 0x04000737 RID: 1847
		private int int_33;

		// Token: 0x04000738 RID: 1848
		private int int_34;

		// Token: 0x04000739 RID: 1849
		private int int_35;

		// Token: 0x0400073A RID: 1850
		private int int_36;

		// Token: 0x0400073B RID: 1851
		private int int_37;

		// Token: 0x0400073C RID: 1852
		private int int_38;

		// Token: 0x0400073D RID: 1853
		private int int_39;

		// Token: 0x0400073E RID: 1854
		private int int_40;

		// Token: 0x0400073F RID: 1855
		private int int_41;

		// Token: 0x04000740 RID: 1856
		private int int_42;

		// Token: 0x04000741 RID: 1857
		private int int_43;

		// Token: 0x04000742 RID: 1858
		private int int_44;

		// Token: 0x04000743 RID: 1859
		private int int_45;

		// Token: 0x04000744 RID: 1860
		private int int_46;

		// Token: 0x04000745 RID: 1861
		private int int_47;

		// Token: 0x04000746 RID: 1862
		private int int_48;

		// Token: 0x04000747 RID: 1863
		private int int_49;

		// Token: 0x04000748 RID: 1864
		private int int_50;

		// Token: 0x04000749 RID: 1865
		private int int_51;

		// Token: 0x0400074A RID: 1866
		private bool bool_0;

		// Token: 0x0400074B RID: 1867
		private bool bool_1;

		// Token: 0x0400074C RID: 1868
		private bool bool_2;

		// Token: 0x0400074D RID: 1869
		private bool bool_3;

		// Token: 0x0400074E RID: 1870
		private bool bool_4;

		// Token: 0x0400074F RID: 1871
		private bool bool_5;

		// Token: 0x04000750 RID: 1872
		private bool bool_6;

		// Token: 0x04000751 RID: 1873
		private bool bool_7;

		// Token: 0x04000752 RID: 1874
		private bool bool_8;

		// Token: 0x04000753 RID: 1875
		private bool bool_9;

		// Token: 0x04000754 RID: 1876
		private bool bool_10;

		// Token: 0x04000755 RID: 1877
		private bool bool_11;

		// Token: 0x04000756 RID: 1878
		private bool bool_12;

		// Token: 0x04000757 RID: 1879
		private bool bool_13;
	}
}
