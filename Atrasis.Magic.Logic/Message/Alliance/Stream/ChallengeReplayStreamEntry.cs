using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DD RID: 221
	public class ChallengeReplayStreamEntry : StreamEntry
	{
		// Token: 0x0600099E RID: 2462 RVA: 0x00022844 File Offset: 0x00020A44
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			this.int_3 = stream.ReadVInt();
			this.int_4 = stream.ReadVInt();
			this.int_5 = stream.ReadVInt();
			stream.ReadVInt();
			stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.int_6 = stream.ReadVInt();
				this.logicLong_3 = stream.ReadLong();
			}
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000228BC File Offset: 0x00020ABC
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			stream.WriteVInt(this.int_3);
			stream.WriteVInt(this.int_4);
			stream.WriteVInt(this.int_5);
			stream.WriteVInt(0);
			stream.WriteBoolean(false);
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteVInt(this.int_6);
				stream.WriteLong(this.logicLong_3);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00007772 File Offset: 0x00005972
		public string GetBattleLogJSON()
		{
			return this.string_1;
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0000777A File Offset: 0x0000597A
		public void SetBattleLogJSON(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00007783 File Offset: 0x00005983
		public int GetReplayMajorVersion()
		{
			return this.int_3;
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0000778B File Offset: 0x0000598B
		public void SetReplayMajorVersion(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00007794 File Offset: 0x00005994
		public int GetReplayBuildVersion()
		{
			return this.int_4;
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0000779C File Offset: 0x0000599C
		public void SetReplayBuildVersion(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000077A5 File Offset: 0x000059A5
		public int GetReplayContentVersion()
		{
			return this.int_5;
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000077AD File Offset: 0x000059AD
		public void SetReplayContentVersion(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x000077B6 File Offset: 0x000059B6
		public int GetReplayShardId()
		{
			return this.int_6;
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x000077BE File Offset: 0x000059BE
		public void SetReplayShardId(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x000077C7 File Offset: 0x000059C7
		public LogicLong GetReplayId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x000077CF File Offset: 0x000059CF
		public void SetReplayId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000046E2 File Offset: 0x000028E2
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.CHALLENGE_REPLAY;
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00022940 File Offset: 0x00020B40
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ChallengeReplayStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("battleLog").GetStringValue();
			this.int_3 = jsonObject.GetJSONNumber("replay_major_v").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("replay_build_v").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("replay_content_v").GetIntValue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("replay_shard_id");
			if (jsonnumber != null)
			{
				this.int_6 = jsonnumber.GetIntValue();
				this.logicLong_3 = new LogicLong(jsonObject.GetJSONNumber("replay_id_hi").GetIntValue(), jsonObject.GetJSONNumber("replay_id_lo").GetIntValue());
			}
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00022A0C File Offset: 0x00020C0C
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("battleLog", new LogicJSONString(this.string_1));
			jsonObject.Put("replay_major_v", new LogicJSONNumber(this.int_3));
			jsonObject.Put("replay_build_v", new LogicJSONNumber(this.int_4));
			jsonObject.Put("replay_content_v", new LogicJSONNumber(this.int_5));
			if (this.logicLong_3 != null)
			{
				jsonObject.Put("replay_shard_id", new LogicJSONNumber(this.int_6));
				jsonObject.Put("replay_id_hi", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("replay_id_lo", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
			}
		}

		// Token: 0x040003C7 RID: 967
		private string string_1;

		// Token: 0x040003C8 RID: 968
		private int int_3;

		// Token: 0x040003C9 RID: 969
		private int int_4;

		// Token: 0x040003CA RID: 970
		private int int_5;

		// Token: 0x040003CB RID: 971
		private int int_6;

		// Token: 0x040003CC RID: 972
		private LogicLong logicLong_3;
	}
}
