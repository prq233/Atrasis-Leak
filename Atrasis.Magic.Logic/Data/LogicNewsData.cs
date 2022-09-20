using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015A RID: 346
	public class LogicNewsData : LogicData
	{
		// Token: 0x06001440 RID: 5184 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicNewsData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x00051338 File Offset: 0x0004F538
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("ID", 0);
			this.bool_0 = base.GetBooleanValue("Enabled", 0);
			this.bool_1 = base.GetBooleanValue("EnabledIOS", 0);
			this.bool_2 = base.GetBooleanValue("EnabledAndroid", 0);
			this.bool_3 = base.GetBooleanValue("EnabledKunlun", 0);
			this.bool_4 = base.GetBooleanValue("EnabledTencent", 0);
			this.bool_5 = base.GetBooleanValue("EnabledLowEnd", 0);
			this.bool_6 = base.GetBooleanValue("EnabledHighEnd", 0);
			this.string_0 = base.GetValue("Type", 0);
			this.bool_7 = base.GetBooleanValue("ShowAsNew", 0);
			this.string_1 = base.GetValue("ButtonTID", 0);
			this.string_2 = base.GetValue("ActionType", 0);
			this.string_3 = base.GetValue("ActionParameter1", 0);
			this.string_4 = base.GetValue("ActionParameter2", 0);
			this.string_5 = base.GetValue("NativeAndroidURL", 0);
			this.string_6 = base.GetValue("IncludedCountries", 0);
			this.string_7 = base.GetValue("ExcludedCountries", 0);
			this.string_8 = base.GetValue("ExcludedLoginCountries", 0);
			this.bool_8 = base.GetBooleanValue("CenterText", 0);
			this.bool_9 = base.GetBooleanValue("LoadResources", 0);
			this.bool_10 = base.GetBooleanValue("LoadInLowEnd", 0);
			this.string_9 = base.GetValue("ItemSWF", 0);
			this.string_10 = base.GetValue("ItemExportName", 0);
			this.string_11 = base.GetValue("IconSWF", 0);
			this.string_12 = base.GetValue("IconExportName", 0);
			this.int_1 = base.GetIntegerValue("IconFrame", 0);
			this.bool_11 = base.GetBooleanValue("AnimateIcon", 0);
			this.bool_12 = base.GetBooleanValue("CenterIcon", 0);
			this.int_2 = base.GetIntegerValue("MinTownHall", 0);
			this.int_3 = base.GetIntegerValue("MaxTownHall", 0);
			this.int_4 = base.GetIntegerValue("MinLevel", 0);
			this.int_5 = base.GetIntegerValue("MaxLevel", 0);
			this.int_6 = base.GetIntegerValue("MaxDiamonds", 0);
			this.bool_13 = base.GetBooleanValue("ClickToDismiss", 0);
			this.bool_14 = base.GetBooleanValue("NotifyAlways", 0);
			this.int_7 = base.GetIntegerValue("NotifyMinLevel", 0);
			this.int_8 = base.GetIntegerValue("AvatarIdModulo", 0);
			this.int_9 = base.GetIntegerValue("ModuloMin", 0);
			this.int_10 = base.GetIntegerValue("ModuloMax", 0);
			this.bool_15 = base.GetBooleanValue("Collapsed", 0);
			this.string_13 = base.GetValue("MinOS", 0);
			this.string_14 = base.GetValue("MaxOS", 0);
			this.string_15 = base.GetValue("ButtonTID2", 0);
			this.string_16 = base.GetValue("Action2Type", 0);
			this.string_17 = base.GetValue("Action2Parameter1", 0);
			this.string_18 = base.GetValue("Action2Parameter2", 0);
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x0000D52B File Offset: 0x0000B72B
		public int GetID()
		{
			return this.int_0;
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x0000D533 File Offset: 0x0000B733
		public bool IsEnabled()
		{
			return this.bool_0;
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x0000D53B File Offset: 0x0000B73B
		public bool IsEnabledIOS()
		{
			return this.bool_1;
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x0000D543 File Offset: 0x0000B743
		public bool IsEnabledAndroid()
		{
			return this.bool_2;
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x0000D54B File Offset: 0x0000B74B
		public bool IsEnabledKunlun()
		{
			return this.bool_3;
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x0000D553 File Offset: 0x0000B753
		public bool IsEnabledTencent()
		{
			return this.bool_4;
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x0000D55B File Offset: 0x0000B75B
		public bool IsEnabledLowEnd()
		{
			return this.bool_5;
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x0000D563 File Offset: 0x0000B763
		public bool IsEnabledHighEnd()
		{
			return this.bool_6;
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0000D56B File Offset: 0x0000B76B
		public new string GetType()
		{
			return this.string_0;
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x0000D573 File Offset: 0x0000B773
		public bool IsShowAsNew()
		{
			return this.bool_7;
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x0000D57B File Offset: 0x0000B77B
		public string GetButtonTID()
		{
			return this.string_1;
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x0000D583 File Offset: 0x0000B783
		public string GetActionType()
		{
			return this.string_2;
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x0000D58B File Offset: 0x0000B78B
		public string GetActionParameter1()
		{
			return this.string_3;
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x0000D593 File Offset: 0x0000B793
		public string GetActionParameter2()
		{
			return this.string_4;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x0000D59B File Offset: 0x0000B79B
		public string GetNativeAndroidURL()
		{
			return this.string_5;
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x0000D5A3 File Offset: 0x0000B7A3
		public string GetIncludedCountries()
		{
			return this.string_6;
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0000D5AB File Offset: 0x0000B7AB
		public string GetExcludedCountries()
		{
			return this.string_7;
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x0000D5B3 File Offset: 0x0000B7B3
		public string GetExcludedLoginCountries()
		{
			return this.string_8;
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x0000D5BB File Offset: 0x0000B7BB
		public bool IsCenterText()
		{
			return this.bool_8;
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0000D5C3 File Offset: 0x0000B7C3
		public bool IsLoadResources()
		{
			return this.bool_9;
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x0000D5CB File Offset: 0x0000B7CB
		public bool IsLoadInLowEnd()
		{
			return this.bool_10;
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0000D5D3 File Offset: 0x0000B7D3
		public string GetItemSWF()
		{
			return this.string_9;
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x0000D5DB File Offset: 0x0000B7DB
		public string GetItemExportName()
		{
			return this.string_10;
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0000D5E3 File Offset: 0x0000B7E3
		public string GetIconSWF()
		{
			return this.string_11;
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0000D5EB File Offset: 0x0000B7EB
		public int GetIconFrame()
		{
			return this.int_1;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x0000D5F3 File Offset: 0x0000B7F3
		public bool IsAnimateIcon()
		{
			return this.bool_11;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x0000D5FB File Offset: 0x0000B7FB
		public bool IsCenterIcon()
		{
			return this.bool_12;
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0000D603 File Offset: 0x0000B803
		public int GetMinTownHall()
		{
			return this.int_2;
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x0000D60B File Offset: 0x0000B80B
		public int GetMaxTownHall()
		{
			return this.int_3;
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x0000D613 File Offset: 0x0000B813
		public int GetMinLevel()
		{
			return this.int_4;
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x0000D61B File Offset: 0x0000B81B
		public int GetMaxLevel()
		{
			return this.int_5;
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x0000D623 File Offset: 0x0000B823
		public int GetMaxDiamonds()
		{
			return this.int_6;
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x0000D62B File Offset: 0x0000B82B
		public bool IsClickToDismiss()
		{
			return this.bool_13;
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x0000D633 File Offset: 0x0000B833
		public bool IsNotifyAlways()
		{
			return this.bool_14;
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x0000D63B File Offset: 0x0000B83B
		public int GetNotifyMinLevel()
		{
			return this.int_7;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0000D643 File Offset: 0x0000B843
		public int GetAvatarIdModulo()
		{
			return this.int_8;
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0000D64B File Offset: 0x0000B84B
		public int GetModuloMin()
		{
			return this.int_9;
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0000D653 File Offset: 0x0000B853
		public int GetModuloMax()
		{
			return this.int_10;
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x0000D65B File Offset: 0x0000B85B
		public bool IsCollapsed()
		{
			return this.bool_15;
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x0000D663 File Offset: 0x0000B863
		public string GetMinOS()
		{
			return this.string_13;
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0000D66B File Offset: 0x0000B86B
		public string GetMaxOS()
		{
			return this.string_14;
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x0000D673 File Offset: 0x0000B873
		public string GetButtonTID2()
		{
			return this.string_15;
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0000D67B File Offset: 0x0000B87B
		public string GetAction2Type()
		{
			return this.string_16;
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x0000D683 File Offset: 0x0000B883
		public string GetAction2Parameter1()
		{
			return this.string_17;
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0000D68B File Offset: 0x0000B88B
		public string GetAction2Parameter2()
		{
			return this.string_18;
		}

		// Token: 0x04000A8B RID: 2699
		private string string_0;

		// Token: 0x04000A8C RID: 2700
		private string string_1;

		// Token: 0x04000A8D RID: 2701
		private string string_2;

		// Token: 0x04000A8E RID: 2702
		private string string_3;

		// Token: 0x04000A8F RID: 2703
		private string string_4;

		// Token: 0x04000A90 RID: 2704
		private string string_5;

		// Token: 0x04000A91 RID: 2705
		private string string_6;

		// Token: 0x04000A92 RID: 2706
		private string string_7;

		// Token: 0x04000A93 RID: 2707
		private string string_8;

		// Token: 0x04000A94 RID: 2708
		private string string_9;

		// Token: 0x04000A95 RID: 2709
		private string string_10;

		// Token: 0x04000A96 RID: 2710
		private string string_11;

		// Token: 0x04000A97 RID: 2711
		private string string_12;

		// Token: 0x04000A98 RID: 2712
		private string string_13;

		// Token: 0x04000A99 RID: 2713
		private string string_14;

		// Token: 0x04000A9A RID: 2714
		private string string_15;

		// Token: 0x04000A9B RID: 2715
		private string string_16;

		// Token: 0x04000A9C RID: 2716
		private string string_17;

		// Token: 0x04000A9D RID: 2717
		private string string_18;

		// Token: 0x04000A9E RID: 2718
		private int int_0;

		// Token: 0x04000A9F RID: 2719
		private int int_1;

		// Token: 0x04000AA0 RID: 2720
		private int int_2;

		// Token: 0x04000AA1 RID: 2721
		private int int_3;

		// Token: 0x04000AA2 RID: 2722
		private int int_4;

		// Token: 0x04000AA3 RID: 2723
		private int int_5;

		// Token: 0x04000AA4 RID: 2724
		private int int_6;

		// Token: 0x04000AA5 RID: 2725
		private int int_7;

		// Token: 0x04000AA6 RID: 2726
		private int int_8;

		// Token: 0x04000AA7 RID: 2727
		private int int_9;

		// Token: 0x04000AA8 RID: 2728
		private int int_10;

		// Token: 0x04000AA9 RID: 2729
		private bool bool_0;

		// Token: 0x04000AAA RID: 2730
		private bool bool_1;

		// Token: 0x04000AAB RID: 2731
		private bool bool_2;

		// Token: 0x04000AAC RID: 2732
		private bool bool_3;

		// Token: 0x04000AAD RID: 2733
		private bool bool_4;

		// Token: 0x04000AAE RID: 2734
		private bool bool_5;

		// Token: 0x04000AAF RID: 2735
		private bool bool_6;

		// Token: 0x04000AB0 RID: 2736
		private bool bool_7;

		// Token: 0x04000AB1 RID: 2737
		private bool bool_8;

		// Token: 0x04000AB2 RID: 2738
		private bool bool_9;

		// Token: 0x04000AB3 RID: 2739
		private bool bool_10;

		// Token: 0x04000AB4 RID: 2740
		private bool bool_11;

		// Token: 0x04000AB5 RID: 2741
		private bool bool_12;

		// Token: 0x04000AB6 RID: 2742
		private bool bool_13;

		// Token: 0x04000AB7 RID: 2743
		private bool bool_14;

		// Token: 0x04000AB8 RID: 2744
		private bool bool_15;
	}
}
