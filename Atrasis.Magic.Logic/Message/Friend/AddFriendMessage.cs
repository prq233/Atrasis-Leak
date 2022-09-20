using System;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006A RID: 106
	public class AddFriendMessage : FriendAvatarBaseMessage
	{
		// Token: 0x060004A6 RID: 1190 RVA: 0x00004C0C File Offset: 0x00002E0C
		public AddFriendMessage() : this(0)
		{
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00004B91 File Offset: 0x00002D91
		public AddFriendMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00004B9A File Offset: 0x00002D9A
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00004BA2 File Offset: 0x00002DA2
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00004C15 File Offset: 0x00002E15
		public override short GetMessageType()
		{
			return 10502;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00004BB1 File Offset: 0x00002DB1
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001C8 RID: 456
		public const int MESSAGE_TYPE = 10502;
	}
}
