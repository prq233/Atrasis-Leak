using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F5 RID: 501
	public static class LogicCalendarEventFactory
	{
		// Token: 0x060019AC RID: 6572 RVA: 0x000110AE File Offset: 0x0000F2AE
		public static LogicCalendarEvent CreateByType(int type)
		{
			switch (type)
			{
			case 0:
				return new LogicCalendarEvent();
			case 1:
				return new LogicOfferCalendarEvent();
			case 4:
				return new LogicDuelLootLimitCalendarEvent();
			}
			Debugger.Error("Unknown calendar event type!");
			return null;
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x0006131C File Offset: 0x0005F51C
		public static LogicCalendarEvent LoadFromJSON(LogicJSONObject jsonObject, LogicCalendarErrorHandler errorHandler)
		{
			LogicCalendarEvent logicCalendarEvent = LogicCalendarEventFactory.CreateByType(jsonObject.GetJSONNumber("type").GetIntValue());
			if (errorHandler != null)
			{
				logicCalendarEvent.SetErrorHandler(errorHandler);
			}
			logicCalendarEvent.Init(jsonObject);
			return logicCalendarEvent;
		}
	}
}
