using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000161 RID: 353
	public class LogicResourcePackData : LogicData
	{
		// Token: 0x060014DD RID: 5341 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicResourcePackData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0000D9AE File Offset: 0x0000BBAE
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("Resource", 0), this);
			this.int_0 = base.GetIntegerValue("CapacityPercentage", 0);
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0000D9E0 File Offset: 0x0000BBE0
		public LogicResourceData GetResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x0000D9E8 File Offset: 0x0000BBE8
		public int GetCapacityPercentage()
		{
			return this.int_0;
		}

		// Token: 0x04000B19 RID: 2841
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000B1A RID: 2842
		private int int_0;
	}
}
