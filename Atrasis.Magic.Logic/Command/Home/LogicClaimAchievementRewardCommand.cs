using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019C RID: 412
	public sealed class LogicClaimAchievementRewardCommand : LogicCommand
	{
		// Token: 0x06001700 RID: 5888 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicClaimAchievementRewardCommand()
		{
		}

		// Token: 0x06001701 RID: 5889 RVA: 0x0000F045 File Offset: 0x0000D245
		public LogicClaimAchievementRewardCommand(LogicAchievementData achievementData)
		{
			this.logicAchievementData_0 = achievementData;
		}

		// Token: 0x06001702 RID: 5890 RVA: 0x0000F054 File Offset: 0x0000D254
		public override void Decode(ByteStream stream)
		{
			this.logicAchievementData_0 = (LogicAchievementData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.ACHIEVEMENT);
			base.Decode(stream);
		}

		// Token: 0x06001703 RID: 5891 RVA: 0x0000F070 File Offset: 0x0000D270
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicAchievementData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001704 RID: 5892 RVA: 0x0000F085 File Offset: 0x0000D285
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CLAIM_ACHIEVEMENT_REWARD;
		}

		// Token: 0x06001705 RID: 5893 RVA: 0x0000F08C File Offset: 0x0000D28C
		public override void Destruct()
		{
			base.Destruct();
			this.logicAchievementData_0 = null;
		}

		// Token: 0x06001706 RID: 5894 RVA: 0x00058138 File Offset: 0x00056338
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && this.logicAchievementData_0 != null && playerAvatar.IsAchievementCompleted(this.logicAchievementData_0) && !playerAvatar.IsAchievementRewardClaimed(this.logicAchievementData_0))
			{
				playerAvatar.XpGainHelper(this.logicAchievementData_0.GetExpReward());
				if (this.logicAchievementData_0.GetDiamondReward() > 0)
				{
					int diamondReward = this.logicAchievementData_0.GetDiamondReward();
					playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() + diamondReward);
					playerAvatar.SetFreeDiamonds(playerAvatar.GetFreeDiamonds() + diamondReward);
					playerAvatar.GetChangeListener().FreeDiamondsAdded(diamondReward, 4);
				}
				playerAvatar.SetAchievementRewardClaimed(this.logicAchievementData_0, true);
				playerAvatar.GetChangeListener().CommodityCountChanged(1, this.logicAchievementData_0, 1);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CBE RID: 3262
		private LogicAchievementData logicAchievementData_0;
	}
}
