using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C1 RID: 449
	public sealed class LogicSetClanChatFilterPreferenceCommand : LogicCommand
	{
		// Token: 0x060017EE RID: 6126 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSetClanChatFilterPreferenceCommand()
		{
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x0000FC91 File Offset: 0x0000DE91
		public LogicSetClanChatFilterPreferenceCommand(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x0000FCA0 File Offset: 0x0000DEA0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.bool_0 = stream.ReadBoolean();
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x0000FCB5 File Offset: 0x0000DEB5
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteBoolean(this.bool_0);
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x0000FCCA File Offset: 0x0000DECA
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_CLAN_CHAT_FILTER_PREFERENCE;
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x0005B1E8 File Offset: 0x000593E8
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (this.bool_0 != playerAvatar.GetAllianceChatFilterEnabled())
				{
					playerAvatar.SetAllianceChatFilterEnabled(true);
					level.GetHomeOwnerAvatar().GetChangeListener().AllianceChatFilterChanged(this.bool_0);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D06 RID: 3334
		private bool bool_0;
	}
}
