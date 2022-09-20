using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000121 RID: 289
	public sealed class LogicDefenceUnitProductionComponent : LogicComponent
	{
		// Token: 0x06000F61 RID: 3937 RVA: 0x0000A771 File Offset: 0x00008971
		public LogicDefenceUnitProductionComponent(LogicGameObject gameObject) : base(gameObject)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicCharacter>();
			this.logicCharacterData_0 = new LogicCharacterData[2];
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x0004130C File Offset: 0x0003F50C
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicCharacterData_0 = null;
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x0004135C File Offset: 0x0003F55C
		public override void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
			int i = 0;
			int num = this.logicArrayList_0.Size();
			while (i < num)
			{
				if (this.logicArrayList_0[i] == gameObject)
				{
					this.logicArrayList_0.Remove(i);
					this.StartSpawnCooldownTimer();
					return;
				}
				i++;
			}
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x0000746C File Offset: 0x0000566C
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.DEFENCE_UNIT_PRODUCTION;
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x000413A8 File Offset: 0x0003F5A8
		public override void Tick()
		{
			if (this.m_parent.IsAlive())
			{
				if (LogicDataTables.GetGlobals().GuardPostNotFunctionalUnderUpgrade() && this.m_parent.GetGameObjectType() == LogicGameObjectType.BUILDING && ((LogicBuilding)this.m_parent).IsConstructing())
				{
					return;
				}
				if (this.int_3 > this.int_2 && (this.logicTimer_0 == null || this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) <= 0))
				{
					this.method_0(this.m_parent.GetX(), this.m_parent.GetY() + (this.m_parent.GetHeightInTiles() << 8));
					if (this.int_3 > this.logicArrayList_0.Size())
					{
						this.StartSpawnCooldownTimer();
					}
				}
			}
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x00041468 File Offset: 0x0003F668
		public void StartSpawnCooldownTimer()
		{
			if (this.logicTimer_0 == null)
			{
				this.logicTimer_0 = new LogicTimer();
			}
			if (this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime()) <= 0)
			{
				this.logicTimer_0.StartTimer(this.int_1, this.m_parent.GetLevel().GetLogicTime(), false, -1);
			}
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x000414CC File Offset: 0x0003F6CC
		private void method_0(int int_4, int int_5)
		{
			int num = this.int_2 % 2;
			if (this.logicCharacterData_0[num] == null)
			{
				num = 0;
			}
			LogicBuilding logicBuilding = (LogicBuilding)this.m_parent;
			if (logicBuilding.GetBuildingData().IsEnabledInVillageType(this.m_parent.GetLevel().GetVillageType()) && this.m_parent.GetLevel().GetState() != 1 && this.m_parent.GetLevel().GetState() != 4)
			{
				LogicCharacter logicCharacter = (LogicCharacter)LogicGameObjectFactory.CreateGameObject(this.logicCharacterData_0[num], this.m_parent.GetLevel(), this.m_parent.GetVillageType());
				logicCharacter.SetInitialPosition(int_4, int_5);
				logicCharacter.SetUpgradeLevel(this.int_0 - 1);
				LogicHitpointComponent hitpointComponent = logicCharacter.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					hitpointComponent.SetTeam(1);
				}
				if (LogicDataTables.GetGlobals().EnableDefendingAllianceTroopJump())
				{
					logicCharacter.GetMovementComponent().EnableJump(3600000);
				}
				this.m_parent.GetGameObjectManager().AddGameObject(logicCharacter, -1);
				logicCharacter.GetCombatComponent().SetSearchRadius(LogicDataTables.GetGlobals().GetClanCastleRadius() >> 9);
				logicCharacter.GetMovementComponent().GetMovementSystem().CreatePatrolArea(this.m_parent, this.m_parent.GetLevel(), true, this.int_2);
				LogicDefenceUnitProductionComponent defenceUnitProduction = logicBuilding.GetDefenceUnitProduction();
				if (defenceUnitProduction != null)
				{
					defenceUnitProduction.logicArrayList_0.Add(logicCharacter);
				}
				this.int_2++;
			}
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0000A791 File Offset: 0x00008991
		public void SetDefenceTroops(LogicCharacterData defenceTroopCharacter1, LogicCharacterData defenceTroopCharacter2, int defenceTroopCount, int defenceTroopLevel, int defenseTroopCooldownSecs)
		{
			this.logicCharacterData_0[0] = defenceTroopCharacter1;
			this.logicCharacterData_0[1] = defenceTroopCharacter2;
			this.int_3 = defenceTroopCount;
			this.int_0 = defenceTroopLevel;
			this.int_1 = defenseTroopCooldownSecs;
		}

		// Token: 0x04000646 RID: 1606
		private LogicTimer logicTimer_0;

		// Token: 0x04000647 RID: 1607
		private LogicArrayList<LogicCharacter> logicArrayList_0;

		// Token: 0x04000648 RID: 1608
		private LogicCharacterData[] logicCharacterData_0;

		// Token: 0x04000649 RID: 1609
		private int int_0;

		// Token: 0x0400064A RID: 1610
		private int int_1;

		// Token: 0x0400064B RID: 1611
		private int int_2;

		// Token: 0x0400064C RID: 1612
		private int int_3;
	}
}
