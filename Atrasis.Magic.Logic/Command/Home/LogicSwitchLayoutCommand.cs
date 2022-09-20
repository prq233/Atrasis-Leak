using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D5 RID: 469
	public class LogicSwitchLayoutCommand : LogicCommand
	{
		// Token: 0x06001873 RID: 6259 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSwitchLayoutCommand()
		{
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x000102A0 File Offset: 0x0000E4A0
		public LogicSwitchLayoutCommand(int layoutId, int layoutType)
		{
			this.int_1 = layoutId;
			this.int_2 = layoutType;
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x000102B6 File Offset: 0x0000E4B6
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			if (this.int_1 == 6 || this.int_1 == 7)
			{
				this.int_1 = -1;
			}
			base.Decode(stream);
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x000102F0 File Offset: 0x0000E4F0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x0005BD90 File Offset: 0x00059F90
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 != -1 && level.GetTownHallLevel(level.GetVillageType()) >= level.GetRequiredTownHallLevelForLayout(this.int_1, -1))
			{
				if (((long)this.int_1 & 4294967294L) != 6L)
				{
					if (this.int_2 != 0)
					{
						if (this.int_1 != 1 && this.int_1 != 4 && this.int_1 != 5)
						{
							return -5;
						}
					}
					else if (this.int_1 != 0 && this.int_1 != 2 && this.int_1 != 3)
					{
						return -4;
					}
				}
				LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
				LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
				level.GetGameObjectManager().GetGameObjects(logicArrayList, logicGameObjectFilter);
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					LogicVector2 positionLayout = logicArrayList[i].GetPositionLayout(this.int_1, false);
					if (((long)this.int_1 & 4294967294L) != 6L)
					{
						if (positionLayout.m_x != -1)
						{
							if (positionLayout.m_y != -1)
							{
								goto IL_10F;
							}
						}
						return -2;
					}
					IL_10F:;
				}
				LogicGameObjectManager gameObjectManager = level.GetGameObjectManager();
				LogicArrayList<LogicGameObject> gameObjects = gameObjectManager.GetGameObjects(LogicGameObjectType.BUILDING);
				LogicArrayList<LogicGameObject> gameObjects2 = gameObjectManager.GetGameObjects(LogicGameObjectType.OBSTACLE);
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					LogicGameObject logicGameObject = logicArrayList[j];
					LogicVector2 positionLayout2 = logicGameObject.GetPositionLayout(this.int_1, false);
					int x = positionLayout2.m_x;
					int y = positionLayout2.m_y;
					int num = x + logicGameObject.GetWidthInTiles();
					int num2 = y + logicGameObject.GetHeightInTiles();
					for (int k = 0; k < gameObjects2.Size(); k++)
					{
						LogicObstacle logicObstacle = (LogicObstacle)gameObjects2[k];
						int tileX = logicObstacle.GetTileX();
						int tileY = logicObstacle.GetTileY();
						int num3 = tileX + logicObstacle.GetWidthInTiles();
						int num4 = tileY + logicObstacle.GetHeightInTiles();
						if (num > tileX && num2 > tileY && x < num3 && y < num4)
						{
							if (((long)this.int_1 & 4294967294L) != 6L)
							{
								return -2;
							}
							gameObjectManager.RemoveGameObject(logicObstacle);
							k--;
						}
					}
				}
				for (int l = 0; l < gameObjects.Size(); l++)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjects[l];
					if (logicBuilding.GetWallIndex() != 0)
					{
						int tileX2 = logicBuilding.GetTileX();
						int tileY2 = logicBuilding.GetTileY();
						int num5 = 0;
						int num6 = 0;
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						int num10 = 0;
						int num11 = 0;
						int num12 = 0;
						int num13 = 0;
						for (int m = 0; m < gameObjects.Size(); m++)
						{
							LogicBuilding logicBuilding2 = (LogicBuilding)gameObjects[m];
							if (logicBuilding2.GetWallIndex() == logicBuilding.GetWallIndex())
							{
								int valueB = tileX2 - logicBuilding2.GetTileX();
								int valueB2 = tileY2 - logicBuilding2.GetTileY();
								num5 = LogicMath.Min(num5, valueB);
								num6 = LogicMath.Min(num6, valueB2);
								num7 = LogicMath.Max(num7, valueB);
								num8 = LogicMath.Max(num8, valueB2);
								int wallBlockX = logicBuilding2.GetBuildingData().GetWallBlockX(num13);
								int wallBlockY = logicBuilding2.GetBuildingData().GetWallBlockY(num13);
								num9 = LogicMath.Min(num9, wallBlockX);
								num10 = LogicMath.Min(num10, wallBlockY);
								num11 = LogicMath.Max(num11, wallBlockX);
								num12 = LogicMath.Max(num12, wallBlockY);
								num13++;
							}
						}
						if (logicBuilding.GetBuildingData().GetWallBlockCount() != num13)
						{
							return -24;
						}
						int num14 = num11 - num9;
						int num15 = num12 - num10;
						int num16 = num7 - num5;
						int num17 = num8 - num6;
						if ((num14 != num16 || num15 != num17) && num14 != num16 != (num15 != num17))
						{
							return -25;
						}
					}
				}
				if (this.int_2 != 0)
				{
					if (level.IsWarBase())
					{
						level.SetWarBase(true);
					}
					level.SetActiveWarLayout(this.int_1);
				}
				else
				{
					level.SetActiveLayout(this.int_1, level.GetVillageType());
					for (int n = 0; n < logicArrayList.Size(); n++)
					{
						LogicGameObject logicGameObject2 = logicArrayList[n];
						LogicVector2 positionLayout3 = logicGameObject2.GetPositionLayout(this.int_1, false);
						logicGameObject2.SetPositionXY(positionLayout3.m_x << 9, positionLayout3.m_y << 9);
					}
				}
				return 0;
			}
			return -10;
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x00010311 File Offset: 0x0000E511
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SWITCH_LAYOUT;
		}

		// Token: 0x04000D23 RID: 3363
		private int int_1;

		// Token: 0x04000D24 RID: 3364
		private int int_2;
	}
}
