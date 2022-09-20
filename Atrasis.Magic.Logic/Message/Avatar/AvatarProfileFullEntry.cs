using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008A RID: 138
	public class AvatarProfileFullEntry
	{
		// Token: 0x060005D9 RID: 1497 RVA: 0x000056C7 File Offset: 0x000038C7
		public void Destruct()
		{
			this.logicClientAvatar_0 = null;
			this.byte_0 = null;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001D714 File Offset: 0x0001B914
		public void Encode(ChecksumEncoder encoder)
		{
			this.logicClientAvatar_0.Encode(encoder);
			encoder.WriteBytes(this.byte_0, this.byte_0.Length);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(true);
			encoder.WriteInt(0);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001D774 File Offset: 0x0001B974
		public void Decode(ByteStream stream)
		{
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(stream);
			this.byte_0 = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			stream.ReadBoolean();
			stream.ReadInt();
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x000056D7 File Offset: 0x000038D7
		public LogicClientAvatar GetLogicClientAvatar()
		{
			return this.logicClientAvatar_0;
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000056DF File Offset: 0x000038DF
		public void SetLogicClientAvatar(LogicClientAvatar avatar)
		{
			this.logicClientAvatar_0 = avatar;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x000056E8 File Offset: 0x000038E8
		public byte[] GetCompressdHomeJSON()
		{
			return this.byte_0;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x000056F0 File Offset: 0x000038F0
		public void SetCompressedHomeJSON(byte[] compressibleString)
		{
			this.byte_0 = compressibleString;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x000056F9 File Offset: 0x000038F9
		public int GetDonations()
		{
			return this.int_0;
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00005701 File Offset: 0x00003901
		public void SetDonations(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000570A File Offset: 0x0000390A
		public int GetDonationsReceived()
		{
			return this.int_1;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00005712 File Offset: 0x00003912
		public void SetDonationsReceived(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000571B File Offset: 0x0000391B
		public int GetRemainingSecondsForWar()
		{
			return this.int_2;
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00005723 File Offset: 0x00003923
		public void SetRemainingSecondsForWar(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x04000236 RID: 566
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000237 RID: 567
		private byte[] byte_0;

		// Token: 0x04000238 RID: 568
		private int int_0;

		// Token: 0x04000239 RID: 569
		private int int_1;

		// Token: 0x0400023A RID: 570
		private int int_2;
	}
}
