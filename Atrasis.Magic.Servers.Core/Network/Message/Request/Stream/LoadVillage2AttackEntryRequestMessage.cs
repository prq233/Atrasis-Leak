using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000094 RID: 148
	public class LoadVillage2AttackEntryRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00006FCD File Offset: 0x000051CD
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00006FD5 File Offset: 0x000051D5
		public LogicLong Id { get; set; }

		// Token: 0x0600040C RID: 1036 RVA: 0x00006FDE File Offset: 0x000051DE
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.Id);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00006FEC File Offset: 0x000051EC
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadLong();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00006FFA File Offset: 0x000051FA
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_REQUEST;
		}

		// Token: 0x040001D4 RID: 468
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
