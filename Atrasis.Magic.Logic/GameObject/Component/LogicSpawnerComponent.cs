using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200012A RID: 298
	public sealed class LogicSpawnerComponent : LogicComponent
	{
		// Token: 0x0600102F RID: 4143 RVA: 0x00047E68 File Offset: 0x00046068
		public LogicSpawnerComponent(LogicGameObject gameObject, LogicObstacleData spawnData, int radius, int intervalSeconds, int spawnCount, int maxSpawned, int maxLifetimeSpawns) : base(gameObject)
		{
			this.logicArrayList_0 = new LogicArrayList<int>();
			this.logicMersenneTwisterRandom_0 = new LogicMersenneTwisterRandom();
			this.logicGameObjectData_0 = spawnData;
			this.int_0 = radius;
			this.int_1 = intervalSeconds;
			this.int_2 = spawnCount;
			this.int_3 = maxSpawned;
			this.int_4 = maxLifetimeSpawns;
			this.logicMersenneTwisterRandom_0.Initialize(this.m_parent.GetGlobalID());
			this.logicArrayList_0.EnsureCapacity(maxSpawned);
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0000AEF0 File Offset: 0x000090F0
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicGameObjectData_0 = null;
			this.logicArrayList_0 = null;
			this.logicMersenneTwisterRandom_0 = null;
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x000077D8 File Offset: 0x000059D8
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.SPAWNER;
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0000AF27 File Offset: 0x00009127
		public override void Tick()
		{
			if (!this.bool_0)
			{
				this.method_0();
				this.bool_0 = true;
			}
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x00047EE4 File Offset: 0x000460E4
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("initial_spawn_done");
			if (jsonboolean != null)
			{
				this.bool_0 = jsonboolean.IsTrue();
			}
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
			this.logicTimer_0 = LogicTimer.GetLogicTimer(jsonObject, this.m_parent.GetLevel().GetLogicTime(), "spawn_timer", this.int_1);
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("lifetime_spawns");
			if (jsonnumber != null)
			{
				this.int_5 = jsonnumber.GetIntValue();
			}
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("spawned");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					this.logicArrayList_0.Add(jsonarray.GetJSONNumber(i).GetIntValue());
				}
			}
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0000AF3E File Offset: 0x0000913E
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x00047FA0 File Offset: 0x000461A0
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			LogicTimer.SetLogicTimer(jsonObject, this.logicTimer_0, this.m_parent.GetLevel(), "spawn_timer");
			jsonObject.Put("initial_spawn_done", new LogicJSONBoolean(this.bool_0));
			jsonObject.Put("lifetime_spawns", new LogicJSONNumber(this.int_5));
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				logicJSONArray.Add(new LogicJSONNumber(this.logicArrayList_0[i]));
			}
			jsonObject.Put("spawned", logicJSONArray);
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x00048034 File Offset: 0x00046234
		public override void FastForwardTime(int time)
		{
			while (time > 0)
			{
				LogicGameObjectManager gameObjectManager = this.m_parent.GetGameObjectManager();
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					if (gameObjectManager.GetGameObjectByID(this.logicArrayList_0[i]) == null)
					{
						this.logicArrayList_0.Remove(i--);
					}
				}
				if (this.int_5 < this.int_4 && this.logicArrayList_0.Size() < this.int_3)
				{
					if (this.logicTimer_0 == null)
					{
						this.logicTimer_0 = new LogicTimer();
						this.logicTimer_0.StartTimer(this.int_1, this.m_parent.GetLevel().GetLogicTime(), false, -1);
					}
					int remainingSeconds = this.logicTimer_0.GetRemainingSeconds(this.m_parent.GetLevel().GetLogicTime());
					if (time >= remainingSeconds)
					{
						this.logicTimer_0.FastForward(remainingSeconds);
						this.method_0();
						this.logicTimer_0.StartTimer(this.int_1, this.m_parent.GetLevel().GetLogicTime(), false, -1);
						time -= remainingSeconds;
						continue;
					}
				}
				else if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
					return;
				}
				return;
			}
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x00048168 File Offset: 0x00046368
		private void method_0()
		{
			int num = LogicMath.Min(LogicMath.Min(this.int_2, this.int_3 - this.logicArrayList_0.Size()), this.int_4 - this.int_5);
			if (num > 0)
			{
				int x = this.m_parent.GetX();
				int y = this.m_parent.GetY();
				int tileX = this.m_parent.GetTileX();
				int tileY = this.m_parent.GetTileY();
				int widthInTiles = this.m_parent.GetWidthInTiles();
				int heightInTiles = this.m_parent.GetHeightInTiles();
				int widthInTiles2 = this.m_parent.GetLevel().GetWidthInTiles();
				int heightInTiles2 = this.m_parent.GetLevel().GetHeightInTiles();
				int num2 = LogicMath.Clamp(tileX - this.int_0, 0, widthInTiles2);
				int num3 = LogicMath.Clamp(tileY - this.int_0, 0, heightInTiles2);
				int num4 = LogicMath.Clamp(tileX + this.int_0 + widthInTiles, 0, widthInTiles2);
				int num5 = LogicMath.Clamp(tileY + this.int_0 + heightInTiles, 0, heightInTiles2);
				int num6 = (this.int_0 << 9) * (this.int_0 << 9);
				LogicArrayList<LogicTile> logicArrayList = new LogicArrayList<LogicTile>((num4 - num2) * (num5 - num3));
				LogicTileMap tileMap = this.m_parent.GetLevel().GetTileMap();
				int num7 = x + (widthInTiles << 9);
				int num8 = y + (heightInTiles << 9);
				int num9 = y - 256 - (num3 << 9);
				int num10 = num2 << 9 | 256;
				int num11 = num3 << 9 | 256;
				int i = num2;
				int num12 = num10;
				while (i < num4)
				{
					int num13 = (num12 >= num7) ? (-num7 + num12 + 1) : 0;
					int num14 = (num12 >= x) ? num13 : (x - num12);
					num14 *= num14;
					int j = num3;
					int num15 = num11;
					int num16 = num9;
					while (j < num5)
					{
						LogicTile tile = tileMap.GetTile(i, j);
						if (tile.GetGameObjectCount() == 0)
						{
							int num17 = (y <= num15) ? ((num15 < num8) ? 0 : (-num8 + num15 + 1)) : num16;
							num17 *= num17;
							if (num14 + num17 <= num6)
							{
								logicArrayList.Add(tile);
							}
						}
						j++;
						num15 += 512;
						num16 -= 512;
					}
					i++;
					num12 += 512;
				}
				int num18 = num;
				while (num18 > 0 && logicArrayList.Size() > 0)
				{
					int index = this.logicMersenneTwisterRandom_0.Rand(logicArrayList.Size());
					LogicTile logicTile = logicArrayList[index];
					LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(this.logicGameObjectData_0, this.m_parent.GetLevel(), this.m_parent.GetVillageType());
					logicGameObject.SetInitialPosition(logicTile.GetX() << 9, logicTile.GetY() << 9);
					this.m_parent.GetGameObjectManager().AddGameObject(logicGameObject, -1);
					this.logicArrayList_0.Add(logicGameObject.GetGlobalID());
					logicArrayList.Remove(index);
					num18--;
					this.int_5++;
				}
			}
		}

		// Token: 0x040006A7 RID: 1703
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x040006A8 RID: 1704
		private LogicMersenneTwisterRandom logicMersenneTwisterRandom_0;

		// Token: 0x040006A9 RID: 1705
		private LogicTimer logicTimer_0;

		// Token: 0x040006AA RID: 1706
		private LogicGameObjectData logicGameObjectData_0;

		// Token: 0x040006AB RID: 1707
		private readonly int int_0;

		// Token: 0x040006AC RID: 1708
		private readonly int int_1;

		// Token: 0x040006AD RID: 1709
		private readonly int int_2;

		// Token: 0x040006AE RID: 1710
		private readonly int int_3;

		// Token: 0x040006AF RID: 1711
		private readonly int int_4;

		// Token: 0x040006B0 RID: 1712
		private int int_5;

		// Token: 0x040006B1 RID: 1713
		private bool bool_0;
	}
}
