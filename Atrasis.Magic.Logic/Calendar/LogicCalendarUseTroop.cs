using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F8 RID: 504
	public class LogicCalendarUseTroop
	{
		// Token: 0x060019BE RID: 6590 RVA: 0x00011178 File Offset: 0x0000F378
		public LogicCalendarUseTroop(LogicCombatItemData data)
		{
			this.logicCombatItemData_0 = data;
			this.logicArrayList_0 = new LogicArrayList<int>();
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x00011192 File Offset: 0x0000F392
		public LogicCombatItemData GetData()
		{
			return this.logicCombatItemData_0;
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x0001119A File Offset: 0x0000F39A
		public void AddParameter(int parameter)
		{
			this.logicArrayList_0.Add(parameter);
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x000111A8 File Offset: 0x0000F3A8
		public int GetParameter(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x04000DD1 RID: 3537
		private readonly LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000DD2 RID: 3538
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
