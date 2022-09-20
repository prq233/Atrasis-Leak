using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014E RID: 334
	public class LogicExperienceLevelData : LogicData
	{
		// Token: 0x060012D1 RID: 4817 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicExperienceLevelData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x0000C93C File Offset: 0x0000AB3C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("ExpPoints", 0);
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x0000C956 File Offset: 0x0000AB56
		public int GetMaxExpPoints()
		{
			return this.int_0;
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x0000C95E File Offset: 0x0000AB5E
		public static int GetLevelCap()
		{
			return LogicDataTables.GetTable(LogicDataType.EXPERIENCE_LEVEL).GetItemCount();
		}

		// Token: 0x040008F0 RID: 2288
		private int int_0;
	}
}
