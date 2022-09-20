using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001CE RID: 462
	public sealed class LogicSpeedUpTrainingVillage2Command : LogicCommand
	{
		// Token: 0x06001848 RID: 6216 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x00010136 File Offset: 0x0000E336
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SPEED_UP_TRAINING_VILLAGE_2;
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x0005B708 File Offset: 0x00059908
		public override int Execute(LogicLevel level)
		{
			LogicArrayList<LogicComponent> components = level.GetComponentManager().GetComponents(LogicComponentType.VILLAGE2_UNIT);
			int num = 0;
			for (int i = 0; i < components.Size(); i++)
			{
				num += ((LogicVillage2UnitComponent)components[i]).GetRemainingSecs();
			}
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			int speedUpCost = LogicGamePlayUtil.GetSpeedUpCost(num, 4, 1);
			if (!playerAvatar.HasEnoughDiamonds(speedUpCost, true, level))
			{
				return -1;
			}
			playerAvatar.UseDiamonds(speedUpCost);
			for (int j = 0; j < components.Size(); j++)
			{
				LogicVillage2UnitComponent logicVillage2UnitComponent = (LogicVillage2UnitComponent)components[j];
				if (logicVillage2UnitComponent.GetCurrentlyTrainedUnit() != null && logicVillage2UnitComponent.GetRemainingSecs() > 0)
				{
					logicVillage2UnitComponent.ProductionCompleted();
				}
			}
			playerAvatar.GetChangeListener().DiamondPurchaseMade(16, 0, 0, speedUpCost, 1);
			return 0;
		}
	}
}
