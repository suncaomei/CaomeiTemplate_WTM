
<template>
  <WtmGrid :PageController="PageController" :columnDefs="columnDefs" :gridOptions="gridOptions" />
</template>



<script lang="ts">
import { ColDef, ColGroupDef, GridOptions } from "ag-grid-community";
import { Inject, Options,Provide,Vue } from "vue-property-decorator";
import { FrameworkUserPageController,ExFrameworkUserPageController } from "../../controller";
import language from '@/client/locales/languagesys';
import RowAction from "./actionViewIndex.vue";
@Options({ components: {} })
export default class extends Vue {
  @Provide({ reactive: true }) readonly PageController = ExFrameworkUserPageController;
  get columnDefs(): (ColDef | ColGroupDef)[] {
    return [
      {
        headerName:'Sys_Account',
        field: "FrameworkUser_ITCode",
      },
      {
        headerName:'Sys_Name',
        field: "FrameworkUser_Name",
      },
      {
        headerName:'Sys_Role',
        field: "FrameworkUser_Role",
      },
      {
        headerName:'Sys_Group',
        field: "FrameworkUser_Group",
      },
      {
        headerName:'Sys_IsValid',
        field: "Sys_IsValid",
        cellRenderer: this.$FrameworkComponents.switch,
      },
      {
        headerName:'Sys_IsValid',
        field: "FrameworkUser_ExpiryTime",
        // cellRenderer: this.$FrameworkComponents.switch,
      },

    ]
  };
    get queryKey() {
        return 'adminframeworkuserindex';
    }
  get gridOptions(): GridOptions {
    return {
      frameworkComponents: {
        RowAction: this.__wtmToRowAction(RowAction, this.PageController),
      },
    };
  }
  created() { 
      
  }
}
</script>

