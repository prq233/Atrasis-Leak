using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013E RID: 318
	public class LogicBuildingClassData : LogicData
	{
		// Token: 0x06001124 RID: 4388 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicBuildingClassData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x0004B7A8 File Offset: 0x000499A8
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_4 = base.GetBooleanValue("CanBuy", 0);
			this.bool_5 = base.GetBooleanValue("ShopCategoryResource", 0);
			this.bool_6 = base.GetBooleanValue("ShopCategoryArmy", 0);
			this.bool_3 = string.Equals("Worker", base.GetName());
			if (!this.bool_3)
			{
				this.bool_3 = string.Equals("Worker2", base.GetName());
			}
			this.bool_1 = string.Equals("Town Hall", base.GetName());
			this.bool_0 = string.Equals("Town Hall2", base.GetName());
			this.bool_2 = string.Equals("Wall", base.GetName());
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x0000B828 File Offset: 0x00009A28
		public bool IsWorker()
		{
			return this.bool_3;
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x0000B830 File Offset: 0x00009A30
		public bool IsTownHall()
		{
			return this.bool_1;
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x0000B838 File Offset: 0x00009A38
		public bool IsTownHall2()
		{
			return this.bool_0;
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x0000B840 File Offset: 0x00009A40
		public bool IsWall()
		{
			return this.bool_2;
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x0000B848 File Offset: 0x00009A48
		public bool CanBuy()
		{
			return this.bool_4;
		}

		// Token: 0x0400076F RID: 1903
		private bool bool_0;

		// Token: 0x04000770 RID: 1904
		private bool bool_1;

		// Token: 0x04000771 RID: 1905
		private bool bool_2;

		// Token: 0x04000772 RID: 1906
		private bool bool_3;

		// Token: 0x04000773 RID: 1907
		private bool bool_4;

		// Token: 0x04000774 RID: 1908
		private bool bool_5;

		// Token: 0x04000775 RID: 1909
		private bool bool_6;
	}
}
