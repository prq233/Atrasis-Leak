using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019D RID: 413
	public sealed class LogicClearObstacleCommand : LogicCommand
	{
		// Token: 0x06001707 RID: 5895 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicClearObstacleCommand()
		{
		}

		// Token: 0x06001708 RID: 5896 RVA: 0x0000F09B File Offset: 0x0000D29B
		public LogicClearObstacleCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001709 RID: 5897 RVA: 0x0000F0AA File Offset: 0x0000D2AA
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600170A RID: 5898 RVA: 0x0000F0BF File Offset: 0x0000D2BF
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600170B RID: 5899 RVA: 0x0000F0D4 File Offset: 0x0000D2D4
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CLEAR_OBSTACLE;
		}

		// Token: 0x0600170C RID: 5900 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600170D RID: 5901 RVA: 0x000581F4 File Offset: 0x000563F4
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.OBSTACLE)
			{
				return -1;
			}
			LogicObstacle logicObstacle = (LogicObstacle)gameObjectByID;
			if (logicObstacle.GetObstacleData().GetVillageType() == level.GetVillageType())
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (logicObstacle.CanStartClearing())
				{
					LogicObstacleData obstacleData = logicObstacle.GetObstacleData();
					if (logicObstacle.GetVillageType() == 1 && playerAvatar.GetVillage2TownHallLevel() < LogicDataTables.GetGlobals().GetMinVillage2TownHallLevelForDestructObstacle() && obstacleData.GetClearCost() > 0)
					{
						return 0;
					}
					LogicResourceData clearResourceData = obstacleData.GetClearResourceData();
					int clearCost = obstacleData.GetClearCost();
					if (playerAvatar.HasEnoughResources(clearResourceData, clearCost, true, this, false))
					{
						if (obstacleData.GetClearTime() == 0 || level.HasFreeWorkers(this, -1))
						{
							playerAvatar.CommodityCountChangeHelper(0, clearResourceData, -clearCost);
							logicObstacle.StartClearing();
							if (logicObstacle.IsTombstone())
							{
								int tombGroup = logicObstacle.GetTombGroup();
								if (tombGroup != 2)
								{
									LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.OBSTACLE);
									for (int i = 0; i < gameObjects.Size(); i++)
									{
										LogicObstacle logicObstacle2 = (LogicObstacle)gameObjects[i];
										if (logicObstacle2.IsTombstone() && logicObstacle2.GetTombGroup() == tombGroup)
										{
											logicObstacle2.StartClearing();
										}
									}
								}
							}
						}
						return 0;
					}
				}
				return -1;
			}
			return -32;
		}

		// Token: 0x04000CBF RID: 3263
		private int int_1;
	}
}
