using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000006 RID: 6
	public static class AuthManager
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002AAC File Offset: 0x00000CAC
		public static async Task<string> OpenSession(string user, string password)
		{
			TaskAwaiter<UserEntry> taskAwaiter = AuthManager.GetUser(user, password).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<UserEntry> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<UserEntry>);
			}
			UserEntry result = taskAwaiter.GetResult();
			UserEntry userEntry = result;
			string result2;
			if (userEntry == null)
			{
				result2 = null;
			}
			else
			{
				SessionEntry sessionEntry = new SessionEntry(userEntry.User, AuthManager.GenerateToken());
				TaskAwaiter<bool> taskAwaiter3 = AuthManager.SaveSession(sessionEntry).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<bool> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<bool>);
				}
				if (!taskAwaiter3.GetResult())
				{
					result2 = null;
				}
				else
				{
					result2 = sessionEntry.Token;
				}
			}
			return result2;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000020E9 File Offset: 0x000002E9
		private static Task<bool> SaveSession(SessionEntry sessionEntry)
		{
			return ServerAdmin.AdminDatabase.Set("session-" + sessionEntry.Token, SessionEntry.Save(sessionEntry), TimeSpan.FromMinutes(15.0));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002119 File Offset: 0x00000319
		public static Task<bool> CloseSession(string token)
		{
			return ServerAdmin.AdminDatabase.Delete("session-" + token);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002AFC File Offset: 0x00000CFC
		public static async Task<SessionEntry> GetSession(string session)
		{
			RedisValue redisValue = await ServerAdmin.AdminDatabase.Get("session-" + session);
			RedisValue value = redisValue;
			SessionEntry result;
			if (value.IsNullOrEmpty)
			{
				result = null;
			}
			else
			{
				result = SessionEntry.Load(value);
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002B44 File Offset: 0x00000D44
		public static async Task<UserEntry> GetUser(string user)
		{
			RedisValue redisValue = await ServerAdmin.AdminDatabase.Get("user-" + user);
			RedisValue value = redisValue;
			UserEntry result;
			if (value.IsNullOrEmpty)
			{
				result = null;
			}
			else
			{
				result = UserEntry.Load(value);
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002B8C File Offset: 0x00000D8C
		public static async Task<UserEntry> GetUser(string user, string password)
		{
			UserEntry userEntry = await AuthManager.GetUser(user);
			UserEntry userEntry2 = userEntry;
			UserEntry result;
			if (userEntry2 == null)
			{
				result = null;
			}
			else if (!string.Equals(userEntry2.Password, password))
			{
				result = null;
			}
			else
			{
				result = userEntry2;
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002BDC File Offset: 0x00000DDC
		private static string GenerateToken()
		{
			return Guid.NewGuid().ToString("N");
		}
	}
}
