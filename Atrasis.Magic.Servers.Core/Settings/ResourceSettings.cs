using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Settings
{
	// Token: 0x0200001C RID: 28
	public static class ResourceSettings
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00004ACC File Offset: 0x00002CCC
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00004AD3 File Offset: 0x00002CD3
		public static LogicArrayList<string> ContentUrlList { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00004ADB File Offset: 0x00002CDB
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00004AE2 File Offset: 0x00002CE2
		public static LogicArrayList<string> ChronosContentUrlList { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00004AEA File Offset: 0x00002CEA
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00004AF1 File Offset: 0x00002CF1
		public static LogicArrayList<string> AppStoreUrlList { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00004AF9 File Offset: 0x00002CF9
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00004B00 File Offset: 0x00002D00
		public static string ResourceSHA { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00004B08 File Offset: 0x00002D08
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00004B0F File Offset: 0x00002D0F
		public static string FacebookAppId { get; private set; }

		// Token: 0x06000097 RID: 151 RVA: 0x00004B17 File Offset: 0x00002D17
		internal static void smethod_0()
		{
			ResourceSettings.smethod_1(ServerHttpClient.DownloadJSON("resource.json"));
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004B28 File Offset: 0x00002D28
		public static string GetContentUrl()
		{
			if (ResourceSettings.ContentUrlList.Size() > 1)
			{
				return ResourceSettings.ContentUrlList[1];
			}
			return null;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004B44 File Offset: 0x00002D44
		public static string GetAppStoreUrl(bool androidVersion)
		{
			return ResourceSettings.AppStoreUrlList[androidVersion ? 1 : 0];
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000A7DC File Offset: 0x000089DC
		private static void smethod_1(LogicJSONObject logicJSONObject_0)
		{
			ResourceSettings.ContentUrlList = ResourceSettings.smethod_2(logicJSONObject_0.GetJSONArray("contentUrls"));
			ResourceSettings.ChronosContentUrlList = ResourceSettings.smethod_2(logicJSONObject_0.GetJSONArray("chronosContentUrls"));
			ResourceSettings.AppStoreUrlList = ResourceSettings.smethod_2(logicJSONObject_0.GetJSONArray("appstoreUrls"));
			ResourceSettings.ResourceSHA = logicJSONObject_0.GetJSONString("resourceSHA").GetStringValue();
			ResourceSettings.FacebookAppId = logicJSONObject_0.GetJSONString("fbAppId").GetStringValue();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000A854 File Offset: 0x00008A54
		private static LogicArrayList<string> smethod_2(LogicJSONArray logicJSONArray_0)
		{
			LogicArrayList<string> logicArrayList = new LogicArrayList<string>();
			if (logicJSONArray_0 != null)
			{
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					logicArrayList.Add(logicJSONArray_0.GetJSONString(i).GetStringValue());
				}
			}
			return logicArrayList;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000A890 File Offset: 0x00008A90
		public static LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("contentUrls", ResourceSettings.smethod_3(ResourceSettings.ContentUrlList));
			logicJSONObject.Put("chronosContentUrls", ResourceSettings.smethod_3(ResourceSettings.ChronosContentUrlList));
			logicJSONObject.Put("appstoreUrls", ResourceSettings.smethod_3(ResourceSettings.AppStoreUrlList));
			logicJSONObject.Put("resourceSHA", new LogicJSONString(ResourceSettings.ResourceSHA));
			logicJSONObject.Put("fbAppId", new LogicJSONString(ResourceSettings.FacebookAppId));
			return logicJSONObject;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000A90C File Offset: 0x00008B0C
		private static LogicJSONArray smethod_3(LogicArrayList<string> logicArrayList_3)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < logicArrayList_3.Size(); i++)
			{
				logicJSONArray.Add(new LogicJSONString(logicArrayList_3[i]));
			}
			return logicJSONArray;
		}

		// Token: 0x0400003A RID: 58
		[CompilerGenerated]
		private static LogicArrayList<string> logicArrayList_0;

		// Token: 0x0400003B RID: 59
		[CompilerGenerated]
		private static LogicArrayList<string> logicArrayList_1;

		// Token: 0x0400003C RID: 60
		[CompilerGenerated]
		private static LogicArrayList<string> logicArrayList_2;

		// Token: 0x0400003D RID: 61
		[CompilerGenerated]
		private static string string_0;

		// Token: 0x0400003E RID: 62
		[CompilerGenerated]
		private static string string_1;
	}
}
