﻿using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A8 RID: 424
	public sealed class LogicLoadTurretCommand : LogicCommand
	{
		// Token: 0x0600174B RID: 5963 RVA: 0x0000F3A8 File Offset: 0x0000D5A8
		public LogicLoadTurretCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>();
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x000589D0 File Offset: 0x00056BD0
		public override void Decode(ByteStream stream)
		{
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
				i++;
			}
			base.Decode(stream);
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x00058A08 File Offset: 0x00056C08
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x0000F3BB File Offset: 0x0000D5BB
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.LOAD_TURRET;
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x00058A58 File Offset: 0x00056C58
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0.Size() > 0)
			{
				LogicResourceData logicResourceData = null;
				int num = 0;
				int num2 = 0;
				do
				{
					LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[num2]);
					if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
					{
						LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
						if (logicBuilding.GetData().GetVillageType() != level.GetVillageType())
						{
							return -32;
						}
						LogicCombatComponent combatComponent = logicBuilding.GetCombatComponent(false);
						if (combatComponent != null && combatComponent.UseAmmo() && combatComponent.GetAmmoCount() < combatComponent.GetMaxAmmo() && !logicBuilding.IsUpgrading())
						{
							LogicBuildingData buildingData = logicBuilding.GetBuildingData();
							logicResourceData = buildingData.GetAmmoResourceData(0);
							num += buildingData.GetAmmoCost(logicBuilding.GetUpgradeLevel(), combatComponent.GetMaxAmmo() - combatComponent.GetAmmoCount());
						}
					}
				}
				while (++num2 < this.logicArrayList_0.Size());
				if (logicResourceData == null || num <= 0)
				{
					return -1;
				}
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (playerAvatar.HasEnoughResources(logicResourceData, num, true, this, false))
				{
					for (int i = 0; i < this.logicArrayList_0.Size(); i++)
					{
						LogicGameObject gameObjectByID2 = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[i]);
						if (gameObjectByID2 == null || gameObjectByID2.GetGameObjectType() != LogicGameObjectType.BUILDING)
						{
							break;
						}
						LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectByID2;
						LogicCombatComponent combatComponent2 = logicBuilding2.GetCombatComponent(false);
						if (combatComponent2 == null || !combatComponent2.UseAmmo() || combatComponent2.GetAmmoCount() >= combatComponent2.GetMaxAmmo())
						{
							break;
						}
						int upgradeLevel = logicBuilding2.GetUpgradeLevel();
						LogicBuildingData buildingData2 = logicBuilding2.GetBuildingData();
						LogicResourceData ammoResourceData = buildingData2.GetAmmoResourceData(upgradeLevel);
						int ammoCost = buildingData2.GetAmmoCost(upgradeLevel, combatComponent2.GetMaxAmmo() - combatComponent2.GetAmmoCount());
						if (!playerAvatar.HasEnoughResources(ammoResourceData, ammoCost, true, this, false))
						{
							break;
						}
						playerAvatar.CommodityCountChangeHelper(0, ammoResourceData, -ammoCost);
						combatComponent2.LoadAmmo();
					}
					return 0;
				}
				return -2;
			}
			return -1;
		}

		// Token: 0x04000CCB RID: 3275
		private readonly LogicArrayList<int> logicArrayList_0;
	}
}
