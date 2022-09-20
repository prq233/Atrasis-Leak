using System;
using Atrasis.Magic.Logic.Data;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F2 RID: 498
	public class LogicCalendarBuildingDestroyedSpawnUnit
	{
		// Token: 0x0600195E RID: 6494 RVA: 0x00010D85 File Offset: 0x0000EF85
		public LogicCalendarBuildingDestroyedSpawnUnit(LogicBuildingData buildingData, LogicCharacterData unitData, int count)
		{
			this.logicBuildingData_0 = buildingData;
			this.logicCharacterData_0 = unitData;
			this.int_0 = count;
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x00010DA2 File Offset: 0x0000EFA2
		public LogicBuildingData GetBuildingData()
		{
			return this.logicBuildingData_0;
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x00010DAA File Offset: 0x0000EFAA
		public LogicCharacterData GetCharacterData()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x06001961 RID: 6497 RVA: 0x00010DB2 File Offset: 0x0000EFB2
		public int GetCount()
		{
			return this.int_0;
		}

		// Token: 0x04000DA5 RID: 3493
		private readonly LogicBuildingData logicBuildingData_0;

		// Token: 0x04000DA6 RID: 3494
		private readonly LogicCharacterData logicCharacterData_0;

		// Token: 0x04000DA7 RID: 3495
		private readonly int int_0;
	}
}
