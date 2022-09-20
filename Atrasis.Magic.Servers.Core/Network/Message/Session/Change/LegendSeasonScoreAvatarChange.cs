using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.League.Entry;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000066 RID: 102
	public class LegendSeasonScoreAvatarChange : AvatarChange
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000611F File Offset: 0x0000431F
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x00006127 File Offset: 0x00004327
		public LogicAvatarTournamentEntry Entry { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00006130 File Offset: 0x00004330
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00006138 File Offset: 0x00004338
		public int ScoreChange { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00006141 File Offset: 0x00004341
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00006149 File Offset: 0x00004349
		public bool BestSeason { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00006152 File Offset: 0x00004352
		// (set) Token: 0x060002BD RID: 701 RVA: 0x0000615A File Offset: 0x0000435A
		public int VillageType { get; set; }

		// Token: 0x060002BE RID: 702 RVA: 0x00006163 File Offset: 0x00004363
		public override void Decode(ByteStream stream)
		{
			this.Entry = new LogicAvatarTournamentEntry();
			this.Entry.Decode(stream);
			this.ScoreChange = stream.ReadVInt();
			this.BestSeason = stream.ReadBoolean();
			this.VillageType = stream.ReadVInt();
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000061A0 File Offset: 0x000043A0
		public override void Encode(ByteStream stream)
		{
			this.Entry.Encode(stream);
			stream.WriteVInt(this.ScoreChange);
			stream.WriteBoolean(this.BestSeason);
			stream.WriteVInt(this.VillageType);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			LogicAvatarTournamentEntry logicAvatarTournamentEntry = (this.VillageType == 1) ? avatar.GetLegendSeasonEntryVillage2() : avatar.GetLegendSeasonEntry();
			if (logicAvatarTournamentEntry.GetLastSeasonState() != this.Entry.GetLastSeasonState())
			{
				if (this.VillageType == 1)
				{
					avatar.SetDuelScore(avatar.GetDuelScore() - this.ScoreChange);
					avatar.SetLegendaryScore(avatar.GetLegendaryScoreVillage2() + this.ScoreChange);
				}
				else
				{
					avatar.SetScore(avatar.GetScore() - this.ScoreChange);
					avatar.SetLegendaryScore(avatar.GetLegendaryScore() + this.ScoreChange);
				}
				logicAvatarTournamentEntry.SetLastSeasonState(this.Entry.GetLastSeasonState());
				logicAvatarTournamentEntry.SetLastSeasonDate(this.Entry.GetLastSeasonYear(), this.Entry.GetLastSeasonMonth());
				logicAvatarTournamentEntry.SetLastSeasonRank(this.Entry.GetLastSeasonRank());
				logicAvatarTournamentEntry.SetLastSeasonScore(this.Entry.GetLastSeasonScore());
				if (this.BestSeason)
				{
					logicAvatarTournamentEntry.SetBestSeasonState(this.Entry.GetBestSeasonState());
					logicAvatarTournamentEntry.SetBestSeasonDate(this.Entry.GetBestSeasonYear(), this.Entry.GetBestSeasonMonth());
					logicAvatarTournamentEntry.SetBestSeasonRank(this.Entry.GetBestSeasonRank());
					logicAvatarTournamentEntry.SetBestSeasonScore(this.Entry.GetBestSeasonScore());
				}
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000061D2 File Offset: 0x000043D2
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			if (this.VillageType == 1)
			{
				memberEntry.SetDuelScore(memberEntry.GetDuelScore() - this.ScoreChange);
				return;
			}
			memberEntry.SetScore(memberEntry.GetScore() - this.ScoreChange);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00006204 File Offset: 0x00004404
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.LEGEND_SEASON_SCORE;
		}

		// Token: 0x04000157 RID: 343
		[CompilerGenerated]
		private LogicAvatarTournamentEntry logicAvatarTournamentEntry_0;

		// Token: 0x04000158 RID: 344
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000159 RID: 345
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400015A RID: 346
		[CompilerGenerated]
		private int int_1;
	}
}
