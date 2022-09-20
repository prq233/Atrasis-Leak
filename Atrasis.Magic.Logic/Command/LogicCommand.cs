using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command
{
	// Token: 0x0200016B RID: 363
	public class LogicCommand
	{
		// Token: 0x060015AC RID: 5548 RVA: 0x0000E16E File Offset: 0x0000C36E
		public LogicCommand()
		{
			this.int_0 = -1;
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsServerCommand()
		{
			return false;
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x00002467 File Offset: 0x00000667
		public virtual LogicCommandType GetCommandType()
		{
			return (LogicCommandType)0;
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x0000E17D File Offset: 0x0000C37D
		public virtual void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_0);
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0000E18B File Offset: 0x0000C38B
		public virtual void Decode(ByteStream stream)
		{
			this.int_0 = stream.ReadInt();
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x00002467 File Offset: 0x00000667
		public virtual int Execute(LogicLevel level)
		{
			return 0;
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0000E199 File Offset: 0x0000C399
		public virtual LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("t", new LogicJSONNumber(this.int_0));
			return logicJSONObject;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x00053AF4 File Offset: 0x00051CF4
		public virtual void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("t");
			if (jsonnumber != null)
			{
				this.int_0 = jsonnumber.GetIntValue();
				return;
			}
			Debugger.Error("Replay - Load command from JSON failed! Execute sub tick was not found!");
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0000E1B6 File Offset: 0x0000C3B6
		public virtual void Destruct()
		{
			this.int_0 = -1;
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0000E1BF File Offset: 0x0000C3BF
		public void SetExecuteSubTick(int tick)
		{
			this.int_0 = tick;
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x0000E1C8 File Offset: 0x0000C3C8
		public int GetExecuteSubTick()
		{
			return this.int_0;
		}

		// Token: 0x04000BC9 RID: 3017
		private int int_0;
	}
}
