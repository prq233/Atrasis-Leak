using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x020000A3 RID: 163
	public class Village2AttackEntryUpdateMessage : PiranhaMessage
	{
		// Token: 0x060006FB RID: 1787 RVA: 0x00006084 File Offset: 0x00004284
		public Village2AttackEntryUpdateMessage() : this(0)
		{
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0000328E File Offset: 0x0000148E
		public Village2AttackEntryUpdateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0000608D File Offset: 0x0000428D
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

		// Token: 0x060006FE RID: 1790 RVA: 0x000060C1 File Offset: 0x000042C1
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.village2AttackEntry_0.GetAttackEntryType());
			this.village2AttackEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000060F0 File Offset: 0x000042F0
		public override short GetMessageType()
		{
			return 24371;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x000060F7 File Offset: 0x000042F7
		public override void Destruct()
		{
			base.Destruct();
			this.village2AttackEntry_0 = null;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00006106 File Offset: 0x00004306
		public Village2AttackEntry RemoveAttackEntry()
		{
			Village2AttackEntry result = this.village2AttackEntry_0;
			this.village2AttackEntry_0 = null;
			return result;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00006115 File Offset: 0x00004315
		public void SetAttackEntry(Village2AttackEntry entry)
		{
			this.village2AttackEntry_0 = entry;
		}

		// Token: 0x0400029C RID: 668
		public const int MESSAGE_TYPE = 24371;

		// Token: 0x0400029D RID: 669
		private Village2AttackEntry village2AttackEntry_0;
	}
}
