using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Request;

namespace Atrasis.Magic.Servers.Core.Network.Request
{
	// Token: 0x02000022 RID: 34
	public class ServerRequestArgs
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00004D4F File Offset: 0x00002F4F
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00004D57 File Offset: 0x00002F57
		public ServerRequestArgs.CompleteHandler OnComplete { get; set; } = new ServerRequestArgs.CompleteHandler(ServerRequestArgs.Class3.class3_0.method_0);

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00004D60 File Offset: 0x00002F60
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00004D68 File Offset: 0x00002F68
		public ServerResponseMessage ResponseMessage { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004D71 File Offset: 0x00002F71
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00004D79 File Offset: 0x00002F79
		public ServerRequestError ErrorCode { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00004D82 File Offset: 0x00002F82
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00004D8A File Offset: 0x00002F8A
		internal DateTime ExpireTime { get; set; }

		// Token: 0x060000CA RID: 202 RVA: 0x0000AD44 File Offset: 0x00008F44
		public ServerRequestArgs(int timeout)
		{
			this.ExpireTime = DateTime.UtcNow.AddSeconds((double)timeout);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004D93 File Offset: 0x00002F93
		internal void method_0()
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.ErrorCode = ServerRequestError.Aborted;
				this.OnComplete(this);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004DB7 File Offset: 0x00002FB7
		internal void method_1(ServerResponseMessage serverResponseMessage_1)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				this.ResponseMessage = serverResponseMessage_1;
				this.ErrorCode = ServerRequestError.Success;
				this.OnComplete(this);
			}
		}

		// Token: 0x0400004E RID: 78
		[CompilerGenerated]
		private ServerRequestArgs.CompleteHandler completeHandler_0;

		// Token: 0x0400004F RID: 79
		[CompilerGenerated]
		private ServerResponseMessage serverResponseMessage_0;

		// Token: 0x04000050 RID: 80
		[CompilerGenerated]
		private ServerRequestError serverRequestError_0;

		// Token: 0x04000051 RID: 81
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x04000052 RID: 82
		private bool bool_0;

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x060000CE RID: 206
		public delegate void CompleteHandler(ServerRequestArgs args);

		// Token: 0x02000024 RID: 36
		[CompilerGenerated]
		[Serializable]
		private sealed class Class3
		{
			// Token: 0x060000D3 RID: 211 RVA: 0x00004631 File Offset: 0x00002831
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
			}

			// Token: 0x04000053 RID: 83
			public static readonly ServerRequestArgs.Class3 class3_0 = new ServerRequestArgs.Class3();

			// Token: 0x04000054 RID: 84
			public static ServerRequestArgs.CompleteHandler completeHandler_0;
		}
	}
}
