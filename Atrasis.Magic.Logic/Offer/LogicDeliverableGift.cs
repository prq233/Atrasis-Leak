using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001D RID: 29
	public class LogicDeliverableGift : LogicDeliverableBundle
	{
		// Token: 0x0600012C RID: 300 RVA: 0x00002CCC File Offset: 0x00000ECC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			jsonObject.Put("giftLimit", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00002CF3 File Offset: 0x00000EF3
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "giftLimit");
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00002D0D File Offset: 0x00000F0D
		public override int GetDeliverableType()
		{
			return 6;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002D10 File Offset: 0x00000F10
		public override bool Deliver(LogicLevel level)
		{
			level.GetHomeOwnerAvatar().GetChangeListener().DeliverableAllianceGift(this);
			return true;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002D24 File Offset: 0x00000F24
		public override bool CanBeDeliver(LogicLevel level)
		{
			return level.GetHomeOwnerAvatar().IsInAlliance();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002D31 File Offset: 0x00000F31
		public int GetGiftLimit()
		{
			return this.int_0;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00002D39 File Offset: 0x00000F39
		public void SetGiftLimit(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000074 RID: 116
		private int int_0;
	}
}
