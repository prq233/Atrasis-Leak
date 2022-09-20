using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014A RID: 330
	public class LogicDecoData : LogicGameObjectData
	{
		// Token: 0x06001279 RID: 4729 RVA: 0x0000B477 File Offset: 0x00009677
		public LogicDecoData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x0004E16C File Offset: 0x0004C36C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("Width", 0);
			this.int_1 = base.GetIntegerValue("Height", 0);
			this.int_3 = base.GetIntegerValue("MaxCount", 0);
			this.bool_0 = !base.GetBooleanValue("NotInShop", 0);
			this.int_2 = base.GetIntegerValue("BuildCost", 0);
			this.int_4 = base.GetIntegerValue("RequiredExpLevel", 0);
			this.bool_1 = base.GetBooleanValue("DecoPath", 0);
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("BuildResource", 0), this);
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x0000C68A File Offset: 0x0000A88A
		public bool IsInShop()
		{
			return this.bool_0;
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x0000C692 File Offset: 0x0000A892
		public int GetMaxCount()
		{
			return this.int_3;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x0000C69A File Offset: 0x0000A89A
		public int GetRequiredExpLevel()
		{
			return this.int_4;
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x0000C6A2 File Offset: 0x0000A8A2
		public int GetSellPrice()
		{
			return this.int_2 / 10;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x0000C6AD File Offset: 0x0000A8AD
		public int GetBuildCost()
		{
			return this.int_2;
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x0000C6B5 File Offset: 0x0000A8B5
		public int GetWidth()
		{
			return this.int_0;
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x0000C6BD File Offset: 0x0000A8BD
		public int GetHeight()
		{
			return this.int_1;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0000C6C5 File Offset: 0x0000A8C5
		public LogicResourceData GetBuildResource()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x0000C6CD File Offset: 0x0000A8CD
		public bool IsPassable()
		{
			return this.bool_1;
		}

		// Token: 0x040008C1 RID: 2241
		private int int_0;

		// Token: 0x040008C2 RID: 2242
		private int int_1;

		// Token: 0x040008C3 RID: 2243
		private int int_2;

		// Token: 0x040008C4 RID: 2244
		private int int_3;

		// Token: 0x040008C5 RID: 2245
		private int int_4;

		// Token: 0x040008C6 RID: 2246
		private bool bool_0;

		// Token: 0x040008C7 RID: 2247
		private bool bool_1;

		// Token: 0x040008C8 RID: 2248
		private LogicResourceData logicResourceData_0;
	}
}
