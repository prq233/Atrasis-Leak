using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017F RID: 383
	public class LogicLeaveAllianceCommand : LogicServerCommand
	{
		// Token: 0x0600163A RID: 5690 RVA: 0x0000E84E File Offset: 0x0000CA4E
		public void SetAllianceData(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x0000E857 File Offset: 0x0000CA57
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x0000E866 File Offset: 0x0000CA66
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			base.Decode(stream);
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x0000E87B File Offset: 0x0000CA7B
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			base.Encode(encoder);
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x00055D10 File Offset: 0x00053F10
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (playerAvatar.IsInAlliance() && playerAvatar.GetAllianceId().Equals(this.logicLong_0))
				{
					playerAvatar.SetAllianceId(null);
					playerAvatar.SetAllianceName(null);
					playerAvatar.SetAllianceBadgeId(-1);
					playerAvatar.SetAllianceLevel(-1);
					playerAvatar.GetChangeListener().AllianceLeft();
				}
				level.GetGameListener().AllianceLeft();
				return 0;
			}
			return -1;
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x00002B58 File Offset: 0x00000D58
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.LEAVE_ALLIANCE;
		}

		// Token: 0x04000C8B RID: 3211
		private LogicLong logicLong_0;
	}
}
