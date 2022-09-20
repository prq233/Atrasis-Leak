using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000181 RID: 385
	public class LogicPersonalWarPreferenceCommand : LogicServerCommand
	{
		// Token: 0x06001647 RID: 5703 RVA: 0x0000E25A File Offset: 0x0000C45A
		public LogicPersonalWarPreferenceCommand()
		{
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x0000E8D6 File Offset: 0x0000CAD6
		public LogicPersonalWarPreferenceCommand(int preference)
		{
			this.int_2 = preference;
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x0000E8E5 File Offset: 0x0000CAE5
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x0000E8FA File Offset: 0x0000CAFA
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x0000E90F File Offset: 0x0000CB0F
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().SetWarPreference(this.int_2);
			return 0;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x0000AB25 File Offset: 0x00008D25
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PERSONAL_WAR_PREFERENCE_CHANGED;
		}

		// Token: 0x04000C8E RID: 3214
		private int int_2;
	}
}
