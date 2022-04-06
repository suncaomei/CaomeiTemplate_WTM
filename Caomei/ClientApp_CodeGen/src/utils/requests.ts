import axios from "axios";

const service = axios.create({
  baseURL: process.env.VUE_APP_URL,
  timeout: 10000,
});
const showStatus = (status: number) => {
  let message = "";
  // 这一坨代码可以使用策略模式进行优化
  switch (status) {
    case 400:
      message = "请求错误(400)";
      break;
    case 401:
      message = "未授权，请重新登录(401)";
      break;
    case 403:
      message = "拒绝访问(403)";
      break;
    case 404:
      message = "请求出错(404)";
      break;
    case 408:
      message = "请求超时(408)";
      break;
    case 500:
      message = "服务器错误(500)";
      break;
    case 501:
      message = "服务未实现(501)";
      break;
    case 502:
      message = "网络错误(502)";
      break;
    case 503:
      message = "服务不可用(503)";
      break;
    case 504:
      message = "网络超时(504)";
      break;
    case 505:
      message = "HTTP版本不受支持(505)";
      break;
    default:
      message = `连接出错(${status})!`;
  }
  return `${message}，请检查网络或联系管理员！`;
};
// 响应拦截器
service.interceptors.response.use(
  (response) => {
    return response.data;
  },
  (error) => {
    // 错误抛到业务代码
    const status = error.response.status;
    let msg = showStatus(status);

    error.data = {};
    error.data.msg = "请求超时或服务器异常，请检查网络或联系管理员！";
    if (typeof error.response.data.Value != undefined) {
      error.msg = error.response.data.Value;
      return Promise.reject(error);
    }
    var returnMessage = error.response.data.Message; //error.response.data.data
    if (
      typeof returnMessage == undefined ||
      returnMessage == null ||
      returnMessage == ""
    ) {
      returnMessage = error.response.data.Form;
      if (
        typeof returnMessage == undefined ||
        returnMessage == null ||
        returnMessage == ""
      ) {
        error.msg = msg;
      } else {
        error.msg = Object.values(returnMessage)[0];
      }
    } else {
      error.msg = returnMessage;
    }
    return Promise.reject(error);
  }
);
// 请求拦截器
service.interceptors.request.use(
  (config) => {
    return config;
  },
  (err) => {
    return Promise.reject(err); //返回错误
  }
);

export default service;
