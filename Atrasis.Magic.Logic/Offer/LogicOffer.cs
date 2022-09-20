using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000021 RID: 33
	public class LogicOffer
	{
		// Token: 0x06000153 RID: 339 RVA: 0x00002EC4 File Offset: 0x000010C4
		public LogicOffer(LogicOfferData data, LogicLevel level)
		{
			this.logicOfferData_0 = data;
			this.logicLevel_0 = level;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00002EDA File Offset: 0x000010DA
		public LogicOfferData GetData()
		{
			return this.logicOfferData_0;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00002EE2 File Offset: 0x000010E2
		public int GetId()
		{
			return this.logicOfferData_0.GetId();
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00002EEF File Offset: 0x000010EF
		public int GetState()
		{
			return this.int_0;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00002EF7 File Offset: 0x000010F7
		public void SetState(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00017578 File Offset: 0x00015778
		public LogicJSONObject Save()
		{
			if (this.int_1 <= 0)
			{
				return null;
			}
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("data", new LogicJSONNumber(this.logicOfferData_0.GetId()));
			logicJSONObject.Put("pc", new LogicJSONNumber(this.int_1));
			return logicJSONObject;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00002F00 File Offset: 0x00001100
		public void Load(LogicJSONObject jsonObject)
		{
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "pc", 0);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00002F14 File Offset: 0x00001114
		public void AddPayCount(int value)
		{
			this.int_1 += value;
			this.logicLevel_0.GetOfferManager().OfferBuyed(this);
		}

		// Token: 0x0400007A RID: 122
		private readonly LogicLevel logicLevel_0;

		// Token: 0x0400007B RID: 123
		private readonly LogicOfferData logicOfferData_0;

		// Token: 0x0400007C RID: 124
		private int int_0;

		// Token: 0x0400007D RID: 125
		private int int_1;
	}
}
