
<template>
  <WtmDetails :queryKey="queryKey" :loading="Entities.loading" :onFinish="onFinish">
    <a-row :gutter="6">

      <a-col :span="12">
         <WtmField entityKey="Content_Form"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="CreateBy_Form"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="CreateTime_Form"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="Title_Form"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="UpdateBy_Form"/>
      </a-col>
      <a-col :span="12">
         <WtmField entityKey="UpdateTime_Form"/>
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
import { ArticlePageController,ExArticlePageController,ExArticleEntity } from "../../controller";
import {$locales, $i18n} from "@/client";

@Options({ components: {} })
export default class extends mixins(PageDetailsBasics) {
  @Provide({ reactive: true }) readonly PageController = ExArticlePageController;
  @Provide({ reactive: true }) readonly PageEntity = ExArticleEntity;
  
  get queryKey() {
    return "blogarticleedit";
  }
  @Provide({ reactive: true }) formState = {
      Entity: {
        Content: undefined,
        CreateBy: undefined,
        CreateTime: undefined,
        Title: undefined,
        UpdateBy: undefined,
        UpdateTime: undefined,
       
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

