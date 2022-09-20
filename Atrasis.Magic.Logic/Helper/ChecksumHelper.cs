using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000107 RID: 263
	public class ChecksumHelper
	{
		// Token: 0x06000CA4 RID: 3236 RVA: 0x00009233 File Offset: 0x00007433
		public ChecksumHelper(LogicJSONObject root)
		{
			if (root != null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicJSONNode>(16);
				this.logicArrayList_0.Add(root);
			}
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0002B5A0 File Offset: 0x000297A0
		public void StartObject(string name)
		{
			if (this.logicArrayList_0 != null)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONNode logicJSONNode = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
				{
					((LogicJSONObject)logicJSONNode).Put(name, logicJSONObject);
				}
				else if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
				{
					((LogicJSONArray)logicJSONNode).Add(logicJSONObject);
					logicJSONObject.Put("name", new LogicJSONString(name));
				}
				this.logicArrayList_0.Add(logicJSONObject);
			}
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x0002B620 File Offset: 0x00029820
		public void EndObject()
		{
			if (this.logicArrayList_0 != null)
			{
				Debugger.DoAssert(this.logicArrayList_0[this.logicArrayList_0.Size() - 1].GetJSONNodeType() == LogicJSONNodeType.OBJECT, "ChecksumHelper::endObject() called but top is not an object");
				Debugger.DoAssert(this.logicArrayList_0.Size() > 1, "ChecksumHelper::endObject() - size is too small");
				this.logicArrayList_0.Remove(this.logicArrayList_0.Size() - 1);
			}
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x0002B694 File Offset: 0x00029894
		public void StartArray(string name)
		{
			if (this.logicArrayList_0 != null)
			{
				LogicJSONNode logicJSONNode = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
				{
					LogicJSONArray item = new LogicJSONArray();
					((LogicJSONObject)logicJSONNode).Put(name, item);
					this.logicArrayList_0.Add(item);
					return;
				}
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
				{
					Debugger.DoAssert(((LogicJSONArray)logicJSONNode).Size() != 0, "ChecksumHelper::startArray can't handle the truth (array inside array)");
				}
			}
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x0002B710 File Offset: 0x00029910
		public void EndArray()
		{
			if (this.logicArrayList_0 != null)
			{
				Debugger.DoAssert(this.logicArrayList_0[this.logicArrayList_0.Size() - 1].GetJSONNodeType() == LogicJSONNodeType.ARRAY, "ChecksumHelper::endArray() called but top is not an array");
				Debugger.DoAssert(this.logicArrayList_0.Size() > 1, "ChecksumHelper::endArray() - size is too small");
				this.logicArrayList_0.Remove(this.logicArrayList_0.Size() - 1);
			}
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0002B784 File Offset: 0x00029984
		public void WriteValue(string name, int value)
		{
			this.int_0 += value;
			if (this.logicArrayList_0 != null)
			{
				LogicJSONNode logicJSONNode = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
				{
					((LogicJSONObject)logicJSONNode).Put(name, new LogicJSONNumber(value));
					return;
				}
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
				{
					((LogicJSONArray)logicJSONNode).Add(new LogicJSONString(string.Format("{0} {1}", name, value)));
				}
			}
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x00009257 File Offset: 0x00007457
		public int GetChecksum()
		{
			return this.int_0;
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x0000925F File Offset: 0x0000745F
		public void Destruct()
		{
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x04000501 RID: 1281
		private int int_0;

		// Token: 0x04000502 RID: 1282
		private LogicArrayList<LogicJSONNode> logicArrayList_0;
	}
}
