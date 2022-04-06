
<template>
  <WtmGrid :PageController="PageController" :columnDefs="columnDefs" :gridOptions="gridOptions" />
</template>



<script lang="ts">
import { ColDef, ColGroupDef, GridOptions } from "ag-grid-community";
import { Inject, Options,Provide,Vue } from "vue-property-decorator";
import { ArticlePageController,ExArticlePageController } from "../../controller";
import language from '@/client/locales/languagesys';
import RowAction from "./actionViewIndex.vue";
@Options({ components: {} })
export default class extends Vue {
  @Provide({ reactive: true }) readonly PageController = ExArticlePageController;
  get columnDefs(): (ColDef | ColGroupDef)[] {
    return [

      {
        headerName:'Article_Content',
        field: "Content",
      },
      {
        headerName:'Sys_CreateBy',
        field: "CreateBy",
      },
      {
        headerName:'Sys_CreateTime',
        field: "CreateTime",
      },
      {
        headerName:'Article_Title',
        field: "Title",
      },
      {
        headerName:'Sys_UpdateBy',
        field: "UpdateBy",
      },
      {
        headerName:'Sys_UpdateTime',
        field: "UpdateTime",
      },

    ]
  };
    get queryKey() {
        return 'blogarticleindex';
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

