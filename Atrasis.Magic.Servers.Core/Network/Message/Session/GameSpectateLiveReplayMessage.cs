using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000037 RID: 55
	public class GameSpectateLiveReplayMessage : ServerSessionMessage
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00005268 File Offset: 0x00003468
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00005270 File Offset: 0x00003470
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00005279 File Offset: 0x00003479
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00005281 File Offset: 0x00003481
		public bool IsEnemy { get; set; }

		// Token: 0x06000144 RID: 324 RVA: 0x0000528A File Offset: 0x0000348A
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.LiveReplayId);
			stream.WriteBoolean(this.IsEnemy);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000052A4 File Offset: 0x000034A4
		public override void Decode(ByteStream stream)
		{
			this.LiveReplayId = stream.ReadLong();
			this.IsEnemy = stream.ReadBoolean();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000052BE File Offset: 0x000034BE
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_SPECTATE_LIVE_REPLAY;
		}

		// Token: 0x040000E2 RID: 226
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000E3 RID: 227
		[CompilerGenerated]
		private bool bool_0;
	}
}
