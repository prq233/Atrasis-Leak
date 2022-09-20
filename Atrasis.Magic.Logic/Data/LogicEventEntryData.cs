using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014D RID: 333
	public class LogicEventEntryData : LogicData
	{
		// Token: 0x060012C2 RID: 4802 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicEventEntryData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x0004E2A4 File Offset: 0x0004C4A4
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("ItemSWF", 0);
			this.string_1 = base.GetValue("ItemExportName", 0);
			this.string_2 = base.GetValue("UpcomingItemExportName", 0);
			this.bool_0 = base.GetBooleanValue("LoadSWF", 0);
			this.string_3 = base.GetValue("TitleTID", 0);
			this.string_4 = base.GetValue("UpcomingTitleTID", 0);
			this.string_5 = base.GetValue("ButtonTID", 0);
			this.string_6 = base.GetValue("ButtonAction", 0);
			this.string_7 = base.GetValue("ButtonActionData", 0);
			this.string_8 = base.GetValue("Button2TID", 0);
			this.string_9 = base.GetValue("Button2Action", 0);
			this.string_10 = base.GetValue("Button2ActionData", 0);
			this.string_11 = base.GetValue("ButtonLanguage", 0);
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x0000C8D4 File Offset: 0x0000AAD4
		public string GetItemSWF()
		{
			return this.string_0;
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x0000C8DC File Offset: 0x0000AADC
		public string GetItemExportName()
		{
			return this.string_1;
		}

		// Token: 0x060012C6 RID: 4806 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
		public string GetUpcomingItemExportName()
		{
			return this.string_2;
		}

		// Token: 0x060012C7 RID: 4807 RVA: 0x0000C8EC File Offset: 0x0000AAEC
		public bool IsLoadSWF()
		{
			return this.bool_0;
		}

		// Token: 0x060012C8 RID: 4808 RVA: 0x0000C8F4 File Offset: 0x0000AAF4
		public string GetTitleTID()
		{
			return this.string_3;
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x0000C8FC File Offset: 0x0000AAFC
		public string GetUpcomingTitleTID()
		{
			return this.string_4;
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x0000C904 File Offset: 0x0000AB04
		public string GetButtonTID()
		{
			return this.string_5;
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x0000C90C File Offset: 0x0000AB0C
		public string GetButtonAction()
		{
			return this.string_6;
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x0000C914 File Offset: 0x0000AB14
		public string GetButtonActionData()
		{
			return this.string_7;
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x0000C91C File Offset: 0x0000AB1C
		public string GetButton2TID()
		{
			return this.string_8;
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x0000C924 File Offset: 0x0000AB24
		public string GetButton2Action()
		{
			return this.string_9;
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x0000C92C File Offset: 0x0000AB2C
		public string GetButton2ActionData()
		{
			return this.string_10;
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x0000C934 File Offset: 0x0000AB34
		public string GetButtonLanguage()
		{
			return this.string_11;
		}

		// Token: 0x040008E3 RID: 2275
		private string string_0;

		// Token: 0x040008E4 RID: 2276
		private string string_1;

		// Token: 0x040008E5 RID: 2277
		private string string_2;

		// Token: 0x040008E6 RID: 2278
		private string string_3;

		// Token: 0x040008E7 RID: 2279
		private string string_4;

		// Token: 0x040008E8 RID: 2280
		private string string_5;

		// Token: 0x040008E9 RID: 2281
		private string string_6;

		// Token: 0x040008EA RID: 2282
		private string string_7;

		// Token: 0x040008EB RID: 2283
		private string string_8;

		// Token: 0x040008EC RID: 2284
		private string string_9;

		// Token: 0x040008ED RID: 2285
		private string string_10;

		// Token: 0x040008EE RID: 2286
		private string string_11;

		// Token: 0x040008EF RID: 2287
		private bool bool_0;
	}
}
