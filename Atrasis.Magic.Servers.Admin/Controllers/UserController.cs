using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Debug;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Admin.Helper;
using Atrasis.Magic.Servers.Admin.Logic;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Controllers
{
	// Token: 0x0200001A RID: 26
	[Route("api/[controller]")]
	[Produces("application/json", new string[]
	{

	})]
	public class UserController : Controller
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00003E5C File Offset: 0x0000205C
		[HttpPost("sendAdminMessageToUsers")]
		public async Task<JObject> SendAdminMessageToUsers([FromBody] UserController.AdminMessageRequest result)
		{
			StringValues values;
			bool flag;
			SessionEntry sessionEntry2;
			if (!(flag = !base.Request.Headers.TryGetValue("token", out values)))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				flag = ((sessionEntry2 = sessionEntry) == null);
			}
			JObject result2;
			if (flag)
			{
				result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanExecuteAdminCommand)
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else if (result.Title != null && result.Content != null)
				{
					AdminMessageAvatarStreamEntry adminMessageAvatarStreamEntry = new AdminMessageAvatarStreamEntry();
					adminMessageAvatarStreamEntry.SetSenderName("Atrasis - Admin");
					adminMessageAvatarStreamEntry.SetTitleTID(result.Title);
					adminMessageAvatarStreamEntry.SetDescriptionTID(result.Content);
					adminMessageAvatarStreamEntry.SetButtonTID(result.Button);
					adminMessageAvatarStreamEntry.SetUrlLink(result.Url);
					adminMessageAvatarStreamEntry.SetDiamondCount(result.DiamondCount);
					int[] higherId = ServerAdmin.GameDatabase.GetCounterHigherIDs();
					int[] serverSentCount = new int[Atrasis.Magic.Servers.Core.Network.ServerManager.GetServerCount(9)];
					for (int i = 0; i < higherId.Length; i++)
					{
						int j = 1;
						int count = higherId[i];
						while (j <= count)
						{
							LogicLong id = new LogicLong(i, j);
							ServerSocket socket = Atrasis.Magic.Servers.Core.Network.ServerManager.GetDocumentSocket(9, id);
							if (serverSentCount[socket.ServerId] % 1000 == 0)
							{
								TaskAwaiter taskAwaiter = Task.Delay(50).GetAwaiter();
								if (!taskAwaiter.IsCompleted)
								{
									await taskAwaiter;
									TaskAwaiter taskAwaiter2;
									taskAwaiter = taskAwaiter2;
									taskAwaiter2 = default(TaskAwaiter);
								}
								taskAwaiter.GetResult();
							}
							serverSentCount[socket.ServerId]++;
							ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
							{
								AccountId = id,
								Entry = adminMessageAvatarStreamEntry
							}, socket);
							id = null;
							socket = null;
							j++;
						}
					}
					result2 = this.BuildResponse(HttpStatusCode.OK);
				}
				else
				{
					result2 = this.BuildResponse(HttpStatusCode.Forbidden);
				}
			}
			return result2;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003EAC File Offset: 0x000020AC
		[HttpPost("search")]
		public async Task<JObject> Search([FromBody] UserController.UserSearchRequest request)
		{
			StringValues values;
			bool flag;
			SessionEntry sessionEntry2;
			if (!(flag = !base.Request.Headers.TryGetValue("token", out values)))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				flag = ((sessionEntry2 = sessionEntry) == null);
			}
			JObject result;
			if (flag)
			{
				result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanOpenUsersPage)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else
				{
					JArray jarray = await UserManager.Search(request.Name, request.Level, request.Score, request.AllianceName);
					if (jarray == null)
					{
						result = this.BuildResponse(HttpStatusCode.InternalServerError);
					}
					else
					{
						result = this.BuildResponse(HttpStatusCode.OK).AddAttribute("result", jarray);
					}
				}
			}
			return result;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003EFC File Offset: 0x000020FC
		[HttpGet("{id}")]
		public async Task<JObject> Get(long id, [FromQuery(Name = "pass")] string passToken)
		{
			bool canOpenUserProfilePage = false;
			bool canExecuteAdminCommand = false;
			bool canExecuteDebugCommand = false;
			StringValues values;
			if (base.Request.Headers.TryGetValue("token", out values))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				SessionEntry sessionEntry2;
				if ((sessionEntry2 = sessionEntry) == null)
				{
					return this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
				}
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				canOpenUserProfilePage = userEntry.CanOpenUserProfilePage;
				canExecuteAdminCommand = userEntry.CanExecuteAdminCommand;
				canExecuteDebugCommand = userEntry.CanExecuteDebugCommand;
			}
			Task<AccountDocument> account = UserManager.GetAccount(id);
			Task<GameDocument> taskDocument = UserManager.GetAvatar(id);
			AccountDocument accountDocument = await account;
			GameDocument gameDocument = await taskDocument;
			JObject result;
			if (accountDocument != null && gameDocument != null)
			{
				if (!canOpenUserProfilePage && passToken != accountDocument.PassToken)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden);
				}
				else
				{
					TaskAwaiter<bool> taskAwaiter = ServerAdmin.SessionDatabase.Exists(id).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<bool> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
					}
					bool result2 = taskAwaiter.GetResult();
					JObject jobject = this.BuildResponse(HttpStatusCode.OK).AddAttribute("online", result2);
					JObject jobject2 = new JObject();
					if (canOpenUserProfilePage)
					{
						jobject2.Add("id", accountDocument.Id);
						jobject2.Add("passToken", accountDocument.PassToken);
					}
					jobject2.Add("status", accountDocument.State.ToString());
					if (accountDocument.StateArg != null)
					{
						AccountState state = accountDocument.State;
						if (state != AccountState.LOCKED)
						{
							if (state == AccountState.BANNED)
							{
								jobject2.Add("reason", accountDocument.StateArg);
							}
						}
						else
						{
							jobject2.Add("unlockCode", accountDocument.StateArg);
						}
					}
					jobject2.Add("rank", accountDocument.Rank.ToString());
					jobject2.Add("country", accountDocument.Country);
					jobject2.Add("createTime", TimeUtil.GetDateTimeFromTimestamp(accountDocument.CreateTime).ToString("F"));
					jobject2.Add("lastSessionTime", TimeUtil.GetDateTimeFromTimestamp(accountDocument.LastSessionTime).ToString("F"));
					jobject2.Add("playTimeSecs", UserController.GetSecondsToTime(accountDocument.PlayTimeSeconds + (result2 ? ((int)DateTime.UtcNow.Subtract(TimeUtil.GetDateTimeFromTimestamp(accountDocument.LastSessionTime)).TotalSeconds) : 0)));
					jobject.Add("account", jobject2);
					jobject.Add("avatar", new JObject
					{
						{
							"name",
							gameDocument.LogicClientAvatar.GetName()
						},
						{
							"nameChanged",
							gameDocument.LogicClientAvatar.GetNameChangeState() >= 1
						},
						{
							"diamonds",
							gameDocument.LogicClientAvatar.GetDiamonds()
						},
						{
							"lvl",
							gameDocument.LogicClientAvatar.GetExpLevel()
						}
					});
					if (gameDocument.LogicClientAvatar.IsInAlliance())
					{
						JObject jobject3 = new JObject();
						jobject3.Add("name", gameDocument.LogicClientAvatar.GetAllianceName());
						jobject3.Add("badgeId", gameDocument.LogicClientAvatar.GetAllianceBadgeId());
						jobject3.Add("lvl", gameDocument.LogicClientAvatar.GetAllianceLevel());
						switch (gameDocument.LogicClientAvatar.GetAllianceRole())
						{
						case LogicAvatarAllianceRole.MEMBER:
							jobject3.Add("role", "Member");
							break;
						case LogicAvatarAllianceRole.LEADER:
							jobject3.Add("role", "Leader");
							break;
						case LogicAvatarAllianceRole.ELDER:
							jobject3.Add("role", "Elder");
							break;
						case LogicAvatarAllianceRole.CO_LEADER:
							jobject3.Add("role", "Co Leader");
							break;
						}
						jobject.Add("alliance", jobject3);
					}
					if (result2)
					{
						jobject.Add("op-cmd", new JArray
						{
							0,
							1,
							2,
							3,
							4,
							5
						});
						if (canExecuteDebugCommand)
						{
							jobject.Add("debug-cmd", new JArray
							{
								9,
								0,
								1,
								34,
								43,
								46,
								49,
								50,
								30,
								2,
								45,
								12,
								16,
								20,
								13,
								23,
								31,
								44,
								6,
								51,
								26,
								40,
								29,
								8,
								10,
								11,
								17,
								18,
								41,
								42,
								25,
								4,
								35,
								39,
								55,
								47,
								3,
								27,
								14,
								28,
								24,
								7,
								15,
								48,
								53,
								5,
								19,
								22,
								21,
								32,
								33,
								36
							});
						}
					}
					if (canExecuteAdminCommand)
					{
						JArray jarray = new JArray();
						switch (accountDocument.State)
						{
						case AccountState.NORMAL:
							jarray.Add(0);
							jarray.Add(1);
							break;
						case AccountState.LOCKED:
							jarray.Add(2);
							break;
						case AccountState.BANNED:
							jarray.Add(3);
							break;
						}
						jarray.Add(4);
						jarray.Add(6);
						if (result2)
						{
							jarray.Add(5);
						}
						jobject.Add("administration-cmd", jarray);
					}
					result = jobject;
				}
			}
			else
			{
				result = this.BuildResponse(HttpStatusCode.InternalServerError);
			}
			return result;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003F54 File Offset: 0x00002154
		[HttpPost("commands/admin/{id}")]
		public async Task<JObject> ExecuteAdministrationCommand(int id, [FromQuery(Name = "userId")] long accountId, [FromBody] UserController.AdministrationCommandRequest administrationCommand)
		{
			StringValues values;
			bool flag;
			SessionEntry sessionEntry2;
			if (!(flag = !base.Request.Headers.TryGetValue("token", out values)))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				flag = ((sessionEntry2 = sessionEntry) == null);
			}
			JObject result;
			if (flag)
			{
				result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanExecuteAdminCommand)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else
				{
					AccountDocument accountDocument = await UserManager.GetAccount(accountId);
					if (accountDocument == null)
					{
						result = this.BuildResponse(HttpStatusCode.InternalServerError);
					}
					else
					{
						switch (id)
						{
						case 0:
							if (accountDocument.State == AccountState.NORMAL)
							{
								accountDocument.State = AccountState.BANNED;
								accountDocument.StateArg = administrationCommand.GetArg<string>("reason");
								UserManager.SaveAccount(accountDocument);
								this.Disconnect(accountId);
								return this.BuildResponse(HttpStatusCode.OK);
							}
							break;
						case 1:
							if (accountDocument.State == AccountState.NORMAL)
							{
								char[] array = new char[12];
								for (int i = 0; i < 12; i++)
								{
									array[i] = "abcdefghijklmnopqrstuvwxyz0123456789"[ServerCore.Random.Rand("abcdefghijklmnopqrstuvwxyz0123456789".Length)];
								}
								string text = new string(array);
								accountDocument.State = AccountState.LOCKED;
								accountDocument.StateArg = text;
								UserManager.SaveAccount(accountDocument);
								this.Disconnect(accountId);
								return this.BuildResponse(HttpStatusCode.OK).AddAttribute("code", text);
							}
							break;
						case 2:
							if (accountDocument.State == AccountState.LOCKED)
							{
								accountDocument.State = AccountState.NORMAL;
								accountDocument.StateArg = null;
								UserManager.SaveAccount(accountDocument);
								return this.BuildResponse(HttpStatusCode.OK);
							}
							break;
						case 3:
							if (accountDocument.State == AccountState.BANNED)
							{
								accountDocument.State = AccountState.NORMAL;
								accountDocument.StateArg = null;
								UserManager.SaveAccount(accountDocument);
								return this.BuildResponse(HttpStatusCode.OK);
							}
							break;
						case 4:
						{
							int num = (int)administrationCommand.GetArg<long>("rank");
							if (num >= 0 && num <= 2 && accountDocument.Rank != (AccountRankingType)num)
							{
								accountDocument.Rank = (AccountRankingType)num;
								UserManager.SaveAccount(accountDocument);
								this.Disconnect(accountId);
								return this.BuildResponse(HttpStatusCode.OK);
							}
							break;
						}
						case 5:
							this.Disconnect(accountId);
							return this.BuildResponse(HttpStatusCode.OK);
						case 6:
						{
							string arg = administrationCommand.GetArg<string>("title");
							string arg2 = administrationCommand.GetArg<string>("content");
							string arg3 = administrationCommand.GetArg<string>("button");
							string arg4 = administrationCommand.GetArg<string>("url");
							int diamondCount = (int)administrationCommand.GetArg<long>("diamonds");
							if (arg != null && arg2 != null)
							{
								AdminMessageAvatarStreamEntry adminMessageAvatarStreamEntry = new AdminMessageAvatarStreamEntry();
								adminMessageAvatarStreamEntry.SetSenderName("Atrasis - Admin");
								adminMessageAvatarStreamEntry.SetTitleTID(arg);
								adminMessageAvatarStreamEntry.SetDescriptionTID(arg2);
								adminMessageAvatarStreamEntry.SetButtonTID(arg3);
								adminMessageAvatarStreamEntry.SetUrlLink(arg4);
								adminMessageAvatarStreamEntry.SetDiamondCount(diamondCount);
								ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
								{
									AccountId = accountId,
									Entry = adminMessageAvatarStreamEntry
								}, 9);
								return this.BuildResponse(HttpStatusCode.OK);
							}
							break;
						}
						}
						result = this.BuildResponse(HttpStatusCode.InternalServerError);
					}
				}
			}
			return result;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003FB4 File Offset: 0x000021B4
		private async void Disconnect(long id)
		{
			RedisValue redisValue = await ServerAdmin.SessionDatabase.Get(id);
			RedisValue value = redisValue;
			if (!value.IsNull)
			{
				long sessionId = long.Parse(value);
				ServerMessageManager.SendMessage(new StopSessionMessage
				{
					SessionId = sessionId
				}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003FF0 File Offset: 0x000021F0
		[HttpPost("commands/op/{id}")]
		public async Task<JObject> ExecuteOPCommand(int id, [FromQuery(Name = "userId")] long accountId, [FromQuery(Name = "pass")] string passToken, [FromBody] JObject args)
		{
			bool canExecuteAdminCommand = false;
			StringValues values;
			if (base.Request.Headers.TryGetValue("token", out values))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				SessionEntry sessionEntry2;
				if ((sessionEntry2 = sessionEntry) == null)
				{
					return this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
				}
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				canExecuteAdminCommand = userEntry.CanExecuteAdminCommand;
			}
			AccountDocument accountDocument = await UserManager.GetAccount(accountId);
			JObject result;
			if (accountDocument == null)
			{
				result = this.BuildResponse(HttpStatusCode.InternalServerError);
			}
			else if (!canExecuteAdminCommand && passToken != accountDocument.PassToken)
			{
				result = this.BuildResponse(HttpStatusCode.Forbidden);
			}
			else
			{
				RedisValue value = await ServerAdmin.SessionDatabase.Get(accountDocument.Id);
				if (value.IsNull)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "No client connected.");
				}
				else
				{
					long sessionId = long.Parse(value);
					switch (id)
					{
					case 0:
					{
						LogicGameObjectData logicGameObjectData = null;
						JToken value2;
						if (args.TryGetValue("objectName", out value2) && ((string)value2).Length > 0)
						{
							logicGameObjectData = LogicDataTables.GetBuildingByName((string)value2, null);
							if (logicGameObjectData == null)
							{
								logicGameObjectData = (LogicGameObjectData)LogicDataTables.GetTable(LogicDataType.TRAP).GetDataByName((string)value2, null);
								if (logicGameObjectData == null)
								{
									return this.BuildResponse(HttpStatusCode.NotFound).AddAttribute("reason", "Unknown object name");
								}
							}
						}
						ServerMessageManager.SendMessage(new GameStartFakeAttackMessage
						{
							SessionId = sessionId,
							ArgData = logicGameObjectData
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetDocumentSocket(9, accountId));
						break;
					}
					case 1:
						ServerMessageManager.SendMessage(new GameStartFakeAttackMessage
						{
							AccountId = accountId,
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetDocumentSocket(9, accountId));
						break;
					case 2:
					{
						AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
						availableServerCommandMessage.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.UPGRADE_ALL_BUILDINGS));
						availableServerCommandMessage.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage.GetMessageType(),
							MessageLength = availableServerCommandMessage.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 3:
					{
						AvailableServerCommandMessage availableServerCommandMessage2 = new AvailableServerCommandMessage();
						availableServerCommandMessage2.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.REMOVE_OBSTACLES));
						availableServerCommandMessage2.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage2.GetMessageType(),
							MessageLength = availableServerCommandMessage2.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage2.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage2.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 4:
					{
						AvailableServerCommandMessage availableServerCommandMessage3 = new AvailableServerCommandMessage();
						availableServerCommandMessage3.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.SET_MAX_UNIT_SPELL_LEVELS));
						availableServerCommandMessage3.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage3.GetMessageType(),
							MessageLength = availableServerCommandMessage3.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage3.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage3.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 5:
					{
						AvailableServerCommandMessage availableServerCommandMessage4 = new AvailableServerCommandMessage();
						availableServerCommandMessage4.SetServerCommand(new LogicDebugCommand(LogicDebugActionType.SET_MAX_HERO_LEVELS));
						availableServerCommandMessage4.Encode();
						ServerMessageManager.SendMessage(new ForwardLogicMessage
						{
							MessageType = availableServerCommandMessage4.GetMessageType(),
							MessageLength = availableServerCommandMessage4.GetEncodingLength(),
							MessageVersion = (short)availableServerCommandMessage4.GetMessageVersion(),
							MessageBytes = availableServerCommandMessage4.GetByteStream().GetByteArray(),
							SessionId = sessionId
						}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
						break;
					}
					case 6:
					{
						GameDocument gameDocument = await UserManager.GetAvatar(accountId);
						if (gameDocument != null)
						{
							LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
							LogicCharacterData logicCharacterData = null;
							int num = 0;
							JToken value3;
							if (args.TryGetValue("objectName", out value3) && ((string)value3).Length > 0)
							{
								logicCharacterData = (LogicCharacterData)table.GetDataByName((string)value3, null);
								if (logicCharacterData != null)
								{
									if (!logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop())
									{
										num = gameDocument.LogicClientAvatar.GetAllianceCastleFreeCapacity() / logicCharacterData.GetHousingSpace();
										if (num == 0)
										{
											logicCharacterData = null;
										}
									}
									else
									{
										logicCharacterData = null;
									}
								}
							}
							if (logicCharacterData == null)
							{
								for (int i = 0; i < 10; i++)
								{
									logicCharacterData = (LogicCharacterData)table.GetItemAt(ServerCore.Random.Rand(table.GetItemCount()));
									if (logicCharacterData.IsEnabledInVillageType(1) && !logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop())
									{
										num = gameDocument.LogicClientAvatar.GetAllianceCastleFreeCapacity() / logicCharacterData.GetHousingSpace();
										if (num != 0)
										{
											break;
										}
									}
								}
							}
							if (logicCharacterData != null)
							{
								for (int j = 0; j < num; j++)
								{
									LogicAllianceUnitReceivedCommand logicAllianceUnitReceivedCommand = new LogicAllianceUnitReceivedCommand();
									logicAllianceUnitReceivedCommand.SetData("Atrasis - Bot", logicCharacterData, logicCharacterData.GetUpgradeLevelCount() - 1);
									ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
									{
										AccountId = accountId,
										ServerCommand = logicAllianceUnitReceivedCommand
									}, 9);
								}
							}
						}
						break;
					}
					}
					result = this.BuildResponse(HttpStatusCode.OK);
				}
			}
			return result;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004058 File Offset: 0x00002258
		[HttpPost("commands/debug/{id}")]
		public async Task<JObject> ExecuteDebugCommand(int id, [FromQuery(Name = "userId")] long accountId, [FromQuery(Name = "pass")] string passToken)
		{
			StringValues values;
			bool flag;
			SessionEntry sessionEntry2;
			if (!(flag = !base.Request.Headers.TryGetValue("token", out values)))
			{
				SessionEntry sessionEntry = await AuthManager.GetSession(values);
				flag = ((sessionEntry2 = sessionEntry) == null);
			}
			JObject result;
			if (flag)
			{
				result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "invalid token");
			}
			else
			{
				UserEntry userEntry = await AuthManager.GetUser(sessionEntry2.User);
				if (!userEntry.CanExecuteDebugCommand)
				{
					result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "wrong privileges");
				}
				else
				{
					AccountDocument accountDocument = await UserManager.GetAccount(accountId);
					if (accountDocument == null)
					{
						result = this.BuildResponse(HttpStatusCode.InternalServerError);
					}
					else
					{
						RedisValue value = await ServerAdmin.SessionDatabase.Get(accountDocument.Id);
						if (value.IsNull)
						{
							result = this.BuildResponse(HttpStatusCode.Forbidden).AddAttribute("reason", "No client connected.");
						}
						else
						{
							LogicDebugCommand logicDebugCommand = null;
							switch (id)
							{
							case 0:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.FAST_FORWARD_1_HOUR);
								break;
							case 1:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.FAST_FORWARD_24_HOUR);
								break;
							case 2:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_UNITS);
								break;
							case 3:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_RESOURCES);
								break;
							case 4:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.INCREASE_XP_LEVEL);
								break;
							case 5:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_ALL_BUILDINGS);
								break;
							case 6:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COMPLETE_TUTORIAL);
								break;
							case 7:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UNLOCK_MAP);
								break;
							case 8:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SHIELD_TO_HALF);
								break;
							case 9:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.FAST_FORWARD_1_MIN);
								break;
							case 10:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.INCREASE_TROPHIES);
								break;
							case 11:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.DECREASE_TROPHIES);
								break;
							case 12:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_ALLIANCE_UNITS);
								break;
							case 13:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.INCREASE_HERO_LEVELS);
								break;
							case 14:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_RESOURCES);
								break;
							case 15:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_MAP_PROGRESS);
								break;
							case 16:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.DEPLOY_ALL_TROOPS);
								break;
							case 17:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_100_TROPHIES);
								break;
							case 18:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_100_TROPHIES);
								break;
							case 19:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_TO_MAX_FOR_TH);
								break;
							case 20:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_UNITS);
								break;
							case 21:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.DISARM_TRAPS);
								break;
							case 22:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_OBSTACLES);
								break;
							case 23:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_HERO_LEVELS);
								break;
							case 24:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COLLECT_WAR_RESOURCES);
								break;
							case 25:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SET_RANDOM_TROPHIES);
								break;
							case 26:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COMPLETE_WAR_TUTORIAL);
								break;
							case 27:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_WAR_RESOURCES);
								break;
							case 28:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_WAR_RESOURCES);
								break;
							case 29:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_WAR_TUTORIAL);
								break;
							case 30:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_UNIT);
								break;
							case 31:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SET_MAX_UNIT_SPELL_LEVELS);
								break;
							case 32:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_ALL_AMMO);
								break;
							case 33:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_ALL_LAYOUTS);
								break;
							case 34:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.LOCK_CLAN_CASTLE);
								break;
							case 35:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RANDOM_RESOURCES_TROPHY_XP);
								break;
							case 36:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.LOAD_LEVEL);
								logicDebugCommand.SetDebugString(UserManager.GetPresetLevel());
								break;
							case 37:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_BUILDING);
								break;
							case 38:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UPGRADE_BUILDINGS);
								break;
							case 39:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_1000_CLAN_XP);
								break;
							case 40:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RESET_ALL_TUTORIALS);
								break;
							case 41:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_1000_TROPHIES);
								break;
							case 42:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.REMOVE_1000_TROPHIES);
								break;
							case 43:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.CAUSE_DAMAGE);
								break;
							case 44:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.SET_MAX_HERO_LEVELS);
								break;
							case 45:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_PRESET_TROOPS);
								break;
							case 46:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.TOGGLE_INVULNERABILITY);
								break;
							case 47:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_GEMS);
								break;
							case 48:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.PAUSE_ALL_BOOSTS);
								break;
							case 49:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.TRAVEL);
								break;
							case 50:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.TOGGLE_RED);
								break;
							case 51:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.COMPLETE_HOME_TUTORIALS);
								break;
							case 52:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.UNLOCK_SHIPYARD);
								break;
							case 53:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.GIVE_REENGAGEMENT_LOOT_FOR_30_DAYS);
								break;
							case 54:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.ADD_FREE_UNITS);
								break;
							case 55:
								logicDebugCommand = new LogicDebugCommand(LogicDebugActionType.RANDOM_ALLIANCE_EXP_LEVEL);
								break;
							}
							if (logicDebugCommand == null)
							{
								result = this.BuildResponse(HttpStatusCode.InternalServerError);
							}
							else
							{
								long sessionId = long.Parse(value);
								AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
								availableServerCommandMessage.SetServerCommand(logicDebugCommand);
								availableServerCommandMessage.Encode();
								ServerMessageManager.SendMessage(new ForwardLogicMessage
								{
									MessageType = availableServerCommandMessage.GetMessageType(),
									MessageLength = availableServerCommandMessage.GetEncodingLength(),
									MessageVersion = (short)availableServerCommandMessage.GetMessageVersion(),
									MessageBytes = availableServerCommandMessage.GetByteStream().GetByteArray(),
									SessionId = sessionId
								}, Atrasis.Magic.Servers.Core.Network.ServerManager.GetProxySocket(sessionId));
								result = this.BuildResponse(HttpStatusCode.OK);
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000040B0 File Offset: 0x000022B0
		[HttpGet("commands/debug/{id}/info")]
		public JObject GetOPCommandInfo(int id)
		{
			if (id == 0)
			{
				JArray jarray = new JArray();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicBuildingData logicBuildingData = (LogicBuildingData)table.GetItemAt(i);
					if (!logicBuildingData.IsAllianceCastle() && !logicBuildingData.IsTownHall() && !logicBuildingData.IsTownHallVillage2() && logicBuildingData.IsEnabledInVillageType(0) && !logicBuildingData.IsEnableByCalendar())
					{
						jarray.Add(logicBuildingData.GetName());
					}
				}
				for (int j = 0; j < table2.GetItemCount(); j++)
				{
					LogicTrapData logicTrapData = (LogicTrapData)table2.GetItemAt(j);
					if (logicTrapData.IsEnabledInVillageType(0) && !logicTrapData.IsEnableByCalendar() && logicTrapData.GetSpawnedCharAir() == null && logicTrapData.GetSpawnedCharGround() == null)
					{
						jarray.Add(logicTrapData.GetName());
					}
				}
				return this.BuildResponse(HttpStatusCode.OK).AddAttribute("objects", jarray);
			}
			if (id != 6)
			{
				return this.BuildResponse(HttpStatusCode.NotFound);
			}
			JArray jarray2 = new JArray();
			LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			for (int k = 0; k < table3.GetItemCount(); k++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table3.GetItemAt(k);
				if (logicCharacterData.IsEnabledInVillageType(0) && !logicCharacterData.IsDonationDisabled() && !logicCharacterData.IsSecondaryTroop())
				{
					jarray2.Add(logicCharacterData.GetName());
				}
			}
			return this.BuildResponse(HttpStatusCode.OK).AddAttribute("objects", jarray2);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000423C File Offset: 0x0000243C
		private static string GetSecondsToTime(int secs)
		{
			if (secs < 60)
			{
				return string.Format("{0}secs", secs);
			}
			if (secs < 3600)
			{
				return string.Format("{0}mn {1}secs", secs / 60, secs % 60);
			}
			if (secs < 86400)
			{
				return string.Format("{0}h {1}mn {2}secs", secs / 3600, secs % 3600 / 60, secs % 3600 % 60);
			}
			if (secs >= 31536000)
			{
				return string.Format("{0}y {1}d {2}h {3}mn {4}secs", new object[]
				{
					secs / 31536000,
					secs % 31536000 / 86400,
					secs % 31536000 % 86400 / 3600,
					secs % 31536000 % 86400 % 3600 / 60,
					secs % 31536000 % 86400 % 3600 % 60
				});
			}
			return string.Format("{0}d {1}h {2}mn {3}secs", new object[]
			{
				secs / 86400,
				secs % 86400 / 3600,
				secs % 86400 % 3600 / 60,
				secs % 86400 % 3600 % 60
			});
		}

		// Token: 0x02000032 RID: 50
		public class UserSearchRequest
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000D3 RID: 211 RVA: 0x000026BC File Offset: 0x000008BC
			// (set) Token: 0x060000D4 RID: 212 RVA: 0x000026C4 File Offset: 0x000008C4
			public string Name { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000D5 RID: 213 RVA: 0x000026CD File Offset: 0x000008CD
			// (set) Token: 0x060000D6 RID: 214 RVA: 0x000026D5 File Offset: 0x000008D5
			public int Level { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000D7 RID: 215 RVA: 0x000026DE File Offset: 0x000008DE
			// (set) Token: 0x060000D8 RID: 216 RVA: 0x000026E6 File Offset: 0x000008E6
			public int Score { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000D9 RID: 217 RVA: 0x000026EF File Offset: 0x000008EF
			// (set) Token: 0x060000DA RID: 218 RVA: 0x000026F7 File Offset: 0x000008F7
			public string AllianceName { get; set; }
		}

		// Token: 0x02000033 RID: 51
		public class AdminMessageRequest
		{
			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000DC RID: 220 RVA: 0x00002700 File Offset: 0x00000900
			// (set) Token: 0x060000DD RID: 221 RVA: 0x00002708 File Offset: 0x00000908
			public string Title { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060000DE RID: 222 RVA: 0x00002711 File Offset: 0x00000911
			// (set) Token: 0x060000DF RID: 223 RVA: 0x00002719 File Offset: 0x00000919
			public string Content { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060000E0 RID: 224 RVA: 0x00002722 File Offset: 0x00000922
			// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000272A File Offset: 0x0000092A
			public string Button { get; set; }

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x060000E2 RID: 226 RVA: 0x00002733 File Offset: 0x00000933
			// (set) Token: 0x060000E3 RID: 227 RVA: 0x0000273B File Offset: 0x0000093B
			public string Url { get; set; }

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060000E4 RID: 228 RVA: 0x00002744 File Offset: 0x00000944
			// (set) Token: 0x060000E5 RID: 229 RVA: 0x0000274C File Offset: 0x0000094C
			public int DiamondCount { get; set; }
		}

		// Token: 0x02000034 RID: 52
		public class AdministrationCommandRequest
		{
			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060000E7 RID: 231 RVA: 0x00002755 File Offset: 0x00000955
			// (set) Token: 0x060000E8 RID: 232 RVA: 0x0000275D File Offset: 0x0000095D
			public UserController.AdministrationCommandRequest.AdministrationCommandArgEntry[] Args { get; set; }

			// Token: 0x060000E9 RID: 233 RVA: 0x000062E0 File Offset: 0x000044E0
			public T GetArg<T>(string name)
			{
				if (this.Args != null)
				{
					for (int i = 0; i < this.Args.Length; i++)
					{
						if (this.Args[i].Name == name)
						{
							return (T)((object)this.Args[i].Value);
						}
					}
				}
				return default(T);
			}

			// Token: 0x0200003F RID: 63
			public class AdministrationCommandArgEntry
			{
				// Token: 0x17000038 RID: 56
				// (get) Token: 0x060000F9 RID: 249 RVA: 0x000027C8 File Offset: 0x000009C8
				// (set) Token: 0x060000FA RID: 250 RVA: 0x000027D0 File Offset: 0x000009D0
				public string Name { get; set; }

				// Token: 0x17000039 RID: 57
				// (get) Token: 0x060000FB RID: 251 RVA: 0x000027D9 File Offset: 0x000009D9
				// (set) Token: 0x060000FC RID: 252 RVA: 0x000027E1 File Offset: 0x000009E1
				public object Value { get; set; }
			}
		}

		// Token: 0x02000035 RID: 53
		public enum OpCommandType
		{
			// Token: 0x040000AF RID: 175
			ATTACK_GENERATED_VILLAGE,
			// Token: 0x040000B0 RID: 176
			ATTACK_MY_VILLAGE,
			// Token: 0x040000B1 RID: 177
			UPGRADE_VILLAGE,
			// Token: 0x040000B2 RID: 178
			REMOVE_OBSTACLE,
			// Token: 0x040000B3 RID: 179
			UNIT_MAX,
			// Token: 0x040000B4 RID: 180
			HERO_MAX,
			// Token: 0x040000B5 RID: 181
			ADD_CASTLE_UNITS
		}

		// Token: 0x02000036 RID: 54
		public enum DebugCommandType
		{
			// Token: 0x040000B7 RID: 183
			FAST_FORWARD_1_HOUR,
			// Token: 0x040000B8 RID: 184
			FAST_FORWARD_24_HOUR,
			// Token: 0x040000B9 RID: 185
			ADD_UNITS,
			// Token: 0x040000BA RID: 186
			ADD_RESOURCES,
			// Token: 0x040000BB RID: 187
			INCREASE_XP_LEVEL,
			// Token: 0x040000BC RID: 188
			UPGRADE_ALL_BUILDINGS,
			// Token: 0x040000BD RID: 189
			COMPLETE_TUTORIAL,
			// Token: 0x040000BE RID: 190
			UNLOCK_MAP,
			// Token: 0x040000BF RID: 191
			SHIELD_TO_HALF,
			// Token: 0x040000C0 RID: 192
			FAST_FORWARD_1_MIN,
			// Token: 0x040000C1 RID: 193
			INCREASE_TROPHIES,
			// Token: 0x040000C2 RID: 194
			DECREASE_TROPHIES,
			// Token: 0x040000C3 RID: 195
			ADD_ALLIANCE_UNITS,
			// Token: 0x040000C4 RID: 196
			INCREASE_HERO_LEVELS,
			// Token: 0x040000C5 RID: 197
			REMOVE_RESOURCES,
			// Token: 0x040000C6 RID: 198
			RESET_MAP_PROGRESS,
			// Token: 0x040000C7 RID: 199
			DEPLOY_ALL_TROOPS,
			// Token: 0x040000C8 RID: 200
			ADD_100_TROPHIES,
			// Token: 0x040000C9 RID: 201
			REMOVE_100_TROPHIES,
			// Token: 0x040000CA RID: 202
			UPGRADE_TO_MAX_FOR_TH,
			// Token: 0x040000CB RID: 203
			REMOVE_UNITS,
			// Token: 0x040000CC RID: 204
			DISARM_TRAPS,
			// Token: 0x040000CD RID: 205
			REMOVE_OBSTACLES,
			// Token: 0x040000CE RID: 206
			RESET_HERO_LEVELS,
			// Token: 0x040000CF RID: 207
			COLLECT_WAR_RESOURCES,
			// Token: 0x040000D0 RID: 208
			SET_RANDOM_TROPHIES,
			// Token: 0x040000D1 RID: 209
			COMPLETE_WAR_TUTORIAL,
			// Token: 0x040000D2 RID: 210
			ADD_WAR_RESOURCES,
			// Token: 0x040000D3 RID: 211
			REMOVE_WAR_RESOURCES,
			// Token: 0x040000D4 RID: 212
			RESET_WAR_TUTORIAL,
			// Token: 0x040000D5 RID: 213
			ADD_UNIT,
			// Token: 0x040000D6 RID: 214
			SET_MAX_UNIT_SPELL_LEVELS,
			// Token: 0x040000D7 RID: 215
			REMOVE_ALL_AMMO,
			// Token: 0x040000D8 RID: 216
			RESET_ALL_LAYOUTS,
			// Token: 0x040000D9 RID: 217
			LOCK_CLAN_CASTLE,
			// Token: 0x040000DA RID: 218
			RANDOM_RESOURCES_TROPHY_XP,
			// Token: 0x040000DB RID: 219
			LOAD_LEVEL,
			// Token: 0x040000DC RID: 220
			UPGRADE_BUILDING,
			// Token: 0x040000DD RID: 221
			UPGRADE_BUILDINGS,
			// Token: 0x040000DE RID: 222
			ADD_1000_CLAN_XP,
			// Token: 0x040000DF RID: 223
			RESET_ALL_TUTORIALS,
			// Token: 0x040000E0 RID: 224
			ADD_1000_TROPHIES,
			// Token: 0x040000E1 RID: 225
			REMOVE_1000_TROPHIES,
			// Token: 0x040000E2 RID: 226
			CAUSE_DAMAGE,
			// Token: 0x040000E3 RID: 227
			SET_MAX_HERO_LEVELS,
			// Token: 0x040000E4 RID: 228
			ADD_PRESET_TROOPS,
			// Token: 0x040000E5 RID: 229
			TOGGLE_INVULNERABILITY,
			// Token: 0x040000E6 RID: 230
			ADD_GEMS,
			// Token: 0x040000E7 RID: 231
			PAUSE_ALL_BOOSTS,
			// Token: 0x040000E8 RID: 232
			TRAVEL,
			// Token: 0x040000E9 RID: 233
			TOGGLE_RED,
			// Token: 0x040000EA RID: 234
			COMPLETE_HOME_TUTORIALS,
			// Token: 0x040000EB RID: 235
			UNLOCK_SHIPYARD,
			// Token: 0x040000EC RID: 236
			GIVE_REENGAGEMENT_LOOT_FOR_30_DAYS,
			// Token: 0x040000ED RID: 237
			ADD_FREE_UNITS,
			// Token: 0x040000EE RID: 238
			RANDOM_ALLIANCE_EXP_LEVEL
		}

		// Token: 0x02000037 RID: 55
		public enum AdminCommandType
		{
			// Token: 0x040000F0 RID: 240
			BAN_ACCOUNT,
			// Token: 0x040000F1 RID: 241
			LOCK_ACCOUNT,
			// Token: 0x040000F2 RID: 242
			UNLOCK_ACCOUNT,
			// Token: 0x040000F3 RID: 243
			UNBAN_ACCOUNT,
			// Token: 0x040000F4 RID: 244
			CHANGE_RANK,
			// Token: 0x040000F5 RID: 245
			DISCONNECT,
			// Token: 0x040000F6 RID: 246
			SEND_ADMIN_MESSAGE
		}
	}
}
