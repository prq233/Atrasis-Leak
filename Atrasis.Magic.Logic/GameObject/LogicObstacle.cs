using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000114 RID: 276
	public sealed class LogicObstacle : LogicGameObject
	{
		// Token: 0x06000E0B RID: 3595 RVA: 0x00033F1C File Offset: 0x0003211C
		public LogicObstacle(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			LogicObstacleData obstacleData = this.GetObstacleData();
			if (obstacleData.GetSpawnObstacle() != null)
			{
				base.AddComponent(new LogicSpawnerComponent(this, obstacleData.GetSpawnObstacle(), obstacleData.GetSpawnRadius(), obstacleData.GetSpawnIntervalSeconds(), obstacleData.GetSpawnCount(), obstacleData.GetMaxSpawned(), obstacleData.GetMaxLifetimeSpawns()));
			}
			if (obstacleData.IsLootCart())
			{
				LogicLootCartComponent logicLootCartComponent = new LogicLootCartComponent(this);
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				LogicBuilding townHall = base.GetGameObjectManager().GetTownHall();
				LogicArrayList<int> logicArrayList = new LogicArrayList<int>();
				int i = 0;
				int item = 0;
				while (i < table.GetItemCount())
				{
					LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
					if (townHall != null && !logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
					{
						item = LogicDataTables.GetTownHallLevel(townHall.GetUpgradeLevel()).GetCartLootCap(logicResourceData);
					}
					logicArrayList.Add(item);
					i++;
					item = 0;
				}
				logicLootCartComponent.SetCapacityCount(logicArrayList);
				base.AddComponent(logicLootCartComponent);
			}
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00009BB4 File Offset: 0x00007DB4
		public LogicObstacleData GetObstacleData()
		{
			return (LogicObstacleData)this.m_data;
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00009BC1 File Offset: 0x00007DC1
		public LogicLootCartComponent GetLootCartComponent()
		{
			return (LogicLootCartComponent)base.GetComponent(LogicComponentType.LOOT_CART);
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x00009BD0 File Offset: 0x00007DD0
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.int_6 = 0;
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00009BF9 File Offset: 0x00007DF9
		public override bool IsPassable()
		{
			return this.GetObstacleData().IsPassable();
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00034008 File Offset: 0x00032208
		public override void FastForwardTime(int time)
		{
			base.FastForwardTime(time);
			if (this.logicTimer_0 != null)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
				if (remainingSeconds <= time)
				{
					if (LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
					{
						this.logicTimer_0.StartTimer(0, this.m_level.GetLogicTime(), false, -1);
						return;
					}
					this.ClearingFinished(true);
					return;
				}
				else
				{
					this.logicTimer_0.StartTimer(remainingSeconds - time, this.m_level.GetLogicTime(), false, -1);
				}
			}
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00034088 File Offset: 0x00032288
		public override void Tick()
		{
			base.Tick();
			if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) > 0 && this.m_level.GetRemainingClockTowerBoostTime() > 0 && this.GetObstacleData().GetVillageType() == 1)
			{
				this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
			}
			if (this.int_6 < 1)
			{
				if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) <= 0)
				{
					this.ClearingFinished(false);
					return;
				}
			}
			else
			{
				this.int_6 = LogicMath.Min(this.int_6 + 64, this.GetFadingOutTime());
			}
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00009C06 File Offset: 0x00007E06
		public override bool ShouldDestruct()
		{
			return this.int_6 >= this.GetFadingOutTime();
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x0003414C File Offset: 0x0003234C
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			base.Save(jsonObject, villageType);
			if (this.logicTimer_0 != null)
			{
				jsonObject.Put("clear_t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime())));
				jsonObject.Put("clear_ff", new LogicJSONNumber(this.logicTimer_0.GetFastForward()));
			}
			if (this.int_5 != 1)
			{
				jsonObject.Put("lmv", new LogicJSONNumber(this.int_5));
			}
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00009C19 File Offset: 0x00007E19
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			jsonObject.Put("x", new LogicJSONNumber(base.GetTileX() & 63));
			jsonObject.Put("y", new LogicJSONNumber(base.GetTileY() & 63));
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x000341CC File Offset: 0x000323CC
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("clear_t");
			if (jsonnumber != null)
			{
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(jsonnumber.GetIntValue(), this.m_level.GetLogicTime(), false, -1);
				this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("clear_ff");
			if (jsonnumber2 != null && this.logicTimer_0 != null)
			{
				this.logicTimer_0.SetFastForward(jsonnumber2.GetIntValue());
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("loot_multiply_ver");
			if (jsonnumber3 == null)
			{
				jsonnumber3 = jsonObject.GetJSONNumber("lmv");
				if (jsonnumber3 == null)
				{
					this.int_5 = 1;
					return;
				}
			}
			this.int_5 = jsonnumber3.GetIntValue();
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00009C4D File Offset: 0x00007E4D
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			base.LoadFromSnapshot(jsonObject);
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x00009398 File Offset: 0x00007598
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (this.m_listener != null)
			{
				this.m_listener.LoadedFromJSON();
			}
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.OBSTACLE;
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00009C56 File Offset: 0x00007E56
		public override bool IsUnbuildable()
		{
			return this.GetObstacleData().IsTombstone() || this.GetObstacleData().IsLootCart();
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x00009C72 File Offset: 0x00007E72
		public override int GetWidthInTiles()
		{
			return this.GetObstacleData().GetWidth();
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00009C7F File Offset: 0x00007E7F
		public override int GetHeightInTiles()
		{
			return this.GetObstacleData().GetHeight();
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00009C8C File Offset: 0x00007E8C
		public bool IsTombstone()
		{
			return this.GetObstacleData().IsTombstone();
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00009C99 File Offset: 0x00007E99
		public int GetTombGroup()
		{
			return this.GetObstacleData().GetTombGroup();
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00009CA6 File Offset: 0x00007EA6
		public int GetFadeTime()
		{
			return this.int_6;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x000342A4 File Offset: 0x000324A4
		public int GetFadingOutTime()
		{
			LogicObstacleData obstacleData = this.GetObstacleData();
			if (obstacleData.IsTallGrass())
			{
				return 1000;
			}
			if (!obstacleData.IsLootCart())
			{
				return 2000;
			}
			return 4000;
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00009CAE File Offset: 0x00007EAE
		public int GetLootMultiplyVersion()
		{
			return this.int_5;
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00009CB6 File Offset: 0x00007EB6
		public void SetLootMultiplyVersion(int version)
		{
			this.int_5 = version;
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00009CBF File Offset: 0x00007EBF
		public int GetRemainingClearingTime()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00009CE1 File Offset: 0x00007EE1
		public int GetRemainingClearingTimeMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00009D03 File Offset: 0x00007F03
		public bool IsFadingOut()
		{
			return this.int_6 > 0;
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x00009D0E File Offset: 0x00007F0E
		public bool CanStartClearing()
		{
			return this.logicTimer_0 == null && this.int_6 == 0;
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x00009D23 File Offset: 0x00007F23
		public bool IsClearingOnGoing()
		{
			return this.logicTimer_0 != null;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x000342DC File Offset: 0x000324DC
		public void StartClearing()
		{
			if (this.logicTimer_0 == null && this.int_6 == 0)
			{
				if (this.GetObstacleData().GetClearTime() != 0)
				{
					this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
					this.logicTimer_0 = new LogicTimer();
					this.logicTimer_0.StartTimer(this.GetObstacleData().GetClearTime(), this.m_level.GetLogicTime(), false, -1);
					return;
				}
				this.ClearingFinished(false);
			}
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00009D2E File Offset: 0x00007F2E
		public void CancelClearing()
		{
			this.m_level.GetWorkerManagerAt(this.m_data.GetVillageType()).DeallocateWorker(this);
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00034354 File Offset: 0x00032554
		public void ClearingFinished(bool ignoreState)
		{
			int state = this.m_level.GetState();
			if ((state == 1 || (!LogicDataTables.GetGlobals().CompleteConstructionOnlyHome() && ignoreState)) && this.m_level.GetHomeOwnerAvatar().IsClientAvatar())
			{
				LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.m_level.GetHomeOwnerAvatar();
				LogicObstacleData obstacleData = this.GetObstacleData();
				LogicResourceData lootResourceData = obstacleData.GetLootResourceData();
				int lootCount = obstacleData.GetLootCount();
				if (obstacleData.IsLootCart())
				{
					LogicLootCartComponent logicLootCartComponent = (LogicLootCartComponent)base.GetComponent(LogicComponentType.LOOT_CART);
					if (logicLootCartComponent != null)
					{
						LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
						bool flag = true;
						for (int i = 0; i < table.GetItemCount(); i++)
						{
							LogicResourceData logicResourceData = (LogicResourceData)table.GetItemAt(i);
							if (!logicResourceData.IsPremiumCurrency() && logicResourceData.GetWarResourceReferenceData() == null)
							{
								int resourceCount = logicLootCartComponent.GetResourceCount(i);
								int num = LogicMath.Min(logicClientAvatar.GetUnusedResourceCap(logicResourceData), resourceCount);
								int num2 = resourceCount - num;
								if (num > 0)
								{
									logicClientAvatar.CommodityCountChangeHelper(0, logicResourceData, num);
									logicLootCartComponent.SetResourceCount(i, num2);
								}
								if (num2 > 0)
								{
									flag = false;
								}
							}
						}
						if (!flag)
						{
							return;
						}
					}
				}
				if (!obstacleData.IsTombstone() && !obstacleData.IsLootCart())
				{
					this.m_level.GetAchievementManager().ObstacleCleared();
				}
				this.m_level.GetWorkerManagerAt(this.m_villageType).DeallocateWorker(this);
				base.XpGainHelper(LogicGamePlayUtil.TimeToExp(obstacleData.GetClearTime()), logicClientAvatar, ignoreState || state == 1);
				if (lootResourceData != null && lootCount > 0)
				{
					if (logicClientAvatar != null)
					{
						if (lootResourceData.IsPremiumCurrency())
						{
							int num3 = 1;
							if (this.int_5 >= 2)
							{
								num3 = obstacleData.GetLootMultiplierVersion2();
							}
							int num4 = obstacleData.GetName().Equals("Bonus Gembox") ? (lootCount * num3) : this.m_level.GetGameObjectManagerAt(this.m_villageType).IncreaseObstacleClearCounter(num3);
							if (num4 > 0)
							{
								logicClientAvatar.SetDiamonds(logicClientAvatar.GetDiamonds() + num4);
								logicClientAvatar.SetFreeDiamonds(logicClientAvatar.GetFreeDiamonds() + num4);
								logicClientAvatar.GetChangeListener().FreeDiamondsAdded(num4, 6);
							}
						}
						else
						{
							int num5 = LogicMath.Min(logicClientAvatar.GetUnusedResourceCap(lootResourceData), lootCount);
							if (num5 > 0)
							{
								logicClientAvatar.CommodityCountChangeHelper(0, lootResourceData, num5);
							}
						}
					}
					else
					{
						Debugger.Error("LogicObstacle::clearingFinished - Home owner avatar is NULL!");
					}
				}
				obstacleData.IsEnabledInVillageType(this.m_level.GetVillageType());
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.int_6 = 1;
			}
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x000345B8 File Offset: 0x000327B8
		public bool SpeedUpClearing()
		{
			if (this.logicTimer_0 != null)
			{
				LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()), 0, this.m_villageType);
				if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_level))
				{
					playerAvatar.UseDiamonds(speedUpCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(3, this.m_data.GetGlobalID(), 0, speedUpCost, this.m_level.GetVillageType());
					this.ClearingFinished(false);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00034644 File Offset: 0x00032844
		public void ReengageLootCart(int secs)
		{
			LogicObstacleData obstacleData = this.GetObstacleData();
			LogicLootCartComponent logicLootCartComponent = (LogicLootCartComponent)base.GetComponent(LogicComponentType.LOOT_CART);
			LogicBuilding townHall = this.m_level.GetGameObjectManagerAt(0).GetTownHall();
			Debugger.DoAssert(obstacleData.IsLootCart(), string.Empty);
			Debugger.DoAssert(logicLootCartComponent != null, string.Empty);
			Debugger.DoAssert(townHall != null, string.Empty);
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicResourceData data = (LogicResourceData)table.GetItemAt(i);
				LogicTownhallLevelData townHallLevel = LogicDataTables.GetTownHallLevel(townHall.GetUpgradeLevel());
				int num = secs * townHallLevel.GetCartLootReengagement(data) / 100;
				if (num > logicLootCartComponent.GetResourceCount(i))
				{
					logicLootCartComponent.SetResourceCount(i, num);
				}
			}
		}

		// Token: 0x0400057D RID: 1405
		private LogicTimer logicTimer_0;

		// Token: 0x0400057E RID: 1406
		private int int_5;

		// Token: 0x0400057F RID: 1407
		private int int_6;
	}
}
