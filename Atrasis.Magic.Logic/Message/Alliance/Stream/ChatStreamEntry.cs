using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DF RID: 223
	public class ChatStreamEntry : StreamEntry
	{
		// Token: 0x060009C5 RID: 2501 RVA: 0x0000785D File Offset: 0x00005A5D
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00007877 File Offset: 0x00005A77
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0000788C File Offset: 0x00005A8C
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x00007894 File Offset: 0x00005A94
		public void SetMessage(string message)
		{
			this.string_1 = message;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x00002B58 File Offset: 0x00000D58
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.CHAT;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00022CCC File Offset: 0x00020ECC
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ChatStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			LogicJSONString jsonstring = jsonObject.GetJSONString("message");
			if (jsonstring != null)
			{
				this.string_1 = jsonstring.GetStringValue();
			}
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x00022D14 File Offset: 0x00020F14
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("message", new LogicJSONString(this.string_1));
		}

		// Token: 0x040003D4 RID: 980
		private string string_1;
	}
}
