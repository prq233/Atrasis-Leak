using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000048 RID: 72
	public abstract class GameState
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000585C File Offset: 0x00003A5C
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00005864 File Offset: 0x00003A64
		public LogicClientAvatar PlayerAvatar { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000586D File Offset: 0x00003A6D
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00005875 File Offset: 0x00003A75
		public LogicClientHome Home { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000587E File Offset: 0x00003A7E
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00005886 File Offset: 0x00003A86
		public int SaveTime { get; set; } = -1;

		// Token: 0x060001E7 RID: 487 RVA: 0x0000588F File Offset: 0x00003A8F
		public virtual void Encode(ByteStream stream)
		{
			this.PlayerAvatar.Encode(stream);
			this.Home.Encode(stream);
			stream.WriteVInt(this.SaveTime);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000058B5 File Offset: 0x00003AB5
		public virtual void Decode(ByteStream stream)
		{
			this.PlayerAvatar = new LogicClientAvatar();
			this.PlayerAvatar.Decode(stream);
			this.Home = new LogicClientHome();
			this.Home.Decode(stream);
			this.SaveTime = stream.ReadVInt();
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000058F1 File Offset: 0x00003AF1
		public virtual SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.HOME;
		}

		// Token: 0x060001EA RID: 490
		public abstract GameStateType GetGameStateType();

		// Token: 0x0400010E RID: 270
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x0400010F RID: 271
		[CompilerGenerated]
		private LogicClientHome logicClientHome_0;

		// Token: 0x04000110 RID: 272
		[CompilerGenerated]
		private int int_0;
	}
}
