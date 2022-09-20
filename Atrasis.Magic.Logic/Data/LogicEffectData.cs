using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014C RID: 332
	public class LogicEffectData : LogicData
	{
		// Token: 0x06001289 RID: 4745 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicEffectData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600128A RID: 4746 RVA: 0x0000C6F3 File Offset: 0x0000A8F3
		// (set) Token: 0x0600128B RID: 4747 RVA: 0x0000C6FB File Offset: 0x0000A8FB
		public string SWF { get; protected set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600128C RID: 4748 RVA: 0x0000C704 File Offset: 0x0000A904
		// (set) Token: 0x0600128D RID: 4749 RVA: 0x0000C70C File Offset: 0x0000A90C
		public string ExportName { get; protected set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600128E RID: 4750 RVA: 0x0000C715 File Offset: 0x0000A915
		// (set) Token: 0x0600128F RID: 4751 RVA: 0x0000C71D File Offset: 0x0000A91D
		protected string[] ParticleEmitter { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x0000C726 File Offset: 0x0000A926
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x0000C72E File Offset: 0x0000A92E
		public int EmitterDelayMs { get; protected set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06001292 RID: 4754 RVA: 0x0000C737 File Offset: 0x0000A937
		// (set) Token: 0x06001293 RID: 4755 RVA: 0x0000C73F File Offset: 0x0000A93F
		public int CameraShake { get; protected set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x0000C748 File Offset: 0x0000A948
		// (set) Token: 0x06001295 RID: 4757 RVA: 0x0000C750 File Offset: 0x0000A950
		public int CameraShakeTimeMS { get; protected set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x0000C759 File Offset: 0x0000A959
		// (set) Token: 0x06001297 RID: 4759 RVA: 0x0000C761 File Offset: 0x0000A961
		public bool CameraShakeInReplay { get; protected set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06001298 RID: 4760 RVA: 0x0000C76A File Offset: 0x0000A96A
		// (set) Token: 0x06001299 RID: 4761 RVA: 0x0000C772 File Offset: 0x0000A972
		protected bool[] AttachToParent { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x0000C77B File Offset: 0x0000A97B
		// (set) Token: 0x0600129B RID: 4763 RVA: 0x0000C783 File Offset: 0x0000A983
		protected bool[] DetachAfterStart { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x0000C78C File Offset: 0x0000A98C
		// (set) Token: 0x0600129D RID: 4765 RVA: 0x0000C794 File Offset: 0x0000A994
		protected bool[] DestroyWhenParentDies { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600129E RID: 4766 RVA: 0x0000C79D File Offset: 0x0000A99D
		// (set) Token: 0x0600129F RID: 4767 RVA: 0x0000C7A5 File Offset: 0x0000A9A5
		public bool Looping { get; protected set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060012A0 RID: 4768 RVA: 0x0000C7AE File Offset: 0x0000A9AE
		// (set) Token: 0x060012A1 RID: 4769 RVA: 0x0000C7B6 File Offset: 0x0000A9B6
		protected string[] IsoLayer { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060012A2 RID: 4770 RVA: 0x0000C7BF File Offset: 0x0000A9BF
		// (set) Token: 0x060012A3 RID: 4771 RVA: 0x0000C7C7 File Offset: 0x0000A9C7
		public bool Targeted { get; protected set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060012A4 RID: 4772 RVA: 0x0000C7D0 File Offset: 0x0000A9D0
		// (set) Token: 0x060012A5 RID: 4773 RVA: 0x0000C7D8 File Offset: 0x0000A9D8
		public int MaxCount { get; protected set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060012A6 RID: 4774 RVA: 0x0000C7E1 File Offset: 0x0000A9E1
		// (set) Token: 0x060012A7 RID: 4775 RVA: 0x0000C7E9 File Offset: 0x0000A9E9
		protected string[] Sound { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060012A8 RID: 4776 RVA: 0x0000C7F2 File Offset: 0x0000A9F2
		// (set) Token: 0x060012A9 RID: 4777 RVA: 0x0000C7FA File Offset: 0x0000A9FA
		protected int[] Volume { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x0000C803 File Offset: 0x0000AA03
		// (set) Token: 0x060012AB RID: 4779 RVA: 0x0000C80B File Offset: 0x0000AA0B
		protected int[] MinPitch { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x0000C814 File Offset: 0x0000AA14
		// (set) Token: 0x060012AD RID: 4781 RVA: 0x0000C81C File Offset: 0x0000AA1C
		protected int[] MaxPitch { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x0000C825 File Offset: 0x0000AA25
		// (set) Token: 0x060012AF RID: 4783 RVA: 0x0000C82D File Offset: 0x0000AA2D
		public string LowEndSound { get; protected set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x0000C836 File Offset: 0x0000AA36
		// (set) Token: 0x060012B1 RID: 4785 RVA: 0x0000C83E File Offset: 0x0000AA3E
		public int LowEndVolume { get; protected set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x0000C847 File Offset: 0x0000AA47
		// (set) Token: 0x060012B3 RID: 4787 RVA: 0x0000C84F File Offset: 0x0000AA4F
		public int LowEndMinPitch { get; protected set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060012B4 RID: 4788 RVA: 0x0000C858 File Offset: 0x0000AA58
		// (set) Token: 0x060012B5 RID: 4789 RVA: 0x0000C860 File Offset: 0x0000AA60
		public int LowEndMaxPitch { get; protected set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060012B6 RID: 4790 RVA: 0x0000C869 File Offset: 0x0000AA69
		// (set) Token: 0x060012B7 RID: 4791 RVA: 0x0000C871 File Offset: 0x0000AA71
		public bool Beam { get; protected set; }

		// Token: 0x060012B8 RID: 4792 RVA: 0x0000B491 File Offset: 0x00009691
		public override void CreateReferences()
		{
			base.CreateReferences();
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x0000C87A File Offset: 0x0000AA7A
		public string GetParticleEmitter(int index)
		{
			return this.ParticleEmitter[index];
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x0000C884 File Offset: 0x0000AA84
		public bool GetAttachToParent(int index)
		{
			return this.AttachToParent[index];
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x0000C88E File Offset: 0x0000AA8E
		public bool GetDetachAfterStart(int index)
		{
			return this.DetachAfterStart[index];
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x0000C898 File Offset: 0x0000AA98
		public bool GetDestroyWhenParentDies(int index)
		{
			return this.DestroyWhenParentDies[index];
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x0000C8A2 File Offset: 0x0000AAA2
		public string GetIsoLayer(int index)
		{
			return this.IsoLayer[index];
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		public string GetSound(int index)
		{
			return this.Sound[index];
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x0000C8B6 File Offset: 0x0000AAB6
		public int GetVolume(int index)
		{
			return this.Volume[index];
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x0000C8C0 File Offset: 0x0000AAC0
		public int GetMinPitch(int index)
		{
			return this.MinPitch[index];
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x0000C8CA File Offset: 0x0000AACA
		public int GetMaxPitch(int index)
		{
			return this.MaxPitch[index];
		}

		// Token: 0x040008CC RID: 2252
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040008CD RID: 2253
		[CompilerGenerated]
		private string string_1;

		// Token: 0x040008CE RID: 2254
		[CompilerGenerated]
		private string[] string_2;

		// Token: 0x040008CF RID: 2255
		[CompilerGenerated]
		private int int_0;

		// Token: 0x040008D0 RID: 2256
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040008D1 RID: 2257
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040008D2 RID: 2258
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x040008D3 RID: 2259
		[CompilerGenerated]
		private bool[] bool_1;

		// Token: 0x040008D4 RID: 2260
		[CompilerGenerated]
		private bool[] bool_2;

		// Token: 0x040008D5 RID: 2261
		[CompilerGenerated]
		private bool[] bool_3;

		// Token: 0x040008D6 RID: 2262
		[CompilerGenerated]
		private bool bool_4;

		// Token: 0x040008D7 RID: 2263
		[CompilerGenerated]
		private string[] string_3;

		// Token: 0x040008D8 RID: 2264
		[CompilerGenerated]
		private bool bool_5;

		// Token: 0x040008D9 RID: 2265
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040008DA RID: 2266
		[CompilerGenerated]
		private string[] string_4;

		// Token: 0x040008DB RID: 2267
		[CompilerGenerated]
		private int[] int_4;

		// Token: 0x040008DC RID: 2268
		[CompilerGenerated]
		private int[] int_5;

		// Token: 0x040008DD RID: 2269
		[CompilerGenerated]
		private int[] int_6;

		// Token: 0x040008DE RID: 2270
		[CompilerGenerated]
		private string string_5;

		// Token: 0x040008DF RID: 2271
		[CompilerGenerated]
		private int int_7;

		// Token: 0x040008E0 RID: 2272
		[CompilerGenerated]
		private int int_8;

		// Token: 0x040008E1 RID: 2273
		[CompilerGenerated]
		private int int_9;

		// Token: 0x040008E2 RID: 2274
		[CompilerGenerated]
		private bool bool_6;
	}
}
