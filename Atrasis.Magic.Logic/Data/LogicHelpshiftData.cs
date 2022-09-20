using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000153 RID: 339
	public class LogicHelpshiftData : LogicData
	{
		// Token: 0x060013C4 RID: 5060 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicHelpshiftData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x0000D11B File Offset: 0x0000B31B
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("HelpshiftId", 0);
		}

		// Token: 0x04000A11 RID: 2577
		private string string_0;
	}
}
