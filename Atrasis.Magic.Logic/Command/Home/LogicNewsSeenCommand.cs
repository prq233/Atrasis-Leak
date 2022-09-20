using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B1 RID: 433
	public sealed class LogicNewsSeenCommand : LogicCommand
	{
		// Token: 0x06001786 RID: 6022 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicNewsSeenCommand()
		{
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x0000F763 File Offset: 0x0000D963
		public LogicNewsSeenCommand(int lastSeenNews)
		{
			this.int_1 = lastSeenNews;
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x0000F772 File Offset: 0x0000D972
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x0000F787 File Offset: 0x0000D987
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600178A RID: 6026 RVA: 0x0000F79C File Offset: 0x0000D99C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.NEWS_SEEN;
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x0000F7A3 File Offset: 0x0000D9A3
		public override int Execute(LogicLevel level)
		{
			level.SetLastSeenNews(this.int_1);
			return 0;
		}

		// Token: 0x04000CE3 RID: 3299
		private int int_1;
	}
}
