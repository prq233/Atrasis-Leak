using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B3 RID: 179
	public class DuelResultMessage : ServerAccountMessage
	{
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x00007993 File Offset: 0x00005B93
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x0000799B File Offset: 0x00005B9B
		public LogicLong AvatarId { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000079A4 File Offset: 0x00005BA4
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x000079AC File Offset: 0x00005BAC
		public LogicLong ReplayId { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x000079B5 File Offset: 0x00005BB5
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x000079BD File Offset: 0x00005BBD
		public string BattleLog { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x000079C6 File Offset: 0x00005BC6
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x000079CE File Offset: 0x00005BCE
		public int DestructionPercentage { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x000079D7 File Offset: 0x00005BD7
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x000079DF File Offset: 0x00005BDF
		public int Stars { get; set; }

		// Token: 0x06000508 RID: 1288 RVA: 0x0000C858 File Offset: 0x0000AA58
		public override void Encode(ByteStream stream)
		{
			if (this.ReplayId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.ReplayId);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteLong(this.AvatarId);
			stream.WriteString(this.BattleLog);
			stream.WriteVInt(this.DestructionPercentage);
			stream.WriteVInt(this.Stars);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000C8BC File Offset: 0x0000AABC
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.ReplayId = stream.ReadLong();
			}
			this.AvatarId = stream.ReadLong();
			this.BattleLog = stream.ReadString(900000);
			this.DestructionPercentage = stream.ReadVInt();
			this.Stars = stream.ReadVInt();
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x000079E8 File Offset: 0x00005BE8
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.DUEL_RESULT;
		}

		// Token: 0x04000211 RID: 529
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000212 RID: 530
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x04000213 RID: 531
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000214 RID: 532
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000215 RID: 533
		[CompilerGenerated]
		private int int_3;
	}
}
