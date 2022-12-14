using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F6 RID: 502
	public class LogicCalendarFunction
	{
		// Token: 0x060019AE RID: 6574 RVA: 0x000110E9 File Offset: 0x0000F2E9
		public LogicCalendarFunction(LogicCalendarEvent calendarEvent, int idx, LogicJSONObject jsonObject, LogicCalendarErrorHandler errorHandler)
		{
			this.logicArrayList_0 = new LogicArrayList<string>();
			this.logicCalendarEvent_0 = calendarEvent;
			this.logicCalendarErrorHandler_0 = errorHandler;
			this.int_0 = idx;
			this.Load(jsonObject);
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x00011119 File Offset: 0x0000F319
		public void Destruct()
		{
			this.logicCalendarEventFunctionData_0 = null;
			this.logicCalendarEvent_0 = null;
			this.logicCalendarErrorHandler_0 = null;
			this.logicArrayList_0 = null;
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x00061354 File Offset: 0x0005F554
		public void Load(LogicJSONObject jsonObject)
		{
			Debugger.DoAssert(this.logicCalendarErrorHandler_0 != null, "LogicCalendarErrorHandler must not be NULL!");
			if (jsonObject == null)
			{
				this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, "Event function malformed.");
				return;
			}
			string @string = LogicJSONHelper.GetString(jsonObject, "name");
			this.logicCalendarEventFunctionData_0 = LogicDataTables.GetCalendarEventFunctionByName(@string, null);
			if (this.logicCalendarEventFunctionData_0 == null)
			{
				this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, string.Format("event function '{0}' not found.", @string));
				return;
			}
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("parameters");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.logicArrayList_0.Add(jsonarray.GetJSONString(i).GetStringValue());
				}
			}
			this.LoadingFinished();
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x0006140C File Offset: 0x0005F60C
		public void LoadingFinished()
		{
			if (this.logicCalendarEventFunctionData_0.IsDeprecated())
			{
				this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, "Function is deprecated.");
			}
			if (this.logicArrayList_0.Size() != this.logicCalendarEventFunctionData_0.GetParameterCount())
			{
				this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, string.Format("Invalid number of parameters defined. Expected {0} got {1}.", this.logicCalendarEventFunctionData_0.GetParameterCount(), this.logicArrayList_0.Size()));
			}
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				int parameterType = this.logicCalendarEventFunctionData_0.GetParameterType(i);
				switch (parameterType)
				{
				case 0:
					this.GetBoolParameter(i);
					break;
				case 1:
					this.GetIntParameter(i);
					break;
				case 2:
					this.GetStringParameter(i);
					break;
				case 3:
					this.GetDataParameter(i, LogicDataType.CHARACTER);
					break;
				case 4:
					this.GetDataParameter(i, LogicDataType.SPELL);
					break;
				case 5:
					this.GetDataParameter(i, LogicDataType.BUILDING);
					break;
				case 6:
					this.GetDataParameter(i, LogicDataType.TRAP);
					break;
				case 7:
					this.GetDataParameter(i, LogicDataType.GEM_BUNDLE);
					break;
				case 8:
					this.GetDataParameter(i, LogicDataType.BILLING_PACKAGE);
					break;
				case 9:
					break;
				case 10:
					this.GetDataParameter(i, LogicDataType.HERO);
					break;
				default:
					this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, this.logicCalendarEventFunctionData_0.GetParameterName(i), string.Format("Unhandled parameter type {0}!", parameterType));
					break;
				}
			}
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x0006158C File Offset: 0x0005F78C
		public LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_0.Size());
			logicJSONObject.Put("name", new LogicJSONString(this.logicCalendarEventFunctionData_0.GetName()));
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				logicJSONArray.Add(new LogicJSONString(this.logicArrayList_0[i]));
			}
			logicJSONObject.Put("parameters", logicJSONArray);
			return logicJSONObject;
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x00061608 File Offset: 0x0005F808
		public void ApplyToEvent(LogicCalendarEvent calendarEvent)
		{
			switch (this.logicCalendarEventFunctionData_0.GetFunctionType())
			{
			case 1:
				calendarEvent.SetNewTrainingBoostBarracksCost(this.GetIntParameter(0));
				return;
			case 2:
				calendarEvent.SetNewTrainingBoostSpellCost(this.GetIntParameter(0));
				return;
			case 3:
				calendarEvent.AddBuildingBoost(this.GetDataParameter(0, LogicDataType.BUILDING), this.GetIntParameter(1));
				return;
			case 4:
				calendarEvent.AddTroopDiscount(this.GetDataParameter(0, LogicDataType.CHARACTER), this.GetIntParameter(1));
				return;
			case 5:
				calendarEvent.AddTroopDiscount(this.GetDataParameter(0, LogicDataType.SPELL), this.GetIntParameter(1));
				return;
			case 6:
				calendarEvent.SetAllianceXpMultiplier(this.GetIntParameter(0));
				return;
			case 7:
				calendarEvent.AddEnabledData(this.GetDataParameter(0, LogicDataType.GEM_BUNDLE));
				return;
			case 8:
				calendarEvent.SetStarBonusMultiplier(this.GetIntParameter(0));
				return;
			case 9:
				calendarEvent.AddEnabledData(this.GetDataParameter(0, LogicDataType.CHARACTER));
				return;
			case 10:
				calendarEvent.AddEnabledData(this.GetDataParameter(0, LogicDataType.SPELL));
				return;
			case 11:
				calendarEvent.AddEnabledData(this.GetDataParameter(0, LogicDataType.TRAP));
				return;
			case 12:
				calendarEvent.AddUseTroop((LogicCombatItemData)this.GetDataParameter(0, LogicDataType.CHARACTER), this.GetIntParameter(1), this.GetIntParameter(2), this.GetIntParameter(3), this.GetIntParameter(4));
				return;
			case 13:
			case 14:
				Debugger.Warning("You should no longer target thru event functions.");
				return;
			case 15:
				calendarEvent.AddEnabledData(this.GetDataParameter(0, LogicDataType.BILLING_PACKAGE));
				return;
			case 16:
			case 20:
				break;
			case 17:
				calendarEvent.AddFreeTroop((LogicCombatItemData)this.GetDataParameter(0, LogicDataType.CHARACTER), this.GetIntParameter(1));
				return;
			case 18:
				calendarEvent.AddFreeTroop((LogicCombatItemData)this.GetDataParameter(0, LogicDataType.SPELL), this.GetIntParameter(1));
				return;
			case 19:
			{
				if (this.GetDataParameter(0, LogicDataType.HERO) != null)
				{
					calendarEvent.AddFreeTroop((LogicCombatItemData)this.GetDataParameter(0, LogicDataType.HERO), 1);
					return;
				}
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.HERO);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					calendarEvent.AddFreeTroop((LogicCombatItemData)table.GetItemAt(i), 1);
				}
				return;
			}
			case 21:
				calendarEvent.AddBuildingDestroyedSpawnUnit((LogicBuildingData)this.GetDataParameter(0, LogicDataType.BUILDING), (LogicCharacterData)this.GetDataParameter(1, LogicDataType.CHARACTER), this.GetIntParameter(2));
				return;
			case 22:
				calendarEvent.AddUseTroop((LogicCombatItemData)this.GetDataParameter(0, LogicDataType.SPELL), this.GetIntParameter(1), this.GetIntParameter(2), this.GetIntParameter(3), this.GetIntParameter(4));
				return;
			case 23:
				calendarEvent.SetAllianceWarWinLootMultiplier(this.GetIntParameter(0));
				calendarEvent.SetAllianceWarDrawLootMultiplier(this.GetIntParameter(1));
				calendarEvent.SetAllianceWarLooseLootMultiplier(this.GetIntParameter(2));
				return;
			default:
				Debugger.Error(string.Format("Unknown function type: {0}.", this.logicCalendarEventFunctionData_0.GetFunctionType()));
				break;
			}
		}

		// Token: 0x060019B4 RID: 6580 RVA: 0x000618B4 File Offset: 0x0005FAB4
		public LogicData GetDataParameter(int idx, LogicDataType tableIdx)
		{
			if (this.IsValidParameter(idx))
			{
				int num = LogicStringUtil.ConvertToInt(this.logicArrayList_0[idx]);
				if (num != 0)
				{
					LogicData dataById = LogicDataTables.GetDataById(num, tableIdx);
					if (dataById != null)
					{
						return dataById;
					}
					this.logicCalendarErrorHandler_0.WarningFunction(this.logicCalendarEvent_0, this, this.logicCalendarEventFunctionData_0.GetParameterName(idx), string.Format("Unable to find data by id {0} from tableId {1}.", num, tableIdx));
				}
				else
				{
					this.logicCalendarErrorHandler_0.WarningFunction(this.logicCalendarEvent_0, this, this.logicCalendarEventFunctionData_0.GetParameterName(idx), string.Format("Expected globalId got {0}.", num));
				}
			}
			return null;
		}

		// Token: 0x060019B5 RID: 6581 RVA: 0x00061954 File Offset: 0x0005FB54
		public int GetIntParameter(int idx)
		{
			if (!this.IsValidParameter(idx))
			{
				return 0;
			}
			int num = LogicStringUtil.ConvertToInt(this.logicArrayList_0[idx]);
			int minValue = this.logicCalendarEventFunctionData_0.GetMinValue(idx);
			int maxValue = this.logicCalendarEventFunctionData_0.GetMaxValue(idx);
			if (num >= minValue && num <= maxValue)
			{
				return num;
			}
			this.logicCalendarErrorHandler_0.WarningFunction(this.logicCalendarEvent_0, this, this.logicCalendarEventFunctionData_0.GetParameterName(idx), string.Format("Value {0} is not between {1} and {2}.", num, minValue, maxValue));
			return minValue;
		}

		// Token: 0x060019B6 RID: 6582 RVA: 0x000619E0 File Offset: 0x0005FBE0
		public bool GetBoolParameter(int index)
		{
			if (!this.IsValidParameter(index))
			{
				return false;
			}
			string text = this.logicArrayList_0[index];
			if (!text.Equals("true", StringComparison.InvariantCultureIgnoreCase))
			{
				if (!text.Equals("false", StringComparison.InvariantCultureIgnoreCase))
				{
					this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, text, string.Format("Invalid boolean value {0}.", text));
				}
				return false;
			}
			return true;
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x00011137 File Offset: 0x0000F337
		public string GetStringParameter(int index)
		{
			if (this.IsValidParameter(index))
			{
				return this.logicArrayList_0[index];
			}
			return string.Empty;
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x00061A44 File Offset: 0x0005FC44
		public bool IsValidParameter(int idx)
		{
			if (this.logicArrayList_0.Size() <= idx)
			{
				this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, idx.ToString(), "Parameter has not been defined.");
			}
			else
			{
				if (idx >= 0)
				{
					return true;
				}
				this.logicCalendarErrorHandler_0.ErrorFunction(this.logicCalendarEvent_0, this, "Got negative parameter index");
			}
			return false;
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x00011154 File Offset: 0x0000F354
		public string GetName()
		{
			return this.logicCalendarEventFunctionData_0.GetName();
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x00011161 File Offset: 0x0000F361
		public LogicArrayList<string> GetParameters()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x04000DC8 RID: 3528
		private LogicCalendarEventFunctionData logicCalendarEventFunctionData_0;

		// Token: 0x04000DC9 RID: 3529
		private LogicCalendarEvent logicCalendarEvent_0;

		// Token: 0x04000DCA RID: 3530
		private LogicCalendarErrorHandler logicCalendarErrorHandler_0;

		// Token: 0x04000DCB RID: 3531
		private LogicArrayList<string> logicArrayList_0;

		// Token: 0x04000DCC RID: 3532
		private int int_0;
	}
}
