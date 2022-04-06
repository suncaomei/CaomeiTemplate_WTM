

<template>
  <WtmFilter :PageController="PageController" @finish="onFinish" @reset="onReset">

    <WtmField entityKey="Content_Filter" />
    <WtmField entityKey="CreateBy_Filter" />
    <WtmField entityKey="CreateTime_Filter" />
    <WtmField entityKey="Title_Filter" />
    <WtmField entityKey="UpdateBy_Filter" />
    <WtmField entityKey="UpdateTime_Filter" />
        
    <template #more> </template>
  </WtmFilter>
</template>



<script lang="ts">
import { Vue, Options, Provide, Inject } from "vue-property-decorator";
import { ArticlePageController,ExArticlePageController,ExArticleEntity } from "../../controller";
import language from '@/client/locales/languagesys';
@Options({ components: {} })
export default class extends Vue {
  @Provide({ reactive: true }) readonly PageController = ExArticlePageController;
  @Provide({ reactive: true }) readonly PageEntity = ExArticleEntity;
  @Provide({ reactive: true }) readonly formState = { 
        Content: undefined,
        CreateBy: undefined,
        CreateTime: undefined,
        Title: undefined,
        UpdateBy: undefined,
        UpdateTime: undefined,
       
  };
  //readonly EnumLocaleLabel = EnumLocaleLabel;

    get queryKey() {
        return 'blogarticleindex';
    }
  get Pagination() {
    return this.PageController.Pagination;
  }
  async onFinish(values) {
    await this.Pagination.onLoading(values);
  }
  async onReset(values) {
    await this.Pagination.onLoading(values);
  }
  mounted() { }
  created(){
    
}
}
</script>

