using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200012E RID: 302
	public sealed class LogicUnitUpgradeComponent : LogicComponent
	{
		// Token: 0x06001065 RID: 4197 RVA: 0x0000B114 File Offset: 0x00009314
		public LogicUnitUpgradeComponent(LogicGameObject gameObject) : base(gameObject)
		{
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0000B11D File Offset: 0x0000931D
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x00048F8C File Offset: 0x0004718C
		public override void Tick()
		{
			if (this.logicTimer_0 != null)
			{
				if (this.m_parent.GetLevel().GetRemainingClockTowerBoostTime() > 0)
				{
					LogicGameObjectData data = this.m_parent.GetData();
					if (data.GetDataType() == LogicDataType.BUILDING && data.GetVillageType() == 1)
					{
						this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
					}
				}
				if (this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) == 0)
				{
					this.FinishUpgrading(true);
				}
			}
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00003F0B File Offset: 0x0000210B
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.UNIT_UPGRADE;
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x0004901C File Offset: 0x0004721C
		public void FinishUpgrading(bool tick)
		{
			if (this.logicCombatItemData_0 != null)
			{
				this.m_parent.GetLevel().GetHomeOwnerAvatar().CommodityCountChangeHelper(1, this.logicCombatItemData_0, 1);
				if (this.logicCombatItemData_0.GetVillageType() == 1 && this.logicCombatItemData_0.GetCombatItemType() == LogicCombatItemType.CHARACTER)
				{
					this.m_parent.GetLevel().GetGameObjectManagerAt(1).RefreshArmyCampSize();
				}
				if (this.m_parent.GetLevel().GetState() == 1)
				{
					this.m_parent.GetLevel().GetGameListener().UnitUpgradeCompleted(this.logicCombatItemData_0, this.m_parent.GetLevel().GetHomeOwnerAvatar().GetUnitUpgradeLevel(this.logicCombatItemData_0), tick);
				}
				this.logicCombatItemData_0 = null;
			}
			else
			{
				Debugger.Warning("LogicUnitUpgradeComponent::finishUpgrading called and m_pUnit is NULL");
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x0000B13F File Offset: 0x0000933F
		public int GetRemainingSeconds()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x0000B166 File Offset: 0x00009366
		public int GetRemainingMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_parent.GetLevel().GetLogicTime());
			}
			return 0;
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x0000B18D File Offset: 0x0000938D
		public int GetTotalSeconds()
		{
			if (this.logicCombatItemData_0 != null)
			{
				return this.logicCombatItemData_0.GetUpgradeTime(this.m_parent.GetLevel().GetHomeOwnerAvatar().GetUnitUpgradeLevel(this.logicCombatItemData_0));
			}
			return 0;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x000490FC File Offset: 0x000472FC
		public override void Save(LogicJSONObject root, int villageType)
		{
			if (this.logicTimer_0 != null && this.logicCombatItemData_0 != null)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				logicJSONObject.Put("unit_type", new LogicJSONNumber((int)this.logicCombatItemType_0));
				logicJSONObject.Put("t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime())));
				logicJSONObject.Put("id", new LogicJSONNumber(this.logicCombatItemData_0.GetGlobalID()));
				if (this.logicTimer_0.GetEndTimestamp() != -1)
				{
					logicJSONObject.Put("t_end", new LogicJSONNumber(this.logicTimer_0.GetEndTimestamp()));
				}
				if (this.logicTimer_0.GetFastForward() > 0)
				{
					logicJSONObject.Put("t_ff", new LogicJSONNumber(this.logicTimer_0.GetFastForward()));
				}
				root.Put("unit_upg", logicJSONObject);
			}
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x000491E0 File Offset: 0x000473E0
		public override void Load(LogicJSONObject root)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicCombatItemData_0 = null;
			LogicJSONObject jsonobject = root.GetJSONObject("unit_upg");
			if (jsonobject != null)
			{
				LogicJSONNumber jsonnumber = jsonobject.GetJSONNumber("unit_type");
				LogicJSONNumber jsonnumber2 = jsonobject.GetJSONNumber("id");
				LogicJSONNumber jsonnumber3 = jsonobject.GetJSONNumber("t");
				LogicJSONNumber jsonnumber4 = jsonobject.GetJSONNumber("t_end");
				LogicJSONNumber jsonnumber5 = jsonobject.GetJSONNumber("t_ff");
				this.logicCombatItemType_0 = (LogicCombatItemType)((jsonnumber != null) ? jsonnumber.GetIntValue() : 0);
				if (jsonnumber2 != null && jsonnumber3 != null)
				{
					LogicData dataById = LogicDataTables.GetDataById(jsonnumber2.GetIntValue(), (this.logicCombatItemType_0 == LogicCombatItemType.CHARACTER) ? LogicDataType.CHARACTER : LogicDataType.SPELL);
					if (dataById != null)
					{
						this.logicCombatItemData_0 = (LogicCombatItemData)dataById;
						this.logicTimer_0 = new LogicTimer();
						this.logicTimer_0.StartTimer(jsonnumber3.GetIntValue(), this.m_parent.GetLevel().GetLogicTime(), false, -1);
						if (jsonnumber4 != null)
						{
							this.logicTimer_0.SetEndTimestamp(jsonnumber4.GetIntValue());
						}
						if (jsonnumber5 != null)
						{
							this.logicTimer_0.SetFastForward(jsonnumber5.GetIntValue());
						}
					}
				}
			}
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x00049304 File Offset: 0x00047504
		public override void LoadingFinished()
		{
			if (this.logicTimer_0 != null)
			{
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
				int totalSeconds = this.GetTotalSeconds();
				if (LogicDataTables.GetGlobals().ClampUpgradeTimes())
				{
					if (remainingSeconds > totalSeconds)
					{
						this.logicTimer_0.StartTimer(totalSeconds, this.m_parent.GetLevel().GetLogicTime(), true, this.m_parent.GetLevel().GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
						return;
					}
				}
				else
				{
					this.logicTimer_0.StartTimer(LogicMath.Min(remainingSeconds, totalSeconds), this.m_parent.GetLevel().GetLogicTime(), false, -1);
				}
			}
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x000493A8 File Offset: 0x000475A8
		public override void FastForwardTime(int time)
		{
			if (this.logicTimer_0 != null)
			{
				if (this.logicTimer_0.GetEndTimestamp() == -1)
				{
					this.logicTimer_0.StartTimer(this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) - time, this.m_parent.GetLevel().GetLogicTime(), false, -1);
				}
				else
				{
					this.logicTimer_0.AdjustEndSubtick(this.m_parent.GetLevel());
				}
				int updatedClockTowerBoostTime = this.m_parent.GetLevel().GetUpdatedClockTowerBoostTime();
				if (updatedClockTowerBoostTime > 0 && this.m_parent.GetLevel().IsClockTowerBoostPaused())
				{
					LogicGameObjectData data = this.m_parent.GetData();
					if (data.GetDataType() == LogicDataType.BUILDING && data.GetVillageType() == 1)
					{
						this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 60 * LogicMath.Min(time, updatedClockTowerBoostTime) * (LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 1));
					}
				}
			}
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x00049494 File Offset: 0x00047694
		public bool SpeedUp()
		{
			if (this.logicCombatItemData_0 != null)
			{
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost((this.logicTimer_0 != null) ? this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) : 0, 0, this.m_parent.GetVillageType());
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				if (this.m_parent.GetLevel().GetHomeOwnerAvatar().IsClientAvatar())
				{
					LogicClientAvatar logicClientAvatar = (LogicClientAvatar)homeOwnerAvatar;
					if (logicClientAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_parent.GetLevel()))
					{
						logicClientAvatar.UseDiamonds(speedUpCost);
						logicClientAvatar.GetChangeListener().DiamondPurchaseMade(4, this.logicCombatItemData_0.GetGlobalID(), logicClientAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0) + 1, speedUpCost, this.m_parent.GetLevel().GetVillageType());
						this.FinishUpgrading(true);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0000B1BF File Offset: 0x000093BF
		public LogicCombatItemData GetCurrentlyUpgradedUnit()
		{
			return this.logicCombatItemData_0;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00049570 File Offset: 0x00047770
		public void CancelUpgrade()
		{
			if (this.logicCombatItemData_0 != null)
			{
				LogicAvatar homeOwnerAvatar = this.m_parent.GetLevel().GetHomeOwnerAvatar();
				int unitUpgradeLevel = homeOwnerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0);
				homeOwnerAvatar.CommodityCountChangeHelper(0, this.logicCombatItemData_0.GetUpgradeResource(unitUpgradeLevel), this.logicCombatItemData_0.GetUpgradeCost(unitUpgradeLevel));
				this.logicCombatItemData_0 = null;
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x000495E4 File Offset: 0x000477E4
		public bool CanStartUpgrading(LogicCombatItemData data)
		{
			if (data != null && this.logicCombatItemData_0 == null && this.m_parent.GetLevel().GetGameMode().GetCalendar().IsProductionEnabled(data) && data.GetCombatItemType() != LogicCombatItemType.HERO && this.m_parent.GetVillageType() == data.GetVillageType())
			{
				int unitUpgradeLevel = this.m_parent.GetLevel().GetHomeOwnerAvatar().GetUnitUpgradeLevel(data);
				if (data.GetUpgradeLevelCount() - 1 > unitUpgradeLevel)
				{
					int num;
					if (data.GetVillageType() == 1)
					{
						num = this.m_parent.GetComponentManager().GetMaxBarrackLevel();
					}
					else
					{
						LogicComponentManager componentManager = this.m_parent.GetComponentManager();
						if (data.GetCombatItemType() == LogicCombatItemType.CHARACTER)
						{
							num = ((data.GetUnitOfType() != 1) ? componentManager.GetMaxDarkBarrackLevel() : componentManager.GetMaxBarrackLevel());
						}
						else
						{
							num = ((data.GetUnitOfType() == 1) ? componentManager.GetMaxSpellForgeLevel() : componentManager.GetMaxMiniSpellForgeLevel());
						}
					}
					if (num >= data.GetRequiredProductionHouseLevel())
					{
						LogicBuilding logicBuilding = (LogicBuilding)this.m_parent;
						if (!logicBuilding.IsLocked())
						{
							return logicBuilding.GetUpgradeLevel() >= data.GetRequiredLaboratoryLevel(unitUpgradeLevel + 1);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x00049700 File Offset: 0x00047900
		public void StartUpgrading(LogicCombatItemData data)
		{
			if (this.CanStartUpgrading(data))
			{
				this.logicCombatItemData_0 = data;
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(this.GetTotalSeconds(), this.m_parent.GetLevel().GetLogicTime(), true, this.m_parent.GetLevel().GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				this.logicCombatItemType_0 = this.logicCombatItemData_0.GetCombatItemType();
			}
		}

		// Token: 0x040006C1 RID: 1729
		private LogicTimer logicTimer_0;

		// Token: 0x040006C2 RID: 1730
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x040006C3 RID: 1731
		private LogicCombatItemType logicCombatItemType_0;
	}
}
