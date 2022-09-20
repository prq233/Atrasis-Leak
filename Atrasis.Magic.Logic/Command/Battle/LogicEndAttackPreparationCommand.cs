using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001E7 RID: 487
	public sealed class LogicEndAttackPreparationCommand : LogicCommand
	{
		// Token: 0x060018F3 RID: 6387 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x000108DF File Offset: 0x0000EADF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.END_ATTACK_PREPARATION;
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00002B32 File Offset: 0x00000D32
		public override int Execute(LogicLevel level)
		{
			return -1;
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x0005EF94 File Offset: 0x0005D194
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicEndAttackPreparationCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x000108E6 File Offset: 0x0000EAE6
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			return logicJSONObject;
		}
	}
}
