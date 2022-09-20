using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000009 RID: 9
	public class LogicDataSlot
	{
		// Token: 0x06000039 RID: 57 RVA: 0x0000231A File Offset: 0x0000051A
		public LogicDataSlot(LogicData data, int count)
		{
			this.logicData_0 = data;
			this.int_0 = count;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002330 File Offset: 0x00000530
		public LogicDataSlot Clone()
		{
			return new LogicDataSlot(this.logicData_0, this.int_0);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002343 File Offset: 0x00000543
		public void Destruct()
		{
			this.logicData_0 = null;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000234C File Offset: 0x0000054C
		public void Decode(ByteStream stream)
		{
			this.logicData_0 = ByteStreamHelper.ReadDataReference(stream);
			this.int_0 = stream.ReadInt();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002366 File Offset: 0x00000566
		public void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicData_0);
			encoder.WriteInt(this.int_0);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002380 File Offset: 0x00000580
		public LogicData GetData()
		{
			return this.logicData_0;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002388 File Offset: 0x00000588
		public int GetCount()
		{
			return this.int_0;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00012578 File Offset: 0x00010778
		public void GetChecksum(ChecksumHelper checksumHelper)
		{
			checksumHelper.StartObject("LogicDataSlot");
			if (this.logicData_0 != null)
			{
				checksumHelper.WriteValue("globalID", this.logicData_0.GetGlobalID());
			}
			checksumHelper.WriteValue("m_count", this.int_0);
			checksumHelper.EndObject();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002390 File Offset: 0x00000590
		public void SetCount(int count)
		{
			this.int_0 = count;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000125C8 File Offset: 0x000107C8
		public void ReadFromJSON(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("id");
			if (jsonnumber != null && jsonnumber.GetIntValue() != 0)
			{
				this.logicData_0 = LogicDataTables.GetDataById(jsonnumber.GetIntValue());
			}
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "cnt");
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002399 File Offset: 0x00000599
		public void WriteToJSON(LogicJSONObject jsonObject)
		{
			jsonObject.Put("id", new LogicJSONNumber((this.logicData_0 != null) ? this.logicData_0.GetGlobalID() : 0));
			jsonObject.Put("cnt", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x04000029 RID: 41
		private LogicData logicData_0;

		// Token: 0x0400002A RID: 42
		private int int_0;
	}
}
