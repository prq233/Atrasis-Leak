using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Battle
{
	// Token: 0x0200007C RID: 124
	public class Village2AttackAvatarDataMessage : PiranhaMessage
	{
		// Token: 0x06000564 RID: 1380 RVA: 0x00005278 File Offset: 0x00003478
		public Village2AttackAvatarDataMessage() : this(0)
		{
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0000328E File Offset: 0x0000148E
		public Village2AttackAvatarDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001D3DC File Offset: 0x0001B5DC
		public override void Decode()
		{
			base.Decode();
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(this.m_stream);
			this.logicClientHome_0 = new LogicClientHome();
			this.logicClientHome_0.Decode(this.m_stream);
			this.logicLong_0 = this.m_stream.ReadLong();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001D44C File Offset: 0x0001B64C
		public override void Encode()
		{
			base.Encode();
			this.logicClientAvatar_0.Encode(this.m_stream);
			this.logicClientHome_0.Encode(this.m_stream);
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00005281 File Offset: 0x00003481
		public override short GetMessageType()
		{
			return 25023;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00005232 File Offset: 0x00003432
		public override int GetServiceNodeType()
		{
			return 27;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00005288 File Offset: 0x00003488
		public LogicClientAvatar GetLogicClientAvatar()
		{
			return this.logicClientAvatar_0;
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00005290 File Offset: 0x00003490
		public void SetLogicClientAvatar(LogicClientAvatar value)
		{
			this.logicClientAvatar_0 = value;
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00005299 File Offset: 0x00003499
		public LogicClientHome GetLogicClientHome()
		{
			return this.logicClientHome_0;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x000052A1 File Offset: 0x000034A1
		public void SetLogicClientHome(LogicClientHome value)
		{
			this.logicClientHome_0 = value;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000052AA File Offset: 0x000034AA
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000052B2 File Offset: 0x000034B2
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x000052BB File Offset: 0x000034BB
		public int GetTimestamp()
		{
			return this.int_0;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x000052C3 File Offset: 0x000034C3
		public void SetTimestamp(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000207 RID: 519
		public const int MESSAGE_TYPE = 25023;

		// Token: 0x04000208 RID: 520
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000209 RID: 521
		private LogicClientHome logicClientHome_0;

		// Token: 0x0400020A RID: 522
		private LogicLong logicLong_0;

		// Token: 0x0400020B RID: 523
		private int int_0;
	}
}
