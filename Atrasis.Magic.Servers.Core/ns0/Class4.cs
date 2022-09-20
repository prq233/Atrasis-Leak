using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;

namespace ns0
{
	// Token: 0x0200002B RID: 43
	internal class Class4
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x0000B274 File Offset: 0x00009474
		public Class4(ServerMessageManager serverMessageManager_1)
		{
			this.bool_0 = true;
			this.concurrentQueue_0 = new ConcurrentQueue<Class4.Struct0>();
			this.concurrentQueue_1 = new ConcurrentQueue<ServerMessage>();
			this.autoResetEvent_0 = new AutoResetEvent(false);
			this.autoResetEvent_1 = new AutoResetEvent(false);
			this.serverMessageManager_0 = serverMessageManager_1;
			this.thread_0 = new Thread(new ThreadStart(this.method_1));
			this.thread_0.Start();
			this.thread_1 = new Thread(new ThreadStart(this.method_0));
			this.thread_1.Start();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B308 File Offset: 0x00009508
		private void method_0()
		{
			while (this.bool_0)
			{
				this.autoResetEvent_1.WaitOne();
				ServerMessage serverMessage;
				while (this.concurrentQueue_1.TryDequeue(out serverMessage))
				{
					try
					{
						switch (serverMessage.GetMessageCategory())
						{
						case ServerMessageCategory.ACCOUNT:
							this.serverMessageManager_0.OnReceiveAccountMessage((ServerAccountMessage)serverMessage);
							break;
						case ServerMessageCategory.REQUEST:
							this.serverMessageManager_0.OnReceiveRequestMessage((ServerRequestMessage)serverMessage);
							break;
						case ServerMessageCategory.RESPONSE:
							ServerRequestManager.smethod_1((ServerResponseMessage)serverMessage);
							break;
						case ServerMessageCategory.SESSION:
							this.serverMessageManager_0.OnReceiveSessionMessage((ServerSessionMessage)serverMessage);
							break;
						case ServerMessageCategory.CORE:
							if (!ServerMessageManager.smethod_0((ServerCoreMessage)serverMessage))
							{
								this.serverMessageManager_0.OnReceiveCoreMessage((ServerCoreMessage)serverMessage);
							}
							break;
						default:
							Logging.Error("ServerMessageHandler.receive: unknown message category: " + serverMessage.GetMessageCategory());
							break;
						}
					}
					catch (Exception ex)
					{
						Logging.Warning(string.Concat(new object[]
						{
							"ServerMessageHandler.receive: exception when the handle of message type ",
							serverMessage.GetMessageType(),
							", trace: ",
							ex
						}));
					}
				}
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B434 File Offset: 0x00009634
		private void method_1()
		{
			while (this.bool_0)
			{
				this.autoResetEvent_0.WaitOne();
				Class4.Struct0 @struct;
				while (this.concurrentQueue_0.TryDequeue(out @struct))
				{
					byte[] byte_;
					int int_;
					Class2.smethod_4(@struct.Message, out byte_, out int_);
					@struct.Socket.method_0(byte_, int_);
				}
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004EAE File Offset: 0x000030AE
		public void method_2(ServerMessage serverMessage_0)
		{
			this.concurrentQueue_1.Enqueue(serverMessage_0);
			this.autoResetEvent_1.Set();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004EC8 File Offset: 0x000030C8
		public void method_3(ServerMessage serverMessage_0, ServerSocket serverSocket_0)
		{
			this.concurrentQueue_0.Enqueue(new Class4.Struct0(serverMessage_0, serverSocket_0));
			this.autoResetEvent_0.Set();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004EE8 File Offset: 0x000030E8
		public virtual void vmethod_0()
		{
			while (this.concurrentQueue_0.Count != 0 || this.concurrentQueue_1.Count != 0)
			{
				Thread.Sleep(50);
			}
			this.bool_0 = false;
		}

		// Token: 0x040000C6 RID: 198
		private readonly Thread thread_0;

		// Token: 0x040000C7 RID: 199
		private readonly Thread thread_1;

		// Token: 0x040000C8 RID: 200
		private readonly ConcurrentQueue<Class4.Struct0> concurrentQueue_0;

		// Token: 0x040000C9 RID: 201
		private readonly ConcurrentQueue<ServerMessage> concurrentQueue_1;

		// Token: 0x040000CA RID: 202
		private readonly AutoResetEvent autoResetEvent_0;

		// Token: 0x040000CB RID: 203
		private readonly AutoResetEvent autoResetEvent_1;

		// Token: 0x040000CC RID: 204
		private readonly ServerMessageManager serverMessageManager_0;

		// Token: 0x040000CD RID: 205
		private bool bool_0;

		// Token: 0x0200002C RID: 44
		private struct Struct0
		{
			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060000EC RID: 236 RVA: 0x00004F1B File Offset: 0x0000311B
			internal ServerMessage Message { get; }

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060000ED RID: 237 RVA: 0x00004F23 File Offset: 0x00003123
			internal ServerSocket Socket { get; }

			// Token: 0x060000EE RID: 238 RVA: 0x00004F2B File Offset: 0x0000312B
			internal Struct0(ServerMessage serverMessage_1, ServerSocket serverSocket_1)
			{
				this.Message = serverMessage_1;
				this.Socket = serverSocket_1;
			}

			// Token: 0x040000CE RID: 206
			[CompilerGenerated]
			private readonly ServerMessage serverMessage_0;

			// Token: 0x040000CF RID: 207
			[CompilerGenerated]
			private readonly ServerSocket serverSocket_0;
		}
	}
}
