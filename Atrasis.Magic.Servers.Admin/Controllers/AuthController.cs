using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000015 RID: 21
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class AuthController : Controller
	{
		// Token: 0x06000087 RID: 135 RVA: 0x000039C8 File Offset: 0x00001BC8
		[HttpPost]
		[Route("login")]
		public async Task<JObject> Login([FromBody] AuthController.LoginRequest request)
		{
			StringValues values;
			bool flag;
			if (flag = base.Request.Headers.TryGetValue("token", out values))
			{
				TaskAwaiter<SessionEntry> taskAwaiter = AuthManager.GetSession(values).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<SessionEntry> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
				}
				SessionEntry result = taskAwaiter.GetResult();
				flag = (result != null);
			}
			JObject result2;
			if (flag)
			{
				result2 = this.BuildResponse(HttpStatusCode.Forbidden);
			}
			else
			{
				TaskAwaiter<string> taskAwaiter3 = AuthManager.OpenSession(request.User, request.Password).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<string> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<string>);
				}
				string result3 = taskAwaiter3.GetResult();
				if (result3 == null)
				{
					result2 = this.BuildResponse(HttpStatusCode.NotFound);
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.OK).AddAttribute("token", result3);
				}
			}
			return result2;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003A18 File Offset: 0x00001C18
		[HttpGet]
		[Route("logout")]
		public async Task<JObject> Logout()
		{
			StringValues values;
			bool flag = (!base.Request.Headers.TryGetValue("token", out values)) ?? (await AuthManager.CloseSession(values));
			JObject result;
			if (flag)
			{
				result = this.BuildResponse(HttpStatusCode.NotFound);
			}
			else
			{
				result = this.BuildResponse(HttpStatusCode.OK);
			}
			return result;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003A60 File Offset: 0x00001C60
		[HttpGet]
		[Route("info")]
		public async Task<JObject> GetUserInfo()
		{
			StringValues values;
			bool flag;
			SessionEntry sessionEntry;
			if (!(flag = !base.Request.Headers.TryGetValue("token", out values)))
			{
				TaskAwaiter<SessionEntry> taskAwaiter = AuthManager.GetSession(values).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<SessionEntry> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<SessionEntry>);
				}
				SessionEntry result = taskAwaiter.GetResult();
				flag = ((sessionEntry = result) == null);
			}
			JObject result2;
			if (flag)
			{
				result2 = this.BuildResponse(HttpStatusCode.NotFound);
			}
			else
			{
				JObject obj = this.BuildResponse(HttpStatusCode.OK);
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				result2 = obj.AddAttribute("name", taskAwaiter3.GetResult().User);
			}
			return result2;
		}

		// Token: 0x0400003C RID: 60
		public const string TOKEN_ATTRIBUTE = "token";

		// Token: 0x02000026 RID: 38
		public class LoginRequest
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000B8 RID: 184 RVA: 0x00002600 File Offset: 0x00000800
			// (set) Token: 0x060000B9 RID: 185 RVA: 0x00002608 File Offset: 0x00000808
			public string User { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000BA RID: 186 RVA: 0x00002611 File Offset: 0x00000811
			// (set) Token: 0x060000BB RID: 187 RVA: 0x00002619 File Offset: 0x00000819
			public string Password { get; set; }
		}
	}
}
