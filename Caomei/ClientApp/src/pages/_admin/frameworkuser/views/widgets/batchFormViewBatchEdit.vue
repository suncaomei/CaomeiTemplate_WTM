
<template>
  <WtmDetails :queryKey="queryKey" :loading="Entities.loading" :onFinish="onFinish">
    <div style="margin-bottom:10px;"><i18n-t :keypath="$locales.Sys_BatchEditConfirm" /></div>
      <a-row :gutter="6">
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_Email"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_Gender"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_CellPhone"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_HomePhone"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_Address"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_ZipCode"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs"/>
        </a-col>
        <a-col :span="12">
           <WtmField entityKey="LinkedVM_SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs"/>
        </a-col>
      </a-row>

        <div style="text-align:right;">


        </div>

  <template #button>
  
   <a-divider type="vertical" />
   <a-button type="primary" html-type="submit">
       <template v-slot:icon>
           <SaveOutlined style='margin-right:5px'/>
       </template>
       <i18n-t :keypath="$locales.Sys_Submit" />
   </a-button>
   <a-divider type="vertical" />
   <a-button type="primary" @click.stop.prevent="__wtmBackDetails()">
       <template v-slot:icon>
           <RedoOutlined style='margin-right:5px'/>
       </template>
       <i18n-t :keypath="$locales.Sys_Close" />
   </a-button>
  </template>
  </WtmDetails>
</template>



<script lang="ts">
import { PageDetailsBasics } from "@/components";
import { Inject, mixins, Options, Provide } from "vue-property-decorator";
import { FrameworkUserPageController,ExFrameworkUserPageController,ExFrameworkUserEntity } from "../../controller";
import {$locales, $i18n} from "@/client";

@Options({ components: {} })
export default class extends mixins(PageDetailsBasics) {
  @Provide({ reactive: true }) readonly PageController = ExFrameworkUserPageController;
  @Provide({ reactive: true }) readonly PageEntity = ExFrameworkUserEntity;
  
  @Provide({ reactive: true }) formState = {
      LinkedVM: {
        Email: undefined,
        Gender: undefined,
        CellPhone: undefined,
        HomePhone: undefined,
        Address: undefined,
        ZipCode: undefined,
        SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs: undefined,
        SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs: undefined,
    },
  };
  
  async onFinish(values) {
      const Ids = this.lodash.map(this.PageController.Pagination.selectionDataSource, this.PageController.key)
      if (this.lodash.size(Ids)) {
          await this.PageController.onBatchUpdate(this.lodash.assign({ Ids }, this.formState));
          await this.onRefreshGrid();
      }
  }
  
  
  
  created() {}
  mounted() {
    this.onLoading();
  }
}
</script>

