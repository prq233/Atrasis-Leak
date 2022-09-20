using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000038 RID: 56
	public class GameStartFakeAttackMessage : ServerSessionMessage
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000148 RID: 328 RVA: 0x000052C5 File Offset: 0x000034C5
		// (set) Token: 0x06000149 RID: 329 RVA: 0x000052CD File Offset: 0x000034CD
		public LogicLong AccountId { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600014A RID: 330 RVA: 0x000052D6 File Offset: 0x000034D6
		// (set) Token: 0x0600014B RID: 331 RVA: 0x000052DE File Offset: 0x000034DE
		public LogicData ArgData { get; set; }

		// Token: 0x0600014C RID: 332 RVA: 0x000052E7 File Offset: 0x000034E7
		public override void Encode(ByteStream stream)
		{
			if (this.AccountId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.AccountId);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			ByteStreamHelper.WriteDataReference(stream, this.ArgData);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005319 File Offset: 0x00003519
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.AccountId = stream.ReadLong();
			}
			this.ArgData = ByteStreamHelper.ReadDataReference(stream);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000533B File Offset: 0x0000353B
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_START_FAKE_ATTACK;
		}

		// Token: 0x040000E4 RID: 228
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000E5 RID: 229
		[CompilerGenerated]
		private LogicData logicData_0;
	}
}
