using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006C RID: 108
	public class FriendAvatarBaseMessage : PiranhaMessage
	{
		// Token: 0x060004B3 RID: 1203 RVA: 0x00004C2C File Offset: 0x00002E2C
		public FriendAvatarBaseMessage() : this(0)
		{
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000328E File Offset: 0x0000148E
		public FriendAvatarBaseMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00004C35 File Offset: 0x00002E35
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00004C5F File Offset: 0x00002E5F
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00004C89 File Offset: 0x00002E89
		public LogicLong GetAvatarId()
		{
			return new LogicLong(this.int_0, this.int_1);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00004C9C File Offset: 0x00002E9C
		public void SetAvatarId(LogicLong avatarId)
		{
			this.int_0 = avatarId.GetHigherInt();
			this.int_1 = avatarId.GetLowerInt();
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00004CB6 File Offset: 0x00002EB6
		public void SetAvatarId(int high, int low)
		{
			this.int_0 = high;
			this.int_1 = low;
		}

		// Token: 0x040001CA RID: 458
		private int int_0;

		// Token: 0x040001CB RID: 459
		private int int_1;
	}
}
