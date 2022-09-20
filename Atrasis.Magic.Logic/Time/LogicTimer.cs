using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Time
{
	// Token: 0x02000016 RID: 22
	public class LogicTimer
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00002A49 File Offset: 0x00000C49
		public LogicTimer()
		{
			this.int_1 = -1;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002A58 File Offset: 0x00000C58
		public void Destruct()
		{
			this.int_0 = 0;
			this.int_1 = -1;
			this.int_2 = 0;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00016E8C File Offset: 0x0001508C
		public int GetRemainingSeconds(LogicTime time)
		{
			int num = this.int_0 - time.GetTick() - this.int_2;
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				if (num > 0)
				{
					return LogicMath.Max((int)(16L * (long)num / 1000L + 1L), 1);
				}
			}
			else if (num > 0)
			{
				return LogicMath.Max((num + 59) / 60, 1);
			}
			return 0;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00016EFC File Offset: 0x000150FC
		public int GetRemainingMS(LogicTime time)
		{
			int num = this.int_0 - time.GetTick() - this.int_2;
			if (LogicDataTables.GetGlobals().MoreAccurateTime())
			{
				return 16 * num;
			}
			int num2 = 1000 * (num / 60);
			if (num2 % 60 != 0)
			{
				num2 += 2133 * num2 >> 7;
			}
			return num2;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00002A6F File Offset: 0x00000C6F
		public void StartTimer(int totalSecs, LogicTime time, bool setEndTimestamp, int currentTimestamp)
		{
			this.int_0 = LogicTime.GetSecondsInTicks(totalSecs) + time.GetTick();
			if (currentTimestamp != -1 && setEndTimestamp)
			{
				this.int_1 = currentTimestamp + totalSecs;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00002A9A File Offset: 0x00000C9A
		public void FastForward(int totalSecs)
		{
			this.int_0 -= LogicTime.GetSecondsInTicks(totalSecs);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00002AAF File Offset: 0x00000CAF
		public void FastForwardSubticks(int tick)
		{
			if (tick > 0)
			{
				this.int_0 -= tick;
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00016F50 File Offset: 0x00015150
		public void AdjustEndSubtick(LogicLevel level)
		{
			if (this.int_1 != -1)
			{
				int num = LogicDataTables.GetGlobals().AdjustEndSubtickUseCurrentTime() ? level.GetGameMode().GetServerTimeInSecondsSince1970() : level.GetGameMode().GetStartTime();
				if (num != -1)
				{
					int num2 = this.int_1 - num;
					int clampLongTimeStampsToDays = LogicDataTables.GetGlobals().GetClampLongTimeStampsToDays();
					if (clampLongTimeStampsToDays * 86400 > 0)
					{
						if (num2 > 86400 * clampLongTimeStampsToDays)
						{
							num2 = 86400 * clampLongTimeStampsToDays;
						}
						else if (num2 < -86400 * clampLongTimeStampsToDays)
						{
							num2 = -86400 * clampLongTimeStampsToDays;
						}
					}
					this.int_0 = level.GetLogicTime().GetTick() + LogicTime.GetSecondsInTicks(num2);
				}
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00002AC3 File Offset: 0x00000CC3
		public int GetEndTimestamp()
		{
			return this.int_1;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002ACB File Offset: 0x00000CCB
		public void SetEndTimestamp(int endTimestamp)
		{
			this.int_1 = endTimestamp;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00002AD4 File Offset: 0x00000CD4
		public int GetFastForward()
		{
			return this.int_2;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00002ADC File Offset: 0x00000CDC
		public void SetFastForward(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00016FF0 File Offset: 0x000151F0
		public static void SetLogicTimer(LogicJSONObject jsonObject, LogicTimer timer, LogicLevel level, string key)
		{
			if (timer != null)
			{
				int remainingSeconds = timer.GetRemainingSeconds(level.GetLogicTime());
				if (remainingSeconds > 0)
				{
					jsonObject.Put(key, new LogicJSONNumber(remainingSeconds));
				}
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00017020 File Offset: 0x00015220
		public static LogicTimer GetLogicTimer(LogicJSONObject jsonObject, LogicTime time, string key, int maxTime)
		{
			LogicJSONNumber logicJSONNumber = (LogicJSONNumber)jsonObject.Get(key);
			if (logicJSONNumber != null)
			{
				LogicTimer logicTimer = new LogicTimer();
				int time2 = LogicMath.Min(logicJSONNumber.GetIntValue(), maxTime);
				int tick = time.GetTick();
				logicTimer.int_0 = tick + LogicTime.GetSecondsInTicks(time2);
				return logicTimer;
			}
			return null;
		}

		// Token: 0x0400006C RID: 108
		private int int_0;

		// Token: 0x0400006D RID: 109
		private int int_1;

		// Token: 0x0400006E RID: 110
		private int int_2;
	}
}
