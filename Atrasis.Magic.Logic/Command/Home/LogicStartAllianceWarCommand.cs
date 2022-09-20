using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D2 RID: 466
	public sealed class LogicStartAllianceWarCommand : LogicCommand
	{
		// Token: 0x06001861 RID: 6241 RVA: 0x0001019A File Offset: 0x0000E39A
		public LogicStartAllianceWarCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicLong>();
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0005B984 File Offset: 0x00059B84
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			int num = stream.ReadInt();
			if (num > 0)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicLong>();
				this.logicArrayList_0.EnsureCapacity(num);
				if (num > 50)
				{
					Debugger.Error(string.Format("Number of excluded players ({0}) is too high.", num));
				}
				for (int i = 0; i < num; i++)
				{
					this.logicArrayList_0.Add(stream.ReadLong());
				}
			}
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x0005B9F4 File Offset: 0x00059BF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			if (this.logicArrayList_0 != null)
			{
				encoder.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					encoder.WriteLong(this.logicArrayList_0[i]);
				}
			}
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x000101AD File Offset: 0x0000E3AD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.START_ALLIANCE_WAR;
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x000101B4 File Offset: 0x0000E3B4
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x0005BA4C File Offset: 0x00059C4C
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0 != null && this.logicArrayList_0.Size() > LogicDataTables.GetGlobals().GetWarMaxExcludeMembers())
			{
				return -1;
			}
			LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
			if (homeOwnerAvatar.IsInAlliance())
			{
				if (homeOwnerAvatar.GetAllianceRole() != LogicAvatarAllianceRole.LEADER)
				{
					if (homeOwnerAvatar.GetAllianceRole() != LogicAvatarAllianceRole.CO_LEADER)
					{
						return -3;
					}
				}
				homeOwnerAvatar.GetChangeListener().StartWar(this.logicArrayList_0);
				return 0;
			}
			return -2;
		}

		// Token: 0x04000D1D RID: 3357
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
