using System;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200007E RID: 126
	public class AllianceBookmarksFullDataMessage : PiranhaMessage
	{
		// Token: 0x0600057C RID: 1404 RVA: 0x0000532E File Offset: 0x0000352E
		public AllianceBookmarksFullDataMessage() : this(0)
		{
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceBookmarksFullDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001D4A4 File Offset: 0x0001B6A4
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num >= 0)
			{
				this.logicArrayList_0 = new LogicArrayList<AllianceHeaderEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AllianceHeaderEntry allianceHeaderEntry = new AllianceHeaderEntry();
					allianceHeaderEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(allianceHeaderEntry);
				}
			}
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001D500 File Offset: 0x0001B700
		public override void Encode()
		{
			base.Encode();
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00005337 File Offset: 0x00003537
		public override short GetMessageType()
		{
			return 24341;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0000533E File Offset: 0x0000353E
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0000534D File Offset: 0x0000354D
		public LogicArrayList<AllianceHeaderEntry> GetAllianceList()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00005355 File Offset: 0x00003555
		public void SetAlliances(LogicArrayList<AllianceHeaderEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0400020E RID: 526
		public const int MESSAGE_TYPE = 24341;

		// Token: 0x0400020F RID: 527
		private LogicArrayList<AllianceHeaderEntry> logicArrayList_0;
	}
}
