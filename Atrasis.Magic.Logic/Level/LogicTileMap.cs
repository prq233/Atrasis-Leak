using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Level
{
	// Token: 0x02000102 RID: 258
	public sealed class LogicTileMap
	{
		// Token: 0x06000C55 RID: 3157 RVA: 0x0002A760 File Offset: 0x00028960
		public LogicTileMap(int x, int y)
		{
			this.int_0 = x;
			this.int_1 = y;
			this.logicTile_0 = new LogicTile[x * y];
			for (int i = 0; i < this.logicTile_0.Length; i++)
			{
				this.logicTile_0[i] = new LogicTile((byte)(i % x), (byte)(i / x));
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0002A7B8 File Offset: 0x000289B8
		public void Destruct()
		{
			if (this.logicTile_0 != null)
			{
				for (int i = 0; i < this.logicTile_0.Length; i++)
				{
					if (this.logicTile_0[i] != null)
					{
						this.logicTile_0[i].Destruct();
						this.logicTile_0[i] = null;
					}
				}
				this.logicTile_0 = null;
			}
			this.int_2 = null;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x00008FA2 File Offset: 0x000071A2
		public int GetSizeX()
		{
			return this.int_0;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00008FAA File Offset: 0x000071AA
		public int GetSizeY()
		{
			return this.int_1;
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00008FB2 File Offset: 0x000071B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public LogicTile GetTile(int x, int y)
		{
			if ((long)this.int_0 > (long)((ulong)x) && (long)this.int_1 > (long)((ulong)y))
			{
				return this.logicTile_0[x + this.int_0 * y];
			}
			return null;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00008FDD File Offset: 0x000071DD
		public LogicPathFinder GetPathFinder()
		{
			if (this.logicPathFinder_0 == null)
			{
				if (LogicDataTables.GetGlobals().UseNewPathFinder())
				{
					this.logicPathFinder_0 = new LogicPathFinderNew(this);
				}
				else
				{
					this.logicPathFinder_0 = new LogicPathFinderOld(this);
				}
			}
			return this.logicPathFinder_0;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0002A810 File Offset: 0x00028A10
		public int GetPathFinderCost(int x, int y)
		{
			LogicTile tile = this.GetTile(x / 2, y / 2);
			if (tile != null)
			{
				return tile.GetPathFinderCost(x % 2, y % 2);
			}
			return int.MaxValue;
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x0002A840 File Offset: 0x00028A40
		public int GetTilePathFinderCost(int tileX, int tileY)
		{
			LogicTile tile = this.GetTile(tileX, tileY);
			if (tile != null)
			{
				return tile.GetPathFinderCost();
			}
			return int.MaxValue;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x0002A868 File Offset: 0x00028A68
		public void AddGameObject(LogicGameObject gameObject)
		{
			if (gameObject.IsStaticObject())
			{
				int tileX = gameObject.GetTileX();
				int tileY = gameObject.GetTileY();
				if (tileX >= 0 && tileY >= 0)
				{
					int widthInTiles = gameObject.GetWidthInTiles();
					int heightInTiles = gameObject.GetHeightInTiles();
					for (int i = 0; i < heightInTiles; i++)
					{
						for (int j = 0; j < widthInTiles; j++)
						{
							this.logicTile_0[tileX + j + this.int_0 * (tileY + i)].AddGameObject(gameObject);
						}
					}
					if (!gameObject.IsPassable())
					{
						this.UpdateRoomIndices();
					}
				}
			}
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x0002A8EC File Offset: 0x00028AEC
		public void GameObjectMoved(LogicGameObject gameObject, int prevTileX, int prevTileY)
		{
			if (gameObject.IsStaticObject())
			{
				int tileX = gameObject.GetTileX();
				int tileY = gameObject.GetTileY();
				if (tileX >= 0 && tileY >= 0)
				{
					int widthInTiles = gameObject.GetWidthInTiles();
					int heightInTiles = gameObject.GetHeightInTiles();
					for (int i = 0; i < heightInTiles; i++)
					{
						for (int j = 0; j < widthInTiles; j++)
						{
							this.logicTile_0[prevTileX + j + this.int_0 * (prevTileY + i)].RemoveGameObject(gameObject);
						}
					}
					for (int k = 0; k < heightInTiles; k++)
					{
						for (int l = 0; l < widthInTiles; l++)
						{
							this.logicTile_0[tileX + l + this.int_0 * (tileY + k)].AddGameObject(gameObject);
						}
					}
					if (!gameObject.IsPassable())
					{
						this.UpdateRoomIndices();
					}
				}
			}
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x0002A9B8 File Offset: 0x00028BB8
		public void RemoveGameObject(LogicGameObject gameObject)
		{
			if (gameObject.IsStaticObject())
			{
				int tileX = gameObject.GetTileX();
				int tileY = gameObject.GetTileY();
				if (tileX >= 0 && tileY >= 0)
				{
					int widthInTiles = gameObject.GetWidthInTiles();
					int heightInTiles = gameObject.GetHeightInTiles();
					for (int i = 0; i < heightInTiles; i++)
					{
						for (int j = 0; j < widthInTiles; j++)
						{
							this.logicTile_0[tileX + j + this.int_0 * (tileY + i)].RemoveGameObject(gameObject);
						}
					}
					if (!gameObject.IsPassable())
					{
						this.UpdateRoomIndices();
					}
				}
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00009013 File Offset: 0x00007213
		public void EnableRoomIndices(bool enabled)
		{
			if (enabled && !this.bool_0)
			{
				this.bool_0 = true;
				this.UpdateRoomIndices();
			}
			this.bool_0 = enabled;
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0002AA3C File Offset: 0x00028C3C
		public void RefreshPassable(LogicGameObject gameObject)
		{
			if (gameObject.IsStaticObject())
			{
				int tileX = gameObject.GetTileX();
				int tileY = gameObject.GetTileY();
				if (tileX >= 0 && tileY >= 0)
				{
					int widthInTiles = gameObject.GetWidthInTiles();
					int heightInTiles = gameObject.GetHeightInTiles();
					for (int i = 0; i < heightInTiles; i++)
					{
						for (int j = 0; j < widthInTiles; j++)
						{
							LogicTile tile = this.GetTile(tileX + j, tileY + i);
							Debugger.DoAssert(tile != null, "illegal tile index");
							tile.RefreshPassableFlag();
						}
					}
					this.UpdateRoomIndices();
				}
			}
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x0002AAC0 File Offset: 0x00028CC0
		public void UpdateRoomIndices()
		{
			if (this.bool_0)
			{
				int num = this.logicTile_0.Length;
				for (int i = 0; i < num; i++)
				{
					this.logicTile_0[i].SetRoomIdx(this.logicTile_0[i].IsFullyNotPassable() ? -1 : 0);
				}
				short num2 = 1;
				for (int j = 0; j < num; j++)
				{
					if (this.logicTile_0[j].GetRoomIdx() == 0)
					{
						int tileIndex = j;
						short num3 = num2;
						num2 = num3 + 1;
						this.FillRoom(tileIndex, num3);
					}
				}
			}
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x0002AB34 File Offset: 0x00028D34
		public void FillRoom(int tileIndex, short roomIdx)
		{
			if (this.logicTile_0[tileIndex].GetRoomIdx() == 0)
			{
				int num = 1;
				int num2 = this.int_0 * this.int_1;
				if (this.int_2 == null)
				{
					this.int_2 = new int[num2];
				}
				this.int_2[0] = tileIndex;
				for (int i = 0; i < num; i++)
				{
					int num3 = this.int_2[i];
					if (this.logicTile_0[num3].GetRoomIdx() == 0)
					{
						int num4 = num3 / this.int_0;
						int num5 = num3 % this.int_0;
						int num6 = num4 * this.int_0;
						int num7 = num3 - 1;
						int num8 = num3 + 1;
						int num9 = num5 + 1;
						while (num5-- > 0)
						{
							LogicTile logicTile = this.logicTile_0[num7--];
							if (logicTile.GetRoomIdx() != 0)
							{
								break;
							}
						}
						while (num9 < this.int_0 && this.logicTile_0[num8++].GetRoomIdx() == 0)
						{
							num9++;
						}
						if (num5 <= num9)
						{
							int num10 = num5;
							do
							{
								if (num10 >= 0 && num10 < this.int_0)
								{
									if (num10 > num5 && num10 < num9)
									{
										this.logicTile_0[num10 + num6].SetRoomIdx(roomIdx);
									}
									if (num4 > 0 && this.logicTile_0[num10 + num6 - this.int_0].GetRoomIdx() == 0)
									{
										this.int_2[num++] = num10 + num6 - this.int_0;
									}
									if (num4 < this.int_1 - 1 && this.logicTile_0[num10 + num6 + this.int_0].GetRoomIdx() == 0)
									{
										this.int_2[num++] = num10 + num6 + this.int_0;
									}
								}
							}
							while (num10++ < num9);
						}
					}
				}
				if (num > num2)
				{
					Debugger.Error("LogicTileMap::fillRoom - open nodes array overflowed.");
				}
			}
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0002AD10 File Offset: 0x00028F10
		public bool IsPassablePathFinder(int x, int y)
		{
			LogicTile tile = this.GetTile(x / 2, y / 2);
			return tile != null && tile.IsPassablePathFinder(x % 2, y % 2);
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0002AD3C File Offset: 0x00028F3C
		public bool IsValidAttackPos(int x, int y)
		{
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					LogicTile tile = this.GetTile(x + i, y + j);
					if (tile != null)
					{
						for (int k = 0; k < tile.GetGameObjectCount(); k++)
						{
							LogicGameObject gameObject = tile.GetGameObject(k);
							if (gameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && !((LogicBuilding)gameObject).GetBuildingData().IsHidden())
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0002ADAC File Offset: 0x00028FAC
		public bool GetNearestPassablePosition(int x, int y, LogicVector2 output, int radius)
		{
			int num = -1;
			int i = x - radius >> 8;
			int num2 = x + radius >> 8;
			while (i <= num2)
			{
				int j = y - radius >> 8;
				int num3 = y + radius >> 8;
				int num4 = i << 8;
				int num5 = j << 8;
				int value = x - num4;
				int num6 = y - num5;
				while (j <= num3)
				{
					if (this.IsPassablePathFinder(i, j))
					{
						int num7 = LogicMath.Max(LogicMath.Abs(value), LogicMath.Abs(num6));
						if (num < 0 || num7 < num)
						{
							num = num7;
							output.m_x = num4;
							output.m_y = num5;
						}
					}
					num5 += 256;
					num6 -= 256;
					j++;
				}
				i++;
			}
			return num > -1;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0002AE5C File Offset: 0x0002905C
		public bool GetWallInPassableLine(int startX, int startY, int endX, int endY, LogicVector2 output)
		{
			int num = endX - startX;
			int num2 = endY - startY;
			int num3 = LogicMath.Abs(num);
			int num4 = LogicMath.Abs(num2);
			int x = startX;
			int y = startY;
			int num5;
			int num6;
			int num7;
			if (num4 < num3)
			{
				num5 = ((num > 0) ? 256 : -256);
				num6 = (num2 << 8) / num3;
				num7 = num / num5;
			}
			else if (num3 >= num4)
			{
				num5 = ((num > 0) ? 256 : -256);
				num6 = ((num2 > 0) ? 256 : -256);
				num7 = num / num5;
			}
			else
			{
				num5 = (num << 8) / num4;
				num6 = ((num2 > 0) ? 256 : -256);
				num7 = num2 / num6;
			}
			int num8 = startX;
			int num9 = startY;
			LogicTile tile;
			for (int i = 0; i < num7; i++)
			{
				tile = this.GetTile(num8 >> 9, num9 >> 9);
				if (tile != null && tile.HasWall())
				{
					output.m_x = x;
					output.m_y = y;
					return true;
				}
				x = num8;
				y = num9;
				num8 += num5;
				num9 += num6;
			}
			tile = this.GetTile(endX >> 9, endY >> 9);
			if (tile != null && tile.HasWall())
			{
				output.m_x = x;
				output.m_y = y;
				return true;
			}
			output.m_x = endX;
			output.m_y = endY;
			return false;
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0002AFA0 File Offset: 0x000291A0
		public bool GetPassablePositionInLine(int startX, int startY, int endX, int endY, int radius, LogicVector2 output)
		{
			int num = endX - startX;
			int num2 = endY - startY;
			int num3 = LogicMath.Abs(num);
			int num4 = LogicMath.Abs(num2);
			int num5;
			int num6;
			int num7;
			if (num4 < num3)
			{
				num5 = ((num > 0) ? 64 : -64);
				num6 = (num2 << 6) / num3;
				num7 = num / num5;
			}
			else if (num3 >= num4)
			{
				num5 = ((num > 0) ? 64 : -64);
				num6 = ((num2 > 0) ? 64 : -64);
				num7 = num / num5;
			}
			else
			{
				num5 = (num << 6) / num4;
				num6 = ((num2 > 0) ? 64 : -64);
				num7 = num2 / num6;
			}
			int num8 = startX;
			int num9 = startY;
			int i = 0;
			int num10 = 0;
			while (i < num7)
			{
				if (this.IsPassablePathFinder(num8 >> 8, num9 >> 8))
				{
					output.m_x = num8;
					output.m_y = num9;
					return true;
				}
				num10 += num5 * num5 + num6 * num6;
				if (num10 > radius * radius)
				{
					return false;
				}
				num8 += num5;
				num9 += num6;
				i++;
			}
			if (this.IsPassablePathFinder(endX >> 8, endY >> 8))
			{
				output.m_x = endX;
				output.m_y = endY;
				return true;
			}
			return false;
		}

		// Token: 0x040004E9 RID: 1257
		private bool bool_0;

		// Token: 0x040004EA RID: 1258
		private readonly int int_0;

		// Token: 0x040004EB RID: 1259
		private readonly int int_1;

		// Token: 0x040004EC RID: 1260
		private LogicTile[] logicTile_0;

		// Token: 0x040004ED RID: 1261
		private LogicPathFinder logicPathFinder_0;

		// Token: 0x040004EE RID: 1262
		private int[] int_2;
	}
}
