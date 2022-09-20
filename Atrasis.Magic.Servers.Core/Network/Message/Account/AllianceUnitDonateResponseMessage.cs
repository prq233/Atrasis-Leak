using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AD RID: 173
	public class AllianceUnitDonateResponseMessage : ServerAccountMessage
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x000077AC File Offset: 0x000059AC
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x000077B4 File Offset: 0x000059B4
		public LogicLong MemberId { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x000077BD File Offset: 0x000059BD
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x000077C5 File Offset: 0x000059C5
		public LogicLong StreamId { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x000077CE File Offset: 0x000059CE
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x000077D6 File Offset: 0x000059D6
		public LogicCombatItemData Data { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x000077DF File Offset: 0x000059DF
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x000077E7 File Offset: 0x000059E7
		public int UpgradeLevel { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x000077F0 File Offset: 0x000059F0
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x000077F8 File Offset: 0x000059F8
		public bool QuickDonate { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00007801 File Offset: 0x00005A01
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00007809 File Offset: 0x00005A09
		public bool Success { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00007812 File Offset: 0x00005A12
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x0000781A File Offset: 0x00005A1A
		public string MemberName { get; set; }

		// Token: 0x060004D6 RID: 1238 RVA: 0x0000C6D4 File Offset: 0x0000A8D4
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.StreamId);
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.UpgradeLevel);
			stream.WriteBoolean(this.QuickDonate);
			stream.WriteBoolean(this.Success);
			stream.WriteString(this.MemberName);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0000C738 File Offset: 0x0000A938
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.StreamId = stream.ReadLong();
			this.Data = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream);
			this.UpgradeLevel = stream.ReadVInt();
			this.QuickDonate = stream.ReadBoolean();
			this.Success = stream.ReadBoolean();
			this.MemberName = stream.ReadString(900000);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00007823 File Offset: 0x00005A23
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_UNIT_DONATE_RESPONSE;
		}

		// Token: 0x04000202 RID: 514
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000203 RID: 515
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x04000204 RID: 516
		[CompilerGenerated]
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000205 RID: 517
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000206 RID: 518
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000207 RID: 519
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000208 RID: 520
		[CompilerGenerated]
		private string string_0;
	}
}
