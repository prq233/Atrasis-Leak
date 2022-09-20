using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000185 RID: 389
	public class LogicTransactionsRevokedCommand : LogicServerCommand
	{
		// Token: 0x06001664 RID: 5732 RVA: 0x0000E9F1 File Offset: 0x0000CBF1
		public void SetAmount(int diamondCount)
		{
			this.int_2 = diamondCount;
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x0000E9FA File Offset: 0x0000CBFA
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x0000EA0F File Offset: 0x0000CC0F
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x0005602C File Offset: 0x0005422C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() - this.int_2);
				if (playerAvatar.GetFreeDiamonds() > playerAvatar.GetDiamonds())
				{
					playerAvatar.SetFreeDiamonds(playerAvatar.GetDiamonds());
				}
				playerAvatar.AddCumulativePurchasedDiamonds(-this.int_2);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x00007719 File Offset: 0x00005919
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRANSACTIONS_REVOKED;
		}

		// Token: 0x04000C93 RID: 3219
		private int int_2;
	}
}
