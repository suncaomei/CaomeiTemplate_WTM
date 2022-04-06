
<template>
  <FilterViewIndexFrameworkUserSearcher />

  <ActionViewIndex />
  <a-divider />
  <GridViewIndex />


  <WtmView queryKey="adminframeworkusercreate" :title="$i18n.t($locales.Sys_Create)">
    <Create @refreshGrid="refreshGridFrameworkUser"/>
  </WtmView>

  <WtmView queryKey="adminframeworkuseredit" :title="$i18n.t($locales.Sys_Edit)">
    <Edit @refreshGrid="refreshGridFrameworkUser"/>
  </WtmView>

  <WtmView queryKey="adminframeworkuserdetails" :title="$i18n.t($locales.Sys_Details)">
    <Details @refreshGrid="refreshGridFrameworkUser"/>
  </WtmView>

  <WtmView queryKey="adminframeworkuserimport" :title="$i18n.t($locales.Sys_Import)">
    <Import @refreshGrid="refreshGridFrameworkUser"/>
  </WtmView>

  <WtmView queryKey="adminframeworkuserbatchedit" :title="$i18n.t($locales.Sys_BatchEdit)">
    <BatchEdit @refreshGrid="refreshGridFrameworkUser"/>
  </WtmView>

  <WtmView queryKey="adminframeworkuserpassword" :title="$i18n.t($locales.Sys_ChangePassword)">
    <Password @refreshGrid="refreshGridFrameworkUser"/>
  </WtmView>
</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import {ExFrameworkUserPageController,} from "./controller";
import FilterViewIndexFrameworkUserSearcher from "./views/widgets/filterViewIndexFrameworkUserSearcher.vue";
import ActionViewIndex from "./views/widgets/actionViewIndex.vue";
import GridViewIndex from "./views/widgets/gridViewIndex.vue";
import Create from "@/pages/_admin/frameworkuser/views/create.vue";
import Edit from "@/pages/_admin/frameworkuser/views/edit.vue";
import Details from "@/pages/_admin/frameworkuser/views/details.vue";
import Import from "@/pages/_admin/frameworkuser/views/import.vue";
import BatchEdit from "@/pages/_admin/frameworkuser/views/batchEdit.vue";
import Password from "@/pages/_admin/frameworkuser/views/password.vue";
@Options({
    name: "Caomei.Admin.Controllers,FrameworkUser",  
    components: {
    FilterViewIndexFrameworkUserSearcher,
    ActionViewIndex,
    GridViewIndex,
    Create,
    Edit,
    Details,
    Import,
    BatchEdit,
    Password,
  },
})
export default class extends Vue {

    readonly ExFrameworkUserPageController = ExFrameworkUserPageController;

    
    get queryKey() {
      return "adminframeworkuserindex";
    }

    
    refreshGridFrameworkUser() {
        this.ExFrameworkUserPageController.Pagination.onCurrentChange({ current: 1 })
    }
    created() {}
    mounted() {}
}
</script>
<style lang="less">
</style>

