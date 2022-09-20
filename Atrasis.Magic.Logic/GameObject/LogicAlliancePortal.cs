using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x0200010B RID: 267
	public sealed class LogicAlliancePortal : LogicGameObject
	{
		// Token: 0x06000CC3 RID: 3267 RVA: 0x0002BBE8 File Offset: 0x00029DE8
		public LogicAlliancePortal(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			LogicBunkerComponent logicBunkerComponent = new LogicBunkerComponent(this, 0);
			logicBunkerComponent.SetComponentMode(0);
			base.AddComponent(logicBunkerComponent);
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00009373 File Offset: 0x00007573
		public LogicAlliancePortalData GetAlliancePortalData()
		{
			return (LogicAlliancePortalData)this.m_data;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetWidthInTiles()
		{
			return 1;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetHeightInTiles()
		{
			return 1;
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00009380 File Offset: 0x00007580
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			Debugger.Error("LogicAlliancePortal can't be saved");
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x00009380 File Offset: 0x00007580
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			Debugger.Error("LogicAlliancePortal can't be saved");
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0000938C File Offset: 0x0000758C
		public override void Load(LogicJSONObject jsonObject)
		{
			Debugger.Error("LogicAlliancePortal can't be loaded");
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x0000938C File Offset: 0x0000758C
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			Debugger.Error("LogicAlliancePortal can't be loaded");
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00009398 File Offset: 0x00007598
		public override void LoadingFinished()
		{
			base.LoadingFinished();
			if (this.m_listener != null)
			{
				this.m_listener.LoadedFromJSON();
			}
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000093B3 File Offset: 0x000075B3
		public override bool ShouldDestruct()
		{
			return !this.m_level.IsInCombatState();
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00002B38 File Offset: 0x00000D38
		public override bool IsPassable()
		{
			return true;
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00002BCE File Offset: 0x00000DCE
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.ALLIANCE_PORTAL;
		}
	}
}
