using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000031 RID: 49
	public class GameAllianceDonationCountMessage : ServerAccountMessage
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000116 RID: 278 RVA: 0x0000508B File Offset: 0x0000328B
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00005093 File Offset: 0x00003293
		public int DonationCount { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000509C File Offset: 0x0000329C
		// (set) Token: 0x06000119 RID: 281 RVA: 0x000050A4 File Offset: 0x000032A4
		public int ReceivedDonationCount { get; set; }

		// Token: 0x0600011A RID: 282 RVA: 0x000050AD File Offset: 0x000032AD
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.DonationCount);
			stream.WriteVInt(this.ReceivedDonationCount);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000050C7 File Offset: 0x000032C7
		public override void Decode(ByteStream stream)
		{
			this.DonationCount = stream.ReadVInt();
			this.ReceivedDonationCount = stream.ReadVInt();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000050E1 File Offset: 0x000032E1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_ALLIANCE_DONATION_COUNT;
		}

		// Token: 0x040000D9 RID: 217
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000DA RID: 218
		[CompilerGenerated]
		private int int_3;
	}
}
