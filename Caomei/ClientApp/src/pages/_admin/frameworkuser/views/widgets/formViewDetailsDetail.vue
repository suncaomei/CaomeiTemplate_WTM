
<template>
  <WtmDetails :queryKey="queryKey" :loading="Entities.loading" :onFinish="onFinish">
    <a-row :gutter="6">
      <a-col :span="12">
         <WtmField entityKey="EmailDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="GenderDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="CellPhoneDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="HomePhoneDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="AddressDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="ZipCodeDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="ITCodeDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="NameDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="IsValidDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="PhotoIdDetail" style="width:300px;"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="CreateTimeDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="UpdateTimeDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="CreateByDetail"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="UpdateByDetail"/>
      </a-col>
    </a-row>

      <div style="text-align:right;">

      </div>

  <template #button>
  
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
    return "adminframeworkuserdetails";
  }
  @Provide({ reactive: true }) formState = {
      Entity: {
        Email: '',
        Gender: undefined,
        CellPhone: '',
        HomePhone: '',
        Address: '',
        ZipCode: '',
        ITCode: '',
        Name: '',
        IsValid: false,
        PhotoId: undefined,
        CreateTime: undefined,
        UpdateTime: undefined,
        CreateBy: '',
        UpdateBy: '',
    },
  };
  
  
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

