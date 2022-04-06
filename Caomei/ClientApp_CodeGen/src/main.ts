import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./assets/css/style.css";
import "./assets/js/main.js";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
createApp(App).use(router).use(ElementPlus).mount("#app");

router.beforeEach((to, from, next) => {
  /* 路由发生变化修改页面title */
  if (to.meta.title && typeof to.meta.title == "string") {
    document.title = "Caomei - "+to.meta.title;
  }
  next();
});
