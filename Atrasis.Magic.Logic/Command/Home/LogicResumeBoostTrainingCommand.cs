using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B9 RID: 441
	public sealed class LogicResumeBoostTrainingCommand : LogicCommand
	{
		// Token: 0x060017B7 RID: 6071 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicResumeBoostTrainingCommand()
		{
		}

		// Token: 0x060017B8 RID: 6072 RVA: 0x0000FA4B File Offset: 0x0000DC4B
		public LogicResumeBoostTrainingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060017B9 RID: 6073 RVA: 0x0000FA5A File Offset: 0x0000DC5A
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017BA RID: 6074 RVA: 0x0000FA6F File Offset: 0x0000DC6F
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017BB RID: 6075 RVA: 0x0000FA84 File Offset: 0x0000DC84
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.RESUME_BOOST_TRAINING;
		}

		// Token: 0x060017BC RID: 6076 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017BD RID: 6077 RVA: 0x0005A6B0 File Offset: 0x000588B0
		public override int Execute(LogicLevel level)
		{
			if (LogicDataTables.GetGlobals().UseNewTraining())
			{
				LogicUnitProduction logicUnitProduction = (this.int_1 == -2) ? level.GetGameObjectManager().GetUnitProduction() : ((this.int_1 == -1) ? level.GetGameObjectManager().GetSpellProduction() : null);
				if (logicUnitProduction != null)
				{
					logicUnitProduction.SetBoostPause(false);
					this.UpdateProductionHouseListeners(level);
				}
				return 0;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING && gameObjectByID.IsBoostPaused())
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
				if (logicBuilding.CanStopBoost())
				{
					logicBuilding.SetBoostPause(false);
					logicBuilding.GetListener().RefreshState();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x060017BE RID: 6078 RVA: 0x0005A754 File Offset: 0x00058954
		public void UpdateProductionHouseListeners(LogicLevel level)
		{
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.BUILDING);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				if (logicBuilding.GetBuildingData().GetUnitProduction(0) > 0)
				{
					logicBuilding.GetListener().RefreshState();
				}
			}
		}

		// Token: 0x04000CF4 RID: 3316
		private int int_1;
	}
}
