using System;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Titan.Debug;

namespace ns0
{
	// Token: 0x02000005 RID: 5
	internal class Class1 : IDebuggerListener
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00004631 File Offset: 0x00002831
		public void HudPrint(string message)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00004631 File Offset: 0x00002831
		public void Print(string message)
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000467C File Offset: 0x0000287C
		public void Warning(string message)
		{
			if (Logging.SEND_LOGS && Logging.SEND_WARNING_LOGS && ServerManager.IsInit() && ServerManager.GetServerCount(0) != 0)
			{
				Class2.smethod_5(new GameLogMessage
				{
					LogType = 0,
					Message = message
				}, ServerManager.GetSocket(0, 0));
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000046BA File Offset: 0x000028BA
		public void Error(string message)
		{
			if (Logging.SEND_LOGS && ServerManager.IsInit() && ServerManager.GetServerCount(0) != 0)
			{
				Class2.smethod_5(new GameLogMessage
				{
					LogType = 1,
					Message = message
				}, ServerManager.GetSocket(0, 0));
			}
		}
	}
}
