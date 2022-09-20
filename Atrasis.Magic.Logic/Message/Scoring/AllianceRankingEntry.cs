using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200002C RID: 44
	public class AllianceRankingEntry : RankingEntry
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x000032DA File Offset: 0x000014DA
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_5);
			ByteStreamHelper.WriteDataReference(stream, this.logicData_0);
			stream.WriteInt(this.int_4);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00003313 File Offset: 0x00001513
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.logicData_0 = ByteStreamHelper.ReadDataReference(stream);
			this.int_4 = stream.ReadInt();
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000334C File Offset: 0x0000154C
		public int GetAllianceBadgeId()
		{
			return this.int_3;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00003354 File Offset: 0x00001554
		public void SetAllianceBadgeId(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000335D File Offset: 0x0000155D
		public int GetMemberCount()
		{
			return this.int_5;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00003365 File Offset: 0x00001565
		public void SetMemberCount(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000336E File Offset: 0x0000156E
		public int GetAllianceLevel()
		{
			return this.int_4;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00003376 File Offset: 0x00001576
		public void SetAllianceLevel(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000337F File Offset: 0x0000157F
		public LogicData GetOriginData()
		{
			return this.logicData_0;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00003387 File Offset: 0x00001587
		public void SetOriginData(LogicData data)
		{
			this.logicData_0 = data;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0001A79C File Offset: 0x0001899C
		public override LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = base.Save();
			logicJSONObject.Put("badgeId", new LogicJSONNumber(this.int_3));
			logicJSONObject.Put("xpLvl", new LogicJSONNumber(this.int_4));
			logicJSONObject.Put("memberCnt", new LogicJSONNumber(this.int_5));
			if (this.logicData_0 != null)
			{
				logicJSONObject.Put("origin", new LogicJSONNumber(this.logicData_0.GetGlobalID()));
			}
			return logicJSONObject;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0001A818 File Offset: 0x00018A18
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			this.int_3 = jsonObject.GetJSONNumber("badgeId").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("xpLvl").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("memberCnt").GetIntValue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("origin");
			if (jsonnumber != null)
			{
				this.logicData_0 = LogicDataTables.GetDataById(jsonnumber.GetIntValue());
			}
		}

		// Token: 0x040000AC RID: 172
		public const string JSON_ATTRIBUTE_BADGE_ID = "badgeId";

		// Token: 0x040000AD RID: 173
		public const string JSON_ATTRIBUTE_EXP_LEVEL = "xpLvl";

		// Token: 0x040000AE RID: 174
		public const string JSON_ATTRIBUTE_MEMBER_COUNT = "memberCnt";

		// Token: 0x040000AF RID: 175
		public const string JSON_ATTRIBUTE_ORIGIN = "origin";

		// Token: 0x040000B0 RID: 176
		private int int_3;

		// Token: 0x040000B1 RID: 177
		private int int_4;

		// Token: 0x040000B2 RID: 178
		private int int_5;

		// Token: 0x040000B3 RID: 179
		private LogicData logicData_0;
	}
}
