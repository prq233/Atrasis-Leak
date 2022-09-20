using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000186 RID: 390
	public class LogicV2HomeDataCommand : LogicServerCommand
	{
		// Token: 0x0600166B RID: 5739 RVA: 0x0000EA24 File Offset: 0x0000CC24
		public override void Destruct()
		{
			base.Destruct();
			this.byte_0 = null;
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x0000EA33 File Offset: 0x0000CC33
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.byte_0 = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			}
			base.Decode(stream);
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x0000EA5B File Offset: 0x0000CC5B
		public override void Encode(ChecksumEncoder encoder)
		{
			if (this.byte_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteBytes(this.byte_0, this.byte_0.Length);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			base.Encode(encoder);
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x00056080 File Offset: 0x00054280
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				if (level.GetGameObjectManagerAt(1).GetTownHall() == null)
				{
					LogicJSONObject logicJSONObject = level.GetGameListener().ParseCompressedHomeJSON(this.byte_0, this.byte_0.Length);
					level.SetLoadingVillageType(1);
					this.LoadGameObjectsJsonArray(level, logicJSONObject.GetJSONArray("buildings2"), 1);
					this.LoadGameObjectsJsonArray(level, logicJSONObject.GetJSONArray("obstacles2"), 1);
					this.LoadGameObjectsJsonArray(level, logicJSONObject.GetJSONArray("traps2"), 1);
					this.LoadGameObjectsJsonArray(level, logicJSONObject.GetJSONArray("decos2"), 1);
					level.SetLoadingVillageType(-1);
					if (playerAvatar.GetResourceCount(LogicDataTables.GetGold2Data()) == 0)
					{
						playerAvatar.CommodityCountChangeHelper(0, LogicDataTables.GetGold2Data(), LogicDataTables.GetGlobals().GetStartingGold2());
					}
					if (playerAvatar.GetResourceCount(LogicDataTables.GetElixir2Data()) == 0)
					{
						playerAvatar.CommodityCountChangeHelper(0, LogicDataTables.GetElixir2Data(), LogicDataTables.GetGlobals().GetStartingElixir2());
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x00005232 File Offset: 0x00003432
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.V2_HOME_DATA;
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x0000EA90 File Offset: 0x0000CC90
		public void SetData(byte[] compressedHomeJSON)
		{
			this.byte_0 = compressedHomeJSON;
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x00056168 File Offset: 0x00054368
		public void LoadGameObjectsJsonArray(LogicLevel level, LogicJSONArray array, int villageType)
		{
			if (array != null)
			{
				for (int i = 0; i < array.Size(); i++)
				{
					LogicJSONObject jsonobject = array.GetJSONObject(i);
					if (jsonobject != null)
					{
						LogicGameObjectData logicGameObjectData = (LogicGameObjectData)LogicDataTables.GetDataById(jsonobject.GetJSONNumber("data").GetIntValue());
						if (logicGameObjectData != null)
						{
							LogicGameObject logicGameObject = LogicGameObjectFactory.CreateGameObject(logicGameObjectData, level, villageType);
							logicGameObject.Load(jsonobject);
							level.GetGameObjectManagerAt(1).AddGameObject(logicGameObject, -1);
						}
					}
				}
			}
		}

		// Token: 0x04000C94 RID: 3220
		private byte[] byte_0;
	}
}
