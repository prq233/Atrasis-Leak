using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000142 RID: 322
	public class LogicClientGlobals : LogicDataTable
	{
		// Token: 0x060011FB RID: 4603 RVA: 0x0000C064 File Offset: 0x0000A264
		public LogicClientGlobals(CSVTable table, LogicDataType index) : base(table, index)
		{
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x0000C06E File Offset: 0x0000A26E
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_2 = this.method_1("USE_PEPPER_CRYPTO");
			this.bool_3 = this.method_1("POWER_SAVE_MODE_LESS_ENDTURN_MESSAGES");
		}

		// Token: 0x060011FD RID: 4605 RVA: 0x0000C098 File Offset: 0x0000A298
		private LogicGlobalData method_0(string string_1)
		{
			return LogicDataTables.GetClientGlobalByName(string_1, null);
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x0000C0A1 File Offset: 0x0000A2A1
		private bool method_1(string string_1)
		{
			return this.method_0(string_1).GetBooleanValue();
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x0000C0AF File Offset: 0x0000A2AF
		private int method_2(string string_1)
		{
			return this.method_0(string_1).GetNumberValue();
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x0000C0BD File Offset: 0x0000A2BD
		public bool PepperEnabled()
		{
			return this.bool_2;
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x0000C0C5 File Offset: 0x0000A2C5
		public bool PowerSaveModeLessEndTurnMessages()
		{
			return this.bool_3;
		}

		// Token: 0x0400085A RID: 2138
		private bool bool_2;

		// Token: 0x0400085B RID: 2139
		private bool bool_3;
	}
}
