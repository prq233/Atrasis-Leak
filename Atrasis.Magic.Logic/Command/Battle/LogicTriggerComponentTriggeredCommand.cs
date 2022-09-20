using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EC RID: 492
	public sealed class LogicTriggerComponentTriggeredCommand : LogicCommand
	{
		// Token: 0x0600191B RID: 6427 RVA: 0x00010A8C File Offset: 0x0000EC8C
		public LogicTriggerComponentTriggeredCommand()
		{
			this.logicJSONObject_0 = new LogicJSONObject();
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x00010A9F File Offset: 0x0000EC9F
		public LogicTriggerComponentTriggeredCommand(LogicGameObject gameObject) : this()
		{
			this.int_1 = gameObject.GetGlobalID();
			this.logicGameObjectData_0 = gameObject.GetData();
			gameObject.Save(this.logicJSONObject_0, 0);
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x0005F948 File Offset: 0x0005DB48
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadVInt();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(stream.ReadVInt());
			this.logicJSONObject_0 = LogicJSONParser.ParseObject(stream.ReadString(900000) ?? string.Empty);
			base.Decode(stream);
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x00010ACC File Offset: 0x0000ECCC
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteVInt(this.int_1);
			encoder.WriteVInt(this.logicGameObjectData_0.GetGlobalID());
			encoder.WriteString(LogicJSONParser.CreateJSONString(this.logicJSONObject_0, 20));
			base.Encode(encoder);
		}

		// Token: 0x0600191F RID: 6431 RVA: 0x00010B05 File Offset: 0x0000ED05
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRIGGER_COMPONENT_TRIGGERED;
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x00010B0C File Offset: 0x0000ED0C
		public override void Destruct()
		{
			base.Destruct();
			this.logicGameObjectData_0 = null;
			this.logicJSONObject_0 = null;
		}

		// Token: 0x06001921 RID: 6433 RVA: 0x0005F9A0 File Offset: 0x0005DBA0
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
			if (logicGameObject != null)
			{
				if (logicGameObject.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicGameObject logicGameObject2 = (LogicTrap)logicGameObject;
					level.GetGameObjectManager().GetListener().AddGameObject(logicGameObject);
					logicGameObject.LoadingFinished();
					logicGameObject.GetListener().RefreshState();
					LogicTriggerComponent triggerComponent = logicGameObject2.GetTriggerComponent();
					if (triggerComponent != null)
					{
						triggerComponent.SetTriggered();
					}
				}
				return 0;
			}
			Debugger.Warning("PGO == NULL in LogicTriggerComponentTriggeredCommand");
			return -2;
		}

		// Token: 0x06001922 RID: 6434 RVA: 0x0005FA50 File Offset: 0x0005DC50
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicTriggerComponentTriggeredCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			this.int_1 = jsonRoot.GetJSONNumber("id").GetIntValue();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(jsonRoot.GetJSONNumber("dataid").GetIntValue());
			this.logicJSONObject_0 = jsonRoot.GetJSONObject("objs");
		}

		// Token: 0x06001923 RID: 6435 RVA: 0x0005FAC4 File Offset: 0x0005DCC4
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			logicJSONObject.Put("id", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("dataid", new LogicJSONNumber(this.logicGameObjectData_0.GetGlobalID()));
			logicJSONObject.Put("objs", this.logicJSONObject_0);
			return logicJSONObject;
		}

		// Token: 0x04000D95 RID: 3477
		private int int_1;

		// Token: 0x04000D96 RID: 3478
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000D97 RID: 3479
		private LogicGameObjectData logicGameObjectData_0;
	}
}
