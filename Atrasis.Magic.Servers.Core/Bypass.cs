using System;
using Atrasis.Magic.Servers.Core.Settings;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x02000102 RID: 258
	internal static class Bypass
	{
		// Token: 0x06000761 RID: 1889 RVA: 0x00017560 File Offset: 0x00015760
		public static void key()
		{
			int num = 9000000;
			int num2 = EnvironmentSettings.Servers[1].Length;
			if (num2 > 0)
			{
				num = num / num2 + ((num % num2 > 0) ? 1 : 0);
			}
			EnvironmentSettings.Settings.Proxy.SessionCapacity = num;
		}
	}
}
