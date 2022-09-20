using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000192 RID: 402
	public sealed class LogicBuyShieldCommand : LogicCommand
	{
		// Token: 0x060016BD RID: 5821 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicBuyShieldCommand()
		{
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x0000EDAB File Offset: 0x0000CFAB
		public LogicBuyShieldCommand(LogicShieldData data)
		{
			this.logicShieldData_0 = data;
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x0000EDBA File Offset: 0x0000CFBA
		public override void Decode(ByteStream stream)
		{
			this.logicShieldData_0 = (LogicShieldData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.SHIELD);
			base.Decode(stream);
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x0000EDD6 File Offset: 0x0000CFD6
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicShieldData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016C1 RID: 5825 RVA: 0x0000EDEB File Offset: 0x0000CFEB
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_SHIELD;
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x0000EDF2 File Offset: 0x0000CFF2
		public override void Destruct()
		{
			base.Destruct();
			this.logicShieldData_0 = null;
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x00057208 File Offset: 0x00055408
		public override int Execute(LogicLevel level)
		{
			if (this.logicShieldData_0 != null && level.GetCooldownManager().GetCooldownSeconds(this.logicShieldData_0.GetGlobalID()) <= 0)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if ((this.logicShieldData_0.GetScoreLimit() > playerAvatar.GetScore() || this.logicShieldData_0.GetScoreLimit() <= 0) && playerAvatar.HasEnoughDiamonds(this.logicShieldData_0.GetDiamondsCost(), true, level))
				{
					LogicGameMode gameMode = level.GetGameMode();
					playerAvatar.UseDiamonds(this.logicShieldData_0.GetDiamondsCost());
					playerAvatar.GetChangeListener().DiamondPurchaseMade(6, this.logicShieldData_0.GetGlobalID(), this.logicShieldData_0.GetTimeHours() * 3600, this.logicShieldData_0.GetDiamondsCost(), level.GetVillageType());
					int num = gameMode.GetShieldRemainingSeconds() + this.logicShieldData_0.GetTimeHours() * 3600;
					int num2 = gameMode.GetGuardRemainingSeconds();
					if (this.logicShieldData_0.GetTimeHours() <= 0)
					{
						if (num > 0)
						{
							return -2;
						}
						num2 += this.logicShieldData_0.GetGuardTimeHours() * 3600;
					}
					else
					{
						LogicLeagueData leagueTypeData = playerAvatar.GetLeagueTypeData();
						if (playerAvatar.GetAttackShieldReduceCounter() != 0)
						{
							playerAvatar.SetAttackShieldReduceCounter(0);
							playerAvatar.GetChangeListener().AttackShieldReduceCounterChanged(0);
						}
						if (playerAvatar.GetDefenseVillageGuardCounter() != 0)
						{
							playerAvatar.SetDefenseVillageGuardCounter(0);
							playerAvatar.GetChangeListener().DefenseVillageGuardCounterChanged(0);
						}
						num2 += leagueTypeData.GetVillageGuardInMins() * 60;
					}
					int personalBreakCooldownSeconds;
					if (num <= 0)
					{
						personalBreakCooldownSeconds = LogicMath.Min(LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds() + this.logicShieldData_0.GetGuardTimeHours() * 3600, gameMode.GetPersonalBreakCooldownSeconds() + this.logicShieldData_0.GetGuardTimeHours() * 3600);
					}
					else
					{
						personalBreakCooldownSeconds = num + LogicDataTables.GetGlobals().GetPersonalBreakLimitSeconds();
					}
					gameMode.SetPersonalBreakCooldownSeconds(personalBreakCooldownSeconds);
					gameMode.SetShieldRemainingSeconds(num);
					gameMode.SetGuardRemainingSeconds(num2);
					level.GetHome().GetChangeListener().ShieldActivated(num, num2);
					level.GetCooldownManager().AddCooldown(this.logicShieldData_0.GetGlobalID(), this.logicShieldData_0.GetCooldownSecs());
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CAA RID: 3242
		private LogicShieldData logicShieldData_0;
	}
}
