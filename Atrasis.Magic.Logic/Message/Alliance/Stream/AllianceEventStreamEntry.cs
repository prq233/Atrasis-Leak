using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000D5 RID: 213
	public class AllianceEventStreamEntry : StreamEntry
	{
		// Token: 0x06000929 RID: 2345 RVA: 0x00007358 File Offset: 0x00005558
		public AllianceEventStreamEntry()
		{
			this.logicLong_3 = new LogicLong();
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0000736B File Offset: 0x0000556B
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.allianceEventStreamEntryType_0 = (AllianceEventStreamEntryType)stream.ReadInt();
			this.logicLong_3 = stream.ReadLong();
			this.string_1 = stream.ReadString(900000);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0000739D File Offset: 0x0000559D
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt((int)this.allianceEventStreamEntryType_0);
			stream.WriteLong(this.logicLong_3);
			stream.WriteString(this.string_1);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000073CA File Offset: 0x000055CA
		public AllianceEventStreamEntryType GetEventType()
		{
			return this.allianceEventStreamEntryType_0;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x000073D2 File Offset: 0x000055D2
		public void SetEventType(AllianceEventStreamEntryType value)
		{
			this.allianceEventStreamEntryType_0 = value;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000073DB File Offset: 0x000055DB
		public LogicLong GetEventAvatarId()
		{
			return this.logicLong_3;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x000073E3 File Offset: 0x000055E3
		public void SetEventAvatarId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000073EC File Offset: 0x000055EC
		public string GetEventAvatarName()
		{
			return this.string_1;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x000073F4 File Offset: 0x000055F4
		public void SetEventAvatarName(string message)
		{
			this.string_1 = message;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00002EB0 File Offset: 0x000010B0
		public override StreamEntryType GetStreamEntryType()
		{
			return StreamEntryType.ALLIANCE_EVENT;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00021B40 File Offset: 0x0001FD40
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("ChatStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.allianceEventStreamEntryType_0 = (AllianceEventStreamEntryType)jsonObject.GetJSONNumber("event_type").GetIntValue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("event_avatar_id_high");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("event_avatar_id_low");
			if (jsonnumber != null && jsonnumber2 != null)
			{
				this.logicLong_3 = new LogicLong(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
				LogicJSONString jsonstring = jsonObject.GetJSONString("event_avatar_name");
				if (jsonstring != null)
				{
					this.string_1 = jsonstring.GetStringValue();
				}
			}
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00021BD4 File Offset: 0x0001FDD4
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("event_type", new LogicJSONNumber((int)this.allianceEventStreamEntryType_0));
			if (!this.logicLong_3.IsZero())
			{
				jsonObject.Put("event_avatar_id_high", new LogicJSONNumber(this.logicLong_3.GetHigherInt()));
				jsonObject.Put("event_avatar_id_low", new LogicJSONNumber(this.logicLong_3.GetLowerInt()));
				jsonObject.Put("event_avatar_name", new LogicJSONString(this.string_1));
			}
		}

		// Token: 0x04000394 RID: 916
		private AllianceEventStreamEntryType allianceEventStreamEntryType_0;

		// Token: 0x04000395 RID: 917
		private string string_1;

		// Token: 0x04000396 RID: 918
		private LogicLong logicLong_3;
	}
}
