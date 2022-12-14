using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B4 RID: 436
	public sealed class LogicRemoveTroopVillage2Command : LogicCommand
	{
		// Token: 0x06001799 RID: 6041 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicRemoveTroopVillage2Command()
		{
		}

		// Token: 0x0600179A RID: 6042 RVA: 0x0000F8C3 File Offset: 0x0000DAC3
		public LogicRemoveTroopVillage2Command(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600179B RID: 6043 RVA: 0x0000F8D2 File Offset: 0x0000DAD2
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600179C RID: 6044 RVA: 0x0000F8E7 File Offset: 0x0000DAE7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600179D RID: 6045 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REMOVE_TROOP_VILLAGE_2;
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x0000F903 File Offset: 0x0000DB03
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x00059F90 File Offset: 0x00058190
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicVillage2UnitComponent village2UnitComponent = ((LogicBuilding)gameObjectByID).GetVillage2UnitComponent();
				if (village2UnitComponent != null)
				{
					level.GetPlayerAvatar().CommodityCountChangeHelper(7, village2UnitComponent.GetUnitData(), -village2UnitComponent.GetUnitCount());
					village2UnitComponent.RemoveUnits();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CEA RID: 3306
		private int int_1;
	}
}
