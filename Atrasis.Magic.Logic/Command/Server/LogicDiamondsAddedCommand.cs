using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000178 RID: 376
	public class LogicDiamondsAddedCommand : LogicServerCommand
	{
		// Token: 0x06001609 RID: 5641 RVA: 0x0000E5E7 File Offset: 0x0000C7E7
		public void SetData(bool free, int diamondCount, int billingPackage, bool bundlePackage, int source, string transactionId)
		{
			this.bool_0 = free;
			this.int_3 = diamondCount;
			this.int_4 = billingPackage;
			this.bool_1 = bundlePackage;
			this.int_2 = source;
			this.string_0 = transactionId;
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x0000E616 File Offset: 0x0000C816
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x00054D44 File Offset: 0x00052F44
		public override void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.bool_1 = stream.ReadBoolean();
			this.int_2 = stream.ReadInt();
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x00054DA8 File Offset: 0x00052FA8
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteBoolean(this.bool_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x00054E04 File Offset: 0x00053004
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() + this.int_3);
				playerAvatar.GetChangeListener().FreeDiamondsAdded(this.int_3, 0);
				if (this.bool_0)
				{
					int freeDiamonds = playerAvatar.GetFreeDiamonds();
					if (this.int_3 < 0)
					{
						if (freeDiamonds - this.int_3 >= 0 && playerAvatar.GetDiamonds() != freeDiamonds)
						{
							playerAvatar.SetFreeDiamonds(freeDiamonds + this.int_3);
						}
					}
					else
					{
						playerAvatar.SetFreeDiamonds(freeDiamonds + this.int_3);
					}
				}
				else
				{
					if (this.int_4 > 0)
					{
						LogicBillingPackageData logicBillingPackageData = (LogicBillingPackageData)LogicDataTables.GetDataById(this.int_4, LogicDataType.BILLING_PACKAGE);
						if (logicBillingPackageData != null && logicBillingPackageData.IsRED() && !this.bool_1)
						{
							int redPackageState = playerAvatar.GetRedPackageState();
							int num = redPackageState | 16;
							if ((redPackageState & 3) != 3)
							{
								num = (int)((long)num & 4294967292L);
							}
							playerAvatar.SetRedPackageState(num);
						}
					}
					level.GetGameListener().DiamondsBought();
					playerAvatar.AddCumulativePurchasedDiamonds(this.int_3);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x00002E34 File Offset: 0x00001034
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DIAMONDS_ADDED;
		}

		// Token: 0x04000C71 RID: 3185
		private bool bool_0;

		// Token: 0x04000C72 RID: 3186
		private bool bool_1;

		// Token: 0x04000C73 RID: 3187
		private int int_2;

		// Token: 0x04000C74 RID: 3188
		private int int_3;

		// Token: 0x04000C75 RID: 3189
		private int int_4;

		// Token: 0x04000C76 RID: 3190
		private string string_0;
	}
}
