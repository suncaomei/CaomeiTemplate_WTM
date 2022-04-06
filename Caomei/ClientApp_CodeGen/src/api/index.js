import request from "../utils/requests";

export function DoGen(data) {
  return request({
    url: "/api/_CodeGen/DoGen",
    method: "post",
    data: data,
  });
}
export function AllModels() {
  return request({
    url: "/api/_CodeGen/AllModels",
    method: "get",
  });
}

export function Preview(data) {
  return request({
    url: "/api/_CodeGen/Preview",
    method: "post",
    data: data,
  });
}
export function SetField(data) {
  return request({
    url: "/api/_CodeGen/SetField",
    method: "post",
    data: data,
  });
}
export function Gen(data) {
  return request({
    url: "/api/_CodeGen/Gen",
    method: "post",
    data: data,
  });
}
export function CreatModel(data) {
  return request({
    url: "/api/_CodeGen/CreatModel",
    method: "post",
    data: data,
  });
}
export function CreatResx(data) {
  return request({
    url: "/api/_CodeGen/CreatResx",
    method: "post",
    data: data,
  });
}
export function CreatVueResx(data) {
  return request({
    url: "/api/_CodeGen/CreatVueResx",
    method: "post",
    data: data,
  });
}
export function GetMainNS() {
  return request({
    url: "/api/_CodeGen/GetMainNS",
    method: "get",
  });
}
