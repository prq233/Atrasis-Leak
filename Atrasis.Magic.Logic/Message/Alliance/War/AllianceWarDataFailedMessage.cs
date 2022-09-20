using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000C9 RID: 201
	public class AllianceWarDataFailedMessage : PiranhaMessage
	{
		// Token: 0x060008B8 RID: 2232 RVA: 0x00006FD4 File Offset: 0x000051D4
		public AllianceWarDataFailedMessage() : this(0)
		{
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceWarDataFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00006FDD File Offset: 0x000051DD
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00006FF6 File Offset: 0x000051F6
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0000700F File Offset: 0x0000520F
		public override short GetMessageType()
		{
			return 24337;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00007016 File Offset: 0x00005216
		public int GetErrorCode()
		{
			return this.int_0;
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0000701E File Offset: 0x0000521E
		public void SetErrorCode(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000355 RID: 853
		public const int MESSAGE_TYPE = 24337;

		// Token: 0x04000356 RID: 854
		public const int WAR_DATA_ERROR_INTERNAL = 2;

		// Token: 0x04000357 RID: 855
		public const int WAR_DATA_ERROR_INVALID_WAR = 1;

		// Token: 0x04000358 RID: 856
		public const int WAR_DATA_ERROR_ERROR_NO_LONGER_AVAILABLE = 0;

		// Token: 0x04000359 RID: 857
		private int int_0;
	}
}
