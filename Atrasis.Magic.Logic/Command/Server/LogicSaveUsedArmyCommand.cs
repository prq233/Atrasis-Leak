using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000183 RID: 387
	public class LogicSaveUsedArmyCommand : LogicServerCommand
	{
		// Token: 0x06001655 RID: 5717 RVA: 0x0000E97A File Offset: 0x0000CB7A
		public LogicSaveUsedArmyCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicDataSlot>();
			this.logicArrayList_1 = new LogicArrayList<LogicDataSlot>();
		}

		// Token: 0x06001656 RID: 5718 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x00055DD0 File Offset: 0x00053FD0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				LogicDataSlot logicDataSlot = new LogicDataSlot(null, 0);
				logicDataSlot.Decode(stream);
				if (logicDataSlot.GetData() != null)
				{
					this.logicArrayList_0.Add(logicDataSlot);
				}
				else
				{
					logicDataSlot.Destruct();
					Debugger.Error("LogicSaveUsedArmyCommand::decode - troop data is NULL");
				}
				i++;
			}
			int j = 0;
			int num2 = stream.ReadInt();
			while (j < num2)
			{
				LogicDataSlot logicDataSlot2 = new LogicDataSlot(null, 0);
				logicDataSlot2.Decode(stream);
				if (logicDataSlot2.GetData() != null)
				{
					this.logicArrayList_1.Add(logicDataSlot2);
				}
				else
				{
					logicDataSlot2.Destruct();
					Debugger.Error("LogicSaveUsedArmyCommand::decode - spell data is NULL");
				}
				j++;
			}
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x00055E80 File Offset: 0x00054080
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Encode(encoder);
			}
			encoder.WriteInt(this.logicArrayList_1.Size());
			for (int j = 0; j < this.logicArrayList_1.Size(); j++)
			{
				this.logicArrayList_1[j].Encode(encoder);
			}
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x00055F08 File Offset: 0x00054108
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetLastUsedArmy(this.logicArrayList_0, this.logicArrayList_1);
				return 0;
			}
			return -1;
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x0000281D File Offset: 0x00000A1D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SAVE_USED_ARMY;
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x00055F34 File Offset: 0x00054134
		public void AddUnit(LogicCharacterData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.logicArrayList_0.Size())
			{
				if (this.logicArrayList_0[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.logicArrayList_0[num].SetCount(this.logicArrayList_0[num].GetCount() + count);
						return;
					}
					this.logicArrayList_0.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x0600165C RID: 5724 RVA: 0x00055FB0 File Offset: 0x000541B0
		public void AddSpell(LogicSpellData data, int count)
		{
			int num = -1;
			int i = 0;
			while (i < this.logicArrayList_1.Size())
			{
				if (this.logicArrayList_1[i].GetData() == data)
				{
					num = i;
					IL_32:
					if (num != -1)
					{
						this.logicArrayList_1[num].SetCount(this.logicArrayList_1[num].GetCount() + count);
						return;
					}
					this.logicArrayList_1.Add(new LogicDataSlot(data, count));
					return;
				}
				else
				{
					i++;
				}
			}
			goto IL_32;
		}

		// Token: 0x04000C90 RID: 3216
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_0;

		// Token: 0x04000C91 RID: 3217
		private readonly LogicArrayList<LogicDataSlot> logicArrayList_1;
	}
}
