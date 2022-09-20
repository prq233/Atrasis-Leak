using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AC RID: 428
	public sealed class LogicMoveBuildingEditModeCommand : LogicCommand
	{
		// Token: 0x06001765 RID: 5989 RVA: 0x0000F4F7 File Offset: 0x0000D6F7
		public override void Decode(ByteStream stream)
		{
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0000F530 File Offset: 0x0000D730
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0000F569 File Offset: 0x0000D769
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_BUILDING_EDIT_MODE;
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x00059070 File Offset: 0x00057270
		public override int Execute(LogicLevel level)
		{
			if (this.int_2 == 6)
			{
				return -5;
			}
			if (this.int_2 == 7)
			{
				return -6;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null)
			{
				return -3;
			}
			LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
			if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP)
			{
				if (gameObjectType != LogicGameObjectType.DECO)
				{
					return -1;
				}
			}
			LogicRect playArea = level.GetPlayArea();
			if ((!playArea.IsInside(this.int_3, this.int_4) || !playArea.IsInside(this.int_3 + gameObjectByID.GetWidthInTiles(), this.int_4 + gameObjectByID.GetHeightInTiles())) && this.int_3 != -1)
			{
				if (this.int_4 != -1)
				{
					return -2;
				}
			}
			if (gameObjectType == LogicGameObjectType.BUILDING && ((LogicBuilding)gameObjectByID).GetWallIndex() != 0)
			{
				return -23;
			}
			gameObjectByID.SetPositionLayoutXY(this.int_3, this.int_4, this.int_2, true);
			LogicGlobals globals = LogicDataTables.GetGlobals();
			if (!globals.NoCooldownFromMoveEditModeActive() && level.GetActiveLayout(level.GetVillageType()) == this.int_2 && level.GetHomeOwnerAvatar().GetExpLevel() >= globals.GetChallengeBaseCooldownEnabledTownHall())
			{
				level.SetLayoutCooldownSecs(this.int_2, globals.GetChallengeBaseSaveCooldown());
			}
			return 0;
		}

		// Token: 0x04000CD3 RID: 3283
		private int int_1;

		// Token: 0x04000CD4 RID: 3284
		private int int_2;

		// Token: 0x04000CD5 RID: 3285
		private int int_3;

		// Token: 0x04000CD6 RID: 3286
		private int int_4;
	}
}
