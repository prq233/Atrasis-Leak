using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E6 RID: 230
	public abstract class StreamEntry
	{
		// Token: 0x06000A65 RID: 2661 RVA: 0x00007E06 File Offset: 0x00006006
		protected StreamEntry()
		{
			this.logicLong_0 = new LogicLong();
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x00007E19 File Offset: 0x00006019
		public virtual void Destruct()
		{
			this.logicLong_0 = null;
			this.logicLong_1 = null;
			this.logicLong_2 = null;
			this.string_0 = null;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x000247A8 File Offset: 0x000229A8
		public virtual void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			bool flag = stream.ReadBoolean();
			bool flag2 = stream.ReadBoolean();
			this.bool_0 = stream.ReadBoolean();
			if (flag)
			{
				this.logicLong_2 = stream.ReadLong();
			}
			if (flag2)
			{
				this.logicLong_1 = stream.ReadLong();
			}
			this.string_0 = stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)stream.ReadInt();
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00024838 File Offset: 0x00022A38
		public virtual void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			stream.WriteBoolean(this.logicLong_2 != null);
			stream.WriteBoolean(this.logicLong_1 != null);
			stream.WriteBoolean(this.bool_0);
			if (this.logicLong_2 != null)
			{
				stream.WriteLong(this.logicLong_2);
			}
			if (this.logicLong_1 != null)
			{
				stream.WriteLong(this.logicLong_1);
			}
			stream.WriteString(this.string_0);
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_1);
			stream.WriteInt((int)this.logicAvatarAllianceRole_0);
			stream.WriteInt(this.int_2);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00007E37 File Offset: 0x00006037
		public LogicLong GetSenderAvatarId()
		{
			return this.logicLong_2;
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00007E3F File Offset: 0x0000603F
		public void SetSenderAvatarId(LogicLong id)
		{
			this.logicLong_2 = id;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x00007E48 File Offset: 0x00006048
		public LogicLong GetSenderHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00007E50 File Offset: 0x00006050
		public void SetSenderHomeId(LogicLong id)
		{
			this.logicLong_1 = id;
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00007E59 File Offset: 0x00006059
		public LogicLong GetId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00007E61 File Offset: 0x00006061
		public void SetId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00007E6A File Offset: 0x0000606A
		public string GetSenderName()
		{
			return this.string_0;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00007E72 File Offset: 0x00006072
		public void SetSenderName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00007E7B File Offset: 0x0000607B
		public int GetSenderLevel()
		{
			return this.int_0;
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00007E83 File Offset: 0x00006083
		public void SetSenderLevel(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00007E8C File Offset: 0x0000608C
		public int GetSenderLeagueType()
		{
			return this.int_1;
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00007E94 File Offset: 0x00006094
		public void SetSenderLeagueType(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00007E9D File Offset: 0x0000609D
		public LogicAvatarAllianceRole GetSenderRole()
		{
			return this.logicAvatarAllianceRole_0;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00007EA5 File Offset: 0x000060A5
		public void SetSenderRole(LogicAvatarAllianceRole value)
		{
			this.logicAvatarAllianceRole_0 = value;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x00007EAE File Offset: 0x000060AE
		public int GetAgeSeconds()
		{
			return this.int_2;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00007EB6 File Offset: 0x000060B6
		public void SetAgeSeconds(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00007EBF File Offset: 0x000060BF
		public bool IsRemoved()
		{
			return this.bool_0;
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00007EC7 File Offset: 0x000060C7
		public void SetRemoved(bool removed)
		{
			this.bool_0 = removed;
		}

		// Token: 0x06000A7B RID: 2683
		public abstract StreamEntryType GetStreamEntryType();

		// Token: 0x06000A7C RID: 2684 RVA: 0x000248E0 File Offset: 0x00022AE0
		public virtual void Save(LogicJSONObject baseObject)
		{
			if (this.logicLong_2 != null)
			{
				baseObject.Put("sender_avatar_id_high", new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				baseObject.Put("sender_avatar_id_low", new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
			}
			if (this.logicLong_1 != null)
			{
				baseObject.Put("sender_home_id_high", new LogicJSONNumber(this.logicLong_1.GetHigherInt()));
				baseObject.Put("sender_home_id_low", new LogicJSONNumber(this.logicLong_1.GetLowerInt()));
			}
			baseObject.Put("sender_name", new LogicJSONString(this.string_0));
			baseObject.Put("sender_level", new LogicJSONNumber(this.int_0));
			baseObject.Put("sender_league_type", new LogicJSONNumber(this.int_1));
			baseObject.Put("sender_role", new LogicJSONNumber((int)this.logicAvatarAllianceRole_0));
			baseObject.Put("removed", new LogicJSONBoolean(this.bool_0));
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000249D8 File Offset: 0x00022BD8
		public virtual void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("sender_avatar_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("sender_avatar_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_2 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
			}
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("sender_home_id_high");
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("sender_home_id_low");
			if (jsonnumber3 != null && jsonnumber4 != null)
			{
				this.logicLong_1 = new LogicLong(jsonnumber3.GetIntValue(), jsonnumber4.GetIntValue());
			}
			this.string_0 = LogicJSONHelper.GetString(jsonObject, "sender_name");
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "sender_level");
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "sender_league_type");
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)LogicJSONHelper.GetInt(jsonObject, "sender_role");
			this.bool_0 = LogicJSONHelper.GetBool(jsonObject, "removed");
		}

		// Token: 0x04000407 RID: 1031
		private LogicLong logicLong_0;

		// Token: 0x04000408 RID: 1032
		private LogicLong logicLong_1;

		// Token: 0x04000409 RID: 1033
		private LogicLong logicLong_2;

		// Token: 0x0400040A RID: 1034
		private string string_0;

		// Token: 0x0400040B RID: 1035
		private int int_0;

		// Token: 0x0400040C RID: 1036
		private int int_1;

		// Token: 0x0400040D RID: 1037
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;

		// Token: 0x0400040E RID: 1038
		private int int_2;

		// Token: 0x0400040F RID: 1039
		private bool bool_0;
	}
}
