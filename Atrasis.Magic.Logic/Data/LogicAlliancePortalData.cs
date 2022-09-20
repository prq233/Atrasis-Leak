using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000138 RID: 312
	public class LogicAlliancePortalData : LogicGameObjectData
	{
		// Token: 0x060010B7 RID: 4279 RVA: 0x0000B477 File Offset: 0x00009677
		public LogicAlliancePortalData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x0004AB0C File Offset: 0x00048D0C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("SWF", 0);
			this.string_1 = base.GetValue("ExportName", 0);
			this.int_0 = base.GetIntegerValue("Width", 0);
			this.int_1 = base.GetIntegerValue("Height", 0);
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0000B481 File Offset: 0x00009681
		public int GetWidth()
		{
			return this.int_0;
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0000B489 File Offset: 0x00009689
		public int GetHeight()
		{
			return this.int_1;
		}

		// Token: 0x040006FB RID: 1787
		private string string_0;

		// Token: 0x040006FC RID: 1788
		private string string_1;

		// Token: 0x040006FD RID: 1789
		private int int_0;

		// Token: 0x040006FE RID: 1790
		private int int_1;
	}
}
