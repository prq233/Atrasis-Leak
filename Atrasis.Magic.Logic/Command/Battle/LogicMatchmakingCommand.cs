using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001F0 RID: 496
	public sealed class LogicMatchmakingCommand : LogicCommand
	{
		// Token: 0x0600193B RID: 6459 RVA: 0x00010C5D File Offset: 0x0000EE5D
		public override void Decode(ByteStream stream)
		{
			this.logicResourceData_0 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x00010C84 File Offset: 0x0000EE84
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_0);
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x00010CA5 File Offset: 0x0000EEA5
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MATCHMAKING;
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x00010CAC File Offset: 0x0000EEAC
		public override void Destruct()
		{
			base.Destruct();
			this.logicResourceData_0 = null;
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x0005FF48 File Offset: 0x0005E148
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() == 0)
			{
				if (level.GetState() != 2)
				{
					if (level.GetState() != 1)
					{
						return -3;
					}
				}
				if (this.logicResourceData_0 != null && this.int_1 > 0 && !this.logicResourceData_0.IsPremiumCurrency())
				{
					int resourceDiamondCost = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, this.logicResourceData_0);
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					if (playerAvatar.GetUnusedResourceCap(this.logicResourceData_0) < this.int_1)
					{
						return -1;
					}
					if (!playerAvatar.HasEnoughDiamonds(resourceDiamondCost, true, level))
					{
						return -2;
					}
					playerAvatar.UseDiamonds(resourceDiamondCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(5, this.logicResourceData_0.GetGlobalID(), this.int_1, resourceDiamondCost, level.GetVillageType());
					playerAvatar.CommodityCountChangeHelper(0, this.logicResourceData_0, this.int_1);
				}
				level.GetGameListener().MatchmakingCommandExecuted();
				return 0;
			}
			return -32;
		}

		// Token: 0x04000D9E RID: 3486
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000D9F RID: 3487
		private int int_1;
	}
}
