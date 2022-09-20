using System;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000070 RID: 112
	public class RemoveFriendMessage : FriendAvatarBaseMessage
	{
		// Token: 0x060004F5 RID: 1269 RVA: 0x00004EB9 File Offset: 0x000030B9
		public RemoveFriendMessage() : this(0)
		{
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00004B91 File Offset: 0x00002D91
		public RemoveFriendMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00004B9A File Offset: 0x00002D9A
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00004BA2 File Offset: 0x00002DA2
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00004EC2 File Offset: 0x000030C2
		public override short GetMessageType()
		{
			return 10506;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00004BB1 File Offset: 0x00002DB1
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001E2 RID: 482
		public const int MESSAGE_TYPE = 10506;
	}
}
