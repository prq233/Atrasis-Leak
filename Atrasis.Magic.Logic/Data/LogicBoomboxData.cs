using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013D RID: 317
	public class LogicBoomboxData : LogicData
	{
		// Token: 0x06001122 RID: 4386 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicBoomboxData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x0004B614 File Offset: 0x00049814
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = base.GetBooleanValue("Enabled", 0);
			this.bool_1 = base.GetBooleanValue("EnabledLowMem", 0);
			this.bool_2 = base.GetBooleanValue("PreLoading", 0);
			this.bool_3 = base.GetBooleanValue("PreLoadingLowMem", 0);
			this.string_0 = new string[base.GetArraySize("DisabledDevices")];
			for (int i = 0; i < this.string_0.Length; i++)
			{
				this.string_0[i] = base.GetValue("DisabledDevices", i);
			}
			this.string_1 = new string[base.GetArraySize("SupportedPlatforms")];
			for (int j = 0; j < this.string_1.Length; j++)
			{
				this.string_1[j] = base.GetValue("SupportedPlatforms", j);
			}
			this.string_2 = new string[base.GetArraySize("SupportedPlatformsVersion")];
			for (int k = 0; k < this.string_2.Length; k++)
			{
				this.string_2[k] = base.GetValue("SupportedPlatformsVersion", k);
			}
			this.string_3 = new string[base.GetArraySize("AllowedDomains")];
			for (int l = 0; l < this.string_3.Length; l++)
			{
				this.string_3[l] = base.GetValue("AllowedDomains", l);
			}
			this.string_4 = new string[base.GetArraySize("AllowedUrls")];
			for (int m = 0; m < this.string_4.Length; m++)
			{
				this.string_4[m] = base.GetValue("AllowedUrls", m);
			}
		}

		// Token: 0x04000766 RID: 1894
		private bool bool_0;

		// Token: 0x04000767 RID: 1895
		private bool bool_1;

		// Token: 0x04000768 RID: 1896
		private bool bool_2;

		// Token: 0x04000769 RID: 1897
		private bool bool_3;

		// Token: 0x0400076A RID: 1898
		private string[] string_0;

		// Token: 0x0400076B RID: 1899
		private string[] string_1;

		// Token: 0x0400076C RID: 1900
		private string[] string_2;

		// Token: 0x0400076D RID: 1901
		private string[] string_3;

		// Token: 0x0400076E RID: 1902
		private string[] string_4;
	}
}
