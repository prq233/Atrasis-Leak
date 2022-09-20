using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000044 RID: 68
	public class GameHomeState : GameState
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00005706 File Offset: 0x00003906
		// (set) Token: 0x060001BE RID: 446 RVA: 0x0000570E File Offset: 0x0000390E
		public int MaintenanceTime { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00005717 File Offset: 0x00003917
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x0000571F File Offset: 0x0000391F
		public int LayoutId { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00005728 File Offset: 0x00003928
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00005730 File Offset: 0x00003930
		public int MapId { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00005739 File Offset: 0x00003939
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00005741 File Offset: 0x00003941
		public LogicArrayList<LogicServerCommand> ServerCommands { get; set; }

		// Token: 0x060001C5 RID: 453 RVA: 0x0000B9F0 File Offset: 0x00009BF0
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteVInt(this.MaintenanceTime);
			stream.WriteVInt(this.LayoutId);
			stream.WriteVInt(this.MapId);
			stream.WriteVInt(this.ServerCommands.Size());
			for (int i = 0; i < this.ServerCommands.Size(); i++)
			{
				LogicCommandManager.EncodeCommand(stream, this.ServerCommands[i]);
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000BA64 File Offset: 0x00009C64
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.MaintenanceTime = stream.ReadVInt();
			this.LayoutId = stream.ReadVInt();
			this.MapId = stream.ReadVInt();
			this.ServerCommands = new LogicArrayList<LogicServerCommand>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.ServerCommands.Add((LogicServerCommand)LogicCommandManager.DecodeCommand(stream));
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000574A File Offset: 0x0000394A
		public override GameStateType GetGameStateType()
		{
			return GameStateType.HOME;
		}

		// Token: 0x04000104 RID: 260
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000105 RID: 261
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000106 RID: 262
		[CompilerGenerated]
		private int int_3;

		// Token: 0x04000107 RID: 263
		[CompilerGenerated]
		private LogicArrayList<LogicServerCommand> logicArrayList_0;
	}
}
