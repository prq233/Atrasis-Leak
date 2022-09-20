using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013A RID: 314
	public class LogicAnimationTable : LogicDataTable
	{
		// Token: 0x060010BD RID: 4285 RVA: 0x0000B499 File Offset: 0x00009699
		public LogicAnimationTable(CSVNode node, LogicDataType index) : base(node.GetTable(), index)
		{
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0004AB68 File Offset: 0x00048D68
		public override void CreateReferences()
		{
			for (int i = 0; i < this.m_items.Size(); i++)
			{
				this.m_items[i].CreateReferences();
			}
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x00002465 File Offset: 0x00000665
		public void SetTable(CSVNode node)
		{
		}
	}
}
