using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BE RID: 446
	public sealed class LogicSendAllianceMailCommand : LogicCommand
	{
		// Token: 0x060017DB RID: 6107 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSendAllianceMailCommand()
		{
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x0000FBC4 File Offset: 0x0000DDC4
		public LogicSendAllianceMailCommand(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x0000FBD3 File Offset: 0x0000DDD3
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x0000FBED File Offset: 0x0000DDED
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x0000FC02 File Offset: 0x0000DE02
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SEND_ALLIANCE_MAIL;
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x0000FC09 File Offset: 0x0000DE09
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060017E1 RID: 6113 RVA: 0x0005AF8C File Offset: 0x0005918C
		public override int Execute(LogicLevel level)
		{
			LogicAvatarAllianceRole allianceRole = level.GetHomeOwnerAvatar().GetAllianceRole();
			if (allianceRole != LogicAvatarAllianceRole.LEADER)
			{
				if (allianceRole != LogicAvatarAllianceRole.CO_LEADER)
				{
					return -1;
				}
			}
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null && bunkerComponent.GetClanMailCooldownTime() == 0)
				{
					bunkerComponent.StartClanMailCooldownTime();
					level.GetHomeOwnerAvatar().GetChangeListener().SendClanMail(this.string_0);
					return 0;
				}
			}
			return -2;
		}

		// Token: 0x04000D01 RID: 3329
		private string string_0;
	}
}
