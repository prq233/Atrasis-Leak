using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C2 RID: 450
	public sealed class LogicSetCurrentVillageCommand : LogicCommand
	{
		// Token: 0x060017F5 RID: 6133 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSetCurrentVillageCommand()
		{
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x0000FCD1 File Offset: 0x0000DED1
		public LogicSetCurrentVillageCommand(int villageType)
		{
			this.int_1 = villageType;
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x0000FCE0 File Offset: 0x0000DEE0
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0000FCF5 File Offset: 0x0000DEF5
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x0000FD0A File Offset: 0x0000DF0A
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_CURRENT_VILLAGE;
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x0000FD11 File Offset: 0x0000DF11
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 < 0)
			{
				return -1;
			}
			if (this.int_1 > 1)
			{
				return -2;
			}
			if (this.int_1 != level.GetVillageType())
			{
				level.GetGameObjectManagerAt(1).GetTownHall();
				return this.ChangeVillage(level, false);
			}
			return -3;
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0005B230 File Offset: 0x00059430
		public int ChangeVillage(LogicLevel level, bool force)
		{
			if (this.int_1 != 0 && !force)
			{
				LogicVillageObject shipyard = level.GetGameObjectManagerAt(0).GetShipyard();
				if (shipyard == null || shipyard.GetUpgradeLevel() <= 0)
				{
					return -23;
				}
			}
			if (level.GetGameObjectManagerAt(1).GetTownHall() != null)
			{
				level.SetVillageType(this.int_1);
				if (level.GetState() == 1)
				{
					level.GetPlayerAvatar().SetVariableByName("VillageToGoTo", this.int_1);
				}
				level.GetGameObjectManager().RespawnObstacles();
			}
			return 0;
		}

		// Token: 0x04000D07 RID: 3335
		private int int_1;
	}
}
