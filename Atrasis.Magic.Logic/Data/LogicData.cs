using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000145 RID: 325
	public class LogicData
	{
		// Token: 0x06001219 RID: 4633 RVA: 0x0004D81C File Offset: 0x0004BA1C
		public LogicData(CSVRow row, LogicDataTable table)
		{
			this.m_row = row;
			this.m_table = table;
			this.m_globalId = GlobalID.CreateGlobalID((int)(table.GetTableIndex() + 1), table.GetItemCount());
			this.m_tidIndex = -1;
			this.m_infoTidIndex = -1;
			this.m_iconSWFIndex = -1;
			this.m_iconExportNameIndex = -1;
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x0004D874 File Offset: 0x0004BA74
		public virtual void CreateReferences()
		{
			this.m_iconSWFIndex = (short)this.m_row.GetColumnIndexByName("IconSWF");
			this.m_iconExportNameIndex = (short)this.m_row.GetColumnIndexByName("IconExportName");
			this.m_tidIndex = (short)this.m_row.GetColumnIndexByName("TID");
			this.m_infoTidIndex = (short)this.m_row.GetColumnIndexByName("InfoTID");
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void CreateReferences2()
		{
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x0000C144 File Offset: 0x0000A344
		public void SetCSVRow(CSVRow row)
		{
			this.m_row = row;
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x0000C14D File Offset: 0x0000A34D
		public int GetArraySize(string column)
		{
			return this.m_row.GetArraySize(column);
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x0000C15B File Offset: 0x0000A35B
		public LogicDataType GetDataType()
		{
			return this.m_table.GetTableIndex();
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x0000C168 File Offset: 0x0000A368
		public int GetGlobalID()
		{
			return this.m_globalId;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x0000C170 File Offset: 0x0000A370
		public int GetInstanceID()
		{
			return GlobalID.GetInstanceID(this.m_globalId);
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x0004D8E0 File Offset: 0x0004BAE0
		public int GetColumnIndex(string name)
		{
			if (this.m_row.GetColumnIndexByName(name) == -1)
			{
				Debugger.Warning(string.Format("Unable to find column {0} from {1} ({2})", name, this.m_row.GetName(), this.m_table.GetTableName()));
			}
			return this.m_row.GetColumnIndexByName(name);
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x0000C17D File Offset: 0x0000A37D
		public string GetDebuggerName()
		{
			return this.m_row.GetName() + " (" + this.m_table.GetTableName() + ")";
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x0000C1A4 File Offset: 0x0000A3A4
		public bool GetBooleanValue(string columnName, int index)
		{
			return this.m_row.GetBooleanValue(columnName, index);
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x0000C1B3 File Offset: 0x0000A3B3
		public bool GetClampedBooleanValue(string columnName, int index)
		{
			return this.m_row.GetClampedBooleanValue(columnName, index);
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x0000C1C2 File Offset: 0x0000A3C2
		public int GetIntegerValue(string columnName, int index)
		{
			return this.m_row.GetIntegerValue(columnName, index);
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x0000C1D1 File Offset: 0x0000A3D1
		public int GetClampedIntegerValue(string columnName, int index)
		{
			return this.m_row.GetClampedIntegerValue(columnName, index);
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x0000C1E0 File Offset: 0x0000A3E0
		public string GetValue(string columnName, int index)
		{
			return this.m_row.GetValue(columnName, index);
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x0000C1EF File Offset: 0x0000A3EF
		public string GetClampedValue(string columnName, int index)
		{
			return this.m_row.GetClampedValue(columnName, index);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x0000C1FE File Offset: 0x0000A3FE
		public string GetName()
		{
			return this.m_row.GetName();
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x0000C20B File Offset: 0x0000A40B
		public string GetTID()
		{
			if (this.m_tidIndex == -1)
			{
				return null;
			}
			return this.m_row.GetValueAt((int)this.m_tidIndex, 0);
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x0000C22A File Offset: 0x0000A42A
		public string GetInfoTID()
		{
			if (this.m_infoTidIndex == -1)
			{
				return null;
			}
			return this.m_row.GetValueAt((int)this.m_infoTidIndex, 0);
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x0000C249 File Offset: 0x0000A449
		public string GetIconExportName()
		{
			if (this.m_iconExportNameIndex == -1)
			{
				return null;
			}
			return this.m_row.GetValueAt((int)this.m_iconExportNameIndex, 0);
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsEnableByCalendar()
		{
			return false;
		}

		// Token: 0x0400086E RID: 2158
		protected readonly int m_globalId;

		// Token: 0x0400086F RID: 2159
		protected short m_tidIndex;

		// Token: 0x04000870 RID: 2160
		protected short m_infoTidIndex;

		// Token: 0x04000871 RID: 2161
		protected short m_iconExportNameIndex;

		// Token: 0x04000872 RID: 2162
		protected short m_iconSWFIndex;

		// Token: 0x04000873 RID: 2163
		protected CSVRow m_row;

		// Token: 0x04000874 RID: 2164
		protected readonly LogicDataTable m_table;
	}
}
