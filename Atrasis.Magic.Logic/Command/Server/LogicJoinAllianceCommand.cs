using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x0200017E RID: 382
	public class LogicJoinAllianceCommand : LogicServerCommand
	{
		// Token: 0x06001632 RID: 5682 RVA: 0x0000E809 File Offset: 0x0000CA09
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x00055B88 File Offset: 0x00053D88
		public override void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x00055BE0 File Offset: 0x00053DE0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x00055C30 File Offset: 0x00053E30
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (this.bool_0)
				{
					LogicGlobals globals = LogicDataTables.GetGlobals();
					LogicResourceData allianceCreateResourceData = globals.GetAllianceCreateResourceData();
					int num = LogicMath.Min(globals.GetAllianceCreateCost(), playerAvatar.GetResourceCount(allianceCreateResourceData));
					playerAvatar.CommodityCountChangeHelper(0, allianceCreateResourceData, -num);
				}
				playerAvatar.SetAllianceId(this.logicLong_0.Clone());
				playerAvatar.SetAllianceName(this.string_0);
				playerAvatar.SetAllianceBadgeId(this.int_2);
				playerAvatar.SetAllianceLevel(this.int_3);
				playerAvatar.SetAllianceRole(this.bool_0 ? LogicAvatarAllianceRole.LEADER : LogicAvatarAllianceRole.MEMBER);
				playerAvatar.GetChangeListener().AllianceJoined(playerAvatar.GetAllianceId(), this.string_0, this.int_2, this.int_3, playerAvatar.GetAllianceRole());
				LogicGameListener gameListener = level.GetGameListener();
				if (gameListener != null)
				{
					if (this.bool_0)
					{
						gameListener.AllianceCreated();
					}
					else
					{
						gameListener.AllianceJoined();
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x00002B38 File Offset: 0x00000D38
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.JOIN_ALLIANCE;
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0000E81F File Offset: 0x0000CA1F
		public void SetAllianceData(LogicLong allianceId, string allianceName, int allianceBadgeId, int allianceExpLevel, bool isNewAlliance)
		{
			this.logicLong_0 = allianceId;
			this.string_0 = allianceName;
			this.int_2 = allianceBadgeId;
			this.int_3 = allianceExpLevel;
			this.bool_0 = isNewAlliance;
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0000E846 File Offset: 0x0000CA46
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x04000C86 RID: 3206
		private LogicLong logicLong_0;

		// Token: 0x04000C87 RID: 3207
		private string string_0;

		// Token: 0x04000C88 RID: 3208
		private int int_2;

		// Token: 0x04000C89 RID: 3209
		private int int_3;

		// Token: 0x04000C8A RID: 3210
		private bool bool_0;
	}
}
