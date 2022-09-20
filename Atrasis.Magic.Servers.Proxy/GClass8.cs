using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Account;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Avatar;
using Atrasis.Magic.Logic.Message.Facebook;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Message.Security;

namespace ns0
{
	// Token: 0x02000010 RID: 16
	public class GClass8
	{
		// Token: 0x06000062 RID: 98 RVA: 0x0000242E File Offset: 0x0000062E
		public GClass8(GClass3 gclass3_1)
		{
			this.gclass3_0 = gclass3_1;
			this.dateTime_0 = DateTime.UtcNow;
			this.dictionary_0 = new Dictionary<short, DateTime>();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000036B0 File Offset: 0x000018B0
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			int messageType = (int)piranhaMessage_0.GetMessageType();
			int serviceNodeType = piranhaMessage_0.GetServiceNodeType();
			GEnum0 genum = this.gclass3_0.method_11();
			if (genum != GEnum0.const_2)
			{
				if (genum == GEnum0.const_4)
				{
					return;
				}
				if (messageType != 10100 && messageType != 10101 && messageType != 10108 && messageType != 10121)
				{
					return;
				}
			}
			if (serviceNodeType == 1)
			{
				if (messageType <= 10108)
				{
					if (messageType == 10100)
					{
						this.method_2((ClientHelloMessage)piranhaMessage_0);
						return;
					}
					if (messageType == 10101)
					{
						this.method_3((LoginMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 10108)
					{
						return;
					}
					this.method_5((KeepAliveMessage)piranhaMessage_0);
					return;
				}
				else
				{
					if (messageType == 10121)
					{
						this.method_6((UnlockAccountMessage)piranhaMessage_0);
						return;
					}
					if (messageType == 14201)
					{
						this.method_7((BindFacebookAccountMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14211)
					{
						return;
					}
					this.method_8((UnbindFacebookAccountMessage)piranhaMessage_0);
					return;
				}
			}
			else
			{
				if (genum != GEnum0.const_2)
				{
					return;
				}
				GClass1 gclass = this.gclass3_0.method_3();
				if (gclass == null)
				{
					return;
				}
				if (!this.method_1(piranhaMessage_0))
				{
					if (serviceNodeType != 28)
					{
						if (serviceNodeType != 29)
						{
							gclass.SendPiranhaMessage(piranhaMessage_0, serviceNodeType);
							return;
						}
					}
					this.method_9(piranhaMessage_0, ServerManager.GetNextSocket(serviceNodeType));
					return;
				}
				if (messageType == 14302)
				{
					this.method_9(piranhaMessage_0, ServerManager.GetDocumentSocket(11, ((AskForAllianceDataMessage)piranhaMessage_0).RemoveAllianceId()));
					return;
				}
				if (messageType == 14325)
				{
					this.method_9(piranhaMessage_0, ServerManager.GetDocumentSocket(9, ((AskForAvatarProfileMessage)piranhaMessage_0).RemoveAvatarId()) ?? ServerManager.GetNextSocket(9));
					return;
				}
				return;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003820 File Offset: 0x00001A20
		private bool method_1(PiranhaMessage piranhaMessage_0)
		{
			int messageType = (int)piranhaMessage_0.GetMessageType();
			return messageType == 14325 || messageType == 14302;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003848 File Offset: 0x00001A48
		private void method_2(ClientHelloMessage clientHelloMessage_0)
		{
			if (this.gclass3_0.method_11() == GEnum0.const_0 && this.method_13(clientHelloMessage_0.GetMajorVersion(), clientHelloMessage_0.GetBuildVersion(), null, clientHelloMessage_0.GetContentHash(), clientHelloMessage_0.GetDeviceType() == 2) && this.method_14())
			{
				Logging.Warning("MessageManager.clientHelloMessageReceived: pepper encryption not supported");
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003898 File Offset: 0x00001A98
		private void method_3(LoginMessage loginMessage_0)
		{
			GClass8.Struct2 @struct;
			@struct.gclass8_0 = this;
			@struct.loginMessage_0 = loginMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass8.Struct2>(ref @struct);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000038DC File Offset: 0x00001ADC
		private void method_4(ServerRequestArgs serverRequestArgs_0)
		{
			if (!this.gclass3_0.method_7())
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					if (this.gclass3_0.method_11() == GEnum0.const_2)
					{
						this.gclass3_0.method_3().method_6();
						return;
					}
				}
				else
				{
					GClass4.smethod_7(this.gclass3_0, 0);
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002453 File Offset: 0x00000653
		private void method_5(KeepAliveMessage keepAliveMessage_0)
		{
			this.dateTime_0 = DateTime.UtcNow;
			this.method_11(new KeepAliveServerMessage());
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003938 File Offset: 0x00001B38
		private void method_6(UnlockAccountMessage unlockAccountMessage_0)
		{
			GClass8.Struct3 @struct;
			@struct.gclass8_0 = this;
			@struct.unlockAccountMessage_0 = unlockAccountMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass8.Struct3>(ref @struct);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000246B File Offset: 0x0000066B
		private void method_7(BindFacebookAccountMessage bindFacebookAccountMessage_0)
		{
			this.method_11(new FacebookAccountBoundMessage());
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002478 File Offset: 0x00000678
		private void method_8(UnbindFacebookAccountMessage unbindFacebookAccountMessage_0)
		{
			this.method_11(new UnbindFacebookAccountMessage());
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000397C File Offset: 0x00001B7C
		private void method_9(PiranhaMessage piranhaMessage_0, ServerSocket serverSocket_0)
		{
			if (serverSocket_0 != null)
			{
				if (this.method_1(piranhaMessage_0) && !this.method_10(piranhaMessage_0.GetMessageType()))
				{
					return;
				}
				ServerMessageManager.SendMessage(new ForwardLogicRequestMessage
				{
					SessionId = this.gclass3_0.method_3().Id,
					AccountId = this.gclass3_0.method_3().AccountId,
					MessageType = piranhaMessage_0.GetMessageType(),
					MessageVersion = (short)piranhaMessage_0.GetMessageVersion(),
					MessageLength = piranhaMessage_0.GetEncodingLength(),
					MessageBytes = piranhaMessage_0.GetMessageBytes()
				}, serverSocket_0);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003A10 File Offset: 0x00001C10
		private bool method_10(short short_0)
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime value;
			if (this.dictionary_0.TryGetValue(short_0, out value))
			{
				if (utcNow.Subtract(value).TotalMilliseconds < 500.0)
				{
					return false;
				}
				this.dictionary_0[short_0] = utcNow;
			}
			else
			{
				this.dictionary_0.Add(short_0, utcNow);
			}
			return true;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003A70 File Offset: 0x00001C70
		public void method_11(PiranhaMessage piranhaMessage_0)
		{
			GEnum0 genum = this.gclass3_0.method_11();
			if (genum != GEnum0.const_2)
			{
				if (genum == GEnum0.const_4)
				{
					return;
				}
				int messageType = (int)piranhaMessage_0.GetMessageType();
				if (messageType != 20103 && messageType != 20104 && messageType != 20133 && messageType != 20132)
				{
					return;
				}
				if (messageType == 20103)
				{
					this.gclass3_0.method_15(GEnum0.const_3);
				}
			}
			this.gclass3_0.method_1().method_10(piranhaMessage_0);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003AE0 File Offset: 0x00001CE0
		public bool method_12()
		{
			return DateTime.UtcNow.Subtract(this.dateTime_0).TotalSeconds < 30.0;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003B14 File Offset: 0x00001D14
		private bool method_13(int int_0, int int_1, string string_0, string string_1, bool bool_0)
		{
			if (int_0 != 9 || int_1 != 256 || (string_0 != null && !EnvironmentSettings.IsSupportedAppVersion(string_0)))
			{
				LoginFailedMessage loginFailedMessage = new LoginFailedMessage();
				loginFailedMessage.SetErrorCode(LoginFailedMessage.ErrorCode.CLIENT_VERSION);
				loginFailedMessage.SetUpdateUrl(ResourceSettings.GetAppStoreUrl(bool_0));
				this.method_11(loginFailedMessage);
				return false;
			}
			if (string_1 != ResourceManager.FINGERPRINT_SHA)
			{
				LoginFailedMessage loginFailedMessage2 = new LoginFailedMessage();
				loginFailedMessage2.SetErrorCode(LoginFailedMessage.ErrorCode.DATA_VERSION);
				loginFailedMessage2.SetContentUrl(ResourceSettings.GetContentUrl());
				loginFailedMessage2.SetContentUrlList(ResourceSettings.ContentUrlList);
				loginFailedMessage2.SetCompressedFingerprint(ResourceManager.COMPRESSED_FINGERPRINT_DATA);
				this.method_11(loginFailedMessage2);
				return false;
			}
			return true;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003BA4 File Offset: 0x00001DA4
		private bool method_14()
		{
			if ((ServerStatus.Status == ServerStatusType.SHUTDOWN_STARTED || ServerStatus.Status == ServerStatusType.MAINTENANCE) && !EnvironmentSettings.IsDeveloperIP(this.gclass3_0.method_5().ToString()))
			{
				LoginFailedMessage loginFailedMessage = new LoginFailedMessage();
				loginFailedMessage.SetErrorCode(LoginFailedMessage.ErrorCode.SERVER_MAINTENANCE);
				loginFailedMessage.SetEndMaintenanceTime(LogicMath.Max(ServerStatus.Time + ServerStatus.NextTime - TimeUtil.GetTimestamp(), 0));
				this.method_11(loginFailedMessage);
				return false;
			}
			if (GClass2.smethod_0() >= EnvironmentSettings.Settings.Proxy.SessionCapacity)
			{
				LoginFailedMessage loginFailedMessage2 = new LoginFailedMessage();
				loginFailedMessage2.SetErrorCode((LoginFailedMessage.ErrorCode)1000);
				loginFailedMessage2.SetReason("The servers are not able to connect you at this time. Try again in a few minutes.");
				this.method_11(loginFailedMessage2);
				return false;
			}
			return true;
		}

		// Token: 0x04000043 RID: 67
		private readonly GClass3 gclass3_0;

		// Token: 0x04000044 RID: 68
		private DateTime dateTime_0;

		// Token: 0x04000045 RID: 69
		private Dictionary<short, DateTime> dictionary_0;
	}
}
