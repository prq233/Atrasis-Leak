using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014F RID: 335
	public abstract class LogicGameObjectData : LogicData
	{
		// Token: 0x060012D5 RID: 4821 RVA: 0x0000C96C File Offset: 0x0000AB6C
		protected LogicGameObjectData(CSVRow row, LogicDataTable table) : base(row, table)
		{
			this.m_villageType = -1;
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x0004E3A4 File Offset: 0x0004C5A4
		public override void CreateReferences()
		{
			base.CreateReferences();
			int columnIndexByName = this.m_row.GetColumnIndexByName("VillageType");
			if (columnIndexByName > 0)
			{
				this.m_villageType = this.m_row.GetIntegerValueAt(columnIndexByName, 0);
				if (this.m_villageType >= 2)
				{
					Debugger.Error("invalid VillageType");
				}
			}
		}

		// Token: 0x060012D7 RID: 4823 RVA: 0x0000C97D File Offset: 0x0000AB7D
		public int GetVillageType()
		{
			return this.m_villageType;
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x0000C985 File Offset: 0x0000AB85
		public bool IsEnabledInVillageType(int villageType)
		{
			return this.m_villageType == -1 || this.m_villageType == villageType;
		}

		// Token: 0x040008F1 RID: 2289
		protected int m_villageType;
	}
}
