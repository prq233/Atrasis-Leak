using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Listener;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000F RID: 15
	public class GClass10 : LogicCommandManagerListener
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00002798 File Offset: 0x00000998
		public GClass10(GClass6 gclass6_1, LogicGameMode logicGameMode_1)
		{
			this.gclass6_0 = gclass6_1;
			this.logicGameMode_0 = logicGameMode_1;
			this.logicArrayList_0 = new LogicArrayList<LogicServerCommand>();
			this.logicArrayList_1 = new LogicArrayList<LogicServerCommand>();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000027C4 File Offset: 0x000009C4
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0.Clear();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000027D7 File Offset: 0x000009D7
		public override void CommandExecuted(LogicCommand command)
		{
			if (command.IsServerCommand())
			{
				this.logicArrayList_0.Remove(this.logicArrayList_0.IndexOf((LogicServerCommand)command));
				this.logicArrayList_1.Add((LogicServerCommand)command);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000280E File Offset: 0x00000A0E
		public void method_0(LogicServerCommand logicServerCommand_0)
		{
			this.logicArrayList_0.Add(logicServerCommand_0);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004948 File Offset: 0x00002B48
		public bool method_1(LogicCommandType logicCommandType_0)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetCommandType() == logicCommandType_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000281C File Offset: 0x00000A1C
		public LogicArrayList<LogicServerCommand> method_2()
		{
			LogicArrayList<LogicServerCommand> logicArrayList = new LogicArrayList<LogicServerCommand>();
			logicArrayList.AddAll(this.logicArrayList_1);
			this.logicArrayList_1.Clear();
			return logicArrayList;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004984 File Offset: 0x00002B84
		public void method_3(int int_0, LogicArrayList<LogicCommand> logicArrayList_2)
		{
			for (int i = 0; i < logicArrayList_2.Size(); i++)
			{
				LogicCommand logicCommand = logicArrayList_2[i];
				if (logicCommand.IsServerCommand())
				{
					if (this.logicGameMode_0.GetState() != 1)
					{
						logicArrayList_2.Remove(i--);
					}
					else
					{
						LogicServerCommand logicServerCommand = (LogicServerCommand)logicCommand;
						LogicServerCommand logicServerCommand2 = null;
						for (int j = 0; j < this.logicArrayList_0.Size(); j++)
						{
							LogicServerCommand logicServerCommand3 = this.logicArrayList_0[j];
							if (logicServerCommand3.GetId() == logicServerCommand.GetId())
							{
								logicServerCommand2 = logicServerCommand3;
							}
						}
						if (logicServerCommand2 != null && logicServerCommand2.GetCommandType() == logicServerCommand.GetCommandType() && (logicServerCommand2.GetExecuteSubTick() == -1 || logicServerCommand2.GetExecuteSubTick() < this.logicGameMode_0.GetLevel().GetLogicTime().GetTick()))
						{
							logicServerCommand2.SetExecuteSubTick(logicServerCommand.GetExecuteSubTick());
							logicArrayList_2[i] = logicServerCommand2;
						}
						else
						{
							logicArrayList_2.Remove(i--);
						}
					}
				}
			}
		}

		// Token: 0x04000024 RID: 36
		private readonly GClass6 gclass6_0;

		// Token: 0x04000025 RID: 37
		private readonly LogicGameMode logicGameMode_0;

		// Token: 0x04000026 RID: 38
		private readonly LogicArrayList<LogicServerCommand> logicArrayList_0;

		// Token: 0x04000027 RID: 39
		private readonly LogicArrayList<LogicServerCommand> logicArrayList_1;
	}
}
