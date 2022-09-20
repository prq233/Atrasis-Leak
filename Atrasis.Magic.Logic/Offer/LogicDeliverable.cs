using System;
using System.Text;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000018 RID: 24
	public class LogicDeliverable
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00002B11 File Offset: 0x00000D11
		public void Decode(ByteStream stream)
		{
			this.ReadFromJSON(LogicJSONParser.ParseObject(stream.ReadString(900000) ?? string.Empty));
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00017068 File Offset: 0x00015268
		public void Encode(ChecksumEncoder encoder)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			StringBuilder stringBuilder = new StringBuilder();
			this.WriteToJSON(logicJSONObject);
			logicJSONObject.WriteToString(stringBuilder);
			encoder.WriteString(stringBuilder.ToString());
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Destruct()
		{
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0001709C File Offset: 0x0001529C
		public virtual void WriteToJSON(LogicJSONObject jsonObject)
		{
			Debugger.DoAssert(this.GetDeliverableType() != 0, "Deliverable type not set!");
			jsonObject.Put("type", new LogicJSONString(this.GetDeliverableType().ToString()));
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void ReadFromJSON(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00002B32 File Offset: 0x00000D32
		public virtual int GetDeliverableType()
		{
			return -1;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002B35 File Offset: 0x00000D35
		public virtual LogicDeliverableBundle Compensate(LogicLevel level)
		{
			return null;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00002B38 File Offset: 0x00000D38
		public virtual bool Deliver(LogicLevel level)
		{
			return true;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00002B38 File Offset: 0x00000D38
		public virtual bool CanBeDeliver(LogicLevel level)
		{
			return true;
		}
	}
}
