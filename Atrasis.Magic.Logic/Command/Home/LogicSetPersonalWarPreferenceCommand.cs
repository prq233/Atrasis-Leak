using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C6 RID: 454
	public class LogicSetPersonalWarPreferenceCommand : LogicCommand
	{
		// Token: 0x06001810 RID: 6160 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSetPersonalWarPreferenceCommand()
		{
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x0000FE72 File Offset: 0x0000E072
		public LogicSetPersonalWarPreferenceCommand(int preference)
		{
			this.int_1 = preference;
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001813 RID: 6163 RVA: 0x0000FE81 File Offset: 0x0000E081
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x0000FE96 File Offset: 0x0000E096
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x0000FEAB File Offset: 0x0000E0AB
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().GetChangeListener().WarPreferenceChanged(this.int_1);
			return 0;
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_PERSONAL_WAR_PREFERENCE;
		}

		// Token: 0x04000D0E RID: 3342
		private int int_1;
	}
}
