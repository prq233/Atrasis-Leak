using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AF RID: 175
	public class ClientUpdateLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00007831 File Offset: 0x00005A31
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x00007839 File Offset: 0x00005A39
		public int SubTick { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x00007842 File Offset: 0x00005A42
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0000784A File Offset: 0x00005A4A
		public LogicArrayList<LogicCommand> Commands { get; set; }

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.SubTick);
			if (this.Commands != null)
			{
				stream.WriteVInt(this.Commands.Size());
				for (int i = 0; i < this.Commands.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(stream, this.Commands[i]);
				}
				return;
			}
			stream.WriteVInt(-1);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000C808 File Offset: 0x0000AA08
		public override void Decode(ByteStream stream)
		{
			this.SubTick = stream.ReadVInt();
			int num = stream.ReadVInt();
			if (num >= 0)
			{
				this.Commands = new LogicArrayList<LogicCommand>(num);
				for (int i = 0; i < num; i++)
				{
					this.Commands.Add(LogicCommandManager.DecodeCommand(stream));
				}
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00007853 File Offset: 0x00005A53
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CLIENT_UPDATE_LIVE_REPLAY;
		}

		// Token: 0x04000209 RID: 521
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400020A RID: 522
		[CompilerGenerated]
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
