using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000080 RID: 128
	public class AskForAvatarProfileMessage : PiranhaMessage
	{
		// Token: 0x0600058C RID: 1420 RVA: 0x0000536E File Offset: 0x0000356E
		public AskForAvatarProfileMessage() : this(0)
		{
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForAvatarProfileMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001D56C File Offset: 0x0001B76C
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_1 = this.m_stream.ReadLong();
			}
			this.m_stream.ReadBoolean();
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001D5BC File Offset: 0x0001B7BC
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			if (this.logicLong_1 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_1);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00005377 File Offset: 0x00003577
		public override short GetMessageType()
		{
			return 14325;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000537E File Offset: 0x0000357E
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.logicLong_1 = null;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00005394 File Offset: 0x00003594
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x000053A3 File Offset: 0x000035A3
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000053AC File Offset: 0x000035AC
		public LogicLong RemoveHomeId()
		{
			LogicLong result = this.logicLong_1;
			this.logicLong_1 = null;
			return result;
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x000053BB File Offset: 0x000035BB
		public void SetHomeId(LogicLong id)
		{
			this.logicLong_1 = id;
		}

		// Token: 0x04000211 RID: 529
		public const int MESSAGE_TYPE = 14325;

		// Token: 0x04000212 RID: 530
		private LogicLong logicLong_0;

		// Token: 0x04000213 RID: 531
		private LogicLong logicLong_1;
	}
}
