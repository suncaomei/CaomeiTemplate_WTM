<template>
  <div class="container">
    <div class="post-center">
      <div class="nickname">代码生成器</div>
      <div class="description">
        <p>Caomei自用版 <br />深度强迫症患者</p>
      </div>
      <el-form :inline="false" :model="formInline" labelPosition="top">
        <el-row :gutter="20">
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"> </el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <el-form-item label="UI">
              <el-input v-model="formInline.UI" :disabled="true" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6"> </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"> </el-col>
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6">
            <el-form-item label="*选择模型">
              <el-select
                @change="onSelectedDrug"
                v-model="formInline.SelectedModel"
                class="m-2"
                placeholder="*请选择模型"
                size="large"
              >
                <el-option
                  v-for="item in formInline.AllModels"
                  :key="item.Value"
                  :label="item.Text"
                  :value="item.Value"
                />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6">
            <el-form-item label="区域">
              <el-input v-model="formInline.Area" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6"> </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"> </el-col>
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6">
            <el-form-item label="*认证方式">
              <el-select
                v-model="formInline.AuthMode"
                class="m-2"
                placeholder="请选择认证方式"
                size="large"
              >
                <el-option
                  v-for="item in options"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"
                />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6">
            <el-form-item label="*模块名称">
              <el-input v-model="formInline.ModuleName" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6"> </el-col>
        </el-row>

        <el-form-item>
          <div class="post-center">
            <el-button type="primary" @click="onSubmit">下一步</el-button>
          </div>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>
<script>
import router from "@/router";
import { SetField } from "../api";
import { AllModels } from "../api";
import { isEmpty } from "element-plus/lib/utils";

export default {
  data() {
    return {
      formInline: {},
      options: [
        {
          value: "Both",
          label: "Both Jwt and Cookie",
        },
        {
          value: "Jwt",
          label: "Jwt",
        },
        {
          value: "Cookie",
          label: "Cookie",
        },
      ],
      UI: isEmpty(this.$route.query.ui) ? "BlazorAndVue" : this.$route.query.ui,
    };
  },
  components: {},
  methods: {
    AllModels() {
      AllModels()
        .then((res) => {
          this.formInline.AllModels = res;
          this.formInline.UI = this.UI;
          this.formInline.ModuleName = "MenuKey.";
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });
    },
    onSelectedDrug() {
      var objVal = {};
      this.formInline.AllModels.forEach((item) => {
        // this.systemVersionObj 是下拉框的数据
        if (item.Value == this.formInline.SelectedModel) {
          // 选中id和当前一样就赋值
          objVal = item.Text;
        }
      });
      this.formInline.ModelName = objVal; // 赋值
    },
    SetField() {
      SetField({
        UI: this.formInline.UI,
        SelectedModel: this.formInline.SelectedModel,
        ModuleName: this.formInline.ModuleName,
        Area: this.formInline.Area,
      })
        .then((res) => {
          this.$router.push({
            name: "SetField",
            params: {
              formInline: JSON.stringify(this.formInline),
              entity: JSON.stringify(res.Data),
            },
          });
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });
    },

    onSubmit() {
      if (
        this.isEmpty(this.formInline.AuthMode) ||
        this.isEmpty(this.formInline.SelectedModel) ||
        this.formInline.ModuleName == "MenuKey." ||
        this.isEmpty(this.formInline.ModuleName)
      ) {
        this.$message.error("必填项未填");
      } else {
        this.SetField();
      }
    },
    //判断字符是否为空的方法
    isEmpty(obj) {
      if (typeof obj == "undefined" || obj == null || obj == "") {
        return true;
      } else {
        return false;
      }
    },
  },
  mounted() {},
  created() {
    this.AllModels();
  },
};
</script>
