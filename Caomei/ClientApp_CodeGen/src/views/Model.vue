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
          <el-col ::xs="24" :sm="6" :md="6" :lg="6" :xl="6">
            <el-form-item label="*基类">
              <el-select
                v-model="formInline.BaseModel"
                class="m-2"
                placeholder="请选择基类"
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
          <el-col ::xs="24" :sm="6" :md="6" :lg="6" :xl="6">
            <el-form-item label="虚方法">
              <el-switch
                v-model="formInline.IsAbstract"
                class="m-2"
                size="large"
              >
              </el-switch>
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6"> </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"> </el-col>
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6">
            <el-form-item label="*项目名称">
              <el-input v-model="formInline.ProjectName_en" :readonly="true" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6">
            <el-form-item label="*区域名称">
              <el-input v-model="formInline.AreasName_en" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6"> </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"> </el-col>
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6">
            <el-form-item label="*模型名称">
              <el-input v-model="formInline.ModelName_en" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6">
            <el-form-item label="*模型描述">
              <el-input v-model="formInline.ModelName_cn" />
            </el-form-item>
          </el-col>
          <el-col :xs="24" :sm="12" :md="6" :lg="6" :xl="6"> </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"></el-col>
          <el-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <el-table :data="ModelField_List">
              <el-table-column prop="ModelField_en" label="*字段名称">
                <template #default="scope">
                  <el-input v-model="scope.row.ModelField_en" />
                </template>
              </el-table-column>
              <el-table-column prop="ModelField_cn" label="*字段描述">
                <template #default="scope">
                  <el-input v-model="scope.row.ModelField_cn" />
                </template>
              </el-table-column>
              <el-table-column label="删除">
                <template #default="scope">
                  <el-button
                    size="small"
                    type="danger"
                    @click="handleDelete(scope.$index, scope.row)"
                    >Delete</el-button
                  >
                </template>
              </el-table-column>
            </el-table>
          </el-col>
          <el-col :xs="24" :sm="6" :md="6" :lg="6" :xl="6"></el-col>
        </el-row>

        <el-form-item>
          <div class="post-center">
            <el-button type="primary" @click="onAdd">增加一行</el-button>
            <el-button type="primary" @click="onModel">Model</el-button>
            <el-button type="primary" @click="onResx">Resx</el-button>
            <el-button type="primary" @click="onVueResx">VueResx</el-button>
          </div>
        </el-form-item>
      </el-form>
    </div>
  </div>
  <el-drawer v-model="drawer" :title="viewTitle" :lock-scroll="true" size="60%">
    <!-- <div>{{ view }}</div> -->
    <el-input
      v-model="view"
      :disabled="true"
      :autosize="true"
      type="textarea"
    />
  </el-drawer>
</template>
<script>
import router from "@/router";
import { GetMainNS } from "../api";
import { CreatModel } from "../api";
import { CreatResx } from "../api";
import { CreatVueResx } from "../api";
import { ref } from "vue";
import { isEmpty } from "element-plus/lib/utils";

export default {
  data() {
    return {
      formInline: {},
      ModelField_List: [],
      options: [
        {
          value: "TopBasePoco",
          label: "TopBasePoco(Guid)",
        },
        {
          value: "BasePoco",
          label: "BasePoco(Guid,创建人，修改人，创建时间和修改时间)",
        },
        {
          value: "PersistPoco",
          label: "PersistPoco(Guid,创建人，修改人，创建时间和修改时间,IsValid)",
        },
      ],
      view: "",
      viewTitle: "",
      drawer: ref(false),
    };
  },
  components: {},
  methods: {
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
    onModel() {
      var list = [];
      for (var i = 0; i < this.ModelField_List.length; i++) {
        if (
          this.isEmpty(this.ModelField_List[i].ModelField_cn) ||
          this.isEmpty(this.ModelField_List[i].ModelField_en)
        ) {
        } else {
          list.push(this.ModelField_List[i]);
        }
      }

      if (
        this.isEmpty(this.formInline.BaseModel) ||
        this.isEmpty(this.formInline.ProjectName_en) ||
        this.isEmpty(this.formInline.ModelName_en) ||
        this.isEmpty(this.formInline.ModelName_cn) ||
        list.length == 0
      ) {
        this.$message.error("必填项必填");
        return;
      }
      this.formInline.ModelField_List = list;

      CreatModel(this.formInline)
        .then((res) => {
          this.viewTitle = "Model";
          this.view = res;
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });

      this.drawer = true;
    },
    onResx() {
      this.formInline.ModelField_List = this.ModelField_List;
      CreatResx(this.formInline)
        .then((res) => {
          this.viewTitle = "Resx";
          this.view = res;
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });

      this.drawer = true;
    },
    onVueResx() {
      this.formInline.ModelField_List = this.ModelField_List;
      CreatVueResx(this.formInline)
        .then((res) => {
          this.viewTitle = "VueResx";
          this.view = res;
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });

      this.drawer = true;
    },
    onAdd() {
      this.ModelField_List.push({
        ModelField_cn: "",
        ModelField_en: "",
      });
    },
    handleDelete(index, row) {
      this.ModelField_List.splice(index, 1);
    },
    //判断字符是否为空的方法
    isEmpty(obj) {
      if (typeof obj == "undefined" || obj == null || obj == ""|| obj == '') {
        return true;
      } else {
        return false;
      }
    },
  },
  mounted() {},
  created() {
    GetMainNS()
      .then((res) => {
        this.formInline.ProjectName_en = res;
      })
      .catch((err) => {
        this.$message.error(err.msg);
        console.log(err);
        console.log(err.msg);
      });
  },
};
</script>
