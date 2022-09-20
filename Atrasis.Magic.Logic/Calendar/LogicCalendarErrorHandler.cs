using System;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F3 RID: 499
	public class LogicCalendarErrorHandler
	{
		// Token: 0x06001962 RID: 6498 RVA: 0x00010DBA File Offset: 0x0000EFBA
		public void Error(LogicCalendarEvent eventName, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}: {1}", eventName, message));
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x00010DCD File Offset: 0x0000EFCD
		public void ErrorField(LogicCalendarEvent eventName, string field, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}, field {1}: {2}", eventName, field, message));
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x00010DCD File Offset: 0x0000EFCD
		public void ErrorFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}, field {1}: {2}", eventName, function, message));
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x00010DE1 File Offset: 0x0000EFE1
		public void ErrorFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string parameter, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}, function {1}, parameter {2}: {3}", new object[]
			{
				eventName,
				function,
				parameter,
				message
			}));
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x00010E09 File Offset: 0x0000F009
		public void Warning(LogicCalendarEvent eventName, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}: {1}", eventName, message));
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x00010E1C File Offset: 0x0000F01C
		public void WarningField(LogicCalendarEvent eventName, string field, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}, field {1}: {2}", eventName, field, message));
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x00010E30 File Offset: 0x0000F030
		public void WarningFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}, function {1}: {2}", eventName, function, message));
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x00010E44 File Offset: 0x0000F044
		public void WarningFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string parameter, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}, function {1}, parameter {2}: {3}", new object[]
			{
				eventName,
				function,
				parameter,
				message
			}));
		}
	}
}
