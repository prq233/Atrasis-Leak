using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200004B RID: 75
	public class GameStateDataMessage : ServerSessionMessage
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00005904 File Offset: 0x00003B04
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000590C File Offset: 0x00003B0C
		public GameState State { get; set; }

		// Token: 0x060001EE RID: 494 RVA: 0x00005915 File Offset: 0x00003B15
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.State.GetGameStateType());
			this.State.Encode(stream);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00005934 File Offset: 0x00003B34
		public override void Decode(ByteStream stream)
		{
			this.State = GameStateFactory.CreateByType((GameStateType)stream.ReadVInt());
			this.State.Decode(stream);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00005953 File Offset: 0x00003B53
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_STATE_DATA;
		}

		// Token: 0x0400011D RID: 285
		[CompilerGenerated]
		private GameState gameState_0;
	}
}
