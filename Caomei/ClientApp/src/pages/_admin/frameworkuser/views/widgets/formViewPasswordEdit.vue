
<template>
  <WtmDetails :queryKey="queryKey" :loading="Entities.loading" :onFinish="onFinish">
    <WtmField entityKey="PasswordEdit"/>
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
    return "adminframeworkuserpassword";
  }
  @Provide({ reactive: true }) formState = {
      Entity: {
        Password: '',
    },
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

