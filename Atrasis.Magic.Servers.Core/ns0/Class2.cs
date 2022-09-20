using System;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Titan.DataStream;

namespace ns0
{
	// Token: 0x02000020 RID: 32
	internal static class Class2
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x00004C99 File Offset: 0x00002E99
		internal static void smethod_0(ServerMessageManager serverMessageManager_0)
		{
			Class2.class4_0 = new Class4(serverMessageManager_0);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004CA6 File Offset: 0x00002EA6
		public static void smethod_1()
		{
			if (Class2.class4_0 != null)
			{
				Class2.class4_0.vmethod_0();
				Class2.class4_0 = null;
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000AC24 File Offset: 0x00008E24
		internal static void smethod_2(byte[] byte_0, int int_0)
		{
			ServerMessage serverMessage = Class2.smethod_3(byte_0, int_0);
			if (serverMessage != null)
			{
				Class2.class4_0.method_2(serverMessage);
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000AC48 File Offset: 0x00008E48
		internal static ServerMessage smethod_3(byte[] byte_0, int int_0)
		{
			ByteStream byteStream = new ByteStream(byte_0, int_0);
			ServerMessage serverMessage = ServerMessageFactory.CreateMessageByType((ServerMessageType)byteStream.ReadShort());
			if (serverMessage != null)
			{
				ServerMessage result;
				try
				{
					serverMessage.DecodeHeader(byteStream);
					serverMessage.Decode(byteStream);
					result = serverMessage;
				}
				catch (Exception arg)
				{
					Logging.Error(string.Format("ServerMessaging.onReceive exception when the decoding of message type {0}, trace: {1}", serverMessage.GetMessageType(), arg));
					goto IL_49;
				}
				return result;
			}
			IL_49:
			return null;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		internal static void smethod_4(ServerMessage serverMessage_0, out byte[] byte_0, out int int_0)
		{
			ByteStream byteStream = new ByteStream(64);
			byteStream.WriteShort((short)serverMessage_0.GetMessageType());
			serverMessage_0.EncodeHeader(byteStream);
			serverMessage_0.Encode(byteStream);
			byte_0 = byteStream.GetByteArray();
			int_0 = byteStream.GetOffset();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004CBF File Offset: 0x00002EBF
		internal static void smethod_5(ServerMessage serverMessage_0, ServerSocket serverSocket_0)
		{
			if (serverSocket_0 == null)
			{
				Logging.Warning("ServerMessaging.send - socket is NULL");
				return;
			}
			serverMessage_0.SenderType = ServerCore.Type;
			serverMessage_0.SenderId = ServerCore.Id;
			Class2.class4_0.method_3(serverMessage_0, serverSocket_0);
		}

		// Token: 0x0400004A RID: 74
		private static Class4 class4_0;
	}
}
