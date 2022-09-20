using System;

namespace Atrasis.Magic.Servers.Core.Util
{
	// Token: 0x0200000F RID: 15
	public static class TimeUtil
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00009BA8 File Offset: 0x00007DA8
		public static int GetTimestamp()
		{
			return (int)DateTime.UtcNow.Subtract(TimeUtil.dateTime_0).TotalSeconds;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00009BD0 File Offset: 0x00007DD0
		public static int GetTimestamp(DateTime utc)
		{
			return (int)utc.Subtract(TimeUtil.dateTime_0).TotalSeconds;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00009BF4 File Offset: 0x00007DF4
		public static long GetTimestampMS()
		{
			return (long)((int)DateTime.UtcNow.Subtract(TimeUtil.dateTime_0).TotalMilliseconds);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00009C20 File Offset: 0x00007E20
		public static long GetTimestampMS(DateTime utc)
		{
			return (long)((int)utc.Subtract(TimeUtil.dateTime_0).TotalMilliseconds);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004806 File Offset: 0x00002A06
		public static DateTime GetDateTimeFromTimestamp(int timestamp)
		{
			return TimeUtil.dateTime_0.AddSeconds((double)timestamp);
		}

		// Token: 0x0400001C RID: 28
		private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1);
	}
}
