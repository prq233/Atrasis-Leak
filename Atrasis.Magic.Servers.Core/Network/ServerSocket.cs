using System;
using System.Runtime.CompilerServices;
using NetMQ;
using NetMQ.Sockets;

namespace Atrasis.Magic.Servers.Core.Network
{
	// Token: 0x02000021 RID: 33
	public class ServerSocket
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00004CF1 File Offset: 0x00002EF1
		public int ServerType { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004CF9 File Offset: 0x00002EF9
		public int ServerId { get; }

		// Token: 0x060000BE RID: 190 RVA: 0x0000ACF0 File Offset: 0x00008EF0
		public ServerSocket(int type, int id, string host, int port)
		{
			this.ServerType = type;
			this.ServerId = id;
			this.netMQSocket_0 = new PushSocket(string.Format(">tcp://{0}:{1}", host, port));
			this.netMQSocket_0.Options.SendHighWatermark = 10000;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004D01 File Offset: 0x00002F01
		public void Destruct()
		{
			if (this.netMQSocket_0 != null)
			{
				this.netMQSocket_0.Dispose();
				this.netMQSocket_0 = null;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004D1D File Offset: 0x00002F1D
		internal void method_0(byte[] byte_0, int int_2)
		{
			this.netMQSocket_0.SendFrame(byte_0, int_2, false);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004D2D File Offset: 0x00002F2D
		public override string ToString()
		{
			return this.ServerType + "-" + this.ServerId;
		}

		// Token: 0x0400004B RID: 75
		private NetMQSocket netMQSocket_0;

		// Token: 0x0400004C RID: 76
		[CompilerGenerated]
		private readonly int int_0;

		// Token: 0x0400004D RID: 77
		[CompilerGenerated]
		private readonly int int_1;
	}
}
