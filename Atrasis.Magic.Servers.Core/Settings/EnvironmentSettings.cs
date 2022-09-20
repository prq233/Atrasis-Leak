using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Settings
{
	// Token: 0x02000011 RID: 17
	public static class EnvironmentSettings
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00004859 File Offset: 0x00002A59
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004860 File Offset: 0x00002A60
		public static EnvironmentSettings.ServerConnectionEntry[][] Servers { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004868 File Offset: 0x00002A68
		// (set) Token: 0x06000046 RID: 70 RVA: 0x0000486F File Offset: 0x00002A6F
		public static EnvironmentSettings.CouchbaseSettings Couchbase { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004877 File Offset: 0x00002A77
		// (set) Token: 0x06000048 RID: 72 RVA: 0x0000487E File Offset: 0x00002A7E
		public static EnvironmentSettings.RedisSettings Redis { get; private set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00004886 File Offset: 0x00002A86
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000488D File Offset: 0x00002A8D
		public static EnvironmentSettings.ServerSettings Settings { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00004895 File Offset: 0x00002A95
		// (set) Token: 0x0600004C RID: 76 RVA: 0x0000489C File Offset: 0x00002A9C
		public static string Environment { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000048A4 File Offset: 0x00002AA4
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000048AB File Offset: 0x00002AAB
		public static int HigherIdCounterSize { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000048B3 File Offset: 0x00002AB3
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000048BA File Offset: 0x00002ABA
		public static string[] SupportedAppVersions { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000048C2 File Offset: 0x00002AC2
		// (set) Token: 0x06000052 RID: 82 RVA: 0x000048C9 File Offset: 0x00002AC9
		public static string[] SupportedCountries { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000048D1 File Offset: 0x00002AD1
		// (set) Token: 0x06000054 RID: 84 RVA: 0x000048D8 File Offset: 0x00002AD8
		public static string[] DeveloperIPs { get; private set; }

		// Token: 0x06000055 RID: 85 RVA: 0x00009CD4 File Offset: 0x00007ED4
		internal static void smethod_0()
		{
			EnvironmentSettings.Servers = new EnvironmentSettings.ServerConnectionEntry[30][];
			EnvironmentSettings.Couchbase = default(EnvironmentSettings.CouchbaseSettings);
			EnvironmentSettings.SupportedAppVersions = new string[0];
			EnvironmentSettings.SupportedCountries = new string[0];
			EnvironmentSettings.DeveloperIPs = new string[0];
			for (int i = 0; i < 30; i++)
			{
				EnvironmentSettings.Servers[i] = new EnvironmentSettings.ServerConnectionEntry[0];
			}
			EnvironmentSettings.smethod_1(ServerHttpClient.DownloadJSON("environment.json"));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000048E0 File Offset: 0x00002AE0
		public static bool IsSupportedAppVersion(string appVersion)
		{
			return EnvironmentSettings.SupportedAppVersions.Length == 0 || Array.IndexOf<string>(EnvironmentSettings.SupportedAppVersions, appVersion) != -1;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000048FD File Offset: 0x00002AFD
		public static bool IsSupportedCountry(string country)
		{
			return EnvironmentSettings.SupportedCountries.Length == 0 || Array.IndexOf<string>(EnvironmentSettings.SupportedCountries, country) != -1;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000491A File Offset: 0x00002B1A
		public static bool IsDeveloperIP(string ip)
		{
			return Array.IndexOf<string>(EnvironmentSettings.DeveloperIPs, ip) != -1;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000492D File Offset: 0x00002B2D
		public static bool IsStageServer()
		{
			return EnvironmentSettings.Environment.StartsWith("stage");
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000493E File Offset: 0x00002B3E
		public static bool IsIntegrationServer()
		{
			return EnvironmentSettings.Environment.StartsWith("integration");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000494F File Offset: 0x00002B4F
		public static bool IsProductionServer()
		{
			return EnvironmentSettings.Environment.Equals("prod");
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00009D48 File Offset: 0x00007F48
		private static void smethod_1(LogicJSONObject logicJSONObject_0)
		{
			EnvironmentSettings.Environment = logicJSONObject_0.GetJSONString("environment").GetStringValue();
			LogicJSONObject jsonobject = logicJSONObject_0.GetJSONObject("servers");
			if (jsonobject != null)
			{
				EnvironmentSettings.Settings = new EnvironmentSettings.ServerSettings(jsonobject.GetJSONObject("settings"));
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("admin"), 0);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("proxy"), 1);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("account"), 2);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("friend"), 3);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("chat"), 6);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("game"), 9);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("home"), 10);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("stream"), 11);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("league"), 13);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("war"), 25);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("battle"), 27);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("scoring"), 28);
				EnvironmentSettings.smethod_2(jsonobject.GetJSONArray("search"), 29);
			}
			LogicJSONObject jsonobject2 = logicJSONObject_0.GetJSONObject("database");
			if (jsonobject2 != null)
			{
				EnvironmentSettings.HigherIdCounterSize = jsonobject2.GetJSONNumber("higher_id_counter_size").GetIntValue();
				EnvironmentSettings.Couchbase = new EnvironmentSettings.CouchbaseSettings(jsonobject2.GetJSONObject("couchbase"));
				EnvironmentSettings.Redis = new EnvironmentSettings.RedisSettings(jsonobject2.GetJSONObject("redis"));
			}
			EnvironmentSettings.SupportedAppVersions = EnvironmentSettings.smethod_3(logicJSONObject_0.GetJSONArray("supported_app_versions"));
			EnvironmentSettings.SupportedCountries = EnvironmentSettings.smethod_3(logicJSONObject_0.GetJSONArray("supported_countries"));
			EnvironmentSettings.DeveloperIPs = EnvironmentSettings.smethod_3(logicJSONObject_0.GetJSONArray("developer_ips"));
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00009F04 File Offset: 0x00008104
		private static void smethod_2(LogicJSONArray logicJSONArray_0, int int_1)
		{
			EnvironmentSettings.ServerConnectionEntry[] array;
			if (logicJSONArray_0 != null)
			{
				array = new EnvironmentSettings.ServerConnectionEntry[logicJSONArray_0.Size()];
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					array[i] = new EnvironmentSettings.ServerConnectionEntry(logicJSONArray_0.GetJSONString(i));
				}
			}
			else
			{
				array = new EnvironmentSettings.ServerConnectionEntry[0];
			}
			EnvironmentSettings.Servers[int_1] = array;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00009F58 File Offset: 0x00008158
		private static string[] smethod_3(LogicJSONArray logicJSONArray_0)
		{
			string[] array;
			if (logicJSONArray_0 != null)
			{
				array = new string[logicJSONArray_0.Size()];
				for (int i = 0; i < logicJSONArray_0.Size(); i++)
				{
					array[i] = logicJSONArray_0.GetJSONString(i).GetStringValue();
				}
			}
			else
			{
				array = new string[0];
			}
			return array;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00009FA0 File Offset: 0x000081A0
		public static LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("environment", new LogicJSONString(EnvironmentSettings.Environment));
			LogicJSONObject logicJSONObject2 = new LogicJSONObject();
			logicJSONObject2.Put("settings", EnvironmentSettings.Settings.Save());
			logicJSONObject2.Put("admin", EnvironmentSettings.smethod_4(0));
			logicJSONObject2.Put("proxy", EnvironmentSettings.smethod_4(1));
			logicJSONObject2.Put("account", EnvironmentSettings.smethod_4(2));
			logicJSONObject2.Put("friend", EnvironmentSettings.smethod_4(3));
			logicJSONObject2.Put("chat", EnvironmentSettings.smethod_4(6));
			logicJSONObject2.Put("avatar", EnvironmentSettings.smethod_4(9));
			logicJSONObject2.Put("home", EnvironmentSettings.smethod_4(10));
			logicJSONObject2.Put("stream", EnvironmentSettings.smethod_4(11));
			logicJSONObject2.Put("league", EnvironmentSettings.smethod_4(13));
			logicJSONObject2.Put("war", EnvironmentSettings.smethod_4(25));
			logicJSONObject2.Put("battle", EnvironmentSettings.smethod_4(27));
			logicJSONObject2.Put("scoring", EnvironmentSettings.smethod_4(28));
			logicJSONObject2.Put("search", EnvironmentSettings.smethod_4(29));
			logicJSONObject.Put("servers", logicJSONObject2);
			LogicJSONObject logicJSONObject3 = new LogicJSONObject();
			logicJSONObject3.Put("higher_id_counter_size", new LogicJSONNumber(EnvironmentSettings.HigherIdCounterSize));
			logicJSONObject3.Put("couchbase", EnvironmentSettings.Couchbase.Save());
			logicJSONObject3.Put("redis", EnvironmentSettings.Redis.Save());
			logicJSONObject.Put("supported_app_versions", EnvironmentSettings.smethod_5(EnvironmentSettings.SupportedAppVersions));
			logicJSONObject.Put("supported_countries", EnvironmentSettings.smethod_5(EnvironmentSettings.SupportedCountries));
			logicJSONObject.Put("developer_ips", EnvironmentSettings.smethod_5(EnvironmentSettings.DeveloperIPs));
			return logicJSONObject;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000A160 File Offset: 0x00008360
		private static LogicJSONArray smethod_4(int int_1)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			if (EnvironmentSettings.Servers[int_1] != null)
			{
				EnvironmentSettings.ServerConnectionEntry[] array = EnvironmentSettings.Servers[int_1];
				for (int i = 0; i < array.Length; i++)
				{
					logicJSONArray.Add(array[i].Save());
				}
			}
			return logicJSONArray;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000A1A8 File Offset: 0x000083A8
		private static LogicJSONArray smethod_5(string[] string_4)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			if (string_4 != null)
			{
				for (int i = 0; i < string_4.Length; i++)
				{
					logicJSONArray.Add(new LogicJSONString(string_4[i]));
				}
			}
			return logicJSONArray;
		}

		// Token: 0x0400001E RID: 30
		public const int SERVER_TYPE_COUNT = 30;

		// Token: 0x0400001F RID: 31
		[CompilerGenerated]
		private static EnvironmentSettings.ServerConnectionEntry[][] serverConnectionEntry_0;

		// Token: 0x04000020 RID: 32
		[CompilerGenerated]
		private static EnvironmentSettings.CouchbaseSettings couchbaseSettings_0;

		// Token: 0x04000021 RID: 33
		[CompilerGenerated]
		private static EnvironmentSettings.RedisSettings redisSettings_0;

		// Token: 0x04000022 RID: 34
		[CompilerGenerated]
		private static EnvironmentSettings.ServerSettings serverSettings_0;

		// Token: 0x04000023 RID: 35
		[CompilerGenerated]
		private static string string_0;

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private static int int_0;

		// Token: 0x04000025 RID: 37
		[CompilerGenerated]
		private static string[] string_1;

		// Token: 0x04000026 RID: 38
		[CompilerGenerated]
		private static string[] string_2;

		// Token: 0x04000027 RID: 39
		[CompilerGenerated]
		private static string[] string_3;

		// Token: 0x02000012 RID: 18
		public struct RedisSettings
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000062 RID: 98 RVA: 0x00004960 File Offset: 0x00002B60
			public LogicArrayList<EnvironmentSettings.RedisSettings.RedisDatabaseEntry> Databases { get; }

			// Token: 0x06000063 RID: 99 RVA: 0x0000A1DC File Offset: 0x000083DC
			public RedisSettings(LogicJSONObject jsonObject)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("databases");
				this.Databases = new LogicArrayList<EnvironmentSettings.RedisSettings.RedisDatabaseEntry>(jsonarray.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.Databases.Add(new EnvironmentSettings.RedisSettings.RedisDatabaseEntry(jsonarray.GetJSONObject(i)));
				}
			}

			// Token: 0x06000064 RID: 100 RVA: 0x0000A230 File Offset: 0x00008430
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.Databases.Size(); i++)
				{
					logicJSONArray.Add(this.Databases[i].Save());
				}
				logicJSONObject.Put("databases", logicJSONArray);
				return logicJSONObject;
			}

			// Token: 0x06000065 RID: 101 RVA: 0x0000A284 File Offset: 0x00008484
			public bool TryGetDatabase(string name, out EnvironmentSettings.RedisSettings.RedisDatabaseEntry entry)
			{
				for (int i = 0; i < this.Databases.Size(); i++)
				{
					if (this.Databases[i].Name == name)
					{
						entry = this.Databases[i];
						return true;
					}
				}
				entry = null;
				return false;
			}

			// Token: 0x04000028 RID: 40
			[CompilerGenerated]
			private readonly LogicArrayList<EnvironmentSettings.RedisSettings.RedisDatabaseEntry> logicArrayList_0;

			// Token: 0x02000013 RID: 19
			public class RedisDatabaseEntry
			{
				// Token: 0x17000014 RID: 20
				// (get) Token: 0x06000066 RID: 102 RVA: 0x00004968 File Offset: 0x00002B68
				public string Name { get; }

				// Token: 0x17000015 RID: 21
				// (get) Token: 0x06000067 RID: 103 RVA: 0x00004970 File Offset: 0x00002B70
				public string ConnectionString { get; }

				// Token: 0x06000068 RID: 104 RVA: 0x00004978 File Offset: 0x00002B78
				public RedisDatabaseEntry(LogicJSONObject jsonObject)
				{
					this.Name = jsonObject.GetJSONString("name").GetStringValue();
					this.ConnectionString = jsonObject.GetJSONString("connectionString").GetStringValue();
				}

				// Token: 0x06000069 RID: 105 RVA: 0x000049AC File Offset: 0x00002BAC
				public LogicJSONObject Save()
				{
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					logicJSONObject.Put("name", new LogicJSONString(this.Name));
					logicJSONObject.Put("connectionString", new LogicJSONString(this.ConnectionString));
					return logicJSONObject;
				}

				// Token: 0x04000029 RID: 41
				[CompilerGenerated]
				private readonly string string_0;

				// Token: 0x0400002A RID: 42
				[CompilerGenerated]
				private readonly string string_1;
			}
		}

		// Token: 0x02000014 RID: 20
		public struct ServerSettings
		{
			// Token: 0x17000016 RID: 22
			// (get) Token: 0x0600006A RID: 106 RVA: 0x000049DF File Offset: 0x00002BDF
			public EnvironmentSettings.ServerSettings.ProxySettings Proxy { get; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600006B RID: 107 RVA: 0x000049E7 File Offset: 0x00002BE7
			public EnvironmentSettings.ServerSettings.AdminSettings Admin { get; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600006C RID: 108 RVA: 0x000049EF File Offset: 0x00002BEF
			public bool ContentValidationModeEnabled { get; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600006D RID: 109 RVA: 0x000049F7 File Offset: 0x00002BF7
			public bool StartInMaintenanceMode { get; }

			// Token: 0x0600006E RID: 110 RVA: 0x0000A2D4 File Offset: 0x000084D4
			public ServerSettings(LogicJSONObject jsonObject)
			{
				this.ContentValidationModeEnabled = jsonObject.GetJSONBoolean("contentValidationModeEnabled").IsTrue();
				this.StartInMaintenanceMode = jsonObject.GetJSONBoolean("startInMaintenanceMode").IsTrue();
				this.Admin = new EnvironmentSettings.ServerSettings.AdminSettings(jsonObject.GetJSONObject("admin"));
				this.Proxy = new EnvironmentSettings.ServerSettings.ProxySettings();
			}

			// Token: 0x0600006F RID: 111 RVA: 0x0000A330 File Offset: 0x00008530
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("contentValidationModeEnabled", new LogicJSONBoolean(this.ContentValidationModeEnabled));
				logicJSONObject.Put("startInMaintenanceMode", new LogicJSONBoolean(this.StartInMaintenanceMode));
				logicJSONObject.Put("admin", this.Admin.Save());
				return logicJSONObject;
			}

			// Token: 0x0400002B RID: 43
			[CompilerGenerated]
			private readonly EnvironmentSettings.ServerSettings.ProxySettings proxySettings_0;

			// Token: 0x0400002C RID: 44
			[CompilerGenerated]
			private readonly EnvironmentSettings.ServerSettings.AdminSettings adminSettings_0;

			// Token: 0x0400002D RID: 45
			[CompilerGenerated]
			private readonly bool bool_0;

			// Token: 0x0400002E RID: 46
			[CompilerGenerated]
			private readonly bool bool_1;

			// Token: 0x02000015 RID: 21
			public class ProxySettings
			{
				// Token: 0x1700001A RID: 26
				// (get) Token: 0x06000070 RID: 112 RVA: 0x000049FF File Offset: 0x00002BFF
				// (set) Token: 0x06000071 RID: 113 RVA: 0x00004A07 File Offset: 0x00002C07
				public int SessionCapacity { get; set; }

				// Token: 0x0400002F RID: 47
				[CompilerGenerated]
				private int int_0;
			}

			// Token: 0x02000016 RID: 22
			public class AdminSettings
			{
				// Token: 0x1700001B RID: 27
				// (get) Token: 0x06000073 RID: 115 RVA: 0x00004A10 File Offset: 0x00002C10
				public LogicArrayList<string> PresetLevelFiles { get; }

				// Token: 0x06000074 RID: 116 RVA: 0x0000A384 File Offset: 0x00008584
				public AdminSettings(LogicJSONObject jsonObject)
				{
					LogicJSONArray jsonarray = jsonObject.GetJSONArray("presetLevelFiles");
					if (jsonarray != null)
					{
						this.PresetLevelFiles = new LogicArrayList<string>(jsonarray.Size());
						for (int i = 0; i < jsonarray.Size(); i++)
						{
							this.PresetLevelFiles.Add(jsonarray.GetJSONString(i).GetStringValue());
						}
						return;
					}
					this.PresetLevelFiles = null;
				}

				// Token: 0x06000075 RID: 117 RVA: 0x0000A3E8 File Offset: 0x000085E8
				public LogicJSONObject Save()
				{
					LogicJSONObject logicJSONObject = new LogicJSONObject();
					if (this.PresetLevelFiles != null)
					{
						LogicJSONArray logicJSONArray = new LogicJSONArray();
						for (int i = 0; i < this.PresetLevelFiles.Size(); i++)
						{
							logicJSONArray.Add(new LogicJSONString(this.PresetLevelFiles[i]));
						}
						logicJSONObject.Put("presetLevelFiles", logicJSONArray);
					}
					return logicJSONObject;
				}

				// Token: 0x04000030 RID: 48
				[CompilerGenerated]
				private readonly LogicArrayList<string> logicArrayList_0;
			}
		}

		// Token: 0x02000017 RID: 23
		public struct ServerConnectionEntry
		{
			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000076 RID: 118 RVA: 0x00004A18 File Offset: 0x00002C18
			public string ServerIP { get; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000077 RID: 119 RVA: 0x00004A20 File Offset: 0x00002C20
			public int ServerPort { get; }

			// Token: 0x06000078 RID: 120 RVA: 0x0000A444 File Offset: 0x00008644
			public ServerConnectionEntry(LogicJSONString jsonString)
			{
				string[] array = jsonString.GetStringValue().Split(':', StringSplitOptions.None);
				Logging.Assert(array.Length == 2, "Malformed connection string!");
				this.ServerIP = array[0];
				this.ServerPort = int.Parse(array[1]);
			}

			// Token: 0x06000079 RID: 121 RVA: 0x00004A28 File Offset: 0x00002C28
			public ServerConnectionEntry(string ip, int port)
			{
				this.ServerIP = ip;
				this.ServerPort = port;
			}

			// Token: 0x0600007A RID: 122 RVA: 0x00004A38 File Offset: 0x00002C38
			public LogicJSONString Save()
			{
				return new LogicJSONString(string.Format("{0}:{1}", this.ServerIP, this.ServerPort));
			}

			// Token: 0x04000031 RID: 49
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x04000032 RID: 50
			[CompilerGenerated]
			private readonly int int_0;
		}

		// Token: 0x02000018 RID: 24
		public struct CouchbaseSettings
		{
			// Token: 0x1700001E RID: 30
			// (get) Token: 0x0600007B RID: 123 RVA: 0x00004A5A File Offset: 0x00002C5A
			public LogicArrayList<EnvironmentSettings.CouchbaseServerEntry> Servers { get; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00004A62 File Offset: 0x00002C62
			public LogicArrayList<EnvironmentSettings.CouchbaseBucketEntry> Buckets { get; }

			// Token: 0x0600007D RID: 125 RVA: 0x0000A488 File Offset: 0x00008688
			public CouchbaseSettings(LogicJSONObject jsonObject)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("servers");
				LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("buckets");
				this.Servers = new LogicArrayList<EnvironmentSettings.CouchbaseServerEntry>(jsonarray.Size());
				this.Buckets = new LogicArrayList<EnvironmentSettings.CouchbaseBucketEntry>(jsonarray2.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.Servers.Add(new EnvironmentSettings.CouchbaseServerEntry(jsonarray.GetJSONObject(i)));
				}
				for (int j = 0; j < jsonarray2.Size(); j++)
				{
					EnvironmentSettings.CouchbaseBucketEntry couchbaseBucketEntry = new EnvironmentSettings.CouchbaseBucketEntry(jsonarray2.GetJSONString(j));
					if (this.method_0(couchbaseBucketEntry.Name) != -1)
					{
						Logging.Warning("EnvironmentSettings::CouchbaseSettings.ctr: bucket with the same name already exists.");
					}
					else if ((ulong)couchbaseBucketEntry.ServerIndex >= (ulong)((long)this.Servers.Size()))
					{
						Logging.Warning(string.Format("EnvironmentSettings::CouchbaseSettings.ctr: server index is out of bounds (bucket name: {0})", couchbaseBucketEntry.ServerIndex));
					}
					else
					{
						this.Buckets.Add(couchbaseBucketEntry);
					}
				}
			}

			// Token: 0x0600007E RID: 126 RVA: 0x0000A574 File Offset: 0x00008774
			private int method_0(string string_0)
			{
				for (int i = 0; i < this.Buckets.Size(); i++)
				{
					if (this.Buckets[i].Name.Equals(string_0, StringComparison.InvariantCultureIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x0600007F RID: 127 RVA: 0x0000A5B4 File Offset: 0x000087B4
			public bool TryGetBucketData(string name, out EnvironmentSettings.CouchbaseServerEntry serverEntry, out EnvironmentSettings.CouchbaseBucketEntry bucketEntry)
			{
				int num = this.method_0(name);
				if (num != -1)
				{
					bucketEntry = this.Buckets[num];
					serverEntry = this.Servers[bucketEntry.ServerIndex];
					return true;
				}
				serverEntry = null;
				bucketEntry = null;
				return false;
			}

			// Token: 0x06000080 RID: 128 RVA: 0x0000A5F8 File Offset: 0x000087F8
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				for (int i = 0; i < this.Servers.Size(); i++)
				{
					logicJSONArray.Add(this.Servers[i].Save());
				}
				for (int j = 0; j < this.Buckets.Size(); j++)
				{
					logicJSONArray2.Add(this.Buckets[j].Save());
				}
				logicJSONObject.Put("servers", logicJSONArray);
				logicJSONObject.Put("buckets", logicJSONArray2);
				return logicJSONObject;
			}

			// Token: 0x04000033 RID: 51
			[CompilerGenerated]
			private readonly LogicArrayList<EnvironmentSettings.CouchbaseServerEntry> logicArrayList_0;

			// Token: 0x04000034 RID: 52
			[CompilerGenerated]
			private readonly LogicArrayList<EnvironmentSettings.CouchbaseBucketEntry> logicArrayList_1;
		}

		// Token: 0x02000019 RID: 25
		public class CouchbaseServerEntry
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000081 RID: 129 RVA: 0x00004A6A File Offset: 0x00002C6A
			public Uri[] Hosts { get; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000082 RID: 130 RVA: 0x00004A72 File Offset: 0x00002C72
			public string Username { get; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000083 RID: 131 RVA: 0x00004A7A File Offset: 0x00002C7A
			public string Password { get; }

			// Token: 0x06000084 RID: 132 RVA: 0x0000A690 File Offset: 0x00008890
			public CouchbaseServerEntry(LogicJSONObject jsonObject)
			{
				LogicJSONArray jsonarray = jsonObject.GetJSONArray("hosts");
				this.Hosts = new Uri[jsonarray.Size()];
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.Hosts[i] = new Uri("http://" + jsonarray.GetJSONString(i).GetStringValue());
				}
				this.Username = jsonObject.GetJSONString("username").GetStringValue();
				this.Password = jsonObject.GetJSONString("password").GetStringValue();
			}

			// Token: 0x06000085 RID: 133 RVA: 0x0000A720 File Offset: 0x00008920
			public LogicJSONObject Save()
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.Hosts.Length; i++)
				{
					logicJSONArray.Add(new LogicJSONString(this.Hosts[i].ToString()));
				}
				logicJSONObject.Put("hosts", logicJSONArray);
				logicJSONObject.Put("username", new LogicJSONString(this.Username));
				logicJSONObject.Put("password", new LogicJSONString(this.Password));
				return logicJSONObject;
			}

			// Token: 0x04000035 RID: 53
			[CompilerGenerated]
			private readonly Uri[] uri_0;

			// Token: 0x04000036 RID: 54
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x04000037 RID: 55
			[CompilerGenerated]
			private readonly string string_1;
		}

		// Token: 0x0200001A RID: 26
		public class CouchbaseBucketEntry
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000086 RID: 134 RVA: 0x00004A82 File Offset: 0x00002C82
			public string Name { get; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000087 RID: 135 RVA: 0x00004A8A File Offset: 0x00002C8A
			public int ServerIndex { get; }

			// Token: 0x06000088 RID: 136 RVA: 0x0000A7A0 File Offset: 0x000089A0
			public CouchbaseBucketEntry(LogicJSONString str)
			{
				string[] array = str.GetStringValue().Split(':', StringSplitOptions.None);
				this.Name = array[0];
				this.ServerIndex = int.Parse(array[1]);
			}

			// Token: 0x06000089 RID: 137 RVA: 0x00004A92 File Offset: 0x00002C92
			public LogicJSONString Save()
			{
				return new LogicJSONString(string.Format("{0}:{1}", this.Name, this.ServerIndex));
			}

			// Token: 0x04000038 RID: 56
			[CompilerGenerated]
			private readonly string string_0;

			// Token: 0x04000039 RID: 57
			[CompilerGenerated]
			private readonly int int_0;
		}
	}
}
