using System;
using System.Net;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x02000018 RID: 24
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class PublicController : Controller
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00003C3C File Offset: 0x00001E3C
		[HttpGet]
		public JObject Index()
		{
			return this.BuildResponse(HttpStatusCode.OK).AddAttribute("totalUsers", DashboardManager.TotalUsers[6]).AddAttribute("dailyActiveUsers", DashboardManager.DailyActiveUsers[6]).AddAttribute("newUsers", DashboardManager.NewUsers[6]).AddAttribute("onlineUsers", ServerManager.OnlineUsers);
		}
	}
}
