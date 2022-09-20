using System;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000011 RID: 17
	public class ClusterPerformance
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000024F9 File Offset: 0x000006F9
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002501 File Offset: 0x00000701
		public int Ping { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000250A File Offset: 0x0000070A
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002512 File Offset: 0x00000712
		public int SessionCount { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000251B File Offset: 0x0000071B
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00002523 File Offset: 0x00000723
		public bool Defined { get; set; }

		// Token: 0x0600007D RID: 125 RVA: 0x000037B8 File Offset: 0x000019B8
		public JObject Save()
		{
			return new JObject
			{
				{
					"ping",
					this.Ping
				},
				{
					"sessionCount",
					this.SessionCount
				}
			};
		}
	}
}
