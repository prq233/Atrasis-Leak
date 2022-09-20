using System;
using System.Text;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x02000019 RID: 25
	public abstract class LogicJSONNode
	{
		// Token: 0x060000DA RID: 218
		public abstract LogicJSONNodeType GetJSONNodeType();

		// Token: 0x060000DB RID: 219
		public abstract void WriteToString(StringBuilder builder);
	}
}
