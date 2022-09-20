using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F4 RID: 244
	public class LoginOkMessage : PiranhaMessage
	{
		// Token: 0x06000B16 RID: 2838 RVA: 0x00008383 File Offset: 0x00006583
		public LoginOkMessage() : this(1)
		{
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0000328E File Offset: 0x0000148E
		public LoginOkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x000255F4 File Offset: 0x000237F4
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.logicLong_1 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.string_2 = this.m_stream.ReadString(900000);
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.string_3 = this.m_stream.ReadString(900000);
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.int_5 = this.m_stream.ReadInt();
			this.string_4 = this.m_stream.ReadString(900000);
			this.string_5 = this.m_stream.ReadString(900000);
			this.string_6 = this.m_stream.ReadString(900000);
			this.int_6 = this.m_stream.ReadInt();
			this.string_7 = this.m_stream.ReadString(9000);
			this.string_8 = this.m_stream.ReadString(9000);
			this.m_stream.ReadString(9000);
			this.m_stream.ReadInt();
			this.m_stream.ReadString(9000);
			this.m_stream.ReadString(9000);
			this.m_stream.ReadString(9000);
			int num = this.m_stream.ReadInt();
			if (num != -1)
			{
				this.logicArrayList_0 = new LogicArrayList<string>(num);
				if (num != 0)
				{
					for (int i = 0; i < num; i++)
					{
						this.logicArrayList_0.Add(this.m_stream.ReadString(900000));
					}
				}
			}
			int num2 = this.m_stream.ReadInt();
			if (num2 != -1)
			{
				this.logicArrayList_1 = new LogicArrayList<string>(num2);
				if (num2 != 0)
				{
					for (int j = 0; j < num2; j++)
					{
						this.logicArrayList_1.Add(this.m_stream.ReadString(900000));
					}
				}
			}
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00025844 File Offset: 0x00023A44
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteLong(this.logicLong_1);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteString(this.string_2);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteString(this.string_3);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			this.m_stream.WriteInt(this.int_5);
			this.m_stream.WriteString(this.string_4);
			this.m_stream.WriteString(this.string_5);
			this.m_stream.WriteString(this.string_6);
			this.m_stream.WriteInt(this.int_6);
			this.m_stream.WriteString(this.string_7);
			this.m_stream.WriteString(this.string_8);
			this.m_stream.WriteString(null);
			this.m_stream.WriteInt(1);
			this.m_stream.WriteString(null);
			this.m_stream.WriteString(null);
			this.m_stream.WriteString(null);
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
			if (this.logicArrayList_1 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_1.Size());
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					this.m_stream.WriteString(this.logicArrayList_1[j]);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0000838C File Offset: 0x0000658C
		public override short GetMessageType()
		{
			return 20104;
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00025A78 File Offset: 0x00023C78
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_1 = null;
			this.logicArrayList_0 = null;
			this.string_0 = null;
			this.string_1 = null;
			this.string_2 = null;
			this.string_3 = null;
			this.string_4 = null;
			this.string_5 = null;
			this.string_6 = null;
			this.string_7 = null;
			this.string_8 = null;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00008393 File Offset: 0x00006593
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0000839B File Offset: 0x0000659B
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000083A4 File Offset: 0x000065A4
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x000083AC File Offset: 0x000065AC
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x000083B5 File Offset: 0x000065B5
		public string GetPassToken()
		{
			return this.string_0;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000083BD File Offset: 0x000065BD
		public void SetPassToken(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x000083C6 File Offset: 0x000065C6
		public string GetFacebookId()
		{
			return this.string_1;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x000083CE File Offset: 0x000065CE
		public void SetFacebookId(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x000083D7 File Offset: 0x000065D7
		public string GetGamecenterId()
		{
			return this.string_2;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x000083DF File Offset: 0x000065DF
		public void SetGamecenterId(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x000083E8 File Offset: 0x000065E8
		public string GetServerEnvironment()
		{
			return this.string_3;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x000083F0 File Offset: 0x000065F0
		public void SetServerEnvironment(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x000083F9 File Offset: 0x000065F9
		public string GetFacebookAppId()
		{
			return this.string_4;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00008401 File Offset: 0x00006601
		public void SetFacebookAppId(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0000840A File Offset: 0x0000660A
		public string GetServerTime()
		{
			return this.string_5;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x00008412 File Offset: 0x00006612
		public void SetServerTime(string value)
		{
			this.string_5 = value;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0000841B File Offset: 0x0000661B
		public string GetAccountCreatedDate()
		{
			return this.string_6;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00008423 File Offset: 0x00006623
		public void SetAccountCreatedDate(string value)
		{
			this.string_6 = value;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0000842C File Offset: 0x0000662C
		public string GetGoogleServiceId()
		{
			return this.string_7;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00008434 File Offset: 0x00006634
		public void SetGoogleServiceId(string value)
		{
			this.string_7 = value;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0000843D File Offset: 0x0000663D
		public string GetRegion()
		{
			return this.string_8;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x00008445 File Offset: 0x00006645
		public void SetRegion(string value)
		{
			this.string_8 = value;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0000844E File Offset: 0x0000664E
		public int GetServerMajorVersion()
		{
			return this.int_0;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x00008456 File Offset: 0x00006656
		public void SetServerMajorVersion(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0000845F File Offset: 0x0000665F
		public int GetServerBuildVersion()
		{
			return this.int_1;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00008467 File Offset: 0x00006667
		public void SetServerBuildVersion(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x00008470 File Offset: 0x00006670
		public int GetContentVersion()
		{
			return this.int_2;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00008478 File Offset: 0x00006678
		public void SetContentVersion(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x00008481 File Offset: 0x00006681
		public int GetSessionCount()
		{
			return this.int_3;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x00008489 File Offset: 0x00006689
		public void SetSessionCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00008492 File Offset: 0x00006692
		public int GetPlayTimeSeconds()
		{
			return this.int_4;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0000849A File Offset: 0x0000669A
		public void SetPlayTimeSeconds(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x000084A3 File Offset: 0x000066A3
		public int GetDaysSinceStartedPlaying()
		{
			return this.int_5;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x000084AB File Offset: 0x000066AB
		public void SetDaysSinceStartedPlaying(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x000084B4 File Offset: 0x000066B4
		public int GetStartupCooldownSeconds()
		{
			return this.int_6;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x000084BC File Offset: 0x000066BC
		public void SetStartupCooldownSeconds(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x000084C5 File Offset: 0x000066C5
		public LogicArrayList<string> GetContentUrlList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000084CD File Offset: 0x000066CD
		public void SetContentUrlList(LogicArrayList<string> value)
		{
			this.logicArrayList_0 = value;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x000084D6 File Offset: 0x000066D6
		public LogicArrayList<string> GetChronosContentUrlList()
		{
			return this.logicArrayList_1;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x000084DE File Offset: 0x000066DE
		public void SetChronosContentUrlList(LogicArrayList<string> value)
		{
			this.logicArrayList_1 = value;
		}

		// Token: 0x04000460 RID: 1120
		public const int MESSAGE_TYPE = 20104;

		// Token: 0x04000461 RID: 1121
		private LogicLong logicLong_0;

		// Token: 0x04000462 RID: 1122
		private LogicLong logicLong_1;

		// Token: 0x04000463 RID: 1123
		private string string_0;

		// Token: 0x04000464 RID: 1124
		private string string_1;

		// Token: 0x04000465 RID: 1125
		private string string_2;

		// Token: 0x04000466 RID: 1126
		private string string_3;

		// Token: 0x04000467 RID: 1127
		private string string_4;

		// Token: 0x04000468 RID: 1128
		private string string_5;

		// Token: 0x04000469 RID: 1129
		private string string_6;

		// Token: 0x0400046A RID: 1130
		private string string_7;

		// Token: 0x0400046B RID: 1131
		private string string_8;

		// Token: 0x0400046C RID: 1132
		private int int_0;

		// Token: 0x0400046D RID: 1133
		private int int_1;

		// Token: 0x0400046E RID: 1134
		private int int_2;

		// Token: 0x0400046F RID: 1135
		private int int_3;

		// Token: 0x04000470 RID: 1136
		private int int_4;

		// Token: 0x04000471 RID: 1137
		private int int_5;

		// Token: 0x04000472 RID: 1138
		private int int_6;

		// Token: 0x04000473 RID: 1139
		private LogicArrayList<string> logicArrayList_0;

		// Token: 0x04000474 RID: 1140
		private LogicArrayList<string> logicArrayList_1;
	}
}
