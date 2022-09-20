using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F3 RID: 243
	public class LoginMessage : PiranhaMessage
	{
		// Token: 0x06000AE1 RID: 2785 RVA: 0x000081EC File Offset: 0x000063EC
		public LoginMessage() : this(8)
		{
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x00025060 File Offset: 0x00023260
		public LoginMessage(short messageVersion) : base(messageVersion)
		{
			this.string_3 = string.Empty;
			this.string_0 = string.Empty;
			this.string_13 = string.Empty;
			this.string_14 = string.Empty;
			this.string_8 = string.Empty;
			this.string_10 = string.Empty;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x000250B8 File Offset: 0x000232B8
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_9);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(0);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteString(this.string_11);
			this.m_stream.WriteString(this.string_12);
			this.m_stream.WriteString(this.string_5);
			this.m_stream.WriteString(this.string_4);
			this.m_stream.WriteString(this.string_2);
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicData_0);
			this.m_stream.WriteString(this.string_10);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteString(this.string_6);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteStringReference(this.string_3);
			this.m_stream.WriteStringReference(this.string_0);
			this.m_stream.WriteStringReference("");
			this.m_stream.WriteBoolean(false);
			this.m_stream.WriteString("");
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteVInt(this.int_3);
			this.m_stream.WriteStringReference(string.Empty);
			this.m_stream.WriteStringReference(string.Empty);
			this.m_stream.WriteStringReference(this.string_8);
			this.m_stream.WriteStringReference(this.string_13);
			this.m_stream.WriteStringReference(this.string_14);
			this.m_stream.WriteVInt(0);
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00025294 File Offset: 0x00023494
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_9 = this.m_stream.ReadString(900000);
			this.int_1 = this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.string_11 = this.m_stream.ReadString(900000);
			this.string_12 = this.m_stream.ReadString(900000);
			this.string_5 = this.m_stream.ReadString(900000);
			this.string_4 = this.m_stream.ReadString(900000);
			this.string_2 = this.m_stream.ReadString(900000);
			if (!this.m_stream.IsAtEnd())
			{
				this.logicData_0 = ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.LOCALE);
				this.string_10 = this.m_stream.ReadString(900000);
				if (this.string_10 == null)
				{
					this.string_10 = string.Empty;
				}
				if (!this.m_stream.IsAtEnd())
				{
					this.string_1 = this.m_stream.ReadString(900000);
					if (!this.m_stream.IsAtEnd())
					{
						this.string_6 = this.m_stream.ReadString(900000);
						if (!this.m_stream.IsAtEnd())
						{
							this.bool_0 = this.m_stream.ReadBoolean();
							if (!this.m_stream.IsAtEnd())
							{
								this.string_3 = this.m_stream.ReadStringReference(900000);
								this.string_0 = this.m_stream.ReadStringReference(900000);
								if (!this.m_stream.IsAtEnd())
								{
									this.m_stream.ReadString(900000);
									if (!this.m_stream.IsAtEnd())
									{
										this.bool_1 = this.m_stream.ReadBoolean();
										this.string_7 = this.m_stream.ReadString(900000);
										if (!this.m_stream.IsAtEnd())
										{
											this.int_0 = this.m_stream.ReadInt();
											if (!this.m_stream.IsAtEnd())
											{
												this.int_3 = this.m_stream.ReadVInt();
												this.m_stream.ReadStringReference(900000);
												this.m_stream.ReadStringReference(900000);
												if (!this.m_stream.IsAtEnd())
												{
													this.string_8 = this.m_stream.ReadStringReference(900000);
													if (!this.m_stream.IsAtEnd())
													{
														this.string_13 = this.m_stream.ReadStringReference(900000);
														this.string_14 = this.m_stream.ReadStringReference(900000);
														this.m_stream.ReadVInt();
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
			}
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x000081F5 File Offset: 0x000063F5
		public override short GetMessageType()
		{
			return 10101;
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00025584 File Offset: 0x00023784
		public override void Destruct()
		{
			base.Destruct();
			this.string_1 = null;
			this.string_9 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.string_6 = null;
			this.string_0 = null;
			this.string_5 = null;
			this.string_10 = null;
			this.string_11 = null;
			this.string_13 = null;
			this.string_14 = null;
			this.string_12 = null;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x000081FC File Offset: 0x000063FC
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x00008204 File Offset: 0x00006404
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0000820D File Offset: 0x0000640D
		public LogicData GetPreferredLanguage()
		{
			return this.logicData_0;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00008215 File Offset: 0x00006415
		public void SetPreferredLanguage(LogicData value)
		{
			this.logicData_0 = value;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0000821E File Offset: 0x0000641E
		public bool IsAndroidClient()
		{
			return this.bool_0;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00008226 File Offset: 0x00006426
		public void SetAndroidClient(bool value)
		{
			this.bool_0 = value;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0000822F File Offset: 0x0000642F
		public bool IsAdvertisingEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00008237 File Offset: 0x00006437
		public void SetAdvertisingEnabled(bool value)
		{
			this.bool_1 = value;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00008240 File Offset: 0x00006440
		public int GetScramblerSeed()
		{
			return this.int_0;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00008248 File Offset: 0x00006448
		public void SetScramblerSeed(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00008251 File Offset: 0x00006451
		public int GetClientMajorVersion()
		{
			return this.int_1;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x00008259 File Offset: 0x00006459
		public void SetClientMajorVersion(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00008262 File Offset: 0x00006462
		public int GetClientBuildVersion()
		{
			return this.int_2;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0000826A File Offset: 0x0000646A
		public void SetClientBuildVersion(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x00008273 File Offset: 0x00006473
		public int GetAppStore()
		{
			return this.int_3;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0000827B File Offset: 0x0000647B
		public void SetAppStore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00008284 File Offset: 0x00006484
		public string GetAndroidID()
		{
			return this.string_0;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0000828C File Offset: 0x0000648C
		public void SetAndroidID(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x00008295 File Offset: 0x00006495
		public string GetADID()
		{
			return this.string_1;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0000829D File Offset: 0x0000649D
		public void SetADID(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x000082A6 File Offset: 0x000064A6
		public string GetDevice()
		{
			return this.string_2;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x000082AE File Offset: 0x000064AE
		public void SetDevice(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x000082B7 File Offset: 0x000064B7
		public string GetIMEI()
		{
			return this.string_3;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x000082BF File Offset: 0x000064BF
		public void SetIMEI(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x000082C8 File Offset: 0x000064C8
		public string GetMacAddress()
		{
			return this.string_4;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x000082D0 File Offset: 0x000064D0
		public void SetMacAddress(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x000082D9 File Offset: 0x000064D9
		public string GetOpenUDID()
		{
			return this.string_5;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x000082E1 File Offset: 0x000064E1
		public void SetOpenUDID(string value)
		{
			this.string_5 = value;
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000082EA File Offset: 0x000064EA
		public string GetOSVersion()
		{
			return this.string_6;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x000082F2 File Offset: 0x000064F2
		public void SetOSVersion(string value)
		{
			this.string_6 = value;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x000082FB File Offset: 0x000064FB
		public string GetAdvertisingId()
		{
			return this.string_7;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00008303 File Offset: 0x00006503
		public void SetAdvertisingId(string value)
		{
			this.string_7 = value;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0000830C File Offset: 0x0000650C
		public string GetAppVersion()
		{
			return this.string_8;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00008314 File Offset: 0x00006514
		public void SetAppVersion(string value)
		{
			this.string_8 = value;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0000831D File Offset: 0x0000651D
		public string GetPassToken()
		{
			return this.string_9;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00008325 File Offset: 0x00006525
		public void SetPassToken(string value)
		{
			this.string_9 = value;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0000832E File Offset: 0x0000652E
		public string GetPreferredDeviceLanguage()
		{
			return this.string_10;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x00008336 File Offset: 0x00006536
		public void SetPreferredDeviceLanguage(string value)
		{
			this.string_10 = value;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0000833F File Offset: 0x0000653F
		public string GetResourceSha()
		{
			return this.string_11;
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00008347 File Offset: 0x00006547
		public void SetResourceSha(string value)
		{
			this.string_11 = value;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00008350 File Offset: 0x00006550
		public string GetUDID()
		{
			return this.string_12;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00008358 File Offset: 0x00006558
		public void SetUDID(string value)
		{
			this.string_12 = value;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00008361 File Offset: 0x00006561
		public string GetKunlunSSO()
		{
			return this.string_13;
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00008369 File Offset: 0x00006569
		public void SetKunlunSSO(string value)
		{
			this.string_13 = value;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00008372 File Offset: 0x00006572
		public string GetKunlunUID()
		{
			return this.string_14;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0000837A File Offset: 0x0000657A
		public void SetKunlunUID(string value)
		{
			this.string_14 = value;
		}

		// Token: 0x04000448 RID: 1096
		public const int MESSAGE_TYPE = 10101;

		// Token: 0x04000449 RID: 1097
		private LogicLong logicLong_0;

		// Token: 0x0400044A RID: 1098
		private LogicData logicData_0;

		// Token: 0x0400044B RID: 1099
		private bool bool_0;

		// Token: 0x0400044C RID: 1100
		private bool bool_1;

		// Token: 0x0400044D RID: 1101
		private int int_0;

		// Token: 0x0400044E RID: 1102
		private int int_1;

		// Token: 0x0400044F RID: 1103
		private int int_2;

		// Token: 0x04000450 RID: 1104
		private int int_3;

		// Token: 0x04000451 RID: 1105
		private string string_0;

		// Token: 0x04000452 RID: 1106
		private string string_1;

		// Token: 0x04000453 RID: 1107
		private string string_2;

		// Token: 0x04000454 RID: 1108
		private string string_3;

		// Token: 0x04000455 RID: 1109
		private string string_4;

		// Token: 0x04000456 RID: 1110
		private string string_5;

		// Token: 0x04000457 RID: 1111
		private string string_6;

		// Token: 0x04000458 RID: 1112
		private string string_7;

		// Token: 0x04000459 RID: 1113
		private string string_8;

		// Token: 0x0400045A RID: 1114
		private string string_9;

		// Token: 0x0400045B RID: 1115
		private string string_10;

		// Token: 0x0400045C RID: 1116
		private string string_11;

		// Token: 0x0400045D RID: 1117
		private string string_12;

		// Token: 0x0400045E RID: 1118
		private string string_13;

		// Token: 0x0400045F RID: 1119
		private string string_14;
	}
}
