using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x0200010E RID: 270
	public sealed class LogicDeco : LogicGameObject
	{
		// Token: 0x06000D5C RID: 3420 RVA: 0x00009803 File Offset: 0x00007A03
		public LogicDeco(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			base.AddComponent(new LogicLayoutComponent(this));
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x0000981A File Offset: 0x00007A1A
		public LogicDecoData GetDecoData()
		{
			return (LogicDecoData)this.m_data;
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00002D0D File Offset: 0x00000F0D
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.DECO;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00009827 File Offset: 0x00007A27
		public override int GetWidthInTiles()
		{
			return this.GetDecoData().GetWidth();
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00009834 File Offset: 0x00007A34
		public override int GetHeightInTiles()
		{
			return this.GetDecoData().GetHeight();
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00009841 File Offset: 0x00007A41
		public override bool IsPassable()
		{
			return this.GetDecoData().IsPassable();
		}
	}
}
