using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E0 RID: 224
	public class ChatToAllianceStreamMessage : PiranhaMessage
	{
		// Token: 0x060009CD RID: 2509 RVA: 0x0000789D File Offset: 0x00005A9D
		public ChatToAllianceStreamMessage() : this(0)
		{
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0000328E File Offset: 0x0000148E
		public ChatToAllianceStreamMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x000078A6 File Offset: 0x00005AA6
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x000078C4 File Offset: 0x00005AC4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x000078DD File Offset: 0x00005ADD
		public override short GetMessageType()
		{
			return 14315;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x000078E4 File Offset: 0x00005AE4
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000078F3 File Offset: 0x00005AF3
		public string RemoveMessage()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00007902 File Offset: 0x00005B02
		public void SetMessage(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x040003D5 RID: 981
		public const int MESSAGE_TYPE = 14315;

		// Token: 0x040003D6 RID: 982
		private string string_0;
	}
}
