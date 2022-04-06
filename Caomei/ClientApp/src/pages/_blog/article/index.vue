
<template>
  <filterViewIndexSearcher />

  <ActionViewIndex />
  <a-divider />
  <GridViewIndex />


  <WtmView queryKey="blogarticlecreate" :title="$i18n.t($locales.Sys_Create)">
    <Create @refreshGrid="refreshGridArticle"/>
  </WtmView>

  <WtmView queryKey="blogarticleedit" :title="$i18n.t($locales.Sys_Edit)">
    <Edit @refreshGrid="refreshGridArticle"/>
  </WtmView>

  <WtmView queryKey="blogarticledetails" :title="$i18n.t($locales.Sys_Details)">
    <Details @refreshGrid="refreshGridArticle"/>
  </WtmView>

  <WtmView queryKey="blogarticlebatchedit" :title="$i18n.t($locales.Sys_BatchEdit)">
    <BatchEdit @refreshGrid="refreshGridArticle"/>
  </WtmView>

  <WtmView queryKey="blogarticleimport" :title="$i18n.t($locales.Sys_Import)">
    <Import @refreshGrid="refreshGridArticle"/>
  </WtmView>
</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import {ExArticlePageController,} from "./controller";
import filterViewIndexSearcher from "./views/widgets/filterViewIndexSearcher.vue";
import ActionViewIndex from "./views/widgets/actionViewIndex.vue";
import GridViewIndex from "./views/widgets/gridViewIndex.vue";
import Create from "@/pages/_blog/article/views/create.vue";
import Edit from "@/pages/_blog/article/views/edit.vue";
import Details from "@/pages/_blog/article/views/details.vue";
import BatchEdit from "@/pages/_blog/article/views/batchEdit.vue";
import Import from "@/pages/_blog/article/views/import.vue";
@Options({
    name: "Caomei.Blog.Controllers,Article",  
    components: {
    filterViewIndexSearcher,
    ActionViewIndex,
    GridViewIndex,
    Create,
    Edit,
    Details,
    BatchEdit,
    Import,
  },
})
export default class extends Vue {

    readonly ExArticlePageController = ExArticlePageController;

    
    get queryKey() {
      return "blogarticleindex";
    }

    
    refreshGridArticle() {
        this.ExArticlePageController.Pagination.onCurrentChange({ current: 1 })
    }
    created() {}
    mounted() {}
}
</script>
<style lang="less">
</style>

