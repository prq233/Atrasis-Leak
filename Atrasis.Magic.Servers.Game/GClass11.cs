using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Helper;

namespace ns0
{
	// Token: 0x02000018 RID: 24
	public static class GClass11
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000267F File Offset: 0x0000087F
		[CompilerGenerated]
		public static byte[] smethod_0()
		{
			return GClass11.byte_0;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002686 File Offset: 0x00000886
		[CompilerGenerated]
		private static void smethod_1(byte[] byte_1)
		{
			GClass11.byte_0 = byte_1;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000268E File Offset: 0x0000088E
		[CompilerGenerated]
		public static LogicClientHome[] smethod_2()
		{
			return GClass11.logicClientHome_0;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002695 File Offset: 0x00000895
		[CompilerGenerated]
		private static void smethod_3(LogicClientHome[] logicClientHome_1)
		{
			GClass11.logicClientHome_0 = logicClientHome_1;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000067A0 File Offset: 0x000049A0
		public static void smethod_4()
		{
			GClass11.smethod_1(GClass11.smethod_5(ServerHttpClient.DownloadBytes("data/level/starting_home.json")));
			GClass11.smethod_3(new LogicClientHome[LogicDataTables.GetTable(LogicDataType.NPC).GetItemCount()]);
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.NPC);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicNpcData logicNpcData = (LogicNpcData)table.GetItemAt(i);
				LogicClientHome logicClientHome = new LogicClientHome();
				logicClientHome.GetCompressibleHomeJSON().Set(GClass11.smethod_5(ServerHttpClient.DownloadBytes("data/" + logicNpcData.GetLevelFile())));
				GClass11.smethod_2()[i] = logicClientHome;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006830 File Offset: 0x00004A30
		private static byte[] smethod_5(byte[] byte_1)
		{
			byte[] result;
			ZLibHelper.CompressInZLibFormat(byte_1, out result);
			return result;
		}

		// Token: 0x04000034 RID: 52
		[CompilerGenerated]
		private static byte[] byte_0;

		// Token: 0x04000035 RID: 53
		[CompilerGenerated]
		private static LogicClientHome[] logicClientHome_0;
	}
}
