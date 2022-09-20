using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D6 RID: 470
	public sealed class LogicToggleAttackModeCommand : LogicCommand
	{
		// Token: 0x0600187A RID: 6266 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicToggleAttackModeCommand()
		{
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00010318 File Offset: 0x0000E518
		public LogicToggleAttackModeCommand(int gameObjectId, int layout, bool draftMode, bool updateListener)
		{
			this.int_1 = gameObjectId;
			this.int_2 = layout;
			this.bool_0 = draftMode;
			this.bool_1 = updateListener;
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x0001033D File Offset: 0x0000E53D
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			this.bool_1 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x00010376 File Offset: 0x0000E576
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteBoolean(this.bool_1);
			base.Encode(encoder);
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x000103AF File Offset: 0x0000E5AF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TOGGLE_ATTACK_MODE;
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x0005C1E4 File Offset: 0x0005A3E4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.GetBuildingData().GetGearUpBuildingData() != null && logicBuilding.GetGearLevel() == 0)
					{
						return -95;
					}
					if (logicBuilding.GetAttackerItemData().HasAlternativeAttackMode())
					{
						LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent(false);
						if (combatComponent != null)
						{
							combatComponent.ToggleAttackMode(this.int_2, this.bool_0);
							return 0;
						}
					}
					return -1;
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.HasAirMode())
					{
						logicTrap.ToggleAirMode(this.int_2, this.bool_0);
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000D25 RID: 3365
		private int int_1;

		// Token: 0x04000D26 RID: 3366
		private int int_2;

		// Token: 0x04000D27 RID: 3367
		private bool bool_0;

		// Token: 0x04000D28 RID: 3368
		private bool bool_1;
	}
}
