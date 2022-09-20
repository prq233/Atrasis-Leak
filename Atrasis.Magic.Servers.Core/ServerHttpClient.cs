using System;
using System.Net;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x0200000C RID: 12
	public static class ServerHttpClient
	{
		// Token: 0x06000032 RID: 50 RVA: 0x000047D7 File Offset: 0x000029D7
		private static WebClient smethod_0()
		{
			return new WebClient
			{
				Proxy = null
			};
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000098A4 File Offset: 0x00007AA4
		public static byte[] DownloadBytes(string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return webClient.DownloadData(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000990C File Offset: 0x00007B0C
		public static string DownloadString(string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return webClient.DownloadString(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00009974 File Offset: 0x00007B74
		public static LogicJSONObject DownloadJSON(string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return LogicJSONParser.ParseObject(webClient.DownloadString(string.Format("{0}/{1}", ServerCore.ConfigurationServer, path)));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000099E4 File Offset: 0x00007BE4
		public static byte[] DownloadAsset(string resourceSha, string path)
		{
			try
			{
				using (WebClient webClient = ServerHttpClient.smethod_0())
				{
					return webClient.DownloadData(string.Format("{0}/{1}/{2}", ResourceSettings.GetContentUrl(), resourceSha, path));
				}
			}
			catch (Exception)
			{
				Logging.Warning(string.Format("ServerHttpClient: file {0} doesn't exist", path));
			}
			return null;
		}
	}
}
