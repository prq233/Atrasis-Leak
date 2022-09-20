using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000042 RID: 66
	public class GameDuelState : GameState
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00005604 File Offset: 0x00003804
		// (set) Token: 0x060001AA RID: 426 RVA: 0x0000560C File Offset: 0x0000380C
		public LogicLong AvatarId { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00005615 File Offset: 0x00003815
		// (set) Token: 0x060001AC RID: 428 RVA: 0x0000561D File Offset: 0x0000381D
		public LogicLong DuelEntryId { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00005626 File Offset: 0x00003826
		// (set) Token: 0x060001AE RID: 430 RVA: 0x0000562E File Offset: 0x0000382E
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x060001AF RID: 431 RVA: 0x00005637 File Offset: 0x00003837
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.AvatarId);
			stream.WriteLong(this.DuelEntryId);
			stream.WriteLong(this.LiveReplayId);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00005664 File Offset: 0x00003864
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.AvatarId = stream.ReadLong();
			this.DuelEntryId = stream.ReadLong();
			this.LiveReplayId = stream.ReadLong();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00005691 File Offset: 0x00003891
		public override GameStateType GetGameStateType()
		{
			return GameStateType.DUEL;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000055F8 File Offset: 0x000037F8
		public override SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.BATTLE;
		}

		// Token: 0x040000FF RID: 255
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000100 RID: 256
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000101 RID: 257
		[CompilerGenerated]
		private LogicLong logicLong_2;
	}
}
