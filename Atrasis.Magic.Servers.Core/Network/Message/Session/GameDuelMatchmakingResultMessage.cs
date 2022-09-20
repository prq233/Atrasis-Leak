using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000033 RID: 51
	public class GameDuelMatchmakingResultMessage : ServerSessionMessage
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00005137 File Offset: 0x00003337
		// (set) Token: 0x06000125 RID: 293 RVA: 0x0000513F File Offset: 0x0000333F
		public long EnemySessionId { get; set; }

		// Token: 0x06000126 RID: 294 RVA: 0x00005148 File Offset: 0x00003348
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.EnemySessionId);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00005156 File Offset: 0x00003356
		public override void Decode(ByteStream stream)
		{
			this.EnemySessionId = stream.ReadLongLong();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005164 File Offset: 0x00003364
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_DUEL_MATCHMAKING_RESULT;
		}

		// Token: 0x040000DC RID: 220
		[CompilerGenerated]
		private long long_1;
	}
}
