using System;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000131 RID: 305
	public class GlobalID
	{
		// Token: 0x06001093 RID: 4243 RVA: 0x0000B328 File Offset: 0x00009528
		public static int CreateGlobalID(int classId, int instanceId)
		{
			return 1000000 * classId + instanceId;
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0000B333 File Offset: 0x00009533
		public static int GetInstanceID(int globalId)
		{
			return globalId % 1000000;
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x0000B33C File Offset: 0x0000953C
		public static int GetClassID(int globalId)
		{
			return globalId / 1000000;
		}
	}
}
