using System;
using Atrasis.Magic.Servers.Core.Util;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x0200000B RID: 11
	public class LogServerEntry
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000022F9 File Offset: 0x000004F9
		public LogType Type { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002301 File Offset: 0x00000501
		public string Message { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002309 File Offset: 0x00000509
		public int ServerType { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002311 File Offset: 0x00000511
		public int ServerId { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002319 File Offset: 0x00000519
		public int Time { get; }

		// Token: 0x06000052 RID: 82 RVA: 0x00002321 File Offset: 0x00000521
		public LogServerEntry(LogType type, string message, int serverType, int serverId)
		{
			this.Type = type;
			this.Message = message;
			this.ServerType = serverType;
			this.ServerId = serverId;
			this.Time = TimeUtil.GetTimestamp();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000305C File Offset: 0x0000125C
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
					"sT",
					this.ServerType
				},
				{
					"sI",
					this.ServerId
				},
				{
					"t",
					this.Time
				}
			};
		}
	}
}
