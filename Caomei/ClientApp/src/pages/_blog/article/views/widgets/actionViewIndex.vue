

<template>
<div v-if="isRowAction">

    <a-button v-if="__wtmAuthority('update', PageController)" type='link' @click="Edit()">
      <span><i18n-t :keypath="$locales.Sys_Edit" /></span>
    </a-button>
    <a-button v-if="__wtmAuthority('details', PageController)" type='link' @click="Details()">
      <span><i18n-t :keypath="$locales.Sys_Details" /></span>
    </a-button>
    <WtmActionDelete :PageController="PageController" :params="params">
      <template #icon><span class="fa fa-trash" style='margin-right:5px'></span></template>
        <span><i18n-t :keypath="$locales.Sys_Delete" /></span>
    </WtmActionDelete>
</div>
<div v-else>

    <a-button v-if="__wtmAuthority('insert', PageController)" @click="Create()">
      <template #icon><span class="fa fa-plus" style='margin-right:5px'></span></template>
      <span><i18n-t :keypath="$locales.Sys_Create" /></span>
    </a-button>
    <WtmActionDelete :PageController="PageController" :params="params">
      <template #icon><span class="fa fa-trash" style='margin-right:5px'></span></template>
        <span><i18n-t :keypath="$locales.Sys_Delete" /></span>
    </WtmActionDelete>
    <a-button @click="BatchEdit()">
      <template #icon><span class="fa fa-pencil-square" style='margin-right:5px'></span></template>
      <span><i18n-t :keypath="$locales.Sys_BatchEdit" /></span>
    </a-button>
    <WtmActionImport :PageController="PageController" :params="params">
      <template #icon><span class="fa fa-tasks" style='margin-right:5px'></span></template>
        <span><i18n-t :keypath="$locales.Sys_Import" /></span>
    </WtmActionImport>
    <WtmActionExport :PageController="PageController" :params="params">
      <template #icon><span class="fa fa-arrow-circle-down" style='margin-right:5px'></span></template>
        <span><i18n-t :keypath="$locales.Sys_Export" /></span>
    </WtmActionExport>
</div>
</template>



<script lang="ts">
import { Inject, Options, Provide, Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ArticlePageController,ExArticlePageController } from "../../controller";
@Options({ components: {} })
export default class extends Vue {
  // page Inject 注入 row 为 toRowAction 注入
  @Provide({ reactive: true }) readonly PageController = ExArticlePageController;
  get Pagination() {
    return this.PageController.Pagination;
  }
  /**
   * 行 操作 的参数 aggrid 传入
   * @type {ICellRendererParams}
   * @memberof Action
   */
  readonly params = {};
  /**
   * 行数据操作 有 aggrid 传入属性
   * @readonly
   * @memberof Action
   */
  get isRowAction() {
    return this.lodash.has(this.params, "node");
  }
  getRowData() {
    if (this.isRowAction) {
      return this.lodash.cloneDeep(this.lodash.get(this, "params.data", {}));
    }
    return this.lodash.cloneDeep(
      this.lodash.head(this.Pagination.selectionDataSource)
    );
  }
  
  Create() {
    this.__wtmToDetails({
      blogarticlecreate:''
    });
  }
  Edit() {
    this.__wtmToDetails({
      blogarticleedit: this.lodash.get(
        this.getRowData(),
        this.PageController.key
      )
    });
  }
  Details() {
    this.__wtmToDetails(
       this.lodash.assign(
         {
             blogarticledetails: this.lodash.get(
                 this.getRowData(),
                 this.PageController.key
             )
         },
         { _readonly: '' }
        )
  );
  }
  BatchEdit() {
    this.__wtmToDetails({
      blogarticlebatchedit: this.lodash.get(
        this.getRowData(),
        this.PageController.key
      )
    });
  }
  mounted() {}
}
</script>

