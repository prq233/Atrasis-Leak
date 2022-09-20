using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AA RID: 170
	public class AllianceRequestAllianceUnitsMessage : ServerAccountMessage
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00007646 File Offset: 0x00005846
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000764E File Offset: 0x0000584E
		public LogicLong MemberId { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00007657 File Offset: 0x00005857
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0000765F File Offset: 0x0000585F
		public string Message { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00007668 File Offset: 0x00005868
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00007670 File Offset: 0x00005870
		public int CastleUpgradeLevel { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x00007679 File Offset: 0x00005879
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x00007681 File Offset: 0x00005881
		public int CastleUsedCapacity { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000768A File Offset: 0x0000588A
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x00007692 File Offset: 0x00005892
		public int CastleTotalCapacity { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000769B File Offset: 0x0000589B
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x000076A3 File Offset: 0x000058A3
		public int CastleSpellUsedCapacity { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x000076AC File Offset: 0x000058AC
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x000076B4 File Offset: 0x000058B4
		public int CastleSpellTotalCapacity { get; set; }

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000C608 File Offset: 0x0000A808
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteString(this.Message);
			stream.WriteVInt(this.CastleUpgradeLevel);
			stream.WriteVInt(this.CastleUsedCapacity);
			stream.WriteVInt(this.CastleTotalCapacity);
			stream.WriteVInt(this.CastleSpellUsedCapacity);
			stream.WriteVInt(this.CastleSpellTotalCapacity);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000C66C File Offset: 0x0000A86C
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
			this.CastleUpgradeLevel = stream.ReadVInt();
			this.CastleUsedCapacity = stream.ReadVInt();
			this.CastleTotalCapacity = stream.ReadVInt();
			this.CastleSpellUsedCapacity = stream.ReadVInt();
			this.CastleSpellTotalCapacity = stream.ReadVInt();
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000076BD File Offset: 0x000058BD
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_REQUEST_ALLIANCE_UNITS;
		}

		// Token: 0x040001F6 RID: 502
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001F7 RID: 503
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040001F8 RID: 504
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001F9 RID: 505
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040001FA RID: 506
		[CompilerGenerated]
		private int int_4;

		// Token: 0x040001FB RID: 507
		[CompilerGenerated]
		private int int_5;

		// Token: 0x040001FC RID: 508
		[CompilerGenerated]
		private int int_6;
	}
}
