<template>
  <div>
    <template v-if="_readonly">
      <a-row :gutter="24">
        <a-col :span="24">
          <MdEditor v-model="value" previewOnly="true" editorId="MdEditor"> </MdEditor>
        </a-col>
      </a-row>
    </template>
    <template v-else>
      <MdEditor toolbarsExclude="['save', 'github']" v-model="value" htmlPreview="true" @onUploadImg="onUploadImg"> </MdEditor>
    </template>
  </div>
</template>
<script lang="ts">
import { Watch, Options, Ref, mixins, Inject } from "vue-property-decorator";
import MdEditor from "md-editor-v3";
import "md-editor-v3/lib/style.css";
import { FieldBasics } from "../script";

@Options({ components: { MdEditor } })
export default class extends mixins(FieldBasics) {
  // 表单状态值
  @Inject() readonly formState;
  // 自定义校验状态
  @Inject() readonly formValidate;
  // 实体
  @Inject() readonly PageEntity;
  // 表单类型
  @Inject({ default: "" }) readonly formType;
  @Ref("container") container: HTMLDivElement;

  async mounted() {
    // this.onRequest();

    if (this.debug) {
      console.log("");
      console.group(`Field ~ ${this.entityKey} ${this._name} `);
      console.log(this);
      console.groupEnd();
    }
  }
  onUploadImg()
  {
    console.log("暂未实现")
  }
  @Watch("disabled")
  onWatchDisabled() {}
}
</script>
<style lang="less"></style>
