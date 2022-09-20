using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000057 RID: 87
	public class NpcDataMessage : PiranhaMessage
	{
		// Token: 0x060003DC RID: 988 RVA: 0x000044CD File Offset: 0x000026CD
		public NpcDataMessage() : this(0)
		{
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000328E File Offset: 0x0000148E
		public NpcDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001C61C File Offset: 0x0001A81C
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(this.m_stream);
			this.logicNpcAvatar_0 = new LogicNpcAvatar();
			this.logicNpcAvatar_0.Decode(this.m_stream);
			this.bool_0 = this.m_stream.ReadBoolean();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001C6B8 File Offset: 0x0001A8B8
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.logicClientHome_0.Encode(this.m_stream);
			this.logicClientAvatar_0.Encode(this.m_stream);
			this.logicNpcAvatar_0.Encode(this.m_stream);
			this.m_stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x000044D6 File Offset: 0x000026D6
		public override short GetMessageType()
		{
			return 24133;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000044DD File Offset: 0x000026DD
		public override void Destruct()
		{
			base.Destruct();
			this.logicClientHome_0 = null;
			this.logicClientAvatar_0 = null;
			this.logicNpcAvatar_0 = null;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000044FA File Offset: 0x000026FA
		public LogicClientHome RemoveLogicClientHome()
		{
			LogicClientHome result = this.logicClientHome_0;
			this.logicClientHome_0 = null;
			return result;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00004509 File Offset: 0x00002709
		public void SetLogicClientHome(LogicClientHome instance)
		{
			this.logicClientHome_0 = instance;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00004512 File Offset: 0x00002712
		public LogicClientAvatar RemoveLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00004521 File Offset: 0x00002721
		public void SetLogicClientAvatar(LogicClientAvatar instance)
		{
			this.logicClientAvatar_0 = instance;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000452A File Offset: 0x0000272A
		public LogicNpcAvatar RemoveLogicNpcAvatar()
		{
			LogicNpcAvatar result = this.logicNpcAvatar_0;
			this.logicNpcAvatar_0 = null;
			return result;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00004539 File Offset: 0x00002739
		public void SetLogicNpcAvatar(LogicNpcAvatar instance)
		{
			this.logicNpcAvatar_0 = instance;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00004542 File Offset: 0x00002742
		public int GetCurrentTimestamp()
		{
			return this.int_1;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000454A File Offset: 0x0000274A
		public void SetCurrentTimestamp(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00004553 File Offset: 0x00002753
		public int GetSecondsSinceLastSave()
		{
			return this.int_0;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000455B File Offset: 0x0000275B
		public void SetSecondsSinceLastSave(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00004564 File Offset: 0x00002764
		public bool IsNpcDuel()
		{
			return this.bool_0;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000456C File Offset: 0x0000276C
		public void SetNpcDuel(bool npcDuel)
		{
			this.bool_0 = npcDuel;
		}

		// Token: 0x04000180 RID: 384
		public const int MESSAGE_TYPE = 24133;

		// Token: 0x04000181 RID: 385
		private LogicClientHome logicClientHome_0;

		// Token: 0x04000182 RID: 386
		private LogicNpcAvatar logicNpcAvatar_0;

		// Token: 0x04000183 RID: 387
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000184 RID: 388
		private int int_0;

		// Token: 0x04000185 RID: 389
		private int int_1;

		// Token: 0x04000186 RID: 390
		private bool bool_0;
	}
}
