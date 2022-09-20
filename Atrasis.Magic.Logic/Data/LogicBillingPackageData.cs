using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013C RID: 316
	public class LogicBillingPackageData : LogicData
	{
		// Token: 0x06001112 RID: 4370 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicBillingPackageData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0004B504 File Offset: 0x00049704
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = base.GetBooleanValue("Disabled", 0);
			this.bool_1 = base.GetBooleanValue("ExistsApple", 0);
			this.bool_2 = base.GetBooleanValue("ExistsAndroid", 0);
			this.int_0 = base.GetIntegerValue("Diamonds", 0);
			this.int_1 = base.GetIntegerValue("USD", 0);
			this.string_0 = base.GetValue("ShopItemExportName", 0);
			this.string_1 = base.GetValue("OfferItemExportName", 0);
			this.int_2 = base.GetIntegerValue("Order", 0);
			this.bool_3 = base.GetBooleanValue("RED", 0);
			this.int_3 = base.GetIntegerValue("RMB", 0);
			this.bool_4 = base.GetBooleanValue("KunlunOnly", 0);
			this.int_4 = base.GetIntegerValue("LenovoID", 0);
			this.string_2 = base.GetValue("TencentID", 0);
			this.bool_5 = base.GetBooleanValue("isOfferPackage", 0);
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0000B7B8 File Offset: 0x000099B8
		public bool Disabled()
		{
			return this.bool_0;
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x0000B7C0 File Offset: 0x000099C0
		public bool ExistsApple()
		{
			return this.bool_1;
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0000B7C8 File Offset: 0x000099C8
		public bool ExistsAndroid()
		{
			return this.bool_2;
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0000B7D0 File Offset: 0x000099D0
		public int GetDiamonds()
		{
			return this.int_0;
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0000B7D8 File Offset: 0x000099D8
		public int GetUSD()
		{
			return this.int_1;
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0000B7E0 File Offset: 0x000099E0
		public string GetShopItemExportName()
		{
			return this.string_0;
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0000B7E8 File Offset: 0x000099E8
		public string GetOfferItemExportName()
		{
			return this.string_1;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0000B7F0 File Offset: 0x000099F0
		public int GetOrder()
		{
			return this.int_2;
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x0000B7F8 File Offset: 0x000099F8
		public bool IsRED()
		{
			return this.bool_3;
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x0000B800 File Offset: 0x00009A00
		public int GetRMB()
		{
			return this.int_3;
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x0000B808 File Offset: 0x00009A08
		public bool IsKunlunOnly()
		{
			return this.bool_4;
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x0000B810 File Offset: 0x00009A10
		public int GetLenovoID()
		{
			return this.int_4;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x0000B818 File Offset: 0x00009A18
		public string GetTencentID()
		{
			return this.string_2;
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x0000B820 File Offset: 0x00009A20
		public bool IsOfferPackage()
		{
			return this.bool_5;
		}

		// Token: 0x04000758 RID: 1880
		private string string_0;

		// Token: 0x04000759 RID: 1881
		private string string_1;

		// Token: 0x0400075A RID: 1882
		private string string_2;

		// Token: 0x0400075B RID: 1883
		private int int_0;

		// Token: 0x0400075C RID: 1884
		private int int_1;

		// Token: 0x0400075D RID: 1885
		private int int_2;

		// Token: 0x0400075E RID: 1886
		private int int_3;

		// Token: 0x0400075F RID: 1887
		private int int_4;

		// Token: 0x04000760 RID: 1888
		private bool bool_0;

		// Token: 0x04000761 RID: 1889
		private bool bool_1;

		// Token: 0x04000762 RID: 1890
		private bool bool_2;

		// Token: 0x04000763 RID: 1891
		private bool bool_3;

		// Token: 0x04000764 RID: 1892
		private bool bool_4;

		// Token: 0x04000765 RID: 1893
		private bool bool_5;
	}
}
