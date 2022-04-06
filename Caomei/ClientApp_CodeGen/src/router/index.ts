import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Home from "../views/Home.vue";
import NotFound from "../views/NotFound.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/:ui?",
    name: "Home",
    component: Home,
    meta: { title: "首页" },
  },
  {
    path: "/setField",
    name: "SetField",
    component: () => import("../views/SetField.vue"),
    props: true,
  },
  {
    path: "/model",
    name: "Model",
    component: () => import("../views/Model.vue"),
  },
  {
    path: "/gen",
    name: "Gen",
    component: () => import("../views/Gen.vue"),
    props: true,
  },
  {
    path: "/:pathMatch(.*)*",
    name: "NotFound",
    component: NotFound,
    meta: { title: "NotFound" },
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
