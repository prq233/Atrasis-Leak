using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006F RID: 111
	public class FriendListUpdateMessage : PiranhaMessage
	{
		// Token: 0x060004EC RID: 1260 RVA: 0x00004E45 File Offset: 0x00003045
		public FriendListUpdateMessage() : this(0)
		{
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000328E File Offset: 0x0000148E
		public FriendListUpdateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00004E4E File Offset: 0x0000304E
		public override void Decode()
		{
			base.Decode();
			this.friendEntry_0 = new FriendEntry();
			this.friendEntry_0.Decode(this.m_stream);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00004E72 File Offset: 0x00003072
		public override void Encode()
		{
			base.Encode();
			this.friendEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00004E8B File Offset: 0x0000308B
		public override short GetMessageType()
		{
			return 20106;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00004E92 File Offset: 0x00003092
		public override void Destruct()
		{
			base.Destruct();
			this.friendEntry_0 = null;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00004EA1 File Offset: 0x000030A1
		public FriendEntry RemoveFriendEntry()
		{
			FriendEntry result = this.friendEntry_0;
			this.friendEntry_0 = null;
			return result;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00004EB0 File Offset: 0x000030B0
		public void SetFriendEntry(FriendEntry entry)
		{
			this.friendEntry_0 = entry;
		}

		// Token: 0x040001E0 RID: 480
		public const int MESSAGE_TYPE = 20106;

		// Token: 0x040001E1 RID: 481
		private FriendEntry friendEntry_0;
	}
}
