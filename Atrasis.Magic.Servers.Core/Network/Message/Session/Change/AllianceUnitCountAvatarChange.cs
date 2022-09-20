using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000058 RID: 88
	public class AllianceUnitCountAvatarChange : AvatarChange
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00005CB0 File Offset: 0x00003EB0
		// (set) Token: 0x0600024A RID: 586 RVA: 0x00005CB8 File Offset: 0x00003EB8
		public LogicCombatItemData Data { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00005CC1 File Offset: 0x00003EC1
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00005CC9 File Offset: 0x00003EC9
		public int UpgradeLevel { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00005CD2 File Offset: 0x00003ED2
		// (set) Token: 0x0600024E RID: 590 RVA: 0x00005CDA File Offset: 0x00003EDA
		public int Count { get; set; }

		// Token: 0x0600024F RID: 591 RVA: 0x00005CE3 File Offset: 0x00003EE3
		public override void Decode(ByteStream stream)
		{
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
			this.Count = stream.ReadVInt();
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00005D0E File Offset: 0x00003F0E
		public override void Encode(ByteStream stream)
		{
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
			stream.WriteVInt(this.Count);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00005D34 File Offset: 0x00003F34
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceUnitCount(this.Data, this.UpgradeLevel, this.Count);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000058F1 File Offset: 0x00003AF1
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_UNIT_COUNT;
		}

		// Token: 0x0400012E RID: 302
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x0400012F RID: 303
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000130 RID: 304
		[CompilerGenerated]
		private int int_1;
	}
}
