using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CF RID: 463
	public sealed class LogicSpeedUpTroopRequestCommand : LogicCommand
	{
		// Token: 0x0600184E RID: 6222 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x0001013D File Offset: 0x0000E33D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_TROOP_REQUEST;
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x0005B7C4 File Offset: 0x000599C4
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseTroopRequestSpeedUp())
			{
				return -1;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle == null)
			{
				return -3;
			}
			LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
			if (bunkerComponent == null)
			{
				return -4;
			}
			if (playerAvatar.GetAllianceCastleUsedCapacity() >= playerAvatar.GetAllianceCastleTotalCapacity() && playerAvatar.GetAllianceCastleUsedSpellCapacity() >= playerAvatar.GetAllianceCastleTotalSpellCapacity())
			{
				return -5;
			}
			int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(bunkerComponent.GetRequestCooldownTime(), 3, 0);
			if (playerAvatar.HasEnoughDiamonds(speedUpCost, true, level))
			{
				playerAvatar.UseDiamonds(speedUpCost);
				playerAvatar.GetChangeListener().DiamondPurchaseMade(11, 0, 0, speedUpCost, level.GetVillageType());
				bunkerComponent.StopRequestCooldownTime();
				return 0;
			}
			return -6;
		}
	}
}
