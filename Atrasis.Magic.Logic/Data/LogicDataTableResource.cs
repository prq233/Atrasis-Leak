using System;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000148 RID: 328
	public class LogicDataTableResource
	{
		// Token: 0x0600123D RID: 4669 RVA: 0x0000C2F2 File Offset: 0x0000A4F2
		public LogicDataTableResource(string fileName, LogicDataType tableIndex, int type)
		{
			this.string_0 = fileName;
			this.logicDataType_0 = tableIndex;
			this.int_0 = type;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x0000C30F File Offset: 0x0000A50F
		public void Destruct()
		{
			this.string_0 = null;
			this.logicDataType_0 = LogicDataType.BUILDING;
			this.int_0 = 0;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x0000C326 File Offset: 0x0000A526
		public string GetFileName()
		{
			return this.string_0;
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x0000C32E File Offset: 0x0000A52E
		public LogicDataType GetTableIndex()
		{
			return this.logicDataType_0;
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x0000C336 File Offset: 0x0000A536
		public int GetTableType()
		{
			return this.int_0;
		}

		// Token: 0x040008A8 RID: 2216
		private string string_0;

		// Token: 0x040008A9 RID: 2217
		private LogicDataType logicDataType_0;

		// Token: 0x040008AA RID: 2218
		private int int_0;
	}
}
