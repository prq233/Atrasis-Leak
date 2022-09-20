using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Avatar.Change
{
	// Token: 0x02000201 RID: 513
	public class LogicAvatarChange
	{
		// Token: 0x06001B1C RID: 6940 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Destruct()
		{
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x00011B46 File Offset: 0x0000FD46
		public virtual int GetAvatarChangeType()
		{
			Debugger.Error("LogicAvatarChange::getAvatarChangeType() must be overridden");
			return 0;
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Decode(ByteStream stream)
		{
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Encode(ChecksumEncoder encoder)
		{
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void ApplyAvatarChange(LogicClientAvatar avatar)
		{
		}
	}
}
