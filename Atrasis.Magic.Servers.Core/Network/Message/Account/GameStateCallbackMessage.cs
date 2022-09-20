using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B8 RID: 184
	public class GameStateCallbackMessage : ServerAccountMessage
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00007AD6 File Offset: 0x00005CD6
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x00007ADE File Offset: 0x00005CDE
		public LogicClientAvatar LogicClientAvatar { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x00007AE7 File Offset: 0x00005CE7
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x00007AEF File Offset: 0x00005CEF
		public LogicArrayList<AvatarChange> AvatarChanges { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x00007AF8 File Offset: 0x00005CF8
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x00007B00 File Offset: 0x00005D00
		public LogicArrayList<LogicServerCommand> ExecutedServerCommands { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00007B09 File Offset: 0x00005D09
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x00007B11 File Offset: 0x00005D11
		public int SaveTime { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x00007B1A File Offset: 0x00005D1A
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x00007B22 File Offset: 0x00005D22
		public byte[] HomeJSON { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x00007B2B File Offset: 0x00005D2B
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x00007B33 File Offset: 0x00005D33
		public long SessionId { get; set; }

		// Token: 0x06000530 RID: 1328 RVA: 0x0000C914 File Offset: 0x0000AB14
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.AvatarChanges.Size());
			for (int i = 0; i < this.AvatarChanges.Size(); i++)
			{
				AvatarChangeFactory.Encode(stream, this.AvatarChanges[i]);
			}
			if (this.LogicClientAvatar != null)
			{
				stream.WriteBoolean(true);
				this.LogicClientAvatar.Encode(stream);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.HomeJSON != null)
			{
				stream.WriteBoolean(true);
				if (this.ExecutedServerCommands != null)
				{
					stream.WriteBoolean(true);
					stream.WriteVInt(this.ExecutedServerCommands.Size());
					for (int j = 0; j < this.ExecutedServerCommands.Size(); j++)
					{
						LogicCommandManager.EncodeCommand(stream, this.ExecutedServerCommands[j]);
					}
				}
				else
				{
					stream.WriteBoolean(false);
				}
				stream.WriteVInt(this.SaveTime);
				stream.WriteBytes(this.HomeJSON, this.HomeJSON.Length);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0000CA14 File Offset: 0x0000AC14
		public override void Decode(ByteStream stream)
		{
			this.SessionId = stream.ReadLongLong();
			this.AvatarChanges = new LogicArrayList<AvatarChange>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.AvatarChanges.Add(AvatarChangeFactory.Decode(stream));
			}
			if (stream.ReadBoolean())
			{
				this.LogicClientAvatar = new LogicClientAvatar();
				this.LogicClientAvatar.Decode(stream);
			}
			if (stream.ReadBoolean())
			{
				if (stream.ReadBoolean())
				{
					this.ExecutedServerCommands = new LogicArrayList<LogicServerCommand>();
					for (int j = stream.ReadVInt(); j > 0; j--)
					{
						this.ExecutedServerCommands.Add((LogicServerCommand)LogicCommandManager.DecodeCommand(stream));
					}
				}
				this.SaveTime = stream.ReadVInt();
				this.HomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00007B3C File Offset: 0x00005D3C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_STATE_CALLBACK;
		}

		// Token: 0x0400021A RID: 538
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x0400021B RID: 539
		[CompilerGenerated]
		private LogicArrayList<AvatarChange> logicArrayList_0;

		// Token: 0x0400021C RID: 540
		[CompilerGenerated]
		private LogicArrayList<LogicServerCommand> logicArrayList_1;

		// Token: 0x0400021D RID: 541
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400021E RID: 542
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x0400021F RID: 543
		[CompilerGenerated]
		private long long_0;
	}
}
