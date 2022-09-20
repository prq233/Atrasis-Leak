using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.League.Entry
{
	// Token: 0x02000103 RID: 259
	public class LogicAvatarTournamentEntry
	{
		// Token: 0x06000C69 RID: 3177 RVA: 0x00002465 File Offset: 0x00000665
		public void Destruct()
		{
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x0002B0AC File Offset: 0x000292AC
		public void Decode(ByteStream stream)
		{
			this.int_0 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.int_9 = stream.ReadInt();
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x0002B134 File Offset: 0x00029334
		public void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(this.int_7);
			encoder.WriteInt(this.int_6);
			encoder.WriteInt(this.int_8);
			encoder.WriteInt(this.int_9);
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00009034 File Offset: 0x00007234
		public int GetLastSeasonState()
		{
			return this.int_5;
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0000903C File Offset: 0x0000723C
		public void SetLastSeasonState(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00009045 File Offset: 0x00007245
		public int GetLastSeasonYear()
		{
			return this.int_7;
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x0000904D File Offset: 0x0000724D
		public int GetLastSeasonMonth()
		{
			return this.int_6;
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x00009055 File Offset: 0x00007255
		public void SetLastSeasonDate(int year, int month)
		{
			this.int_7 = year;
			this.int_6 = month;
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00009065 File Offset: 0x00007265
		public int GetLastSeasonScore()
		{
			return this.int_9;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x0000906D File Offset: 0x0000726D
		public void SetLastSeasonScore(int score)
		{
			this.int_9 = score;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x00009076 File Offset: 0x00007276
		public int GetLastSeasonRank()
		{
			return this.int_8;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x0000907E File Offset: 0x0000727E
		public void SetLastSeasonRank(int score)
		{
			this.int_8 = score;
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x00009087 File Offset: 0x00007287
		public int GetBestSeasonState()
		{
			return this.int_0;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0000908F File Offset: 0x0000728F
		public void SetBestSeasonState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00009098 File Offset: 0x00007298
		public int GetBestSeasonYear()
		{
			return this.int_2;
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x000090A0 File Offset: 0x000072A0
		public int GetBestSeasonMonth()
		{
			return this.int_1;
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x000090A8 File Offset: 0x000072A8
		public void SetBestSeasonDate(int year, int month)
		{
			this.int_2 = year;
			this.int_1 = month;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x000090B8 File Offset: 0x000072B8
		public int GetBestSeasonScore()
		{
			return this.int_4;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x000090C0 File Offset: 0x000072C0
		public void SetBestSeasonScore(int score)
		{
			this.int_4 = score;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x000090C9 File Offset: 0x000072C9
		public int GetBestSeasonRank()
		{
			return this.int_3;
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x000090D1 File Offset: 0x000072D1
		public void SetBestSeasonRank(int score)
		{
			this.int_3 = score;
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x0002B1BC File Offset: 0x000293BC
		public void ReadFromJSON(LogicJSONObject jsonObject)
		{
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "best_season_state");
			this.int_2 = LogicJSONHelper.GetInt(jsonObject, "best_season_year");
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "best_season_month");
			this.int_3 = LogicJSONHelper.GetInt(jsonObject, "best_season_rank");
			this.int_4 = LogicJSONHelper.GetInt(jsonObject, "best_season_score");
			this.int_5 = LogicJSONHelper.GetInt(jsonObject, "last_season_state");
			this.int_7 = LogicJSONHelper.GetInt(jsonObject, "last_season_year");
			this.int_6 = LogicJSONHelper.GetInt(jsonObject, "last_season_month");
			this.int_8 = LogicJSONHelper.GetInt(jsonObject, "last_season_rank");
			this.int_9 = LogicJSONHelper.GetInt(jsonObject, "last_season_score");
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0002B274 File Offset: 0x00029474
		public void WriteToJSON(LogicJSONObject jsonObject)
		{
			jsonObject.Put("best_season_state", new LogicJSONNumber(this.int_0));
			jsonObject.Put("best_season_year", new LogicJSONNumber(this.int_2));
			jsonObject.Put("best_season_month", new LogicJSONNumber(this.int_1));
			jsonObject.Put("best_season_rank", new LogicJSONNumber(this.int_3));
			jsonObject.Put("best_season_score", new LogicJSONNumber(this.int_4));
			jsonObject.Put("last_season_state", new LogicJSONNumber(this.int_5));
			jsonObject.Put("last_season_year", new LogicJSONNumber(this.int_7));
			jsonObject.Put("last_season_month", new LogicJSONNumber(this.int_6));
			jsonObject.Put("last_season_rank", new LogicJSONNumber(this.int_8));
			jsonObject.Put("last_season_score", new LogicJSONNumber(this.int_9));
		}

		// Token: 0x040004EF RID: 1263
		private int int_0;

		// Token: 0x040004F0 RID: 1264
		private int int_1;

		// Token: 0x040004F1 RID: 1265
		private int int_2;

		// Token: 0x040004F2 RID: 1266
		private int int_3;

		// Token: 0x040004F3 RID: 1267
		private int int_4;

		// Token: 0x040004F4 RID: 1268
		private int int_5;

		// Token: 0x040004F5 RID: 1269
		private int int_6;

		// Token: 0x040004F6 RID: 1270
		private int int_7;

		// Token: 0x040004F7 RID: 1271
		private int int_8;

		// Token: 0x040004F8 RID: 1272
		private int int_9;
	}
}
