using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005F RID: 95
	public class CommodityCountAvatarChange : AvatarChange
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00005E28 File Offset: 0x00004028
		// (set) Token: 0x06000275 RID: 629 RVA: 0x00005E30 File Offset: 0x00004030
		public int Type { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000276 RID: 630 RVA: 0x00005E39 File Offset: 0x00004039
		// (set) Token: 0x06000277 RID: 631 RVA: 0x00005E41 File Offset: 0x00004041
		public LogicData Data { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00005E4A File Offset: 0x0000404A
		// (set) Token: 0x06000279 RID: 633 RVA: 0x00005E52 File Offset: 0x00004052
		public int Count { get; set; }

		// Token: 0x0600027A RID: 634 RVA: 0x00005E5B File Offset: 0x0000405B
		public override void Decode(ByteStream stream)
		{
			this.Type = stream.ReadVInt();
			this.Data = ByteStreamHelper.ReadDataReference(stream);
			this.Count = stream.ReadVInt();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00005E81 File Offset: 0x00004081
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Type);
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.Count);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00005EA7 File Offset: 0x000040A7
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetCommodityCount(this.Type, this.Data, this.Count);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00005810 File Offset: 0x00003A10
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.COMMODITY_COUNT;
		}

		// Token: 0x0400014B RID: 331
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400014C RID: 332
		[CompilerGenerated]
		private LogicData logicData_0;

		// Token: 0x0400014D RID: 333
		[CompilerGenerated]
		private int int_1;
	}
}
