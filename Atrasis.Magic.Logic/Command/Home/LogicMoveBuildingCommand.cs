using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AB RID: 427
	public sealed class LogicMoveBuildingCommand : LogicCommand
	{
		// Token: 0x0600175E RID: 5982 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicMoveBuildingCommand()
		{
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x0000F479 File Offset: 0x0000D679
		public LogicMoveBuildingCommand(int gameObjectId, int x, int y)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.int_3 = gameObjectId;
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x0000F496 File Offset: 0x0000D696
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x0000F4C3 File Offset: 0x0000D6C3
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_BUILDING;
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x00058EFC File Offset: 0x000570FC
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_3);
			if (gameObjectByID == null)
			{
				return -2;
			}
			LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
			if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP)
			{
				if (gameObjectType != LogicGameObjectType.DECO)
				{
					return -1;
				}
			}
			if (gameObjectType == LogicGameObjectType.BUILDING)
			{
				if (((LogicBuildingData)gameObjectByID.GetData()).GetVillageType() != level.GetVillageType())
				{
					return -32;
				}
			}
			if (gameObjectType == LogicGameObjectType.BUILDING && ((LogicBuilding)gameObjectByID).GetWallIndex() != 0)
			{
				return -21;
			}
			int tileX = gameObjectByID.GetTileX();
			int tileY = gameObjectByID.GetTileY();
			int widthInTiles = gameObjectByID.GetWidthInTiles();
			int heightInTiles = gameObjectByID.GetHeightInTiles();
			for (int i = 0; i < widthInTiles; i++)
			{
				for (int j = 0; j < heightInTiles; j++)
				{
					LogicObstacle tallGrass = level.GetTileMap().GetTile(this.int_1 + i, this.int_2 + j).GetTallGrass();
					if (tallGrass != null)
					{
						level.GetGameObjectManager().RemoveGameObject(tallGrass);
					}
				}
			}
			if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, widthInTiles, heightInTiles, gameObjectByID))
			{
				gameObjectByID.SetPositionXY(this.int_1 << 9, this.int_2 << 9);
				if (this.int_1 != tileX || this.int_2 != tileY)
				{
					LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
					if (homeOwnerAvatar != null && homeOwnerAvatar.GetTownHallLevel() >= LogicDataTables.GetGlobals().GetChallengeBaseCooldownEnabledTownHall() && gameObjectByID.GetGameObjectType() != LogicGameObjectType.DECO)
					{
						level.SetLayoutCooldownSecs(level.GetActiveLayout(level.GetVillageType()), LogicDataTables.GetGlobals().GetChallengeBaseSaveCooldown());
					}
				}
				return 0;
			}
			return -3;
		}

		// Token: 0x04000CD0 RID: 3280
		private int int_1;

		// Token: 0x04000CD1 RID: 3281
		private int int_2;

		// Token: 0x04000CD2 RID: 3282
		private int int_3;
	}
}
