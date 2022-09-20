using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E4 RID: 228
	public class JoinRequestAllianceStreamEntry : StreamEntry
	{
		// Token: 0x06000A41 RID: 2625 RVA: 0x00007CB4 File Offset: 0x00005EB4
		public JoinRequestAllianceStreamEntry()
		{
			this.int_3 = 1;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00007CC3 File Offset: 0x00005EC3
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			this.string_2 = stream.ReadString(900000);
			this.int_3 = stream.ReadInt();
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00007CFA File Offset: 0x00005EFA
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			stream.WriteString(this.string_2);
			stream.WriteInt(this.int_3);
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00007D27 File Offset: 0x00005F27
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00007D2F File Offset: 0x00005F2F
		public void SetMessage(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00007D38 File Offset: 0x00005F38
		public string GetResponderName()
		{
			return this.string_2;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00007D40 File Offset: 0x00005F40
		public void SetResponderName(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00007D49 File Offset: 0x00005F49
		public int GetState()
		{
			return this.int_3;
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00007D51 File Offset: 0x00005F51
		public void SetState(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.JOIN_REQUEST;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00024388 File Offset: 0x00022588
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("JoinRequestAllianceStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("message").GetStringValue();
			this.int_3 = jsonObject.GetJSONNumber("state").GetIntValue();
			if (this.int_3 != 1)
			{
				this.string_2 = jsonObject.GetJSONString("responder_name").GetStringValue();
			}
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00024400 File Offset: 0x00022600
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("message", new LogicJSONString(this.string_1));
			jsonObject.Put("state", new LogicJSONNumber(this.int_3));
			if (this.int_3 != 1)
			{
				jsonObject.Put("responder_name", new LogicJSONString(this.string_2));
			}
		}

		// Token: 0x040003FB RID: 1019
		private string string_1;

		// Token: 0x040003FC RID: 1020
		private string string_2;

		// Token: 0x040003FD RID: 1021
		private int int_3;
	}
}
