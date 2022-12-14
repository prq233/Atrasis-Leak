using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Mission
{
	// Token: 0x02000027 RID: 39
	public class LogicMissionManager
	{
		// Token: 0x060001BF RID: 447 RVA: 0x000031F2 File Offset: 0x000013F2
		public LogicMissionManager(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicArrayList_0 = new LogicArrayList<LogicMission>();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00019580 File Offset: 0x00017780
		public void Destruct()
		{
			if (this.logicArrayList_0 != null)
			{
				for (int i = this.logicArrayList_0.Size() - 1; i >= 0; i--)
				{
					this.logicArrayList_0[i].Destruct();
					this.logicArrayList_0.Remove(i);
				}
				this.logicArrayList_0 = null;
			}
			this.logicLevel_0 = null;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000320C File Offset: 0x0000140C
		public void LoadingFinished()
		{
			this.RefreshOpenMissions();
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000195D8 File Offset: 0x000177D8
		public void Tick()
		{
			bool flag = false;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicMission logicMission = this.logicArrayList_0[i];
				if (logicMission != null)
				{
					logicMission.RefreshProgress();
					if (logicMission.IsFinished())
					{
						this.logicArrayList_0.Remove(i--);
						logicMission.Destruct();
						flag = true;
					}
					else
					{
						logicMission.Tick();
					}
				}
			}
			if (flag)
			{
				this.RefreshOpenMissions();
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00019644 File Offset: 0x00017844
		public void RefreshOpenMissions()
		{
			if (this.logicLevel_0.GetState() != 4)
			{
				LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.MISSION);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicMissionData logicMissionData = (LogicMissionData)table.GetItemAt(i);
					if (logicMissionData.IsOpenForAvatar(playerAvatar) && this.GetMissionByData(logicMissionData) == null)
					{
						LogicMission logicMission = new LogicMission(logicMissionData, this.logicLevel_0);
						logicMission.RefreshProgress();
						this.logicArrayList_0.Add(logicMission);
					}
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000196C8 File Offset: 0x000178C8
		public LogicMission GetMissionByData(LogicMissionData data)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicMission logicMission = this.logicArrayList_0[i];
				if (logicMission.GetMissionData() == data)
				{
					return logicMission;
				}
			}
			return null;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00019708 File Offset: 0x00017908
		public LogicMission GetMissionByCategory(int category)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicMission logicMission = this.logicArrayList_0[i];
				if (logicMission.GetMissionData().GetMissionCategory() == category)
				{
					return logicMission;
				}
			}
			return null;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0001974C File Offset: 0x0001794C
		public bool IsTutorialFinished()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetMissionData().GetMissionCategory() == 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0001978C File Offset: 0x0001798C
		public bool IsVillage2TutorialOpen()
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetMissionData().GetMissionCategory() == 2 && this.logicArrayList_0[i].IsOpenTutorialMission())
				{
					num++;
				}
			}
			return this.logicLevel_0.GetGameObjectManagerAt(0).GetShipyard() != null && (this.logicLevel_0.GetGameObjectManagerAt(0).GetShipyard().IsConstructing() || num > 0);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00019814 File Offset: 0x00017A14
		public bool HasTravel(LogicAvatar playerAvatar)
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.MISSION);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicMissionData logicMissionData = (LogicMissionData)table.GetItemAt(i);
				if (logicMissionData.GetMissionType() == 14 && playerAvatar.IsMissionCompleted(logicMissionData))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00019860 File Offset: 0x00017A60
		public void DebugCompleteAllTutorials(bool onlyHomeMissions, bool completeNameMission, bool completeWarMissions)
		{
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.MISSION);
			bool flag = false;
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicMissionData logicMissionData = (LogicMissionData)table.GetItemAt(i);
				if (completeWarMissions || logicMissionData.GetMissionCategory() != 1)
				{
					if (onlyHomeMissions)
					{
						if (logicMissionData.GetMissionCategory() != 0)
						{
							goto IL_BC;
						}
					}
					else if (logicMissionData.GetMissionCategory() == 2 && this.logicLevel_0.GetGameObjectManagerAt(0).GetShipyard().GetUpgradeLevel() == 0 && this.logicLevel_0.GetVillageType() == 0)
					{
						goto IL_BC;
					}
					if (flag)
					{
						playerAvatar.SetMissionCompleted(logicMissionData, false);
						playerAvatar.GetChangeListener().CommodityCountChanged(0, logicMissionData, 0);
					}
					if (!completeNameMission && logicMissionData.GetMissionType() == 6)
					{
						flag = true;
					}
					else
					{
						playerAvatar.SetMissionCompleted(logicMissionData, true);
						playerAvatar.GetChangeListener().CommodityCountChanged(0, logicMissionData, 1);
					}
				}
				IL_BC:;
			}
			this.RefreshOpenMissions();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00019940 File Offset: 0x00017B40
		public void DebugResetAllTutorials()
		{
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.MISSION);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicMissionData data = (LogicMissionData)table.GetItemAt(i);
				playerAvatar.SetMissionCompleted(data, false);
				playerAvatar.GetChangeListener().CommodityCountChanged(0, data, 0);
			}
			while (this.logicArrayList_0.Size() > 0)
			{
				this.logicArrayList_0[0].Destruct();
				this.logicArrayList_0.Remove(0);
			}
			this.RefreshOpenMissions();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000199C8 File Offset: 0x00017BC8
		public void DebugResetWarTutorials()
		{
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.MISSION);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicMissionData logicMissionData = (LogicMissionData)table.GetItemAt(i);
				if (logicMissionData.GetMissionCategory() == 1)
				{
					playerAvatar.SetMissionCompleted(logicMissionData, false);
					playerAvatar.GetChangeListener().CommodityCountChanged(0, logicMissionData, 0);
				}
			}
			while (this.logicArrayList_0.Size() > 0)
			{
				this.logicArrayList_0[0].Destruct();
				this.logicArrayList_0.Remove(0);
			}
			this.RefreshOpenMissions();
		}

		// Token: 0x040000A1 RID: 161
		private LogicLevel logicLevel_0;

		// Token: 0x040000A2 RID: 162
		private LogicArrayList<LogicMission> logicArrayList_0;
	}
}
