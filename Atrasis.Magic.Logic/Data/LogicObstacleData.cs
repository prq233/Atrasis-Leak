using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015C RID: 348
	public class LogicObstacleData : LogicGameObjectData
	{
		// Token: 0x0600147D RID: 5245 RVA: 0x0000B477 File Offset: 0x00009677
		public LogicObstacleData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x00051890 File Offset: 0x0004FA90
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("ExportName", 0);
			this.string_1 = base.GetValue("ExportNameBase", 0);
			this.int_5 = base.GetIntegerValue("Width", 0);
			this.int_6 = base.GetIntegerValue("Height", 0);
			this.bool_0 = base.GetBooleanValue("Passable", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("ClearEffect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("PickUpEffect", 0), this);
			this.bool_1 = base.GetBooleanValue("IsTombstone", 0);
			this.int_7 = base.GetIntegerValue("TombGroup", 0);
			this.int_8 = base.GetIntegerValue("AppearancePeriodHours", 0);
			this.int_9 = base.GetIntegerValue("MinRespawnTimeHours", 0);
			this.int_15 = base.GetIntegerValue("LootDefensePercentage", 0);
			this.int_16 = base.GetIntegerValue("RedMul", 0);
			this.int_17 = base.GetIntegerValue("GreenMul", 0);
			this.int_18 = base.GetIntegerValue("BlueMul", 0);
			this.int_19 = base.GetIntegerValue("RedAdd", 0);
			this.int_20 = base.GetIntegerValue("GreenAdd", 0);
			this.int_21 = base.GetIntegerValue("BlueAdd", 0);
			this.bool_2 = base.GetBooleanValue("LightsOn", 0);
			this.int_22 = base.GetIntegerValue("Village2RespawnCount", 0);
			this.int_23 = base.GetIntegerValue("VariationCount", 0);
			this.bool_3 = base.GetBooleanValue("TallGrass", 0);
			this.bool_4 = base.GetBooleanValue("TallGrassSpawnPoint", 0);
			this.int_24 = base.GetIntegerValue("LootHighlightPercentage", 0);
			this.string_2 = base.GetValue("HighlightExportName", 0);
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("ClearResource", 0), this);
			if (this.logicResourceData_0 == null)
			{
				Debugger.Error("Clear resource is not defined for obstacle: " + base.GetName());
			}
			this.int_1 = base.GetIntegerValue("ClearCost", 0);
			this.int_2 = base.GetIntegerValue("ClearTimeSeconds", 0);
			this.int_3 = base.GetIntegerValue("RespawnWeight", 0);
			string value = base.GetValue("LootResource", 0);
			if (value.Length <= 0)
			{
				this.int_3 = 0;
			}
			else
			{
				this.logicResourceData_1 = LogicDataTables.GetResourceByName(value, this);
				this.int_0 = base.GetIntegerValue("LootCount", 0);
			}
			this.int_4 = base.GetIntegerValue("LootMultiplierForVersion2", 0);
			if (this.int_4 == 0)
			{
				this.int_4 = 1;
			}
			string value2 = base.GetValue("SpawnObstacle", 0);
			if (value2.Length > 0)
			{
				this.logicObstacleData_0 = LogicDataTables.GetObstacleByName(value2, this);
				this.int_10 = base.GetIntegerValue("SpawnRadius", 0);
				this.int_11 = base.GetIntegerValue("SpawnIntervalSeconds", 0);
				this.int_12 = base.GetIntegerValue("SpawnCount", 0);
				this.int_13 = base.GetIntegerValue("MaxSpawned", 0);
				this.int_14 = base.GetIntegerValue("MaxLifetimeSpawns", 0);
			}
		}

		// Token: 0x0600147F RID: 5247 RVA: 0x00051BB8 File Offset: 0x0004FDB8
		public override void CreateReferences2()
		{
			if (this.logicResourceData_1 != null && this.logicResourceData_1.GetVillageType() != base.GetVillageType() && !this.logicResourceData_1.IsPremiumCurrency())
			{
				Debugger.Error("invalid resource");
			}
			if (this.logicResourceData_0.GetVillageType() != base.GetVillageType() && !this.logicResourceData_0.IsPremiumCurrency())
			{
				Debugger.Error("invalid clear resource");
			}
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0000D703 File Offset: 0x0000B903
		public int GetRespawnWeight()
		{
			return this.int_3;
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x0000D70B File Offset: 0x0000B90B
		public int GetClearTime()
		{
			return this.int_2;
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0000D713 File Offset: 0x0000B913
		public LogicResourceData GetClearResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x0000D71B File Offset: 0x0000B91B
		public LogicResourceData GetLootResourceData()
		{
			return this.logicResourceData_1;
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0000D723 File Offset: 0x0000B923
		public int GetLootCount()
		{
			return this.int_0;
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x0000D72B File Offset: 0x0000B92B
		public int GetClearCost()
		{
			return this.int_1;
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x0000D733 File Offset: 0x0000B933
		public int GetLootMultiplierVersion2()
		{
			return this.int_4;
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x0000D73B File Offset: 0x0000B93B
		public bool IsLootCart()
		{
			return this.int_15 > 0;
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0000D746 File Offset: 0x0000B946
		public string GetExportName()
		{
			return this.string_0;
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0000D74E File Offset: 0x0000B94E
		public string GetExportNameBase()
		{
			return this.string_1;
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0000D756 File Offset: 0x0000B956
		public int GetWidth()
		{
			return this.int_5;
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0000D75E File Offset: 0x0000B95E
		public int GetHeight()
		{
			return this.int_6;
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x0000D766 File Offset: 0x0000B966
		public bool IsPassable()
		{
			return this.bool_0;
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0000D76E File Offset: 0x0000B96E
		public int GetTombGroup()
		{
			return this.int_7;
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0000D776 File Offset: 0x0000B976
		public LogicEffectData GetClearEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x0000D77E File Offset: 0x0000B97E
		public LogicEffectData GetPickUpEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x0000D786 File Offset: 0x0000B986
		public LogicObstacleData GetSpawnObstacle()
		{
			return this.logicObstacleData_0;
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0000D78E File Offset: 0x0000B98E
		public bool IsTombstone()
		{
			return this.bool_1;
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0000D796 File Offset: 0x0000B996
		public int GetAppearancePeriodHours()
		{
			return this.int_8;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0000D79E File Offset: 0x0000B99E
		public int GetMinRespawnTimeHours()
		{
			return this.int_9;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0000D7A6 File Offset: 0x0000B9A6
		public int GetSpawnRadius()
		{
			return this.int_10;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0000D7AE File Offset: 0x0000B9AE
		public int GetSpawnIntervalSeconds()
		{
			return this.int_11;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x0000D7B6 File Offset: 0x0000B9B6
		public int GetSpawnCount()
		{
			return this.int_12;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0000D7BE File Offset: 0x0000B9BE
		public int GetMaxSpawned()
		{
			return this.int_13;
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x0000D7C6 File Offset: 0x0000B9C6
		public int GetMaxLifetimeSpawns()
		{
			return this.int_14;
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0000D7CE File Offset: 0x0000B9CE
		public int GetLootDefensePercentage()
		{
			return this.int_15;
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x0000D7D6 File Offset: 0x0000B9D6
		public int GetRedMul()
		{
			return this.int_16;
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0000D7DE File Offset: 0x0000B9DE
		public int GetGreenMul()
		{
			return this.int_17;
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0000D7E6 File Offset: 0x0000B9E6
		public int GetBlueMul()
		{
			return this.int_18;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0000D7EE File Offset: 0x0000B9EE
		public int GetRedAdd()
		{
			return this.int_19;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x0000D7F6 File Offset: 0x0000B9F6
		public int GetGreenAdd()
		{
			return this.int_20;
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x0000D7FE File Offset: 0x0000B9FE
		public int GetBlueAdd()
		{
			return this.int_21;
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x0000D806 File Offset: 0x0000BA06
		public bool IsLightsOn()
		{
			return this.bool_2;
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x0000D80E File Offset: 0x0000BA0E
		public int GetVillage2RespawnCount()
		{
			return this.int_22;
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0000D816 File Offset: 0x0000BA16
		public int GetVariationCount()
		{
			return this.int_23;
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x0000D81E File Offset: 0x0000BA1E
		public bool IsTallGrass()
		{
			return this.bool_3;
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x0000D826 File Offset: 0x0000BA26
		public bool IsTallGrassSpawnPoint()
		{
			return this.bool_4;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x0000D82E File Offset: 0x0000BA2E
		public int GetLootHighlightPercentage()
		{
			return this.int_24;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x0000D836 File Offset: 0x0000BA36
		public string GetHighlightExportName()
		{
			return this.string_2;
		}

		// Token: 0x04000AC5 RID: 2757
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000AC6 RID: 2758
		private LogicResourceData logicResourceData_1;

		// Token: 0x04000AC7 RID: 2759
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000AC8 RID: 2760
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000AC9 RID: 2761
		private LogicObstacleData logicObstacleData_0;

		// Token: 0x04000ACA RID: 2762
		private string string_0;

		// Token: 0x04000ACB RID: 2763
		private string string_1;

		// Token: 0x04000ACC RID: 2764
		private string string_2;

		// Token: 0x04000ACD RID: 2765
		private bool bool_0;

		// Token: 0x04000ACE RID: 2766
		private bool bool_1;

		// Token: 0x04000ACF RID: 2767
		private bool bool_2;

		// Token: 0x04000AD0 RID: 2768
		private bool bool_3;

		// Token: 0x04000AD1 RID: 2769
		private bool bool_4;

		// Token: 0x04000AD2 RID: 2770
		private int int_0;

		// Token: 0x04000AD3 RID: 2771
		private int int_1;

		// Token: 0x04000AD4 RID: 2772
		private int int_2;

		// Token: 0x04000AD5 RID: 2773
		private int int_3;

		// Token: 0x04000AD6 RID: 2774
		private int int_4;

		// Token: 0x04000AD7 RID: 2775
		private int int_5;

		// Token: 0x04000AD8 RID: 2776
		private int int_6;

		// Token: 0x04000AD9 RID: 2777
		private int int_7;

		// Token: 0x04000ADA RID: 2778
		private int int_8;

		// Token: 0x04000ADB RID: 2779
		private int int_9;

		// Token: 0x04000ADC RID: 2780
		private int int_10;

		// Token: 0x04000ADD RID: 2781
		private int int_11;

		// Token: 0x04000ADE RID: 2782
		private int int_12;

		// Token: 0x04000ADF RID: 2783
		private int int_13;

		// Token: 0x04000AE0 RID: 2784
		private int int_14;

		// Token: 0x04000AE1 RID: 2785
		private int int_15;

		// Token: 0x04000AE2 RID: 2786
		private int int_16;

		// Token: 0x04000AE3 RID: 2787
		private int int_17;

		// Token: 0x04000AE4 RID: 2788
		private int int_18;

		// Token: 0x04000AE5 RID: 2789
		private int int_19;

		// Token: 0x04000AE6 RID: 2790
		private int int_20;

		// Token: 0x04000AE7 RID: 2791
		private int int_21;

		// Token: 0x04000AE8 RID: 2792
		private int int_22;

		// Token: 0x04000AE9 RID: 2793
		private int int_23;

		// Token: 0x04000AEA RID: 2794
		private int int_24;
	}
}
