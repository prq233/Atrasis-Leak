using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000045 RID: 69
	public class GameMatchedAttackState : GameState
	{
		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000574D File Offset: 0x0000394D
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00005755 File Offset: 0x00003955
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000575E File Offset: 0x0000395E
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00005766 File Offset: 0x00003966
		public LogicClientAvatar HomeOwnerAvatar { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000576F File Offset: 0x0000396F
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00005777 File Offset: 0x00003977
		public int MaintenanceTime { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00005780 File Offset: 0x00003980
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00005788 File Offset: 0x00003988
		public bool GameDefenderLocked { get; set; }

		// Token: 0x060001D1 RID: 465 RVA: 0x00005791 File Offset: 0x00003991
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.HomeOwnerAvatar.Encode(stream);
			stream.WriteVInt(this.MaintenanceTime);
			stream.WriteBoolean(this.GameDefenderLocked);
			stream.WriteLong(this.LiveReplayId);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.HomeOwnerAvatar = new LogicClientAvatar();
			this.HomeOwnerAvatar.Decode(stream);
			this.MaintenanceTime = stream.ReadVInt();
			this.GameDefenderLocked = stream.ReadBoolean();
			this.LiveReplayId = stream.ReadLong();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000053FE File Offset: 0x000035FE
		public override GameStateType GetGameStateType()
		{
			return GameStateType.MATCHED_ATTACK;
		}

		// Token: 0x04000108 RID: 264
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000109 RID: 265
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x0400010A RID: 266
		[CompilerGenerated]
		private int int_1;

		// Token: 0x0400010B RID: 267
		[CompilerGenerated]
		private bool bool_0;
	}
}
