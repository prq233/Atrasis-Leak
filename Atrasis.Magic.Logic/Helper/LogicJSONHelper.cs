using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x0200010A RID: 266
	public static class LogicJSONHelper
	{
		// Token: 0x06000CB5 RID: 3253 RVA: 0x0002BB0C File Offset: 0x00029D0C
		public static bool GetBool(LogicJSONObject jsonObject, string key)
		{
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean(key);
			return jsonboolean != null && jsonboolean.IsTrue();
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0000927B File Offset: 0x0000747B
		public static LogicLong GetLogicLong(LogicJSONObject jsonObject, string key)
		{
			return new LogicLong(LogicJSONHelper.GetInt(jsonObject, key + "_hi"), LogicJSONHelper.GetInt(jsonObject, key + "_lo"));
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x000092A4 File Offset: 0x000074A4
		public static void SetInt(LogicJSONObject jsonObject, string key, int value)
		{
			jsonObject.Put(key, new LogicJSONNumber(value));
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x000092B3 File Offset: 0x000074B3
		public static void SetString(LogicJSONObject jsonObject, string key, string value)
		{
			jsonObject.Put(key, new LogicJSONString(value));
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x000092C2 File Offset: 0x000074C2
		public static void SetBool(LogicJSONObject jsonObject, string key, bool value)
		{
			jsonObject.Put(key, new LogicJSONBoolean(value));
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x000092D1 File Offset: 0x000074D1
		public static void SetLogicLong(LogicJSONObject jsonObject, string key, LogicLong value)
		{
			if (value != null)
			{
				LogicJSONHelper.SetInt(jsonObject, key + "_hi", value.GetHigherInt());
				LogicJSONHelper.SetInt(jsonObject, key + "_lo", value.GetLowerInt());
			}
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x00009304 File Offset: 0x00007504
		public static int GetInt(LogicJSONObject jsonObject, string key)
		{
			return LogicJSONHelper.GetInt(jsonObject, key, -1, true);
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0000930F File Offset: 0x0000750F
		public static int GetInt(LogicJSONObject jsonObject, string key, int defaultValue)
		{
			return LogicJSONHelper.GetInt(jsonObject, key, defaultValue, false);
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0002BB2C File Offset: 0x00029D2C
		public static int GetInt(LogicJSONObject jsonObject, string key, int defaultValue, bool throwIfNotExist)
		{
			if (jsonObject != null && key.Length != 0)
			{
				LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(key);
				if (jsonnumber != null)
				{
					return jsonnumber.GetIntValue();
				}
				if (!throwIfNotExist)
				{
					return defaultValue;
				}
				Debugger.Error(string.Format("Json number with key='{0}' not found!", key));
			}
			return -1;
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0000931A File Offset: 0x0000751A
		public static string GetString(LogicJSONObject jsonObject, string key)
		{
			return LogicJSONHelper.GetString(jsonObject, key, string.Empty, true);
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0002BB6C File Offset: 0x00029D6C
		public static string GetString(LogicJSONObject jsonObject, string key, string defaultValue, bool throwIfNotExist)
		{
			if (jsonObject != null && key.Length != 0)
			{
				LogicJSONString jsonstring = jsonObject.GetJSONString(key);
				if (jsonstring != null)
				{
					return jsonstring.GetStringValue();
				}
				if (!throwIfNotExist)
				{
					return defaultValue;
				}
				Debugger.Error(string.Format("Json string with key='{0}' not found!", key));
			}
			return null;
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00009329 File Offset: 0x00007529
		public static LogicData GetLogicData(LogicJSONObject jsonObject, string key)
		{
			LogicData dataById = LogicDataTables.GetDataById(LogicStringUtil.ConvertToInt(LogicJSONHelper.GetString(jsonObject, key, string.Empty, true)));
			if (dataById == null)
			{
				Debugger.Error("Unable to load data. key:" + key);
			}
			return dataById;
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x00009355 File Offset: 0x00007555
		public static LogicDeliverable GetLogicDeliverable(LogicJSONObject jsonObject)
		{
			LogicDeliverable logicDeliverable = LogicDeliverableFactory.CreateByType(LogicStringUtil.ConvertToInt(LogicJSONHelper.GetString(jsonObject, "type")));
			logicDeliverable.ReadFromJSON(jsonObject);
			return logicDeliverable;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0002BBAC File Offset: 0x00029DAC
		public static void SetLogicData(LogicJSONObject jsonObject, string key, LogicData value)
		{
			if (value != null)
			{
				jsonObject.Put(key, new LogicJSONString(value.GetGlobalID().ToString()));
				return;
			}
			Debugger.Error("Unable to set null data. key:" + key);
		}
	}
}
