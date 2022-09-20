using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Avatar
{
	// Token: 0x02000200 RID: 512
	public class LogicNpcAvatar : LogicAvatar
	{
		// Token: 0x06001B0D RID: 6925 RVA: 0x00011AC9 File Offset: 0x0000FCC9
		public LogicNpcAvatar()
		{
			this.InitBase();
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x00011AD7 File Offset: 0x0000FCD7
		public override void Destruct()
		{
			base.Destruct();
			this.logicNpcData_0 = null;
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x00011AE6 File Offset: 0x0000FCE6
		public LogicNpcData GetNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x00011AEE File Offset: 0x0000FCEE
		public override int GetExpLevel()
		{
			return this.logicNpcData_0.GetExpLevel();
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x00011AFB File Offset: 0x0000FCFB
		public override string GetName()
		{
			return this.logicNpcData_0.GetPlayerName();
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x00011B08 File Offset: 0x0000FD08
		public override int GetAllianceBadgeId()
		{
			return this.logicNpcData_0.GetAllianceBadge();
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x00011B15 File Offset: 0x0000FD15
		public void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicNpcData_0);
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x00011B23 File Offset: 0x0000FD23
		public void Decode(ByteStream stream)
		{
			this.SetNpcData((LogicNpcData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.NPC));
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x00011B38 File Offset: 0x0000FD38
		public static LogicNpcAvatar GetNpcAvatar(LogicNpcData data)
		{
			LogicNpcAvatar logicNpcAvatar = new LogicNpcAvatar();
			logicNpcAvatar.SetNpcData(data);
			return logicNpcAvatar;
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x00002B38 File Offset: 0x00000D38
		public override bool IsNpcAvatar()
		{
			return true;
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x00002B35 File Offset: 0x00000D35
		public override LogicLeagueData GetLeagueTypeData()
		{
			return null;
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x00002465 File Offset: 0x00000665
		public override void SaveToReplay(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x00002465 File Offset: 0x00000665
		public override void SaveToDirect(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x00002465 File Offset: 0x00000665
		public override void LoadForReplay(LogicJSONObject jsonObject, bool direct)
		{
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x00069000 File Offset: 0x00067200
		public void SetNpcData(LogicNpcData data)
		{
			this.logicNpcData_0 = data;
			base.SetResourceCount(LogicDataTables.GetGoldData(), this.logicNpcData_0.GetGoldCount());
			base.SetResourceCount(LogicDataTables.GetElixirData(), this.logicNpcData_0.GetElixirCount());
			if (this.m_allianceUnitCount.Size() != 0)
			{
				base.ClearUnitSlotArray(this.m_allianceUnitCount);
				this.m_allianceUnitCount = null;
			}
			if (this.m_unitCount.Size() != 0)
			{
				base.ClearDataSlotArray(this.m_unitCount);
				this.m_unitCount = null;
			}
			this.m_allianceUnitCount = new LogicArrayList<LogicUnitSlot>();
			this.m_unitCount = this.logicNpcData_0.GetClonedUnits();
		}

		// Token: 0x04000E63 RID: 3683
		private LogicNpcData logicNpcData_0;
	}
}
