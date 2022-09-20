using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000109 RID: 265
	public static class LogicDonationHelper
	{
		// Token: 0x06000CAD RID: 3245 RVA: 0x0002B87C File Offset: 0x00029A7C
		public static int GetMaxUnitDonationCount(int allianceLevel, int unitType)
		{
			if (unitType == 1)
			{
				return LogicDataTables.GetGlobals().GetMaxSpellDonationCount();
			}
			if (allianceLevel > 0)
			{
				LogicAllianceLevelData allianceLevel2 = LogicDataTables.GetAllianceLevel(allianceLevel);
				if (allianceLevel2 != null)
				{
					return allianceLevel2.GetTroopDonationLimit();
				}
			}
			return LogicDataTables.GetGlobals().GetMaxTroopDonationCount();
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x0002B8B8 File Offset: 0x00029AB8
		public static int GetTotalDonationCapacity(LogicArrayList<DonationContainer> arrayList, LogicCombatItemType unitType)
		{
			if (arrayList != null)
			{
				int num = 0;
				for (int i = 0; i < arrayList.Size(); i++)
				{
					num += arrayList[i].GetDonationCapacity(unitType);
				}
				return num;
			}
			return 0;
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x0002B8F0 File Offset: 0x00029AF0
		public static int GetTotalDonateCount(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemType unitType)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					return arrayList[i].GetTotalDonationCount(unitType);
				}
			}
			return 0;
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x0002B940 File Offset: 0x00029B40
		public static int GetDonateCount(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					return arrayList[i].GetDonationCount(data);
				}
			}
			return 0;
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x0002B990 File Offset: 0x00029B90
		public static bool CanAddDonation(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data, int allianceLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					return arrayList[i].CanAddUnit(data, allianceLevel);
				}
			}
			return true;
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0002B9E4 File Offset: 0x00029BE4
		public static bool CanDonateAnything(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, int allianceLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId) && arrayList[i].IsDonationLimitReached(allianceLevel))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x0002BA38 File Offset: 0x00029C38
		public static void AddDonation(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data, int upgLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			int num = -1;
			int i = 0;
			while (i < arrayList.Size())
			{
				if (!LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					i++;
				}
				else
				{
					num = i;
					IL_3A:
					if (num != -1)
					{
						arrayList[num].AddUnit(data, upgLevel);
						return;
					}
					DonationContainer donationContainer = new DonationContainer(avatarId.Clone());
					donationContainer.AddUnit(data, upgLevel);
					arrayList.Add(donationContainer);
					return;
				}
			}
			goto IL_3A;
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0002BAB0 File Offset: 0x00029CB0
		public static void RemoveDonation(LogicArrayList<DonationContainer> arrayList, LogicLong avatarId, LogicCombatItemData data, int upgLevel)
		{
			Debugger.DoAssert(arrayList != null, "pDonations cannot be null");
			int num = -1;
			for (int i = 0; i < arrayList.Size(); i++)
			{
				if (LogicLong.Equals(arrayList[i].GetAvatarId(), avatarId))
				{
					num = i;
					IL_3A:
					if (num != -1)
					{
						arrayList[num].RemoveUnit(data, upgLevel);
					}
					return;
				}
			}
			goto IL_3A;
		}
	}
}
