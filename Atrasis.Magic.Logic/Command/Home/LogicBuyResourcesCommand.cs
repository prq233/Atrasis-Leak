using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000191 RID: 401
	public sealed class LogicBuyResourcesCommand : LogicCommand
	{
		// Token: 0x060016B6 RID: 5814 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicBuyResourcesCommand()
		{
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x0000ED47 File Offset: 0x0000CF47
		public LogicBuyResourcesCommand(LogicResourceData data, int resourceCount, LogicResourceData resource2Data, int resource2Count, LogicCommand resourceCommand)
		{
			this.logicResourceData_0 = data;
			this.logicResourceData_1 = resource2Data;
			this.logicCommand_0 = resourceCommand;
			this.int_1 = resourceCount;
			this.int_2 = resource2Count;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x00056F28 File Offset: 0x00055128
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.logicResourceData_0 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			this.int_2 = stream.ReadInt();
			if (this.int_2 > 0)
			{
				this.logicResourceData_1 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			}
			if (stream.ReadBoolean())
			{
				this.logicCommand_0 = LogicCommandManager.DecodeCommand(stream);
			}
			base.Decode(stream);
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x00056F98 File Offset: 0x00055198
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_0);
			encoder.WriteInt(this.int_2);
			if (this.int_2 > 0)
			{
				ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_1);
			}
			if (this.logicCommand_0 != null)
			{
				encoder.WriteBoolean(true);
				LogicCommandManager.EncodeCommand(encoder, this.logicCommand_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x0000ED74 File Offset: 0x0000CF74
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_RESOURCES;
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x0000ED7B File Offset: 0x0000CF7B
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicCommand_0 != null)
			{
				this.logicCommand_0.Destruct();
				this.logicCommand_0 = null;
			}
			this.logicResourceData_0 = null;
			this.logicResourceData_1 = null;
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x0005700C File Offset: 0x0005520C
		public override int Execute(LogicLevel level)
		{
			if (this.logicResourceData_0 != null && this.int_1 > 0 && !this.logicResourceData_0.IsPremiumCurrency())
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (this.logicResourceData_1 != null && this.int_2 > 0)
				{
					if (playerAvatar.GetUnusedResourceCap(this.logicResourceData_0) >= this.int_1 && playerAvatar.GetUnusedResourceCap(this.logicResourceData_1) >= this.int_2)
					{
						int resourceDiamondCost = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, this.logicResourceData_0);
						int resourceDiamondCost2 = LogicGamePlayUtil.GetResourceDiamondCost(this.int_2, this.logicResourceData_1);
						if (playerAvatar.HasEnoughDiamonds(resourceDiamondCost + resourceDiamondCost2, true, level))
						{
							playerAvatar.UseDiamonds(resourceDiamondCost + resourceDiamondCost2);
							playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, this.int_1);
							playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_1, this.int_2);
							playerAvatar.GetChangeListener().DiamondPurchaseMade(5, this.logicResourceData_1.GetGlobalID(), this.int_2, resourceDiamondCost + resourceDiamondCost2, level.GetVillageType());
							if (this.logicCommand_0 != null)
							{
								int commandType = (int)this.logicCommand_0.GetCommandType();
								if (commandType < 1000 && commandType >= 500 && commandType < 700)
								{
									this.logicCommand_0.Execute(level);
								}
							}
							return 0;
						}
					}
				}
				else if (playerAvatar.GetUnusedResourceCap(this.logicResourceData_0) >= this.int_1)
				{
					int resourceDiamondCost3 = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, this.logicResourceData_0);
					if (playerAvatar.HasEnoughDiamonds(resourceDiamondCost3, true, level))
					{
						playerAvatar.UseDiamonds(resourceDiamondCost3);
						playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, this.int_1);
						playerAvatar.GetChangeListener().DiamondPurchaseMade(5, this.logicResourceData_0.GetGlobalID(), this.int_1, resourceDiamondCost3, level.GetVillageType());
						if (this.logicCommand_0 != null)
						{
							int commandType2 = (int)this.logicCommand_0.GetCommandType();
							if (commandType2 < 1000 && commandType2 >= 500 && commandType2 < 700)
							{
								this.logicCommand_0.Execute(level);
							}
						}
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000CA5 RID: 3237
		private LogicCommand logicCommand_0;

		// Token: 0x04000CA6 RID: 3238
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000CA7 RID: 3239
		private LogicResourceData logicResourceData_1;

		// Token: 0x04000CA8 RID: 3240
		private int int_1;

		// Token: 0x04000CA9 RID: 3241
		private int int_2;
	}
}
