using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atrasis.Magic.Servers.Admin
{
	// Token: 0x02000004 RID: 4
	public class Startup
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000020B4 File Offset: 0x000002B4
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000020C3 File Offset: 0x000002C3
		public IConfiguration Configuration { get; }

		// Token: 0x06000010 RID: 16 RVA: 0x0000297C File Offset: 0x00000B7C
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseCors(delegate(CorsPolicyBuilder builder)
			{
				builder.AllowAnyOrigin();
				builder.AllowAnyHeader();
				builder.AllowAnyMethod();
			});
			app.UseMvc();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020CB File Offset: 0x000002CB
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}
	}
}
