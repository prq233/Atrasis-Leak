using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000160 RID: 352
	public class LogicResourceData : LogicData
	{
		// Token: 0x060014CB RID: 5323 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicResourceData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x00051E84 File Offset: 0x00050084
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("StealEffect", 0), this);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("CollectEffect", 0), this);
			this.string_0 = base.GetValue("ResourceIconExportName", 0);
			this.int_0 = base.GetIntegerValue("StealLimitMid", 0);
			this.string_1 = base.GetValue("StealEffectMid", 0);
			this.int_1 = base.GetIntegerValue("StealLimitBig", 0);
			this.string_2 = base.GetValue("StealEffectBig", 0);
			this.bool_0 = base.GetBooleanValue("PremiumCurrency", 0);
			this.string_3 = base.GetValue("HudInstanceName", 0);
			this.string_4 = base.GetValue("CapFullTID", 0);
			this.int_2 = base.GetIntegerValue("TextRed", 0);
			this.int_3 = base.GetIntegerValue("TextGreen", 0);
			this.int_4 = base.GetIntegerValue("TextBlue", 0);
			this.string_5 = base.GetValue("BundleIconExportName", 0);
			this.int_5 = base.GetIntegerValue("VillageType", 0);
			if (this.int_5 >= 2)
			{
				Debugger.Error("invalid VillageType");
			}
			string value = base.GetValue("WarRefResource", 0);
			if (value.Length > 0)
			{
				this.logicResourceData_0 = LogicDataTables.GetResourceByName(value, this);
			}
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x0000D92E File Offset: 0x0000BB2E
		public LogicResourceData GetWarResourceReferenceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x0000D936 File Offset: 0x0000BB36
		public LogicEffectData GetCollectEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x0000D93E File Offset: 0x0000BB3E
		public string GetResourceIconExportName()
		{
			return this.string_0;
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x0000D946 File Offset: 0x0000BB46
		public LogicEffectData GetStealEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0000D94E File Offset: 0x0000BB4E
		public int GetStealLimitMid()
		{
			return this.int_0;
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x0000D956 File Offset: 0x0000BB56
		public string GetStealEffectMid()
		{
			return this.string_1;
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0000D95E File Offset: 0x0000BB5E
		public int GetStealLimitBig()
		{
			return this.int_1;
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0000D966 File Offset: 0x0000BB66
		public string GetStealEffectBig()
		{
			return this.string_2;
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x0000D96E File Offset: 0x0000BB6E
		public bool IsPremiumCurrency()
		{
			return this.bool_0;
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0000D976 File Offset: 0x0000BB76
		public string GetHudInstanceName()
		{
			return this.string_3;
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x0000D97E File Offset: 0x0000BB7E
		public string GetCapFullTID()
		{
			return this.string_4;
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0000D986 File Offset: 0x0000BB86
		public int GetTextRed()
		{
			return this.int_2;
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0000D98E File Offset: 0x0000BB8E
		public int GetTextGreen()
		{
			return this.int_3;
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x0000D996 File Offset: 0x0000BB96
		public int GetTextBlue()
		{
			return this.int_4;
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x0000D99E File Offset: 0x0000BB9E
		public string GetBundleIconExportName()
		{
			return this.string_5;
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0000D9A6 File Offset: 0x0000BBA6
		public int GetVillageType()
		{
			return this.int_5;
		}

		// Token: 0x04000B09 RID: 2825
		private string string_0;

		// Token: 0x04000B0A RID: 2826
		private string string_1;

		// Token: 0x04000B0B RID: 2827
		private string string_2;

		// Token: 0x04000B0C RID: 2828
		private string string_3;

		// Token: 0x04000B0D RID: 2829
		private string string_4;

		// Token: 0x04000B0E RID: 2830
		private string string_5;

		// Token: 0x04000B0F RID: 2831
		private int int_0;

		// Token: 0x04000B10 RID: 2832
		private int int_1;

		// Token: 0x04000B11 RID: 2833
		private int int_2;

		// Token: 0x04000B12 RID: 2834
		private int int_3;

		// Token: 0x04000B13 RID: 2835
		private int int_4;

		// Token: 0x04000B14 RID: 2836
		private int int_5;

		// Token: 0x04000B15 RID: 2837
		private bool bool_0;

		// Token: 0x04000B16 RID: 2838
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000B17 RID: 2839
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000B18 RID: 2840
		private LogicResourceData logicResourceData_0;
	}
}
