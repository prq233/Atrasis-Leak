using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F9 RID: 505
	public class LogicDuelLootLimitCalendarEvent : LogicCalendarEvent
	{
		// Token: 0x060019C2 RID: 6594 RVA: 0x00061B8C File Offset: 0x0005FD8C
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			this.int_14 = LogicJSONHelper.GetInt(jsonObject, "lootLimitCooldownInMinutes", 1320);
			this.int_15 = LogicJSONHelper.GetInt(jsonObject, "duelBonusPercentWin", 100);
			this.int_16 = LogicJSONHelper.GetInt(jsonObject, "duelBonusPercentLose", 0);
			this.int_17 = LogicJSONHelper.GetInt(jsonObject, "duelBonusPercentDraw", 0);
			this.int_18 = LogicJSONHelper.GetInt(jsonObject, "duelBonusMaxDiamondCostPercent", 100);
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x00061C00 File Offset: 0x0005FE00
		public override LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = base.Save();
			logicJSONObject.Put("lootLimitCooldownInMinutes", new LogicJSONNumber(this.int_14));
			logicJSONObject.Put("duelBonusPercentWin", new LogicJSONNumber(this.int_15));
			logicJSONObject.Put("duelBonusPercentLose", new LogicJSONNumber(this.int_16));
			logicJSONObject.Put("duelBonusPercentDraw", new LogicJSONNumber(this.int_17));
			logicJSONObject.Put("duelBonusMaxDiamondCostPercent", new LogicJSONNumber(this.int_18));
			return logicJSONObject;
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x00002EB0 File Offset: 0x000010B0
		public override int GetCalendarEventType()
		{
			return 4;
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x000111B6 File Offset: 0x0000F3B6
		public int GetDuelLootLimitCooldownInMinutes()
		{
			return this.int_14;
		}

		// Token: 0x060019C6 RID: 6598 RVA: 0x000111BE File Offset: 0x0000F3BE
		public void SetDuelLootLimitCooldownInMinutes(int value)
		{
			this.int_14 = value;
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x000111C7 File Offset: 0x0000F3C7
		public int GetDuelBonusPercentWin()
		{
			return this.int_15;
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x000111CF File Offset: 0x0000F3CF
		public void SetDuelBonusPercentWin(int value)
		{
			this.int_15 = value;
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x000111D8 File Offset: 0x0000F3D8
		public int GetDuelBonusPercentLose()
		{
			return this.int_16;
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x000111E0 File Offset: 0x0000F3E0
		public void SetDuelBonusPercentLose(int value)
		{
			this.int_16 = value;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x000111E9 File Offset: 0x0000F3E9
		public int GetDuelBonusPercentDraw()
		{
			return this.int_17;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x000111F1 File Offset: 0x0000F3F1
		public void SetDuelBonusPercentDraw(int value)
		{
			this.int_17 = value;
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x000111FA File Offset: 0x0000F3FA
		public int GetDuelBonusMaxDiamondCostPercent()
		{
			return this.int_18;
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x00011202 File Offset: 0x0000F402
		public void SetDuelBonusMaxDiamondCostPercent(int value)
		{
			this.int_18 = value;
		}

		// Token: 0x04000DD3 RID: 3539
		private int int_14;

		// Token: 0x04000DD4 RID: 3540
		private int int_15;

		// Token: 0x04000DD5 RID: 3541
		private int int_16;

		// Token: 0x04000DD6 RID: 3542
		private int int_17;

		// Token: 0x04000DD7 RID: 3543
		private int int_18;
	}
}
