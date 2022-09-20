using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000182 RID: 386
	public class LogicResetAvatarNameChangeStateCommand : LogicServerCommand
	{
		// Token: 0x0600164E RID: 5710 RVA: 0x0000E25A File Offset: 0x0000C45A
		public LogicResetAvatarNameChangeStateCommand()
		{
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x0000E923 File Offset: 0x0000CB23
		public LogicResetAvatarNameChangeStateCommand(int state)
		{
			this.int_2 = state;
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x0000E932 File Offset: 0x0000CB32
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x0000E947 File Offset: 0x0000CB47
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x06001653 RID: 5715 RVA: 0x0000E95C File Offset: 0x0000CB5C
		public override int Execute(LogicLevel level)
		{
			if (level.GetPlayerAvatar() != null)
			{
				level.GetPlayerAvatar().SetNameChangeState(this.int_2);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0000746C File Offset: 0x0000566C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.RESET_AVATAR_NAME_CHANGE_STATE;
		}

		// Token: 0x04000C8F RID: 3215
		private int int_2;
	}
}
