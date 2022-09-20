using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006C RID: 108
	public class WarPreferenceAvatarChange : AvatarChange
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00006439 File Offset: 0x00004639
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00006441 File Offset: 0x00004641
		public int Preference { get; set; }

		// Token: 0x060002F6 RID: 758 RVA: 0x0000644A File Offset: 0x0000464A
		public override void Decode(ByteStream stream)
		{
			this.Preference = stream.ReadVInt();
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00006458 File Offset: 0x00004658
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Preference);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00006466 File Offset: 0x00004666
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetWarPreference(this.Preference);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00006474 File Offset: 0x00004674
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetWarPreference(this.Preference);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00005859 File Offset: 0x00003A59
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.WAR_PREFERENCE;
		}

		// Token: 0x04000164 RID: 356
		[CompilerGenerated]
		private int int_0;
	}
}
