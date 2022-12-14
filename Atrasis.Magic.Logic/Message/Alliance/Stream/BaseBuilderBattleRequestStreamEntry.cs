using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000DC RID: 220
	public class BaseBuilderBattleRequestStreamEntry : StreamEntry
	{
		// Token: 0x0600098E RID: 2446 RVA: 0x000226B8 File Offset: 0x000208B8
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.string_1 = stream.ReadString(900000);
			if (stream.ReadBoolean())
			{
				this.string_2 = stream.ReadString(900000);
			}
			stream.ReadVInt();
			this.int_3 = stream.ReadVInt();
			this.bool_1 = stream.ReadBoolean();
			stream.ReadVInt();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0002271C File Offset: 0x0002091C
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteString(this.string_1);
			if (this.string_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteString(this.string_1);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteVInt(0);
			stream.WriteVInt(this.int_3);
			stream.WriteBoolean(this.bool_1);
			stream.WriteVInt(0);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00007719 File Offset: 0x00005919
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.BASE_BUILDER_BATTLE_REQUEST;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0000771D File Offset: 0x0000591D
		public string GetMessage()
		{
			return this.string_1;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00007725 File Offset: 0x00005925
		public void SetMessage(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0000772E File Offset: 0x0000592E
		public int GetLayoutId()
		{
			return this.int_4;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00007736 File Offset: 0x00005936
		public void SetLayoutId(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0000773F File Offset: 0x0000593F
		public string GetBattleLogJSON()
		{
			return this.string_2;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00007747 File Offset: 0x00005947
		public void SetBattleLogJSON(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00007750 File Offset: 0x00005950
		public int GetSpectatorCount()
		{
			return this.int_3;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00007758 File Offset: 0x00005958
		public void SetSpectatorCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00007761 File Offset: 0x00005961
		public bool IsStarted()
		{
			return this.bool_1;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00007769 File Offset: 0x00005969
		public void SetStarted(bool started)
		{
			this.bool_1 = started;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00022788 File Offset: 0x00020988
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("BaseBuilderBattleRequestStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("message").GetStringValue();
			LogicJSONString jsonstring = jsonObject.GetJSONString("battleLog");
			if (jsonstring != null)
			{
				this.string_2 = jsonstring.GetStringValue();
			}
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000227E8 File Offset: 0x000209E8
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("message", new LogicJSONString(this.string_1));
			if (this.string_2 != null)
			{
				jsonObject.Put("battleLog", new LogicJSONString(this.string_2));
			}
		}

		// Token: 0x040003C2 RID: 962
		private string string_1;

		// Token: 0x040003C3 RID: 963
		private string string_2;

		// Token: 0x040003C4 RID: 964
		private int int_3;

		// Token: 0x040003C5 RID: 965
		private int int_4;

		// Token: 0x040003C6 RID: 966
		private bool bool_1;
	}
}
