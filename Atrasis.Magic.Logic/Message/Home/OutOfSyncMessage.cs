using System;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000058 RID: 88
	public class OutOfSyncMessage : PiranhaMessage
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x00004575 File Offset: 0x00002775
		public OutOfSyncMessage() : this(0)
		{
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000328E File Offset: 0x0000148E
		public OutOfSyncMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0001C734 File Offset: 0x0001A934
		public override void Decode()
		{
			base.Decode();
			this.int_2 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				string text = this.m_stream.ReadString(900000);
				if (text != null)
				{
					this.logicJSONObject_0 = LogicJSONParser.ParseObject(text);
				}
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0001C7A8 File Offset: 0x0001A9A8
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_0);
			if (this.logicJSONObject_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteString(LogicJSONParser.CreateJSONString(this.logicJSONObject_0, 1024));
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000457E File Offset: 0x0000277E
		public override short GetMessageType()
		{
			return 24104;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00004585 File Offset: 0x00002785
		public override void Destruct()
		{
			base.Destruct();
			this.logicJSONObject_0 = null;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00004594 File Offset: 0x00002794
		public int GetServerChecksum()
		{
			return this.int_2;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000459C File Offset: 0x0000279C
		public void SetServerChecksum(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000045A5 File Offset: 0x000027A5
		public int GetClientChecksum()
		{
			return this.int_1;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000045AD File Offset: 0x000027AD
		public void SetClientChecksum(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000045B6 File Offset: 0x000027B6
		public int GetSubTick()
		{
			return this.int_0;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000045BE File Offset: 0x000027BE
		public void SetSubTick(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000045C7 File Offset: 0x000027C7
		public LogicJSONObject RemoveDebugJSON()
		{
			LogicJSONObject result = this.logicJSONObject_0;
			this.logicJSONObject_0 = null;
			return result;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000045D6 File Offset: 0x000027D6
		public void SetDebugJSON(LogicJSONObject json)
		{
			this.logicJSONObject_0 = json;
		}

		// Token: 0x04000187 RID: 391
		public const int MESSAGE_TYPE = 24104;

		// Token: 0x04000188 RID: 392
		private int int_0;

		// Token: 0x04000189 RID: 393
		private int int_1;

		// Token: 0x0400018A RID: 394
		private int int_2;

		// Token: 0x0400018B RID: 395
		private LogicJSONObject logicJSONObject_0;
	}
}
