using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000172 RID: 370
	public class LogicChallengeUpdatedCommand : LogicServerCommand
	{
		// Token: 0x060015E0 RID: 5600 RVA: 0x0000E3D7 File Offset: 0x0000C5D7
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.logicLong_1 = null;
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x0000E3ED File Offset: 0x0000C5ED
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_2 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_1 = stream.ReadLong();
			}
			base.Decode(stream);
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x00054A54 File Offset: 0x00052C54
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.logicLong_1 != null);
			if (this.logicLong_1 != null)
			{
				encoder.WriteLong(this.logicLong_1);
			}
			base.Encode(encoder);
		}

		// Token: 0x060015E3 RID: 5603 RVA: 0x00054AA4 File Offset: 0x00052CA4
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetChallengeId(this.logicLong_0);
				playerAvatar.SetChallengeState(this.int_2);
				level.GetGameListener().ChallengeStateChanged(this.logicLong_0, this.logicLong_1, this.int_2);
				return 0;
			}
			return -1;
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x00007715 File Offset: 0x00005915
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHALLENGE_UPDATED;
		}

		// Token: 0x04000C63 RID: 3171
		private LogicLong logicLong_0;

		// Token: 0x04000C64 RID: 3172
		private LogicLong logicLong_1;

		// Token: 0x04000C65 RID: 3173
		private int int_2;
	}
}
