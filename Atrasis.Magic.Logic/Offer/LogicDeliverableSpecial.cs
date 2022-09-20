using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000020 RID: 32
	public class LogicDeliverableSpecial : LogicDeliverable
	{
		// Token: 0x06000149 RID: 329 RVA: 0x00002E59 File Offset: 0x00001059
		public LogicDeliverableSpecial()
		{
			this.int_0 = -1;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00002E68 File Offset: 0x00001068
		public override void Destruct()
		{
			base.Destruct();
			this.int_0 = -1;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00002E77 File Offset: 0x00001077
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			jsonObject.Put("id", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00002E96 File Offset: 0x00001096
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "id");
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00002EB0 File Offset: 0x000010B0
		public override int GetDeliverableType()
		{
			return 4;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00017530 File Offset: 0x00015730
		public override bool Deliver(LogicLevel level)
		{
			LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
			if (this.int_0 == 0)
			{
				homeOwnerAvatar.SetRedPackageState(homeOwnerAvatar.GetRedPackageState() | 19);
			}
			else
			{
				Debugger.Error("Unknown special delivery id " + this.int_0);
			}
			return true;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00002B38 File Offset: 0x00000D38
		public override bool CanBeDeliver(LogicLevel level)
		{
			return true;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00002B35 File Offset: 0x00000D35
		public override LogicDeliverableBundle Compensate(LogicLevel level)
		{
			return null;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00002EB3 File Offset: 0x000010B3
		public int GetId()
		{
			return this.int_0;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00002EBB File Offset: 0x000010BB
		public void SetId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000079 RID: 121
		private int int_0;
	}
}
