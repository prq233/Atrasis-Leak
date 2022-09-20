using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009B RID: 155
	public class ScoringSyncMessage : ServerCoreMessage
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x0000716C File Offset: 0x0000536C
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x00007174 File Offset: 0x00005374
		public SeasonDocument CurrentSeasonDocument { get; set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x0000717D File Offset: 0x0000537D
		// (set) Token: 0x06000437 RID: 1079 RVA: 0x00007185 File Offset: 0x00005385
		public SeasonDocument LastSeasonDocument { get; set; }

		// Token: 0x06000438 RID: 1080 RVA: 0x0000718E File Offset: 0x0000538E
		public override void Encode(ByteStream stream)
		{
			CouchbaseDocument.Encode(stream, this.CurrentSeasonDocument);
			if (this.LastSeasonDocument != null)
			{
				stream.WriteBoolean(true);
				CouchbaseDocument.Encode(stream, this.LastSeasonDocument);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000071BF File Offset: 0x000053BF
		public override void Decode(ByteStream stream)
		{
			this.CurrentSeasonDocument = CouchbaseDocument.Decode<SeasonDocument>(stream);
			if (stream.ReadBoolean())
			{
				this.LastSeasonDocument = CouchbaseDocument.Decode<SeasonDocument>(stream);
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000071E1 File Offset: 0x000053E1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SCORING_SYNC;
		}

		// Token: 0x040001DB RID: 475
		[CompilerGenerated]
		private SeasonDocument seasonDocument_0;

		// Token: 0x040001DC RID: 476
		[CompilerGenerated]
		private SeasonDocument seasonDocument_1;
	}
}
