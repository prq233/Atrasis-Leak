using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B7 RID: 183
	public class GameHomeProtectionUpdateMessage : ServerAccountMessage
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00007A63 File Offset: 0x00005C63
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00007A6B File Offset: 0x00005C6B
		public int ShieldTime { get; set; } = -1;

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00007A74 File Offset: 0x00005C74
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x00007A7C File Offset: 0x00005C7C
		public int GuardTime { get; set; } = -1;

		// Token: 0x06000520 RID: 1312 RVA: 0x00007A85 File Offset: 0x00005C85
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ShieldTime);
			stream.WriteVInt(this.GuardTime);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00007A9F File Offset: 0x00005C9F
		public override void Decode(ByteStream stream)
		{
			this.ShieldTime = stream.ReadVInt();
			this.GuardTime = stream.ReadVInt();
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00007AB9 File Offset: 0x00005CB9
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_HOME_PROTECTION_UPDATE;
		}

		// Token: 0x04000218 RID: 536
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000219 RID: 537
		[CompilerGenerated]
		private int int_3;
	}
}
