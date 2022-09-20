using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015E RID: 350
	public class LogicProjectileData : LogicGameObjectData
	{
		// Token: 0x060014A9 RID: 5289 RVA: 0x0000B477 File Offset: 0x00009677
		public LogicProjectileData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x00051C24 File Offset: 0x0004FE24
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("SWF", 0);
			this.string_1 = base.GetValue("ExportName", 0);
			this.string_2 = base.GetValue("ShadowSWF", 0);
			this.string_3 = base.GetValue("ShadowExportName", 0);
			this.int_0 = base.GetIntegerValue("StartHeight", 0);
			this.int_1 = base.GetIntegerValue("StartOffset", 0);
			this.bool_0 = base.GetBooleanValue("RandomHitPosition", 0);
			string value = base.GetValue("ParticleEmitter", 0);
			if (value.Length > 0)
			{
				this.logicParticleEmitterData_0 = LogicDataTables.GetParticleEmitterByName(value, this);
			}
			this.bool_1 = base.GetBooleanValue("IsBallistic", 0);
			this.int_2 = (base.GetIntegerValue("Speed", 0) << 9) / 100;
			this.bool_2 = base.GetBooleanValue("PlayOnce", 0);
			this.bool_3 = base.GetBooleanValue("UseRotate", 0);
			this.bool_4 = base.GetBooleanValue("UseTopLayer", 0);
			this.int_3 = base.GetIntegerValue("Scale", 0);
			if (this.int_3 == 0)
			{
				this.int_3 = 100;
			}
			this.int_4 = base.GetIntegerValue("SlowdownDefencePercent", 0);
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(base.GetValue("HitSpell", 0), this);
			this.int_5 = base.GetIntegerValue("HitSpellLevel", 0);
			this.bool_5 = !base.GetBooleanValue("DontTrackTarget", 0);
			this.int_6 = base.GetIntegerValue("BallisticHeight", 0);
			this.int_7 = base.GetIntegerValue("TrajectoryStyle", 0);
			this.int_8 = base.GetIntegerValue("FixedTravelTime", 0);
			this.int_9 = base.GetIntegerValue("DamageDelay", 0);
			this.bool_6 = base.GetBooleanValue("UseDirections", 0);
			this.bool_7 = base.GetBooleanValue("ScaleTimeline", 0);
			this.int_10 = base.GetIntegerValue("TargetPosRandomRadius", 0);
			this.bool_8 = base.GetBooleanValue("DirectionFrame", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("Effect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("DestroyedEffect", 0), this);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(base.GetValue("BounceEffect", 0), this);
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x0000D83E File Offset: 0x0000BA3E
		public LogicSpellData GetHitSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x0000D846 File Offset: 0x0000BA46
		public LogicEffectData GetEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x0000D84E File Offset: 0x0000BA4E
		public LogicEffectData GetDestroyedEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x0000D856 File Offset: 0x0000BA56
		public LogicEffectData GetBounceEffect()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0000D85E File Offset: 0x0000BA5E
		public LogicParticleEmitterData GetParticleEmiter()
		{
			return this.logicParticleEmitterData_0;
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0000D866 File Offset: 0x0000BA66
		public string GetSwf()
		{
			return this.string_0;
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x0000D86E File Offset: 0x0000BA6E
		public string GetExportName()
		{
			return this.string_1;
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0000D876 File Offset: 0x0000BA76
		public string GetShadowSWF()
		{
			return this.string_2;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x0000D87E File Offset: 0x0000BA7E
		public string GetShadowExportName()
		{
			return this.string_3;
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0000D886 File Offset: 0x0000BA86
		public string GetParticleEmitter()
		{
			return this.string_4;
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x0000D88E File Offset: 0x0000BA8E
		public int GetStartHeight()
		{
			return this.int_0;
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x0000D896 File Offset: 0x0000BA96
		public int GetStartOffset()
		{
			return this.int_1;
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x0000D89E File Offset: 0x0000BA9E
		public int GetSpeed()
		{
			return this.int_2;
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0000D8A6 File Offset: 0x0000BAA6
		public int GetScale()
		{
			return this.int_3;
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0000D8AE File Offset: 0x0000BAAE
		public int GetSlowdownDefensePercent()
		{
			return this.int_4;
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0000D8B6 File Offset: 0x0000BAB6
		public int GetHitSpellLevel()
		{
			return this.int_5;
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0000D8BE File Offset: 0x0000BABE
		public int GetBallisticHeight()
		{
			return this.int_6;
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x0000D8C6 File Offset: 0x0000BAC6
		public int GetTrajectoryStyle()
		{
			return this.int_7;
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0000D8CE File Offset: 0x0000BACE
		public int GetFixedTravelTime()
		{
			return this.int_8;
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0000D8D6 File Offset: 0x0000BAD6
		public int GetDamageDelay()
		{
			return this.int_9;
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0000D8DE File Offset: 0x0000BADE
		public int GetTargetPosRandomRadius()
		{
			return this.int_10;
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0000D8E6 File Offset: 0x0000BAE6
		public bool GetRandomHitPosition()
		{
			return this.bool_0;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0000D8EE File Offset: 0x0000BAEE
		public bool IsBallistic()
		{
			return this.bool_1;
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0000D8F6 File Offset: 0x0000BAF6
		public bool GetPlayOnce()
		{
			return this.bool_2;
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0000D8FE File Offset: 0x0000BAFE
		public bool GetUseRotate()
		{
			return this.bool_3;
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0000D906 File Offset: 0x0000BB06
		public bool GetUseTopLayer()
		{
			return this.bool_4;
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0000D90E File Offset: 0x0000BB0E
		public bool GetTrackTarget()
		{
			return this.bool_5;
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0000D916 File Offset: 0x0000BB16
		public bool GetUseDirection()
		{
			return this.bool_6;
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x0000D91E File Offset: 0x0000BB1E
		public bool GetScaleTimeline()
		{
			return this.bool_7;
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0000D926 File Offset: 0x0000BB26
		public bool GetDirectionFrame()
		{
			return this.bool_8;
		}

		// Token: 0x04000AEB RID: 2795
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000AEC RID: 2796
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000AED RID: 2797
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000AEE RID: 2798
		private LogicEffectData logicEffectData_2;

		// Token: 0x04000AEF RID: 2799
		private LogicParticleEmitterData logicParticleEmitterData_0;

		// Token: 0x04000AF0 RID: 2800
		private string string_0;

		// Token: 0x04000AF1 RID: 2801
		private string string_1;

		// Token: 0x04000AF2 RID: 2802
		private string string_2;

		// Token: 0x04000AF3 RID: 2803
		private string string_3;

		// Token: 0x04000AF4 RID: 2804
		private string string_4;

		// Token: 0x04000AF5 RID: 2805
		private int int_0;

		// Token: 0x04000AF6 RID: 2806
		private int int_1;

		// Token: 0x04000AF7 RID: 2807
		private int int_2;

		// Token: 0x04000AF8 RID: 2808
		private int int_3;

		// Token: 0x04000AF9 RID: 2809
		private int int_4;

		// Token: 0x04000AFA RID: 2810
		private int int_5;

		// Token: 0x04000AFB RID: 2811
		private int int_6;

		// Token: 0x04000AFC RID: 2812
		private int int_7;

		// Token: 0x04000AFD RID: 2813
		private int int_8;

		// Token: 0x04000AFE RID: 2814
		private int int_9;

		// Token: 0x04000AFF RID: 2815
		private int int_10;

		// Token: 0x04000B00 RID: 2816
		private bool bool_0;

		// Token: 0x04000B01 RID: 2817
		private bool bool_1;

		// Token: 0x04000B02 RID: 2818
		private bool bool_2;

		// Token: 0x04000B03 RID: 2819
		private bool bool_3;

		// Token: 0x04000B04 RID: 2820
		private bool bool_4;

		// Token: 0x04000B05 RID: 2821
		private bool bool_5;

		// Token: 0x04000B06 RID: 2822
		private bool bool_6;

		// Token: 0x04000B07 RID: 2823
		private bool bool_7;

		// Token: 0x04000B08 RID: 2824
		private bool bool_8;
	}
}
