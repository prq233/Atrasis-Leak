using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Chat
{
	// Token: 0x02000076 RID: 118
	public class GlobalChatLineMessage : PiranhaMessage
	{
		// Token: 0x06000523 RID: 1315 RVA: 0x00004FDD File Offset: 0x000031DD
		public GlobalChatLineMessage() : this(0)
		{
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000328E File Offset: 0x0000148E
		public GlobalChatLineMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001D11C File Offset: 0x0001B31C
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.logicLong_1 = this.m_stream.ReadLong();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_2 = this.m_stream.ReadLong();
				this.string_2 = this.m_stream.ReadString(900000);
				this.int_2 = this.m_stream.ReadInt();
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteLong(this.logicLong_1);
			if (this.logicLong_2 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_2);
				this.m_stream.WriteString(this.string_2);
				this.m_stream.WriteInt(this.int_2);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00004FE6 File Offset: 0x000031E6
		public override short GetMessageType()
		{
			return 24715;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00002D0D File Offset: 0x00000F0D
		public override int GetServiceNodeType()
		{
			return 6;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00004FED File Offset: 0x000031ED
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.logicLong_0 = null;
			this.logicLong_1 = null;
			this.logicLong_2 = null;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0000501F File Offset: 0x0000321F
		public string RemoveMessage(string message)
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0000502E File Offset: 0x0000322E
		public void SetMessage(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00005037 File Offset: 0x00003237
		public string GetAvatarName()
		{
			return this.string_1;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000503F File Offset: 0x0000323F
		public void SetAvatarName(string name)
		{
			this.string_1 = name;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00005048 File Offset: 0x00003248
		public string GetAllianceName()
		{
			return this.string_2;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00005050 File Offset: 0x00003250
		public void SetAllianceName(string name)
		{
			this.string_2 = name;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00005059 File Offset: 0x00003259
		public int GetAvatarExpLevel()
		{
			return this.int_0;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00005061 File Offset: 0x00003261
		public void SetAvatarExpLevel(int lvl)
		{
			this.int_0 = lvl;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0000506A File Offset: 0x0000326A
		public int GetAvatarLeagueType()
		{
			return this.int_1;
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00005072 File Offset: 0x00003272
		public void SetAvatarLeagueType(int leagueType)
		{
			this.int_1 = leagueType;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0000507B File Offset: 0x0000327B
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00005083 File Offset: 0x00003283
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000508C File Offset: 0x0000328C
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00005094 File Offset: 0x00003294
		public void SetHomeId(LogicLong id)
		{
			this.logicLong_1 = id;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0000509D File Offset: 0x0000329D
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x000050A5 File Offset: 0x000032A5
		public void SetAllianceId(LogicLong id)
		{
			this.logicLong_2 = id;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x000050AE File Offset: 0x000032AE
		public int GetAllianceBadgeId()
		{
			return this.int_2;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x000050B6 File Offset: 0x000032B6
		public void SetAllianceBadgeId(int id)
		{
			this.int_2 = id;
		}

		// Token: 0x040001EC RID: 492
		public const int MESSAGE_TYPE = 24715;

		// Token: 0x040001ED RID: 493
		private string string_0;

		// Token: 0x040001EE RID: 494
		private string string_1;

		// Token: 0x040001EF RID: 495
		private string string_2;

		// Token: 0x040001F0 RID: 496
		private int int_0;

		// Token: 0x040001F1 RID: 497
		private int int_1;

		// Token: 0x040001F2 RID: 498
		private int int_2;

		// Token: 0x040001F3 RID: 499
		private LogicLong logicLong_0;

		// Token: 0x040001F4 RID: 500
		private LogicLong logicLong_1;

		// Token: 0x040001F5 RID: 501
		private LogicLong logicLong_2;
	}
}
