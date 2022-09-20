using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000083 RID: 131
	public class AvatarNameCheckRequestMessage : PiranhaMessage
	{
		// Token: 0x060005A0 RID: 1440 RVA: 0x00005417 File Offset: 0x00003617
		public AvatarNameCheckRequestMessage() : this(0)
		{
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarNameCheckRequestMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00005420 File Offset: 0x00003620
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0000543E File Offset: 0x0000363E
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00005457 File Offset: 0x00003657
		public override short GetMessageType()
		{
			return 14600;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0000545E File Offset: 0x0000365E
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0000546D File Offset: 0x0000366D
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00005475 File Offset: 0x00003675
		public void SetName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x0400021C RID: 540
		public const int MESSAGE_TYPE = 14600;

		// Token: 0x0400021D RID: 541
		private string string_0;
	}
}
