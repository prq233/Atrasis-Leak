using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200000A RID: 10
	public static class LogManager
	{
		// Token: 0x06000048 RID: 72 RVA: 0x0000227F File Offset: 0x0000047F
		public static void Init()
		{
			LogManager.m_serverLogs = new LogicArrayList<LogServerEntry>();
			LogManager.m_gameLogs = new LogicArrayList<LogGameEntry>();
			LogManager.m_eventLogs = new LogicArrayList<LogEventEntry>();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000229F File Offset: 0x0000049F
		public static void OnServerLogMessage(ServerLogMessage message)
		{
			LogManager.m_serverLogs.Add(new LogServerEntry((LogType)message.LogType, message.Message, message.SenderType, message.SenderId));
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000022C8 File Offset: 0x000004C8
		public static void OnGameLogMessage(GameLogMessage message)
		{
			LogManager.m_gameLogs.Add(new LogGameEntry((LogType)message.LogType, message.Message));
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000022E5 File Offset: 0x000004E5
		public static void AddEventLog(LogEventEntry.EventType type, LogicLong accountId, Dictionary<string, object> args)
		{
			LogManager.m_eventLogs.Add(new LogEventEntry(type, accountId, args));
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002F80 File Offset: 0x00001180
		public static JObject Save()
		{
			JObject jobject = new JObject();
			JArray jarray = new JArray();
			JArray jarray2 = new JArray();
			JArray jarray3 = new JArray();
			for (int i = 0; i < LogManager.m_serverLogs.Size(); i++)
			{
				jarray.Add(LogManager.m_serverLogs[i].Save());
			}
			for (int j = 0; j < LogManager.m_gameLogs.Size(); j++)
			{
				jarray2.Add(LogManager.m_gameLogs[j].Save());
			}
			for (int k = 0; k < LogManager.m_eventLogs.Size(); k++)
			{
				jarray3.Add(LogManager.m_eventLogs[k].Save());
			}
			jobject.Add("server", jarray);
			jobject.Add("game", jarray2);
			jobject.Add("event", jarray3);
			return jobject;
		}

		// Token: 0x04000018 RID: 24
		private static LogicArrayList<LogServerEntry> m_serverLogs;

		// Token: 0x04000019 RID: 25
		private static LogicArrayList<LogGameEntry> m_gameLogs;

		// Token: 0x0400001A RID: 26
		private static LogicArrayList<LogEventEntry> m_eventLogs;
	}
}
