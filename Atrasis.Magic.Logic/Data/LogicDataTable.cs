﻿using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000147 RID: 327
	public class LogicDataTable
	{
		// Token: 0x0600122E RID: 4654 RVA: 0x0000C268 File Offset: 0x0000A468
		public LogicDataTable(CSVTable table, LogicDataType index)
		{
			this.logicDataType_0 = index;
			this.m_table = table;
			this.m_items = new LogicArrayList<LogicData>();
			this.LoadTable();
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x0000C28F File Offset: 0x0000A48F
		public void Destruct()
		{
			this.m_items.Destruct();
			this.string_0 = null;
			this.logicDataType_0 = LogicDataType.BUILDING;
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0004D930 File Offset: 0x0004BB30
		public void LoadTable()
		{
			int i = 0;
			int rowCount = this.m_table.GetRowCount();
			while (i < rowCount)
			{
				this.AddItem(this.m_table.GetRowAt(i));
				i++;
			}
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x0004D968 File Offset: 0x0004BB68
		public void SetTable(CSVTable table)
		{
			this.m_table = table;
			for (int i = 0; i < this.m_items.Size(); i++)
			{
				this.m_items[i].SetCSVRow(table.GetRowAt(i));
			}
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0000C2AA File Offset: 0x0000A4AA
		public void AddItem(CSVRow row)
		{
			this.m_items.Add(this.CreateItem(row));
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x0004D9AC File Offset: 0x0004BBAC
		public LogicData CreateItem(CSVRow row)
		{
			LogicData result = null;
			switch (this.logicDataType_0)
			{
			case LogicDataType.BUILDING:
				result = new LogicBuildingData(row, this);
				break;
			case LogicDataType.LOCALE:
				result = new LogicLocaleData(row, this);
				break;
			case LogicDataType.RESOURCE:
				result = new LogicResourceData(row, this);
				break;
			case LogicDataType.CHARACTER:
				result = new LogicCharacterData(row, this);
				break;
			case LogicDataType.ANIMATION:
				result = new LogicAnimationData(row, this);
				break;
			case LogicDataType.PROJECTILE:
				result = new LogicProjectileData(row, this);
				break;
			case LogicDataType.BUILDING_CLASS:
				result = new LogicBuildingClassData(row, this);
				break;
			case LogicDataType.OBSTACLE:
				result = new LogicObstacleData(row, this);
				break;
			case LogicDataType.EFFECT:
				result = new LogicEffectData(row, this);
				break;
			case LogicDataType.PARTICLE_EMITTER:
				result = new LogicParticleEmitterData(row, this);
				break;
			case LogicDataType.EXPERIENCE_LEVEL:
				result = new LogicExperienceLevelData(row, this);
				break;
			case LogicDataType.TRAP:
				result = new LogicTrapData(row, this);
				break;
			case LogicDataType.ALLIANCE_BADGE:
				result = new LogicAllianceBadgeData(row, this);
				break;
			case LogicDataType.GLOBAL:
			case LogicDataType.CLIENT_GLOBAL:
				result = new LogicGlobalData(row, this);
				break;
			case LogicDataType.TOWNHALL_LEVEL:
				result = new LogicTownhallLevelData(row, this);
				break;
			case LogicDataType.ALLIANCE_PORTAL:
				result = new LogicAlliancePortalData(row, this);
				break;
			case LogicDataType.NPC:
				result = new LogicNpcData(row, this);
				break;
			case LogicDataType.DECO:
				result = new LogicDecoData(row, this);
				break;
			case LogicDataType.RESOURCE_PACK:
				result = new LogicResourcePackData(row, this);
				break;
			case LogicDataType.SHIELD:
				result = new LogicShieldData(row, this);
				break;
			case LogicDataType.MISSION:
				result = new LogicMissionData(row, this);
				break;
			case LogicDataType.BILLING_PACKAGE:
				result = new LogicBillingPackageData(row, this);
				break;
			case LogicDataType.ACHIEVEMENT:
				result = new LogicAchievementData(row, this);
				break;
			case LogicDataType.CREDIT:
			case LogicDataType.FAQ:
			case LogicDataType.VARIABLE:
				result = new LogicData(row, this);
				break;
			case LogicDataType.SPELL:
				result = new LogicSpellData(row, this);
				break;
			case LogicDataType.HINT:
				result = new LogicHintData(row, this);
				break;
			case LogicDataType.HERO:
				result = new LogicHeroData(row, this);
				break;
			case LogicDataType.LEAGUE:
				result = new LogicLeagueData(row, this);
				break;
			case LogicDataType.NEWS:
				result = new LogicNewsData(row, this);
				break;
			case LogicDataType.WAR:
				result = new LogicWarData(row, this);
				break;
			case LogicDataType.REGION:
				result = new LogicRegionData(row, this);
				break;
			case LogicDataType.ALLIANCE_BADGE_LAYER:
				result = new LogicAllianceBadgeLayerData(row, this);
				break;
			case LogicDataType.ALLIANCE_LEVEL:
				result = new LogicAllianceLevelData(row, this);
				break;
			case LogicDataType.HELPSHIFT:
				result = new LogicHelpshiftData(row, this);
				break;
			case LogicDataType.GEM_BUNDLE:
				result = new LogicGemBundleData(row, this);
				break;
			case LogicDataType.VILLAGE_OBJECT:
				result = new LogicVillageObjectData(row, this);
				break;
			case LogicDataType.CALENDAR_EVENT_FUNCTION:
				result = new LogicCalendarEventFunctionData(row, this);
				break;
			case LogicDataType.BOOMBOX:
				result = new LogicBoomboxData(row, this);
				break;
			case LogicDataType.EVENT_ENTRY:
				result = new LogicEventEntryData(row, this);
				break;
			case LogicDataType.DEEPLINK:
				result = new LogicDeeplinkData(row, this);
				break;
			case LogicDataType.LEAGUE_VILLAGE2:
				result = new LogicLeagueVillage2Data(row, this);
				break;
			default:
				Debugger.Error("Invalid data table id: " + this.logicDataType_0);
				break;
			}
			return result;
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0004DC84 File Offset: 0x0004BE84
		public virtual void CreateReferences()
		{
			if (LogicDataTables.CanReloadTable(this) || !this.bool_0)
			{
				for (int i = 0; i < this.m_items.Size(); i++)
				{
					this.m_items[i].CreateReferences();
				}
				this.bool_0 = true;
			}
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x0004DCD0 File Offset: 0x0004BED0
		public virtual void CreateReferences2()
		{
			if (LogicDataTables.CanReloadTable(this) || !this.bool_1)
			{
				for (int i = 0; i < this.m_items.Size(); i++)
				{
					this.m_items[i].CreateReferences2();
				}
				this.bool_1 = true;
			}
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x0000C2BE File Offset: 0x0000A4BE
		public LogicData GetItemAt(int index)
		{
			return this.m_items[index];
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x0004DD1C File Offset: 0x0004BF1C
		public LogicData GetDataByName(string name, LogicData caller)
		{
			if (!string.IsNullOrEmpty(name))
			{
				for (int i = 0; i < this.m_items.Size(); i++)
				{
					LogicData logicData = this.m_items[i];
					if (logicData.GetName().Equals(name))
					{
						return logicData;
					}
				}
				if (caller != null)
				{
					Debugger.Warning(string.Format("CSV row ({0}) has an invalid reference ({1})", caller.GetName(), name));
				}
			}
			return null;
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x0004DD80 File Offset: 0x0004BF80
		public LogicData GetItemById(int globalId)
		{
			int instanceID = GlobalID.GetInstanceID(globalId);
			if (instanceID >= 0 && instanceID < this.m_items.Size())
			{
				return this.m_items[instanceID];
			}
			Debugger.Warning(string.Concat(new object[]
			{
				"LogicDataTable::getItemById() - Instance id out of bounds! ",
				instanceID + 1,
				"/",
				this.m_items.Size()
			}));
			return null;
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x0000C2CC File Offset: 0x0000A4CC
		public int GetItemCount()
		{
			return this.m_items.Size();
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x0000C2D9 File Offset: 0x0000A4D9
		public LogicDataType GetTableIndex()
		{
			return this.logicDataType_0;
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x0000C2E1 File Offset: 0x0000A4E1
		public string GetTableName()
		{
			return this.string_0;
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x0000C2E9 File Offset: 0x0000A4E9
		public void SetName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x040008A2 RID: 2210
		private LogicDataType logicDataType_0;

		// Token: 0x040008A3 RID: 2211
		private string string_0;

		// Token: 0x040008A4 RID: 2212
		private bool bool_0;

		// Token: 0x040008A5 RID: 2213
		private bool bool_1;

		// Token: 0x040008A6 RID: 2214
		protected CSVTable m_table;

		// Token: 0x040008A7 RID: 2215
		protected LogicArrayList<LogicData> m_items;
	}
}
