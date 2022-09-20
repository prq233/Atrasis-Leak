using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Chat;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002165 File Offset: 0x00000365
		public GClass3(GClass1 gclass1_1)
		{
			this.gclass1_0 = gclass1_1;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002174 File Offset: 0x00000374
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			if (piranhaMessage_0.GetMessageType() == 14715)
			{
				this.method_1((SendGlobalChatLineMessage)piranhaMessage_0);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002274 File Offset: 0x00000474
		private void method_1(SendGlobalChatLineMessage sendGlobalChatLineMessage_0)
		{
			GClass3.Class1 @class = new GClass3.Class1();
			@class.gclass3_0 = this;
			if (!this.method_2())
			{
				return;
			}
			@class.string_0 = StringUtil.RemoveMultipleSpaces(sendGlobalChatLineMessage_0.RemoveMessage());
			if (@class.string_0.Length > 0)
			{
				if (@class.string_0.Length > 128)
				{
					@class.string_0 = @class.string_0.Substring(0, 128);
				}
				if (@class.string_0.StartsWith("/op "))
				{
					GlobalChatLineMessage globalChatLineMessage = new GlobalChatLineMessage();
					globalChatLineMessage.SetMessage("OP commands must be executed in the News menu");
					globalChatLineMessage.SetAvatarId(new LogicLong(0, 1));
					globalChatLineMessage.SetHomeId(new LogicLong(0, 1));
					globalChatLineMessage.SetAvatarExpLevel(500);
					globalChatLineMessage.SetAvatarLeagueType(LogicDataTables.GetTable(LogicDataType.LEAGUE).GetItemCount() - 1);
					globalChatLineMessage.SetAvatarName("Atrasis - Bot");
					this.gclass1_0.SendPiranhaMessage(globalChatLineMessage, 1);
					return;
				}
				ServerRequestManager.Create(new AvatarRequestMessage
				{
					AccountId = this.gclass1_0.AccountId
				}, ServerManager.GetDocumentSocket(9, this.gclass1_0.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002398 File Offset: 0x00000598
		private bool method_2()
		{
			return DateTime.UtcNow.Subtract(this.dateTime_0).TotalSeconds >= 1.0;
		}

		// Token: 0x04000004 RID: 4
		private readonly GClass1 gclass1_0;

		// Token: 0x04000005 RID: 5
		private DateTime dateTime_0;

		// Token: 0x02000007 RID: 7
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x06000013 RID: 19 RVA: 0x000023D0 File Offset: 0x000005D0
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					this.gclass3_0.gclass1_0.method_1().method_3(((AvatarResponseMessage)serverRequestArgs_0.ResponseMessage).LogicClientAvatar, WordCensorUtil.FilterMessage(this.string_0));
					this.gclass3_0.dateTime_0 = DateTime.UtcNow;
				}
			}

			// Token: 0x04000006 RID: 6
			public GClass3 gclass3_0;

			// Token: 0x04000007 RID: 7
			public string string_0;
		}
	}
}
