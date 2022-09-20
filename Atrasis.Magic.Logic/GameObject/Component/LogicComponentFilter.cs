using System;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200011F RID: 287
	public sealed class LogicComponentFilter : LogicGameObjectFilter
	{
		// Token: 0x06000F44 RID: 3908 RVA: 0x0000A712 File Offset: 0x00008912
		public void SetComponentType(LogicComponentType type)
		{
			this.logicComponentType_0 = type;
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x0000A71B File Offset: 0x0000891B
		public LogicComponentType GetComponentType()
		{
			return this.logicComponentType_0;
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00002B38 File Offset: 0x00000D38
		public override bool IsComponentFilter()
		{
			return true;
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x0000A723 File Offset: 0x00008923
		public override bool TestGameObject(LogicGameObject gameObject)
		{
			return gameObject.GetComponent(this.logicComponentType_0) != null && base.TestGameObject(gameObject);
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x0000A73C File Offset: 0x0000893C
		public bool TestComponent(LogicComponent component)
		{
			return this.TestGameObject(component.GetParent());
		}

		// Token: 0x04000642 RID: 1602
		private LogicComponentType logicComponentType_0;
	}
}
