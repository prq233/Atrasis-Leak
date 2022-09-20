using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004A RID: 74
	public class EndClientTurnMessage : PiranhaMessage
	{
		// Token: 0x06000352 RID: 850 RVA: 0x00004066 File Offset: 0x00002266
		public EndClientTurnMessage() : this(0)
		{
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000328E File Offset: 0x0000148E
		public EndClientTurnMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0001BE64 File Offset: 0x0001A064
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			int num = this.m_stream.ReadInt();
			if (num <= 1024)
			{
				if (num > 0)
				{
					this.logicArrayList_0 = new LogicArrayList<LogicCommand>(num);
					do
					{
						LogicCommand logicCommand = LogicCommandManager.DecodeCommand(this.m_stream);
						if (logicCommand == null)
						{
							return;
						}
						this.logicArrayList_0.Add(logicCommand);
					}
					while (--num != 0);
					return;
				}
			}
			else
			{
				Debugger.Error(string.Format("EndClientTurn::decode() command count is too high! ({0})", num));
			}
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0001BEFC File Offset: 0x0001A0FC
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					LogicCommandManager.EncodeCommand(this.m_stream, this.logicArrayList_0[i]);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000406F File Offset: 0x0000226F
		public override short GetMessageType()
		{
			return 14102;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00004076 File Offset: 0x00002276
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00004085 File Offset: 0x00002285
		public int GetSubTick()
		{
			return this.int_0;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000408D File Offset: 0x0000228D
		public void SetSubTick(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00004096 File Offset: 0x00002296
		public int GetChecksum()
		{
			return this.int_1;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000409E File Offset: 0x0000229E
		public void SetChecksum(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000040A7 File Offset: 0x000022A7
		public LogicArrayList<LogicCommand> GetCommands()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000040AF File Offset: 0x000022AF
		public void SetCommands(LogicArrayList<LogicCommand> commands)
		{
			this.logicArrayList_0 = commands;
		}

		// Token: 0x0400014C RID: 332
		public const int MESSAGE_TYPE = 14102;

		// Token: 0x0400014D RID: 333
		private int int_0;

		// Token: 0x0400014E RID: 334
		private int int_1;

		// Token: 0x0400014F RID: 335
		private LogicArrayList<LogicCommand> logicArrayList_0;
	}
}
