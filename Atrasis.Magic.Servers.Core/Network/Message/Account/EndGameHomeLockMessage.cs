using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B4 RID: 180
	public class EndGameHomeLockMessage : ServerAccountMessage
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x000079EF File Offset: 0x00005BEF
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x000079F7 File Offset: 0x00005BF7
		public LogicLong AttackerId { get; set; }

		// Token: 0x0600050E RID: 1294 RVA: 0x00007A00 File Offset: 0x00005C00
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AttackerId);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00007A0E File Offset: 0x00005C0E
		public override void Decode(ByteStream stream)
		{
			this.AttackerId = stream.ReadLong();
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00007A1C File Offset: 0x00005C1C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.END_GAME_HOME_LOCK;
		}

		// Token: 0x04000216 RID: 534
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
