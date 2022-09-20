using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;
using ns0;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000132 RID: 306
	public class LogicAchievementData : LogicData
	{
		// Token: 0x06001097 RID: 4247 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicAchievementData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x0004A3BC File Offset: 0x000485BC
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_5 = base.GetIntegerValue("UIGroup", 0);
			this.int_0 = base.GetIntegerValue("DiamondReward", 0);
			this.int_1 = base.GetIntegerValue("ExpReward", 0);
			this.int_2 = base.GetIntegerValue("ActionCount", 0);
			this.int_3 = base.GetIntegerValue("Level", 0);
			this.int_4 = base.GetIntegerValue("LevelCount", 0);
			this.string_0 = base.GetValue("CompletedTID", 0);
			this.bool_0 = base.GetBooleanValue("ShowValue", 0);
			this.string_1 = base.GetValue("AndroidID", 0);
			if (this.int_2 == 0)
			{
				Debugger.Error("Achievement has invalid ActionCount 0");
			}
			string value = base.GetValue("Action", 0);
			if (value != null)
			{
				uint num = Class0.smethod_0(value);
				if (num <= 2389725974U)
				{
					if (num <= 1485590983U)
					{
						if (num <= 72397119U)
						{
							if (num != 19336808U)
							{
								if (num == 72397119U)
								{
									if (value == "clear_obstacles")
									{
										this.logicAchievementActionType_0 = LogicAchievementActionType.CLEAR_OBSTACLES;
										goto IL_4AF;
									}
								}
							}
							else if (value == "war_loot")
							{
								this.logicAchievementActionType_0 = LogicAchievementActionType.WAR_LOOT;
								goto IL_4AF;
							}
						}
						else if (num != 408900432U)
						{
							if (num == 1485590983U)
							{
								if (value == "account_bound")
								{
									this.logicAchievementActionType_0 = LogicAchievementActionType.ACCOUNT_BOUND;
									goto IL_4AF;
								}
							}
						}
						else if (value == "league")
						{
							this.logicAchievementActionType_0 = LogicAchievementActionType.LEAGUE;
							goto IL_4AF;
						}
					}
					else if (num <= 1641388238U)
					{
						if (num != 1556555408U)
						{
							if (num == 1641388238U)
							{
								if (value == "npc_stars")
								{
									this.logicAchievementActionType_0 = LogicAchievementActionType.NPC_STARS;
									goto IL_4AF;
								}
							}
						}
						else if (value == "vs_battle_trophies")
						{
							this.logicAchievementActionType_0 = LogicAchievementActionType.VERSUS_BATTLE_TROPHIES;
							goto IL_4AF;
						}
					}
					else if (num != 1987856727U)
					{
						if (num != 2133671514U)
						{
							if (num == 2389725974U)
							{
								if (value == "gear_up")
								{
									this.logicAchievementActionType_0 = LogicAchievementActionType.GEAR_UP;
									goto IL_4AF;
								}
							}
						}
						else if (value == "donate_units")
						{
							this.logicAchievementActionType_0 = LogicAchievementActionType.DONATE_UNITS;
							goto IL_4AF;
						}
					}
					else if (value == "war_stars")
					{
						this.logicAchievementActionType_0 = LogicAchievementActionType.WAR_STARS;
						goto IL_4AF;
					}
				}
				else if (num <= 3091794805U)
				{
					if (num <= 2869827144U)
					{
						if (num != 2403257508U)
						{
							if (num == 2869827144U)
							{
								if (value == "donate_spells")
								{
									this.logicAchievementActionType_0 = LogicAchievementActionType.DONATE_SPELLS;
									goto IL_4AF;
								}
							}
						}
						else if (value == "unit_unlock")
						{
							this.logicAchievementActionType_0 = LogicAchievementActionType.UNIT_UNLOCK;
							this.logicCharacterData_0 = LogicDataTables.GetCharacterByName(base.GetValue("ActionData", 0), this);
							if (this.logicCharacterData_0 == null)
							{
								Debugger.Error("LogicCharacterData - Character data is NULL for unit_unlock achievement");
								goto IL_4AF;
							}
							goto IL_4AF;
						}
					}
					else if (num != 2994835433U)
					{
						if (num == 3091794805U)
						{
							if (value == "win_pvp_attack")
							{
								this.logicAchievementActionType_0 = LogicAchievementActionType.WIN_PVP_ATTACK;
								goto IL_4AF;
							}
						}
					}
					else if (value == "repair_building")
					{
						this.logicAchievementActionType_0 = LogicAchievementActionType.REPAIR_BUILDING;
						this.logicBuildingData_0 = LogicDataTables.GetBuildingByName(base.GetValue("ActionData", 0), this);
						if (this.logicBuildingData_0 == null)
						{
							Debugger.Error("LogicAchievementData - Building data is NULL for repair_building achievement");
							goto IL_4AF;
						}
						goto IL_4AF;
					}
				}
				else if (num <= 3294324549U)
				{
					if (num != 3111152827U)
					{
						if (num == 3294324549U)
						{
							if (value == "destroy")
							{
								this.logicAchievementActionType_0 = LogicAchievementActionType.DESTROY;
								this.logicBuildingData_0 = LogicDataTables.GetBuildingByName(base.GetValue("ActionData", 0), this);
								if (this.logicBuildingData_0 == null)
								{
									Debugger.Error("LogicAchievementData - Building data is NULL for destroy achievement");
									goto IL_4AF;
								}
								goto IL_4AF;
							}
						}
					}
					else if (value == "win_pvp_defense")
					{
						this.logicAchievementActionType_0 = LogicAchievementActionType.WIN_PVP_DEFENSE;
						goto IL_4AF;
					}
				}
				else if (num != 3326860153U)
				{
					if (num != 3700935799U)
					{
						if (num == 3790556855U)
						{
							if (value == "loot")
							{
								this.logicAchievementActionType_0 = LogicAchievementActionType.LOOT;
								this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("ActionData", 0), this);
								if (this.logicResourceData_0 == null)
								{
									Debugger.Error("LogicAchievementData - Resource data is NULL for loot achievement");
									goto IL_4AF;
								}
								goto IL_4AF;
							}
						}
					}
					else if (value == "upgrade")
					{
						this.logicAchievementActionType_0 = LogicAchievementActionType.UPGRADE;
						this.logicBuildingData_0 = LogicDataTables.GetBuildingByName(base.GetValue("ActionData", 0), this);
						if (this.logicBuildingData_0 == null)
						{
							Debugger.Error("LogicAchievementData - Building data is NULL for upgrade achievement");
							goto IL_4AF;
						}
						goto IL_4AF;
					}
				}
				else if (value == "victory_points")
				{
					this.logicAchievementActionType_0 = LogicAchievementActionType.VICTORY_POINTS;
					goto IL_4AF;
				}
			}
			Debugger.Error(string.Format("Unknown Action in achievements {0}", value));
			IL_4AF:
			this.logicArrayList_0 = new LogicArrayList<LogicAchievementData>();
			string text = base.GetName().Substring(0, base.GetName().Length - 1);
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.ACHIEVEMENT);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicAchievementData logicAchievementData = (LogicAchievementData)table.GetItemAt(i);
				if (logicAchievementData.GetName().Contains(text) && logicAchievementData.GetName().Substring(0, logicAchievementData.GetName().Length - 1).Equals(text))
				{
					this.logicArrayList_0.Add(logicAchievementData);
				}
			}
			Debugger.DoAssert(this.logicArrayList_0.Size() == this.int_4, string.Format("Expected same amount of achievements named {0}X to be same as LevelCount={1} for {2}.", text, this.int_4, base.GetName()));
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x0000B34F File Offset: 0x0000954F
		public int GetVillageType()
		{
			return this.int_5;
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x0000B357 File Offset: 0x00009557
		public LogicAchievementActionType GetActionType()
		{
			return this.logicAchievementActionType_0;
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x0000B35F File Offset: 0x0000955F
		public int GetDiamondReward()
		{
			return this.int_0;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x0000B367 File Offset: 0x00009567
		public int GetExpReward()
		{
			return this.int_1;
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x0000B36F File Offset: 0x0000956F
		public int GetActionCount()
		{
			return this.int_2;
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x0000B377 File Offset: 0x00009577
		public int GetLevel()
		{
			return this.int_3;
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x0000B37F File Offset: 0x0000957F
		public string GetCompletedTID()
		{
			return this.string_0;
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x0000B387 File Offset: 0x00009587
		public string GetAndroidID()
		{
			return this.string_1;
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x0000B38F File Offset: 0x0000958F
		public LogicArrayList<LogicAchievementData> GetAchievementLevels()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x0000B397 File Offset: 0x00009597
		public LogicBuildingData GetBuildingData()
		{
			return this.logicBuildingData_0;
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x0000B39F File Offset: 0x0000959F
		public LogicResourceData GetResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x060010A4 RID: 4260 RVA: 0x0000B3A7 File Offset: 0x000095A7
		public LogicCharacterData GetCharacterData()
		{
			return this.logicCharacterData_0;
		}

		// Token: 0x040006C8 RID: 1736
		private bool bool_0;

		// Token: 0x040006C9 RID: 1737
		private LogicAchievementActionType logicAchievementActionType_0;

		// Token: 0x040006CA RID: 1738
		private int int_0;

		// Token: 0x040006CB RID: 1739
		private int int_1;

		// Token: 0x040006CC RID: 1740
		private int int_2;

		// Token: 0x040006CD RID: 1741
		private int int_3;

		// Token: 0x040006CE RID: 1742
		private int int_4;

		// Token: 0x040006CF RID: 1743
		private int int_5;

		// Token: 0x040006D0 RID: 1744
		private string string_0;

		// Token: 0x040006D1 RID: 1745
		private string string_1;

		// Token: 0x040006D2 RID: 1746
		private LogicBuildingData logicBuildingData_0;

		// Token: 0x040006D3 RID: 1747
		private LogicResourceData logicResourceData_0;

		// Token: 0x040006D4 RID: 1748
		private LogicCharacterData logicCharacterData_0;

		// Token: 0x040006D5 RID: 1749
		private LogicArrayList<LogicAchievementData> logicArrayList_0;
	}
}
