using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000041 RID: 65
	public class GameChallengeAttackState : GameState
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000553F File Offset: 0x0000373F
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00005547 File Offset: 0x00003747
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00005550 File Offset: 0x00003750
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00005558 File Offset: 0x00003758
		public LogicLong StreamId { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00005561 File Offset: 0x00003761
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00005569 File Offset: 0x00003769
		public LogicLong AllianceId { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00005572 File Offset: 0x00003772
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000557A File Offset: 0x0000377A
		public int MapId { get; set; }

		// Token: 0x060001A4 RID: 420 RVA: 0x00005583 File Offset: 0x00003783
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.LiveReplayId);
			stream.WriteLong(this.StreamId);
			stream.WriteLong(this.AllianceId);
			stream.WriteVInt(this.MapId);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000055BC File Offset: 0x000037BC
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.LiveReplayId = stream.ReadLong();
			this.StreamId = stream.ReadLong();
			this.AllianceId = stream.ReadLong();
			this.MapId = stream.ReadVInt();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000055F5 File Offset: 0x000037F5
		public override GameStateType GetGameStateType()
		{
			return GameStateType.CHALLENGE_ATTACK;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000055F8 File Offset: 0x000037F8
		public override SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.BATTLE;
		}

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000FC RID: 252
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040000FD RID: 253
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x040000FE RID: 254
		[CompilerGenerated]
		private int int_1;
	}
}
