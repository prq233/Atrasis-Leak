using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000040 RID: 64
	public class ChangeGameStateMessage : ServerSessionMessage
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000547D File Offset: 0x0000367D
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00005485 File Offset: 0x00003685
		public int LayoutId { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000548E File Offset: 0x0000368E
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00005496 File Offset: 0x00003696
		public int MapId { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000186 RID: 390 RVA: 0x0000549F File Offset: 0x0000369F
		// (set) Token: 0x06000187 RID: 391 RVA: 0x000054A7 File Offset: 0x000036A7
		public GameStateType StateType { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000188 RID: 392 RVA: 0x000054B0 File Offset: 0x000036B0
		// (set) Token: 0x06000189 RID: 393 RVA: 0x000054B8 File Offset: 0x000036B8
		public LogicNpcData NpcData { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600018A RID: 394 RVA: 0x000054C1 File Offset: 0x000036C1
		// (set) Token: 0x0600018B RID: 395 RVA: 0x000054C9 File Offset: 0x000036C9
		public LogicLong HomeId { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600018C RID: 396 RVA: 0x000054D2 File Offset: 0x000036D2
		// (set) Token: 0x0600018D RID: 397 RVA: 0x000054DA File Offset: 0x000036DA
		public int VisitType { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600018E RID: 398 RVA: 0x000054E3 File Offset: 0x000036E3
		// (set) Token: 0x0600018F RID: 399 RVA: 0x000054EB File Offset: 0x000036EB
		public LogicLong ChallengeHomeId { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000190 RID: 400 RVA: 0x000054F4 File Offset: 0x000036F4
		// (set) Token: 0x06000191 RID: 401 RVA: 0x000054FC File Offset: 0x000036FC
		public LogicLong ChallengeStreamId { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00005505 File Offset: 0x00003705
		// (set) Token: 0x06000193 RID: 403 RVA: 0x0000550D File Offset: 0x0000370D
		public LogicLong ChallengeAllianceId { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00005516 File Offset: 0x00003716
		// (set) Token: 0x06000195 RID: 405 RVA: 0x0000551E File Offset: 0x0000371E
		public byte[] ChallengeHomeJSON { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00005527 File Offset: 0x00003727
		// (set) Token: 0x06000197 RID: 407 RVA: 0x0000552F File Offset: 0x0000372F
		public int ChallengeMapId { get; set; }

		// Token: 0x06000198 RID: 408 RVA: 0x0000B850 File Offset: 0x00009A50
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.StateType);
			switch (this.StateType)
			{
			case GameStateType.HOME:
				stream.WriteVInt(this.LayoutId);
				stream.WriteVInt(this.MapId);
				return;
			case GameStateType.NPC_ATTACK:
			case GameStateType.NPC_DUEL:
				ByteStreamHelper.WriteDataReference(stream, this.NpcData);
				return;
			case GameStateType.MATCHED_ATTACK:
			case GameStateType.FAKE_ATTACK:
			case GameStateType.DUEL:
				break;
			case GameStateType.CHALLENGE_ATTACK:
				stream.WriteLong(this.ChallengeHomeId);
				stream.WriteLong(this.ChallengeStreamId);
				stream.WriteLong(this.ChallengeAllianceId);
				stream.WriteBytes(this.ChallengeHomeJSON, this.ChallengeHomeJSON.Length);
				stream.WriteVInt(this.ChallengeMapId);
				break;
			case GameStateType.VISIT:
				stream.WriteLong(this.HomeId);
				stream.WriteVInt(this.VisitType);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000B91C File Offset: 0x00009B1C
		public override void Decode(ByteStream stream)
		{
			this.StateType = (GameStateType)stream.ReadVInt();
			switch (this.StateType)
			{
			case GameStateType.HOME:
				this.LayoutId = stream.ReadVInt();
				this.MapId = stream.ReadVInt();
				return;
			case GameStateType.NPC_ATTACK:
			case GameStateType.NPC_DUEL:
				this.NpcData = (LogicNpcData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.NPC);
				return;
			case GameStateType.MATCHED_ATTACK:
			case GameStateType.FAKE_ATTACK:
			case GameStateType.DUEL:
				break;
			case GameStateType.CHALLENGE_ATTACK:
				this.ChallengeHomeId = stream.ReadLong();
				this.ChallengeStreamId = stream.ReadLong();
				this.ChallengeAllianceId = stream.ReadLong();
				this.ChallengeHomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
				this.ChallengeMapId = stream.ReadVInt();
				break;
			case GameStateType.VISIT:
				this.HomeId = stream.ReadLong();
				this.VisitType = stream.ReadVInt();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00005538 File Offset: 0x00003738
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CHANGE_GAME_STATE;
		}

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000F1 RID: 241
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040000F2 RID: 242
		[CompilerGenerated]
		private GameStateType gameStateType_0;

		// Token: 0x040000F3 RID: 243
		[CompilerGenerated]
		private LogicNpcData logicNpcData_0;

		// Token: 0x040000F4 RID: 244
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000F5 RID: 245
		[CompilerGenerated]
		private int int_4;

		// Token: 0x040000F6 RID: 246
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040000F7 RID: 247
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x040000F8 RID: 248
		[CompilerGenerated]
		private LogicLong logicLong_3;

		// Token: 0x040000F9 RID: 249
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		private int int_5;
	}
}
