using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006D RID: 109
	public class FriendEntry
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x00004CC6 File Offset: 0x00002EC6
		public FriendEntry()
		{
			this.int_5 = -1;
			this.int_6 = -1;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001CD8C File Offset: 0x0001AF8C
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.logicLong_1 = stream.ReadLong();
			}
			this.string_0 = stream.ReadString(900000);
			this.string_2 = stream.ReadString(900000);
			this.string_3 = stream.ReadString(900000);
			stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_2 = stream.ReadLong();
				this.int_6 = stream.ReadInt();
				this.string_1 = stream.ReadString(900000);
				this.int_7 = stream.ReadInt();
				this.int_8 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
				stream.ReadInt();
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001CEAC File Offset: 0x0001B0AC
		public void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			if (this.logicLong_1 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_1);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteString(this.string_0);
			stream.WriteString(this.string_2);
			stream.WriteString(this.string_3);
			stream.WriteString(null);
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_1);
			stream.WriteInt(this.int_2);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(0);
			if (this.logicLong_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_2);
				stream.WriteInt(this.int_6);
				stream.WriteString(this.string_1);
				stream.WriteInt(this.int_7);
				stream.WriteInt(this.int_8);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_3);
				stream.WriteInt(0);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00004CDC File Offset: 0x00002EDC
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00004CE4 File Offset: 0x00002EE4
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00004CED File Offset: 0x00002EED
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00004CF5 File Offset: 0x00002EF5
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00004CFE File Offset: 0x00002EFE
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00004D06 File Offset: 0x00002F06
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00004D0F File Offset: 0x00002F0F
		public LogicLong GetLiveReplayId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00004D17 File Offset: 0x00002F17
		public void SetLiveReplayId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00004D20 File Offset: 0x00002F20
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00004D28 File Offset: 0x00002F28
		public void SetName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00004D31 File Offset: 0x00002F31
		public string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00004D39 File Offset: 0x00002F39
		public void SetAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00004D42 File Offset: 0x00002F42
		public string GetFacebookId()
		{
			return this.string_2;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00004D4A File Offset: 0x00002F4A
		public void SetFacebookId(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00004D53 File Offset: 0x00002F53
		public string GetGamecenterId()
		{
			return this.string_3;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00004D5B File Offset: 0x00002F5B
		public void SetGamecenterId(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00004D64 File Offset: 0x00002F64
		public int GetProtectionDurationSeconds()
		{
			return this.int_0;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00004D6C File Offset: 0x00002F6C
		public void SetProtectionDurationSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00004D75 File Offset: 0x00002F75
		public int GetExpLevel()
		{
			return this.int_1;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00004D7D File Offset: 0x00002F7D
		public void SetExpLevel(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00004D86 File Offset: 0x00002F86
		public int GetLeagueType()
		{
			return this.int_2;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00004D8E File Offset: 0x00002F8E
		public void SetLeagueType(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00004D97 File Offset: 0x00002F97
		public int GetScore()
		{
			return this.int_3;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00004D9F File Offset: 0x00002F9F
		public void SetScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00004DA8 File Offset: 0x00002FA8
		public int GetDuelScore()
		{
			return this.int_4;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00004DB0 File Offset: 0x00002FB0
		public void SetDuelScore(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00004DB9 File Offset: 0x00002FB9
		public int GetFriendState()
		{
			return this.int_5;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00004DC1 File Offset: 0x00002FC1
		public void SetFriendState(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00004DCA File Offset: 0x00002FCA
		public int GetAllianceBadgeId()
		{
			return this.int_6;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00004DD2 File Offset: 0x00002FD2
		public void SetAllianceBadgeId(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00004DDB File Offset: 0x00002FDB
		public int GetAllianceRole()
		{
			return this.int_7;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00004DE3 File Offset: 0x00002FE3
		public void SetAllianceRole(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00004DEC File Offset: 0x00002FEC
		public int GetAllianceLevel()
		{
			return this.int_8;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00004DF4 File Offset: 0x00002FF4
		public void SetAllianceLevel(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x040001CC RID: 460
		private LogicLong logicLong_0;

		// Token: 0x040001CD RID: 461
		private LogicLong logicLong_1;

		// Token: 0x040001CE RID: 462
		private LogicLong logicLong_2;

		// Token: 0x040001CF RID: 463
		private LogicLong logicLong_3;

		// Token: 0x040001D0 RID: 464
		private string string_0;

		// Token: 0x040001D1 RID: 465
		private string string_1;

		// Token: 0x040001D2 RID: 466
		private string string_2;

		// Token: 0x040001D3 RID: 467
		private string string_3;

		// Token: 0x040001D4 RID: 468
		private int int_0;

		// Token: 0x040001D5 RID: 469
		private int int_1;

		// Token: 0x040001D6 RID: 470
		private int int_2;

		// Token: 0x040001D7 RID: 471
		private int int_3;

		// Token: 0x040001D8 RID: 472
		private int int_4;

		// Token: 0x040001D9 RID: 473
		private int int_5;

		// Token: 0x040001DA RID: 474
		private int int_6;

		// Token: 0x040001DB RID: 475
		private int int_7;

		// Token: 0x040001DC RID: 476
		private int int_8;
	}
}
