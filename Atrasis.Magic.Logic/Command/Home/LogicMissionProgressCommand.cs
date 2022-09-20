using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mission;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A9 RID: 425
	public sealed class LogicMissionProgressCommand : LogicCommand
	{
		// Token: 0x06001751 RID: 5969 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicMissionProgressCommand()
		{
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x0000F3C2 File Offset: 0x0000D5C2
		public LogicMissionProgressCommand(LogicMissionData missionData)
		{
			this.logicMissionData_0 = missionData;
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0000F3D1 File Offset: 0x0000D5D1
		public override void Decode(ByteStream stream)
		{
			this.logicMissionData_0 = (LogicMissionData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.MISSION);
			base.Decode(stream);
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x0000F3ED File Offset: 0x0000D5ED
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicMissionData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0000F402 File Offset: 0x0000D602
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MISSION_PROGRESS;
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x0000F409 File Offset: 0x0000D609
		public override void Destruct()
		{
			base.Destruct();
			this.logicMissionData_0 = null;
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x00058C54 File Offset: 0x00056E54
		public override int Execute(LogicLevel level)
		{
			if (this.logicMissionData_0 == null)
			{
				return -1;
			}
			LogicMission missionByData = level.GetMissionManager().GetMissionByData(this.logicMissionData_0);
			if (missionByData != null)
			{
				missionByData.StateChangeConfirmed();
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CCC RID: 3276
		private LogicMissionData logicMissionData_0;
	}
}
