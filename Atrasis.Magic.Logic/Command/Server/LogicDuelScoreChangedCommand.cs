using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Avatar.Change;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017D RID: 381
	public class LogicDuelScoreChangedCommand : LogicServerCommand
	{
		// Token: 0x0600162B RID: 5675 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600162C RID: 5676 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x0000E7D1 File Offset: 0x0000C9D1
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x00055ADC File Offset: 0x00053CDC
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetDuelScore(playerAvatar.GetDuelScore() + this.int_2);
				switch (this.int_3)
				{
				case 0:
					playerAvatar.SetDuelLoseCount(playerAvatar.GetDuelLoseCount() + 1);
					break;
				case 1:
					playerAvatar.SetDuelWinCount(playerAvatar.GetDuelWinCount() + 1);
					break;
				case 2:
					playerAvatar.SetDuelDrawCount(playerAvatar.GetDuelDrawCount() + 1);
					break;
				}
				level.GetAchievementManager().RefreshStatus();
				LogicAvatarChangeListener homeOwnerAvatarChangeListener = level.GetHomeOwnerAvatarChangeListener();
				if (homeOwnerAvatarChangeListener != null)
				{
					homeOwnerAvatarChangeListener.DuelScoreChanged(playerAvatar.GetAllianceId(), this.int_2, this.int_3, this.bool_0);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x0000713B File Offset: 0x0000533B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DUEL_SCORE_CHANGED;
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x0000E7F2 File Offset: 0x0000C9F2
		public void SetData(int scoreGain, int resultType, bool attacker)
		{
			this.int_2 = scoreGain;
			this.int_3 = resultType;
			this.bool_0 = attacker;
		}

		// Token: 0x04000C83 RID: 3203
		private int int_2;

		// Token: 0x04000C84 RID: 3204
		private int int_3;

		// Token: 0x04000C85 RID: 3205
		private bool bool_0;
	}
}
