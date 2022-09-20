using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200016E RID: 366
	public class LogicAllianceExpEarnedCommand : LogicServerCommand
	{
		// Token: 0x060015C4 RID: 5572 RVA: 0x0000E25A File Offset: 0x0000C45A
		public LogicAllianceExpEarnedCommand()
		{
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x0000E262 File Offset: 0x0000C462
		public LogicAllianceExpEarnedCommand(int expLevel)
		{
			this.int_2 = expLevel;
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015C7 RID: 5575 RVA: 0x0000E279 File Offset: 0x0000C479
		public override void Decode(ByteStream stream)
		{
			stream.ReadInt();
			stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x0000E2A8 File Offset: 0x0000C4A8
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(0);
			encoder.WriteInt(0);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x0005468C File Offset: 0x0005288C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && playerAvatar.IsInAlliance())
			{
				playerAvatar.SetAllianceLevel(this.int_2);
				if (this.bool_0)
				{
					playerAvatar.GetChangeListener().AllianceLevelChanged(this.int_2);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x0000B312 File Offset: 0x00009512
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_EXP_EARNED;
		}

		// Token: 0x04000C55 RID: 3157
		private int int_2;

		// Token: 0x04000C56 RID: 3158
		private bool bool_0;
	}
}
