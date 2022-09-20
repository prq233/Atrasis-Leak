using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Session
{
	// Token: 0x0200001D RID: 29
	public class ServerSession
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00004B57 File Offset: 0x00002D57
		public long Id { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00004B5F File Offset: 0x00002D5F
		public string Country { get; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00004B67 File Offset: 0x00002D67
		public LogicLong AccountId { get; }

		// Token: 0x060000A1 RID: 161 RVA: 0x00004B6F File Offset: 0x00002D6F
		public ServerSession(long sessionId, LogicLong accountId, string country)
		{
			this.Id = sessionId;
			this.AccountId = accountId;
			this.Country = country;
			this.m_sockets = new ServerSocket[30];
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A944 File Offset: 0x00008B44
		public ServerSession(StartServerSessionMessage message) : this(message.SessionId, message.AccountId, message.Country)
		{
			LogicArrayList<int> serverSocketTypeList = message.ServerSocketTypeList;
			LogicArrayList<int> serverSocketIdList = message.ServerSocketIdList;
			for (int i = 0; i < serverSocketTypeList.Size(); i++)
			{
				int num = serverSocketTypeList[i];
				int id = serverSocketIdList[i];
				this.m_sockets[num] = ServerManager.GetSocket(num, id);
			}
			if (message.BindRequestMessage != null)
			{
				ServerRequestManager.SendResponse(new BindServerSocketResponseMessage
				{
					ServerType = ServerCore.Type,
					ServerId = ServerCore.Id,
					Success = true
				}, message.BindRequestMessage);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004B99 File Offset: 0x00002D99
		public virtual void Destruct()
		{
			if (!this.m_destructed)
			{
				Array.Clear(this.m_sockets, 0, 30);
				this.m_destructed = true;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004BB8 File Offset: 0x00002DB8
		public bool IsDestructed()
		{
			return this.m_destructed;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004BC0 File Offset: 0x00002DC0
		public virtual void UpdateSocketServerSessionMessageReceived(UpdateSocketServerSessionMessage message)
		{
			this.m_sockets[message.ServerType] = ((message.ServerId != -1) ? ServerManager.GetSocket(message.ServerType, message.ServerId) : null);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004BEC File Offset: 0x00002DEC
		public void SendMessage(ServerSessionMessage message, int serverType)
		{
			message.SessionId = this.Id;
			if (this.m_sockets[serverType] != null)
			{
				ServerMessageManager.SendMessage(message, this.m_sockets[serverType]);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000A9E0 File Offset: 0x00008BE0
		public void SendPiranhaMessage(PiranhaMessage message, int serverType)
		{
			if (message.GetByteStream().GetLength() == 0)
			{
				message.Encode();
			}
			this.SendMessage(new ForwardLogicMessage
			{
				MessageType = message.GetMessageType(),
				MessageVersion = (short)message.GetMessageVersion(),
				MessageLength = message.GetEncodingLength(),
				MessageBytes = message.GetByteStream().GetByteArray()
			}, serverType);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004C12 File Offset: 0x00002E12
		public ServerSocket GetSocket(int type)
		{
			return this.m_sockets[type];
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004C1C File Offset: 0x00002E1C
		public bool IsBoundToServerType(int type)
		{
			return this.m_sockets[type] != null;
		}

		// Token: 0x0400003F RID: 63
		[CompilerGenerated]
		private readonly long long_0;

		// Token: 0x04000040 RID: 64
		[CompilerGenerated]
		private readonly string string_0;

		// Token: 0x04000041 RID: 65
		[CompilerGenerated]
		private readonly LogicLong logicLong_0;

		// Token: 0x04000042 RID: 66
		protected readonly ServerSocket[] m_sockets;

		// Token: 0x04000043 RID: 67
		protected bool m_destructed;
	}
}
