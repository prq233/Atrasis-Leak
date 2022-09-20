using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C5 RID: 453
	public sealed class LogicSetPersistentBoolCommand : LogicCommand
	{
		// Token: 0x0600180A RID: 6154 RVA: 0x0000FE0F File Offset: 0x0000E00F
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0000FE30 File Offset: 0x0000E030
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x0000FE51 File Offset: 0x0000E051
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_PERSISTENT_BOOL;
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x0000FE58 File Offset: 0x0000E058
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 0)
			{
				level.SetPersistentBool(0, this.bool_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D0C RID: 3340
		private int int_1;

		// Token: 0x04000D0D RID: 3341
		private bool bool_0;
	}
}
