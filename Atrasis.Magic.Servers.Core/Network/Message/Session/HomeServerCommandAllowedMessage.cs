using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000039 RID: 57
	public class HomeServerCommandAllowedMessage : ServerSessionMessage
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00005342 File Offset: 0x00003542
		// (set) Token: 0x06000151 RID: 337 RVA: 0x0000534A File Offset: 0x0000354A
		public LogicServerCommand ServerCommand { get; set; }

		// Token: 0x06000152 RID: 338 RVA: 0x00005353 File Offset: 0x00003553
		public override void Encode(ByteStream stream)
		{
			LogicCommandManager.EncodeCommand(stream, this.ServerCommand);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00005361 File Offset: 0x00003561
		public override void Decode(ByteStream stream)
		{
			this.ServerCommand = (LogicServerCommand)LogicCommandManager.DecodeCommand(stream);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005374 File Offset: 0x00003574
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.HOME_SERVER_COMMAND_ALLOWED;
		}

		// Token: 0x040000E6 RID: 230
		[CompilerGenerated]
		private LogicServerCommand logicServerCommand_0;
	}
}
