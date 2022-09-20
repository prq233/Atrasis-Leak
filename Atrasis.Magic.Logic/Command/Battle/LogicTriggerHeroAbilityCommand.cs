using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001ED RID: 493
	public sealed class LogicTriggerHeroAbilityCommand : LogicCommand
	{
		// Token: 0x06001924 RID: 6436 RVA: 0x00010B22 File Offset: 0x0000ED22
		public override void Decode(ByteStream stream)
		{
			this.logicHeroData_0 = (LogicHeroData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.HERO);
			base.Decode(stream);
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x00010B3E File Offset: 0x0000ED3E
		public override void Encode(ChecksumEncoder encoder)
		{
			ByteStreamHelper.WriteDataReference(encoder, this.logicHeroData_0);
			base.Encode(encoder);
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x00010B53 File Offset: 0x0000ED53
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRIGGER_HERO_ABILITY;
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x00010B5A File Offset: 0x0000ED5A
		public override void Destruct()
		{
			base.Destruct();
			this.logicHeroData_0 = null;
		}

		// Token: 0x06001928 RID: 6440 RVA: 0x0005FB2C File Offset: 0x0005DD2C
		public override int Execute(LogicLevel level)
		{
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.CHARACTER);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicCharacter logicCharacter = (LogicCharacter)gameObjects[i];
				if (logicCharacter.GetHitpointComponent().GetTeam() == 0 && logicCharacter.IsHero() && logicCharacter.GetData() == this.logicHeroData_0 && logicCharacter.GetHitpointComponent().GetHitpoints() > 0 && this.logicHeroData_0.HasAbility(logicCharacter.GetUpgradeLevel()) && ((!this.logicHeroData_0.HasOnceAbility() && logicCharacter.GetAbilityCooldown() == 0) || (this.logicHeroData_0.HasOnceAbility() && !logicCharacter.IsAbilityUsed())))
				{
					logicCharacter.StartAbility();
				}
			}
			return 0;
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x0005FBE0 File Offset: 0x0005DDE0
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicTriggerHeroAbility load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			LogicJSONNumber jsonnumber = jsonRoot.GetJSONNumber("d");
			if (jsonnumber != null)
			{
				this.logicHeroData_0 = (LogicHeroData)LogicDataTables.GetDataById(jsonnumber.GetIntValue(), LogicDataType.HERO);
			}
			if (this.logicHeroData_0 == null)
			{
				Debugger.Error("Replay LogicTriggerHeroAbility load failed! Hero is NULL!");
			}
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x0005FC48 File Offset: 0x0005DE48
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			if (this.logicHeroData_0 != null)
			{
				logicJSONObject.Put("d", new LogicJSONNumber(this.logicHeroData_0.GetGlobalID()));
			}
			return logicJSONObject;
		}

		// Token: 0x04000D98 RID: 3480
		private LogicHeroData logicHeroData_0;
	}
}
