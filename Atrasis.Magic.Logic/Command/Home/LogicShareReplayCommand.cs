using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C7 RID: 455
	public sealed class LogicShareReplayCommand : LogicCommand
	{
		// Token: 0x06001817 RID: 6167 RVA: 0x0000FECB File Offset: 0x0000E0CB
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.bool_0 = stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.string_0 = stream.ReadString(900000);
			}
			base.Decode(stream);
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x0005B358 File Offset: 0x00059558
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteBoolean(this.bool_0);
			if (this.string_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteString(this.string_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x0000FF05 File Offset: 0x0000E105
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SHARE_REPLAY;
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x0000FF0C File Offset: 0x0000E10C
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x0005B3A8 File Offset: 0x000595A8
		public override int Execute(LogicLevel level)
		{
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null && bunkerComponent.GetReplayShareCooldownTime() == 0)
				{
					bunkerComponent.StartReplayShareCooldownTime();
					if (this.bool_0)
					{
						level.GetGameListener().DuelReplayShared(this.logicLong_0);
						level.GetHomeOwnerAvatar().GetChangeListener().ShareDuelReplay(this.logicLong_0, this.string_0);
					}
					else
					{
						level.GetHomeOwnerAvatar().GetChangeListener().ShareReplay(this.logicLong_0, this.string_0);
					}
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D0F RID: 3343
		private LogicLong logicLong_0;

		// Token: 0x04000D10 RID: 3344
		private bool bool_0;

		// Token: 0x04000D11 RID: 3345
		private string string_0;
	}
}
