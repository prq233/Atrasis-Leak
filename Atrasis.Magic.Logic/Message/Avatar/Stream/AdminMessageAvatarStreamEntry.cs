using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000090 RID: 144
	public class AdminMessageAvatarStreamEntry : AvatarStreamEntry
	{
		// Token: 0x06000616 RID: 1558 RVA: 0x0001D8B4 File Offset: 0x0001BAB4
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteBoolean(false);
			stream.WriteString(this.string_1);
			stream.WriteString(this.string_2);
			stream.WriteString(this.string_4);
			stream.WriteString(this.string_5);
			stream.WriteString(this.string_3);
			stream.WriteBoolean(this.bool_2);
			stream.WriteInt(this.int_3);
			stream.WriteBoolean(this.bool_3);
			stream.WriteInt(0);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0001D938 File Offset: 0x0001BB38
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			stream.ReadBoolean();
			this.string_1 = stream.ReadString(900000);
			this.string_2 = stream.ReadString(900000);
			this.string_4 = stream.ReadString(900000);
			this.string_5 = stream.ReadString(900000);
			this.string_3 = stream.ReadString(900000);
			this.bool_2 = stream.ReadBoolean();
			this.int_3 = stream.ReadInt();
			this.bool_3 = stream.ReadBoolean();
			stream.ReadInt();
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override AvatarStreamEntryType GetAvatarStreamEntryType()
		{
			return AvatarStreamEntryType.ADMIN_MESSAGE;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001D9D4 File Offset: 0x0001BBD4
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("AllianceInvitationAvatarStreamEntry::load base is NULL");
			}
			base.Load(jsonobject);
			this.string_1 = jsonObject.GetJSONString("title").GetStringValue();
			this.string_2 = jsonObject.GetJSONString("description").GetStringValue();
			LogicJSONString jsonstring = jsonObject.GetJSONString("button");
			if (jsonstring != null)
			{
				this.string_3 = jsonstring.GetStringValue();
			}
			LogicJSONString jsonstring2 = jsonObject.GetJSONString("helpshift_url");
			if (jsonstring2 != null)
			{
				this.string_4 = jsonstring2.GetStringValue();
			}
			LogicJSONString jsonstring3 = jsonObject.GetJSONString("url");
			if (jsonstring3 != null)
			{
				this.string_5 = jsonstring3.GetStringValue();
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("diamonds");
			if (jsonnumber != null)
			{
				this.int_3 = jsonnumber.GetIntValue();
			}
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean("support_msg");
			if (jsonboolean != null)
			{
				this.bool_2 = jsonboolean.IsTrue();
			}
			LogicJSONBoolean jsonboolean2 = jsonObject.GetJSONBoolean("claimed");
			if (jsonboolean2 != null)
			{
				this.bool_3 = jsonboolean2.IsTrue();
			}
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0001DAD8 File Offset: 0x0001BCD8
		public override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			base.Save(logicJSONObject);
			jsonObject.Put("base", logicJSONObject);
			jsonObject.Put("title", new LogicJSONString(this.string_1));
			jsonObject.Put("description", new LogicJSONString(this.string_2));
			if (this.string_3 != null)
			{
				jsonObject.Put("button", new LogicJSONString(this.string_3));
			}
			if (this.string_4 != null)
			{
				jsonObject.Put("helpshift_url", new LogicJSONString(this.string_4));
			}
			if (this.string_5 != null)
			{
				jsonObject.Put("url", new LogicJSONString(this.string_5));
			}
			if (this.int_3 != 0)
			{
				jsonObject.Put("diamonds", new LogicJSONNumber(this.int_3));
			}
			if (this.bool_2)
			{
				jsonObject.Put("support_msg", new LogicJSONBoolean(this.bool_2));
			}
			if (this.bool_3)
			{
				jsonObject.Put("claimed", new LogicJSONBoolean(this.bool_3));
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0000594E File Offset: 0x00003B4E
		public string GetTitleTID()
		{
			return this.string_1;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00005956 File Offset: 0x00003B56
		public void SetTitleTID(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0000595F File Offset: 0x00003B5F
		public string GetDescriptionTID()
		{
			return this.string_2;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00005967 File Offset: 0x00003B67
		public void SetDescriptionTID(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00005970 File Offset: 0x00003B70
		public string GetButtonTID()
		{
			return this.string_3;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00005978 File Offset: 0x00003B78
		public void SetButtonTID(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00005981 File Offset: 0x00003B81
		public string GetHelpshiftLink()
		{
			return this.string_4;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00005989 File Offset: 0x00003B89
		public void SetHelpshiftLink(string value)
		{
			this.string_4 = value;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00005992 File Offset: 0x00003B92
		public string GetUrlLink()
		{
			return this.string_5;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0000599A File Offset: 0x00003B9A
		public void SetUrlLink(string value)
		{
			this.string_5 = value;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x000059A3 File Offset: 0x00003BA3
		public int GetDiamondCount()
		{
			return this.int_3;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x000059AB File Offset: 0x00003BAB
		public void SetDiamondCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000059B4 File Offset: 0x00003BB4
		public bool IsSupportMessage()
		{
			return this.bool_2;
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000059BC File Offset: 0x00003BBC
		public void SetSupportMessage(bool value)
		{
			this.bool_2 = value;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000059C5 File Offset: 0x00003BC5
		public bool IsClaimed()
		{
			return this.bool_3;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x000059CD File Offset: 0x00003BCD
		public void SetClaimed(bool value)
		{
			this.bool_3 = value;
		}

		// Token: 0x04000246 RID: 582
		private string string_1;

		// Token: 0x04000247 RID: 583
		private string string_2;

		// Token: 0x04000248 RID: 584
		private string string_3;

		// Token: 0x04000249 RID: 585
		private string string_4;

		// Token: 0x0400024A RID: 586
		private string string_5;

		// Token: 0x0400024B RID: 587
		private int int_3;

		// Token: 0x0400024C RID: 588
		private bool bool_2;

		// Token: 0x0400024D RID: 589
		private bool bool_3;
	}
}
