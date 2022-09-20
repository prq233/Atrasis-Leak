using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Battle
{
	// Token: 0x020001FC RID: 508
	public class LogicReplay
	{
		// Token: 0x06001A0B RID: 6667 RVA: 0x00011405 File Offset: 0x0000F605
		public LogicReplay(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicJSONObject_0 = new LogicJSONObject();
			this.StartRecord();
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x00011425 File Offset: 0x0000F625
		public void Destruct()
		{
			this.logicJSONObject_0 = null;
			this.logicJSONNumber_0 = null;
			this.logicJSONNumber_1 = null;
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x00062E2C File Offset: 0x0006102C
		public void StartRecord()
		{
			this.logicJSONObject_0 = new LogicJSONObject();
			this.logicJSONNumber_0 = new LogicJSONNumber();
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONObject logicJSONObject2 = new LogicJSONObject();
			LogicJSONObject logicJSONObject3 = new LogicJSONObject();
			this.logicLevel_0.SaveToJSON(logicJSONObject);
			this.logicLevel_0.GetVisitorAvatar().SaveToReplay(logicJSONObject2);
			this.logicLevel_0.GetHomeOwnerAvatar().SaveToReplay(logicJSONObject3);
			this.logicJSONObject_0.Put("level", logicJSONObject);
			this.logicJSONObject_0.Put("attacker", logicJSONObject2);
			this.logicJSONObject_0.Put("defender", logicJSONObject3);
			this.logicJSONObject_0.Put("end_tick", this.logicJSONNumber_0);
			this.logicJSONObject_0.Put("timestamp", new LogicJSONNumber(this.logicLevel_0.GetGameMode().GetStartTime()));
			this.logicJSONObject_0.Put("cmd", new LogicJSONArray());
			this.logicJSONObject_0.Put("calendar", this.logicLevel_0.GetCalendar().Save());
			if (this.logicLevel_0.GetGameMode().GetConfiguration().GetJson() != null)
			{
				this.logicJSONObject_0.Put("globals", this.logicLevel_0.GetGameMode().GetConfiguration().GetJson());
			}
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x0001143C File Offset: 0x0000F63C
		public void SubTick()
		{
			this.logicJSONNumber_0.SetIntValue(this.logicLevel_0.GetLogicTime().GetTick() + 1);
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x00062F70 File Offset: 0x00061170
		public void RecordCommand(LogicCommand command)
		{
			LogicJSONArray jsonarray = this.logicJSONObject_0.GetJSONArray("cmd");
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicCommandManager.SaveCommandToJSON(logicJSONObject, command);
			jsonarray.Add(logicJSONObject);
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x0001145B File Offset: 0x0000F65B
		public void RecordPreparationSkipTime(int secs)
		{
			if (secs > 0)
			{
				if (this.logicJSONNumber_1 == null)
				{
					this.logicJSONNumber_1 = new LogicJSONNumber();
					this.logicJSONObject_0.Put("prep_skip", this.logicJSONNumber_1);
				}
				this.logicJSONNumber_1.SetIntValue(secs);
			}
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x00011496 File Offset: 0x0000F696
		public LogicJSONObject GetJson()
		{
			return this.logicJSONObject_0;
		}

		// Token: 0x04000E09 RID: 3593
		private readonly LogicLevel logicLevel_0;

		// Token: 0x04000E0A RID: 3594
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000E0B RID: 3595
		private LogicJSONNumber logicJSONNumber_0;

		// Token: 0x04000E0C RID: 3596
		private LogicJSONNumber logicJSONNumber_1;
	}
}
