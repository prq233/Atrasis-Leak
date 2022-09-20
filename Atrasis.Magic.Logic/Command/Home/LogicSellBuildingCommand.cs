using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BD RID: 445
	public sealed class LogicSellBuildingCommand : LogicCommand
	{
		// Token: 0x060017D4 RID: 6100 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSellBuildingCommand()
		{
		}

		// Token: 0x060017D5 RID: 6101 RVA: 0x0000FB84 File Offset: 0x0000DD84
		public LogicSellBuildingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060017D6 RID: 6102 RVA: 0x0000FB93 File Offset: 0x0000DD93
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017D8 RID: 6104 RVA: 0x0000FBBD File Offset: 0x0000DDBD
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SELL_BUILDING;
		}

		// Token: 0x060017D9 RID: 6105 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017DA RID: 6106 RVA: 0x0005AEA8 File Offset: 0x000590A8
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.CanSell())
					{
						playerAvatar.CommodityCountChangeHelper(0, logicBuilding.GetSellResource(), logicBuilding.GetSellPrice());
						logicBuilding.OnSell();
						level.GetGameObjectManager().RemoveGameObject(logicBuilding);
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.DECO)
				{
					LogicDeco logicDeco = (LogicDeco)gameObjectByID;
					LogicDecoData decoData = logicDeco.GetDecoData();
					LogicResourceData buildResource = decoData.GetBuildResource();
					int sellPrice = decoData.GetSellPrice();
					if (buildResource.IsPremiumCurrency())
					{
						playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() + sellPrice);
						playerAvatar.SetFreeDiamonds(playerAvatar.GetFreeDiamonds() + sellPrice);
						playerAvatar.GetChangeListener().FreeDiamondsAdded(sellPrice, 6);
					}
					else
					{
						playerAvatar.CommodityCountChangeHelper(0, buildResource, sellPrice);
					}
					level.GetGameObjectManager().RemoveGameObject(logicDeco);
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D00 RID: 3328
		private int int_1;
	}
}
