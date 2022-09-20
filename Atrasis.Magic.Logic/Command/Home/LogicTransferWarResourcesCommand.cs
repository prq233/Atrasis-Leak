using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DB RID: 475
	public sealed class LogicTransferWarResourcesCommand : LogicCommand
	{
		// Token: 0x0600189E RID: 6302 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x0000EBF4 File Offset: 0x0000CDF4
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x000105CD File Offset: 0x0000E7CD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRANSFER_WAR_RESOURCES;
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x0005C664 File Offset: 0x0005A864
		public override int Execute(LogicLevel level)
		{
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManagerAt(0).GetGameObjects(LogicGameObjectType.BUILDING);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				if (logicBuilding.GetData() == LogicDataTables.GetAllianceCastleData())
				{
					LogicWarResourceStorageComponent warResourceStorageComponent = logicBuilding.GetWarResourceStorageComponent();
					if (warResourceStorageComponent.IsNotEmpty())
					{
						warResourceStorageComponent.CollectResources();
					}
				}
			}
			return 0;
		}
	}
}
