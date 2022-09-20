using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Google
{
	// Token: 0x02000063 RID: 99
	public class GoogleServiceAccountAlreadyBoundMessage : PiranhaMessage
	{
		// Token: 0x06000476 RID: 1142 RVA: 0x00004A55 File Offset: 0x00002C55
		public GoogleServiceAccountAlreadyBoundMessage() : this(0)
		{
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000328E File Offset: 0x0000148E
		public GoogleServiceAccountAlreadyBoundMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001CC90 File Offset: 0x0001AE90
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.string_1 = this.m_stream.ReadString(900000);
			this.logicClientAvatar_0 = new LogicClientAvatar();
			this.logicClientAvatar_0.Decode(this.m_stream);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001CD0C File Offset: 0x0001AF0C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			if (!this.logicLong_0.IsZero())
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.m_stream.WriteString(this.string_1);
			this.logicClientAvatar_0.Encode(this.m_stream);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00004A5E File Offset: 0x00002C5E
		public override short GetMessageType()
		{
			return 24262;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00004A65 File Offset: 0x00002C65
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
			this.logicClientAvatar_0 = null;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00004A82 File Offset: 0x00002C82
		public string RemoveGoogleServiceId()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00004A91 File Offset: 0x00002C91
		public void SetGoogleServiceId(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00004A9A File Offset: 0x00002C9A
		public string RemovePassToken()
		{
			string result = this.string_1;
			this.string_1 = null;
			return result;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00004AA9 File Offset: 0x00002CA9
		public void SetPassToken(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00004AB2 File Offset: 0x00002CB2
		public LogicLong RemoveAccountId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00004AC1 File Offset: 0x00002CC1
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00004ACA File Offset: 0x00002CCA
		public LogicClientAvatar RemoveLogicClientAvatar()
		{
			LogicClientAvatar result = this.logicClientAvatar_0;
			this.logicClientAvatar_0 = null;
			return result;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00004AD9 File Offset: 0x00002CD9
		public void SetAvatar(LogicClientAvatar avatar)
		{
			this.logicClientAvatar_0 = avatar;
		}

		// Token: 0x040001B0 RID: 432
		public const int MESSAGE_TYPE = 20262;

		// Token: 0x040001B1 RID: 433
		private LogicLong logicLong_0;

		// Token: 0x040001B2 RID: 434
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x040001B3 RID: 435
		private string string_0;

		// Token: 0x040001B4 RID: 436
		private string string_1;
	}
}
