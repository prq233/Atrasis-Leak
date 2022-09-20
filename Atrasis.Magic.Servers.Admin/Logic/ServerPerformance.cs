using System;
using System.Diagnostics;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Util;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000010 RID: 16
	public class ServerPerformance
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002435 File Offset: 0x00000635
		// (set) Token: 0x06000069 RID: 105 RVA: 0x0000243D File Offset: 0x0000063D
		public ServerPerformanceStatus Status { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002446 File Offset: 0x00000646
		public ServerSocket Socket { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000244E File Offset: 0x0000064E
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00002456 File Offset: 0x00000656
		public ClusterPerformance[] ClusterPerformances { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000245F File Offset: 0x0000065F
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002467 File Offset: 0x00000667
		public int Ping { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002470 File Offset: 0x00000670
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002478 File Offset: 0x00000678
		public int SessionCount { get; private set; }

		// Token: 0x06000071 RID: 113 RVA: 0x00002481 File Offset: 0x00000681
		public ServerPerformance(ServerSocket socket)
		{
			this.Socket = socket;
			this.Status = ServerPerformanceStatus.UNKNOWN;
			this.m_watch = new Stopwatch();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000024A2 File Offset: 0x000006A2
		public void SendPingMessage()
		{
			if (this.m_watch.IsRunning)
			{
				this.Status = ServerPerformanceStatus.OFFLINE;
			}
			ServerMessageManager.SendMessage(new PingMessage(), this.Socket);
			this.m_watch.Restart();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000024D3 File Offset: 0x000006D3
		public void OnPongMessageReceived()
		{
			this.m_watch.Stop();
			this.Ping = (int)this.m_watch.ElapsedMilliseconds;
			this.Status = ServerPerformanceStatus.ONLINE;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003618 File Offset: 0x00001818
		public void OnServerPerformanceDataMessageReceived(ServerPerformanceDataMessage message)
		{
			this.SessionCount = message.SessionCount;
			if ((this.ClusterPerformances == null) ? (message.ClusterCount != 0) : (this.ClusterPerformances.Length != message.ClusterCount))
			{
				this.ClusterPerformances = new ClusterPerformance[message.ClusterCount];
				for (int i = 0; i < this.ClusterPerformances.Length; i++)
				{
					this.ClusterPerformances[i] = new ClusterPerformance();
				}
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000368C File Offset: 0x0000188C
		public void OnClusterPerformanceDataMessageReceived(ClusterPerformanceDataMessage message)
		{
			this.ClusterPerformances[message.Id].Ping = message.Ping;
			this.ClusterPerformances[message.Id].SessionCount = message.SessionCount;
			this.ClusterPerformances[message.Id].Defined = true;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000036DC File Offset: 0x000018DC
		public JObject Save()
		{
			JObject jobject = new JObject();
			jobject.Add("name", string.Format("{0} - {1}", ServerUtil.GetServerName(this.Socket.ServerType), this.Socket.ServerId + 1));
			jobject.Add("status", this.Status.ToString());
			jobject.Add("ping", this.Ping);
			if (this.ClusterPerformances != null)
			{
				JArray jarray = new JArray();
				for (int i = 0; i < this.ClusterPerformances.Length; i++)
				{
					if (this.ClusterPerformances[i].Defined)
					{
						jarray.Add(this.ClusterPerformances[i].Save());
					}
				}
				jobject.Add("clusters", jarray);
			}
			return jobject;
		}

		// Token: 0x04000032 RID: 50
		private readonly Stopwatch m_watch;
	}
}
