using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000187 RID: 391
	public class LogicWarLootAwardedCommand : LogicServerCommand
	{
		// Token: 0x06001673 RID: 5747 RVA: 0x00002465 File Offset: 0x00000665
		public void SetDatas(int diamondCount)
		{
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x000561D0 File Offset: 0x000543D0
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_0 = stream.ReadLong();
			}
			base.Decode(stream);
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x00056224 File Offset: 0x00054424
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(0);
			if (this.logicLong_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001677 RID: 5751 RVA: 0x00056288 File Offset: 0x00054488
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.AddWarReward(this.int_2, this.int_3, this.int_4, 0, this.logicLong_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x00003F0B File Offset: 0x0000210B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.WAR_LOOT_AWARDED;
		}

		// Token: 0x04000C95 RID: 3221
		private LogicLong logicLong_0;

		// Token: 0x04000C96 RID: 3222
		private int int_2;

		// Token: 0x04000C97 RID: 3223
		private int int_3;

		// Token: 0x04000C98 RID: 3224
		private int int_4;
	}
}
