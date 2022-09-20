using System;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Cooldown
{
	// Token: 0x02000169 RID: 361
	public class LogicCooldown
	{
		// Token: 0x0600159B RID: 5531 RVA: 0x0000213B File Offset: 0x0000033B
		public LogicCooldown()
		{
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x0000E0A0 File Offset: 0x0000C2A0
		public LogicCooldown(int targetGlobalId, int cooldownSecs)
		{
			this.int_0 = targetGlobalId;
			this.int_1 = LogicTime.GetCooldownSecondsInTicks(cooldownSecs);
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x0000E0BB File Offset: 0x0000C2BB
		public void Tick()
		{
			if (this.int_1 > 0)
			{
				this.int_1--;
			}
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0000E0D4 File Offset: 0x0000C2D4
		public void FastForwardTime(int secs)
		{
			this.int_1 = LogicMath.Max(this.int_1 - LogicTime.GetCooldownSecondsInTicks(secs), 0);
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x0005391C File Offset: 0x00051B1C
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("cooldown");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("target");
			if (jsonnumber == null)
			{
				Debugger.Error("LogicCooldown::load - Cooldown was not found!");
				return;
			}
			if (jsonnumber2 == null)
			{
				Debugger.Error("LogicCooldown::load - Target was not found!");
				return;
			}
			this.int_1 = jsonnumber.GetIntValue();
			this.int_0 = jsonnumber2.GetIntValue();
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x0000E0EF File Offset: 0x0000C2EF
		public void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("cooldown", new LogicJSONNumber(this.int_1));
			jsonObject.Put("target", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x0000E11D File Offset: 0x0000C31D
		public int GetCooldownSeconds()
		{
			return LogicTime.GetCooldownTicksInSeconds(this.int_1);
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x0000E12A File Offset: 0x0000C32A
		public int GetTargetGlobalId()
		{
			return this.int_0;
		}

		// Token: 0x04000BC6 RID: 3014
		private int int_0;

		// Token: 0x04000BC7 RID: 3015
		private int int_1;
	}
}
