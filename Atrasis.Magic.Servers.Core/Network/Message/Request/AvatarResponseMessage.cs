using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000071 RID: 113
	public class AvatarResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600031E RID: 798 RVA: 0x000065ED File Offset: 0x000047ED
		// (set) Token: 0x0600031F RID: 799 RVA: 0x000065F5 File Offset: 0x000047F5
		public LogicClientAvatar LogicClientAvatar { get; set; }

		// Token: 0x06000320 RID: 800 RVA: 0x000065FE File Offset: 0x000047FE
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				this.LogicClientAvatar.Encode(stream);
			}
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00006614 File Offset: 0x00004814
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.LogicClientAvatar = new LogicClientAvatar();
				this.LogicClientAvatar.Decode(stream);
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00006635 File Offset: 0x00004835
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.AVATAR_RESPONSE;
		}

		// Token: 0x04000176 RID: 374
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;
	}
}
