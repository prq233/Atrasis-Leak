using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018D RID: 397
	public sealed class LogicBoostTrainingCommand : LogicCommand
	{
		// Token: 0x0600169B RID: 5787 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicBoostTrainingCommand()
		{
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0000EBAB File Offset: 0x0000CDAB
		public LogicBoostTrainingCommand(int productionType)
		{
			this.int_1 = productionType;
		}

		// Token: 0x0600169D RID: 5789 RVA: 0x0000EBBA File Offset: 0x0000CDBA
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x0000EBCF File Offset: 0x0000CDCF
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x0000EBE4 File Offset: 0x0000CDE4
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BOOST_TRAINING;
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x00056A64 File Offset: 0x00054C64
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			LogicUnitProduction logicUnitProduction = (this.int_1 == 1) ? level.GetGameObjectManagerAt(0).GetSpellProduction() : level.GetGameObjectManagerAt(0).GetUnitProduction();
			if (!logicUnitProduction.CanBeBoosted())
			{
				return -1;
			}
			int boostCost = logicUnitProduction.GetBoostCost();
			if (playerAvatar.HasEnoughDiamonds(boostCost, true, level))
			{
				playerAvatar.UseDiamonds(boostCost);
				playerAvatar.GetChangeListener().DiamondPurchaseMade(15, 0, 0, boostCost, level.GetVillageType());
				logicUnitProduction.Boost();
				return 0;
			}
			return -2;
		}

		// Token: 0x04000C9E RID: 3230
		private int int_1;
	}
}
