using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x0200000D RID: 13
	public class LogicPathFinder
	{
		// Token: 0x0600005B RID: 91 RVA: 0x0000244D File Offset: 0x0000064D
		public LogicPathFinder(LogicTileMap tileMap)
		{
			this.m_tileMap = tileMap;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000245C File Offset: 0x0000065C
		public virtual void Destruct()
		{
			this.m_tileMap = null;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void SetCostStrategy(bool enabled, int quality)
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void ResetCostStrategyToDefault()
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void FindPath(LogicVector2 startPosition, LogicVector2 endPosition, bool clampPathFinderCost)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002467 File Offset: 0x00000667
		public virtual int GetPathLength()
		{
			return 0;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void GetPathPoint(LogicVector2 position, int idx)
		{
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void GetPathPointSubTile(LogicVector2 position, int idx)
		{
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002465 File Offset: 0x00000665
		public virtual void InvalidateCache()
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002467 File Offset: 0x00000667
		public virtual int GetParent(int index)
		{
			return 0;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsLineOfSightClear()
		{
			return false;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000246A File Offset: 0x0000066A
		public LogicTileMap GetTileMap()
		{
			return this.m_tileMap;
		}

		// Token: 0x0400002F RID: 47
		protected LogicTileMap m_tileMap;
	}
}
