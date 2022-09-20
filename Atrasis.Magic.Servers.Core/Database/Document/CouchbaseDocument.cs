using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000EE RID: 238
	public abstract class CouchbaseDocument
	{
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00008DFF File Offset: 0x00006FFF
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x00008E07 File Offset: 0x00007007
		public LogicLong Id { get; private set; }

		// Token: 0x060006FF RID: 1791 RVA: 0x000046F1 File Offset: 0x000028F1
		protected CouchbaseDocument()
		{
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00008E10 File Offset: 0x00007010
		protected CouchbaseDocument(LogicLong id)
		{
			this.Id = id;
		}

		// Token: 0x06000701 RID: 1793
		protected abstract void Save(LogicJSONObject jsonObject);

		// Token: 0x06000702 RID: 1794
		protected abstract void Load(LogicJSONObject jsonObject);

		// Token: 0x06000703 RID: 1795
		protected abstract void Encode(ByteStream stream);

		// Token: 0x06000704 RID: 1796
		protected abstract void Decode(ByteStream stream);

		// Token: 0x06000705 RID: 1797 RVA: 0x0001614C File Offset: 0x0001434C
		public static string Save(CouchbaseDocument document)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("id_hi", new LogicJSONNumber(document.Id.GetHigherInt()));
			logicJSONObject.Put("id_lo", new LogicJSONNumber(document.Id.GetLowerInt()));
			document.Save(logicJSONObject);
			return LogicJSONParser.CreateJSONString(logicJSONObject, 256);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000161A8 File Offset: 0x000143A8
		public static T Load<T>(string json) where T : CouchbaseDocument, new()
		{
			LogicJSONObject logicJSONObject = LogicJSONParser.ParseObject(json);
			T t = Activator.CreateInstance<T>();
			t.Id = LogicLong.ToLong(logicJSONObject.GetJSONNumber("id_hi").GetIntValue(), logicJSONObject.GetJSONNumber("id_lo").GetIntValue());
			t.Load(logicJSONObject);
			return t;
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00008E1F File Offset: 0x0000701F
		public static void Encode(ByteStream stream, CouchbaseDocument document)
		{
			stream.WriteLong(document.Id);
			document.Encode(stream);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00008E34 File Offset: 0x00007034
		public static T Decode<T>(ByteStream stream) where T : CouchbaseDocument, new()
		{
			T t = Activator.CreateInstance<T>();
			t.Id = stream.ReadLong();
			t.Decode(stream);
			return t;
		}

		// Token: 0x040003F4 RID: 1012
		public const string JSON_ATTRIBUTE_ID_HIGH = "id_hi";

		// Token: 0x040003F5 RID: 1013
		public const string JSON_ATTRIBUTE_ID_LOW = "id_lo";

		// Token: 0x040003F6 RID: 1014
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
