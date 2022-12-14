using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Facebook
{
	// Token: 0x02000072 RID: 114
	public class BindFacebookAccountMessage : PiranhaMessage
	{
		// Token: 0x06000501 RID: 1281 RVA: 0x00004ED9 File Offset: 0x000030D9
		public BindFacebookAccountMessage() : this(0)
		{
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000328E File Offset: 0x0000148E
		public BindFacebookAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001D0CC File Offset: 0x0001B2CC
		public override void Decode()
		{
			base.Decode();
			this.bool_0 = this.m_stream.ReadBoolean();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00004EE2 File Offset: 0x000030E2
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00004F1D File Offset: 0x0000311D
		public override short GetMessageType()
		{
			return 14201;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00004F24 File Offset: 0x00003124
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00004F3A File Offset: 0x0000313A
		public string RemoveFacebookId()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00004F49 File Offset: 0x00003149
		public void SetFacebookId(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00004F52 File Offset: 0x00003152
		public string RemoveAuthentificationToken()
		{
			string result = this.string_1;
			this.string_1 = null;
			return result;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00004F61 File Offset: 0x00003161
		public void SetAuthentificationToken(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x040001E4 RID: 484
		public const int MESSAGE_TYPE = 14201;

		// Token: 0x040001E5 RID: 485
		private bool bool_0;

		// Token: 0x040001E6 RID: 486
		private string string_0;

		// Token: 0x040001E7 RID: 487
		private string string_1;
	}
}
