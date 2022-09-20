using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000180 RID: 384
	public class LogicOfferStateUpdatedCommand : LogicServerCommand
	{
		// Token: 0x06001641 RID: 5697 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x0000E890 File Offset: 0x0000CA90
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x0000E8B1 File Offset: 0x0000CAB1
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x00055D78 File Offset: 0x00053F78
		public override int Execute(LogicLevel level)
		{
			LogicOffer offerById = level.GetOfferManager().GetOfferById(this.int_3);
			if (offerById != null)
			{
				offerById.SetState(this.int_2);
				return 0;
			}
			Debugger.Warning(string.Format("Offer not found when updating offer state for id: {0} to state: {1}", this.int_3, this.int_2));
			return -2;
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x0000E8D2 File Offset: 0x0000CAD2
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.OFFER_STATE_UPDATED;
		}

		// Token: 0x04000C8C RID: 3212
		private int int_2;

		// Token: 0x04000C8D RID: 3213
		private int int_3;
	}
}
