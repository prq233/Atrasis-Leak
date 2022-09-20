using System;
using Atrasis.Magic.Servers.Core.Util;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200000C RID: 12
	public class LogGameEntry
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002351 File Offset: 0x00000551
		public LogType Type { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002359 File Offset: 0x00000559
		public string Message { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002361 File Offset: 0x00000561
		public int Time { get; }

		// Token: 0x06000057 RID: 87 RVA: 0x00002369 File Offset: 0x00000569
		public LogGameEntry(LogType type, string message)
		{
			this.Type = type;
			this.Message = message;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000030DC File Offset: 0x000012DC
		public JObject Save()
		{
			return new JObject
			{
				{
					"type",
					(int)this.Type
				},
				{
					"msg",
					this.Message
				},
				{
					"t",
					this.Time
				}
			};
		}
	}
}
