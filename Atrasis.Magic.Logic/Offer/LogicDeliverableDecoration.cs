using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001B RID: 27
	public class LogicDeliverableDecoration : LogicDeliverable
	{
		// Token: 0x06000121 RID: 289 RVA: 0x00002C07 File Offset: 0x00000E07
		public override void Destruct()
		{
			base.Destruct();
			this.logicDecoData_0 = null;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00002C16 File Offset: 0x00000E16
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			LogicJSONHelper.SetLogicData(jsonObject, "decoration", this.logicDecoData_0);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002C30 File Offset: 0x00000E30
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.logicDecoData_0 = (LogicDecoData)LogicJSONHelper.GetLogicData(jsonObject, "decoration");
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetDeliverableType()
		{
			return 3;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00002C52 File Offset: 0x00000E52
		public override bool Deliver(LogicLevel level)
		{
			if (this.CanBeDeliver(level))
			{
				level.AddUnplacedObject(new LogicDataSlot(this.logicDecoData_0, 0));
				return true;
			}
			return false;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00002C72 File Offset: 0x00000E72
		public override bool CanBeDeliver(LogicLevel level)
		{
			return level.GetObjectCount(this.logicDecoData_0, this.logicDecoData_0.GetVillageType()) < this.logicDecoData_0.GetMaxCount();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00002C98 File Offset: 0x00000E98
		public override LogicDeliverableBundle Compensate(LogicLevel level)
		{
			LogicDeliverableBundle logicDeliverableBundle = new LogicDeliverableBundle();
			logicDeliverableBundle.AddResources(this.logicDecoData_0.GetBuildResource(), this.logicDecoData_0.GetBuildCost());
			return logicDeliverableBundle;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00002CBB File Offset: 0x00000EBB
		public LogicDecoData GetDecorationData()
		{
			return this.logicDecoData_0;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00002CC3 File Offset: 0x00000EC3
		public void SetDecorationData(LogicDecoData data)
		{
			this.logicDecoData_0 = data;
		}

		// Token: 0x04000073 RID: 115
		private LogicDecoData logicDecoData_0;
	}
}
