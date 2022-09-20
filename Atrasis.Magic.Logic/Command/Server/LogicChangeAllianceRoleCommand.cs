using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000173 RID: 371
	public class LogicChangeAllianceRoleCommand : LogicServerCommand
	{
		// Token: 0x060015E6 RID: 5606 RVA: 0x0000E422 File Offset: 0x0000C622
		public void SetData(LogicLong allianceId, LogicAvatarAllianceRole allianceRole)
		{
			this.logicLong_0 = allianceId;
			this.logicAvatarAllianceRole_0 = allianceRole;
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x0000E432 File Offset: 0x0000C632
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x060015E8 RID: 5608 RVA: 0x0000E441 File Offset: 0x0000C641
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.logicAvatarAllianceRole_0 = (LogicAvatarAllianceRole)stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015E9 RID: 5609 RVA: 0x0000E462 File Offset: 0x0000C662
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt((int)this.logicAvatarAllianceRole_0);
			base.Encode(encoder);
		}

		// Token: 0x060015EA RID: 5610 RVA: 0x00054AF4 File Offset: 0x00052CF4
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (playerAvatar.IsInAlliance() && LogicLong.Equals(playerAvatar.GetAllianceId(), this.logicLong_0))
				{
					playerAvatar.SetAllianceRole(this.logicAvatarAllianceRole_0);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x0000A171 File Offset: 0x00008371
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_ALLIANCE_ROLE;
		}

		// Token: 0x04000C66 RID: 3174
		private LogicLong logicLong_0;

		// Token: 0x04000C67 RID: 3175
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;
	}
}
