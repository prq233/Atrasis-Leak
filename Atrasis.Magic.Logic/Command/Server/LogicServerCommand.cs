using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000184 RID: 388
	public class LogicServerCommand : LogicCommand
	{
		// Token: 0x0600165D RID: 5725 RVA: 0x0000E998 File Offset: 0x0000CB98
		public LogicServerCommand()
		{
			this.int_1 = -1;
		}

		// Token: 0x0600165E RID: 5726 RVA: 0x0000E9A7 File Offset: 0x0000CBA7
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = -1;
		}

		// Token: 0x0600165F RID: 5727 RVA: 0x0000E9B6 File Offset: 0x0000CBB6
		public int GetId()
		{
			return this.int_1;
		}

		// Token: 0x06001660 RID: 5728 RVA: 0x0000E9BE File Offset: 0x0000CBBE
		public void SetId(int id)
		{
			this.int_1 = id;
		}

		// Token: 0x06001661 RID: 5729 RVA: 0x0000E9C7 File Offset: 0x0000CBC7
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x0000E9DC File Offset: 0x0000CBDC
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001663 RID: 5731 RVA: 0x00002B38 File Offset: 0x00000D38
		public sealed override bool IsServerCommand()
		{
			return true;
		}

		// Token: 0x04000C92 RID: 3218
		private int int_1;
	}
}
