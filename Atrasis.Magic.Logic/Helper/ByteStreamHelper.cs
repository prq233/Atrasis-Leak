using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000106 RID: 262
	public static class ByteStreamHelper
	{
		// Token: 0x06000C9F RID: 3231 RVA: 0x000091DF File Offset: 0x000073DF
		public static LogicCompressibleString ReadCompressableStringOrNull(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				return null;
			}
			LogicCompressibleString logicCompressibleString = new LogicCompressibleString();
			logicCompressibleString.Decode(stream);
			return logicCompressibleString;
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x000091F7 File Offset: 0x000073F7
		public static LogicData ReadDataReference(ByteStream stream)
		{
			return LogicDataTables.GetDataById(stream.ReadInt());
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x0002B578 File Offset: 0x00029778
		public static LogicData ReadDataReference(ByteStream stream, LogicDataType tableIndex)
		{
			int globalId = stream.ReadInt();
			if (GlobalID.GetClassID(globalId) == (int)(tableIndex + 1))
			{
				return LogicDataTables.GetDataById(globalId);
			}
			return null;
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x00009204 File Offset: 0x00007404
		public static void WriteCompressableStringOrNull(ChecksumEncoder encoder, LogicCompressibleString compressibleString)
		{
			if (compressibleString == null)
			{
				encoder.WriteBoolean(false);
				return;
			}
			encoder.WriteBoolean(true);
			compressibleString.Encode(encoder);
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x0000921F File Offset: 0x0000741F
		public static void WriteDataReference(ChecksumEncoder encoder, LogicData data)
		{
			encoder.WriteInt((data != null) ? data.GetGlobalID() : 0);
		}
	}
}
