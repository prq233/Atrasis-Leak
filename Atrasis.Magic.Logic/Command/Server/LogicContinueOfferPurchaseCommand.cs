using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000176 RID: 374
	public class LogicContinueOfferPurchaseCommand : LogicServerCommand
	{
		// Token: 0x060015FC RID: 5628 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x0000E55D File Offset: 0x0000C75D
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadVInt();
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x0000E572 File Offset: 0x0000C772
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteVInt(this.int_2);
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x00054C00 File Offset: 0x00052E00
		public override int Execute(LogicLevel level)
		{
			if (level.GetState() != 1)
			{
				return -1;
			}
			LogicOffer offerById = level.GetOfferManager().GetOfferById(this.int_2);
			if (offerById.GetState() == 1)
			{
				offerById.SetState(2);
				return 0;
			}
			return -2;
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x0000E587 File Offset: 0x0000C787
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CONTINUE_OFFER_PURCHASE;
		}

		// Token: 0x04000C6C RID: 3180
		private int int_2;
	}
}
