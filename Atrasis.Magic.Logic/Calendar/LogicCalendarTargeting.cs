using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F7 RID: 503
	public class LogicCalendarTargeting
	{
		// Token: 0x060019BB RID: 6587 RVA: 0x00011169 File Offset: 0x0000F369
		public LogicCalendarTargeting(LogicJSONObject jsonObject)
		{
			this.Load(jsonObject);
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x00061AA0 File Offset: 0x0005FCA0
		public void Load(LogicJSONObject jsonObject)
		{
			Debugger.DoAssert(jsonObject != null, "Unable to load targeting");
			this.int_0 = (LogicJSONHelper.GetInt(jsonObject, "minTownHallLevel") & int.MaxValue);
			this.int_1 = (LogicJSONHelper.GetInt(jsonObject, "maxTownHallLevel") & int.MaxValue);
			this.int_2 = (LogicJSONHelper.GetInt(jsonObject, "minGemsPurchased") & int.MaxValue);
			this.int_3 = (LogicJSONHelper.GetInt(jsonObject, "maxGemsPurchased") & int.MaxValue);
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x00061B18 File Offset: 0x0005FD18
		public void Save(LogicJSONObject jsonObject)
		{
			Debugger.DoAssert(jsonObject != null, "Unable to save targeting");
			jsonObject.Put("minTownHallLevel", new LogicJSONNumber(this.int_0));
			jsonObject.Put("maxTownHallLevel", new LogicJSONNumber(this.int_1));
			jsonObject.Put("minGemsPurchased", new LogicJSONNumber(this.int_2));
			jsonObject.Put("maxGemsPurchased", new LogicJSONNumber(this.int_3));
		}

		// Token: 0x04000DCD RID: 3533
		private int int_0;

		// Token: 0x04000DCE RID: 3534
		private int int_1;

		// Token: 0x04000DCF RID: 3535
		private int int_2;

		// Token: 0x04000DD0 RID: 3536
		private int int_3;
	}
}
