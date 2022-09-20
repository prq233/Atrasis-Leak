using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CD RID: 461
	public sealed class LogicSpeedUpTrainingCommand : LogicCommand
	{
		// Token: 0x06001840 RID: 6208 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSpeedUpTrainingCommand()
		{
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x000100B8 File Offset: 0x0000E2B8
		public LogicSpeedUpTrainingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x000100C7 File Offset: 0x0000E2C7
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x000100E8 File Offset: 0x0000E2E8
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x00010109 File Offset: 0x0000E309
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_TRAINING;
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x00010110 File Offset: 0x0000E310
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				throw new NotImplementedException();
			}
			return this.SpeedUpNewTrainingUnit(level);
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x0005B63C File Offset: 0x0005983C
		public int SpeedUpNewTrainingUnit(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			LogicUnitProduction logicUnitProduction = this.bool_0 ? level.GetGameObjectManager().GetSpellProduction() : level.GetGameObjectManager().GetUnitProduction();
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			int num = LogicGamePlayUtil.GetSpeedUpCost(logicUnitProduction.GetTotalRemainingSeconds(), this.bool_0 ? 1 : 4, level.GetVillageType());
			if (!level.GetMissionManager().IsTutorialFinished() && num > 0 && LogicDataTables.GetGlobals().GetTutorialTrainingSpeedUpCost() >= 0)
			{
				num = LogicDataTables.GetGlobals().GetTutorialTrainingSpeedUpCost();
			}
			if (playerAvatar.HasEnoughDiamonds(num, true, level))
			{
				playerAvatar.UseDiamonds(num);
				logicUnitProduction.SpeedUp();
				playerAvatar.GetChangeListener().DiamondPurchaseMade((logicUnitProduction.GetUnitProductionType() == LogicDataType.CHARACTER) ? 2 : 7, 0, 0, num, level.GetVillageType());
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D1A RID: 3354
		private int int_1;

		// Token: 0x04000D1B RID: 3355
		private bool bool_0;
	}
}
