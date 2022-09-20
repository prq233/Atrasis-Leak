using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200005E RID: 94
	public class VisitedHomeDataMessage : PiranhaMessage
	{
		// Token: 0x0600043B RID: 1083 RVA: 0x000047E1 File Offset: 0x000029E1
		public VisitedHomeDataMessage() : this(0)
		{
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000328E File Offset: 0x0000148E
		public VisitedHomeDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0001CAFC File Offset: 0x0001ACFC
		public override void Decode()
		{
			base.Decode();
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.logicClientAvatar_1 = new LogicClientAvatar();
			this.logicClientAvatar_1.Decode(this.m_stream);
			this.int_2 = this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				this.logicClientAvatar_0 = new LogicClientAvatar();
				this.logicClientAvatar_0.Decode(this.m_stream);
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0001CBA4 File Offset: 0x0001ADA4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_0);
			this.logicClientHome_0.Encode(this.m_stream);
			this.logicClientAvatar_1.Encode(this.m_stream);
			this.m_stream.WriteInt(this.int_2);
			if (this.logicClientAvatar_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.logicClientAvatar_0.Encode(this.m_stream);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000047EA File Offset: 0x000029EA
		public override short GetMessageType()
		{
			return 24113;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000047F1 File Offset: 0x000029F1
		public override void Destruct()
		{
			base.Destruct();
			this.logicClientHome_0 = null;
			this.logicClientAvatar_1 = null;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00004807 File Offset: 0x00002A07
		public int GetCurrentTimestamp()
		{
			return this.int_0;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000480F File Offset: 0x00002A0F
		public void SetCurrentTimestamp(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00004818 File Offset: 0x00002A18
		public int GetSecondsSinceLastSave()
		{
			return this.int_1;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00004820 File Offset: 0x00002A20
		public void SetSecondsSinceLastSave(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00004829 File Offset: 0x00002A29
		public LogicClientHome RemoveLogicClientHome()
		{
			LogicClientHome result = this.logicClientHome_0;
			this.logicClientHome_0 = null;
			return result;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00004838 File Offset: 0x00002A38
		public void SetLogicClientHome(LogicClientHome logicClientHome)
		{
			this.logicClientHome_0 = logicClientHome;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00004841 File Offset: 0x00002A41
		public LogicClientAvatar RemoveVisitorLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00004850 File Offset: 0x00002A50
		public void SetVisitorLogicClientAvatar(LogicClientAvatar logicClientAvatar)
		{
			this.logicClientAvatar_0 = logicClientAvatar;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00004859 File Offset: 0x00002A59
		public LogicClientAvatar RemoveOwnerLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_1;
			this.logicClientAvatar_1 = null;
			return result;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00004868 File Offset: 0x00002A68
		public void SetOwnerLogicClientAvatar(LogicClientAvatar logicClientAvatar)
		{
			this.logicClientAvatar_1 = logicClientAvatar;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00004871 File Offset: 0x00002A71
		public int GetVillageType()
		{
			return this.int_2;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00004879 File Offset: 0x00002A79
		public void SetVillageType(int villageType)
		{
			this.int_2 = villageType;
		}

		// Token: 0x0400019E RID: 414
		public const int MESSAGE_TYPE = 24113;

		// Token: 0x0400019F RID: 415
		private int int_0;

		// Token: 0x040001A0 RID: 416
		private int int_1;

		// Token: 0x040001A1 RID: 417
		private int int_2;

		// Token: 0x040001A2 RID: 418
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x040001A3 RID: 419
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x040001A4 RID: 420
		private LogicClientHome logicClientHome_0;
	}
}
