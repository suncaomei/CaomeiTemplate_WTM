
<template>
  <WtmDetails :queryKey="queryKey" :loading="Entities.loading" :onFinish="onFinish">
    <a-tabs >
      <a-tab-pane :tab="$i18n.t($locales.Sys_BasicInfo)" key="基本信息">
        <a-row :gutter="6">
          <a-col :span="12">
             <WtmField entityKey="ITCodeAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="PasswordAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="NameAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="IsValidAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="PhotoIdAdd"/>
          </a-col>
        </a-row>

        <a-row :gutter="6">
          <a-col :span="24">
             <WtmField entityKey="SelectedFrameworkRoleFrameworkUser_MT_WtmsIDsAdd"/>
          </a-col>
          <a-col :span="24">
             <WtmField entityKey="SelectedFrameworkGroupFrameworkUser_MT_WtmsIDsAdd"/>
          </a-col>
        </a-row>

      </a-tab-pane>

      <a-tab-pane :tab="$i18n.t($locales.Sys_ExtraInfo)" key="附加信息">
        <a-row :gutter="6">
          <a-col :span="12">
             <WtmField entityKey="EmailAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="GenderAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="CellPhoneAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="HomePhoneAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="AddressAdd"/>
          </a-col>
          <a-col :span="12">
             <WtmField entityKey="ZipCodeAdd"/>
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
  
  @Provide({ reactive: true }) formState = {
      Entity: {
        ITCode: '',
        Password: '',
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
      await this.PageController.onInsert(this.lodash.omit(this.formState, ['Entity.ID']))
      await this.onRefreshGrid();
  }
  
  
  
  created() {}
  mounted() {
    this.onLoading();
  }
}
</script>

