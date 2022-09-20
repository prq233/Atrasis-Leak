using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019E RID: 414
	public sealed class LogicCollectResourcesCommand : LogicCommand
	{
		// Token: 0x0600170E RID: 5902 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicCollectResourcesCommand()
		{
		}

		// Token: 0x0600170F RID: 5903 RVA: 0x0000F0DB File Offset: 0x0000D2DB
		public LogicCollectResourcesCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x0000F0EA File Offset: 0x0000D2EA
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x0000F0FF File Offset: 0x0000D2FF
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001712 RID: 5906 RVA: 0x0000F114 File Offset: 0x0000D314
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.COLLECT_RESOURCES;
		}

		// Token: 0x06001713 RID: 5907 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x00058334 File Offset: 0x00056534
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -2;
			}
			if (gameObjectByID.GetVillageType() != level.GetVillageType())
			{
				return -3;
			}
			LogicResourceProductionComponent resourceProductionComponent = gameObjectByID.GetResourceProductionComponent();
			if (resourceProductionComponent != null)
			{
				if (LogicDataTables.GetGlobals().CollectAllResourcesAtOnce())
				{
					int resourceCount = resourceProductionComponent.GetResourceCount();
					int num = resourceProductionComponent.CollectResources(true);
					bool flag = resourceCount > 0 && num == 0;
					LogicArrayList<LogicComponent> components = level.GetComponentManager().GetComponents(resourceProductionComponent.GetComponentType());
					for (int i = 0; i < components.Size(); i++)
					{
						LogicResourceProductionComponent logicResourceProductionComponent = (LogicResourceProductionComponent)components[i];
						if (resourceProductionComponent != logicResourceProductionComponent && resourceProductionComponent.GetResourceData() == logicResourceProductionComponent.GetResourceData())
						{
							int resourceCount2 = logicResourceProductionComponent.GetResourceCount();
							int num2 = logicResourceProductionComponent.CollectResources(!flag);
							if (resourceCount2 > 0 && num2 == 0)
							{
								flag = true;
							}
						}
					}
				}
				else
				{
					resourceProductionComponent.CollectResources(true);
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CC0 RID: 3264
		private int int_1;
	}
}
