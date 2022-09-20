using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BA RID: 442
	public sealed class LogicRotateBuildingCommand : LogicCommand
	{
		// Token: 0x060017BF RID: 6079 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicRotateBuildingCommand()
		{
		}

		// Token: 0x060017C0 RID: 6080 RVA: 0x0000FA8B File Offset: 0x0000DC8B
		public LogicRotateBuildingCommand(int gameObjectId, int layout, bool draftLayout, bool updateListener, int baseLayout, bool baseDraftLayout)
		{
			this.int_1 = gameObjectId;
			this.int_2 = layout;
			this.bool_0 = draftLayout;
			this.bool_2 = updateListener;
			this.int_3 = baseLayout;
			this.bool_1 = baseDraftLayout;
		}

		// Token: 0x060017C1 RID: 6081 RVA: 0x0005A7A8 File Offset: 0x000589A8
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			this.bool_2 = stream.ReadBoolean();
			this.int_3 = stream.ReadInt();
			this.bool_1 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060017C2 RID: 6082 RVA: 0x0005A804 File Offset: 0x00058A04
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(this.bool_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteBoolean(this.bool_1);
			base.Encode(encoder);
		}

		// Token: 0x060017C3 RID: 6083 RVA: 0x0000FAC0 File Offset: 0x0000DCC0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ROTATE_BUILDING;
		}

		// Token: 0x060017C4 RID: 6084 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017C5 RID: 6085 RVA: 0x0005A860 File Offset: 0x00058A60
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					LogicBuildingData buildingData = logicBuilding.GetBuildingData();
					LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent(false);
					if (combatComponent != null && combatComponent.GetAttackerItemData().GetTargetingConeAngle() != 0)
					{
						if (this.int_3 == -1)
						{
							combatComponent.ToggleAimAngle(buildingData.GetAimRotateStep(), this.int_2, this.bool_0);
						}
						else
						{
							int aimAngle = combatComponent.GetAimAngle(this.int_3, this.bool_1);
							int aimAngle2 = combatComponent.GetAimAngle(this.int_2, this.bool_0);
							combatComponent.ToggleAimAngle(aimAngle - aimAngle2, this.int_2, this.bool_0);
						}
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.GetTrapData().GetDirectionCount() > 0)
					{
						if (this.int_3 == -1)
						{
							logicTrap.ToggleDirection(this.int_2, this.bool_0);
						}
						else
						{
							logicTrap.SetDirection(this.int_2, this.bool_0, logicTrap.GetDirection(this.int_3, this.bool_1));
						}
						return 0;
					}
					return -21;
				}
			}
			return -1;
		}

		// Token: 0x04000CF5 RID: 3317
		private int int_1;

		// Token: 0x04000CF6 RID: 3318
		private int int_2;

		// Token: 0x04000CF7 RID: 3319
		private int int_3;

		// Token: 0x04000CF8 RID: 3320
		private bool bool_0;

		// Token: 0x04000CF9 RID: 3321
		private bool bool_1;

		// Token: 0x04000CFA RID: 3322
		private bool bool_2;
	}
}
