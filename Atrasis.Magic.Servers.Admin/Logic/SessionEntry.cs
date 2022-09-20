using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000007 RID: 7
	public class SessionEntry
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002130 File Offset: 0x00000330
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002138 File Offset: 0x00000338
		public string Token { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002141 File Offset: 0x00000341
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002149 File Offset: 0x00000349
		public string User { get; set; }

		// Token: 0x06000022 RID: 34 RVA: 0x00002152 File Offset: 0x00000352
		public SessionEntry(string user, string token)
		{
			this.User = user;
			this.Token = token;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002168 File Offset: 0x00000368
		public static SessionEntry Load(RedisValue value)
		{
			return JsonConvert.DeserializeObject<SessionEntry>(value);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002175 File Offset: 0x00000375
		public static string Save(SessionEntry entry)
		{
			return JsonConvert.SerializeObject(entry, Formatting.Indented);
		}
	}
}
