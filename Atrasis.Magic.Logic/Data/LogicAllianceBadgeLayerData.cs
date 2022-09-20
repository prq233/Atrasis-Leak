using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000135 RID: 309
	public class LogicAllianceBadgeLayerData : LogicData
	{
		// Token: 0x060010A7 RID: 4263 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicAllianceBadgeLayerData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x0000B3ED File Offset: 0x000095ED
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicAllianceBadgeLayerType_0 = this.method_0(base.GetValue("Type", 0));
			this.int_0 = base.GetIntegerValue("RequiredClanLevel", 0);
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x0004A940 File Offset: 0x00048B40
		private LogicAllianceBadgeLayerType method_0(string string_0)
		{
			if (string.Equals(string_0, "Background", StringComparison.InvariantCultureIgnoreCase))
			{
				return LogicAllianceBadgeLayerType.BACKGROUND;
			}
			if (string.Equals(string_0, "Middle", StringComparison.InvariantCultureIgnoreCase))
			{
				return LogicAllianceBadgeLayerType.MIDDLE;
			}
			if (string.Equals(string_0, "Foreground", StringComparison.InvariantCultureIgnoreCase))
			{
				return LogicAllianceBadgeLayerType.FOREGROUND;
			}
			Debugger.Warning("Unknown badge type: " + string_0);
			return LogicAllianceBadgeLayerType.BACKGROUND;
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0000B41F File Offset: 0x0000961F
		public LogicAllianceBadgeLayerType GetBadgeType()
		{
			return this.logicAllianceBadgeLayerType_0;
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0000B427 File Offset: 0x00009627
		public int GetRequiredClanLevel()
		{
			return this.int_0;
		}

		// Token: 0x040006EC RID: 1772
		private LogicAllianceBadgeLayerType logicAllianceBadgeLayerType_0;

		// Token: 0x040006ED RID: 1773
		private int int_0;
	}
}
