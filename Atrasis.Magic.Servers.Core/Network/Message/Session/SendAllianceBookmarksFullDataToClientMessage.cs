using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003A RID: 58
	public class SendAllianceBookmarksFullDataToClientMessage : ServerSessionMessage
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000156 RID: 342 RVA: 0x0000537B File Offset: 0x0000357B
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00005383 File Offset: 0x00003583
		public LogicArrayList<LogicLong> AllianceIds { get; set; }

		// Token: 0x06000158 RID: 344 RVA: 0x0000B584 File Offset: 0x00009784
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.AllianceIds.Size());
			for (int i = 0; i < this.AllianceIds.Size(); i++)
			{
				stream.WriteLong(this.AllianceIds[i]);
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000B5CC File Offset: 0x000097CC
		public override void Decode(ByteStream stream)
		{
			this.AllianceIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.AllianceIds.Add(stream.ReadLong());
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000538C File Offset: 0x0000358C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SEND_ALLIANCE_BOOKMARKS_FULL_DATA_TO_CLIENT;
		}

		// Token: 0x040000E7 RID: 231
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
