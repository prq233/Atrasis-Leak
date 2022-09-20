using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000EF RID: 239
	public class GameDocument : CouchbaseDocument
	{
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00008E58 File Offset: 0x00007058
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00008E60 File Offset: 0x00007060
		public LogicClientAvatar LogicClientAvatar { get; set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00008E69 File Offset: 0x00007069
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00008E71 File Offset: 0x00007071
		public LogicClientHome LogicClientHome { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00008E7A File Offset: 0x0000707A
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00008E82 File Offset: 0x00007082
		public LogicArrayList<LogicServerCommand> ServerCommands { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00008E8B File Offset: 0x0000708B
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00008E93 File Offset: 0x00007093
		public LogicArrayList<GameDocument.RecentlyEnemy> RecentlyMatchedEnemies { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00008E9C File Offset: 0x0000709C
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00008EA4 File Offset: 0x000070A4
		public LogicArrayList<LogicLong> AllianceBookmarksList { get; set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00008EAD File Offset: 0x000070AD
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00008EB5 File Offset: 0x000070B5
		public LogicArrayList<LogicLong> AvatarStreamList { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00008EBE File Offset: 0x000070BE
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00008EC6 File Offset: 0x000070C6
		public LogicArrayList<LogicLong> Village2AttackList { get; set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00008ECF File Offset: 0x000070CF
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00008ED7 File Offset: 0x000070D7
		public int DonationCount { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00008EE0 File Offset: 0x000070E0
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00008EE8 File Offset: 0x000070E8
		public int ReceivedDonationCount { get; set; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00008EF1 File Offset: 0x000070F1
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00008EF9 File Offset: 0x000070F9
		public int SaveTime { get; set; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00008F02 File Offset: 0x00007102
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00008F0A File Offset: 0x0000710A
		public int MaintenanceTime { get; set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00008F13 File Offset: 0x00007113
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00008F1B File Offset: 0x0000711B
		public int ProtectionTime { get; set; }

		// Token: 0x06000721 RID: 1825 RVA: 0x00016204 File Offset: 0x00014404
		public GameDocument()
		{
			this.LogicClientHome = new LogicClientHome();
			this.LogicClientAvatar = LogicClientAvatar.GetDefaultAvatar();
			this.ServerCommands = new LogicArrayList<LogicServerCommand>();
			this.RecentlyMatchedEnemies = new LogicArrayList<GameDocument.RecentlyEnemy>();
			this.AllianceBookmarksList = new LogicArrayList<LogicLong>();
			this.AvatarStreamList = new LogicArrayList<LogicLong>();
			this.Village2AttackList = new LogicArrayList<LogicLong>();
			this.SaveTime = -1;
			this.MaintenanceTime = -1;
			this.ProtectionTime = TimeUtil.GetTimestamp();
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00016280 File Offset: 0x00014480
		public GameDocument(LogicLong id) : base(id)
		{
			this.LogicClientHome = new LogicClientHome();
			this.LogicClientAvatar = LogicClientAvatar.GetDefaultAvatar();
			this.ServerCommands = new LogicArrayList<LogicServerCommand>();
			this.RecentlyMatchedEnemies = new LogicArrayList<GameDocument.RecentlyEnemy>();
			this.AllianceBookmarksList = new LogicArrayList<LogicLong>();
			this.AvatarStreamList = new LogicArrayList<LogicLong>();
			this.Village2AttackList = new LogicArrayList<LogicLong>();
			this.SaveTime = -1;
			this.MaintenanceTime = -1;
			this.ProtectionTime = TimeUtil.GetTimestamp();
			this.method_0(id);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00008F24 File Offset: 0x00007124
		private void method_0(LogicLong logicLong_1)
		{
			this.LogicClientAvatar.SetId(logicLong_1);
			this.LogicClientAvatar.SetCurrentHomeId(logicLong_1);
			this.LogicClientHome.SetHomeId(logicLong_1);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00008F4A File Offset: 0x0000714A
		public int GetRemainingProtectionTimeSeconds()
		{
			return LogicMath.Max(this.LogicClientHome.GetShieldDurationSeconds() + this.LogicClientHome.GetGuardDurationSeconds() + this.ProtectionTime - TimeUtil.GetTimestamp(), 0);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00016304 File Offset: 0x00014504
		public void UpdateProtection()
		{
			int timestamp = TimeUtil.GetTimestamp();
			int num = this.LogicClientHome.GetShieldDurationSeconds() - (timestamp - this.ProtectionTime);
			if (num < 0)
			{
				int num2 = this.LogicClientHome.GetGuardDurationSeconds() + num;
				if (num2 < 0)
				{
					num2 = 0;
				}
				num = 0;
				this.LogicClientHome.SetGuardDurationSeconds(num2);
			}
			this.LogicClientHome.SetShieldDurationSeconds(num);
			this.ProtectionTime = timestamp;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00016368 File Offset: 0x00014568
		protected override void Encode(ByteStream stream)
		{
			this.LogicClientAvatar.Encode(stream);
			this.LogicClientHome.Encode(stream);
			stream.WriteVInt(this.ServerCommands.Size());
			for (int i = 0; i < this.ServerCommands.Size(); i++)
			{
				LogicCommandManager.EncodeCommand(stream, this.ServerCommands[i]);
			}
			stream.WriteVInt(this.RecentlyMatchedEnemies.Size());
			for (int j = 0; j < this.RecentlyMatchedEnemies.Size(); j++)
			{
				stream.WriteLong(this.RecentlyMatchedEnemies[j].AvatarId);
				stream.WriteVInt(this.RecentlyMatchedEnemies[j].Timestamp);
			}
			stream.WriteVInt(this.AllianceBookmarksList.Size());
			for (int k = 0; k < this.AllianceBookmarksList.Size(); k++)
			{
				stream.WriteLong(this.AllianceBookmarksList[k]);
			}
			stream.WriteVInt(this.AvatarStreamList.Size());
			for (int l = 0; l < this.AvatarStreamList.Size(); l++)
			{
				stream.WriteLong(this.AvatarStreamList[l]);
			}
			stream.WriteVInt(this.Village2AttackList.Size());
			for (int m = 0; m < this.Village2AttackList.Size(); m++)
			{
				stream.WriteLong(this.Village2AttackList[m]);
			}
			stream.WriteVInt(this.DonationCount);
			stream.WriteVInt(this.ReceivedDonationCount);
			stream.WriteVInt(this.SaveTime);
			stream.WriteVInt(this.MaintenanceTime);
			stream.WriteVInt(this.ProtectionTime);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00016508 File Offset: 0x00014708
		protected override void Decode(ByteStream stream)
		{
			this.LogicClientAvatar.Decode(stream);
			this.LogicClientHome.Decode(stream);
			this.ServerCommands.Clear();
			this.RecentlyMatchedEnemies.Clear();
			this.AllianceBookmarksList.Clear();
			this.AvatarStreamList.Clear();
			this.Village2AttackList.Clear();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.ServerCommands.Add((LogicServerCommand)LogicCommandManager.DecodeCommand(stream));
			}
			for (int j = stream.ReadVInt(); j > 0; j--)
			{
				this.RecentlyMatchedEnemies.Add(new GameDocument.RecentlyEnemy(stream.ReadLong(), stream.ReadVInt()));
			}
			for (int k = stream.ReadVInt(); k > 0; k--)
			{
				this.AllianceBookmarksList.Add(stream.ReadLong());
			}
			for (int l = stream.ReadVInt(); l > 0; l--)
			{
				this.AvatarStreamList.Add(stream.ReadLong());
			}
			for (int m = stream.ReadVInt(); m > 0; m--)
			{
				this.Village2AttackList.Add(stream.ReadLong());
			}
			this.DonationCount = stream.ReadVInt();
			this.ReceivedDonationCount = stream.ReadVInt();
			this.SaveTime = stream.ReadVInt();
			this.MaintenanceTime = stream.ReadVInt();
			this.ProtectionTime = stream.ReadVInt();
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00016660 File Offset: 0x00014860
		protected override void Save(LogicJSONObject jsonObject)
		{
			this.LogicClientAvatar.Save(jsonObject);
			jsonObject.Put("home", this.LogicClientHome.Save());
			jsonObject.Put("saveTime", new LogicJSONNumber(this.SaveTime));
			jsonObject.Put("maintenanceTime", new LogicJSONNumber(this.MaintenanceTime));
			jsonObject.Put("protectionTime", new LogicJSONNumber(this.ProtectionTime));
			jsonObject.Put("donationCount", new LogicJSONNumber(this.DonationCount));
			jsonObject.Put("receivedDonationCount", new LogicJSONNumber(this.ReceivedDonationCount));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.RecentlyMatchedEnemies.Size());
			for (int i = 0; i < this.RecentlyMatchedEnemies.Size(); i++)
			{
				GameDocument.RecentlyEnemy recentlyEnemy = this.RecentlyMatchedEnemies[i];
				LogicJSONArray logicJSONArray2 = new LogicJSONArray(3);
				logicJSONArray2.Add(new LogicJSONNumber(recentlyEnemy.AvatarId.GetHigherInt()));
				logicJSONArray2.Add(new LogicJSONNumber(recentlyEnemy.AvatarId.GetLowerInt()));
				logicJSONArray2.Add(new LogicJSONNumber(recentlyEnemy.Timestamp));
				logicJSONArray.Add(logicJSONArray2);
			}
			jsonObject.Put("recentlyEnemies", logicJSONArray);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray(this.AllianceBookmarksList.Size());
			for (int j = 0; j < this.AllianceBookmarksList.Size(); j++)
			{
				LogicLong logicLong = this.AllianceBookmarksList[j];
				LogicJSONArray logicJSONArray4 = new LogicJSONArray(2);
				logicJSONArray4.Add(new LogicJSONNumber(logicLong.GetHigherInt()));
				logicJSONArray4.Add(new LogicJSONNumber(logicLong.GetLowerInt()));
				logicJSONArray3.Add(logicJSONArray4);
			}
			jsonObject.Put("allianceBookmarks", logicJSONArray3);
			LogicJSONArray logicJSONArray5 = new LogicJSONArray(this.AvatarStreamList.Size());
			for (int k = 0; k < this.AvatarStreamList.Size(); k++)
			{
				LogicLong logicLong2 = this.AvatarStreamList[k];
				LogicJSONArray logicJSONArray6 = new LogicJSONArray(2);
				logicJSONArray6.Add(new LogicJSONNumber(logicLong2.GetHigherInt()));
				logicJSONArray6.Add(new LogicJSONNumber(logicLong2.GetLowerInt()));
				logicJSONArray5.Add(logicJSONArray6);
			}
			jsonObject.Put("avatarStreams", logicJSONArray5);
			LogicJSONArray logicJSONArray7 = new LogicJSONArray(this.Village2AttackList.Size());
			for (int l = 0; l < this.Village2AttackList.Size(); l++)
			{
				LogicLong logicLong3 = this.Village2AttackList[l];
				LogicJSONArray logicJSONArray8 = new LogicJSONArray(2);
				logicJSONArray8.Add(new LogicJSONNumber(logicLong3.GetHigherInt()));
				logicJSONArray8.Add(new LogicJSONNumber(logicLong3.GetLowerInt()));
				logicJSONArray7.Add(logicJSONArray8);
			}
			jsonObject.Put("attackListV2", logicJSONArray7);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0001690C File Offset: 0x00014B0C
		protected override void Load(LogicJSONObject jsonObject)
		{
			this.LogicClientAvatar.Load(jsonObject);
			this.LogicClientHome.Load(jsonObject.GetJSONObject("home"));
			this.SaveTime = jsonObject.GetJSONNumber("saveTime").GetIntValue();
			this.MaintenanceTime = jsonObject.GetJSONNumber("maintenanceTime").GetIntValue();
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("protectionTime");
			this.ProtectionTime = ((jsonnumber != null) ? jsonnumber.GetIntValue() : this.SaveTime);
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("donationCount");
			this.DonationCount = ((jsonnumber2 != null) ? jsonnumber2.GetIntValue() : 0);
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("receivedDonationCount");
			this.ReceivedDonationCount = ((jsonnumber3 != null) ? jsonnumber3.GetIntValue() : 0);
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("recentlyEnemies");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONArray jsonarray2 = jsonarray.GetJSONArray(i);
					this.RecentlyMatchedEnemies.Add(new GameDocument.RecentlyEnemy(new LogicLong(jsonarray2.GetJSONNumber(0).GetIntValue(), jsonarray2.GetJSONNumber(1).GetIntValue()), jsonarray2.GetJSONNumber(2).GetIntValue()));
				}
			}
			LogicJSONArray jsonarray3 = jsonObject.GetJSONArray("allianceBookmarks");
			if (jsonarray3 != null)
			{
				this.AllianceBookmarksList.EnsureCapacity(jsonarray3.Size());
				for (int j = 0; j < jsonarray3.Size(); j++)
				{
					LogicJSONArray jsonarray4 = jsonarray3.GetJSONArray(j);
					this.AllianceBookmarksList.Add(new LogicLong(jsonarray4.GetJSONNumber(0).GetIntValue(), jsonarray4.GetJSONNumber(1).GetIntValue()));
				}
			}
			LogicJSONArray jsonarray5 = jsonObject.GetJSONArray("avatarStreams");
			if (jsonarray5 != null)
			{
				this.AvatarStreamList.EnsureCapacity(jsonarray5.Size());
				for (int k = 0; k < jsonarray5.Size(); k++)
				{
					LogicJSONArray jsonarray6 = jsonarray5.GetJSONArray(k);
					this.AvatarStreamList.Add(new LogicLong(jsonarray6.GetJSONNumber(0).GetIntValue(), jsonarray6.GetJSONNumber(1).GetIntValue()));
				}
			}
			LogicJSONArray jsonarray7 = jsonObject.GetJSONArray("attackListV2");
			if (jsonarray7 != null)
			{
				this.Village2AttackList.EnsureCapacity(jsonarray7.Size());
				for (int l = 0; l < jsonarray7.Size(); l++)
				{
					LogicJSONArray jsonarray8 = jsonarray7.GetJSONArray(l);
					this.Village2AttackList.Add(new LogicLong(jsonarray8.GetJSONNumber(0).GetIntValue(), jsonarray8.GetJSONNumber(1).GetIntValue()));
				}
			}
			this.method_0(base.Id);
		}

		// Token: 0x040003F7 RID: 1015
		private const string string_0 = "home";

		// Token: 0x040003F8 RID: 1016
		private const string string_1 = "saveTime";

		// Token: 0x040003F9 RID: 1017
		private const string string_2 = "maintenanceTime";

		// Token: 0x040003FA RID: 1018
		private const string string_3 = "donationCount";

		// Token: 0x040003FB RID: 1019
		private const string string_4 = "receivedDonationCount";

		// Token: 0x040003FC RID: 1020
		private const string string_5 = "recentlyEnemies";

		// Token: 0x040003FD RID: 1021
		private const string string_6 = "allianceBookmarks";

		// Token: 0x040003FE RID: 1022
		private const string string_7 = "avatarStreams";

		// Token: 0x040003FF RID: 1023
		private const string string_8 = "attackListV2";

		// Token: 0x04000400 RID: 1024
		private const string string_9 = "protectionTime";

		// Token: 0x04000401 RID: 1025
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000402 RID: 1026
		[CompilerGenerated]
		private LogicClientHome logicClientHome_0;

		// Token: 0x04000403 RID: 1027
		[CompilerGenerated]
		private LogicArrayList<LogicServerCommand> logicArrayList_0;

		// Token: 0x04000404 RID: 1028
		[CompilerGenerated]
		private LogicArrayList<GameDocument.RecentlyEnemy> logicArrayList_1;

		// Token: 0x04000405 RID: 1029
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_2;

		// Token: 0x04000406 RID: 1030
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_3;

		// Token: 0x04000407 RID: 1031
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_4;

		// Token: 0x04000408 RID: 1032
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000409 RID: 1033
		[CompilerGenerated]
		private int int_1;

		// Token: 0x0400040A RID: 1034
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400040B RID: 1035
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400040C RID: 1036
		[CompilerGenerated]
		private int int_4;

		// Token: 0x020000F0 RID: 240
		public struct RecentlyEnemy
		{
			// Token: 0x0600072A RID: 1834 RVA: 0x00008F76 File Offset: 0x00007176
			public RecentlyEnemy(LogicLong id, int timestamp)
			{
				this.AvatarId = id;
				this.Timestamp = timestamp;
			}

			// Token: 0x0400040D RID: 1037
			public readonly LogicLong AvatarId;

			// Token: 0x0400040E RID: 1038
			public readonly int Timestamp;
		}
	}
}
