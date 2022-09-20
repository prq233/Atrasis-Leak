using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F1 RID: 241
	public class LoginFailedMessage : PiranhaMessage
	{
		// Token: 0x06000AC6 RID: 2758 RVA: 0x000080E3 File Offset: 0x000062E3
		public LoginFailedMessage() : this(9)
		{
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x000080ED File Offset: 0x000062ED
		public LoginFailedMessage(short messageVersion) : base(messageVersion)
		{
			this.byte_0 = new byte[0];
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00024D70 File Offset: 0x00022F70
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (LoginFailedMessage.ErrorCode)this.m_stream.ReadInt();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.string_4 = this.m_stream.ReadString(900000);
			if (this.m_version >= 1)
			{
				this.string_3 = this.m_stream.ReadString(900000);
				if (this.m_version >= 2)
				{
					this.string_2 = this.m_stream.ReadString(900000);
					if (this.m_version >= 3)
					{
						this.int_0 = this.m_stream.ReadInt();
						if (this.m_version >= 4)
						{
							this.bool_0 = this.m_stream.ReadBoolean();
							if (this.m_version >= 5)
							{
								this.byte_0 = this.m_stream.ReadBytes(this.m_stream.ReadBytesLength(), 900000);
								int num = this.m_stream.ReadInt();
								if (num != -1)
								{
									this.logicArrayList_0 = new LogicArrayList<string>(num);
									for (int i = 0; i < num; i++)
									{
										this.logicArrayList_0.Add(this.m_stream.ReadString(900000));
									}
								}
								if (this.m_version >= 6)
								{
									this.m_stream.ReadInt();
									if (this.m_version >= 7)
									{
										this.m_stream.ReadInt();
										if (this.m_version >= 8)
										{
											this.m_stream.ReadString(900000);
											if (this.m_version >= 9)
											{
												this.m_stream.ReadInt();
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00024F20 File Offset: 0x00023120
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteString(this.string_4);
			this.m_stream.WriteString(this.string_3);
			this.m_stream.WriteString(this.string_2);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteBytes(this.byte_0, this.byte_0.Length);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.m_stream.WriteString(this.logicArrayList_0[i]);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			this.m_stream.WriteInt(0);
			this.m_stream.WriteInt(0);
			this.m_stream.WriteString(null);
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00008102 File Offset: 0x00006302
		public override short GetMessageType()
		{
			return 20103;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00008109 File Offset: 0x00006309
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.byte_0 = null;
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00008142 File Offset: 0x00006342
		public LogicArrayList<string> GetContentUrlList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0000814A File Offset: 0x0000634A
		public void SetContentUrlList(LogicArrayList<string> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00008153 File Offset: 0x00006353
		public bool IsBannedShowHelpshiftContact()
		{
			return this.bool_0;
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0000815B File Offset: 0x0000635B
		public void SetBannedShowHelpshiftContact(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00008164 File Offset: 0x00006364
		public LoginFailedMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0000816C File Offset: 0x0000636C
		public void SetErrorCode(LoginFailedMessage.ErrorCode value)
		{
			this.errorCode_0 = value;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00008175 File Offset: 0x00006375
		public int GetEndMaintenanceTime()
		{
			return this.int_0;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0000817D File Offset: 0x0000637D
		public void SetEndMaintenanceTime(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00008186 File Offset: 0x00006386
		public string GetResourceFingerprintContent()
		{
			return this.string_0;
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0000818E File Offset: 0x0000638E
		public void SetResourceFingerprintContent(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00008197 File Offset: 0x00006397
		public string GetRedirectDomain()
		{
			return this.string_1;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0000819F File Offset: 0x0000639F
		public void SetRedirectDomain(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x000081A8 File Offset: 0x000063A8
		public string GetReason()
		{
			return this.string_2;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x000081B0 File Offset: 0x000063B0
		public void SetReason(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x000081B9 File Offset: 0x000063B9
		public string GetUpdateUrl()
		{
			return this.string_3;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x000081C1 File Offset: 0x000063C1
		public void SetUpdateUrl(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000081CA File Offset: 0x000063CA
		public string GetContentUrl()
		{
			return this.string_4;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x000081D2 File Offset: 0x000063D2
		public void SetContentUrl(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x000081DB File Offset: 0x000063DB
		public byte[] GetCompressedFingerprint()
		{
			return this.byte_0;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x000081E3 File Offset: 0x000063E3
		public void SetCompressedFingerprint(byte[] value)
		{
			this.byte_0 = value;
		}

		// Token: 0x0400042E RID: 1070
		public const int MESSAGE_TYPE = 20103;

		// Token: 0x0400042F RID: 1071
		private LogicArrayList<string> logicArrayList_0;

		// Token: 0x04000430 RID: 1072
		private bool bool_0;

		// Token: 0x04000431 RID: 1073
		private LoginFailedMessage.ErrorCode errorCode_0;

		// Token: 0x04000432 RID: 1074
		private int int_0;

		// Token: 0x04000433 RID: 1075
		private string string_0;

		// Token: 0x04000434 RID: 1076
		private string string_1;

		// Token: 0x04000435 RID: 1077
		private string string_2;

		// Token: 0x04000436 RID: 1078
		private string string_3;

		// Token: 0x04000437 RID: 1079
		private string string_4;

		// Token: 0x04000438 RID: 1080
		private byte[] byte_0;

		// Token: 0x020000F2 RID: 242
		public enum ErrorCode
		{
			// Token: 0x0400043A RID: 1082
			ACCOUNT_NOT_EXISTS = 1,
			// Token: 0x0400043B RID: 1083
			DATA_VERSION = 7,
			// Token: 0x0400043C RID: 1084
			CLIENT_VERSION,
			// Token: 0x0400043D RID: 1085
			REDIRECTION,
			// Token: 0x0400043E RID: 1086
			SERVER_MAINTENANCE,
			// Token: 0x0400043F RID: 1087
			BANNED,
			// Token: 0x04000440 RID: 1088
			PERSONAL_BREAK,
			// Token: 0x04000441 RID: 1089
			ACCOUNT_LOCKED,
			// Token: 0x04000442 RID: 1090
			WRONG_STORE = 15,
			// Token: 0x04000443 RID: 1091
			VERSION_NOT_UP_TO_DATE_STORE_NOT_READY,
			// Token: 0x04000444 RID: 1092
			CHINESE_APP_STORE_CONFLICT_MESSAGE = 18,
			// Token: 0x04000445 RID: 1093
			PERSONAL_BREAK_EXTENDED,
			// Token: 0x04000446 RID: 1094
			PERSONAL_BREAK_EXTENDED_FINAL,
			// Token: 0x04000447 RID: 1095
			PERSONAL_BREAK_FINAL
		}
	}
}
