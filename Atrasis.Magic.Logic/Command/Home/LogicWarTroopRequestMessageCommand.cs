using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001E2 RID: 482
	public sealed class LogicWarTroopRequestMessageCommand : LogicCommand
	{
		// Token: 0x060018CD RID: 6349 RVA: 0x000107DD File Offset: 0x0000E9DD
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x000107F7 File Offset: 0x0000E9F7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x0001080C File Offset: 0x0000EA0C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.WAR_TROOP_REQUEST_MESSAGE;
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x00010813 File Offset: 0x0000EA13
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x0005CE78 File Offset: 0x0005B078
		public override int Execute(LogicLevel level)
		{
			level.SetWarTroopRequestMessage(this.string_0);
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.GetChangeListener().WarTroopRequestMessageChanged(this.string_0);
			}
			return 0;
		}

		// Token: 0x04000D3F RID: 3391
		private string string_0;
	}
}
