using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x0200009A RID: 154
	public class BattleReportStreamEntry : AvatarStreamEntry
	{
		// Token: 0x0600068D RID: 1677 RVA: 0x00005CD6 File Offset: 0x00003ED6
		public BattleReportStreamEntry(AvatarStreamEntryType streamType)
		{
			this.avatarStreamEntryType_0 = streamType;
			this.int_6 = -1;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001E7B0 File Offset: 0x0001C9B0
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			stream.WriteBoolean(this.bool_2);
			stream.WriteInt(0);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			if (this.logicLong_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteInt(this.int_6);
				stream.WriteLong(this.logicLong_2);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001E838 File Offset: 0x0001CA38
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			this.bool_2 = stream.ReadBoolean();
			stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.int_6 = stream.ReadInt();
				this.logicLong_2 = stream.ReadLong();
			}
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00005CEC File Offset: 0x00003EEC
		public LogicLong GetReplayId()
		{
			return this.logicLong_2;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00005CF4 File Offset: 0x00003EF4
		public void SetReplayId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00005CFD File Offset: 0x00003EFD
		public int GetMajorVersion()
		{
			return this.int_3;
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00005D05 File Offset: 0x00003F05
		public void SetMajorVersion(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00005D0E File Offset: 0x00003F0E
		public int GetBuildVersion()
		{
			return this.int_4;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00005D16 File Offset: 0x00003F16
		public void SetBuildVersion(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00005D1F File Offset: 0x00003F1F
		public int GetContentVersion()
		{
			return this.int_5;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00005D27 File Offset: 0x00003F27
		public void SetContentVersion(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00005D30 File Offset: 0x00003F30
		public int GetReplayShardId()
		{
			return this.int_6;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00005D38 File Offset: 0x00003F38
		public void SetReplayShardId(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00005D41 File Offset: 0x00003F41
		public string GetBattleLogJSON()
		{
			return this.string_1;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00005D49 File Offset: 0x00003F49
		public void SetBattleLogJSON(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00005D52 File Offset: 0x00003F52
		public bool IsRevengeUsed()
		{
			return this.bool_2;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00005D5A File Offset: 0x00003F5A
		public void SetRevengeUsed(bool value)
		{
			this.bool_2 = value;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00005D63 File Offset: 0x00003F63
		public override AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			return this.avatarStreamEntryType_0;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001E8B4 File Offset: 0x0001CAB4
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("BattleReportStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("battle_log").GetStringValue();
			this.int_3 = jsonObject.GetJSONNumber("major_v").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("build_v").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("content_v").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("replay_shard_id").GetIntValue();
			this.bool_2 = jsonObject.GetJSONBoolean("revenge_used").IsTrue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("replay_id_hi");
			if (jsonnumber != null)
			{
				this.logicLong_2 = new LogicLong(jsonnumber.GetIntValue(), jsonObject.GetJSONNumber("replay_id_lo").GetIntValue());
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001E998 File Offset: 0x0001CB98
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("battle_log", new LogicJSONString(this.string_1));
			jsonObject.Put("major_v", new LogicJSONNumber(this.int_3));
			jsonObject.Put("build_v", new LogicJSONNumber(this.int_4));
			jsonObject.Put("content_v", new LogicJSONNumber(this.int_5));
			jsonObject.Put("replay_shard_id", new LogicJSONNumber(this.int_6));
			jsonObject.Put("revenge_used", new LogicJSONBoolean(this.bool_2));
			if (this.logicLong_2 != null)
			{
				jsonObject.Put("replay_id_hi", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				jsonObject.Put("replay_id_lo", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
			}
		}

		// Token: 0x04000274 RID: 628
		private LogicLong logicLong_2;

		// Token: 0x04000275 RID: 629
		private readonly AvatarStreamEntryType avatarStreamEntryType_0;

		// Token: 0x04000276 RID: 630
		private int int_3;

		// Token: 0x04000277 RID: 631
		private int int_4;

		// Token: 0x04000278 RID: 632
		private int int_5;

		// Token: 0x04000279 RID: 633
		private int int_6;

		// Token: 0x0400027A RID: 634
		private string string_1;

		// Token: 0x0400027B RID: 635
		private bool bool_2;
	}
}
