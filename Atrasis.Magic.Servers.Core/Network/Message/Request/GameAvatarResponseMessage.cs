using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000078 RID: 120
	public class GameAvatarResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00006848 File Offset: 0x00004A48
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00006850 File Offset: 0x00004A50
		public GameDocument Document { get; set; }

		// Token: 0x06000360 RID: 864 RVA: 0x00006859 File Offset: 0x00004A59
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				CouchbaseDocument.Encode(stream, this.Document);
			}
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000686F File Offset: 0x00004A6F
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Document = CouchbaseDocument.Decode<GameDocument>(stream);
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00006885 File Offset: 0x00004A85
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_AVATAR_RESPONSE;
		}

		// Token: 0x04000190 RID: 400
		[CompilerGenerated]
		private GameDocument gameDocument_0;
	}
}
