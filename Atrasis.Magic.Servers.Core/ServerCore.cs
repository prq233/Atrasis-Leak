using System;
using System.IO;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Titan.Math;
using ns0;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x02000008 RID: 8
	public static class ServerCore
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00004728 File Offset: 0x00002928
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000472F File Offset: 0x0000292F
		public static int Type { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00004737 File Offset: 0x00002937
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000473E File Offset: 0x0000293E
		public static int Id { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00004746 File Offset: 0x00002946
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000474D File Offset: 0x0000294D
		public static string ConfigurationServer { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00004755 File Offset: 0x00002955
		// (set) Token: 0x0600001F RID: 31 RVA: 0x0000475C File Offset: 0x0000295C
		public static LogicRandom Random { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00004764 File Offset: 0x00002964
		// (set) Token: 0x06000021 RID: 33 RVA: 0x0000476B File Offset: 0x0000296B
		public static ServerSocket Socket { get; private set; }

		// Token: 0x06000022 RID: 34 RVA: 0x000096B0 File Offset: 0x000078B0
		public static void Init(int type, string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += ServerCore.smethod_0;
			ServerCore.Type = type;
			ServerCore.Id = 0;
			ServerCore.ConfigurationServer = "http://127.0.0.1/atrasis/";
			if (args.Length != 0)
			{
				if (args.Length % 2 == 0)
				{
					for (int i = 0; i < args.Length; i += 2)
					{
						string text = args[i];
						string text2 = args[i + 1];
						if (text != null)
						{
							if (!(text == "-conf"))
							{
								if (text == "-id")
								{
									ServerCore.Id = int.Parse(text2);
								}
							}
							else if (text2.Length > 0)
							{
								if (!text2.StartsWith("http://") && !text2.StartsWith("https://"))
								{
									Logging.Warning("ServerCore.init: invalid server url: " + text2);
								}
								else
								{
									if (!text2.EndsWith("/"))
									{
										text2 += "/";
									}
									ServerCore.ConfigurationServer = text2;
								}
							}
							else
							{
								Logging.Warning("ServerCore.init server url is empty");
							}
						}
					}
				}
				else
				{
					Logging.Warning("ServerCore.init invalid args length");
				}
			}
			ServerCore.Random = new LogicRandom((int)DateTime.UtcNow.Ticks);
			Directory.SetCurrentDirectory(AppContext.BaseDirectory);
			Logging.smethod_0();
			EnvironmentSettings.smethod_0();
			Bypass.key();
			ResourceSettings.smethod_0();
			GamePlaySettings.smethod_0();
			ResourceManager.smethod_0();
			ServerRequestManager.Init();
			ServerManager.Init();
			ServerCore.Socket = ServerManager.GetSocket(ServerCore.Type, ServerCore.Id);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00009810 File Offset: 0x00007A10
		private static void smethod_0(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				File.AppendAllText("crash.txt", ex.ToString());
				Logging.Error("ServerCore.onUnhandledExceptionThrown: " + ex);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000984C File Offset: 0x00007A4C
		public static void Start(ServerMessageManager messageManager)
		{
			Logging.SEND_LOGS = true;
			Class2.smethod_0(messageManager);
			ServerListenSocket.smethod_0();
			if (ServerManager.GetServerCount(0) != 0 && ServerCore.Type != 0 && EnvironmentSettings.Settings.StartInMaintenanceMode)
			{
				ServerStatus.SetStatus(ServerStatusType.MAINTENANCE, 0, 0);
				ServerMessageManager.SendMessage(new AskForServerStatusMessage(), ServerManager.GetSocket(0, 0));
			}
		}

		// Token: 0x0400000E RID: 14
		[CompilerGenerated]
		private static int int_0;

		// Token: 0x0400000F RID: 15
		[CompilerGenerated]
		private static int int_1;

		// Token: 0x04000010 RID: 16
		[CompilerGenerated]
		private static string string_0;

		// Token: 0x04000011 RID: 17
		[CompilerGenerated]
		private static LogicRandom logicRandom_0;

		// Token: 0x04000012 RID: 18
		[CompilerGenerated]
		private static ServerSocket serverSocket_0;
	}
}
