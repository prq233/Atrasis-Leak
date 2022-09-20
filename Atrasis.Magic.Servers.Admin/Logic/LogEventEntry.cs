using System;
using System.Collections.Generic;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200000D RID: 13
	public class LogEventEntry
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000238A File Offset: 0x0000058A
		public LogEventEntry.EventType Type { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002392 File Offset: 0x00000592
		public LogicLong AccountId { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000239A File Offset: 0x0000059A
		public Dictionary<string, object> Args { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000023A2 File Offset: 0x000005A2
		public int Time { get; }

		// Token: 0x0600005D RID: 93 RVA: 0x000023AA File Offset: 0x000005AA
		public LogEventEntry(LogEventEntry.EventType type, LogicLong accountId, Dictionary<string, object> args)
		{
			this.Type = type;
			this.AccountId = accountId;
			this.Args = args;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003130 File Offset: 0x00001330
		public JObject Save()
		{
			JObject jobject = new JObject();
			jobject.Add("type", (int)this.Type);
			jobject.Add("accId", this.AccountId);
			JArray jarray = new JArray();
			foreach (KeyValuePair<string, object> keyValuePair in this.Args)
			{
				jarray.Add(new JArray
				{
					keyValuePair.Key,
					keyValuePair.Value
				});
			}
			jobject.Add("args", jarray);
			jobject.Add("t", this.Time);
			return jobject;
		}

		// Token: 0x02000021 RID: 33
		public enum EventType
		{
			// Token: 0x04000057 RID: 87
			OUT_OF_SYNC
		}
	}
}
