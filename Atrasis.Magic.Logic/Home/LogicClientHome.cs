using System;
using Atrasis.Magic.Logic.Home.Change;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Home
{
	// Token: 0x02000104 RID: 260
	public class LogicClientHome
	{
		// Token: 0x06000C81 RID: 3201 RVA: 0x000090DA File Offset: 0x000072DA
		public LogicClientHome()
		{
			this.logicCompressibleString_0 = new LogicCompressibleString();
			this.logicCompressibleString_1 = new LogicCompressibleString();
			this.logicCompressibleString_2 = new LogicCompressibleString();
			this.Init();
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0002B360 File Offset: 0x00029560
		public void Destruct()
		{
			if (this.logicCompressibleString_1 != null)
			{
				this.logicCompressibleString_1.Destruct();
				this.logicCompressibleString_1 = null;
			}
			if (this.logicCompressibleString_2 != null)
			{
				this.logicCompressibleString_2.Destruct();
				this.logicCompressibleString_2 = null;
			}
			if (this.logicCompressibleString_0 != null)
			{
				this.logicCompressibleString_0.Destruct();
				this.logicCompressibleString_0 = null;
			}
			if (this.logicHomeChangeListener_0 != null)
			{
				this.logicHomeChangeListener_0.Destruct();
				this.logicHomeChangeListener_0 = null;
			}
			this.logicLong_0 = null;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00009109 File Offset: 0x00007309
		public void Init()
		{
			this.logicLong_0 = new LogicLong();
			this.logicHomeChangeListener_0 = new LogicHomeChangeListener();
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0002B3DC File Offset: 0x000295DC
		public virtual void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			this.logicCompressibleString_0.Encode(encoder);
			this.logicCompressibleString_2.Encode(encoder);
			this.logicCompressibleString_1.Encode(encoder);
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0002B440 File Offset: 0x00029640
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicCompressibleString_0.Decode(stream);
			this.logicCompressibleString_2.Decode(stream);
			this.logicCompressibleString_1.Decode(stream);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x00009121 File Offset: 0x00007321
		public LogicLong GetHomeId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00009129 File Offset: 0x00007329
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00009132 File Offset: 0x00007332
		public int GetShieldDurationSeconds()
		{
			return this.int_0;
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x0000913A File Offset: 0x0000733A
		public int GetGuardDurationSeconds()
		{
			return this.int_1;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00009142 File Offset: 0x00007342
		public int GetPersonalBreakSeconds()
		{
			return this.int_2;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0000914A File Offset: 0x0000734A
		public LogicCompressibleString GetCompressibleCalendarJSON()
		{
			return this.logicCompressibleString_2;
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x00009152 File Offset: 0x00007352
		public LogicCompressibleString GetCompressibleGlobalJSON()
		{
			return this.logicCompressibleString_1;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0000915A File Offset: 0x0000735A
		public LogicCompressibleString GetCompressibleHomeJSON()
		{
			return this.logicCompressibleString_0;
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x00009162 File Offset: 0x00007362
		public string GetHomeJSON()
		{
			return this.logicCompressibleString_0.Get();
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x0000916F File Offset: 0x0000736F
		public void SetHomeJSON(string json)
		{
			this.logicCompressibleString_0.Set(json);
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x0000917D File Offset: 0x0000737D
		public string GetCalendarJSON()
		{
			return this.logicCompressibleString_2.Get();
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0000918A File Offset: 0x0000738A
		public void SetCalendarJSON(string json)
		{
			this.logicCompressibleString_2.Set(json);
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x00009198 File Offset: 0x00007398
		public string GetGlobalJSON()
		{
			return this.logicCompressibleString_1.Get();
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x000091A5 File Offset: 0x000073A5
		public void SetGlobalJSON(string json)
		{
			this.logicCompressibleString_1.Set(json);
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x000091B3 File Offset: 0x000073B3
		public void SetShieldDurationSeconds(int secs)
		{
			this.int_0 = secs;
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x000091BC File Offset: 0x000073BC
		public void SetGuardDurationSeconds(int secs)
		{
			this.int_1 = secs;
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x000091C5 File Offset: 0x000073C5
		public void SetPersonalBreakSeconds(int secs)
		{
			this.int_2 = secs;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x000091CE File Offset: 0x000073CE
		public LogicHomeChangeListener GetChangeListener()
		{
			return this.logicHomeChangeListener_0;
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x000091D6 File Offset: 0x000073D6
		public void SetChangeListener(LogicHomeChangeListener listener)
		{
			this.logicHomeChangeListener_0 = listener;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x0002B4A4 File Offset: 0x000296A4
		public LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("homeJSON", this.logicCompressibleString_0.Save());
			logicJSONObject.Put("shield_t", new LogicJSONNumber(this.int_0));
			logicJSONObject.Put("guard_t", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("personal_break_t", new LogicJSONNumber(this.int_2));
			return logicJSONObject;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x0002B510 File Offset: 0x00029710
		public void Load(LogicJSONObject jsonObject)
		{
			this.logicCompressibleString_0.Load(jsonObject.GetJSONObject("homeJSON"));
			this.int_0 = jsonObject.GetJSONNumber("shield_t").GetIntValue();
			this.int_1 = jsonObject.GetJSONNumber("guard_t").GetIntValue();
			this.int_2 = jsonObject.GetJSONNumber("personal_break_t").GetIntValue();
		}

		// Token: 0x040004F9 RID: 1273
		private LogicLong logicLong_0;

		// Token: 0x040004FA RID: 1274
		private LogicHomeChangeListener logicHomeChangeListener_0;

		// Token: 0x040004FB RID: 1275
		private int int_0;

		// Token: 0x040004FC RID: 1276
		private int int_1;

		// Token: 0x040004FD RID: 1277
		private int int_2;

		// Token: 0x040004FE RID: 1278
		private LogicCompressibleString logicCompressibleString_0;

		// Token: 0x040004FF RID: 1279
		private LogicCompressibleString logicCompressibleString_1;

		// Token: 0x04000500 RID: 1280
		private LogicCompressibleString logicCompressibleString_2;
	}
}
