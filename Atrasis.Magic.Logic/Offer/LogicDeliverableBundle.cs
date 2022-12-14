using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001A RID: 26
	public class LogicDeliverableBundle : LogicDeliverable
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00002BBB File Offset: 0x00000DBB
		public LogicDeliverableBundle()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicDeliverable>();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00017264 File Offset: 0x00015464
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicArrayList_0 != null)
			{
				while (this.logicArrayList_0.Size() != 0)
				{
					this.logicArrayList_0[0].Destruct();
					this.logicArrayList_0.Remove(0);
				}
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000172B4 File Offset: 0x000154B4
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				this.logicArrayList_0[i].WriteToJSON(logicJSONObject);
				logicJSONArray.Add(logicJSONObject);
			}
			jsonObject.Put("dels", logicJSONArray);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001731C File Offset: 0x0001551C
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("dels");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONObject jsonobject = jsonarray.GetJSONObject(i);
					if (jsonobject != null)
					{
						this.logicArrayList_0.Add(LogicJSONHelper.GetLogicDeliverable(jsonobject));
					}
				}
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00002BCE File Offset: 0x00000DCE
		public override int GetDeliverableType()
		{
			return 5;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0001736C File Offset: 0x0001556C
		public override bool Deliver(LogicLevel level)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Deliver(level);
			}
			return true;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00002B38 File Offset: 0x00000D38
		public override bool CanBeDeliver(LogicLevel level)
		{
			return true;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00002BD1 File Offset: 0x00000DD1
		public override LogicDeliverableBundle Compensate(LogicLevel level)
		{
			Debugger.Warning("LogicDeliverableBundle cannot handle compensations. Use LogicDeliveryHelper instead.");
			return null;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000173A4 File Offset: 0x000155A4
		public void AddResources(LogicResourceData data, int count)
		{
			LogicDeliverableResource logicDeliverableResource = null;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicDeliverable logicDeliverable = this.logicArrayList_0[i];
				if (logicDeliverable.GetDeliverableType() == 1)
				{
					LogicDeliverableResource logicDeliverableResource2 = (LogicDeliverableResource)logicDeliverable;
					if (logicDeliverableResource2.GetResourceData() == data)
					{
						logicDeliverableResource = logicDeliverableResource2;
						IL_44:
						if (logicDeliverableResource != null)
						{
							logicDeliverableResource.SetResourceAmount(logicDeliverableResource.GetResourceAmount() + count);
							return;
						}
						LogicDeliverableResource logicDeliverableResource3 = new LogicDeliverableResource();
						logicDeliverableResource3.SetResourceData(data);
						logicDeliverableResource3.SetResourceAmount(count);
						this.logicArrayList_0.Add(logicDeliverableResource3);
						return;
					}
				}
			}
			goto IL_44;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00002BDE File Offset: 0x00000DDE
		public void AddDeliverable(LogicDeliverable deliverable)
		{
			this.logicArrayList_0.Add(deliverable);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00002BEC File Offset: 0x00000DEC
		public int GetDeliverableCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00002BF9 File Offset: 0x00000DF9
		public LogicDeliverable GetDeliverable(int index)
		{
			return this.logicArrayList_0[index];
		}

		// Token: 0x04000072 RID: 114
		private LogicArrayList<LogicDeliverable> logicArrayList_0;
	}
}
