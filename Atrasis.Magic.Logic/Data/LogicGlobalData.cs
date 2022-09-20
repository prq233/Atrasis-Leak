using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000151 RID: 337
	public class LogicGlobalData : LogicData
	{
		// Token: 0x060012E0 RID: 4832 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicGlobalData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x0004EB10 File Offset: 0x0004CD10
		public override void CreateReferences()
		{
			base.CreateReferences();
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.int_1 = new int[biggestArraySize];
			this.int_2 = new int[biggestArraySize];
			this.string_1 = new string[biggestArraySize];
			this.int_0 = base.GetIntegerValue("NumberValue", 0);
			this.bool_0 = base.GetBooleanValue("BooleanValue", 0);
			this.string_0 = base.GetValue("TextValue", 0);
			for (int i = 0; i < biggestArraySize; i++)
			{
				this.int_1[i] = base.GetIntegerValue("NumberArray", i);
				this.int_2[i] = base.GetIntegerValue("AltNumberArray", i);
				this.string_1[i] = base.GetValue("StringArray", i);
			}
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x0000C9BE File Offset: 0x0000ABBE
		public int GetNumberValue()
		{
			return this.int_0;
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x0000C9C6 File Offset: 0x0000ABC6
		public bool GetBooleanValue()
		{
			return this.bool_0;
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x0000C9CE File Offset: 0x0000ABCE
		public string GetTextValue()
		{
			return this.string_0;
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x0000C9D6 File Offset: 0x0000ABD6
		public int GetNumberArraySize()
		{
			return this.int_1.Length;
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x0000C9E0 File Offset: 0x0000ABE0
		public int GetNumberArray(int index)
		{
			return this.int_1[index];
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x0000C9EA File Offset: 0x0000ABEA
		public int GetAltNumberArray(int index)
		{
			return this.int_2[index];
		}

		// Token: 0x0400091A RID: 2330
		private int int_0;

		// Token: 0x0400091B RID: 2331
		private bool bool_0;

		// Token: 0x0400091C RID: 2332
		private string string_0;

		// Token: 0x0400091D RID: 2333
		private int[] int_1;

		// Token: 0x0400091E RID: 2334
		private int[] int_2;

		// Token: 0x0400091F RID: 2335
		private string[] string_1;
	}
}
