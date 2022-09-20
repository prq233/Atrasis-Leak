using System;
using System.Text;
using Atrasis.Magic.Logic.Util;

namespace Atrasis.Magic.Servers.Core.Helper
{
	// Token: 0x020000E5 RID: 229
	public static class CompressibleStringHelper
	{
		// Token: 0x060006A6 RID: 1702 RVA: 0x00015298 File Offset: 0x00013498
		public static void Uncompress(LogicCompressibleString str)
		{
			if (str.IsCompressed())
			{
				byte[] array;
				ZLibHelper.DecompressInMySQLFormat(str.RemoveCompressed(), out array);
				if (array != null)
				{
					str.Set(Encoding.UTF8.GetString(array), str.GetCompressed());
				}
			}
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x000152D8 File Offset: 0x000134D8
		public static void Compress(LogicCompressibleString str)
		{
			if (!str.IsCompressed())
			{
				byte[] array;
				ZLibHelper.CompressInZLibFormat(Encoding.UTF8.GetBytes(str.Get()), out array);
				if (array != null)
				{
					str.Set(array);
				}
			}
		}
	}
}
