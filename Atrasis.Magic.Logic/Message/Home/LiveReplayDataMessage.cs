using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000052 RID: 82
	public class LiveReplayDataMessage : PiranhaMessage
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x000043A7 File Offset: 0x000025A7
		public LiveReplayDataMessage() : this(0)
		{
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000328E File Offset: 0x0000148E
		public LiveReplayDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0001C354 File Offset: 0x0001A554
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadVInt();
			this.int_1 = this.m_stream.ReadVInt();
			this.int_2 = this.m_stream.ReadVInt();
			int num = this.m_stream.ReadInt();
			if (num <= 512)
			{
				if (num > 0)
				{
					this.logicArrayList_0 = new LogicArrayList<LogicCommand>(num);
					for (int i = 0; i < num; i++)
					{
						LogicCommand logicCommand = LogicCommandManager.DecodeCommand(this.m_stream);
						if (logicCommand != null)
						{
							this.logicArrayList_0.Add(logicCommand);
						}
					}
					return;
				}
			}
			else
			{
				Debugger.Error(string.Format("LiveReplayDataMessage::decode() command count is too high! ({0})", num));
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001C3FC File Offset: 0x0001A5FC
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteVInt(this.int_0);
			this.m_stream.WriteVInt(this.int_1);
			this.m_stream.WriteVInt(this.int_2);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(this.m_stream, this.logicArrayList_0[i]);
				}
				return;
			}
			this.m_stream.WriteInt(0);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x000043B0 File Offset: 0x000025B0
		public override short GetMessageType()
		{
			return 24119;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x000043B7 File Offset: 0x000025B7
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000043C6 File Offset: 0x000025C6
		public int GetServerSubTick()
		{
			return this.int_0;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000043CE File Offset: 0x000025CE
		public void SetServerSubTick(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000043D7 File Offset: 0x000025D7
		public void SetViewerCount(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000043E0 File Offset: 0x000025E0
		public int GetViewerCount()
		{
			return this.int_1;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000043E8 File Offset: 0x000025E8
		public void SetEnemyViewerCount(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000043F1 File Offset: 0x000025F1
		public int GetEnemyViewerCount()
		{
			return this.int_2;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000043F9 File Offset: 0x000025F9
		public LogicArrayList<LogicCommand> GetCommands()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00004401 File Offset: 0x00002601
		public void SetCommands(LogicArrayList<LogicCommand> commands)
		{
			this.logicArrayList_0 = commands;
		}

		// Token: 0x0400016F RID: 367
		public const int MESSAGE_TYPE = 24119;

		// Token: 0x04000170 RID: 368
		private int int_0;

		// Token: 0x04000171 RID: 369
		private int int_1;

		// Token: 0x04000172 RID: 370
		private int int_2;

		// Token: 0x04000173 RID: 371
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
