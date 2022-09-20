using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003C RID: 60
	public class SendVillage2AttackEntryListToClientMessage : ServerSessionMessage
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000162 RID: 354 RVA: 0x000053AB File Offset: 0x000035AB
		// (set) Token: 0x06000163 RID: 355 RVA: 0x000053B3 File Offset: 0x000035B3
		public LogicArrayList<LogicLong> EntryIds { get; set; }

		// Token: 0x06000164 RID: 356 RVA: 0x0000B68C File Offset: 0x0000988C
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.EntryIds.Size());
			for (int i = 0; i < this.EntryIds.Size(); i++)
			{
				stream.WriteLong(this.EntryIds[i]);
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000B6D4 File Offset: 0x000098D4
		public override void Decode(ByteStream stream)
		{
			this.EntryIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.EntryIds.Add(stream.ReadLong());
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000053BC File Offset: 0x000035BC
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SEND_VILLAGE2_ATTACK_ENTRY_LIST_TO_CLIENT;
		}

		// Token: 0x040000E9 RID: 233
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
