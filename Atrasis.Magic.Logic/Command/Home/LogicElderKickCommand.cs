using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A1 RID: 417
	public sealed class LogicElderKickCommand : LogicCommand
	{
		// Token: 0x06001721 RID: 5921 RVA: 0x0000F169 File Offset: 0x0000D369
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.string_0 = stream.ReadString(900000);
			}
			base.Decode(stream);
		}

		// Token: 0x06001722 RID: 5922 RVA: 0x0000F197 File Offset: 0x0000D397
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			if (this.string_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteString(this.string_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001723 RID: 5923 RVA: 0x0000F1D0 File Offset: 0x0000D3D0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ELDER_KICK;
		}

		// Token: 0x06001724 RID: 5924 RVA: 0x0000F1D7 File Offset: 0x0000D3D7
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
		}

		// Token: 0x06001725 RID: 5925 RVA: 0x000587C8 File Offset: 0x000569C8
		public override int Execute(LogicLevel level)
		{
			LogicAvatarAllianceRole allianceRole = level.GetHomeOwnerAvatar().GetAllianceRole();
			if (allianceRole != LogicAvatarAllianceRole.MEMBER)
			{
				if (allianceRole != LogicAvatarAllianceRole.LEADER)
				{
					if (allianceRole != LogicAvatarAllianceRole.CO_LEADER)
					{
						LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
						if (allianceCastle != null)
						{
							LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
							if (bunkerComponent != null && bunkerComponent.GetElderCooldownTime() == 0)
							{
								bunkerComponent.StartElderKickCooldownTime();
								level.GetHomeOwnerAvatar().GetChangeListener().KickPlayer(this.logicLong_0, this.string_0);
								return 0;
							}
						}
						return -2;
					}
				}
				level.GetHomeOwnerAvatar().GetChangeListener().KickPlayer(this.logicLong_0, this.string_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CC3 RID: 3267
		private LogicLong logicLong_0;

		// Token: 0x04000CC4 RID: 3268
		private string string_0;
	}
}
