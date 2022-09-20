using System;
using System.Threading;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;
using Couchbase;

namespace ns0
{
	// Token: 0x02000005 RID: 5
	public static class GClass2
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002694 File Offset: 0x00000894
		public static void smethod_0()
		{
			GClass2.logicArrayList_0 = new LogicArrayList<int>();
			GClass2.logicArrayList_0.Add(50000);
			GClass2.logicArrayList_0.Add(30000);
			GClass2.logicArrayList_0.Add(15000);
			if (ServerCore.Id == 0)
			{
				DateTime dateTime = DateTime.UtcNow.AddMonths(1);
				DateTime dateTime2 = dateTime.AddMonths(-1);
				GClass2.seasonDocument_0 = GClass2.smethod_2(new LogicLong(dateTime.Year, dateTime.Month));
				GClass2.seasonDocument_1 = GClass2.smethod_3(new LogicLong(dateTime2.Year, dateTime2.Month));
				GClass2.thread_0 = new Thread(new ThreadStart(GClass2.smethod_1));
				GClass2.thread_0.Start();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002754 File Offset: 0x00000954
		private static void smethod_1()
		{
			for (;;)
			{
				Task task = ((GClass3)GClass2.seasonDocument_0).method_1();
				GClass3 gclass = (GClass3)GClass2.seasonDocument_1;
				object obj = (gclass == null) ? null : gclass.method_1();
				task.Wait();
				object obj2 = obj;
				if (obj2 != null)
				{
					obj2.Wait();
				}
				if (((GClass3)GClass2.seasonDocument_0).method_2())
				{
					DateTime dateTime = DateTime.UtcNow.AddMonths(1);
					GClass2.seasonDocument_1 = GClass2.seasonDocument_0;
					GClass2.seasonDocument_0 = GClass2.smethod_2(new LogicLong(dateTime.Year, dateTime.Month));
				}
				int i = 1;
				int serverCount = ServerManager.GetServerCount(26);
				while (i < serverCount)
				{
					ServerMessageManager.SendMessage(new ScoringSyncMessage
					{
						CurrentSeasonDocument = GClass2.seasonDocument_0,
						LastSeasonDocument = GClass2.seasonDocument_1
					}, 26, i);
					i++;
				}
				Thread.Sleep(2000);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000282C File Offset: 0x00000A2C
		private static GClass3 smethod_2(LogicLong logicLong_0)
		{
			GClass3 gclass = GClass2.smethod_3(logicLong_0);
			if (gclass == null)
			{
				IOperationResult<string> result = GClass0.smethod_4().Insert(logicLong_0, CouchbaseDocument.Save(gclass = new GClass3(logicLong_0))).Result;
				if (!result.Success)
				{
					throw result.Exception;
				}
				gclass.NextCheckTime = DateTime.UtcNow.Date.AddDays(1.0);
				gclass.method_0();
			}
			return gclass;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000028A0 File Offset: 0x00000AA0
		private static GClass3 smethod_3(LogicLong logicLong_0)
		{
			IOperationResult<string> result = GClass0.smethod_4().Get(logicLong_0).Result;
			if (result.Success)
			{
				GClass3 gclass = CouchbaseDocument.Load<GClass3>(result.Value);
				gclass.method_0();
				return gclass;
			}
			return null;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002118 File Offset: 0x00000318
		public static void smethod_4(ScoringSyncMessage scoringSyncMessage_0)
		{
			GClass2.seasonDocument_0 = scoringSyncMessage_0.CurrentSeasonDocument;
			GClass2.seasonDocument_1 = scoringSyncMessage_0.LastSeasonDocument;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002130 File Offset: 0x00000330
		public static LogicArrayList<int> smethod_5()
		{
			return GClass2.logicArrayList_0;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000028E0 File Offset: 0x00000AE0
		public static int smethod_6()
		{
			return LogicMath.Max((int)(GClass2.seasonDocument_0.EndTime.Subtract(DateTime.UtcNow).TotalSeconds + 0.99), 0);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002137 File Offset: 0x00000337
		public static int smethod_7()
		{
			return GClass2.seasonDocument_0.Year;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002143 File Offset: 0x00000343
		public static int smethod_8()
		{
			return GClass2.seasonDocument_0.Month;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000214F File Offset: 0x0000034F
		public static int smethod_9()
		{
			if (GClass2.seasonDocument_1 == null)
			{
				return 0;
			}
			return GClass2.seasonDocument_1.Year;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002164 File Offset: 0x00000364
		public static int smethod_10()
		{
			if (GClass2.seasonDocument_1 == null)
			{
				return 0;
			}
			return GClass2.seasonDocument_1.Month;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002179 File Offset: 0x00000379
		public static LogicArrayList<AllianceRankingEntry> smethod_11(int int_1, LogicLong logicLong_0)
		{
			return GClass2.smethod_17<AllianceRankingEntry>(GClass2.seasonDocument_0.AllianceRankingList[int_1], logicLong_0);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000218D File Offset: 0x0000038D
		public static LogicArrayList<AllianceRankingEntry> smethod_12(int int_1, LogicLong logicLong_0)
		{
			SeasonDocument seasonDocument = GClass2.seasonDocument_1;
			return GClass2.smethod_17<AllianceRankingEntry>((seasonDocument != null) ? seasonDocument.AllianceRankingList[int_1] : null, logicLong_0);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000021A8 File Offset: 0x000003A8
		public static LogicArrayList<AvatarRankingEntry> smethod_13(LogicLong logicLong_0)
		{
			return GClass2.smethod_17<AvatarRankingEntry>(GClass2.seasonDocument_0.AvatarRankingList, logicLong_0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000021BA File Offset: 0x000003BA
		public static LogicArrayList<AvatarRankingEntry> smethod_14(LogicLong logicLong_0)
		{
			SeasonDocument seasonDocument = GClass2.seasonDocument_1;
			return GClass2.smethod_17<AvatarRankingEntry>((seasonDocument != null) ? seasonDocument.AvatarRankingList : null, logicLong_0);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000021D3 File Offset: 0x000003D3
		public static LogicArrayList<AvatarDuelRankingEntry> smethod_15(LogicLong logicLong_0)
		{
			return GClass2.smethod_17<AvatarDuelRankingEntry>(GClass2.seasonDocument_0.AvatarDuelRankingList, logicLong_0);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000021E5 File Offset: 0x000003E5
		public static LogicArrayList<AvatarDuelRankingEntry> smethod_16(LogicLong logicLong_0)
		{
			SeasonDocument seasonDocument = GClass2.seasonDocument_1;
			return GClass2.smethod_17<AvatarDuelRankingEntry>((seasonDocument != null) ? seasonDocument.AvatarDuelRankingList : null, logicLong_0);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002920 File Offset: 0x00000B20
		private static LogicArrayList<T> smethod_17<T>(LogicArrayList<T> logicArrayList_1, LogicLong logicLong_0) where T : RankingEntry
		{
			LogicArrayList<T> logicArrayList = new LogicArrayList<T>(200);
			if (logicArrayList_1 != null)
			{
				int i = 0;
				int num = LogicMath.Min(logicArrayList_1.Size(), 200);
				while (i < num)
				{
					logicArrayList.Add(logicArrayList_1[i]);
					i++;
				}
				int j = 200;
				while (j < logicArrayList_1.Size())
				{
					if (!logicArrayList_1[j].GetId().Equals(logicLong_0))
					{
						j++;
					}
					else
					{
						if (j > 0)
						{
							logicArrayList.Add(logicArrayList_1[j - 1]);
						}
						logicArrayList.Add(logicArrayList_1[j]);
						if (j + 1 < logicArrayList_1.Size())
						{
							logicArrayList.Add(logicArrayList_1[j + 1]);
							break;
						}
						break;
					}
				}
			}
			return logicArrayList;
		}

		// Token: 0x04000004 RID: 4
		private const int int_0 = 200;

		// Token: 0x04000005 RID: 5
		private static LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000006 RID: 6
		private static Thread thread_0;

		// Token: 0x04000007 RID: 7
		private static SeasonDocument seasonDocument_0;

		// Token: 0x04000008 RID: 8
		private static SeasonDocument seasonDocument_1;
	}
}
