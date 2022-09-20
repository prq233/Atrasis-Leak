using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003F RID: 63
	public class StartServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00005421 File Offset: 0x00003621
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00005429 File Offset: 0x00003629
		public LogicLong AccountId { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00005432 File Offset: 0x00003632
		// (set) Token: 0x06000177 RID: 375 RVA: 0x0000543A File Offset: 0x0000363A
		public string Country { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00005443 File Offset: 0x00003643
		// (set) Token: 0x06000179 RID: 377 RVA: 0x0000544B File Offset: 0x0000364B
		public LogicArrayList<int> ServerSocketTypeList { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00005454 File Offset: 0x00003654
		// (set) Token: 0x0600017B RID: 379 RVA: 0x0000545C File Offset: 0x0000365C
		public LogicArrayList<int> ServerSocketIdList { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00005465 File Offset: 0x00003665
		// (set) Token: 0x0600017D RID: 381 RVA: 0x0000546D File Offset: 0x0000366D
		public BindServerSocketRequestMessage BindRequestMessage { get; set; }

		// Token: 0x0600017E RID: 382 RVA: 0x0000B710 File Offset: 0x00009910
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteString(this.Country);
			stream.WriteVInt(this.ServerSocketTypeList.Size());
			for (int i = 0; i < this.ServerSocketTypeList.Size(); i++)
			{
				stream.WriteVInt(this.ServerSocketTypeList[i]);
				stream.WriteVInt(this.ServerSocketIdList[i]);
			}
			if (this.BindRequestMessage != null)
			{
				stream.WriteBoolean(true);
				this.BindRequestMessage.EncodeHeader(stream);
				this.BindRequestMessage.Encode(stream);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000B7B0 File Offset: 0x000099B0
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.Country = stream.ReadString(900000);
			this.ServerSocketTypeList = new LogicArrayList<int>();
			this.ServerSocketIdList = new LogicArrayList<int>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.ServerSocketTypeList.Add(stream.ReadVInt());
				this.ServerSocketIdList.Add(stream.ReadVInt());
			}
			if (stream.ReadBoolean())
			{
				this.BindRequestMessage = new BindServerSocketRequestMessage();
				this.BindRequestMessage.DecodeHeader(stream);
				this.BindRequestMessage.Decode(stream);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00005476 File Offset: 0x00003676
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.START_SERVER_SESSION;
		}

		// Token: 0x040000EB RID: 235
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000EC RID: 236
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040000ED RID: 237
		[CompilerGenerated]
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x040000EE RID: 238
		[CompilerGenerated]
		private LogicArrayList<int> logicArrayList_1;

		// Token: 0x040000EF RID: 239
		[CompilerGenerated]
		private BindServerSocketRequestMessage bindServerSocketRequestMessage_0;
	}
}
