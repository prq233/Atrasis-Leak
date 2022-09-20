using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;

namespace Atrasis.Magic.Servers.Core.Cluster
{
	// Token: 0x020000F5 RID: 245
	public class ClusterInstance
	{
		// Token: 0x06000756 RID: 1878 RVA: 0x00017430 File Offset: 0x00015630
		public ClusterInstance(int id, int logicUpdateFrequency = -1)
		{
			this.bool_0 = true;
			this.m_id = id;
			this.concurrentQueue_0 = new ConcurrentQueue<ServerMessage>();
			this.autoResetEvent_0 = new AutoResetEvent(false);
			this.thread_0 = new Thread(new ThreadStart(this.method_0));
			this.thread_0.Name = "Cluster: Network Thread";
			if (logicUpdateFrequency >= 0)
			{
				this.m_logicUpdateFrequency = logicUpdateFrequency;
				this.thread_1 = new Thread(new ThreadStart(this.method_1));
				this.thread_1.Name = "Cluster: Logic Thread";
				this.thread_1.Start();
			}
			this.thread_0.Start();
			this.stopwatch_0 = new Stopwatch();
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00009149 File Offset: 0x00007349
		public void Stop()
		{
			this.bool_0 = false;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x000174E4 File Offset: 0x000156E4
		private void method_0()
		{
			while (this.bool_0)
			{
				this.autoResetEvent_0.WaitOne();
				ServerMessage serverMessage;
				while (this.concurrentQueue_0.TryDequeue(out serverMessage))
				{
					if (serverMessage.GetMessageType() != ServerMessageType.SERVER_CLUSTER_PING)
					{
						this.ReceiveMessage(serverMessage);
					}
					else
					{
						this.stopwatch_0.Stop();
						this.m_ping = (int)this.stopwatch_0.ElapsedMilliseconds;
						this.stopwatch_0.Reset();
						this.OnPingTestCompleted();
					}
				}
			}
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00009152 File Offset: 0x00007352
		private void method_1()
		{
			while (this.bool_0)
			{
				Thread.Sleep(this.m_logicUpdateFrequency);
				this.Tick();
			}
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00004631 File Offset: 0x00002831
		protected virtual void ReceiveMessage(ServerMessage message)
		{
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00004631 File Offset: 0x00002831
		protected virtual void Tick()
		{
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00004631 File Offset: 0x00002831
		protected virtual void OnPingTestCompleted()
		{
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00009170 File Offset: 0x00007370
		public void SendMessage(ServerMessage message)
		{
			this.concurrentQueue_0.Enqueue(message);
			this.autoResetEvent_0.Set();
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0000918A File Offset: 0x0000738A
		public void SendPing()
		{
			if (!this.stopwatch_0.IsRunning)
			{
				this.stopwatch_0.Start();
				this.SendMessage(ClusterInstance.serverClusterPingMessage_0);
			}
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x000091AF File Offset: 0x000073AF
		public int GetId()
		{
			return this.m_id;
		}

		// Token: 0x0400042C RID: 1068
		private static readonly ServerClusterPingMessage serverClusterPingMessage_0 = new ServerClusterPingMessage();

		// Token: 0x0400042D RID: 1069
		private bool bool_0;

		// Token: 0x0400042E RID: 1070
		protected readonly int m_id;

		// Token: 0x0400042F RID: 1071
		protected readonly int m_logicUpdateFrequency;

		// Token: 0x04000430 RID: 1072
		private readonly Thread thread_0;

		// Token: 0x04000431 RID: 1073
		private readonly Thread thread_1;

		// Token: 0x04000432 RID: 1074
		private readonly ConcurrentQueue<ServerMessage> concurrentQueue_0;

		// Token: 0x04000433 RID: 1075
		private readonly AutoResetEvent autoResetEvent_0;

		// Token: 0x04000434 RID: 1076
		private readonly Stopwatch stopwatch_0;

		// Token: 0x04000435 RID: 1077
		protected int m_ping;
	}
}
