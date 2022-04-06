
<template>
  <WtmDetails :queryKey="queryKey" :loading="Entities.loading" :onFinish="onFinish">
    <a-tabs >
      <a-tab-pane :tab="$i18n.t($locales.Sys_BasicInfo)" key="基本信息">
        <a-row :gutter="6">
          <a-col :span="12">
             <WtmField entityKey="ITCodeEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="NameEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="IsValidEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="PhotoIdEdit"/>
          </a-col>
        </a-row>

        <a-row :gutter="6">
          <a-col :span="24">
             <WtmField entityKey="SelectedFrameworkRoleFrameworkUser_MT_WtmsIDsEdit"/>
          </a-col>
          <a-col :span="24">
             <WtmField entityKey="SelectedFrameworkGroupFrameworkUser_MT_WtmsIDsEdit"/>
          </a-col>
        </a-row>

      </a-tab-pane>

      <a-tab-pane :tab="$i18n.t($locales.Sys_ExtraInfo)" key="附加信息">
        <a-row :gutter="6">
          <a-col :span="12">
             <WtmField entityKey="EmailEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="GenderEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="CellPhoneEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="HomePhoneEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="AddressEdit"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="ZipCodeEdit"/>
          </a-col>
        </a-row>

      </a-tab-pane>

    </a-tabs>

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
  
  get queryKey() {
    return "adminframeworkuseredit";
  }
  @Provide({ reactive: true }) formState = {
      Entity: {
        ITCode: '',
        Name: '',
        IsValid: true,
        PhotoId: undefined,
        Email: '',
        Gender: undefined,
        CellPhone: '',
        HomePhone: '',
        Address: '',
        ZipCode: '',
    },
    SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs: [],
    SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs: [],
  };
  
  async onFinish(values) {
      await this.PageController.onUpdate(this.formState);
      await this.onRefreshGrid();
  }
  
  async onLoading() {
      await this.Entities.onLoading({ ID: this.lodash.get(this.$route.query, this.queryKey) });
      this.formState = this.lodash.assign({}, this.formState, this.Entities.dataSource)
  }
  
  
  created() {}
  mounted() {
    this.onLoading();
  }
}
</script>

