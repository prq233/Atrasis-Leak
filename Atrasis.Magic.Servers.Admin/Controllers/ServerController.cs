using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000019 RID: 25
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class ServerController : Controller
	{
		// Token: 0x06000092 RID: 146 RVA: 0x00003CAC File Offset: 0x00001EAC
		[HttpGet]
		public async Task<JObject> Index()
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
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanOpenServersPage)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.OK).AddAttribute("servers", ServerManager.Save());
				}
			}
			return result2;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003CF4 File Offset: 0x00001EF4
		[HttpGet("startMaintenance")]
		public async Task<JObject> StartMaintenance()
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
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				StringValues values2;
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else if ((ServerStatus.Status == ServerStatusType.NORMAL || ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE) && base.Request.Query.TryGetValue("duration", out values2))
				{
					ServerStatus.SetStatus(ServerStatusType.SHUTDOWN_STARTED, TimeUtil.GetTimestamp() + 300, LogicMath.Max(int.Parse(values2) * 60, 0));
					result2 = this.BuildResponse(HttpStatusCode.OK);
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden);
				}
			}
			return result2;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003D3C File Offset: 0x00001F3C
		[HttpGet("stopMaintenance")]
		public async Task<JObject> StopMaintenance()
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
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else if (ServerStatus.Status == ServerStatusType.MAINTENANCE)
				{
					ServerStatus.SetStatus(ServerStatusType.COOLDOWN_AFTER_MAINTENANCE, TimeUtil.GetTimestamp() + 300, 0);
					result2 = this.BuildResponse(HttpStatusCode.OK);
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden);
				}
			}
			return result2;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003D84 File Offset: 0x00001F84
		[HttpGet("cancelCooldown")]
		public async Task<JObject> CancelCooldown()
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
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else if (ServerStatus.Status == ServerStatusType.COOLDOWN_AFTER_MAINTENANCE)
				{
					ServerStatus.SetStatus(ServerStatusType.NORMAL, 0, 0);
					result2 = this.BuildResponse(HttpStatusCode.OK);
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden);
				}
			}
			return result2;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003DCC File Offset: 0x00001FCC
		[HttpGet("extendMaintenance")]
		public async Task<JObject> ExtendMaintenance()
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
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				StringValues values2;
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else if (ServerStatus.Status == ServerStatusType.MAINTENANCE && base.Request.Query.TryGetValue("duration", out values2))
				{
					ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, TimeUtil.GetTimestamp() + LogicMath.Max(int.Parse(values2) * 60, 0), 0);
					result2 = this.BuildResponse(HttpStatusCode.OK);
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden);
				}
			}
			return result2;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003E14 File Offset: 0x00002014
		[HttpGet("addContainer")]
		public async Task<JObject> AddContainer()
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
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				TaskAwaiter<UserEntry> taskAwaiter3 = AuthManager.GetUser(sessionEntry.User).GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<UserEntry> taskAwaiter4;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<UserEntry>);
				}
				UserEntry result3 = taskAwaiter3.GetResult();
				if (!result3.CanChangeServerStatus)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden);
				}
			}
			return result2;
		}
	}
}
