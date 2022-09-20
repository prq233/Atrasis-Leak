using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000125 RID: 293
	public sealed class LogicLootCartComponent : LogicComponent
	{
		// Token: 0x06000FBA RID: 4026 RVA: 0x000438E8 File Offset: 0x00041AE8
		public LogicLootCartComponent(LogicGameObject gameObject) : base(gameObject)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			this.logicArrayList_0 = new LogicArrayList<int>(table.GetItemCount());
			this.logicArrayList_1 = new LogicArrayList<int>(table.GetItemCount());
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				this.logicArrayList_0.Add(0);
				this.logicArrayList_1.Add(0);
			}
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x0000AB0F File Offset: 0x00008D0F
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0000AB25 File Offset: 0x00008D25
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.LOOT_CART;
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x00043950 File Offset: 0x00041B50
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				if (!logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
				{
					if (LogicDataTables.GetGoldData() == logicResourceData)
					{
						LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("defg");
						if (jsonnumber != null)
						{
							this.SetResourceCount(i, jsonnumber.GetIntValue());
						}
					}
					else if (LogicDataTables.GetElixirData() == logicResourceData)
					{
						LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("defe");
						if (jsonnumber2 != null)
						{
							this.SetResourceCount(i, jsonnumber2.GetIntValue());
						}
					}
					else if (LogicDataTables.GetDarkElixirData() == logicResourceData)
					{
						LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("defde");
						if (jsonnumber3 != null)
						{
							this.SetResourceCount(i, jsonnumber3.GetIntValue());
						}
					}
				}
			}
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x00043A10 File Offset: 0x00041C10
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				if (!logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
				{
					if (LogicDataTables.GetGoldData() == logicResourceData)
					{
						int resourceCount = this.GetResourceCount(i);
						if (resourceCount > 0)
						{
							jsonObject.Put("defg", new LogicJSONNumber(resourceCount));
						}
					}
					else if (LogicDataTables.GetElixirData() == logicResourceData)
					{
						int resourceCount2 = this.GetResourceCount(i);
						if (resourceCount2 > 0)
						{
							jsonObject.Put("defe", new LogicJSONNumber(resourceCount2));
						}
					}
					else if (LogicDataTables.GetDarkElixirData() == logicResourceData)
					{
						int resourceCount3 = this.GetResourceCount(i);
						if (resourceCount3 > 0)
						{
							jsonObject.Put("defde", new LogicJSONNumber(resourceCount3));
						}
					}
				}
			}
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0000AB29 File Offset: 0x00008D29
		public int GetResourceCount(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0000AB37 File Offset: 0x00008D37
		public void SetResourceCount(int idx, int count)
		{
			this.logicArrayList_0[idx] = LogicMath.Clamp(count, 0, this.logicArrayList_1[idx]);
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0000AB58 File Offset: 0x00008D58
		public int GetCapacityCount(int idx)
		{
			return this.logicArrayList_1[idx];
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00043AD4 File Offset: 0x00041CD4
		public void SetCapacityCount(LogicArrayList<int> count)
		{
			for (int i = 0; i < count.Size(); i++)
			{
				this.logicArrayList_1[i] = count[i];
			}
			this.m_parent.GetLevel().RefreshResourceCaps();
		}

		// Token: 0x04000669 RID: 1641
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x0400066A RID: 1642
		private LogicArrayList<int> logicArrayList_1;
	}
}
