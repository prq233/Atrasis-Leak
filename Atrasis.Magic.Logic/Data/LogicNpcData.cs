using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015B RID: 347
	public class LogicNpcData : LogicData
	{
		// Token: 0x0600146F RID: 5231 RVA: 0x0000D693 File Offset: 0x0000B893
		public LogicNpcData(CSVRow row, LogicDataTable table) : base(row, table)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicNpcData>();
			this.logicArrayList_1 = new LogicArrayList<LogicDataSlot>();
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x00051688 File Offset: 0x0004F888
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("MapInstanceName", 0);
			this.int_0 = base.GetIntegerValue("ExpLevel", 0);
			this.string_1 = base.GetValue("LevelFile", 0);
			this.int_1 = base.GetIntegerValue("Gold", 0);
			this.int_2 = base.GetIntegerValue("Elixir", 0);
			this.bool_0 = base.GetBooleanValue("AlwaysUnlocked", 0);
			this.string_2 = base.GetValue("PlayerName", 0);
			this.string_3 = base.GetValue("AllianceName", 0);
			this.int_3 = base.GetIntegerValue("AllianceBadge", 0);
			this.bool_1 = base.GetBooleanValue("SinglePlayer", 0);
			int arraySize = base.GetArraySize("UnitType");
			if (arraySize > 0)
			{
				this.logicArrayList_1.EnsureCapacity(arraySize);
				for (int i = 0; i < arraySize; i++)
				{
					int integerValue = base.GetIntegerValue("UnitCount", i);
					if (integerValue > 0)
					{
						this.logicArrayList_1.Add(new LogicDataSlot(LogicDataTables.GetCharacterByName(base.GetValue("UnitType", i), this), integerValue));
					}
				}
			}
			int arraySize2 = base.GetArraySize("MapDependencies");
			for (int j = 0; j < arraySize2; j++)
			{
				LogicNpcData npcByName = LogicDataTables.GetNpcByName(base.GetValue("MapDependencies", j), this);
				if (npcByName != null)
				{
					this.logicArrayList_0.Add(npcByName);
				}
			}
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x000517F0 File Offset: 0x0004F9F0
		public LogicArrayList<LogicDataSlot> GetClonedUnits()
		{
			LogicArrayList<LogicDataSlot> logicArrayList = new LogicArrayList<LogicDataSlot>();
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				logicArrayList.Add(this.logicArrayList_1[i].Clone());
			}
			return logicArrayList;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x00051834 File Offset: 0x0004FA34
		public bool IsUnlockedInMap(LogicClientAvatar avatar)
		{
			if (!this.bool_0)
			{
				if (!string.IsNullOrEmpty(this.string_0) && this.logicArrayList_0 != null)
				{
					for (int i = 0; i < this.logicArrayList_0.Size(); i++)
					{
						if (avatar.GetNpcStars(this.logicArrayList_0[i]) > 0)
						{
							return true;
						}
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x0000D6B3 File Offset: 0x0000B8B3
		public string GetMapInstanceName()
		{
			return this.string_0;
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x0000D6BB File Offset: 0x0000B8BB
		public int GetExpLevel()
		{
			return this.int_0;
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x0000D6C3 File Offset: 0x0000B8C3
		public string GetLevelFile()
		{
			return this.string_1;
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x0000D6CB File Offset: 0x0000B8CB
		public int GetGoldCount()
		{
			return this.int_1;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x0000D6D3 File Offset: 0x0000B8D3
		public int GetElixirCount()
		{
			return this.int_2;
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x0000D6DB File Offset: 0x0000B8DB
		public bool IsAlwaysUnlocked()
		{
			return this.bool_0;
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x0000D6E3 File Offset: 0x0000B8E3
		public string GetPlayerName()
		{
			return this.string_2;
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x0000D6EB File Offset: 0x0000B8EB
		public string GetAllianceName()
		{
			return this.string_3;
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x0000D6F3 File Offset: 0x0000B8F3
		public int GetAllianceBadge()
		{
			return this.int_3;
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x0000D6FB File Offset: 0x0000B8FB
		public bool IsSinglePlayer()
		{
			return this.bool_1;
		}

		// Token: 0x04000AB9 RID: 2745
		private string string_0;

		// Token: 0x04000ABA RID: 2746
		private string string_1;

		// Token: 0x04000ABB RID: 2747
		private string string_2;

		// Token: 0x04000ABC RID: 2748
		private string string_3;

		// Token: 0x04000ABD RID: 2749
		private int int_0;

		// Token: 0x04000ABE RID: 2750
		private int int_1;

		// Token: 0x04000ABF RID: 2751
		private int int_2;

		// Token: 0x04000AC0 RID: 2752
		private int int_3;

		// Token: 0x04000AC1 RID: 2753
		private bool bool_0;

		// Token: 0x04000AC2 RID: 2754
		private bool bool_1;

		// Token: 0x04000AC3 RID: 2755
		private readonly LogicArrayList<LogicNpcData> logicArrayList_0;

		// Token: 0x04000AC4 RID: 2756
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_1;
	}
}
