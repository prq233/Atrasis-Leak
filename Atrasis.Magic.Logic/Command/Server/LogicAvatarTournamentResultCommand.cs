using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.League.Entry;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000171 RID: 369
	public class LogicAvatarTournamentResultCommand : LogicServerCommand
	{
		// Token: 0x060015D9 RID: 5593 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015DA RID: 5594 RVA: 0x000547F0 File Offset: 0x000529F0
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015DB RID: 5595 RVA: 0x00054858 File Offset: 0x00052A58
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_6);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(this.int_7);
			encoder.WriteInt(this.int_8);
			base.Encode(encoder);
		}

		// Token: 0x060015DC RID: 5596 RVA: 0x000548C0 File Offset: 0x00052AC0
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				LogicAvatarTournamentEntry logicAvatarTournamentEntry;
				if (this.int_8 == 1)
				{
					logicAvatarTournamentEntry = playerAvatar.GetLegendSeasonEntryVillage2();
				}
				else
				{
					if (this.int_8 != 0)
					{
						return -2;
					}
					logicAvatarTournamentEntry = playerAvatar.GetLegendSeasonEntry();
				}
				if (logicAvatarTournamentEntry.GetLastSeasonState() != this.int_2)
				{
					if (this.int_8 == 1)
					{
						playerAvatar.SetDuelScore(playerAvatar.GetDuelScore() - this.int_7);
						playerAvatar.SetLegendaryScore(playerAvatar.GetLegendaryScoreVillage2() + this.int_7);
					}
					else
					{
						playerAvatar.SetScore(playerAvatar.GetScore() - this.int_7);
						playerAvatar.SetLegendaryScore(playerAvatar.GetLegendaryScore() + this.int_7);
					}
					logicAvatarTournamentEntry.SetLastSeasonState(this.int_2);
					logicAvatarTournamentEntry.SetLastSeasonDate(this.int_3, this.int_4);
					logicAvatarTournamentEntry.SetLastSeasonRank(this.int_5);
					logicAvatarTournamentEntry.SetLastSeasonScore(this.int_6);
					bool bestSeason = false;
					if (logicAvatarTournamentEntry.GetBestSeasonState() == 0 || this.int_5 < logicAvatarTournamentEntry.GetBestSeasonRank() || (this.int_5 == logicAvatarTournamentEntry.GetBestSeasonRank() && this.int_6 > logicAvatarTournamentEntry.GetBestSeasonScore()))
					{
						logicAvatarTournamentEntry.SetBestSeasonState(this.int_2);
						logicAvatarTournamentEntry.SetBestSeasonDate(this.int_3, this.int_4);
						logicAvatarTournamentEntry.SetBestSeasonRank(this.int_5);
						logicAvatarTournamentEntry.SetBestSeasonScore(this.int_6);
						bestSeason = true;
					}
					playerAvatar.GetChangeListener().LegendSeasonScoreChanged(this.int_2, this.int_6, this.int_7, bestSeason, this.int_8);
					level.GetGameListener().LegendSeasonScoreChanged(this.int_2, this.int_6, this.int_7, bestSeason, this.int_8);
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x0000E39C File Offset: 0x0000C59C
		public void SetDatas(int seasonState, int seasonYear, int seasonMonth, int seasonRank, int seasonScore, int scoreChange, int villageType)
		{
			this.int_2 = seasonState;
			this.int_3 = seasonYear;
			this.int_4 = seasonMonth;
			this.int_5 = seasonRank;
			this.int_6 = seasonScore;
			this.int_7 = scoreChange;
			this.int_8 = villageType;
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x0000E3D3 File Offset: 0x0000C5D3
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.AVATAR_TOURNAMENT_RESULT;
		}

		// Token: 0x04000C5C RID: 3164
		private int int_2;

		// Token: 0x04000C5D RID: 3165
		private int int_3;

		// Token: 0x04000C5E RID: 3166
		private int int_4;

		// Token: 0x04000C5F RID: 3167
		private int int_5;

		// Token: 0x04000C60 RID: 3168
		private int int_6;

		// Token: 0x04000C61 RID: 3169
		private int int_7;

		// Token: 0x04000C62 RID: 3170
		private int int_8;
	}
}
