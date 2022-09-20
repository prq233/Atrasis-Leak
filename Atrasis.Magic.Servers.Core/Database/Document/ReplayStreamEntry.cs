using System;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F3 RID: 243
	public class ReplayStreamEntry
	{
		// Token: 0x0600074E RID: 1870 RVA: 0x000046F1 File Offset: 0x000028F1
		public ReplayStreamEntry()
		{
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000090FC File Offset: 0x000072FC
		public ReplayStreamEntry(byte[] streamData)
		{
			this.byte_0 = streamData;
			this.int_0 = 9;
			this.int_1 = 256;
			this.int_2 = ResourceManager.GetContentVersion();
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00009129 File Offset: 0x00007329
		public byte[] GetStreamData()
		{
			return this.byte_0;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00009131 File Offset: 0x00007331
		public int GetMajorVersion()
		{
			return this.int_0;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00009139 File Offset: 0x00007339
		public int GetBuildVersion()
		{
			return this.int_1;
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00009141 File Offset: 0x00007341
		public int GetContentVersion()
		{
			return this.int_2;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00017354 File Offset: 0x00015554
		public void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("data", new LogicJSONString(Convert.ToBase64String(this.byte_0)));
			LogicJSONArray logicJSONArray = new LogicJSONArray(3);
			logicJSONArray.Add(new LogicJSONNumber(this.int_0));
			logicJSONArray.Add(new LogicJSONNumber(this.int_1));
			logicJSONArray.Add(new LogicJSONNumber(this.int_2));
			jsonObject.Put("version", logicJSONArray);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000173C4 File Offset: 0x000155C4
		public void Load(LogicJSONObject jsonObject)
		{
			this.byte_0 = Convert.FromBase64String(jsonObject.GetJSONString("data").GetStringValue());
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("version");
			this.int_0 = jsonarray.GetJSONNumber(0).GetIntValue();
			this.int_1 = jsonarray.GetJSONNumber(1).GetIntValue();
			this.int_2 = jsonarray.GetJSONNumber(2).GetIntValue();
		}

		// Token: 0x04000421 RID: 1057
		public const string JSON_ATTRIBUTE_STREAM_DATA = "data";

		// Token: 0x04000422 RID: 1058
		public const string JSON_ATTRIBUTE_STREAM_VERSION = "version";

		// Token: 0x04000423 RID: 1059
		private byte[] byte_0;

		// Token: 0x04000424 RID: 1060
		private int int_0;

		// Token: 0x04000425 RID: 1061
		private int int_1;

		// Token: 0x04000426 RID: 1062
		private int int_2;
	}
}
