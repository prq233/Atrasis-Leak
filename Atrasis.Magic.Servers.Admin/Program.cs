using System;
using Atrasis.Magic.Servers.Admin.Network.Message;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Settings;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Atrasis.Magic.Servers.Admin
{
	// Token: 0x02000002 RID: 2
	public class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args).UseUrls(new string[]
			{
				"http://0.0.0.0:5000"
			}).UseStartup<Startup>();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000027EC File Offset: 0x000009EC
		public static void Main(string[] args)
		{
			ServerCore.Init(0, args);
			ServerAdmin.Init();
			ServerCore.Start(new AdminMessageManager());
			if (EnvironmentSettings.Environment.Equals("prod", StringComparison.InvariantCultureIgnoreCase))
			{
				ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, 0, 0);
			}
			Program.CreateWebHostBuilder(args).Build().Run();
		}
	}
}
