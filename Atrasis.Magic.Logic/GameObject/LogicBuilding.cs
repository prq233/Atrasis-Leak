using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x0200010C RID: 268
	public sealed class LogicBuilding : LogicGameObject
	{
		// Token: 0x06000CCF RID: 3279 RVA: 0x0002BC14 File Offset: 0x00029E14
		public LogicBuilding(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			LogicBuildingData buildingData = this.GetBuildingData();
			this.bool_1 = buildingData.IsLocked();
			if (buildingData.GetHitpoints(0) > 0)
			{
				LogicHitpointComponent logicHitpointComponent = new LogicHitpointComponent(this, buildingData.GetHitpoints(0), 1);
				logicHitpointComponent.SetMaxRegenerationTime(buildingData.GetRegenerationTime(0));
				base.AddComponent(logicHitpointComponent);
			}
			LogicAttackerItemData attackerItemData = buildingData.GetAttackerItemData(0);
			if (buildingData.GetHeroData() != null)
			{
				LogicHeroBaseComponent logicHeroBaseComponent = new LogicHeroBaseComponent(this, buildingData.GetHeroData());
				base.AddComponent(logicHeroBaseComponent);
				if (buildingData.GetShareHeroCombatData())
				{
					this.logicAttackerItemData_0 = buildingData.GetHeroData().GetAttackerItemData(0).Clone();
					this.logicAttackerItemData_0.AddAttackRange(buildingData.GetWidth() * 72704 / 200);
					logicHeroBaseComponent.SetSharedHeroCombatData(true);
					attackerItemData = this.logicAttackerItemData_0;
				}
			}
			if (buildingData.IsLaboratory())
			{
				LogicUnitUpgradeComponent logicUnitUpgradeComponent = new LogicUnitUpgradeComponent(this);
				logicUnitUpgradeComponent.SetEnabled(false);
				base.AddComponent(logicUnitUpgradeComponent);
			}
			if (buildingData.GetVillage2Housing() > 0)
			{
				LogicVillage2UnitComponent logicVillage2UnitComponent = new LogicVillage2UnitComponent(this);
				logicVillage2UnitComponent.SetEnabled(false);
				base.AddComponent(logicVillage2UnitComponent);
			}
			if (buildingData.GetUnitProduction(0) > 0)
			{
				LogicUnitProductionComponent logicUnitProductionComponent = new LogicUnitProductionComponent(this);
				logicUnitProductionComponent.SetEnabled(false);
				base.AddComponent(logicUnitProductionComponent);
			}
			if (buildingData.GetUnitStorageCapacity(0) > 0)
			{
				if (buildingData.IsAllianceCastle())
				{
					base.AddComponent(new LogicBunkerComponent(this, 0));
				}
				else
				{
					base.AddComponent(new LogicUnitStorageComponent(this, 0));
				}
			}
			if (attackerItemData.GetDamage(0, false) > 0 || attackerItemData.GetDamage2() > 0 || buildingData.GetAreaOfEffectSpell() != null || attackerItemData.GetShockwavePushStrength() > 0 || attackerItemData.GetHitSpell() != null)
			{
				LogicCombatComponent logicCombatComponent = new LogicCombatComponent(this);
				logicCombatComponent.SetAttackValues(attackerItemData, 100);
				logicCombatComponent.SetEnabled(false);
				base.AddComponent(logicCombatComponent);
			}
			if (buildingData.GetProduceResource() != null)
			{
				LogicResourceProductionComponent logicResourceProductionComponent = new LogicResourceProductionComponent(this, buildingData.GetProduceResource());
				logicResourceProductionComponent.SetEnabled(false);
				base.AddComponent(logicResourceProductionComponent);
			}
			if (buildingData.StoresResources())
			{
				if (buildingData.IsAllianceCastle())
				{
					base.AddComponent(new LogicWarResourceStorageComponent(this));
				}
				else
				{
					base.AddComponent(new LogicResourceStorageComponent(this));
				}
			}
			if (buildingData.GetDefenceTroopCharacter(0) != null)
			{
				base.AddComponent(new LogicDefenceUnitProductionComponent(this));
			}
			base.AddComponent(new LogicLayoutComponent(this));
			this.InitHidden(buildingData);
			this.InitAoeSpell(buildingData);
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000093C3 File Offset: 0x000075C3
		public LogicBuildingData GetBuildingData()
		{
			return (LogicBuildingData)this.m_data;
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x0002BE38 File Offset: 0x0002A038
		public void InitHidden(LogicBuildingData data)
		{
			if (data.IsHidden() && this.m_level.IsInCombatState())
			{
				this.bool_2 = true;
				this.logicGameObjectFilter_0 = new LogicGameObjectFilter();
				this.logicGameObjectFilter_0.AddGameObjectType(LogicGameObjectType.CHARACTER);
				this.logicGameObjectFilter_0.PassEnemyOnly(this);
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0002BE84 File Offset: 0x0002A084
		public void InitAoeSpell(LogicBuildingData data)
		{
			if (data.GetAreaOfEffectSpell() != null && this.m_level.IsInCombatState())
			{
				this.bool_3 = true;
				if (this.logicGameObjectFilter_0 == null)
				{
					this.logicGameObjectFilter_0 = new LogicGameObjectFilter();
					this.logicGameObjectFilter_0.AddGameObjectType(LogicGameObjectType.CHARACTER);
					this.logicGameObjectFilter_0.PassEnemyOnly(this);
				}
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x000093D0 File Offset: 0x000075D0
		public LogicHeroBaseComponent GetHeroBaseComponent()
		{
			return (LogicHeroBaseComponent)base.GetComponent(LogicComponentType.HERO_BASE);
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000093DF File Offset: 0x000075DF
		public LogicUnitProductionComponent GetUnitProductionComponent()
		{
			return (LogicUnitProductionComponent)base.GetComponent(LogicComponentType.UNIT_PRODUCTION);
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x000093ED File Offset: 0x000075ED
		public LogicUnitStorageComponent GetUnitStorageComponent()
		{
			return (LogicUnitStorageComponent)base.GetComponent(LogicComponentType.UNIT_STORAGE);
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x000093FB File Offset: 0x000075FB
		public LogicResourceStorageComponent GetResourceStorageComponentComponent()
		{
			return (LogicResourceStorageComponent)base.GetComponent(LogicComponentType.RESOURCE_STORAGE);
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x00009409 File Offset: 0x00007609
		public LogicUnitUpgradeComponent GetUnitUpgradeComponent()
		{
			return (LogicUnitUpgradeComponent)base.GetComponent(LogicComponentType.UNIT_UPGRADE);
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00009418 File Offset: 0x00007618
		public LogicWarResourceStorageComponent GetWarResourceStorageComponent()
		{
			return (LogicWarResourceStorageComponent)base.GetComponent(LogicComponentType.WAR_RESOURCE_STORAGE);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00009427 File Offset: 0x00007627
		public LogicVillage2UnitComponent GetVillage2UnitComponent()
		{
			return (LogicVillage2UnitComponent)base.GetComponent(LogicComponentType.VILLAGE2_UNIT);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00009436 File Offset: 0x00007636
		public int GetRemainingConstructionTime()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00009458 File Offset: 0x00007658
		public int GetRemainingConstructionTimeMS()
		{
			if (this.logicTimer_0 != null)
			{
				return this.logicTimer_0.GetRemainingMS(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0000947A File Offset: 0x0000767A
		public int GetRemainingBoostCooldownTime()
		{
			if (this.logicTimer_1 != null)
			{
				return this.logicTimer_1.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0000949C File Offset: 0x0000769C
		public int GetGearLevel()
		{
			return this.int_5;
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x000094A4 File Offset: 0x000076A4
		public void SetGearLevel(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x000094AD File Offset: 0x000076AD
		public LogicAttackerItemData GetAttackerItemData()
		{
			return this.GetBuildingData().GetAttackerItemData(this.int_6);
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x000094C0 File Offset: 0x000076C0
		public override int GetRemainingBoostTime()
		{
			if (this.logicTimer_2 != null)
			{
				return this.logicTimer_2.GetRemainingSeconds(this.m_level.GetLogicTime());
			}
			return 0;
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0002BED8 File Offset: 0x0002A0D8
		public override int GetMaxFastForwardTime()
		{
			if (this.logicTimer_0 != null && !LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
			{
				return LogicMath.Max(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()), 1);
			}
			LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)base.GetComponent(LogicComponentType.VILLAGE2_UNIT);
			if (logicVillage2UnitComponent == null || logicVillage2UnitComponent.GetCurrentlyTrainedUnit() == null)
			{
				if (this.GetUnitProductionComponent() == null || this.GetRemainingBoostTime() <= 0 || this.GetBoostMultiplier() <= 0)
				{
				}
				return -1;
			}
			int remainingSecs = logicVillage2UnitComponent.GetRemainingSecs();
			if (remainingSecs > 0)
			{
				return remainingSecs;
			}
			return -1;
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x0002BF5C File Offset: 0x0002A15C
		public int GetMaxBoostTime()
		{
			if (base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION) != null)
			{
				return LogicDataTables.GetGlobals().GetResourceProductionBoostSecs();
			}
			if (base.GetComponent(LogicComponentType.UNIT_PRODUCTION) != null)
			{
				if (this.GetUnitProductionComponent().GetProductionType() == LogicCombatItemType.CHARACTER)
				{
					return LogicDataTables.GetGlobals().GetBarracksBoostSecs();
				}
				return LogicDataTables.GetGlobals().GetSpellFactoryBoostSecs();
			}
			else
			{
				if (base.GetComponent(LogicComponentType.HERO_BASE) != null && !((LogicHeroBaseComponent)base.GetComponent(LogicComponentType.HERO_BASE)).IsUpgrading())
				{
					return LogicDataTables.GetGlobals().GetHeroRestBoostSecs();
				}
				if (this.GetBuildingData().IsClockTower())
				{
					return LogicDataTables.GetGlobals().GetClockTowerBoostSecs(this.int_6);
				}
				return 0;
			}
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x0002BFF4 File Offset: 0x0002A1F4
		public override void DeathEvent()
		{
			base.DeathEvent();
			LogicBuildingData buildingData = this.GetBuildingData();
			this.m_level.GetBattleLog().IncrementDestroyedBuildingCount(buildingData);
			this.m_level.GetTileMap().GetPathFinder().InvalidateCache();
			this.m_level.GetVisitorAvatar().XpGainHelper(buildingData.GetDestructionXP(this.int_6));
			LogicCalendarBuildingDestroyedSpawnUnit buildingDestroyedSpawnUnit = this.m_level.GetCalendar().GetBuildingDestroyedSpawnUnit();
			if (buildingDestroyedSpawnUnit != null && buildingDestroyedSpawnUnit.GetBuildingData() == this.m_data)
			{
				LogicCharacterData characterData = buildingDestroyedSpawnUnit.GetCharacterData();
				int i = 0;
				int count = buildingDestroyedSpawnUnit.GetCount();
				int num = 0;
				int num2 = 0;
				while (i < count)
				{
					LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(characterData, this.m_level, base.GetVillageType());
					logicCharacter.SetInitialPosition(this.GetMidX() + num % 512, this.GetMidY() + num2 % 512);
					LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
					if (hitpointComponent != null)
					{
						hitpointComponent.SetTeam(1);
						hitpointComponent.SetInvulnerabilityTime(64);
					}
					if (LogicDataTables.GetGlobals().EnableDefendingAllianceTroopJump())
					{
						base.GetMovementComponent().EnableJump(3600000);
					}
					this.m_level.GetGameObjectManager().AddGameObject(logicCharacter, -1);
					base.GetCombatComponent().SetSearchRadius(LogicDataTables.GetGlobals().GetClanCastleRadius() >> 9);
					base.GetMovementComponent().GetMovementSystem().CreatePatrolArea(this, this.m_level, true, i);
					i++;
					num += 721;
					num2 += 1051;
				}
			}
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x000094E2 File Offset: 0x000076E2
		public bool IsConstructing()
		{
			return this.logicTimer_0 != null;
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x000094ED File Offset: 0x000076ED
		public bool IsUpgrading()
		{
			return this.logicTimer_0 != null && this.bool_5;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x000094FF File Offset: 0x000076FF
		public bool IsGearing()
		{
			return this.logicTimer_0 != null && this.bool_4;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00009511 File Offset: 0x00007711
		public bool IsLocked()
		{
			return this.bool_1;
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00009519 File Offset: 0x00007719
		public void SetLocked(bool locked)
		{
			this.bool_1 = locked;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00009522 File Offset: 0x00007722
		public void Lock()
		{
			this.bool_1 = true;
			this.SetUpgradeLevel(0);
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00002B38 File Offset: 0x00000D38
		public override bool IsBuilding()
		{
			return true;
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00009532 File Offset: 0x00007732
		public override bool IsBoostPaused()
		{
			return this.bool_6;
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0000953A File Offset: 0x0000773A
		public void SetBoostPause(bool state)
		{
			this.bool_6 = state;
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00009543 File Offset: 0x00007743
		public int GetUpgradeLevel()
		{
			return this.int_6;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x0000954B File Offset: 0x0000774B
		public int GetWallIndex()
		{
			return this.int_7;
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00009553 File Offset: 0x00007753
		public override bool IsWall()
		{
			return this.GetBuildingData().IsWall();
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x0002C170 File Offset: 0x0002A370
		public override bool IsPassable()
		{
			if ((!LogicDataTables.GetGlobals().RemoveUntriggeredTesla() && !LogicDataTables.GetGlobals().UseTeslaTriggerCommand()) || !this.GetBuildingData().IsHidden())
			{
				int state = this.m_level.GetState();
				if (state != 1 && state != 4)
				{
					LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
					if (hitpointComponent != null && hitpointComponent.GetHitpoints() <= 0)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x0002C1D0 File Offset: 0x0002A3D0
		public bool IsConnectedWall()
		{
			if (this.IsWall())
			{
				int num = 0;
				int tileX = base.GetTileX();
				int tileY = base.GetTileY();
				for (int i = -1; i < 2; i++)
				{
					for (int j = -1; j < 2; j++)
					{
						if ((i | j) != 0)
						{
							LogicTile tile = this.m_level.GetTileMap().GetTile(tileX + i, tileY + j);
							if (tile != null)
							{
								for (int k = 0; k < tile.GetGameObjectCount(); k++)
								{
									if (tile.GetGameObject(k).IsWall())
									{
										num++;
									}
								}
							}
						}
					}
				}
				return num > 1;
			}
			return false;
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00009560 File Offset: 0x00007760
		public override int GetWidthInTiles()
		{
			return this.GetBuildingData().GetWidth();
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0000956D File Offset: 0x0000776D
		public override int GetHeightInTiles()
		{
			return this.GetBuildingData().GetHeight();
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x0000957A File Offset: 0x0000777A
		public override int PassableSubtilesAtEdge()
		{
			if (!this.IsWall())
			{
				return LogicMath.Max(1, this.GetBuildingData().GetWidth() - this.GetBuildingData().GetBuildingW());
			}
			return 0;
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x0002C264 File Offset: 0x0002A464
		public override int PathFinderCost()
		{
			if (this.IsWall() && base.IsAlive())
			{
				LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					if (this.int_11 <= 0)
					{
						int num = hitpointComponent.GetHitpoints() / 100;
						int num2 = hitpointComponent.GetMaxHitpoints() / 100;
						int wallCostBase = LogicDataTables.GetGlobals().GetWallCostBase();
						int num3 = 4000 - wallCostBase;
						if (this.int_10 > 0)
						{
							num3 = 3 * num3 >> 2;
						}
						return wallCostBase + base.Rand(0) % 256 + num * num3 / num2;
					}
					return 100;
				}
			}
			return 0;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x0002C2E8 File Offset: 0x0002A4E8
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			if (this.logicTimer_1 != null)
			{
				this.logicTimer_1.Destruct();
				this.logicTimer_1 = null;
			}
			if (this.logicTimer_2 != null)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
			}
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x0002C34C File Offset: 0x0002A54C
		public override void Tick()
		{
			base.Tick();
			if (this.int_11 > 0)
			{
				this.int_11 = LogicMath.Max(this.int_11 - 64, 0);
				if (this.int_11 == 0)
				{
					base.RefreshPassable();
				}
			}
			if (this.int_10 > 0)
			{
				this.int_10 = LogicMath.Max(this.int_10 - 64, 0);
				if (this.int_10 == 0)
				{
					base.RefreshPassable();
				}
			}
			if (this.logicTimer_0 != null)
			{
				if (this.m_level.GetRemainingClockTowerBoostTime() > 0 && this.GetBuildingData().GetVillageType() == 1)
				{
					this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 4 * LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 4);
				}
				if (this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) <= 0)
				{
					this.FinishConstruction(false, true);
				}
			}
			if (this.logicTimer_2 != null && this.logicTimer_2.GetRemainingSeconds(this.m_level.GetLogicTime()) <= 0)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
				if (this.GetBuildingData().IsClockTower())
				{
					this.logicTimer_1 = new LogicTimer();
					this.logicTimer_1.StartTimer(LogicDataTables.GetGlobals().GetClockTowerBoostCooldownSecs(), this.m_level.GetLogicTime(), false, -1);
					this.m_level.GetGameListener();
				}
				if (this.m_listener != null)
				{
					this.m_listener.RefreshState();
				}
			}
			LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
			if (hitpointComponent != null)
			{
				hitpointComponent.EnableRegeneration(this.m_level.GetState() == 1);
			}
			if (this.m_level.IsInCombatState())
			{
				if (this.bool_2)
				{
					this.UpdateHidden();
				}
				if (this.bool_3)
				{
					this.UpdateAreaOfEffectSpell();
				}
				if (!base.IsAlive())
				{
					LogicBuildingData buildingData = this.GetBuildingData();
					int dieDamageDelay = buildingData.GetDieDamageDelay();
					int num = this.int_12;
					this.int_12 += 64;
					if (dieDamageDelay >= num && dieDamageDelay < this.int_12)
					{
						this.UpdateDieDamage(buildingData.GetDieDamage(this.int_6), buildingData.GetDieDamageRadius());
					}
				}
				this.UpdateAuraSpell();
			}
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x0002C550 File Offset: 0x0002A750
		public override void SubTick()
		{
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			if (combatComponent != null)
			{
				combatComponent.SubTick();
				if (combatComponent.GetTarget(0) != null)
				{
					LogicBuildingData buildingData = this.GetBuildingData();
					int angleToTarget = this.GetAngleToTarget();
					if (angleToTarget <= 0)
					{
						if (angleToTarget < 0)
						{
							this.int_9 -= 16 * buildingData.GetTurnSpeed();
						}
					}
					else
					{
						this.int_9 += 16 * buildingData.GetTurnSpeed();
					}
					if (angleToTarget * this.GetAngleToTarget() < 0)
					{
						this.int_9 = 1000 * (this.GetDirection() + this.GetAngleToTarget());
					}
					if (this.int_9 < 360000)
					{
						if (this.int_9 < 0)
						{
							this.int_9 += 360000;
						}
					}
					else
					{
						this.int_9 -= 360000;
					}
					LogicAttackerItemData attackerItemData = combatComponent.GetAttackerItemData();
					if (attackerItemData.GetTargetingConeAngle() > 0)
					{
						int num = 1000 * combatComponent.GetAimAngle(this.m_level.GetActiveLayout(this.m_level.GetVillageType()), false);
						int num2 = this.int_9 - num;
						if (num2 < 180000)
						{
							if (num2 < -180000)
							{
								num2 += 360000;
							}
						}
						else
						{
							num2 -= 360000;
						}
						this.int_9 = num + LogicMath.Clamp(num2, -500 * attackerItemData.GetTargetingConeAngle(), 500 * attackerItemData.GetTargetingConeAngle());
						if (this.int_9 < 360000)
						{
							if (this.int_9 < 0)
							{
								this.int_9 += 360000;
							}
						}
						else
						{
							this.int_9 -= 360000;
						}
					}
				}
			}
			if (this.logicTimer_1 != null && this.bool_6)
			{
				this.logicTimer_1.StartTimer(this.logicTimer_2.GetRemainingSeconds(this.m_level.GetLogicTime()), this.m_level.GetLogicTime(), false, -1);
			}
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x0002C730 File Offset: 0x0002A930
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			if (this.int_6 == 0 && this.logicTimer_0 != null && !this.bool_5)
			{
				jsonObject.Put("lvl", new LogicJSONNumber(-1));
			}
			else
			{
				jsonObject.Put("lvl", new LogicJSONNumber(this.int_6));
			}
			if (this.bool_4)
			{
				jsonObject.Put("gearing", new LogicJSONBoolean(true));
			}
			if (this.logicTimer_0 != null)
			{
				jsonObject.Put("const_t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime())));
				if (this.logicTimer_0.GetEndTimestamp() != -1)
				{
					jsonObject.Put("const_t_end", new LogicJSONNumber(this.logicTimer_0.GetEndTimestamp()));
				}
				if (this.logicTimer_0.GetFastForward() > 0)
				{
					jsonObject.Put("con_ff", new LogicJSONNumber(this.logicTimer_0.GetFastForward()));
				}
			}
			if (this.bool_1)
			{
				jsonObject.Put("locked", new LogicJSONBoolean(true));
			}
			if (this.logicTimer_2 != null)
			{
				jsonObject.Put("boost_t", new LogicJSONNumber(this.logicTimer_2.GetRemainingSeconds(this.m_level.GetLogicTime())));
			}
			if (this.bool_6)
			{
				jsonObject.Put("boost_pause", new LogicJSONBoolean(true));
			}
			if (this.GetRemainingBoostCooldownTime() > 0)
			{
				jsonObject.Put("bcd", new LogicJSONNumber(this.GetRemainingBoostCooldownTime()));
			}
			if (this.int_5 > 0)
			{
				jsonObject.Put("gear", new LogicJSONNumber(this.int_5));
			}
			if (this.IsWall())
			{
				jsonObject.Put("wI", new LogicJSONNumber(this.int_7));
				if (this.bool_0)
				{
					jsonObject.Put("wP", new LogicJSONNumber(1));
				}
				jsonObject.Put("wX", new LogicJSONNumber(this.int_8));
			}
			base.Save(jsonObject, villageType);
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x0002C90C File Offset: 0x0002AB0C
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			if (this.int_6 == 0 && this.logicTimer_0 != null && !this.bool_5)
			{
				jsonObject.Put("lvl", new LogicJSONNumber(-1));
			}
			else
			{
				jsonObject.Put("lvl", new LogicJSONNumber(this.int_6));
			}
			if (this.bool_4)
			{
				jsonObject.Put("gearing", new LogicJSONBoolean(true));
			}
			if (this.logicTimer_0 != null)
			{
				jsonObject.Put("const_t", new LogicJSONNumber(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime())));
			}
			if (this.bool_1)
			{
				jsonObject.Put("locked", new LogicJSONBoolean(true));
			}
			if (this.int_5 > 0)
			{
				jsonObject.Put("gear", new LogicJSONNumber(this.int_5));
			}
			base.SaveToSnapshot(jsonObject, layoutId);
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x0002C9E4 File Offset: 0x0002ABE4
		public override void Load(LogicJSONObject jsonObject)
		{
			this.LoadUpgradeLevel(jsonObject);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("const_t");
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("gearing");
			if (jsonboolean != null)
			{
				this.bool_4 = jsonboolean.IsTrue();
			}
			if (jsonnumber != null)
			{
				int num = jsonnumber.GetIntValue();
				if (!LogicDataTables.GetGlobals().ClampBuildingTimes() && this.int_6 < this.GetBuildingData().GetUpgradeLevelCount() - 1)
				{
					num = LogicMath.Min(num, this.GetBuildingData().GetConstructionTime(this.int_6 + 1, this.m_level, 0));
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(num, this.m_level.GetLogicTime(), false, -1);
				LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("const_t_end");
				if (jsonnumber2 != null)
				{
					this.logicTimer_0.SetEndTimestamp(jsonnumber2.GetIntValue());
				}
				LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("con_ff");
				if (jsonnumber3 != null)
				{
					this.logicTimer_0.SetFastForward(jsonnumber3.GetIntValue());
				}
				if (this.bool_4)
				{
					this.m_level.GetWorkerManagerAt(1).AllocateWorker(this);
				}
				else
				{
					this.m_level.GetWorkerManagerAt(this.m_villageType).AllocateWorker(this);
					this.bool_5 = (this.int_6 != -1);
				}
			}
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("boost_t");
			if (this.logicTimer_2 != null)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
			}
			if (jsonnumber4 != null)
			{
				this.logicTimer_2 = new LogicTimer();
				this.logicTimer_2.StartTimer(jsonnumber4.GetIntValue(), this.m_level.GetLogicTime(), false, -1);
			}
			LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("bcd");
			if (jsonnumber5 != null)
			{
				this.logicTimer_1 = new LogicTimer();
				this.logicTimer_1.StartTimer(jsonnumber5.GetIntValue(), this.m_level.GetLogicTime(), false, -1);
			}
			LogicJSONBoolean jsonboolean2 = jsonObject.GetJSONBoolean("boost_pause");
			if (jsonboolean2 != null)
			{
				this.bool_6 = jsonboolean2.IsTrue();
			}
			if (this.logicTimer_2 == null && LogicDataTables.GetGlobals().StopBoostPauseWhenBoostTimeZeroOnLoad())
			{
				this.bool_6 = false;
			}
			if (this.IsWall())
			{
				LogicJSONNumber jsonnumber6 = jsonObject.GetJSONNumber("wI");
				if (jsonnumber6 != null)
				{
					this.int_7 = jsonnumber6.GetIntValue();
				}
				LogicJSONNumber jsonnumber7 = jsonObject.GetJSONNumber("wX");
				if (jsonnumber7 != null)
				{
					this.int_8 = jsonnumber7.GetIntValue();
				}
				LogicJSONNumber jsonnumber8 = jsonObject.GetJSONNumber("wP");
				if (jsonnumber8 != null)
				{
					this.bool_0 = (jsonnumber8.GetIntValue() != 0);
				}
			}
			if (LogicDataTables.GetGlobals().FixMergeOldBarrackBoostPausing() && LogicDataTables.GetGlobals().UseNewTraining() && this.GetBuildingData().GetUnitProduction(0) > 0 && this.logicTimer_2 != null)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
				if (this.logicTimer_1 != null)
				{
					this.logicTimer_1.Destruct();
					this.logicTimer_1 = null;
				}
			}
			this.SetUpgradeLevel(LogicMath.Clamp(this.int_6, 0, this.GetBuildingData().GetUpgradeLevelCount() - 1));
			base.Load(jsonObject);
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x0002CCE4 File Offset: 0x0002AEE4
		public void LoadUpgradeLevel(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("lvl");
			if (jsonnumber != null)
			{
				this.int_6 = jsonnumber.GetIntValue();
				int upgradeLevelCount = this.GetBuildingData().GetUpgradeLevelCount();
				if (this.int_6 >= upgradeLevelCount)
				{
					Debugger.Warning(string.Format("LogicBuilding::load() - Loaded upgrade level {0} is over max! (max = {1}) id {2} data id {3}", new object[]
					{
						this.int_6,
						upgradeLevelCount,
						this.m_globalId,
						this.m_data.GetGlobalID()
					}));
					this.int_6 = upgradeLevelCount - 1;
				}
				else if (this.int_6 < -1)
				{
					Debugger.Error("LogicBuilding::load() - Loaded an illegal upgrade level!");
				}
			}
			else
			{
				Debugger.Error("LogicBuilding::load - Upgrade level was not found!");
				this.int_6 = 0;
			}
			this.m_level.GetWorkerManagerAt(1).DeallocateWorker(this);
			this.m_level.GetWorkerManagerAt(this.m_villageType).DeallocateWorker(this);
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("gear");
			if (jsonnumber2 != null)
			{
				this.int_5 = jsonnumber2.GetIntValue();
			}
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("locked");
			if (jsonboolean != null)
			{
				this.bool_1 = jsonboolean.IsTrue();
				return;
			}
			this.bool_1 = false;
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x0002CE0C File Offset: 0x0002B00C
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			if (this.m_data.GetVillageType() == 1)
			{
				this.Load(jsonObject);
				return;
			}
			this.LoadUpgradeLevel(jsonObject);
			this.SetUpgradeLevel(LogicMath.Clamp(this.int_6, 0, this.GetBuildingData().GetUpgradeLevelCount() - 1));
			base.LoadFromSnapshot(jsonObject);
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x000095A3 File Offset: 0x000077A3
		public override void StopBoost()
		{
			if (this.logicTimer_2 != null && this.CanStopBoost() && !this.bool_6)
			{
				this.bool_6 = true;
			}
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x0002CE5C File Offset: 0x0002B05C
		public override void FastForwardTime(int secs)
		{
			if (this.logicTimer_0 != null)
			{
				if (this.logicTimer_0.GetEndTimestamp() == -1)
				{
					int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
					if (remainingSeconds > secs)
					{
						base.FastForwardTime(secs);
						this.logicTimer_0.StartTimer(remainingSeconds - secs, this.m_level.GetLogicTime(), false, -1);
					}
					else
					{
						if (LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
						{
							base.FastForwardTime(secs);
							this.logicTimer_0.StartTimer(0, this.m_level.GetLogicTime(), false, -1);
							return;
						}
						base.FastForwardTime(remainingSeconds);
						this.FinishConstruction(true, true);
						base.FastForwardTime(secs - remainingSeconds);
						return;
					}
				}
				else
				{
					this.logicTimer_0.AdjustEndSubtick(this.m_level);
					if (this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()) == 0)
					{
						if (LogicDataTables.GetGlobals().CompleteConstructionOnlyHome())
						{
							base.FastForwardTime(secs);
							this.logicTimer_0.StartTimer(0, this.m_level.GetLogicTime(), false, -1);
							return;
						}
						base.FastForwardTime(0);
						this.FinishConstruction(true, true);
						base.FastForwardTime(secs);
						return;
					}
					else
					{
						base.FastForwardTime(secs);
					}
				}
				int updatedClockTowerBoostTime = this.m_level.GetUpdatedClockTowerBoostTime();
				if (updatedClockTowerBoostTime > 0 && !this.m_level.IsClockTowerBoostPaused() && this.m_data.GetVillageType() == 1)
				{
					this.logicTimer_0.SetFastForward(this.logicTimer_0.GetFastForward() + 60 * LogicMath.Min(secs, updatedClockTowerBoostTime) * (LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier() - 1));
					return;
				}
			}
			else
			{
				base.FastForwardTime(secs);
			}
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x0002CFE4 File Offset: 0x0002B1E4
		public override void FastForwardBoost(int secs)
		{
			base.FastForwardBoost(secs);
			if (this.GetBuildingData().IsClockTower() && this.logicTimer_1 != null)
			{
				int remainingSeconds = this.logicTimer_1.GetRemainingSeconds(this.m_level.GetLogicTime());
				if (remainingSeconds <= secs)
				{
					this.logicTimer_1.Destruct();
					this.logicTimer_1 = null;
					if (this.m_listener != null)
					{
						this.m_listener.RefreshState();
					}
				}
				else
				{
					this.logicTimer_1.StartTimer(remainingSeconds - secs, this.m_level.GetLogicTime(), false, -1);
				}
			}
			if (this.logicTimer_2 != null)
			{
				if (!this.bool_6)
				{
					int remainingSeconds2 = this.logicTimer_2.GetRemainingSeconds(this.m_level.GetLogicTime());
					if (remainingSeconds2 <= secs)
					{
						this.logicTimer_2.Destruct();
						this.logicTimer_2 = null;
						if (this.GetBuildingData().IsClockTower())
						{
							int num = secs - remainingSeconds2;
							if (num < 0)
							{
								Debugger.Warning("boost timer run out during FF -> start cooldown, but timeToFF < 0");
							}
							this.logicTimer_1 = new LogicTimer();
							this.logicTimer_1.StartTimer(LogicDataTables.GetGlobals().GetClockTowerBoostCooldownSecs() - num, this.m_level.GetLogicTime(), false, -1);
						}
						if (this.m_listener != null)
						{
							this.m_listener.RefreshState();
						}
					}
					else
					{
						this.logicTimer_2.StartTimer(remainingSeconds2 - secs, this.m_level.GetLogicTime(), false, -1);
					}
				}
				if (this.logicTimer_2 != null && this.GetBuildingData().IsClockTower())
				{
					this.bool_6 = false;
				}
			}
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x000095C4 File Offset: 0x000077C4
		public override int GetStrengthWeight()
		{
			return this.GetBuildingData().GetStrengthWeight(this.int_6);
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x0002D148 File Offset: 0x0002B348
		public bool IsValidTarget(LogicGameObject target)
		{
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			if (combatComponent != null && combatComponent.GetAttackerItemData().GetTargetingConeAngle() != 0)
			{
				return LogicMath.Abs(this.GetAngleToTarget(target)) <= combatComponent.GetAttackerItemData().GetTargetingConeAngle() / 2;
			}
			return !this.GetBuildingData().IsNeedsAim() || LogicMath.Abs(this.GetAngleToTarget(target)) < 5;
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0002D1AC File Offset: 0x0002B3AC
		public int GetAngleToTarget()
		{
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			if (combatComponent != null && combatComponent.GetTarget(0) != null)
			{
				return this.GetAngleToTarget(combatComponent.GetTarget(0));
			}
			return 0;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x0002D1DC File Offset: 0x0002B3DC
		public int GetAngleToTarget(LogicGameObject gameObject)
		{
			int num = gameObject.GetMidX() - this.GetMidX();
			int num2 = gameObject.GetMidY() - this.GetMidY();
			if (num == 0 && num2 == 0)
			{
				return 0;
			}
			return LogicMath.NormalizeAngle180(LogicMath.GetAngle(num, num2) - this.GetDirection());
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0002D220 File Offset: 0x0002B420
		public void UpdateHidden()
		{
			if ((this.m_level.GetLogicTime().GetTick() / 4 & 7) == 0)
			{
				if (this.logicTimer_0 != null)
				{
					this.bool_2 = false;
				}
				LogicBuildingData buildingData = this.GetBuildingData();
				LogicGameObject closestGameObject = base.GetGameObjectManager().GetClosestGameObject(this.GetMidX(), this.GetMidY(), this.logicGameObjectFilter_0);
				bool flag = false;
				if (closestGameObject != null)
				{
					LogicCombatComponent combatComponent = closestGameObject.GetCombatComponent();
					if ((combatComponent == null || combatComponent.GetUndergroundTime() <= 0) && (LogicDataTables.GetGlobals().SkeletonTriggerTesla() || !LogicDataTables.IsSkeleton((LogicCharacterData)this.m_data)))
					{
						flag = (closestGameObject.GetPosition().GetDistanceSquaredTo(this.GetMidX(), this.GetMidY()) < buildingData.GetTriggerRadius() * buildingData.GetTriggerRadius());
					}
				}
				if (flag || this.m_level.GetBattleLog().GetDestructionPercentage() > LogicDataTables.GetGlobals().GetHiddenBuildingAppearDestructionPercentage())
				{
					if (LogicDataTables.GetGlobals().UseTeslaTriggerCommand())
					{
						if (this.m_level.GetState() != 5)
						{
							LogicTriggerTeslaCommand logicTriggerTeslaCommand = new LogicTriggerTeslaCommand(this);
							logicTriggerTeslaCommand.SetExecuteSubTick(this.m_level.GetLogicTime().GetTick() + 1);
							this.m_level.GetGameMode().GetCommandManager().AddCommand(logicTriggerTeslaCommand);
							return;
						}
					}
					else
					{
						this.Trigger();
					}
				}
			}
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0002D350 File Offset: 0x0002B550
		public void UpdateAreaOfEffectSpell()
		{
			if (base.IsAlive())
			{
				LogicGameObject closestGameObject = base.GetGameObjectManager().GetClosestGameObject(this.GetMidX(), this.GetMidY(), this.logicGameObjectFilter_0);
				if (closestGameObject != null)
				{
					bool alt = base.GetCombatComponent(false).UseAltAttackMode(this.m_level.GetActiveLayout(this.m_level.GetVillageType()), false);
					ulong distanceSquaredTo = (ulong)closestGameObject.GetPosition().GetDistanceSquaredTo(this.GetMidX(), this.GetMidY());
					int attackRange = (this.logicAttackerItemData_0 ?? this.GetBuildingData().GetAttackerItemData(this.int_6)).GetAttackRange(alt);
					if (distanceSquaredTo <= (ulong)((long)(attackRange * attackRange)))
					{
						if (this.logicSpell_1 == null)
						{
							this.logicSpell_1 = (LogicSpell)LogicGameObjectFactory.CreateGameObject(this.GetBuildingData().GetAreaOfEffectSpell(), this.m_level, this.m_villageType);
							this.logicSpell_1.SetUpgradeLevel(this.int_6);
							this.logicSpell_1.SetInitialPosition(this.GetMidX(), this.GetMidY());
							base.GetGameObjectManager().AddGameObject(this.logicSpell_1, -1);
						}
						return;
					}
				}
			}
			if (this.logicSpell_1 != null)
			{
				this.bool_5 = true;
				this.logicSpell_1 = null;
			}
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x0002D470 File Offset: 0x0002B670
		public void UpdateAuraSpell()
		{
			if (base.IsAlive())
			{
				if (this.GetBuildingData().GetShareHeroCombatData())
				{
					LogicHeroBaseComponent heroBaseComponent = this.GetHeroBaseComponent();
					if (heroBaseComponent != null)
					{
						LogicHeroData heroData = heroBaseComponent.GetHeroData();
						LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
						int unitUpgradeLevel = homeOwnerAvatar.GetUnitUpgradeLevel(heroData);
						if (homeOwnerAvatar.IsHeroAvailableForDefense(heroData))
						{
							LogicSpellData auraSpell = heroData.GetAuraSpell(unitUpgradeLevel);
							if (auraSpell != null)
							{
								if (this.logicSpell_0 != null)
								{
									if (!this.logicSpell_0.GetHitsCompleted())
									{
										return;
									}
									base.GetGameObjectManager().RemoveGameObject(this.logicSpell_0);
									this.logicSpell_0 = null;
								}
								if (this.m_level.GetBattleLog().GetBattleStarted())
								{
									LogicCombatComponent combatComponent = base.GetCombatComponent();
									if (combatComponent != null && combatComponent.GetDeployedHousingSpace() >= combatComponent.GetAttackerItemData().GetWakeUpSpace() && combatComponent.GetWakeUpTime() == 0)
									{
										this.logicSpell_0 = (LogicSpell)LogicGameObjectFactory.CreateGameObject(auraSpell, this.m_level, this.m_villageType);
										this.logicSpell_0.SetUpgradeLevel(heroData.GetAuraSpellLevel(unitUpgradeLevel));
										this.logicSpell_0.SetInitialPosition(this.GetMidX(), this.GetMidY());
										this.logicSpell_0.AllowDestruction(false);
										this.logicSpell_0.SetTeam(base.GetHitpointComponent().GetTeam());
										base.GetGameObjectManager().AddGameObject(this.logicSpell_0, -1);
										return;
									}
								}
							}
						}
					}
				}
			}
			else if (this.logicSpell_0 != null)
			{
				base.GetGameObjectManager().RemoveGameObject(this.logicSpell_0);
				this.logicSpell_0 = null;
			}
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0002D5EC File Offset: 0x0002B7EC
		public void UpdateDieDamage(int damage, int radius)
		{
			if (damage > 0 && radius > 0 && base.GetHitpointComponent() != null && this.logicTimer_0 == null)
			{
				this.m_level.AreaDamage(0, this.GetMidX(), this.GetMidY(), radius, damage, null, 0, null, base.GetHitpointComponent().GetTeam(), null, 1, 0, 0, true, false, 100, 0, this, 100, 0);
			}
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x0002D648 File Offset: 0x0002B848
		public bool IsMaxUpgradeLevel()
		{
			LogicBuildingData buildingData = this.GetBuildingData();
			if (buildingData.IsTownHallVillage2())
			{
				return this.int_6 >= this.m_level.GetGameMode().GetConfiguration().GetMaxTownHallLevel() - 1;
			}
			return (buildingData.GetVillageType() == 1 && this.GetRequiredTownHallLevelForUpgrade() >= this.m_level.GetGameMode().GetConfiguration().GetMaxTownHallLevel()) || this.int_6 >= buildingData.GetUpgradeLevelCount() - 1;
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x000095D7 File Offset: 0x000077D7
		public int GetRequiredTownHallLevelForUpgrade()
		{
			return this.GetBuildingData().GetRequiredTownHallLevel(LogicMath.Min(this.int_6 + 1, this.GetBuildingData().GetUpgradeLevelCount() - 1));
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0002D6C4 File Offset: 0x0002B8C4
		public int GetBoostMultiplier()
		{
			if (base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION) != null)
			{
				return LogicDataTables.GetGlobals().GetResourceProductionBoostMultiplier();
			}
			if (base.GetComponent(LogicComponentType.UNIT_PRODUCTION) == null)
			{
				if (base.GetComponent(LogicComponentType.HERO_BASE) != null)
				{
					return LogicDataTables.GetGlobals().GetHeroRestBoostMultiplier();
				}
				if (this.GetBuildingData().IsClockTower())
				{
					return LogicDataTables.GetGlobals().GetClockTowerBoostMultiplier();
				}
			}
			else
			{
				LogicUnitProductionComponent logicUnitProductionComponent = (LogicUnitProductionComponent)base.GetComponent(LogicComponentType.UNIT_PRODUCTION);
				if (logicUnitProductionComponent.GetProductionType() == LogicCombatItemType.SPELL)
				{
					LogicDataTables.GetGlobals().UseNewTraining();
					return LogicDataTables.GetGlobals().GetSpellFactoryBoostMultiplier();
				}
				if (logicUnitProductionComponent.GetProductionType() == LogicCombatItemType.CHARACTER)
				{
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						return LogicDataTables.GetGlobals().GetBarracksBoostNewMultiplier();
					}
					return LogicDataTables.GetGlobals().GetBarracksBoostMultiplier();
				}
			}
			return 1;
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x0002D774 File Offset: 0x0002B974
		public bool CanUnlock(bool canCallListener)
		{
			if (this.logicTimer_0 == null && this.int_6 == 0 && this.bool_1)
			{
				bool flag = this.m_level.GetTownHallLevel(this.m_level.GetVillageType()) >= this.GetBuildingData().GetRequiredTownHallLevel(0);
				if (!flag)
				{
					this.m_level.GetGameListener().TownHallLevelTooLow(this.GetRequiredTownHallLevelForUpgrade());
				}
				return flag;
			}
			return false;
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0002D7DC File Offset: 0x0002B9DC
		public bool CanUpgrade(bool canCallListener)
		{
			if (this.logicTimer_0 == null && !this.IsMaxUpgradeLevel())
			{
				if (this.m_level.GetTownHallLevel(this.m_villageType) >= this.GetRequiredTownHallLevelForUpgrade())
				{
					return true;
				}
				if (canCallListener)
				{
					this.m_level.GetGameListener().TownHallLevelTooLow(this.GetRequiredTownHallLevelForUpgrade());
				}
			}
			return false;
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x00002467 File Offset: 0x00000667
		public bool CanSell()
		{
			return false;
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0002D830 File Offset: 0x0002BA30
		public bool CanBeBoosted()
		{
			if (this.logicTimer_1 != null && this.logicTimer_1.GetRemainingSeconds(this.m_level.GetLogicTime()) > 0)
			{
				return false;
			}
			if (this.m_data.GetVillageType() == 1)
			{
				if (this.GetBuildingData().IsClockTower())
				{
					return true;
				}
			}
			else if (this.logicTimer_2 == null && this.GetMaxBoostTime() > 0)
			{
				return this.m_level.GetGameMode().GetCalendar().GetBuildingBoostCost(this.GetBuildingData(), this.int_6) > 0 || this.GetBuildingData().IsFreeBoost();
			}
			return false;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x000095FE File Offset: 0x000077FE
		public bool CanStopBoost()
		{
			return base.GetComponent(LogicComponentType.UNIT_PRODUCTION) != null || base.GetComponent(LogicComponentType.HERO_BASE) != null || this.GetBuildingData().IsClockTower();
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00009620 File Offset: 0x00007820
		public int GetBoostCost()
		{
			return this.m_level.GetGameMode().GetCalendar().GetBuildingBoostCost(this.GetBuildingData(), this.int_6);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00009643 File Offset: 0x00007843
		public LogicResourceData GetSellResource()
		{
			return this.GetBuildingData().GetBuildResource(this.int_6);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00009656 File Offset: 0x00007856
		public int GetSelectedWallTime()
		{
			return this.int_10;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0002D8C4 File Offset: 0x0002BAC4
		public void StartSelectedWallTime()
		{
			int selectedWallTime = LogicDataTables.GetGlobals().GetSelectedWallTime();
			if (selectedWallTime > 0 && this.IsWall())
			{
				if (this.int_10 == 0)
				{
					this.int_10 = selectedWallTime;
					base.RefreshPassable();
					this.m_level.GetTileMap().GetPathFinder().InvalidateCache();
				}
				this.int_10 = selectedWallTime;
			}
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0000965E File Offset: 0x0000785E
		public int GetHitWallDelay()
		{
			return this.int_11;
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x00009666 File Offset: 0x00007866
		public void SetHitWallDelay(int time)
		{
			if (time > 0 && this.IsWall())
			{
				if (this.int_11 == 0)
				{
					this.int_11 = time;
					base.RefreshPassable();
				}
				this.int_11 = time;
			}
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0002D91C File Offset: 0x0002BB1C
		public void OnSell()
		{
			LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
			if (homeOwnerAvatar.IsClientAvatar())
			{
				if (base.GetComponent(LogicComponentType.RESOURCE_STORAGE) != null)
				{
					base.EnableComponent(LogicComponentType.RESOURCE_STORAGE, false);
					this.m_level.RefreshResourceCaps();
				}
				if (base.GetComponent(LogicComponentType.UNIT_STORAGE) != null)
				{
					LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)base.GetComponent(LogicComponentType.UNIT_STORAGE);
					for (int i = 0; i < logicUnitStorageComponent.GetUnitTypeCount(); i++)
					{
						homeOwnerAvatar.CommodityCountChangeHelper(0, logicUnitStorageComponent.GetUnitType(i), -logicUnitStorageComponent.GetUnitCount(i));
					}
				}
			}
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0002D998 File Offset: 0x0002BB98
		public int GetSellPrice()
		{
			if (this.logicTimer_0 == null)
			{
				return this.GetBuildingData().GetBuildCost(this.int_6, this.m_level) / 5;
			}
			if (!this.bool_4)
			{
				return this.GetBuildingData().GetBuildCost(this.int_6, this.m_level);
			}
			return this.GetBuildingData().GetBuildCost(this.int_6 + 1, this.m_level) + this.GetBuildingData().GetBuildCost(this.int_6, this.m_level) / 5;
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0002DA1C File Offset: 0x0002BC1C
		public bool SpeedUpConstruction()
		{
			if (this.logicTimer_0 != null)
			{
				LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
				int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime()), 0, this.m_villageType);
				if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_level))
				{
					playerAvatar.UseDiamonds(speedUpCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(0, this.m_data.GetGlobalID(), this.int_6 + (this.bool_5 ? 2 : 1), speedUpCost, this.m_level.GetVillageType());
					this.FinishConstruction(false, true);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0002DABC File Offset: 0x0002BCBC
		public bool SpeedUpBoostCooldown()
		{
			if (this.logicTimer_1 != null)
			{
				int remainingSeconds = this.logicTimer_1.GetRemainingSeconds(this.m_level.GetLogicTime());
				if (remainingSeconds > 0)
				{
					LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
					int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(remainingSeconds, this.GetBuildingData().IsClockTower() ? 6 : 5, this.m_villageType);
					if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, this.m_level))
					{
						playerAvatar.UseDiamonds(speedUpCost);
						playerAvatar.GetChangeListener().DiamondPurchaseMade(17, this.m_data.GetGlobalID(), this.int_6, speedUpCost, this.m_level.GetVillageType());
						this.logicTimer_1.Destruct();
						this.logicTimer_1 = null;
						this.Boost();
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x0002DB78 File Offset: 0x0002BD78
		public void StartConstructing(bool updateListener)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			int constructionTime = this.GetBuildingData().GetConstructionTime(this.int_6, this.m_level, 1);
			if (constructionTime <= 0)
			{
				this.FinishConstruction(updateListener, updateListener);
			}
			else
			{
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(constructionTime, this.m_level.GetLogicTime(), true, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				this.m_level.GetWorkerManagerAt(this.GetBuildingData().GetVillageType()).AllocateWorker(this);
			}
			if (this.m_villageType == 1)
			{
			}
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0002DC20 File Offset: 0x0002BE20
		public void DestructBoost()
		{
			if (this.logicTimer_2 != null)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
				if (this.GetBuildingData().IsClockTower())
				{
					this.logicTimer_1 = new LogicTimer();
					this.logicTimer_1.StartTimer(LogicDataTables.GetGlobals().GetClockTowerBoostCooldownSecs(), this.m_level.GetLogicTime(), false, -1);
				}
			}
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0002DC84 File Offset: 0x0002BE84
		public void StartUpgrading(bool updateListener, bool gearup)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.DestructBoost();
			int num;
			if (gearup)
			{
				num = this.GetBuildingData().GetGearUpTime(this.int_6);
				this.bool_4 = true;
			}
			else
			{
				num = this.GetBuildingData().GetConstructionTime(this.int_6 + 1, this.m_level, 0);
				this.bool_5 = true;
			}
			if (num <= 0)
			{
				this.FinishConstruction(false, updateListener);
				return;
			}
			this.m_level.GetWorkerManagerAt(this.bool_4 ? 1 : this.GetBuildingData().GetVillageType()).AllocateWorker(this);
			if (base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION) != null)
			{
				base.GetResourceProductionComponent().CollectResources(false);
			}
			base.EnableComponent(LogicComponentType.RESOURCE_PRODUCTION, false);
			base.EnableComponent(LogicComponentType.UNIT_PRODUCTION, false);
			base.EnableComponent(LogicComponentType.UNIT_UPGRADE, false);
			this.logicTimer_0 = new LogicTimer();
			this.logicTimer_0.StartTimer(num, this.m_level.GetLogicTime(), true, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0002DD88 File Offset: 0x0002BF88
		public void FinishConstruction(bool ignoreState, bool updateListener)
		{
			int state = this.m_level.GetState();
			if (state == 1 || (!LogicDataTables.GetGlobals().CompleteConstructionOnlyHome() && ignoreState))
			{
				if (this.m_level.GetHomeOwnerAvatar() != null && this.m_level.GetHomeOwnerAvatar().IsClientAvatar())
				{
					LogicClientAvatar logicClientAvatar = (LogicClientAvatar)this.m_level.GetHomeOwnerAvatar();
					if (this.logicTimer_0 != null)
					{
						this.logicTimer_0.Destruct();
						this.logicTimer_0 = null;
					}
					this.m_level.GetWorkerManagerAt(this.bool_4 ? 1 : this.GetBuildingData().GetVillageType()).DeallocateWorker(this);
					this.bool_1 = false;
					if (this.bool_4)
					{
						this.int_5++;
						LogicCombatComponent combatComponent = base.GetCombatComponent(false);
						if (combatComponent != null)
						{
							combatComponent.ToggleAttackMode(this.m_level.GetActiveLayout(), false);
						}
					}
					else if (this.int_6 == 0 && !this.bool_5)
					{
						int xp = LogicGamePlayUtil.TimeToExp(this.GetBuildingData().GetConstructionTime(0, this.m_level, 0));
						this.SetUpgradeLevel(this.int_6);
						base.XpGainHelper(xp, logicClientAvatar, ignoreState);
						LogicCombatComponent combatComponent2 = base.GetCombatComponent();
						if (combatComponent2 != null && combatComponent2.UseAmmo())
						{
							combatComponent2.LoadAmmo();
						}
						if (base.GetComponent(LogicComponentType.HERO_BASE) != null)
						{
							LogicHeroData heroData = this.GetBuildingData().GetHeroData();
							if (heroData != null)
							{
								int count = heroData.HasNoDefence() ? 2 : 3;
								logicClientAvatar.SetHeroState(heroData, count);
								logicClientAvatar.GetChangeListener().CommodityCountChanged(2, heroData, count);
							}
							else
							{
								Debugger.Warning("No hero data in herobase/altar building");
							}
						}
					}
					else
					{
						int num = this.int_6 + 1;
						if (this.int_6 >= this.GetBuildingData().GetUpgradeLevelCount() - 1)
						{
							Debugger.Warning("LogicBuilding - Trying to upgrade to level that doesn't exist! - " + this.GetBuildingData().GetName());
							num = this.GetBuildingData().GetUpgradeLevelCount() - 1;
						}
						int xp2 = LogicGamePlayUtil.TimeToExp(this.GetBuildingData().GetConstructionTime(num, this.m_level, 0));
						this.SetUpgradeLevel(num);
						base.XpGainHelper(xp2, logicClientAvatar, ignoreState);
					}
					if (base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION) != null)
					{
						((LogicResourceProductionComponent)base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION)).RestartTimer();
					}
					this.bool_5 = false;
					this.bool_4 = false;
					if (this.m_listener != null)
					{
						this.m_listener.RefreshState();
					}
					if (state == 1)
					{
						this.m_level.GetAchievementManager().RefreshStatus();
					}
					LogicBuildingClassData buildingClass = this.GetBuildingData().GetBuildingClass();
					if (buildingClass.IsTownHall() || buildingClass.IsTownHall2())
					{
						this.m_level.RefreshNewShopUnlocksTH(this.m_data.GetVillageType());
						if (buildingClass.IsTownHall2())
						{
							this.m_level.GetGameObjectManagerAt(1).Village2TownHallFixed();
						}
					}
					return;
				}
				Debugger.Warning("LogicBuilding::finishCostruction failed - Avatar is null or not client avatar");
			}
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0002E048 File Offset: 0x0002C248
		public void CancelConstruction()
		{
			LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null && homeOwnerAvatar.IsClientAvatar() && this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
				int num = this.int_6;
				if (this.bool_5)
				{
					this.SetUpgradeLevel(this.int_6);
					num++;
				}
				LogicBuildingData buildingData = this.GetBuildingData();
				LogicResourceData data = buildingData.GetBuildResource(num);
				int num2 = buildingData.GetBuildCost(num, this.m_level);
				if (this.bool_4)
				{
					data = buildingData.GetGearUpResource();
					num2 = buildingData.GetGearUpCost(this.int_6);
				}
				homeOwnerAvatar.CommodityCountChangeHelper(0, data, LogicMath.Max(LogicDataTables.GetGlobals().GetBuildCancelMultiplier() * num2 / 100, 0));
				if (this.bool_4)
				{
					this.m_level.GetWorkerManagerAt(1).DeallocateWorker(this);
				}
				else
				{
					this.m_level.GetWorkerManagerAt(this.m_data.GetVillageType()).DeallocateWorker(this);
					if (num == 0)
					{
						base.GetGameObjectManager().RemoveGameObject(this);
						return;
					}
				}
				if (this.m_listener != null)
				{
					this.m_listener.RefreshState();
				}
			}
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x00009690 File Offset: 0x00007890
		public void SetWallObjectId(int wallIdx, int wallBlockX, bool wallPoint)
		{
			if (!this.IsWall())
			{
				Debugger.Error("setWallObjectId called for non Wall");
			}
			this.int_7 = wallIdx;
			this.bool_0 = wallPoint;
			this.int_8 = wallBlockX;
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x0002E164 File Offset: 0x0002C364
		public void Boost()
		{
			if (this.logicTimer_2 != null)
			{
				this.logicTimer_2.Destruct();
				this.logicTimer_2 = null;
			}
			this.logicTimer_2 = new LogicTimer();
			this.logicTimer_2.StartTimer(this.GetMaxBoostTime(), this.m_level.GetLogicTime(), false, -1);
			if (this.GetBuildingData().IsClockTower())
			{
				this.m_level.GetGameListener();
			}
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x0002E1D0 File Offset: 0x0002C3D0
		public void SetUpgradeLevel(int level)
		{
			LogicBuildingData logicBuildingData = (LogicBuildingData)this.m_data;
			this.int_6 = LogicMath.Clamp(level, 0, logicBuildingData.GetUpgradeLevelCount() - 1);
			if (this.m_level.GetHomeOwnerAvatar() != null)
			{
				if (logicBuildingData.IsAllianceCastle() && !this.bool_1)
				{
					this.m_level.GetHomeOwnerAvatar().GetChangeListener().SetAllianceCastleLevel(this.int_6);
					this.m_level.GetHomeOwnerAvatar().SetAllianceCastleLevel(this.int_6);
					LogicBuilding allianceCastle = this.m_level.GetGameObjectManagerAt(0).GetAllianceCastle();
					if (allianceCastle != null)
					{
						allianceCastle.SetTreasurySize();
					}
				}
				else if (logicBuildingData.IsTownHall())
				{
					this.m_level.GetHomeOwnerAvatar().GetChangeListener().SetTownHallLevel(this.int_6);
					this.m_level.GetHomeOwnerAvatar().SetTownHallLevel(this.int_6);
					LogicBuilding allianceCastle2 = this.m_level.GetGameObjectManagerAt(0).GetAllianceCastle();
					if (allianceCastle2 != null)
					{
						allianceCastle2.SetTreasurySize();
					}
				}
				else if (logicBuildingData.IsTownHallVillage2())
				{
					this.m_level.GetHomeOwnerAvatar().GetChangeListener().SetVillage2TownHallLevel(this.int_6);
					this.m_level.GetHomeOwnerAvatar().SetVillage2TownHallLevel(this.int_6);
				}
				else if (logicBuildingData.IsBarrackVillage2())
				{
					this.m_level.GetHomeOwnerAvatar().SetVillage2BarrackLevel(this.int_6);
				}
			}
			if (this.int_6 != 0 || this.bool_5 || this.logicTimer_0 == null)
			{
				bool enable = this.logicTimer_0 == null;
				base.EnableComponent(LogicComponentType.UNIT_PRODUCTION, enable);
				base.EnableComponent(LogicComponentType.UNIT_UPGRADE, enable);
				base.EnableComponent(LogicComponentType.COMBAT, enable);
				base.EnableComponent(LogicComponentType.VILLAGE2_UNIT, enable);
				base.EnableComponent(LogicComponentType.RESOURCE_PRODUCTION, enable);
				LogicUnitStorageComponent unitStorageComponent = this.GetUnitStorageComponent();
				if (unitStorageComponent != null)
				{
					unitStorageComponent.SetMaxCapacity(logicBuildingData.GetUnitStorageCapacity(this.int_6));
				}
				LogicBunkerComponent bunkerComponent = base.GetBunkerComponent();
				if (bunkerComponent != null)
				{
					bunkerComponent.SetMaxCapacity(logicBuildingData.GetUnitStorageCapacity(this.int_6));
				}
				LogicDefenceUnitProductionComponent defenceUnitProduction = base.GetDefenceUnitProduction();
				if (defenceUnitProduction != null)
				{
					defenceUnitProduction.SetDefenceTroops(logicBuildingData.GetDefenceTroopCharacter(this.int_6), logicBuildingData.GetDefenceTroopCharacter2(this.int_6), logicBuildingData.GetDefenceTroopCount(this.int_6), logicBuildingData.GetDefenceTroopLevel(this.int_6), 1);
				}
				LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					if (this.bool_1)
					{
						hitpointComponent.SetMaxHitpoints(0);
						hitpointComponent.SetHitpoints(0);
						hitpointComponent.SetMaxRegenerationTime(100);
					}
					else
					{
						hitpointComponent.SetMaxHitpoints(logicBuildingData.GetHitpoints(this.int_6));
						hitpointComponent.SetHitpoints(logicBuildingData.GetHitpoints(this.int_6));
						hitpointComponent.SetMaxRegenerationTime(logicBuildingData.GetRegenerationTime(this.int_6));
					}
				}
				LogicCombatComponent combatComponent = base.GetCombatComponent();
				LogicAttackerItemData attackerItemData = logicBuildingData.GetAttackerItemData(this.int_6);
				if (logicBuildingData.GetHeroData() != null && logicBuildingData.GetShareHeroCombatData())
				{
					this.logicAttackerItemData_0 = logicBuildingData.GetHeroData().GetAttackerItemData(0).Clone();
					this.logicAttackerItemData_0.AddAttackRange(logicBuildingData.GetWidth() * 72704 / 200);
					attackerItemData = this.logicAttackerItemData_0;
				}
				if (combatComponent != null)
				{
					combatComponent.SetAttackValues(attackerItemData, 100);
				}
				LogicResourceProductionComponent resourceProductionComponent = base.GetResourceProductionComponent();
				if (resourceProductionComponent != null)
				{
					resourceProductionComponent.SetProduction(logicBuildingData.GetResourcePer100Hours(this.int_6), logicBuildingData.GetResourceMax(this.int_6));
				}
				LogicResourceStorageComponent resourceStorageComponentComponent = this.GetResourceStorageComponentComponent();
				if (resourceStorageComponentComponent != null)
				{
					resourceStorageComponentComponent.SetMaxArray(logicBuildingData.GetMaxStoredResourceCounts(this.int_6));
					resourceStorageComponentComponent.SetMaxPercentageArray(logicBuildingData.GetMaxPercentageStoredResourceCounts(this.int_6));
				}
				this.SetTreasurySize();
			}
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x0002E530 File Offset: 0x0002C730
		public void SetTreasurySize()
		{
			LogicBuildingData buildingData = this.GetBuildingData();
			LogicWarResourceStorageComponent warResourceStorageComponent = this.GetWarResourceStorageComponent();
			if (buildingData.IsAllianceCastle() && LogicDataTables.GetGlobals().TreasurySizeBasedOnTownHall())
			{
				LogicTownhallLevelData townHallLevel = LogicDataTables.GetTownHallLevel(this.m_level.GetTownHallLevel(0));
				if (townHallLevel != null)
				{
					warResourceStorageComponent.SetMaxArray(townHallLevel.GetTreasuryCaps());
					return;
				}
			}
			if (warResourceStorageComponent != null)
			{
				warResourceStorageComponent.SetMaxArray(buildingData.GetMaxStoredResourceCounts(this.int_6));
			}
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x0002E598 File Offset: 0x0002C798
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (LogicDataTables.GetGlobals().ClampBuildingTimes() && this.logicTimer_0 != null)
			{
				LogicBuildingData buildingData = this.GetBuildingData();
				int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_level.GetLogicTime());
				int num = 0;
				if (this.bool_4)
				{
					num = buildingData.GetGearUpTime(this.int_6);
				}
				else
				{
					int num2 = this.bool_5 ? this.int_6 : -1;
					if (num2 < buildingData.GetUpgradeLevelCount() - 1)
					{
						num = buildingData.GetConstructionTime(num2 + 1, this.m_level, 0);
					}
				}
				if (remainingSeconds > num)
				{
					this.logicTimer_0.StartTimer(num, this.m_level.GetLogicTime(), true, this.m_level.GetHomeOwnerAvatarChangeListener().GetCurrentTimestamp());
				}
			}
			LogicAvatar homeOwnerAvatar = this.m_level.GetHomeOwnerAvatar();
			if (homeOwnerAvatar != null)
			{
				LogicBuildingData buildingData2 = this.GetBuildingData();
				if (buildingData2.IsAllianceCastle() && !this.bool_1)
				{
					if (homeOwnerAvatar.GetAllianceCastleLevel() != this.int_6)
					{
						this.m_level.GetHomeOwnerAvatar().GetChangeListener().SetAllianceCastleLevel(this.int_6);
						this.m_level.GetHomeOwnerAvatar().SetAllianceCastleLevel(this.int_6);
						LogicBuilding allianceCastle = this.m_level.GetGameObjectManagerAt(0).GetAllianceCastle();
						if (allianceCastle != null)
						{
							allianceCastle.SetTreasurySize();
						}
					}
				}
				else if (buildingData2.IsTownHall())
				{
					if (homeOwnerAvatar.GetTownHallLevel() != this.int_6)
					{
						this.m_level.GetHomeOwnerAvatar().GetChangeListener().SetTownHallLevel(this.int_6);
						this.m_level.GetHomeOwnerAvatar().SetTownHallLevel(this.int_6);
						LogicBuilding allianceCastle2 = this.m_level.GetGameObjectManagerAt(0).GetAllianceCastle();
						if (allianceCastle2 != null)
						{
							allianceCastle2.SetTreasurySize();
						}
					}
				}
				else if (buildingData2.IsTownHallVillage2() && homeOwnerAvatar.GetVillage2TownHallLevel() != this.int_6)
				{
					this.m_level.GetHomeOwnerAvatar().GetChangeListener().SetVillage2TownHallLevel(this.int_6);
					this.m_level.GetHomeOwnerAvatar().SetVillage2TownHallLevel(this.int_6);
				}
			}
			LogicCombatComponent combatComponent = base.GetCombatComponent();
			if (combatComponent != null)
			{
				if (combatComponent.GetAttackerItemData().GetTargetingConeAngle() <= 0)
				{
					LogicBuilding townHall = base.GetGameObjectManager().GetTownHall();
					if (townHall != null)
					{
						int x = this.GetMidX() - townHall.GetMidX();
						int y = this.GetMidY() - townHall.GetMidY();
						this.int_9 = 1000 * LogicMath.GetAngle(x, y);
					}
				}
				else
				{
					this.int_9 = 1000 * combatComponent.GetAimAngle(this.m_level.GetActiveLayout(this.m_level.GetVillageType()), false);
				}
				LogicBuildingData buildingData3 = this.GetBuildingData();
				LogicAttackerItemData attackerItemData = buildingData3.GetAttackerItemData(this.int_6);
				LogicHeroData heroData = buildingData3.GetHeroData();
				if (heroData != null && buildingData3.GetShareHeroCombatData())
				{
					int unitUpgradeLevel = homeOwnerAvatar.GetUnitUpgradeLevel(heroData);
					this.logicAttackerItemData_0 = heroData.GetAttackerItemData(unitUpgradeLevel).Clone();
					this.logicAttackerItemData_0.AddAttackRange(buildingData3.GetWidth() * 72704 / 200);
					attackerItemData = this.logicAttackerItemData_0;
					if (homeOwnerAvatar.IsHeroAvailableForDefense(heroData))
					{
						if (!this.bool_1 && this.m_level.IsInCombatState())
						{
							LogicHitpointComponent hitpointComponent = base.GetHitpointComponent();
							hitpointComponent.SetMaxHitpoints(heroData.GetHitpoints(unitUpgradeLevel));
							hitpointComponent.SetHitpoints(heroData.GetHitpoints(unitUpgradeLevel));
							hitpointComponent.SetMaxRegenerationTime(buildingData3.GetRegenerationTime(this.int_6));
						}
					}
					else
					{
						combatComponent.SetEnabled(false);
					}
				}
				combatComponent.SetAttackValues(attackerItemData, 100);
			}
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x0002E908 File Offset: 0x0002CB08
		public override void GetChecksum(ChecksumHelper checksum, bool includeGameObjects)
		{
			checksum.StartObject("LogicBuilding");
			base.GetChecksum(checksum, includeGameObjects);
			if (base.GetComponent(LogicComponentType.RESOURCE_STORAGE) != null)
			{
				base.GetComponent(LogicComponentType.RESOURCE_STORAGE).GetChecksum(checksum);
			}
			if (base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION) != null)
			{
				base.GetComponent(LogicComponentType.RESOURCE_PRODUCTION).GetChecksum(checksum);
			}
			checksum.EndObject();
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x000096B9 File Offset: 0x000078B9
		public override int GetDirection()
		{
			return this.int_9 / 1000;
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x000096C7 File Offset: 0x000078C7
		public override bool IsHidden()
		{
			return this.bool_2;
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x0002E95C File Offset: 0x0002CB5C
		public void Trigger()
		{
			this.bool_2 = false;
			if (base.GetCombatComponent() != null && !this.bool_2)
			{
				int attackRange = base.GetCombatComponent().GetAttackRange(0, false);
				LogicGameObjectManager gameObjectManager = base.GetGameObjectManager();
				LogicVector2 logicVector = new LogicVector2(this.GetMidX(), this.GetMidY());
				LogicArrayList<LogicGameObject> gameObjects = gameObjectManager.GetGameObjects(LogicGameObjectType.CHARACTER);
				for (int i = 0; i < gameObjects.Size(); i++)
				{
					LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
					LogicCombatComponent combatComponent = logicCharacter.GetCombatComponent();
					int distanceSquared = logicVector.GetDistanceSquared(logicCharacter.GetPosition());
					if (combatComponent != null && (distanceSquared < attackRange * attackRange || LogicCombatComponent.IsPreferredTarget(combatComponent.GetPreferredTarget(), this)))
					{
						LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
						if (hitpointComponent != null && hitpointComponent.GetTeam() == 0)
						{
							combatComponent.ForceNewTarget();
						}
					}
				}
				logicVector.Destruct();
			}
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x00002467 File Offset: 0x00000667
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.BUILDING;
		}

		// Token: 0x04000503 RID: 1283
		private int int_5;

		// Token: 0x04000504 RID: 1284
		private int int_6;

		// Token: 0x04000505 RID: 1285
		private int int_7;

		// Token: 0x04000506 RID: 1286
		private int int_8;

		// Token: 0x04000507 RID: 1287
		private int int_9;

		// Token: 0x04000508 RID: 1288
		private int int_10;

		// Token: 0x04000509 RID: 1289
		private int int_11;

		// Token: 0x0400050A RID: 1290
		private int int_12;

		// Token: 0x0400050B RID: 1291
		private bool bool_0;

		// Token: 0x0400050C RID: 1292
		private bool bool_1;

		// Token: 0x0400050D RID: 1293
		private bool bool_2;

		// Token: 0x0400050E RID: 1294
		private bool bool_3;

		// Token: 0x0400050F RID: 1295
		private bool bool_4;

		// Token: 0x04000510 RID: 1296
		private bool bool_5;

		// Token: 0x04000511 RID: 1297
		private bool bool_6;

		// Token: 0x04000512 RID: 1298
		private LogicTimer logicTimer_0;

		// Token: 0x04000513 RID: 1299
		private LogicTimer logicTimer_1;

		// Token: 0x04000514 RID: 1300
		private LogicTimer logicTimer_2;

		// Token: 0x04000515 RID: 1301
		private LogicAttackerItemData logicAttackerItemData_0;

		// Token: 0x04000516 RID: 1302
		private LogicSpell logicSpell_0;

		// Token: 0x04000517 RID: 1303
		private LogicSpell logicSpell_1;

		// Token: 0x04000518 RID: 1304
		private LogicGameObjectFilter logicGameObjectFilter_0;
	}
}
