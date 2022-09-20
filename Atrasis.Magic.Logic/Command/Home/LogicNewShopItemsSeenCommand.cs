using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B0 RID: 432
	public sealed class LogicNewShopItemsSeenCommand : LogicCommand
	{
		// Token: 0x0600177F RID: 6015 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicNewShopItemsSeenCommand()
		{
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x0000F6E5 File Offset: 0x0000D8E5
		public LogicNewShopItemsSeenCommand(int index, int type, int count)
		{
			this.int_1 = index;
			this.logicDataType_0 = (LogicDataType)type;
			this.int_2 = count;
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x0000F702 File Offset: 0x0000D902
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.logicDataType_0 = (LogicDataType)stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x0000F72F File Offset: 0x0000D92F
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt((int)this.logicDataType_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x0000F75C File Offset: 0x0000D95C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.NEW_SHOP_ITEMS_SEEN;
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x00059C94 File Offset: 0x00057E94
		public override int Execute(LogicLevel level)
		{
			if (this.logicDataType_0 != LogicDataType.BUILDING && this.logicDataType_0 != LogicDataType.TRAP)
			{
				if (this.logicDataType_0 != LogicDataType.DECO)
				{
					return -1;
				}
			}
			if (level.SetUnlockedShopItemCount((LogicGameObjectData)LogicDataTables.GetTable(this.logicDataType_0).GetItemAt(this.int_1), this.int_1, this.int_2, level.GetVillageType()))
			{
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CE0 RID: 3296
		private LogicDataType logicDataType_0;

		// Token: 0x04000CE1 RID: 3297
		private int int_1;

		// Token: 0x04000CE2 RID: 3298
		private int int_2;
	}
}
