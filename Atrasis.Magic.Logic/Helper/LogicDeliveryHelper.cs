using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000108 RID: 264
	public static class LogicDeliveryHelper
	{
		// Token: 0x06000CAC RID: 3244 RVA: 0x0002B808 File Offset: 0x00029A08
		public static void Deliver(LogicLevel level, LogicDeliverable deliverable)
		{
			Debugger.DoAssert(deliverable != null, "Deliverable is null!");
			if (deliverable.GetDeliverableType() == 5)
			{
				LogicDeliverableBundle logicDeliverableBundle = (LogicDeliverableBundle)deliverable;
				for (int i = 0; i < logicDeliverableBundle.GetDeliverableCount(); i++)
				{
					LogicDeliveryHelper.Deliver(level, logicDeliverableBundle.GetDeliverable(i));
				}
				return;
			}
			if (!deliverable.Deliver(level))
			{
				LogicDeliverable logicDeliverable = deliverable.Compensate(level);
				if (logicDeliverable != null && !logicDeliverable.Deliver(level))
				{
					Debugger.Error("Delivery compensation failed!");
				}
			}
		}
	}
}
