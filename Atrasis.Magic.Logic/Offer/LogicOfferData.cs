using System;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000022 RID: 34
	public class LogicOfferData
	{
		// Token: 0x0600015B RID: 347 RVA: 0x00002F35 File Offset: 0x00001135
		public int GetId()
		{
			return this.m_offerId;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00002F3D File Offset: 0x0000113D
		public int GetLinkedPackageId()
		{
			return this.m_linkedPackageId;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00002F45 File Offset: 0x00001145
		public int GetShopFrontPageCooldownAfterPurchaseSeconds()
		{
			return this.m_shopFrontPageCooldownAfterPurchaseSecs;
		}

		// Token: 0x0400007E RID: 126
		protected int m_offerId;

		// Token: 0x0400007F RID: 127
		protected int m_linkedPackageId;

		// Token: 0x04000080 RID: 128
		protected int m_shopFrontPageCooldownAfterPurchaseSecs;
	}
}
