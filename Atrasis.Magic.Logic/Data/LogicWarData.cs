using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000168 RID: 360
	public class LogicWarData : LogicData
	{
		// Token: 0x06001595 RID: 5525 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicWarData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x000538C0 File Offset: 0x00051AC0
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("TeamSize", 0);
			this.int_1 = base.GetIntegerValue("PreparationMinutes", 0);
			this.int_2 = base.GetIntegerValue("WarMinutes", 0);
			this.bool_0 = base.GetBooleanValue("DisableProduction", 0);
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0000E080 File Offset: 0x0000C280
		public int GetTeamSize()
		{
			return this.int_0;
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0000E088 File Offset: 0x0000C288
		public int GetPreparationMinutes()
		{
			return this.int_1;
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0000E090 File Offset: 0x0000C290
		public int GetWarMinutes()
		{
			return this.int_2;
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0000E098 File Offset: 0x0000C298
		public bool IsDisableProduction()
		{
			return this.bool_0;
		}

		// Token: 0x04000BC2 RID: 3010
		private int int_0;

		// Token: 0x04000BC3 RID: 3011
		private int int_1;

		// Token: 0x04000BC4 RID: 3012
		private int int_2;

		// Token: 0x04000BC5 RID: 3013
		private bool bool_0;
	}
}
