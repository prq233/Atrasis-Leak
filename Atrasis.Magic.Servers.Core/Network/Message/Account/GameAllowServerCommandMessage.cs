using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B6 RID: 182
	public class GameAllowServerCommandMessage : ServerAccountMessage
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00007A2A File Offset: 0x00005C2A
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x00007A32 File Offset: 0x00005C32
		public LogicServerCommand ServerCommand { get; set; }

		// Token: 0x06000518 RID: 1304 RVA: 0x00007A3B File Offset: 0x00005C3B
		public override void Encode(ByteStream stream)
		{
			LogicCommandManager.EncodeCommand(stream, this.ServerCommand);
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00007A49 File Offset: 0x00005C49
		public override void Decode(ByteStream stream)
		{
			this.ServerCommand = (LogicServerCommand)LogicCommandManager.DecodeCommand(stream);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00007A5C File Offset: 0x00005C5C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_ALLOW_SERVER_COMMAND;
		}

		// Token: 0x04000217 RID: 535
		[CompilerGenerated]
		private LogicServerCommand logicServerCommand_0;
	}
}
