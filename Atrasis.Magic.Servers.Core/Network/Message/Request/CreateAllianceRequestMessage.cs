using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000074 RID: 116
	public class CreateAllianceRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000338 RID: 824 RVA: 0x000066F4 File Offset: 0x000048F4
		// (set) Token: 0x06000339 RID: 825 RVA: 0x000066FC File Offset: 0x000048FC
		public string AllianceName { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00006705 File Offset: 0x00004905
		// (set) Token: 0x0600033B RID: 827 RVA: 0x0000670D File Offset: 0x0000490D
		public string AllianceDescription { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00006716 File Offset: 0x00004916
		// (set) Token: 0x0600033D RID: 829 RVA: 0x0000671E File Offset: 0x0000491E
		public AllianceType AllianceType { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00006727 File Offset: 0x00004927
		// (set) Token: 0x0600033F RID: 831 RVA: 0x0000672F File Offset: 0x0000492F
		public int AllianceBadgeId { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00006738 File Offset: 0x00004938
		// (set) Token: 0x06000341 RID: 833 RVA: 0x00006740 File Offset: 0x00004940
		public int RequiredScore { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00006749 File Offset: 0x00004949
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00006751 File Offset: 0x00004951
		public int RequiredDuelScore { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000675A File Offset: 0x0000495A
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00006762 File Offset: 0x00004962
		public int WarFrequency { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0000676B File Offset: 0x0000496B
		// (set) Token: 0x06000347 RID: 839 RVA: 0x00006773 File Offset: 0x00004973
		public bool PublicWarLog { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0000677C File Offset: 0x0000497C
		// (set) Token: 0x06000349 RID: 841 RVA: 0x00006784 File Offset: 0x00004984
		public bool ArrangedWarEnabled { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0000678D File Offset: 0x0000498D
		// (set) Token: 0x0600034B RID: 843 RVA: 0x00006795 File Offset: 0x00004995
		public LogicData OriginData { get; set; }

		// Token: 0x0600034C RID: 844 RVA: 0x0000C128 File Offset: 0x0000A328
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.AllianceName);
			stream.WriteString(this.AllianceDescription);
			stream.WriteVInt((int)this.AllianceType);
			stream.WriteVInt(this.AllianceBadgeId);
			stream.WriteVInt(this.RequiredScore);
			stream.WriteVInt(this.RequiredDuelScore);
			stream.WriteVInt(this.WarFrequency);
			stream.WriteBoolean(this.PublicWarLog);
			stream.WriteBoolean(this.ArrangedWarEnabled);
			ByteStreamHelper.WriteDataReference(stream, this.OriginData);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000C1B0 File Offset: 0x0000A3B0
		public override void Decode(ByteStream stream)
		{
			this.AllianceName = stream.ReadString(900000);
			this.AllianceDescription = stream.ReadString(900000);
			this.AllianceType = (AllianceType)stream.ReadVInt();
			this.AllianceBadgeId = stream.ReadVInt();
			this.RequiredScore = stream.ReadVInt();
			this.RequiredDuelScore = stream.ReadVInt();
			this.WarFrequency = stream.ReadVInt();
			this.PublicWarLog = stream.ReadBoolean();
			this.ArrangedWarEnabled = stream.ReadBoolean();
			this.OriginData = ByteStreamHelper.ReadDataReference(stream);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000679E File Offset: 0x0000499E
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_ALLIANCE_REQUEST;
		}

		// Token: 0x0400017D RID: 381
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400017E RID: 382
		[CompilerGenerated]
		private string string_1;

		// Token: 0x0400017F RID: 383
		[CompilerGenerated]
		private AllianceType allianceType_0;

		// Token: 0x04000180 RID: 384
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000181 RID: 385
		[CompilerGenerated]
		private int int_3;

		// Token: 0x04000182 RID: 386
		[CompilerGenerated]
		private int int_4;

		// Token: 0x04000183 RID: 387
		[CompilerGenerated]
		private int int_5;

		// Token: 0x04000184 RID: 388
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000185 RID: 389
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000186 RID: 390
		[CompilerGenerated]
		private LogicData logicData_0;
	}
}
