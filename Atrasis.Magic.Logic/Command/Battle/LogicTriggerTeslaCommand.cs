using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EE RID: 494
	public sealed class LogicTriggerTeslaCommand : LogicCommand
	{
		// Token: 0x0600192C RID: 6444 RVA: 0x00010B69 File Offset: 0x0000ED69
		public LogicTriggerTeslaCommand()
		{
			this.logicJSONObject_0 = new LogicJSONObject();
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x00010B7C File Offset: 0x0000ED7C
		public LogicTriggerTeslaCommand(LogicGameObject gameObject) : this()
		{
			this.int_1 = gameObject.GetGlobalID();
			this.logicGameObjectData_0 = gameObject.GetData();
			gameObject.Save(this.logicJSONObject_0, 0);
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x0005FC90 File Offset: 0x0005DE90
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadVInt();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(stream.ReadVInt());
			this.logicJSONObject_0 = LogicJSONParser.ParseObject(stream.ReadString(900000) ?? string.Empty);
			base.Decode(stream);
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x00010BA9 File Offset: 0x0000EDA9
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteVInt(this.int_1);
			encoder.WriteVInt(this.logicGameObjectData_0.GetGlobalID());
			encoder.WriteString(LogicJSONParser.CreateJSONString(this.logicJSONObject_0, 20));
			base.Encode(encoder);
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x00010BE2 File Offset: 0x0000EDE2
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRIGGER_TESLA;
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x00010BE9 File Offset: 0x0000EDE9
		public override void Destruct()
		{
			base.Destruct();
			this.logicGameObjectData_0 = null;
			this.logicJSONObject_0 = null;
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x0005FCE8 File Offset: 0x0005DEE8
		public override int Execute(LogicLevel level)
		{
			if (level == null)
			{
				return -1;
			}
			LogicGameObject logicGameObject;
			if (level.GetState() == 5)
			{
				logicGameObject = LogicGameObjectFactory.CreateGameObject(this.logicGameObjectData_0, level, level.GetVillageType());
				logicGameObject.Load(this.logicJSONObject_0);
				level.GetGameObjectManager().AddGameObject(logicGameObject, -1);
			}
			else
			{
				logicGameObject = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			}
			if (logicGameObject == null || logicGameObject.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				Debugger.Warning("PGO == NULL in LogicTriggerTeslaCommand");
				return -2;
			}
			if (logicGameObject.IsHidden())
			{
				LogicBuilding logicBuilding = (LogicBuilding)logicGameObject;
				level.GetGameObjectManager().GetListener().AddGameObject(logicGameObject);
				logicGameObject.LoadingFinished();
				logicGameObject.GetListener().RefreshState();
				logicBuilding.Trigger();
				return 0;
			}
			Debugger.Warning("PGO building not hidden");
			return -3;
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x0005FDA4 File Offset: 0x0005DFA4
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicTriggerTeslaCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			this.int_1 = jsonRoot.GetJSONNumber("id").GetIntValue();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(jsonRoot.GetJSONNumber("dataid").GetIntValue());
			this.logicJSONObject_0 = jsonRoot.GetJSONObject("objs");
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x0005FE18 File Offset: 0x0005E018
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			logicJSONObject.Put("id", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("dataid", new LogicJSONNumber(this.logicGameObjectData_0.GetGlobalID()));
			logicJSONObject.Put("objs", this.logicJSONObject_0);
			return logicJSONObject;
		}

		// Token: 0x04000D99 RID: 3481
		private int int_1;

		// Token: 0x04000D9A RID: 3482
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000D9B RID: 3483
		private LogicGameObjectData logicGameObjectData_0;
	}
}
