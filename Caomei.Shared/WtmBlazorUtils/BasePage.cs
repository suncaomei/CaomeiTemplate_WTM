using BootstrapBlazor.Components;
using Caomei.Core;
using Caomei.Core.Extensions;
using Caomei.Core.Support.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WtmBlazorUtils
{
    public abstract class BasePage : ComponentBase
    {
        [Inject]
        public WtmBlazorContext WtmBlazor { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public List<string> DeletedFileIds { get; set; }

        [CascadingParameter]
        public LoginUserInfo UserInfo
        {
            get;
            set;
        }

        public object _userinfo;

        [CascadingParameter(Name = "BodyContext")]
        public object UserInfoForDialog
        {
            get
            {
                return _userinfo;
            }
            set
            {
                _userinfo = value;
                UserInfo = value as LoginUserInfo;
            }
        }

        [Parameter]
        public Action<DialogResult> OnCloseDialog { get; set; }

        protected void CloseDialog(DialogResult result = DialogResult.Close)
        {
            OnCloseDialog?.Invoke(result);
        }

        public async Task<DialogResult> OpenDialog<T>(string Title, Expression<Func<T, object>> Values = null, Size size = Size.ExtraExtraLarge, LoginUserInfo userinfo = null, bool isMax = false)
        {
            return await WtmBlazor.OpenDialog(Title, Values, size, userinfo, isMax);
        }

        public async Task<bool> PostsData(object data, string url, Func<string, string> Msg = null, Action<ErrorObj> ErrorHandler = null, HttpMethodEnum method = HttpMethodEnum.POST)
        {
            var rv = await WtmBlazor.Api.CallAPI(url, method, data);
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (Msg != null)
                {
                    var m = Msg.Invoke(rv.Data);
                    await WtmBlazor.Message(color: Color.Success, contetn: WtmBlazor.Localizer[m]);
                }
                CloseDialog(DialogResult.Yes);
                return true;
            }
            else
            {
                await VerificationHttp(rv.Errors, rv.StatusCode, rv.ErrorMsg, ErrorHandler);
                return false;
            }
        }

        public async Task<bool> PostsForm(ValidateForm form, string url, Func<string, string> Msg = null, Action<ErrorObj> ErrorHandler = null, HttpMethodEnum method = HttpMethodEnum.POST)
        {
            if (form.Model is BaseVM bv)
            {
                bv.DeletedFileIds = this.DeletedFileIds;
            }
            var rv = await WtmBlazor.Api.CallAPI(url, method, form.Model);
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (Msg != null)
                {
                    var m = Msg.Invoke(rv.Data);
                    await WtmBlazor.Message(color: Color.Success, contetn: WtmBlazor.Localizer[m]);
                }
                CloseDialog(DialogResult.Yes);
                return true;
            }
            else
            {
                await VerificationHttp(form, rv.Errors, rv.StatusCode, rv.ErrorMsg, ErrorHandler);
                return false;
            }
        }

        public async Task<string> PostsFormToString(ValidateForm form, string url, Func<string, string> Msg = null, Action<ErrorObj> ErrorHandler = null, HttpMethodEnum method = HttpMethodEnum.POST)
        {
            var rv = await WtmBlazor.Api.CallAPI(url, method, form.Model);
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (Msg != null)
                {
                    var m = Msg.Invoke(rv.Data);
                    await WtmBlazor.Message(color: Color.Success, contetn: WtmBlazor.Localizer[m]);
                }
                return rv.Data;
            }
            else
            {
                await VerificationHttp(form, rv.Errors, rv.StatusCode, rv.ErrorMsg, ErrorHandler);
                return null;
            }
        }

        public async Task<T> PostsForm<T>(ValidateForm form, string url, Action<ErrorObj> ErrorHandler = null, HttpMethodEnum method = HttpMethodEnum.POST) where T : class, new()
        {
            var rv = await WtmBlazor.Api.CallAPI<T>(url, method, form.Model);
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return rv.Data;
            }
            else
            {
                await VerificationHttp(form, rv.Errors, rv.StatusCode, rv.ErrorMsg, ErrorHandler);
                return null;
            }
        }

        public async Task GetString(string url, Func<string, string> Msg = null, Action<ErrorObj> ErrorHandler = null)
        {
            var rv = await WtmBlazor.Api.CallAPI(url);
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (Msg != null)
                {
                    var m = Msg.Invoke(rv.Data);
                    await WtmBlazor.Message(color: Color.Success, contetn: WtmBlazor.Localizer[m]);
                }
                CloseDialog(DialogResult.Yes);
            }
            else
            {
                await VerificationHttp(rv.Errors, rv.StatusCode, rv.ErrorMsg, ErrorHandler);
            }
        }

        public async Task<QueryData<T>> StartSearch<T>(string url, BaseSearcher searcher, QueryPageOptions options) where T : class, new()
        {
            var rv = await WtmBlazor.Api.CallSearchApi<T>(url, searcher, options);
            QueryData<T> data = new QueryData<T>();
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data.Items = rv.Data?.Data;
                data.TotalCount = rv.Data?.Count ?? 0;
            }
            else
            {
                await VerificationHttp(rv.Errors, rv.StatusCode, rv.ErrorMsg);
            }
            return data;
        }

        public async Task<QueryData<T>> StartSearchTree<T>(string url, BaseSearcher searcher, QueryPageOptions options) where T : class, new()
        {
            var rv = await WtmBlazor.Api.CallSearchApi<T>(url, searcher, options);
            QueryData<T> data = new QueryData<T>();
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var idpro = typeof(T).GetSingleProperty("ID");
                if (rv.Data?.Data != null)
                {
                    foreach (var item in rv.Data.Data)
                    {
                        string pid = idpro.GetValue(item)?.ToString();
                        item.SetPropertyValue("Children", new List<T>(rv.Data.Data.AsQueryable().CheckParentID(pid)));
                    }
                }
                data.Items = rv.Data?.Data.AsQueryable().CheckParentID(null);
                data.TotalCount = rv.Data?.Count ?? 0;
            }
            else
            {
                await VerificationHttp(rv.Errors, rv.StatusCode, rv.ErrorMsg);
            }
            return data;
        }

        public async void SetError(ValidateForm form, ErrorObj errors)
        {
            if (errors != null)
            {
                foreach (var item in errors.Form)
                {
                    Regex r = new Regex("(.*?)\\[(\\-?\\d?)\\]\\.(.*?)$");
                    var match = r.Match(item.Key);
                    if (match.Success)
                    {
                        int index = 0;
                        int.TryParse(match.Groups[2].Value, out index);
                        await WtmBlazor.Toast.Error(WtmBlazor.Localizer["Sys.Error"], $"{index + 1}:{item.Value}");
                    }
                    else
                    {
                        form.SetError(item.Key, item.Value);
                    }
                }
                if (errors.Message != null && errors.Message.Count > 0)
                {
                    await WtmBlazor.Toast.Error(WtmBlazor.Localizer["Sys.Error"], errors.Message[0]);
                }
            }
        }

        public async Task<string> GetFileUrl(string fileid, int? width = null, int? height = null)
        {
            var rv = await WtmBlazor.Api.CallAPI<byte[]>($"/api/File/GetFile/{fileid}", HttpMethodEnum.GET, new Dictionary<string, string> {
                    {"width", width?.ToString() },
                    {"height", height?.ToString() }
                });
            if (rv.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return $"data:image/jpeg;base64,{Convert.ToBase64String(rv.Data)}";
            }
            else
            {
                return $"data:image/jpeg;base64,0";
            }
        }

        public async Task<string> GetToken()
        {
            return await GetLocalStorage<string>("wtmtoken");
        }

        public async Task<string> GetRefreshToken()
        {
            return await GetLocalStorage<string>("wtmrefreshtoken");
        }

        public async Task SetToken(string token, string refreshtoken)
        {
            await SetLocalStorage("wtmtoken", token);
            await SetLocalStorage("wtmrefreshtoken", refreshtoken);
        }

        public async Task DeleteToken()
        {
            await DeleteLocalStorage("wtmtoken");
            await DeleteLocalStorage("wtmrefreshtoken");
        }

        public async Task SetUserInfo(LoginUserInfo userinfo)
        {
            await JSRuntime.InvokeVoidAsync("localStorageFuncs.set", "wtmuser", JsonSerializer.Serialize(userinfo));
        }

        public async Task<LoginUserInfo> GetUserInfo()
        {
            var user = await GetLocalStorage<LoginUserInfo>("wtmuser");
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            user.Attributes["Actions"] = JsonSerializer.Deserialize<string[]>(user.Attributes["Actions"].ToString(), options).Where(x => x != null).ToArray();
            user.Attributes["Menus"] = JsonSerializer.Deserialize<SimpleMenuApi[]>(user.Attributes["Menus"].ToString(), options);
            return user;
        }

        public async Task<T> GetLocalStorage<T>(string key) where T : class
        {
            string rv = "";
            while (true)
            {
                string part = await JSRuntime.InvokeAsync<string>("localStorageFuncs.get", System.Threading.CancellationToken.None, key, rv.Length);
                if (part == null)
                {
                    return null;
                }
                rv += part;
                if (part.Length < 20000)
                {
                    break;
                }
            }
            if (typeof(T) == typeof(string))
            {
                return rv as T;
            }
            var obj = JsonSerializer.Deserialize<T>(rv);
            return obj;
        }

        public async Task SetLocalStorage<T>(string key, T data) where T : class
        {
            if (typeof(T) == typeof(string))
            {
                await JSRuntime.InvokeVoidAsync("localStorageFuncs.set", key, data);
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("localStorageFuncs.set", key, JsonSerializer.Serialize(data));
            }
        }

        public async Task DeleteLocalStorage(string key)
        {
            await JSRuntime.InvokeAsync<string>("localStorageFuncs.remove", key);
        }

        public bool IsAccessable(string url)
        {
            if (WtmBlazor.ConfigInfo.IsQuickDebug == true)
            {
                return true;
            }
            if (UserInfo != null)
            {
                var actions = UserInfo.Attributes["Actions"] as string[];
                url = url.ToLower();
                return actions.Any(x => x.ToLower() == url.ToLower());
            }
            else if (WtmBlazor.PublicPages.Contains(url?.ToLower()))
            {
                return true;
            }

            return false;
        }

        public async Task Redirect(string path)
        {
            await JSRuntime.InvokeVoidAsync("urlFuncs.redirect", path);
        }

        public async Task Download(string url, object data, HttpMethodEnum method = HttpMethodEnum.POST)
        {
            url = WtmBlazor.GetServerUrl() + url;
            await JSRuntime.InvokeVoidAsync("urlFuncs.download", url, JsonSerializer.Serialize(data, CoreProgram.DefaultPostJsonOption), method.ToString());
        }

        public async Task HttpStatus(HttpStatusCode? status)
        {
            var error = string.Empty;
            switch (status)
            {
                case HttpStatusCode.BadRequest: error = WtmBlazor.Localizer["HttpStatusCode_400"]; break;
                case HttpStatusCode.Unauthorized: error = WtmBlazor.Localizer["HttpStatusCode_401"]; break;
                case HttpStatusCode.PaymentRequired: error = WtmBlazor.Localizer["HttpStatusCode_402"]; break;
                case HttpStatusCode.Forbidden: error = WtmBlazor.Localizer["HttpStatusCode_403"]; break;
                case HttpStatusCode.NotFound: error = WtmBlazor.Localizer["HttpStatusCode_404"]; break;
                case HttpStatusCode.MethodNotAllowed: error = WtmBlazor.Localizer["HttpStatusCode_405"]; break;
                case HttpStatusCode.NotAcceptable: error = WtmBlazor.Localizer["HttpStatusCode_406"]; break;
                case HttpStatusCode.ProxyAuthenticationRequired: error = WtmBlazor.Localizer["HttpStatusCode_407"]; break;
                case HttpStatusCode.RequestTimeout: error = WtmBlazor.Localizer["HttpStatusCode_408"]; break;
                case HttpStatusCode.Conflict: error = WtmBlazor.Localizer["HttpStatusCode_409"]; break;
                case HttpStatusCode.Gone: error = WtmBlazor.Localizer["HttpStatusCode_410"]; break;
                case HttpStatusCode.LengthRequired: error = WtmBlazor.Localizer["HttpStatusCode_411"]; break;
                case HttpStatusCode.PreconditionFailed: error = WtmBlazor.Localizer["HttpStatusCode_412"]; break;
                case HttpStatusCode.RequestEntityTooLarge: error = WtmBlazor.Localizer["HttpStatusCode_413"]; break;
                case HttpStatusCode.RequestUriTooLong: error = WtmBlazor.Localizer["HttpStatusCode_414"]; break;
                case HttpStatusCode.UnsupportedMediaType: error = WtmBlazor.Localizer["HttpStatusCode_415"]; break;
                case HttpStatusCode.RequestedRangeNotSatisfiable: error = WtmBlazor.Localizer["HttpStatusCode_416"]; break;
                case HttpStatusCode.ExpectationFailed: error = WtmBlazor.Localizer["HttpStatusCode_417"]; break;
                case HttpStatusCode.MisdirectedRequest: error = WtmBlazor.Localizer["HttpStatusCode_421"]; break;
                case HttpStatusCode.UnprocessableEntity: error = WtmBlazor.Localizer["HttpStatusCode_422"]; break;
                case HttpStatusCode.Locked: error = WtmBlazor.Localizer["HttpStatusCode_423"]; break;
                case HttpStatusCode.FailedDependency: error = WtmBlazor.Localizer["HttpStatusCode_424"]; break;
                case HttpStatusCode.UpgradeRequired: error = WtmBlazor.Localizer["HttpStatusCode_426"]; break;
                case HttpStatusCode.PreconditionRequired: error = WtmBlazor.Localizer["HttpStatusCode_428"]; break;
                case HttpStatusCode.TooManyRequests: error = WtmBlazor.Localizer["HttpStatusCode_429"]; break;
                case HttpStatusCode.RequestHeaderFieldsTooLarge: error = WtmBlazor.Localizer["HttpStatusCode_431"]; break;
                case HttpStatusCode.UnavailableForLegalReasons: error = WtmBlazor.Localizer["HttpStatusCode_451"]; break;
                case HttpStatusCode.InternalServerError: error = WtmBlazor.Localizer["HttpStatusCode_500"]; break;
                case HttpStatusCode.NotImplemented: error = WtmBlazor.Localizer["HttpStatusCode_501"]; break;
                case HttpStatusCode.BadGateway: error = WtmBlazor.Localizer["HttpStatusCode_502"]; break;
                case HttpStatusCode.ServiceUnavailable: error = WtmBlazor.Localizer["HttpStatusCode_503"]; break;
                case HttpStatusCode.GatewayTimeout: error = WtmBlazor.Localizer["HttpStatusCode_504"]; break;
                case HttpStatusCode.HttpVersionNotSupported: error = WtmBlazor.Localizer["HttpStatusCode_505"]; break;
                case HttpStatusCode.VariantAlsoNegotiates: error = WtmBlazor.Localizer["HttpStatusCode_506"]; break;
                case HttpStatusCode.InsufficientStorage: error = WtmBlazor.Localizer["HttpStatusCode_507"]; break;
                case HttpStatusCode.LoopDetected: error = WtmBlazor.Localizer["HttpStatusCode_508"]; break;
                case HttpStatusCode.NotExtended: error = WtmBlazor.Localizer["HttpStatusCode_510"]; break;
                case HttpStatusCode.NetworkAuthenticationRequired: error = WtmBlazor.Localizer["HttpStatusCode_511"]; break;

                default:
                    break;
            }

            await WtmBlazor.Message(error, Color.Danger);
        }

        public async Task VerificationHttp(ValidateForm form, ErrorObj errors, HttpStatusCode? status, string errorMsg, Action<ErrorObj> ErrorHandler = null)
        {
            if (errors == null)
            {
                await HttpStatus(status);
            }
            else
            {
                SetError(form, errors);
                var err = errors.GetFirstError();
                if (string.IsNullOrEmpty(err) == false)
                {
                    await WtmBlazor.Message(color: Color.Danger, contetn: err);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(errorMsg))
                    {
                        await HttpStatus(status);
                    }
                    else
                    {
                        await WtmBlazor.Message(color: Color.Danger, contetn: errorMsg);
                    }
                }
                ErrorHandler?.Invoke(errors);
            }
        }

        public async Task VerificationHttp(ErrorObj errors, HttpStatusCode? status, string errorMsg, Action<ErrorObj> ErrorHandler = null)
        {
            if (errors == null)
            {
                await HttpStatus(status);
            }
            else
            {
                var err = errors.GetFirstError();
                if (string.IsNullOrEmpty(err) == false)
                {
                    await WtmBlazor.Message(color: Color.Danger, contetn: err);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(errorMsg))
                    {
                        await HttpStatus(status);
                    }
                    else
                    {
                        await WtmBlazor.Message(color: Color.Danger, contetn: errorMsg);
                    }
                }
                ErrorHandler?.Invoke(errors);
            }
        }
    }

    public class WtmBlazorContext
    {
        public IStringLocalizer Localizer { get; set; }
        public GlobalItems GlobalSelectItems { get; set; }
        public ApiClient Api { get; set; }
        public DialogService Dialog { get; set; }
        public ToastService Toast { get; set; }

        public MessageService MessageService { get; set; }

        public IHttpClientFactory ClientFactory { get; set; }
        private Configs _configInfo;
        public Configs ConfigInfo { get => _configInfo; }

        public List<string> _publicPages = null;

        public WtmBlazorContext(IStringLocalizer local, GlobalItems gi, ApiClient api, DialogService dialog, ToastService toast, MessageService messageService, IHttpClientFactory cf, Configs _config)
        {
            _configInfo = _config;
            this.Localizer = local;
            this.GlobalSelectItems = gi;
            this.Api = api;
            this.Dialog = dialog;
            this.Toast = toast;
            this.MessageService = messageService;
            this.ClientFactory = cf;
        }

        public List<FrameworkMenu> GetAllPages()
        {
            var pages = Assembly.GetCallingAssembly().GetTypes().Where(x => typeof(BasePage).IsAssignableFrom(x)).ToList();
            var menus = new List<FrameworkMenu>();
            foreach (var item in pages)
            {
                var actdes = item.GetCustomAttribute<ActionDescriptionAttribute>();
                if (actdes != null)
                {
                    var route = item.GetCustomAttribute<RouteAttribute>();
                    var parts = route.Template.Split("/").Where(x => x != "").ToArray();
                    var area = Localizer["Sys.DefaultArea"].Value;
                    if (parts.Length > 1)
                    {
                        area = parts[0];
                    }
                    var areamenu = menus.Where(x => x.PageName == area).FirstOrDefault();
                    if (areamenu == null)
                    {
                        areamenu = new FrameworkMenu
                        {
                            PageName = area,
                            Icon = "fa fa-fw fa-folder",
                            Children = new List<FrameworkMenu>()
                        };
                        menus.Add(areamenu);
                    }
                    areamenu.Children.Add(new FrameworkMenu
                    {
                        PageName = Localizer[actdes.Description],
                        Icon = "fa fa-fw fa-file",
                        Url = route.Template,
                        ClassName = actdes.ClassFullName
                    });
                }
            }
            return menus;
        }

        public List<string> PublicPages
        {
            get
            {
                if (_publicPages == null)
                {
                    var pages = Assembly.GetCallingAssembly().GetTypes().Where(x => typeof(BasePage).IsAssignableFrom(x)).ToList();
                    _publicPages = new List<string>();
                    foreach (var item in pages)
                    {
                        var route = item.GetCustomAttribute<RouteAttribute>();
                        var ispublic = item.GetCustomAttribute<PublicAttribute>();
                        if (ispublic != null)
                        {
                            var url = route.Template.ToLower();
                            if (url.StartsWith("/"))
                            {
                                url = url[1..];
                            }
                            url = Regex.Replace(url, "{.*?}", ".*?");
                            url = "^" + url + "$";
                            _publicPages.Add(url);
                        }
                    }
                }
                return _publicPages;
            }
        }

        public async Task<string> GetBase64Image(string fileid, int? width = null, int? height = null)
        {
            if (string.IsNullOrEmpty(fileid) == false)
            {
                var rv = await Api.CallAPI<byte[]>($"/api/File/GetFile/{fileid}", HttpMethodEnum.GET, new Dictionary<string, string> {
                    {"width", width?.ToString() },
                    {"height", height?.ToString() }
                });
                if (rv.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return $"data:image/jpeg;base64,{Convert.ToBase64String(rv.Data)}";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public async Task<DialogResult> OpenDialog<T>(string Title, Expression<Func<T, object>> Values = null, Size? size = null, LoginUserInfo userinfo = null, bool isMax = false)
        {
            TaskCompletionSource<DialogResult> ReturnTask = new TaskCompletionSource<DialogResult>();
            SetValuesParser p = new SetValuesParser();
            if (size != null)
            {
                size = Size.ExtraLarge;
            }
            DialogOption option = new DialogOption
            {
                ShowCloseButton = false,
                ShowFooter = false,
                IsDraggable = true,
                ShowMaximizeButton = !isMax,
                FullScreenSize = isMax == true ? FullScreenSize.Always : FullScreenSize.Medium,
                Size = size.Value,
                BodyContext = userinfo,
                Title = Title
            };
            option.BodyTemplate = builder =>
            {
                builder.OpenComponent(0, typeof(T));
                builder.AddMultipleAttributes(2, p.Parse(Values));
                try
                {
                    builder.AddAttribute(3, "OnCloseDialog", new Action<DialogResult>((r) =>
                    {
                        option.OnCloseAsync = null;
                        ReturnTask.TrySetResult(r);
                        option.Dialog!.Close();
                    }));
                }
                catch { };
                //builder.SetKey(Guid.NewGuid());
                builder.AddMarkupContent(4, "<div style=\"height:10px\"></div>");
                builder.CloseComponent();
            };
            option.OnCloseAsync = async () =>
            {
                option.OnCloseAsync = null;
                await option.Dialog.Close();
                ReturnTask.TrySetResult(DialogResult.Close);
            };
            await Dialog.Show(option);
            var rv = await ReturnTask.Task;
            return rv;
        }

        public Task Message(string contetn, Color color, string icon = "fa fa-info-circle") => MessageService.Show(new MessageOption()
        {
            Content = contetn,
            Color = color,
            Icon = icon,
            IsAutoHide = true,
            ShowDismiss = true,
        });

        public string GetServerUrl()
        {
            var server = ConfigInfo.Domains.Where(x => x.Key.ToLower() == "serverpub").Select(x => x.Value).FirstOrDefault();
            if (server == null)
            {
                server = ConfigInfo.Domains.Where(x => x.Key.ToLower() == "server").Select(x => x.Value).FirstOrDefault();
            }
            if (server != null)
            {
                return server.Address.TrimEnd('/');
            }
            else
            {
                return "";
            }
        }
    }
}