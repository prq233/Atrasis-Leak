using System;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Cooldown
{
	// Token: 0x0200016A RID: 362
	public class LogicCooldownManager
	{
		// Token: 0x060015A3 RID: 5539 RVA: 0x0000E132 File Offset: 0x0000C332
		public LogicCooldownManager()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicCooldown>();
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x0000E145 File Offset: 0x0000C345
		public void Destruct()
		{
			this.DeleteCooldowns();
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x0000E14D File Offset: 0x0000C34D
		public void DeleteCooldowns()
		{
			this.logicArrayList_0.Destruct();
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x00053978 File Offset: 0x00051B78
		public void Tick()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Tick();
				if (this.logicArrayList_0[i].GetCooldownSeconds() <= 0)
				{
					this.logicArrayList_0.Remove(i);
				}
			}
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x000539CC File Offset: 0x00051BCC
		public void FastForwardTime(int secs)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].FastForwardTime(secs);
			}
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x00053A04 File Offset: 0x00051C04
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("cooldowns");
			if (jsonarray != null)
			{
				int num = jsonarray.Size();
				for (int i = 0; i < num; i++)
				{
					LogicCooldown logicCooldown = new LogicCooldown();
					logicCooldown.Load(jsonarray.GetJSONObject(i));
					this.logicArrayList_0.Add(logicCooldown);
				}
			}
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00053A54 File Offset: 0x00051C54
		public void Save(LogicJSONObject jsonObject)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				this.logicArrayList_0[i].Save(logicJSONObject);
				logicJSONArray.Add(logicJSONObject);
			}
			jsonObject.Put("cooldowns", logicJSONArray);
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0000E15A File Offset: 0x0000C35A
		public void AddCooldown(int targetGlobalId, int cooldownSecs)
		{
			this.logicArrayList_0.Add(new LogicCooldown(targetGlobalId, cooldownSecs));
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x00053AA8 File Offset: 0x00051CA8
		public int GetCooldownSeconds(int targetGlobalId)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetTargetGlobalId() == targetGlobalId)
				{
					return this.logicArrayList_0[i].GetCooldownSeconds();
				}
			}
			return 0;
		}

		// Token: 0x04000BC8 RID: 3016
		private readonly LogicArrayList<LogicCooldown> logicArrayList_0;
	}
}
