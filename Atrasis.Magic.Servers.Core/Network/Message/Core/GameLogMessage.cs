using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x02000098 RID: 152
	public class GameLogMessage : ServerCoreMessage
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x000070FC File Offset: 0x000052FC
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x00007104 File Offset: 0x00005304
		public int LogType { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000710D File Offset: 0x0000530D
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00007115 File Offset: 0x00005315
		public string Message { get; set; }

		// Token: 0x06000428 RID: 1064 RVA: 0x0000711E File Offset: 0x0000531E
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.LogType);
			stream.WriteString(this.Message);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00007138 File Offset: 0x00005338
		public override void Decode(ByteStream stream)
		{
			this.LogType = stream.ReadVInt();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00007157 File Offset: 0x00005357
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_LOG;
		}

		// Token: 0x040001D9 RID: 473
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001DA RID: 474
		[CompilerGenerated]
		private string string_0;
	}
}
