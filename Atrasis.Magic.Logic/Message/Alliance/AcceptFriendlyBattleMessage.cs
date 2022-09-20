using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000A5 RID: 165
	public class AcceptFriendlyBattleMessage : PiranhaMessage
	{
		// Token: 0x06000734 RID: 1844 RVA: 0x0000628B File Offset: 0x0000448B
		public AcceptFriendlyBattleMessage() : this(0)
		{
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0000328E File Offset: 0x0000148E
		public AcceptFriendlyBattleMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00006294 File Offset: 0x00004494
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x000062BE File Offset: 0x000044BE
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000062E8 File Offset: 0x000044E8
		public override short GetMessageType()
		{
			return 14120;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x000062EF File Offset: 0x000044EF
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x000062F7 File Offset: 0x000044F7
		public void SetStreamId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00006300 File Offset: 0x00004500
		public int GetLayoutId()
		{
			return this.int_0;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00006308 File Offset: 0x00004508
		public void SetLayoutId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040002B3 RID: 691
		public const int MESSAGE_TYPE = 14120;

		// Token: 0x040002B4 RID: 692
		private LogicLong logicLong_0;

		// Token: 0x040002B5 RID: 693
		private int int_0;
	}
}
