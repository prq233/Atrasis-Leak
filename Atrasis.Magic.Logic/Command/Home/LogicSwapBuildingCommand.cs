using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D3 RID: 467
	public sealed class LogicSwapBuildingCommand : LogicCommand
	{
		// Token: 0x06001867 RID: 6247 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSwapBuildingCommand()
		{
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x000101C3 File Offset: 0x0000E3C3
		public LogicSwapBuildingCommand(int gameObject1, int gameObject2)
		{
			this.int_1 = gameObject1;
			this.int_2 = gameObject2;
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x000101D9 File Offset: 0x0000E3D9
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x000101FA File Offset: 0x0000E3FA
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x0001021B File Offset: 0x0000E41B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SWAP_BUILDING;
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x0005BAB8 File Offset: 0x00059CB8
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseSwapBuildings())
			{
				return -99;
			}
			if (this.int_1 == this.int_2)
			{
				return -98;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.int_2);
			if (gameObjectByID == null)
			{
				return -1;
			}
			if (gameObjectByID2 == null)
			{
				return -2;
			}
			LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
			if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP)
			{
				if (gameObjectType != LogicGameObjectType.DECO)
				{
					return -3;
				}
			}
			LogicGameObjectType gameObjectType2 = gameObjectByID2.GetGameObjectType();
			if (gameObjectType2 != LogicGameObjectType.BUILDING && gameObjectType2 != LogicGameObjectType.TRAP)
			{
				if (gameObjectType2 != LogicGameObjectType.DECO)
				{
					return -4;
				}
			}
			int widthInTiles = gameObjectByID.GetWidthInTiles();
			int widthInTiles2 = gameObjectByID2.GetWidthInTiles();
			int heightInTiles = gameObjectByID.GetHeightInTiles();
			int heightInTiles2 = gameObjectByID2.GetHeightInTiles();
			if (widthInTiles == widthInTiles2 && heightInTiles == heightInTiles2)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.IsLocked())
					{
						return -6;
					}
					if (logicBuilding.IsWall())
					{
						return -7;
					}
				}
				if (gameObjectByID2.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByID2;
					if (logicBuilding2.IsLocked())
					{
						return -8;
					}
					if (logicBuilding2.IsWall())
					{
						return -9;
					}
				}
				int x = gameObjectByID.GetX();
				int y = gameObjectByID.GetY();
				int x2 = gameObjectByID2.GetX();
				int y2 = gameObjectByID2.GetY();
				gameObjectByID.SetPositionXY(x2, y2);
				gameObjectByID2.SetPositionXY(x, y);
				return 0;
			}
			return -5;
		}

		// Token: 0x04000D1E RID: 3358
		private int int_1;

		// Token: 0x04000D1F RID: 3359
		private int int_2;
	}
}
