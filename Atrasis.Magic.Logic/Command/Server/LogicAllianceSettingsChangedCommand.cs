using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200016F RID: 367
	public class LogicAllianceSettingsChangedCommand : LogicServerCommand
	{
		// Token: 0x060015CB RID: 5579 RVA: 0x0000E2D7 File Offset: 0x0000C4D7
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x0000E2E6 File Offset: 0x0000C4E6
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x0000E307 File Offset: 0x0000C507
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x000546D4 File Offset: 0x000528D4
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (LogicLong.Equals(playerAvatar.GetAllianceId(), this.logicLong_0))
				{
					playerAvatar.SetAllianceBadgeId(this.int_2);
					level.GetGameListener().AllianceSettingsChanged();
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x00002D0D File Offset: 0x00000F0D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_SETTINGS_CHANGED;
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x0000E328 File Offset: 0x0000C528
		public void SetAllianceData(LogicLong allianceId, int allianceBadgeId)
		{
			this.logicLong_0 = allianceId;
			this.int_2 = allianceBadgeId;
		}

		// Token: 0x04000C57 RID: 3159
		private LogicLong logicLong_0;

		// Token: 0x04000C58 RID: 3160
		private int int_2;
	}
}
