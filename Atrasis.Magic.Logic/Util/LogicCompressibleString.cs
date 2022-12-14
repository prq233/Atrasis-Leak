using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000008 RID: 8
	public class LogicCompressibleString
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00002234 File Offset: 0x00000434
		public void Destruct()
		{
			this.string_0 = null;
			this.byte_0 = null;
			this.int_0 = 0;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000224B File Offset: 0x0000044B
		public void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.int_0 = stream.ReadBytesLength();
				this.byte_0 = stream.ReadBytes(this.int_0, 900000);
				return;
			}
			this.string_0 = stream.ReadString(900000);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000228A File Offset: 0x0000048A
		public void Encode(ChecksumEncoder encoder)
		{
			if (this.byte_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteBytes(this.byte_0, this.byte_0.Length);
				return;
			}
			encoder.WriteBoolean(false);
			encoder.WriteString(this.string_0);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000022C3 File Offset: 0x000004C3
		public string Get()
		{
			return this.string_0;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000022CB File Offset: 0x000004CB
		public void Set(string value)
		{
			this.Set(value, null);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000022D5 File Offset: 0x000004D5
		public void Set(byte[] compressedBytes)
		{
			this.Set(null, compressedBytes);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0001246C File Offset: 0x0001066C
		public void Set(string value, byte[] compressedBytes)
		{
			this.string_0 = value;
			this.byte_0 = null;
			this.int_0 = ((compressedBytes != null) ? compressedBytes.Length : 0);
			if (this.int_0 > 0)
			{
				this.byte_0 = new byte[this.int_0];
				Buffer.BlockCopy(compressedBytes, 0, this.byte_0, 0, this.int_0);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000022DF File Offset: 0x000004DF
		public int GetCompressedLength()
		{
			return this.int_0;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000022E7 File Offset: 0x000004E7
		public bool IsCompressed()
		{
			return this.string_0 == null && this.int_0 != 0;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000022FC File Offset: 0x000004FC
		public byte[] GetCompressed()
		{
			return this.byte_0;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002304 File Offset: 0x00000504
		public byte[] RemoveCompressed()
		{
			byte[] result = this.byte_0;
			this.byte_0 = null;
			this.int_0 = 0;
			return result;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000124C4 File Offset: 0x000106C4
		public LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			if (this.string_0 != null)
			{
				logicJSONObject.Put("s", new LogicJSONString(this.string_0));
			}
			if (this.byte_0 != null)
			{
				logicJSONObject.Put("c", new LogicJSONString(Convert.ToBase64String(this.byte_0, 0, this.int_0)));
			}
			return logicJSONObject;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00012520 File Offset: 0x00010720
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONString jsonstring = jsonObject.GetJSONString("s");
			if (jsonstring != null)
			{
				this.string_0 = jsonstring.GetStringValue();
			}
			LogicJSONString jsonstring2 = jsonObject.GetJSONString("c");
			if (jsonstring2 != null)
			{
				this.byte_0 = Convert.FromBase64String(jsonstring2.GetStringValue());
				this.int_0 = this.byte_0.Length;
			}
		}

		// Token: 0x04000026 RID: 38
		private string string_0;

		// Token: 0x04000027 RID: 39
		private byte[] byte_0;

		// Token: 0x04000028 RID: 40
		private int int_0;
	}
}
