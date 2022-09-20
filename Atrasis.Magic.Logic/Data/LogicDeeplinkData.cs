using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014B RID: 331
	public class LogicDeeplinkData : LogicData
	{
		// Token: 0x06001284 RID: 4740 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicDeeplinkData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x0004E218 File Offset: 0x0004C418
		public override void CreateReferences()
		{
			base.CreateReferences();
			int arraySize = base.GetArraySize("ParameterType");
			this.string_0 = new string[arraySize];
			this.string_1 = new string[arraySize];
			this.string_2 = new string[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				this.string_0[i] = base.GetValue("ParameterType", i);
				this.string_1[i] = base.GetValue("ParameterName", i);
				this.string_2[i] = base.GetValue("Description", i);
			}
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x0000C6D5 File Offset: 0x0000A8D5
		public string GetParameterType(int index)
		{
			return this.string_0[index];
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x0000C6DF File Offset: 0x0000A8DF
		public string GetParameterName(int index)
		{
			return this.string_1[index];
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x0000C6E9 File Offset: 0x0000A8E9
		public string GetDescription(int index)
		{
			return this.string_2[index];
		}

		// Token: 0x040008C9 RID: 2249
		private string[] string_0;

		// Token: 0x040008CA RID: 2250
		private string[] string_1;

		// Token: 0x040008CB RID: 2251
		private string[] string_2;
	}
}
