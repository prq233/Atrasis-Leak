using System;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000112 RID: 274
	public class LogicGameObjectFilter
	{
		// Token: 0x06000DB9 RID: 3513 RVA: 0x00009A47 File Offset: 0x00007C47
		public LogicGameObjectFilter()
		{
			this.int_0 = -1;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00009A56 File Offset: 0x00007C56
		public virtual void Destruct()
		{
			this.bool_1 = null;
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00009A79 File Offset: 0x00007C79
		public bool ContainsGameObjectType(int type)
		{
			return this.bool_1 == null || this.bool_1[type];
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00009A8D File Offset: 0x00007C8D
		public void AddGameObjectType(LogicGameObjectType type)
		{
			if (this.bool_1 == null)
			{
				this.bool_1 = new bool[9];
			}
			this.bool_1[(int)type] = true;
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00030AEC File Offset: 0x0002ECEC
		public virtual bool TestGameObject(LogicGameObject gameObject)
		{
			if (this.bool_1 != null && !this.bool_1[(int)gameObject.GetGameObjectType()])
			{
				return false;
			}
			if (this.logicArrayList_0 != null && this.logicArrayList_0.IndexOf(gameObject) != -1)
			{
				return false;
			}
			if (this.int_0 != -1)
			{
				LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					bool flag;
					return hitpointComponent.GetHitpoints() > 0 && ((flag = hitpointComponent.IsEnemyForTeam(this.int_0)) || !this.bool_0) && (this.bool_0 || !flag);
				}
			}
			return true;
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsComponentFilter()
		{
			return false;
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00030B74 File Offset: 0x0002ED74
		public void PassEnemyOnly(LogicGameObject gameObject)
		{
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			if (hitpointComponent != null)
			{
				this.int_0 = hitpointComponent.GetTeam();
				this.bool_0 = true;
				return;
			}
			this.int_0 = -1;
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00030BA8 File Offset: 0x0002EDA8
		public void PassFriendlyOnly(LogicGameObject gameObject)
		{
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			if (hitpointComponent != null)
			{
				this.int_0 = hitpointComponent.GetTeam();
				this.bool_0 = false;
				return;
			}
			this.int_0 = -1;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x00009AAD File Offset: 0x00007CAD
		public void RemoveAllIgnoreObjects()
		{
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x00009AC9 File Offset: 0x00007CC9
		public void AddIgnoreObject(LogicGameObject gameObject)
		{
			if (this.logicArrayList_0 == null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicGameObject>();
			}
			this.logicArrayList_0.Add(gameObject);
		}

		// Token: 0x04000554 RID: 1364
		private int int_0;

		// Token: 0x04000555 RID: 1365
		private bool bool_0;

		// Token: 0x04000556 RID: 1366
		private bool[] bool_1;

		// Token: 0x04000557 RID: 1367
		private LogicArrayList<LogicGameObject> logicArrayList_0;
	}
}
