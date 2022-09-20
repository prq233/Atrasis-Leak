using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017C RID: 380
	public class LogicDuelLootAwardedCommand : LogicServerCommand
	{
		// Token: 0x06001624 RID: 5668 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x000559EC File Offset: 0x00053BEC
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			stream.ReadInt();
			this.logicLong_0 = stream.ReadLong();
			base.Decode(stream);
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x00055A44 File Offset: 0x00053C44
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(0);
			encoder.WriteLong(this.logicLong_0);
			base.Encode(encoder);
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x00055A9C File Offset: 0x00053C9C
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.AddDuelReward(this.int_2, this.int_3, this.int_4, this.int_5, this.logicLong_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001628 RID: 5672 RVA: 0x0000E785 File Offset: 0x0000C985
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DUEL_LOOT_AWARDED;
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x0000E789 File Offset: 0x0000C989
		public void SetDatas(int goldCount, int elixirCount, int bonusGoldCount, int bonusElixirCount, LogicLong matchId)
		{
			this.int_2 = goldCount;
			this.int_3 = elixirCount;
			this.int_4 = bonusGoldCount;
			this.int_5 = bonusElixirCount;
			this.logicLong_0 = matchId;
		}

		// Token: 0x04000C7E RID: 3198
		private int int_2;

		// Token: 0x04000C7F RID: 3199
		private int int_3;

		// Token: 0x04000C80 RID: 3200
		private int int_4;

		// Token: 0x04000C81 RID: 3201
		private int int_5;

		// Token: 0x04000C82 RID: 3202
		private LogicLong logicLong_0;
	}
}
