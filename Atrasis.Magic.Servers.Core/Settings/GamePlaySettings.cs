using System;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Servers.Core.Settings
{
	// Token: 0x0200001B RID: 27
	public static class GamePlaySettings
	{
		// Token: 0x0600008A RID: 138 RVA: 0x00004AB4 File Offset: 0x00002CB4
		internal static void smethod_0()
		{
			GamePlaySettings.smethod_1(ServerHttpClient.DownloadJSON("gameplay.json"));
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004631 File Offset: 0x00002831
		private static void smethod_1(LogicJSONObject logicJSONObject_0)
		{
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004AC5 File Offset: 0x00002CC5
		public static LogicJSONObject Save()
		{
			return new LogicJSONObject();
		}
	}
}
