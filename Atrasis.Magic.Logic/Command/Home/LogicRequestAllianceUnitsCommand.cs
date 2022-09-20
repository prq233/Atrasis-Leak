using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B8 RID: 440
	public sealed class LogicRequestAllianceUnitsCommand : LogicCommand
	{
		// Token: 0x060017B1 RID: 6065 RVA: 0x0000F9E7 File Offset: 0x0000DBE7
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			if (stream.ReadBoolean())
			{
				this.string_0 = stream.ReadString(900000);
			}
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x0000FA09 File Offset: 0x0000DC09
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			if (this.string_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteString(this.string_0);
				return;
			}
			encoder.WriteBoolean(false);
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x0000FA35 File Offset: 0x0000DC35
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REQUEST_ALLIANCE_UNITS;
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x0000FA3C File Offset: 0x0000DC3C
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x0005A640 File Offset: 0x00058840
		public override int Execute(LogicLevel level)
		{
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle != null)
			{
				LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
				if (bunkerComponent != null && bunkerComponent.GetRequestCooldownTime() == 0)
				{
					LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
					homeOwnerAvatar.GetChangeListener().RequestAllianceUnits(allianceCastle.GetUpgradeLevel(), bunkerComponent.GetUsedCapacity(), bunkerComponent.GetMaxCapacity(), homeOwnerAvatar.GetAllianceCastleUsedSpellCapacity(), homeOwnerAvatar.GetAllianceCastleTotalSpellCapacity(), this.string_0);
					bunkerComponent.StartRequestCooldownTime();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CF3 RID: 3315
		private string string_0;
	}
}
