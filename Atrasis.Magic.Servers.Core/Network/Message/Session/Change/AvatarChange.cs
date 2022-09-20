using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005B RID: 91
	public abstract class AvatarChange
	{
		// Token: 0x06000267 RID: 615
		public abstract void Decode(ByteStream stream);

		// Token: 0x06000268 RID: 616
		public abstract void Encode(ByteStream stream);

		// Token: 0x06000269 RID: 617
		public abstract void ApplyAvatarChange(LogicClientAvatar avatar);

		// Token: 0x0600026A RID: 618
		public abstract void ApplyAvatarChange(AllianceMemberEntry memberEntry);

		// Token: 0x0600026B RID: 619
		public abstract AvatarChangeType GetAvatarChangeType();

		// Token: 0x0200005C RID: 92
		// (Invoke) Token: 0x0600026E RID: 622
		public delegate void AvatarChangeExecuted(LogicClientAvatar playerAvatar);
	}
}
