using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000043 RID: 67
	public class GameFakeAttackState : GameState
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00005694 File Offset: 0x00003894
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x0000569C File Offset: 0x0000389C
		public LogicClientAvatar HomeOwnerAvatar { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x000056A5 File Offset: 0x000038A5
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x000056AD File Offset: 0x000038AD
		public int MaintenanceTime { get; set; }

		// Token: 0x060001B8 RID: 440 RVA: 0x000056B6 File Offset: 0x000038B6
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.HomeOwnerAvatar.Encode(stream);
			stream.WriteVInt(this.MaintenanceTime);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000056D7 File Offset: 0x000038D7
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.HomeOwnerAvatar = new LogicClientAvatar();
			this.HomeOwnerAvatar.Decode(stream);
			this.MaintenanceTime = stream.ReadVInt();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00005703 File Offset: 0x00003903
		public override GameStateType GetGameStateType()
		{
			return GameStateType.FAKE_ATTACK;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000055F8 File Offset: 0x000037F8
		public override SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.BATTLE;
		}

		// Token: 0x04000102 RID: 258
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x04000103 RID: 259
		[CompilerGenerated]
		private int int_1;
	}
}
