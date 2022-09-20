using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000093 RID: 147
	public class LoadReplayStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x00006F82 File Offset: 0x00005182
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x00006F8A File Offset: 0x0000518A
		public byte[] StreamData { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x00006F93 File Offset: 0x00005193
		// (set) Token: 0x06000401 RID: 1025 RVA: 0x00006F9B File Offset: 0x0000519B
		public int MajorVersion { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00006FA4 File Offset: 0x000051A4
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x00006FAC File Offset: 0x000051AC
		public int BuildVersion { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x00006FB5 File Offset: 0x000051B5
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x00006FBD File Offset: 0x000051BD
		public int ContentVersion { get; set; }

		// Token: 0x06000406 RID: 1030 RVA: 0x0000C47C File Offset: 0x0000A67C
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteBytes(this.StreamData, this.StreamData.Length);
				stream.WriteVInt(this.MajorVersion);
				stream.WriteVInt(this.BuildVersion);
				stream.WriteVInt(this.ContentVersion);
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000C4CC File Offset: 0x0000A6CC
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.StreamData = stream.ReadBytes(stream.ReadBytesLength(), 900000);
				this.MajorVersion = stream.ReadVInt();
				this.BuildVersion = stream.ReadVInt();
				this.ContentVersion = stream.ReadVInt();
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00006FC6 File Offset: 0x000051C6
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_REPLAY_STREAM_RESPONSE;
		}

		// Token: 0x040001D0 RID: 464
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x040001D1 RID: 465
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001D2 RID: 466
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040001D3 RID: 467
		[CompilerGenerated]
		private int int_4;
	}
}
