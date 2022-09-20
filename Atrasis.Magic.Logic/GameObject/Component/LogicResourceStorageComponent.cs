﻿using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000129 RID: 297
	public class LogicResourceStorageComponent : LogicComponent
	{
		// Token: 0x06001022 RID: 4130 RVA: 0x00047784 File Offset: 0x00045984
		public LogicResourceStorageComponent(LogicGameObject gameObject) : base(gameObject)
		{
			int itemCount = LogicDataTables.GetTable(LogicDataType.RESOURCE).GetItemCount();
			this.m_maxResourceCount = new LogicArrayList<int>(itemCount);
			this.m_stealableResourceCount = new LogicArrayList<int>(itemCount);
			this.m_resourceCount = new LogicArrayList<int>(itemCount);
			this.m_maxPercentageResourceCount = new LogicArrayList<int>(itemCount);
			for (int i = 0; i < itemCount; i++)
			{
				this.m_resourceCount.Add(0);
				this.m_maxResourceCount.Add(0);
				this.m_stealableResourceCount.Add(0);
				this.m_maxPercentageResourceCount.Add(100);
			}
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0000AE2E File Offset: 0x0000902E
		public override void Destruct()
		{
			base.Destruct();
			this.m_maxResourceCount = null;
			this.m_stealableResourceCount = null;
			this.m_resourceCount = null;
			this.m_maxPercentageResourceCount = null;
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0000AE52 File Offset: 0x00009052
		public int GetStealableResourceCount(int idx)
		{
			return LogicMath.Min(this.m_resourceCount[idx], this.m_stealableResourceCount[idx]);
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x00047814 File Offset: 0x00045A14
		public virtual void ResourcesStolen(int damage, int hp)
		{
			if (damage > 0 && hp > 0)
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				for (int i = 0; i < this.m_stealableResourceCount.Size(); i++)
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					int num = this.GetStealableResourceCount(i);
					if (damage < hp)
					{
						num = damage * num / hp;
					}
					if (num > 0)
					{
						this.m_parent.GetLevel().GetBattleLog().IncreaseStolenResourceCount(logicResourceData, num);
						LogicArrayList<int> resourceCount = this.m_resourceCount;
						int index = i;
						resourceCount[index] -= num;
						LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
						LogicAvatar visitorAvatar = this.m_parent.GetLevel().GetVisitorAvatar();
						homeOwnerAvatar.CommodityCountChangeHelper(0, logicResourceData, -num);
						visitorAvatar.CommodityCountChangeHelper(0, logicResourceData, num);
						if (homeOwnerAvatar.IsNpcAvatar())
						{
							LogicNpcData npcData = ((LogicNpcAvatar)homeOwnerAvatar).GetNpcData();
							if (logicResourceData == LogicDataTables.GetGoldData())
							{
								visitorAvatar.CommodityCountChangeHelper(1, npcData, num);
							}
							else if (logicResourceData == LogicDataTables.GetElixirData())
							{
								visitorAvatar.CommodityCountChangeHelper(2, npcData, num);
							}
						}
						this.m_stealableResourceCount[i] = LogicMath.Max(this.m_stealableResourceCount[i] - num, 0);
					}
				}
			}
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0000AE71 File Offset: 0x00009071
		public void SetCount(int idx, int count)
		{
			this.m_resourceCount[idx] = LogicMath.Clamp(count, 0, this.GetMax(idx));
			if (this.m_parent.GetListener() != null)
			{
				this.m_parent.GetListener().RefreshResourceCount();
			}
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x0000AEAA File Offset: 0x000090AA
		public virtual int GetMax(int idx)
		{
			if (this.m_parent.GetData() == LogicDataTables.GetTownHallData() && this.m_parent.GetLevel().IsNpcVillage())
			{
				return 10000000;
			}
			return this.m_maxResourceCount[idx];
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0000AEE2 File Offset: 0x000090E2
		public int GetCount(int idx)
		{
			return this.m_resourceCount[idx];
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x00047948 File Offset: 0x00045B48
		public int GetRecommendedMax(int idx)
		{
			int max = this.GetMax(idx);
			LogicHitpointComponent hitpointComponent = this.m_parent.GetHitpointComponent();
			if (hitpointComponent == null)
			{
				return max;
			}
			int hitpoints = hitpointComponent.GetHitpoints();
			int maxHitpoints = hitpointComponent.GetMaxHitpoints();
			if (hitpoints > 10000)
			{
				return 1000 * (max * (hitpoints / 1000) / maxHitpoints);
			}
			if (hitpoints <= 1000)
			{
				return max * hitpoints / maxHitpoints;
			}
			return 100 * (max * (hitpoints / 100) / maxHitpoints);
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x000479B0 File Offset: 0x00045BB0
		public int GetRecommendedMax(int idx, int count)
		{
			int recommendedMax = this.GetRecommendedMax(idx);
			if (this.m_maxPercentageResourceCount[idx] != 0)
			{
				return LogicMath.Min(this.m_maxPercentageResourceCount[idx] * count / 100, recommendedMax);
			}
			return recommendedMax;
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x000479EC File Offset: 0x00045BEC
		public void SetMaxArray(LogicArrayList<int> max)
		{
			for (int i = 0; i < max.Size(); i++)
			{
				this.m_maxResourceCount[i] = max[i];
			}
			this.m_parent.GetLevel().RefreshResourceCaps();
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x00047A30 File Offset: 0x00045C30
		public void SetMaxPercentageArray(LogicArrayList<int> max)
		{
			for (int i = 0; i < max.Size(); i++)
			{
				this.m_maxPercentageResourceCount[i] = max[i];
			}
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x00047A64 File Offset: 0x00045C64
		public virtual void RecalculateAvailableLoot()
		{
			int matchType = this.m_parent.GetLevel().GetMatchType();
			LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
			LogicAvatar visitorAvatar = this.m_parent.GetLevel().GetVisitorAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < this.m_resourceCount.Size(); i++)
			{
				LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
				int num = this.m_resourceCount[i];
				if (!homeOwnerAvatar.IsNpcAvatar())
				{
					if (matchType == 5 && this.m_parent.GetLevel().IsArrangedWar())
					{
						if (num >= 0)
						{
							num = 0;
						}
					}
					else if (LogicDataTables.GetGlobals().UseTownHallLootPenaltyInWar() || matchType != 5)
					{
						if (matchType != 8 && matchType != 9)
						{
							int num2 = 100;
							int num3 = 0;
							if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar() && visitorAvatar != null && visitorAvatar.IsClientAvatar())
							{
								num2 = LogicDataTables.GetGlobals().GetLootMultiplierByTownHallDiff(visitorAvatar.GetTownHallLevel(), homeOwnerAvatar.GetTownHallLevel());
							}
							if (this.m_parent.GetData() == LogicDataTables.GetTownHallData() && LogicDataTables.GetGlobals().GetTownHallLootPercentage() != -1)
							{
								num3 = num * (num2 * LogicDataTables.GetGlobals().GetTownHallLootPercentage() / 100) / 100;
							}
							else if (!logicResourceData.IsPremiumCurrency())
							{
								int townHallLevel = homeOwnerAvatar.GetTownHallLevel();
								int num4 = 0;
								if (matchType != 3)
								{
									if (matchType == 5)
									{
										num4 = num;
									}
									else if (matchType != 7)
									{
										num4 = (int)((long)num * (long)LogicDataTables.GetTownHallLevel(townHallLevel).GetStorageLootPercentage(logicResourceData) / 100L);
									}
								}
								int storageLootCap = LogicDataTables.GetTownHallLevel(townHallLevel).GetStorageLootCap(logicResourceData);
								int num5 = LogicMath.Min(homeOwnerAvatar.GetResourceCount(logicResourceData), homeOwnerAvatar.GetResourceCap(logicResourceData));
								if (num5 > storageLootCap && num5 > 0)
								{
									int num6;
									if (storageLootCap < 1000000)
									{
										if (storageLootCap < 100000)
										{
											if (storageLootCap < 10000)
											{
												if (storageLootCap < 1000)
												{
													num6 = (num * storageLootCap + (num5 >> 1)) / num5;
												}
												else if (!LogicDataTables.GetGlobals().UseMoreAccurateLootCap())
												{
													num6 = 100 * ((num * (storageLootCap / 100) + (num5 >> 1)) / num5);
												}
												else if (num / 100 > num5 / storageLootCap)
												{
													num6 = 100 * ((num * (storageLootCap / 100) + (num5 >> 1)) / num5);
												}
												else
												{
													num6 = (num * storageLootCap + (num5 >> 1)) / num5;
												}
											}
											else if (!LogicDataTables.GetGlobals().UseMoreAccurateLootCap())
											{
												num6 = 1000 * ((num * (storageLootCap / 1000) + (num5 >> 1)) / num5);
											}
											else if (num / 1000 > num5 / storageLootCap)
											{
												num6 = 1000 * ((num * (storageLootCap / 1000) + (num5 >> 1)) / num5);
											}
											else if (num / 100 > num5 / storageLootCap)
											{
												num6 = 100 * ((num * (storageLootCap / 100) + (num5 >> 1)) / num5);
											}
											else
											{
												num6 = (num * storageLootCap + (num5 >> 1)) / num5;
											}
										}
										else if (!LogicDataTables.GetGlobals().UseMoreAccurateLootCap())
										{
											num6 = 10000 * ((num * (storageLootCap / 10000) + (num5 >> 1)) / num5);
										}
										else if (num / 10000 > num5 / storageLootCap)
										{
											num6 = 10000 * ((num * (storageLootCap / 10000) + (num5 >> 1)) / num5);
										}
										else if (num / 1000 > num5 / storageLootCap)
										{
											num6 = 1000 * ((num * (storageLootCap / 1000) + (num5 >> 1)) / num5);
										}
										else if (num / 100 > num5 / storageLootCap)
										{
											num6 = 100 * ((num * (storageLootCap / 100) + (num5 >> 1)) / num5);
										}
										else
										{
											num6 = (num * storageLootCap + (num5 >> 1)) / num5;
										}
									}
									else
									{
										num6 = 40000 * ((num * (storageLootCap / 40000) + (num5 >> 1)) / num5);
									}
									if (num4 > num6)
									{
										num4 = num6;
									}
								}
								num3 = num2 * num4 / 100;
							}
							if (num3 <= num)
							{
								num = num3;
							}
						}
						else
						{
							num = 0;
						}
					}
				}
				this.m_stealableResourceCount[i] = num;
			}
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x00002D0D File Offset: 0x00000F0D
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.RESOURCE_STORAGE;
		}

		// Token: 0x040006A3 RID: 1699
		protected LogicArrayList<int> m_resourceCount;

		// Token: 0x040006A4 RID: 1700
		protected LogicArrayList<int> m_maxResourceCount;

		// Token: 0x040006A5 RID: 1701
		protected LogicArrayList<int> m_maxPercentageResourceCount;

		// Token: 0x040006A6 RID: 1702
		protected LogicArrayList<int> m_stealableResourceCount;
	}
}
