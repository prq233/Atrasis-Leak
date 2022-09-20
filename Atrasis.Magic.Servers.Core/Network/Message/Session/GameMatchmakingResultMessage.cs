using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000036 RID: 54
	public class GameMatchmakingResultMessage : ServerSessionMessage
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00005234 File Offset: 0x00003434
		// (set) Token: 0x0600013B RID: 315 RVA: 0x0000523C File Offset: 0x0000343C
		public LogicLong EnemyId { get; set; }

		// Token: 0x0600013C RID: 316 RVA: 0x00005245 File Offset: 0x00003445
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.EnemyId);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005253 File Offset: 0x00003453
		public override void Decode(ByteStream stream)
		{
			this.EnemyId = stream.ReadLong();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005261 File Offset: 0x00003461
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_MATCHMAKING_RESULT;
		}

		// Token: 0x040000E1 RID: 225
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
