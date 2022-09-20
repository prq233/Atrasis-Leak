using System;
using System.Net;
using System.Threading.Tasks;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000016 RID: 22
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class DashboardController : Controller
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00003AA8 File Offset: 0x00001CA8
		[HttpGet]
		public async Task<JObject> Index()
		{
			StringValues values;
			bool flag;
			if (!(flag = !base.Request.Headers.TryGetValue("token", out values)))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				flag = (sessionEntry == null);
			}
			JObject result;
			if (flag)
			{
				result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				result = this.BuildResponse(HttpStatusCode.OK).AddAttribute("totalUsers", new JArray(DashboardManager.TotalUsers)).AddAttribute("dailyActiveUsers", new JArray(DashboardManager.DailyActiveUsers)).AddAttribute("newUsers", new JArray(DashboardManager.NewUsers)).AddAttribute("onlineUsers", ServerManager.OnlineUsers).AddAttribute("maxOnlineUsers", new JArray(DashboardManager.MaxOnlineUsers)).AddAttribute("time", TimeUtil.GetTimestamp(DashboardManager.LastUpdate));
			}
			return result;
		}
	}
}
