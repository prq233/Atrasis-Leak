using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C4 RID: 452
	public sealed class LogicSetLayoutStateCommand : LogicCommand
	{
		// Token: 0x06001804 RID: 6148 RVA: 0x0000FDAE File Offset: 0x0000DFAE
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x0000FDDB File Offset: 0x0000DFDB
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x0000FE08 File Offset: 0x0000E008
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_LAYOUT_STATE;
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x0005B2AC File Offset: 0x000594AC
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 6)
			{
				return -10;
			}
			if (this.int_1 != 7)
			{
				if (this.int_2 == 0)
				{
					LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
					LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
					logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
					logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
					logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
					level.GetGameObjectManager().GetGameObjects(logicArrayList, logicGameObjectFilter);
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						logicArrayList[i].SetPositionLayoutXY(-1, -1, this.int_1, true);
					}
					logicGameObjectFilter.Destruct();
				}
				level.SetLayoutState(this.int_1, level.GetVillageType(), this.int_2);
				return 0;
			}
			return -11;
		}

		// Token: 0x04000D09 RID: 3337
		private int int_1;

		// Token: 0x04000D0A RID: 3338
		private int int_2;

		// Token: 0x04000D0B RID: 3339
		private bool bool_0;
	}
}
