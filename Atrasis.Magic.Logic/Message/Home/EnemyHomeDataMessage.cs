using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004B RID: 75
	public class EnemyHomeDataMessage : PiranhaMessage
	{
		// Token: 0x0600035F RID: 863 RVA: 0x000040B8 File Offset: 0x000022B8
		public EnemyHomeDataMessage() : this(0)
		{
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000328E File Offset: 0x0000148E
		public EnemyHomeDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0001BF8C File Offset: 0x0001A18C
		public override void Decode()
		{
			base.Decode();
			this.int_2 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.logicClientAvatar_1 = new LogicClientAvatar();
			this.logicClientAvatar_1.Decode(this.m_stream);
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(this.m_stream);
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0001C068 File Offset: 0x0001A268
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.logicClientHome_0.Encode(this.m_stream);
			this.logicClientAvatar_1.Encode(this.m_stream);
			this.logicClientAvatar_0.Encode(this.m_stream);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000040C1 File Offset: 0x000022C1
		public override short GetMessageType()
		{
			return 24107;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000040C8 File Offset: 0x000022C8
		public override void Destruct()
		{
			base.Destruct();
			this.logicClientHome_0 = null;
			this.logicClientAvatar_1 = null;
			this.logicClientAvatar_0 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000040EC File Offset: 0x000022EC
		public int GetCurrentTimestamp()
		{
			return this.int_1;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000040F4 File Offset: 0x000022F4
		public void SetCurrentTimestamp(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000040FD File Offset: 0x000022FD
		public int GetSecondsSinceLastSave()
		{
			return this.int_2;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00004105 File Offset: 0x00002305
		public void SetSecondsSinceLastSave(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000410E File Offset: 0x0000230E
		public int GetSecondsSinceLastMaintenance()
		{
			return this.int_0;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00004116 File Offset: 0x00002316
		public void SetAttackSource(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000411F File Offset: 0x0000231F
		public int GetAttackSource()
		{
			return this.int_3;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00004127 File Offset: 0x00002327
		public void SetMapId(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00004130 File Offset: 0x00002330
		public int GetMapId()
		{
			return this.int_4;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00004138 File Offset: 0x00002338
		public void SetSecondsSinceLastMaintenance(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00004141 File Offset: 0x00002341
		public LogicClientHome RemoveLogicClientHome()
		{
			LogicClientHome result = this.logicClientHome_0;
			this.logicClientHome_0 = null;
			return result;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00004150 File Offset: 0x00002350
		public void SetLogicClientHome(LogicClientHome logicClientHome)
		{
			this.logicClientHome_0 = logicClientHome;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00004159 File Offset: 0x00002359
		public LogicClientAvatar RemoveLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_1;
			this.logicClientAvatar_1 = null;
			return result;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00004168 File Offset: 0x00002368
		public void SetLogicClientAvatar(LogicClientAvatar logicClientAvatar)
		{
			this.logicClientAvatar_1 = logicClientAvatar;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00004171 File Offset: 0x00002371
		public LogicClientAvatar RemoveAttackerLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00004180 File Offset: 0x00002380
		public void SetAttackerLogicClientAvatar(LogicClientAvatar logicClientAvatar)
		{
			this.logicClientAvatar_0 = logicClientAvatar;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00004189 File Offset: 0x00002389
		public LogicLong GetAvatarStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00004191 File Offset: 0x00002391
		public void SetAvatarStreamEntryId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x04000150 RID: 336
		public const int MESSAGE_TYPE = 24107;

		// Token: 0x04000151 RID: 337
		private int int_0;

		// Token: 0x04000152 RID: 338
		private int int_1;

		// Token: 0x04000153 RID: 339
		private int int_2;

		// Token: 0x04000154 RID: 340
		private int int_3;

		// Token: 0x04000155 RID: 341
		private int int_4;

		// Token: 0x04000156 RID: 342
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000157 RID: 343
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x04000158 RID: 344
		private LogicClientHome logicClientHome_0;

		// Token: 0x04000159 RID: 345
		private LogicLong logicLong_0;
	}
}
