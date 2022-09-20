using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009E RID: 158
	public class ServerLogMessage : ServerCoreMessage
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000071EF File Offset: 0x000053EF
		// (set) Token: 0x06000443 RID: 1091 RVA: 0x000071F7 File Offset: 0x000053F7
		public int LogType { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x00007200 File Offset: 0x00005400
		// (set) Token: 0x06000445 RID: 1093 RVA: 0x00007208 File Offset: 0x00005408
		public string Message { get; set; }

		// Token: 0x06000446 RID: 1094 RVA: 0x00007211 File Offset: 0x00005411
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.LogType);
			stream.WriteString(this.Message);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000722B File Offset: 0x0000542B
		public override void Decode(ByteStream stream)
		{
			this.LogType = stream.ReadVInt();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000724A File Offset: 0x0000544A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_LOG;
		}

		// Token: 0x040001DD RID: 477
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001DE RID: 478
		[CompilerGenerated]
		private string string_0;
	}
}
