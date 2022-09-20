using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000134 RID: 308
	public class LogicAllianceBadgeData : LogicData
	{
		// Token: 0x060010A5 RID: 4261 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicAllianceBadgeData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x0000B3AF File Offset: 0x000095AF
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("IconLayer0", 0);
			this.string_1 = base.GetValue("IconLayer1", 0);
			this.string_2 = base.GetValue("IconLayer2", 0);
		}

		// Token: 0x040006E9 RID: 1769
		private string string_0;

		// Token: 0x040006EA RID: 1770
		private string string_1;

		// Token: 0x040006EB RID: 1771
		private string string_2;
	}
}
