using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EF RID: 495
	public sealed class LogicMatchmakeVillage2Command : LogicCommand
	{
		// Token: 0x06001935 RID: 6453 RVA: 0x00010BFF File Offset: 0x0000EDFF
		public override void Decode(ByteStream stream)
		{
			this.logicResourceData_0 = (LogicResourceData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.RESOURCE);
			this.int_1 = stream.ReadVInt();
			base.Decode(stream);
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x00010C26 File Offset: 0x0000EE26
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicResourceData_0);
			encoder.WriteVInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x00010C47 File Offset: 0x0000EE47
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MATCHMAKE_VILLAGE2;
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x00010C4E File Offset: 0x0000EE4E
		public override void Destruct()
		{
			base.Destruct();
			this.logicResourceData_0 = null;
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x0005FE80 File Offset: 0x0005E080
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 1)
			{
				return -32;
			}
			if (!level.IsUnitsTrainedVillage2())
			{
				return -24;
			}
			if (level.GetState() == 1)
			{
				if (this.int_1 > 0)
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					if (playerAvatar.GetUnusedResourceCap(LogicDataTables.GetGold2Data()) < this.int_1)
					{
						return -1;
					}
					int resourceDiamondCost = LogicGamePlayUtil.GetResourceDiamondCost(this.int_1, LogicDataTables.GetGold2Data());
					if (playerAvatar.HasEnoughDiamonds(resourceDiamondCost, true, level))
					{
						return -2;
					}
					playerAvatar.UseDiamonds(resourceDiamondCost);
					playerAvatar.GetChangeListener().DiamondPurchaseMade(5, LogicDataTables.GetGold2Data().GetGlobalID(), this.int_1, resourceDiamondCost, level.GetVillageType());
					playerAvatar.CommodityCountChangeHelper(0, LogicDataTables.GetGold2Data(), this.int_1);
				}
				level.GetGameListener().MatchmakingVillage2CommandExecuted();
				return 0;
			}
			return -3;
		}

		// Token: 0x04000D9C RID: 3484
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000D9D RID: 3485
		private int int_1;
	}
}
