using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000059 RID: 89
	public class AllianceUnitRemovedAvatarChange : AvatarChange
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00005D4E File Offset: 0x00003F4E
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00005D56 File Offset: 0x00003F56
		public LogicCombatItemData Data { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00005D5F File Offset: 0x00003F5F
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00005D67 File Offset: 0x00003F67
		public int UpgradeLevel { get; set; }

		// Token: 0x06000259 RID: 601 RVA: 0x00005D70 File Offset: 0x00003F70
		public override void Decode(ByteStream stream)
		{
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00005D8F File Offset: 0x00003F8F
		public override void Encode(ByteStream stream)
		{
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00005DA9 File Offset: 0x00003FA9
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.RemoveAllianceUnit(this.Data, this.UpgradeLevel);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00005DBD File Offset: 0x00003FBD
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_UNIT_REMOVED;
		}

		// Token: 0x04000131 RID: 305
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000132 RID: 306
		[CompilerGenerated]
		private int int_0;
	}
}
