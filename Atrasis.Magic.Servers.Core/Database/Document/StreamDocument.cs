using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F2 RID: 242
	public class StreamDocument : CouchbaseDocument
	{
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x00008FFB File Offset: 0x000071FB
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x00009003 File Offset: 0x00007203
		public DateTime CreateTime { get; set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0000900C File Offset: 0x0000720C
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x00009014 File Offset: 0x00007214
		public StreamType Type { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x0000901D File Offset: 0x0000721D
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x00009025 File Offset: 0x00007225
		public LogicLong OwnerId { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x0000902E File Offset: 0x0000722E
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x00009036 File Offset: 0x00007236
		public object Entry { get; set; }

		// Token: 0x06000744 RID: 1860 RVA: 0x00008D37 File Offset: 0x00006F37
		public StreamDocument()
		{
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0000903F File Offset: 0x0000723F
		public StreamDocument(LogicLong id, LogicLong ownerId, StreamEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = ownerId;
			this.Type = StreamType.ALLIANCE;
			this.Entry = entry;
			entry.SetId(id);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0000906F File Offset: 0x0000726F
		public StreamDocument(LogicLong id, LogicLong ownerId, AvatarStreamEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = ownerId;
			this.Type = StreamType.AVATAR;
			this.Entry = entry;
			entry.SetId(id);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0000909F File Offset: 0x0000729F
		public StreamDocument(LogicLong id, LogicLong ownerId, Village2AttackEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = ownerId;
			this.Type = StreamType.ATTACK_ENTRY;
			this.Entry = entry;
			entry.SetId(id);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000090CF File Offset: 0x000072CF
		public StreamDocument(LogicLong id, ReplayStreamEntry entry) : base(id)
		{
			this.CreateTime = DateTime.UtcNow;
			this.OwnerId = new LogicLong();
			this.Type = StreamType.REPLAY;
			this.Entry = entry;
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00004631 File Offset: 0x00002831
		protected sealed override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00004631 File Offset: 0x00002831
		protected sealed override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00016FEC File Offset: 0x000151EC
		protected sealed override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			logicJSONArray.Add(new LogicJSONNumber(this.OwnerId.GetHigherInt()));
			logicJSONArray.Add(new LogicJSONNumber(this.OwnerId.GetLowerInt()));
			jsonObject.Put("ownerId", logicJSONArray);
			jsonObject.Put("createT", new LogicJSONString(this.CreateTime.ToString("O")));
			jsonObject.Put("type", new LogicJSONNumber((int)this.Type));
			switch (this.Type)
			{
			case StreamType.ALLIANCE:
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				StreamEntry streamEntry = (StreamEntry)this.Entry;
				jsonObject.Put("entryT", new LogicJSONNumber((int)streamEntry.GetStreamEntryType()));
				jsonObject.Put("entry", logicJSONObject);
				streamEntry.Save(logicJSONObject);
				return;
			}
			case StreamType.AVATAR:
			{
				LogicJSONObject logicJSONObject2 = new LogicJSONObject();
				AvatarStreamEntry avatarStreamEntry = (AvatarStreamEntry)this.Entry;
				jsonObject.Put("entryT", new LogicJSONNumber((int)avatarStreamEntry.GetAvatarStreamEntryType()));
				jsonObject.Put("entry", logicJSONObject2);
				avatarStreamEntry.Save(logicJSONObject2);
				return;
			}
			case StreamType.REPLAY:
			{
				LogicJSONObject logicJSONObject3 = new LogicJSONObject();
				ReplayStreamEntry replayStreamEntry = (ReplayStreamEntry)this.Entry;
				jsonObject.Put("entry", logicJSONObject3);
				replayStreamEntry.Save(logicJSONObject3);
				return;
			}
			case StreamType.ATTACK_ENTRY:
			{
				LogicJSONObject logicJSONObject4 = new LogicJSONObject();
				Village2AttackEntry village2AttackEntry = (Village2AttackEntry)this.Entry;
				jsonObject.Put("entryT", new LogicJSONNumber((int)village2AttackEntry.GetAttackEntryType()));
				jsonObject.Put("entry", logicJSONObject4);
				village2AttackEntry.Save(logicJSONObject4);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00017178 File Offset: 0x00015378
		protected sealed override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("ownerId");
			this.OwnerId = new LogicLong(jsonarray.GetJSONNumber(0).GetIntValue(), jsonarray.GetJSONNumber(1).GetIntValue());
			this.CreateTime = DateTime.Parse(jsonObject.GetJSONString("createT").GetStringValue());
			this.Type = (StreamType)jsonObject.GetJSONNumber("type").GetIntValue();
			switch (this.Type)
			{
			case StreamType.ALLIANCE:
			{
				StreamEntry streamEntry = StreamEntryFactory.CreateStreamEntryByType((StreamEntryType)jsonObject.GetJSONNumber("entryT").GetIntValue());
				streamEntry.Load(jsonObject.GetJSONObject("entry"));
				streamEntry.SetId(base.Id);
				this.Entry = streamEntry;
				return;
			}
			case StreamType.AVATAR:
			{
				AvatarStreamEntry avatarStreamEntry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)jsonObject.GetJSONNumber("entryT").GetIntValue());
				avatarStreamEntry.Load(jsonObject.GetJSONObject("entry"));
				avatarStreamEntry.SetId(base.Id);
				this.Entry = avatarStreamEntry;
				return;
			}
			case StreamType.REPLAY:
			{
				ReplayStreamEntry replayStreamEntry = new ReplayStreamEntry();
				replayStreamEntry.Load(jsonObject.GetJSONObject("entry"));
				this.Entry = replayStreamEntry;
				return;
			}
			case StreamType.ATTACK_ENTRY:
			{
				Village2AttackEntry village2AttackEntry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)jsonObject.GetJSONNumber("entryT").GetIntValue());
				village2AttackEntry.Load(jsonObject.GetJSONObject("entry"));
				village2AttackEntry.SetId(base.Id);
				this.Entry = village2AttackEntry;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x000172DC File Offset: 0x000154DC
		public void Update()
		{
			StreamType type = this.Type;
			if (type == StreamType.ALLIANCE)
			{
				((StreamEntry)this.Entry).SetAgeSeconds((int)DateTime.UtcNow.Subtract(this.CreateTime).TotalSeconds);
				return;
			}
			if (type != StreamType.AVATAR)
			{
				return;
			}
			((AvatarStreamEntry)this.Entry).SetAgeSeconds((int)DateTime.UtcNow.Subtract(this.CreateTime).TotalSeconds);
		}

		// Token: 0x04000418 RID: 1048
		private const string string_0 = "ownerId";

		// Token: 0x04000419 RID: 1049
		private const string string_1 = "type";

		// Token: 0x0400041A RID: 1050
		private const string string_2 = "createT";

		// Token: 0x0400041B RID: 1051
		private const string string_3 = "entry";

		// Token: 0x0400041C RID: 1052
		private const string string_4 = "entryT";

		// Token: 0x0400041D RID: 1053
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x0400041E RID: 1054
		[CompilerGenerated]
		private StreamType streamType_0;

		// Token: 0x0400041F RID: 1055
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000420 RID: 1056
		[CompilerGenerated]
		private object object_0;
	}
}
