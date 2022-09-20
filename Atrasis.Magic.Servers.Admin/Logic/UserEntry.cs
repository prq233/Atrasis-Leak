using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000008 RID: 8
	public class UserEntry
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000217E File Offset: 0x0000037E
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002186 File Offset: 0x00000386
		public string User { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000218F File Offset: 0x0000038F
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002197 File Offset: 0x00000397
		public string Password { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000021A0 File Offset: 0x000003A0
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000021A8 File Offset: 0x000003A8
		public bool CanOpenServersPage { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000021B1 File Offset: 0x000003B1
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000021B9 File Offset: 0x000003B9
		public bool CanOpenUsersPage { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000021C2 File Offset: 0x000003C2
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000021CA File Offset: 0x000003CA
		public bool CanOpenUserProfilePage { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000021D3 File Offset: 0x000003D3
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000021DB File Offset: 0x000003DB
		public bool CanOpenLogsPage { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000021E4 File Offset: 0x000003E4
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000021EC File Offset: 0x000003EC
		public bool CanChangeServerStatus { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000021F5 File Offset: 0x000003F5
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000021FD File Offset: 0x000003FD
		public bool CanExecuteAdminCommand { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002206 File Offset: 0x00000406
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000220E File Offset: 0x0000040E
		public bool CanExecuteDebugCommand { get; set; }

		// Token: 0x06000037 RID: 55 RVA: 0x00002217 File Offset: 0x00000417
		public static UserEntry Load(RedisValue value)
		{
			return JsonConvert.DeserializeObject<UserEntry>(value);
		}
	}
}
