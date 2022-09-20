using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B7 RID: 439
	public sealed class LogicRepairTrapsCommand : LogicCommand
	{
		// Token: 0x060017AB RID: 6059 RVA: 0x0000F9CB File Offset: 0x0000DBCB
		public LogicRepairTrapsCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>(50);
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x0005A49C File Offset: 0x0005869C
		public override void Decode(ByteStream stream)
		{
			for (int i = stream.ReadInt(); i > 0; i--)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
			}
			base.Decode(stream);
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x0005A4D4 File Offset: 0x000586D4
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REPAIR_TRAPS;
		}

		// Token: 0x060017AF RID: 6063 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x0005A524 File Offset: 0x00058724
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			LogicGameObjectManager gameObjectManager = level.GetGameObjectManager();
			LogicResourceData logicResourceData = null;
			int num = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject gameObjectByID = gameObjectManager.GetGameObjectByID(this.logicArrayList_0[i]);
				if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.IsDisarmed() && !logicTrap.IsConstructing())
					{
						LogicTrapData trapData = logicTrap.GetTrapData();
						logicResourceData = trapData.GetBuildResource();
						num += trapData.GetRearmCost(logicTrap.GetUpgradeLevel());
					}
				}
			}
			if (logicResourceData == null || num == 0)
			{
				return -1;
			}
			if (playerAvatar.HasEnoughResources(logicResourceData, num, true, this, false))
			{
				playerAvatar.CommodityCountChangeHelper(0, logicResourceData, -num);
				for (int j = 0; j < this.logicArrayList_0.Size(); j++)
				{
					LogicGameObject gameObjectByID2 = gameObjectManager.GetGameObjectByID(this.logicArrayList_0[j]);
					if (gameObjectByID2 != null && gameObjectByID2.GetGameObjectType() == LogicGameObjectType.TRAP)
					{
						LogicTrap logicTrap2 = (LogicTrap)gameObjectByID2;
						if (logicTrap2.IsDisarmed() && !logicTrap2.IsConstructing())
						{
							logicTrap2.RepairTrap();
						}
					}
				}
				return 0;
			}
			return -2;
		}

		// Token: 0x04000CF2 RID: 3314
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
