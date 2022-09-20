using System;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000071 RID: 113
	public class StartFriendLiveSpectateMessage : FriendAvatarBaseMessage
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x00004EC9 File Offset: 0x000030C9
		public StartFriendLiveSpectateMessage() : this(0)
		{
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00004B91 File Offset: 0x00002D91
		public StartFriendLiveSpectateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00004B9A File Offset: 0x00002D9A
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00004BA2 File Offset: 0x00002DA2
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00004ED2 File Offset: 0x000030D2
		public override short GetMessageType()
		{
			return 10507;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00004BB1 File Offset: 0x00002DB1
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001E3 RID: 483
		public const int MESSAGE_TYPE = 10507;
	}
}
