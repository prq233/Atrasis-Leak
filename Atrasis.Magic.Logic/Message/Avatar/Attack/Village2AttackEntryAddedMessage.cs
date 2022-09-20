using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x0200009F RID: 159
	public class Village2AttackEntryAddedMessage : PiranhaMessage
	{
		// Token: 0x060006DE RID: 1758 RVA: 0x00005F4A File Offset: 0x0000414A
		public Village2AttackEntryAddedMessage() : this(0)
		{
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0000328E File Offset: 0x0000148E
		public Village2AttackEntryAddedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00005F53 File Offset: 0x00004153
		public override void Decode()
		{
			base.Decode();
			this.village2AttackEntry_0 = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)this.m_stream.ReadInt());
			Village2AttackEntry village2AttackEntry = this.village2AttackEntry_0;
			if (village2AttackEntry == null)
			{
				return;
			}
			village2AttackEntry.Decode(this.m_stream);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00005F87 File Offset: 0x00004187
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.village2AttackEntry_0.GetAttackEntryType());
			this.village2AttackEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00005FB6 File Offset: 0x000041B6
		public override short GetMessageType()
		{
			return 24372;
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00005FBD File Offset: 0x000041BD
		public override void Destruct()
		{
			base.Destruct();
			this.village2AttackEntry_0 = null;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00005FCC File Offset: 0x000041CC
		public Village2AttackEntry RemoveAttackEntry()
		{
			Village2AttackEntry result = this.village2AttackEntry_0;
			this.village2AttackEntry_0 = null;
			return result;
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00005FDB File Offset: 0x000041DB
		public void SetAttackEntry(Village2AttackEntry entry)
		{
			this.village2AttackEntry_0 = entry;
		}

		// Token: 0x04000295 RID: 661
		public const int MESSAGE_TYPE = 24372;

		// Token: 0x04000296 RID: 662
		private Village2AttackEntry village2AttackEntry_0;
	}
}
