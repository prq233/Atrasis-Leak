using System;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200012B RID: 299
	public sealed class LogicTriggerComponent : LogicComponent
	{
		// Token: 0x06001038 RID: 4152 RVA: 0x0004845C File Offset: 0x0004665C
		public LogicTriggerComponent(LogicGameObject gameObject, int triggerRadius, bool airTrigger, bool groundTrigger, bool healerTrigger, int minTriggerHousingLimit) : base(gameObject)
		{
			this.int_0 = triggerRadius;
			this.bool_0 = airTrigger;
			this.bool_1 = groundTrigger;
			this.bool_2 = healerTrigger;
			this.int_1 = minTriggerHousingLimit;
			int num = (LogicMath.Min(this.m_parent.GetWidthInTiles(), this.m_parent.GetHeightInTiles()) << 9) + 1024 >> 1;
			this.bool_3 = (num < triggerRadius);
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0000AF5A File Offset: 0x0000915A
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0000A171 File Offset: 0x00008371
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.TRIGGER;
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x000484C8 File Offset: 0x000466C8
		public override void Tick()
		{
			if (this.bool_3)
			{
				LogicLevel level = this.m_parent.GetLevel();
				if (level.IsInCombatState() && !this.bool_4 && (level.GetLogicTime().GetTick() / 4 & 7) == 0)
				{
					LogicArrayList<LogicComponent> components = this.m_parent.GetComponentManager().GetComponents(LogicComponentType.MOVEMENT);
					for (int i = 0; i < components.Size(); i++)
					{
						LogicGameObject parent = components[i].GetParent();
						if (parent.GetGameObjectType() == LogicGameObjectType.CHARACTER)
						{
							LogicCharacter logicCharacter = (LogicCharacter)parent;
							LogicMovementComponent movementComponent = logicCharacter.GetMovementComponent();
							bool flag = false;
							if (movementComponent != null)
							{
								LogicMovementSystem movementSystem = movementComponent.GetMovementSystem();
								if (movementSystem != null && movementSystem.IsPushed())
								{
									flag = movementSystem.IgnorePush();
								}
							}
							if (!flag && logicCharacter.GetCharacterData().GetTriggersTraps())
							{
								this.ObjectClose(logicCharacter);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x000485A0 File Offset: 0x000467A0
		public void ObjectClose(LogicGameObject gameObject)
		{
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			if (hitpointComponent == null || hitpointComponent.GetTeam() != 1)
			{
				if (gameObject.GetGameObjectType() == LogicGameObjectType.CHARACTER && ((LogicCharacter)gameObject).GetCharacterData().GetHousingSpace() < this.int_1)
				{
					return;
				}
				LogicCombatComponent combatComponent = gameObject.GetCombatComponent();
				if ((combatComponent == null || combatComponent.GetUndergroundTime() <= 0) && (!gameObject.IsFlying() || this.bool_0) && (gameObject.IsFlying() || this.bool_1) && (this.bool_2 || combatComponent == null || !combatComponent.IsHealer()))
				{
					int num = gameObject.GetX() - this.m_parent.GetMidX();
					int num2 = gameObject.GetY() - this.m_parent.GetMidY();
					if (LogicMath.Abs(num) <= this.int_0 && LogicMath.Abs(num2) <= this.int_0 && (long)(num * num + num2 * num2) < (long)((ulong)(this.int_0 * this.int_0)))
					{
						this.method_0();
					}
				}
			}
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x00048694 File Offset: 0x00046894
		private void method_0()
		{
			if (!this.bool_4)
			{
				if (LogicDataTables.GetGlobals().UseTrapTriggerCommand())
				{
					if (!this.bool_5)
					{
						if (this.m_parent.GetLevel().GetState() != 5)
						{
							LogicTriggerComponentTriggeredCommand logicTriggerComponentTriggeredCommand = new LogicTriggerComponentTriggeredCommand(this.m_parent);
							logicTriggerComponentTriggeredCommand.SetExecuteSubTick(this.m_parent.GetLevel().GetLogicTime().GetTick() + 1);
							this.m_parent.GetLevel().GetGameMode().GetCommandManager().AddCommand(logicTriggerComponentTriggeredCommand);
						}
						this.bool_5 = true;
						return;
					}
				}
				else
				{
					this.bool_4 = true;
				}
			}
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0000AF62 File Offset: 0x00009162
		public void SetAirTrigger(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x0000AF6B File Offset: 0x0000916B
		public void SetGroundTrigger(bool value)
		{
			this.bool_1 = value;
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x0000AF74 File Offset: 0x00009174
		public bool IsTriggeredByRadius()
		{
			return this.bool_3;
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x0000AF7C File Offset: 0x0000917C
		public bool IsTriggered()
		{
			return this.bool_4;
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0000AF84 File Offset: 0x00009184
		public void SetTriggered()
		{
			this.bool_4 = true;
		}

		// Token: 0x040006B2 RID: 1714
		private bool bool_0;

		// Token: 0x040006B3 RID: 1715
		private bool bool_1;

		// Token: 0x040006B4 RID: 1716
		private readonly bool bool_2;

		// Token: 0x040006B5 RID: 1717
		private readonly int int_0;

		// Token: 0x040006B6 RID: 1718
		private readonly int int_1;

		// Token: 0x040006B7 RID: 1719
		private readonly bool bool_3;

		// Token: 0x040006B8 RID: 1720
		private bool bool_4;

		// Token: 0x040006B9 RID: 1721
		private bool bool_5;
	}
}
