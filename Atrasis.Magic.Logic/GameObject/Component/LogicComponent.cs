using System;
using Atrasis.Magic.Logic.GameObject.Listener;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200011D RID: 285
	public class LogicComponent
	{
		// Token: 0x06000F33 RID: 3891 RVA: 0x0000A6A5 File Offset: 0x000088A5
		public LogicComponent(LogicGameObject gameObject)
		{
			this.m_parent = gameObject;
			this.m_enabled = true;
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x0000A6BB File Offset: 0x000088BB
		public virtual void Destruct()
		{
			this.m_parent.GetLevel().GetComponentManagerAt(this.m_parent.GetVillageType()).RemoveComponent(this);
			this.m_enabled = false;
			this.m_parent = null;
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0000A6EC File Offset: 0x000088EC
		public LogicGameObject GetParent()
		{
			return this.m_parent;
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0000A6F4 File Offset: 0x000088F4
		public LogicGameObjectListener GetParentListener()
		{
			return this.m_parent.GetListener();
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x0000A701 File Offset: 0x00008901
		public bool IsEnabled()
		{
			return this.m_enabled;
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0000A709 File Offset: 0x00008909
		public void SetEnabled(bool value)
		{
			this.m_enabled = value;
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x00002467 File Offset: 0x00000667
		public virtual LogicComponentType GetComponentType()
		{
			return LogicComponentType.UNIT_STORAGE;
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void FastForwardTime(int time)
		{
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void GetChecksum(ChecksumHelper checksum)
		{
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void SubTick()
		{
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Tick()
		{
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Load(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06000F40 RID: 3904 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void Save(LogicJSONObject jsonObject, int villageType)
		{
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void LoadingFinished()
		{
		}

		// Token: 0x0400062D RID: 1581
		public const int COMPONENT_TYPE_COUNT = 17;

		// Token: 0x0400062E RID: 1582
		protected bool m_enabled;

		// Token: 0x0400062F RID: 1583
		protected LogicGameObject m_parent;
	}
}
