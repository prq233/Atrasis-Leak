using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EE RID: 238
	public class InboxOpenedMessage : PiranhaMessage
	{
		// Token: 0x06000AAF RID: 2735 RVA: 0x000080A2 File Offset: 0x000062A2
		public InboxOpenedMessage() : this(0)
		{
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0000328E File Offset: 0x0000148E
		public InboxOpenedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00024CC4 File Offset: 0x00022EC4
		public override void Decode()
		{
			int num = this.m_stream.ReadVInt();
			this.logicArrayList_0 = new LogicArrayList<int>(num);
			Debugger.DoAssert(num < 1000, "Too many event inbox ids");
			for (int i = num; i > 0; i--)
			{
				this.logicArrayList_0.Add(this.m_stream.ReadVInt());
			}
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00024D20 File Offset: 0x00022F20
		public override void Encode()
		{
			this.m_stream.WriteVInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.m_stream.WriteVInt(this.logicArrayList_0[i]);
			}
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x000080AB File Offset: 0x000062AB
		public override short GetMessageType()
		{
			return 10905;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x000080B2 File Offset: 0x000062B2
		public LogicArrayList<int> GetEventInboxIds()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000080BA File Offset: 0x000062BA
		public void SetEventInboxIds(LogicArrayList<int> ids)
		{
			this.logicArrayList_0 = ids;
		}

		// Token: 0x0400042A RID: 1066
		public const int MESSAGE_TYPE = 10905;

		// Token: 0x0400042B RID: 1067
		private LogicArrayList<int> logicArrayList_0;
	}
}
