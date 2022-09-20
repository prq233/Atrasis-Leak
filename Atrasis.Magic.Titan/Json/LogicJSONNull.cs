using System;
using System.Text;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x0200001B RID: 27
	public class LogicJSONNull : LogicJSONNode
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00004BB0 File Offset: 0x00002DB0
		public override LogicJSONNodeType GetJSONNodeType()
		{
			return LogicJSONNodeType.NULL;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004BB3 File Offset: 0x00002DB3
		public override void WriteToString(StringBuilder builder)
		{
			builder.Append("null");
		}
	}
}
