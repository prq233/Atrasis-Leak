using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Titan.Math;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000017 RID: 23
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class EventController : Controller
	{
		// Token: 0x0600008D RID: 141 RVA: 0x00003AF0 File Offset: 0x00001CF0
		[HttpGet]
		public async Task<JObject> Get()
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
				if (!result3.CanOpenLogsPage)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.OK).AddAttribute("events", LogManager.Save());
				}
			}
			return result2;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003B38 File Offset: 0x00001D38
		[HttpPost]
		public JObject Insert([FromBody] JObject obj)
		{
			LogEventEntry.EventType eventType = (LogEventEntry.EventType)((int)obj["type"]);
			long num = (long)obj["accountId"];
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			JObject jobject = (JObject)obj["args"];
			if (jobject == null)
			{
				return this.BuildResponse(HttpStatusCode.InternalServerError);
			}
			if (eventType == LogEventEntry.EventType.OUT_OF_SYNC)
			{
				dictionary.Add("subTick", (int)jobject["subTick"]);
				dictionary.Add("clientChecksum", (int)jobject["clientChecksum"]);
				dictionary.Add("serverChecksum", (int)jobject["serverChecksum"]);
				dictionary.Add("debugJSON", (string)jobject["debugJSON"]);
				LogManager.AddEventLog(eventType, new LogicLong((int)(num >> 32), (int)num), dictionary);
				return this.BuildResponse(HttpStatusCode.OK);
			}
			return this.BuildResponse(HttpStatusCode.InternalServerError);
		}
	}
}
