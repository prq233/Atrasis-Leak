using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000158 RID: 344
	public class LogicLocaleData : LogicData
	{
		// Token: 0x0600141D RID: 5149 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicLocaleData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x00050C24 File Offset: 0x0004EE24
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("FileName", 0);
			this.string_1 = base.GetValue("LocalizedName", 0);
			this.bool_0 = base.GetBooleanValue("HasEvenSpaceCharacters", 0);
			this.bool_1 = base.GetBooleanValue("isRTL", 0);
			this.string_2 = base.GetValue("UsedSystemFont", 0);
			this.string_3 = base.GetValue("HelpshiftSDKLanguage", 0);
			this.string_4 = base.GetValue("HelpshiftSDKLanguageAndroid", 0);
			this.int_0 = base.GetIntegerValue("SortOrder", 0);
			this.bool_2 = base.GetBooleanValue("TestLanguage", 0);
			this.bool_3 = base.GetBooleanValue("BoomboxEnabled", 0);
			this.string_5 = base.GetValue("BoomboxUrl", 0);
			this.string_6 = base.GetValue("BoomboxStagingUrl", 0);
			this.string_7 = base.GetValue("HelpshiftLanguageTagOverride", 0);
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x0000D41F File Offset: 0x0000B61F
		public string GetFileName()
		{
			return this.string_0;
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x0000D427 File Offset: 0x0000B627
		public string GetLocalizedName()
		{
			return this.string_1;
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0000D42F File Offset: 0x0000B62F
		public bool IsHasEvenSpaceCharacters()
		{
			return this.bool_0;
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x0000D437 File Offset: 0x0000B637
		public bool IsRTL()
		{
			return this.bool_1;
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x0000D43F File Offset: 0x0000B63F
		public string GetUsedSystemFont()
		{
			return this.string_2;
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x0000D447 File Offset: 0x0000B647
		public string GetHelpshiftSDKLanguage()
		{
			return this.string_3;
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x0000D44F File Offset: 0x0000B64F
		public string GetHelpshiftSDKLanguageAndroid()
		{
			return this.string_4;
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x0000D457 File Offset: 0x0000B657
		public int GetSortOrder()
		{
			return this.int_0;
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x0000D45F File Offset: 0x0000B65F
		public bool IsTestLanguage()
		{
			return this.bool_2;
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x0000D467 File Offset: 0x0000B667
		public bool IsBoomboxEnabled()
		{
			return this.bool_3;
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x0000D46F File Offset: 0x0000B66F
		public string GetBoomboxUrl()
		{
			return this.string_5;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0000D477 File Offset: 0x0000B677
		public string GetBoomboxStagingUrl()
		{
			return this.string_6;
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0000D47F File Offset: 0x0000B67F
		public string GetHelpshiftLanguageTagOverride()
		{
			return this.string_7;
		}

		// Token: 0x04000A5C RID: 2652
		private string string_0;

		// Token: 0x04000A5D RID: 2653
		private string string_1;

		// Token: 0x04000A5E RID: 2654
		private string string_2;

		// Token: 0x04000A5F RID: 2655
		private string string_3;

		// Token: 0x04000A60 RID: 2656
		private string string_4;

		// Token: 0x04000A61 RID: 2657
		private string string_5;

		// Token: 0x04000A62 RID: 2658
		private string string_6;

		// Token: 0x04000A63 RID: 2659
		private string string_7;

		// Token: 0x04000A64 RID: 2660
		private int int_0;

		// Token: 0x04000A65 RID: 2661
		private bool bool_0;

		// Token: 0x04000A66 RID: 2662
		private bool bool_1;

		// Token: 0x04000A67 RID: 2663
		private bool bool_2;

		// Token: 0x04000A68 RID: 2664
		private bool bool_3;
	}
}
