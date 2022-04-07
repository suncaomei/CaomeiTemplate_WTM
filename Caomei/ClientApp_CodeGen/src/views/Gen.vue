<template>
  <div class="container">
    <div class="post-center">
      <div class="nickname">代码生成器</div>
      <div class="description">
        <p>Caomei自用版 <br />深度强迫症患者</p>
      </div>
      <div class="post-left">
        <!-- Model  -->
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-link disabled>Model</el-link>
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <el-input v-model="data.ModelNS" :disabled="true" />
          </el-col>
        </el-row>
        <!-- Controller  -->
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-link disabled>Controller</el-link>
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <el-input v-model="data.ControllerNs" />
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-button
              type="text"
              @click="PreviewClick('Controller', 'Controller', $event)"
              >预览</el-button
            >
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <label
              >{{ data.ControllerDir }}\_{{
                data.ModelName
              }}Controller.cs</label
            >
          </el-col>
        </el-row>

        <!-- ViewModels -->
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-link disabled>ViewModels</el-link>
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <el-input v-model="data.VMNs" />
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-button
              type="text"
              @click="PreviewClick('CrudVM', 'ViewModel', $event)"
              >预览</el-button
            >
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <label>{{ data.VmDir }}\{{ data.ModelName }}VM.cs</label>
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-button
              type="text"
              @click="PreviewClick('ListVM', 'ViewModel', $event)"
              >预览</el-button
            >
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <label>{{ data.VmDir }}\{{ data.ModelName }}ListVM.cs</label>
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-button
              type="text"
              @click="PreviewClick('BatchVM', 'ViewModel', $event)"
              >预览</el-button
            >
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <label>{{ data.VmDir }}\{{ data.ModelName }}BatchVM.cs</label>
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-button
              type="text"
              @click="PreviewClick('ImportVM', 'ViewModel', $event)"
              >预览</el-button
            >
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <label>{{ data.VmDir }}\{{ data.ModelName }}ImportVM.cs</label>
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
            <el-button
              type="text"
              @click="PreviewClick('Searcher', 'ViewModel', $event)"
              >预览</el-button
            >
          </el-col>
          <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
            <label>{{ data.VmDir }}\{{ data.ModelName }}Searcher.cs</label>
          </el-col>
        </el-row>
        <!-- Blazor Views -->
        <template v-if="data.UI == 'Blazor' || data.UI == 'BlazorAndVue'">
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-link disabled>Blazor Views</el-link>
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18"> </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('Index', 'BlazorView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ data.ShareDir }}\Index.razor</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('Create', 'BlazorView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ data.ShareDir }}\Create.razor</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('Edit', 'BlazorView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ data.ShareDir }}\Edit.razor</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('Details', 'BlazorView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ data.ShareDir }}\Details.razor</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('Import', 'BlazorView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ data.ShareDir }}\Import.razor</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('BatchEdit', 'BlazorView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ data.ShareDir }}\BatchEdit.razor</label>
            </el-col>
          </el-row>
        </template>
        <!-- Vue Views -->
        <template v-if="data.UI == 'VUE' || data.UI == 'BlazorAndVue'">
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-link disabled>Vue Views</el-link>
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18"> </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('locales', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}locales.ts</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('index', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}index.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('controller.entity', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}controller\entity.ts</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('controller.index', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}controller\index.ts</label>
            </el-col>
          </el-row>

          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('views.batchEdit', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\batchEdit.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('views.create', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\create.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('views.details', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\details.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('views.edit', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\edit.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="PreviewClick('views.import', 'VueView', $event)"
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\import.vue</label>
            </el-col>
          </el-row>

          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick(
                    'views.widgets.actionViewIndex',
                    'VueView',
                    $event
                  )
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\widgets\actionViewIndex.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick(
                    'views.widgets.batchFormViewBatchEdit',
                    'VueView',
                    $event
                  )
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label
                >{{ vuePath }}views\widgets\batchFormViewBatchEdit.vue</label
              >
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick(
                    'views.widgets.filterViewIndexSearcher',
                    'VueView',
                    $event
                  )
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label
                >{{ vuePath }}views\widgets\filterViewIndexSearcher.vue</label
              >
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick(
                    'views.widgets.formViewCreateAdd',
                    'VueView',
                    $event
                  )
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\widgets\formViewCreateAdd.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick(
                    'views.widgets.formViewDetailsDetail',
                    'VueView',
                    $event
                  )
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label
                >{{ vuePath }}views\widgets\formViewDetailsDetail.vue</label
              >
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick(
                    'views.widgets.formViewEditEdit',
                    'VueView',
                    $event
                  )
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\widgets\formViewEditEdit.vue</label>
            </el-col>
          </el-row>
          <el-row :gutter="20">
            <el-col :xs="24" :sm="3" :md="3" :lg="3" :xl="3">
              <el-button
                type="text"
                @click="
                  PreviewClick('views.widgets.gridViewIndex', 'VueView', $event)
                "
                >预览</el-button
              >
            </el-col>
            <el-col :xs="24" :sm="18" :md="18" :lg="18" :xl="18">
              <label>{{ vuePath }}views\widgets\gridViewIndex.vue</label>
            </el-col>
          </el-row>
        </template>
      </div>
      <div class="post-center">
        <el-button type="primary" @click="onSubmit">生成</el-button>
      </div>
    </div>
    <el-drawer
      v-model="drawer"
      :title="viewTitle"
      :lock-scroll="true"
      size="60%"
    >
      <!-- <div>{{ view }}</div> -->
      <el-input
        v-model="view"
        :disabled="true"
        :autosize="true"
        type="textarea"
        placeholder="Please input"
      />
    </el-drawer>
  </div>
</template>
<script>
import { DoGen } from "../api";
import { Gen } from "../api";
import { Preview } from "../api";
import { ref } from "vue";

export default {
  data() {
    return {
      formInline: {},
      data: {},
      drawer: ref(false),
      view: "",
      viewTitle: "",
      vuePath: "",
    };
  },
  components: {},
  methods: {
    onSubmit() {
      this.DoGen();
    },
    PreviewClick(PreviewFile, PreviewFileName, event) {
      var formData = this.data;
      formData.PreviewFile = PreviewFile;
      if (PreviewFileName == "Controller") {
        this.viewTitle = this.data.ModelName + "Controller.cs";
      } else if (PreviewFileName == "ViewModel") {
        this.viewTitle =
          this.data.ModelName + PreviewFile.replace("CrudVM", "VM") + ".cs";
      } else if (PreviewFileName == "BlazorView") {
        this.viewTitle = PreviewFile + ".razor";
        formData.BlazorAndVue = "Blazor";
      } else if (PreviewFileName == "VueView") {
        this.viewTitle = PreviewFile;
        formData.BlazorAndVue = "VUE";
      }

      this.PreviewPost(formData);

    },
    //判断字符是否为空的方法
    isEmpty(obj) {
      if (typeof obj == "undefined" || obj == null || obj == "") {
        return true;
      } else {
        return false;
      }
    },
    Gen() {
      Gen(this.formInline)
        .then((res) => {
          this.data = res;
          this.vuePath = this.data.VueDir;
          console.log(this.data.UI);
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });
    },
    DoGen() {
      DoGen(this.data)
        .then((res) => {
          this.$message.success("生成成功,请关闭项目重新编译后运行");
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });
    },
    PreviewPost(data) {
      Preview(data)
        .then((res) => {
          this.view = res;
          // this.viewTitle =
          //   this.data.ModelName + this.IsApi ? "Api" : "" + Controller.cs; //$"{vm.ModelName}{(vm.IsApi == true ? "Api" : "")}Controller.cs";
          this.drawer = true;
        })
        .catch((err) => {
          this.$message.error(err.msg);
          console.log(err);
          console.log(err.msg);
        });
    },
  },
  mounted() {},
  created() {
    if (
      this.isEmpty(this.$route.params.formInline) ||
      this.$route.params.formInline == "{}"
    ) {
      this.$router.push({ name: "Home" });
    } else {
      this.formInline = JSON.parse(this.$route.params.formInline);
      this.Gen();
    }
  },
};
</script>
