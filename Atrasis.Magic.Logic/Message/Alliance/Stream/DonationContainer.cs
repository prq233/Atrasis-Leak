using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E2 RID: 226
	public class DonationContainer
	{
		// Token: 0x060009F3 RID: 2547 RVA: 0x00007A6C File Offset: 0x00005C6C
		public DonationContainer()
		{
			this.logicLong_0 = new LogicLong();
			this.logicArrayList_0 = new LogicArrayList<LogicCombatItemData>();
			this.logicArrayList_1 = new LogicArrayList<int>();
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00007A95 File Offset: 0x00005C95
		public DonationContainer(LogicLong avatarId)
		{
			this.logicLong_0 = avatarId;
			this.logicArrayList_0 = new LogicArrayList<LogicCombatItemData>();
			this.logicArrayList_1 = new LogicArrayList<int>();
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00007ABA File Offset: 0x00005CBA
		public void Destruct()
		{
			this.logicLong_0 = null;
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x000233FC File Offset: 0x000215FC
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				LogicCombatItemData logicCombatItemData = ByteStreamHelper.ReadDataReference(stream) as LogicCombatItemData;
				int item = stream.ReadInt();
				if (logicCombatItemData != null)
				{
					this.logicArrayList_0.Add(logicCombatItemData);
					this.logicArrayList_1.Add(item);
				}
				else
				{
					Debugger.Error("DonationContainer::decode() character data is NULL");
				}
				i++;
			}
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00023464 File Offset: 0x00021664
		public void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			stream.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				ByteStreamHelper.WriteDataReference(stream, this.logicArrayList_0[i]);
				stream.WriteInt(this.logicArrayList_1[i]);
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00007AD1 File Offset: 0x00005CD1
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x000234C8 File Offset: 0x000216C8
		public int GetDonationLimit(int allianceLevel)
		{
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

		// Token: 0x060009FA RID: 2554 RVA: 0x000234F4 File Offset: 0x000216F4
		public bool CanAddUnit(LogicCombatItemData data, int allianceLevel)
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCombatItemType() == data.GetCombatItemType())
				{
					num++;
				}
			}
			return num < ((data.GetCombatItemType() == LogicCombatItemType.SPELL) ? LogicDataTables.GetGlobals().GetMaxSpellDonationCount() : this.GetDonationLimit(allianceLevel));
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00023558 File Offset: 0x00021758
		public bool IsDonationLimitReached(int allianceLevel)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCombatItemType() == LogicCombatItemType.CHARACTER)
				{
					num++;
				}
			}
			if (num >= this.GetDonationLimit(allianceLevel))
			{
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					if (this.logicArrayList_0[j].GetCombatItemType() == LogicCombatItemType.SPELL)
					{
						num2++;
					}
				}
				return num2 >= LogicDataTables.GetGlobals().GetMaxSpellDonationCount();
			}
			return false;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000235E0 File Offset: 0x000217E0
		public void AddUnit(LogicCombatItemData data, int upgLevel)
		{
			if (data != null)
			{
				if (upgLevel < 0)
				{
					int num = this.logicArrayList_0.IndexOf(data);
					if (num != -1)
					{
						upgLevel = this.logicArrayList_1[num];
					}
				}
				this.logicArrayList_0.Add(data);
				this.logicArrayList_1.Add(upgLevel);
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0002362C File Offset: 0x0002182C
		public int GetUnitLevel(LogicCombatItemData data)
		{
			int result = -1;
			int num = this.logicArrayList_0.IndexOf(data);
			if (num != -1)
			{
				result = this.logicArrayList_1[num];
			}
			return result;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0002365C File Offset: 0x0002185C
		public void RemoveUnit(LogicCombatItemData data, int upgLevel)
		{
			if (data != null)
			{
				int num = -1;
				int i = 0;
				while (i < this.logicArrayList_0.Size())
				{
					if (this.logicArrayList_0[i] == data && this.logicArrayList_1[i] == upgLevel)
					{
						num = i;
						IL_3F:
						if (num != -1)
						{
							this.logicArrayList_0.Remove(num);
							this.logicArrayList_1.Remove(num);
							return;
						}
						return;
					}
					else
					{
						i++;
					}
				}
				goto IL_3F;
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x000236C4 File Offset: 0x000218C4
		public void RemoveUnit(LogicCombatItemData data)
		{
			if (data != null)
			{
				int num = this.logicArrayList_0.IndexOf(data);
				if (num != -1)
				{
					this.logicArrayList_0.Remove(num);
					this.logicArrayList_1.Remove(num);
				}
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00023700 File Offset: 0x00021900
		public void RemoveLastUnit(LogicCombatItemData data)
		{
			if (data != null)
			{
				int num = -1;
				int i = this.logicArrayList_0.Size() - 1;
				while (i >= 0)
				{
					if (this.logicArrayList_0[i] == data)
					{
						num = i;
						IL_32:
						if (num != -1)
						{
							this.logicArrayList_0.Remove(num);
							this.logicArrayList_1.Remove(num);
							return;
						}
						return;
					}
					else
					{
						i--;
					}
				}
				goto IL_32;
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0002375C File Offset: 0x0002195C
		public void SetUnitLevel(LogicCombatItemData data, int level)
		{
			int num = this.logicArrayList_0.IndexOf(data);
			if (num != -1)
			{
				this.logicArrayList_1[num] = level;
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00007AD9 File Offset: 0x00005CD9
		public int GetDonationCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00023788 File Offset: 0x00021988
		public int GetTotalDonationCount(LogicCombatItemType unitType)
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCombatItemType() == unitType)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x000237C8 File Offset: 0x000219C8
		public int GetDonationCount(LogicCombatItemData data)
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i] == data)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00023804 File Offset: 0x00021A04
		public int GetDonationCapacity(LogicCombatItemType combatItemType)
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCombatItemType() == combatItemType)
				{
					num += this.logicArrayList_0[i].GetHousingSpace();
				}
			}
			return num;
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00023854 File Offset: 0x00021A54
		public int GetXPReward()
		{
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCombatItemType() == LogicCombatItemType.CHARACTER)
				{
					num += ((LogicCharacterData)this.logicArrayList_0[i]).GetDonateXP();
				}
				else
				{
					num += LogicDataTables.GetGlobals().GetDarkSpellDonationXP() * this.logicArrayList_0[i].GetHousingSpace();
				}
			}
			return num;
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00007AE6 File Offset: 0x00005CE6
		public LogicCombatItemData GetDonationType(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00007AF4 File Offset: 0x00005CF4
		public int GetDonationLevel(int idx)
		{
			return this.logicArrayList_1[idx];
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x000238C8 File Offset: 0x00021AC8
		public LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("avatar_id_high", new LogicJSONNumber(this.logicLong_0.GetHigherInt()));
			logicJSONObject.Put("avatar_id_low", new LogicJSONNumber(this.logicLong_0.GetLowerInt()));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicJSONArray logicJSONArray2 = new LogicJSONArray();
				logicJSONArray2.Add(new LogicJSONNumber(this.logicArrayList_0[i].GetGlobalID()));
				logicJSONArray2.Add(new LogicJSONNumber(this.logicArrayList_1[i]));
				logicJSONArray.Add(logicJSONArray2);
			}
			logicJSONObject.Put("donations", logicJSONArray);
			return logicJSONObject;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00023988 File Offset: 0x00021B88
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("avatar_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("avatar_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_0 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
			}
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("donations");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONArray jsonarray2 = jsonarray.GetJSONArray(i);
					if (jsonarray2 != null && jsonarray2.Size() == 2)
					{
						LogicData dataById = LogicDataTables.GetDataById(jsonarray2.GetJSONNumber(0).GetIntValue());
						if (dataById != null)
						{
							this.logicArrayList_0.Add((LogicCombatItemData)dataById);
							this.logicArrayList_1.Add(jsonarray2.GetJSONNumber(1).GetIntValue());
						}
					}
				}
			}
		}

		// Token: 0x040003E0 RID: 992
		private LogicLong logicLong_0;

		// Token: 0x040003E1 RID: 993
		private LogicArrayList<LogicCombatItemData> logicArrayList_0;

		// Token: 0x040003E2 RID: 994
		private LogicArrayList<int> logicArrayList_1;
	}
}
