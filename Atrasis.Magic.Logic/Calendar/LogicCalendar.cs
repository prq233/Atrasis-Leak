using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F1 RID: 497
	public class LogicCalendar
	{
		// Token: 0x06001941 RID: 6465 RVA: 0x00010CBB File Offset: 0x0000EEBB
		public LogicCalendar()
		{
			this.int_0 = -1;
			this.logicArrayList_0 = new LogicArrayList<int>();
			this.logicArrayList_1 = new LogicArrayList<LogicCalendarEvent>();
			this.logicArrayList_2 = new LogicArrayList<LogicCalendarEvent>();
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00010CEB File Offset: 0x0000EEEB
		public void Destruct()
		{
			this.DestructCalendarEvents();
			if (this.logicArrayList_2 != null)
			{
				this.logicArrayList_2.Destruct();
				this.logicArrayList_2 = null;
			}
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x00010D0D File Offset: 0x0000EF0D
		public void DestructCalendarEvents()
		{
			if (this.logicArrayList_1 != null)
			{
				while (this.logicArrayList_1.Size() > 0)
				{
					this.logicArrayList_1[0].Destruct();
					this.logicArrayList_1.Remove(0);
				}
			}
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x00060028 File Offset: 0x0005E228
		public void GetChecksum(ChecksumHelper checksum)
		{
			checksum.StartObject("LogicCalendar");
			checksum.StartArray("m_pActiveCalendarEvents");
			for (int i = 0; i < this.logicArrayList_2.Size(); i++)
			{
				checksum.StartObject("LogicCalendarEvent");
				checksum.EndObject();
			}
			checksum.EndArray();
			checksum.WriteValue("m_activeTimestamp", this.int_0);
			checksum.EndObject();
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x00060090 File Offset: 0x0005E290
		public void Load(string json, int activeTimestamp)
		{
			Debugger.DoAssert(json != null, "Event json NULL");
			if (json.Length > 0)
			{
				LogicJSONObject logicJSONObject = (LogicJSONObject)LogicJSONParser.Parse(json);
				if (logicJSONObject != null)
				{
					LogicArrayList<LogicCalendarEvent> logicArrayList = new LogicArrayList<LogicCalendarEvent>();
					LogicJSONArray jsonarray = logicJSONObject.GetJSONArray("events");
					if (jsonarray != null)
					{
						for (int i = 0; i < jsonarray.Size(); i++)
						{
							LogicJSONObject jsonobject = jsonarray.GetJSONObject(i);
							if (jsonobject == null)
							{
								Debugger.Error("Events json malformed!");
							}
							logicArrayList.Add(LogicCalendarEventFactory.LoadFromJSON(jsonobject, null));
						}
					}
					this.LoadingFinished(logicArrayList, activeTimestamp);
					return;
				}
				Debugger.Error("Events json malformed!");
			}
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x00060124 File Offset: 0x0005E324
		public LogicJSONObject Save()
		{
			Debugger.DoAssert(this.logicArrayList_1 != null, "Cannot create events, array is NULL.");
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_1.Size());
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				logicJSONArray.Add(this.logicArrayList_1[i].Save());
			}
			logicJSONObject.Put("events", logicJSONArray);
			return logicJSONObject;
		}

		// Token: 0x06001947 RID: 6471 RVA: 0x00060198 File Offset: 0x0005E398
		public void LoadProgress(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("events");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.logicArrayList_0.Add(jsonarray.GetJSONNumber(i).GetIntValue());
				}
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("es");
			if (jsonnumber != null)
			{
				this.int_1 = jsonnumber.GetIntValue();
			}
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x000601F8 File Offset: 0x0005E3F8
		public void SaveProgress(LogicJSONObject jsonObject)
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicJSONArray logicJSONArray = new LogicJSONArray();
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					logicJSONArray.Add(new LogicJSONNumber(this.logicArrayList_0[i]));
				}
				jsonObject.Put("events", logicJSONArray);
			}
			jsonObject.Put("es", new LogicJSONNumber(this.int_1));
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00010D44 File Offset: 0x0000EF44
		public void SetEventSeenTime(int timestamp)
		{
			this.int_1 = timestamp;
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00060268 File Offset: 0x0005E468
		public void Update(int activeTimestamp, LogicAvatar homeOwnerAvatar, LogicLevel level)
		{
			Debugger.DoAssert(activeTimestamp != -1, "You must set a valid time for calendar.");
			if (this.int_0 != activeTimestamp)
			{
				this.int_0 = activeTimestamp;
				if (this.HasNewActiveCalendarEvents(this.logicArrayList_2, activeTimestamp, activeTimestamp))
				{
					this.logicArrayList_2 = this.GetActiveCalendarEvents(activeTimestamp, activeTimestamp);
					if (homeOwnerAvatar != null && level != null)
					{
						this.UpdateUseTroopEvent(homeOwnerAvatar, level);
					}
				}
			}
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x000602C4 File Offset: 0x0005E4C4
		public void UpdateUseTroopEvent(LogicAvatar homeOwnerAvatar, LogicLevel level)
		{
			for (int i = 0; i < this.logicArrayList_2.Size(); i++)
			{
				if (this.logicArrayList_0.IndexOf(this.logicArrayList_2[i].GetId()) == -1)
				{
					this.logicArrayList_2[i].StartUseTroopEvent(homeOwnerAvatar, level);
				}
			}
			while (this.logicArrayList_0.Size() > 0)
			{
				this.logicArrayList_0.Remove(0);
			}
			for (int j = 0; j < this.logicArrayList_2.Size(); j++)
			{
				this.logicArrayList_0.Add(this.logicArrayList_2[j].GetId());
			}
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00010D4D File Offset: 0x0000EF4D
		public LogicArrayList<LogicCalendarEvent> GetCalendarEvents()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00060368 File Offset: 0x0005E568
		public LogicArrayList<LogicCalendarEvent> GetActiveCalendarEvents(int minTimestamp, int maxTimestamp)
		{
			LogicArrayList<LogicCalendarEvent> logicArrayList = new LogicArrayList<LogicCalendarEvent>();
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				LogicCalendarEvent logicCalendarEvent = this.logicArrayList_1[i];
				if (logicCalendarEvent.GetStartTime() <= minTimestamp && logicCalendarEvent.GetEndTime() >= maxTimestamp)
				{
					logicArrayList.Add(logicCalendarEvent);
				}
			}
			return logicArrayList;
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x000603B8 File Offset: 0x0005E5B8
		public bool HasNewActiveCalendarEvents(LogicArrayList<LogicCalendarEvent> currentActiveCalendarEvents, int minTimestamp, int maxTimestamp)
		{
			int num = 0;
			int i = 0;
			int num2 = 0;
			while (i < this.logicArrayList_1.Size())
			{
				LogicCalendarEvent logicCalendarEvent = this.logicArrayList_1[i];
				if (logicCalendarEvent.GetStartTime() <= minTimestamp && logicCalendarEvent.GetEndTime() >= maxTimestamp)
				{
					if (num2 < currentActiveCalendarEvents.Size() && !logicCalendarEvent.IsEqual(currentActiveCalendarEvents[num2++]))
					{
						return true;
					}
					num++;
				}
				i++;
			}
			return num != currentActiveCalendarEvents.Size();
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00010D55 File Offset: 0x0000EF55
		public void LoadingFinished(LogicArrayList<LogicCalendarEvent> events, int activeTimestamp)
		{
			this.DestructCalendarEvents();
			this.logicArrayList_1.AddAll(events);
			this.Update(activeTimestamp, null, null);
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x0006042C File Offset: 0x0005E62C
		public LogicCalendarUseTroop GetUseTroopEvents(LogicCombatItemData data)
		{
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				LogicArrayList<LogicCalendarUseTroop> useTroops = this.logicArrayList_2[i].GetUseTroops();
				for (int j = 0; j < useTroops.Size(); j++)
				{
					if (useTroops[j].GetData() == data)
					{
						return useTroops[j];
					}
				}
			}
			return null;
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00060490 File Offset: 0x0005E690
		public LogicCalendarBuildingDestroyedSpawnUnit GetBuildingDestroyedSpawnUnit()
		{
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				LogicCalendarBuildingDestroyedSpawnUnit buildingDestroyedSpawnUnit = this.logicArrayList_2[i].GetBuildingDestroyedSpawnUnit();
				if (buildingDestroyedSpawnUnit != null)
				{
					return buildingDestroyedSpawnUnit;
				}
			}
			return null;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x000604D0 File Offset: 0x0005E6D0
		public int GetBuildingBoostCost(LogicBuildingData data, int upgLevel)
		{
			int num = data.GetBoostCost(upgLevel);
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				int buildingBoostCost = this.logicArrayList_2[i].GetBuildingBoostCost(data, upgLevel);
				if (buildingBoostCost <= num)
				{
					num = buildingBoostCost;
				}
			}
			return num;
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00060518 File Offset: 0x0005E718
		public int GetUnitProductionBoostCost()
		{
			int newTrainingBoostBarracksCost = LogicDataTables.GetGlobals().GetNewTrainingBoostBarracksCost();
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				LogicCalendarEvent logicCalendarEvent = this.logicArrayList_2[i];
				if (logicCalendarEvent.GetNewTrainingBoostBarracksCost() <= newTrainingBoostBarracksCost)
				{
					newTrainingBoostBarracksCost = logicCalendarEvent.GetNewTrainingBoostBarracksCost();
				}
			}
			return newTrainingBoostBarracksCost;
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00060568 File Offset: 0x0005E768
		public int GetSpellProductionBoostCost()
		{
			int num = LogicDataTables.GetGlobals().GetNewTrainingBoostLaboratoryCost();
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				LogicCalendarEvent logicCalendarEvent = this.logicArrayList_2[i];
				if (logicCalendarEvent.GetNewTrainingBoostSpellCost() <= num)
				{
					num = logicCalendarEvent.GetNewTrainingBoostSpellCost();
				}
			}
			return num;
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x000605B8 File Offset: 0x0005E7B8
		public int GetTrainingCost(LogicCombatItemData data, int upgLevel)
		{
			int num = data.GetTrainingCost(upgLevel);
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				int trainingCost = this.logicArrayList_2[i].GetTrainingCost(data, upgLevel);
				if (trainingCost <= num)
				{
					num = trainingCost;
				}
			}
			return num;
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00060600 File Offset: 0x0005E800
		public int GetStarBonusMultiplier()
		{
			int num = 1;
			for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
			{
				int starBonusMultiplier = this.logicArrayList_2[i].GetStarBonusMultiplier();
				if (starBonusMultiplier >= num)
				{
					num = starBonusMultiplier;
				}
			}
			return num;
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x00010D72 File Offset: 0x0000EF72
		public bool IsProductionEnabled(LogicCombatItemData data)
		{
			return this.IsEnabled(data) && data.IsProductionEnabled();
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00060640 File Offset: 0x0005E840
		public bool IsEnabled(LogicData data)
		{
			if (data.IsEnableByCalendar())
			{
				for (int i = this.logicArrayList_2.Size() - 1; i >= 0; i--)
				{
					if (this.logicArrayList_2[i].IsEnabled(data))
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x00060688 File Offset: 0x0005E888
		public static int GetDuelLootLimitCooldownInMinutes(LogicCalendar instance, LogicConfiguration configuration)
		{
			if (instance == null)
			{
				Debugger.Warning("LogicCalender is NULL for getDuelLootLimitCooldownInMinutes call");
				if (configuration != null)
				{
					return configuration.GetDuelLootLimitCooldownInMinutes();
				}
				return 1320;
			}
			else
			{
				int num = -1;
				for (int i = 0; i < instance.logicArrayList_2.Size(); i++)
				{
					LogicCalendarEvent logicCalendarEvent = instance.logicArrayList_2[i];
					if (logicCalendarEvent.GetCalendarEventType() == 4)
					{
						LogicDuelLootLimitCalendarEvent logicDuelLootLimitCalendarEvent = (LogicDuelLootLimitCalendarEvent)logicCalendarEvent;
						if (num == -1 || logicDuelLootLimitCalendarEvent.GetDuelLootLimitCooldownInMinutes() <= num)
						{
							num = logicDuelLootLimitCalendarEvent.GetDuelLootLimitCooldownInMinutes();
						}
					}
				}
				if (num != -1)
				{
					return 0;
				}
				if (configuration != null)
				{
					return configuration.GetDuelLootLimitCooldownInMinutes();
				}
				return 1320;
			}
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x00060710 File Offset: 0x0005E910
		public static int GetDuelBonusMaxDiamondCostPercent(LogicCalendar instance, LogicConfiguration configuration)
		{
			if (instance == null)
			{
				Debugger.Warning("LogicCalender is NULL for getDuelBonusMaxDiamondCostPercent call");
				if (configuration != null)
				{
					return configuration.GetDuelBonusMaxDiamondCostPercent();
				}
				return 100;
			}
			else
			{
				int num = -1;
				for (int i = 0; i < instance.logicArrayList_2.Size(); i++)
				{
					LogicCalendarEvent logicCalendarEvent = instance.logicArrayList_2[i];
					if (logicCalendarEvent.GetCalendarEventType() == 4)
					{
						LogicDuelLootLimitCalendarEvent logicDuelLootLimitCalendarEvent = (LogicDuelLootLimitCalendarEvent)logicCalendarEvent;
						if (num == -1 || logicDuelLootLimitCalendarEvent.GetDuelBonusMaxDiamondCostPercent() <= num)
						{
							num = logicDuelLootLimitCalendarEvent.GetDuelBonusMaxDiamondCostPercent();
						}
					}
				}
				if (num != -1)
				{
					return 0;
				}
				if (configuration != null)
				{
					return configuration.GetDuelBonusMaxDiamondCostPercent();
				}
				return 100;
			}
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x00060794 File Offset: 0x0005E994
		public static int GetDuelBonusPercentWin(LogicCalendar instance, LogicConfiguration configuration)
		{
			if (instance == null)
			{
				Debugger.Warning("LogicCalender is NULL for getDuelBonusPercentWin call");
				if (configuration != null)
				{
					return configuration.GetDuelBonusPercentWin();
				}
				return 100;
			}
			else
			{
				int num = -1;
				for (int i = 0; i < instance.logicArrayList_2.Size(); i++)
				{
					LogicCalendarEvent logicCalendarEvent = instance.logicArrayList_2[i];
					if (logicCalendarEvent.GetCalendarEventType() == 4)
					{
						LogicDuelLootLimitCalendarEvent logicDuelLootLimitCalendarEvent = (LogicDuelLootLimitCalendarEvent)logicCalendarEvent;
						if (num == -1 || logicDuelLootLimitCalendarEvent.GetDuelBonusPercentWin() <= num)
						{
							num = logicDuelLootLimitCalendarEvent.GetDuelBonusPercentWin();
						}
					}
				}
				if (num != -1)
				{
					return 0;
				}
				if (configuration != null)
				{
					return configuration.GetDuelBonusPercentWin();
				}
				return 100;
			}
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x00060818 File Offset: 0x0005EA18
		public static int GetDuelBonusPercentDraw(LogicCalendar instance, LogicConfiguration configuration)
		{
			if (instance == null)
			{
				Debugger.Warning("LogicCalender is NULL for getDuelBonusPercentDraw call");
				if (configuration != null)
				{
					return configuration.GetDuelBonusPercentDraw();
				}
				return 100;
			}
			else
			{
				int num = -1;
				for (int i = 0; i < instance.logicArrayList_2.Size(); i++)
				{
					LogicCalendarEvent logicCalendarEvent = instance.logicArrayList_2[i];
					if (logicCalendarEvent.GetCalendarEventType() == 4)
					{
						LogicDuelLootLimitCalendarEvent logicDuelLootLimitCalendarEvent = (LogicDuelLootLimitCalendarEvent)logicCalendarEvent;
						if (num == -1 || logicDuelLootLimitCalendarEvent.GetDuelBonusPercentDraw() <= num)
						{
							num = logicDuelLootLimitCalendarEvent.GetDuelBonusPercentDraw();
						}
					}
				}
				if (num != -1)
				{
					return 0;
				}
				if (configuration != null)
				{
					return configuration.GetDuelBonusPercentDraw();
				}
				return 100;
			}
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x0006089C File Offset: 0x0005EA9C
		public static int GetDuelBonusPercentLose(LogicCalendar instance, LogicConfiguration configuration)
		{
			if (instance == null)
			{
				Debugger.Warning("LogicCalender is NULL for getDuelBonusPercentLose call");
				if (configuration != null)
				{
					return configuration.GetDuelBonusPercentLose();
				}
				return 100;
			}
			else
			{
				int num = -1;
				for (int i = 0; i < instance.logicArrayList_2.Size(); i++)
				{
					LogicCalendarEvent logicCalendarEvent = instance.logicArrayList_2[i];
					if (logicCalendarEvent.GetCalendarEventType() == 4)
					{
						LogicDuelLootLimitCalendarEvent logicDuelLootLimitCalendarEvent = (LogicDuelLootLimitCalendarEvent)logicCalendarEvent;
						if (num == -1 || logicDuelLootLimitCalendarEvent.GetDuelBonusPercentLose() <= num)
						{
							num = logicDuelLootLimitCalendarEvent.GetDuelBonusPercentLose();
						}
					}
				}
				if (num != -1)
				{
					return 0;
				}
				if (configuration != null)
				{
					return configuration.GetDuelBonusPercentLose();
				}
				return 100;
			}
		}

		// Token: 0x04000DA0 RID: 3488
		private int int_0;

		// Token: 0x04000DA1 RID: 3489
		private int int_1;

		// Token: 0x04000DA2 RID: 3490
		private readonly LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000DA3 RID: 3491
		private readonly LogicArrayList<LogicCalendarEvent> logicArrayList_1;

		// Token: 0x04000DA4 RID: 3492
		private LogicArrayList<LogicCalendarEvent> logicArrayList_2;
	}
}
