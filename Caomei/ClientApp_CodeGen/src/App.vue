<template>
  <div class="wrapper">
    <header>
      <nav class="navbar">
        <div class="container">
          <div class="navbar-header header-logo"><a href="/">Caomei</a></div>
          <div class="menu navbar-right">
            <router-link class="menu-item" to="/">Home</router-link>
            <router-link class="menu-item" to="/model">Model</router-link>

            <input id="switch_default" type="checkbox" class="switch_default" />
            <label for="switch_default" class="toggleBtn"></label>
          </div>
        </div>
      </nav>
      <nav class="navbar-mobile" id="nav-mobile">
        <div class="container">
          <div class="navbar-header">
            <div>
              <a href="/">Caomei</a
              ><a id="mobile-toggle-theme">&nbsp;·&nbsp;Light</a>
            </div>
            <div class="menu-toggle" @click="mobileBtn()">&#9776; Menu</div>
          </div>
          <div class="menu" id="mobile-menu">
            <router-link class="menu-item" to="/">Home</router-link>
            <router-link class="menu-item" to="/model">Model</router-link>
          </div>
        </div>
      </nav>
    </header>
    <div class="main">
      <router-view />
    </div>
  </div>
</template>
<script>
import { ElMessage } from "element-plus";

export default {
  data() {
    return {};
  },
  components: { ElMessage },
  methods: {
    mobileBtn() {
      var toggleMenu = document.getElementsByClassName("menu-toggle")[0];
      var mobileMenu = document.getElementById("mobile-menu");
      if (toggleMenu.classList.contains("active")) {
        toggleMenu.classList.remove("active");
        mobileMenu.classList.remove("active");
      } else {
        toggleMenu.classList.add("active");
        mobileMenu.classList.add("active");
      }
    },
  },
  mounted() {},
  created() {},
};
</script>
