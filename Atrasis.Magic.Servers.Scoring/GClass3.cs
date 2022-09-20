using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3 : SeasonDocument
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000021FE File Offset: 0x000003FE
		public GClass3()
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002206 File Offset: 0x00000406
		public GClass3(LogicLong logicLong_0) : base(logicLong_0)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000220F File Offset: 0x0000040F
		public void method_0()
		{
			this.dictionary_0 = new Dictionary<long, AllianceRankingEntry>[2];
			if (base.EndTime < DateTime.UtcNow)
			{
				this.bool_0 = true;
			}
			this.method_1().Wait();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000029D4 File Offset: 0x00000BD4
		public Task method_1()
		{
			GClass3.Struct0 @struct;
			@struct.gclass3_0 = this;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct0>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002241 File Offset: 0x00000441
		public bool method_2()
		{
			return this.bool_0;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002A1C File Offset: 0x00000C1C
		private Task method_3(int int_0)
		{
			GClass3.Struct1 @struct;
			@struct.gclass3_0 = this;
			@struct.int_1 = int_0;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct1>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002A6C File Offset: 0x00000C6C
		private Task method_4()
		{
			GClass3.Struct2 @struct;
			@struct.gclass3_0 = this;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct2>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002AB4 File Offset: 0x00000CB4
		private Task method_5()
		{
			GClass3.Struct3 @struct;
			@struct.gclass3_0 = this;
			@struct.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder_ = @struct.asyncTaskMethodBuilder_0;
			asyncTaskMethodBuilder_.Start<GClass3.Struct3>(ref @struct);
			return @struct.asyncTaskMethodBuilder_0.Task;
		}

		// Token: 0x04000009 RID: 9
		private Dictionary<long, AllianceRankingEntry>[] dictionary_0;

		// Token: 0x0400000A RID: 10
		private Dictionary<long, AvatarRankingEntry> dictionary_1;

		// Token: 0x0400000B RID: 11
		private Dictionary<long, AvatarDuelRankingEntry> dictionary_2;

		// Token: 0x0400000C RID: 12
		private bool bool_0;
	}
}
