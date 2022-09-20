using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000170 RID: 368
	public class LogicAllianceUnitReceivedCommand : LogicServerCommand
	{
		// Token: 0x060015D2 RID: 5586 RVA: 0x0000E338 File Offset: 0x0000C538
		public void SetData(string senderName, LogicCombatItemData data, int upgLevel)
		{
			this.string_0 = senderName;
			this.logicCombatItemData_0 = data;
			this.int_2 = upgLevel;
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x0000E34F File Offset: 0x0000C54F
		public override void Destruct()
		{
			base.Destruct();
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x00054718 File Offset: 0x00052918
		public override void Decode(ByteStream stream)
		{
			this.string_0 = stream.ReadString(900000);
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (stream.ReadInt() != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015D5 RID: 5589 RVA: 0x0000E35E File Offset: 0x0000C55E
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteString(this.string_0);
			encoder.WriteInt((int)this.logicCombatItemData_0.GetCombatItemType());
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015D6 RID: 5590 RVA: 0x00054768 File Offset: 0x00052968
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null && this.logicCombatItemData_0 != null)
			{
				playerAvatar.AddAllianceUnit(this.logicCombatItemData_0, this.int_2);
				playerAvatar.GetChangeListener().AllianceUnitAdded(this.logicCombatItemData_0, this.int_2);
				level.GetGameListener().UnitReceivedFromAlliance(this.string_0, this.logicCombatItemData_0, this.int_2);
				if (level.GetState() == 1 || level.GetState() == 3)
				{
					level.GetComponentManagerAt(0).AddAvatarAllianceUnitsToCastle();
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x00002BCE File Offset: 0x00000DCE
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ALLIANCE_UNIT_RECEIVED;
		}

		// Token: 0x04000C59 RID: 3161
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000C5A RID: 3162
		private int int_2;

		// Token: 0x04000C5B RID: 3163
		private string string_0;
	}
}
