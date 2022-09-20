using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000174 RID: 372
	public class LogicChangeAvatarNameCommand : LogicServerCommand
	{
		// Token: 0x060015ED RID: 5613 RVA: 0x0000E483 File Offset: 0x0000C683
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0000E492 File Offset: 0x0000C692
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x0000E4B8 File Offset: 0x0000C6B8
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015F0 RID: 5616 RVA: 0x00054B38 File Offset: 0x00052D38
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetName(this.string_0);
				playerAvatar.SetNameSetByUser(true);
				playerAvatar.SetNameChangeState(this.int_2);
				level.GetGameListener().NameChanged(this.string_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x060015F1 RID: 5617 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_AVATAR_NAME;
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x0000E4D9 File Offset: 0x0000C6D9
		public void SetAvatarName(string avatarName)
		{
			this.string_0 = avatarName;
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x0000E4E2 File Offset: 0x0000C6E2
		public void SetAvatarNameChangeState(int state)
		{
			this.int_2 = state;
		}

		// Token: 0x04000C68 RID: 3176
		private string string_0;

		// Token: 0x04000C69 RID: 3177
		private int int_2;
	}
}
