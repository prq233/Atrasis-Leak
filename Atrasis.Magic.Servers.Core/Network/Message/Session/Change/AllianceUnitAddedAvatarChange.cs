using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000057 RID: 87
	public class AllianceUnitAddedAvatarChange : AvatarChange
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00005C3D File Offset: 0x00003E3D
		// (set) Token: 0x06000240 RID: 576 RVA: 0x00005C45 File Offset: 0x00003E45
		public LogicCombatItemData Data { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00005C4E File Offset: 0x00003E4E
		// (set) Token: 0x06000242 RID: 578 RVA: 0x00005C56 File Offset: 0x00003E56
		public int UpgradeLevel { get; set; }

		// Token: 0x06000243 RID: 579 RVA: 0x00005C5F File Offset: 0x00003E5F
		public override void Decode(ByteStream stream)
		{
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00005C7E File Offset: 0x00003E7E
		public override void Encode(ByteStream stream)
		{
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00005C98 File Offset: 0x00003E98
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.AddAllianceUnit(this.Data, this.UpgradeLevel);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00005CAC File Offset: 0x00003EAC
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_UNIT_ADDED;
		}

		// Token: 0x0400012C RID: 300
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x0400012D RID: 301
		[CompilerGenerated]
		private int int_0;
	}
}
