using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Atrasis.Magic.Servers.Admin.Helper
{
	// Token: 0x02000014 RID: 20
	public static class ResponseBuilder
	{
		// Token: 0x06000085 RID: 133 RVA: 0x00003994 File Offset: 0x00001B94
		public static JObject BuildResponse(this Controller controller, HttpStatusCode successCode)
		{
			JObject jobject = new JObject();
			jobject.Add("success", (int)successCode);
			controller.Response.StatusCode = (int)successCode;
			return jobject;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000254C File Offset: 0x0000074C
		public static JObject AddAttribute(this JObject obj, string attribute, JToken content)
		{
			obj.Add(attribute, content);
			return obj;
		}
	}
}
