

<template>
  <WtmFilter :PageController="PageController" @finish="onFinish" @reset="onReset">
    <WtmField entityKey="ITCode_Filter" />
    <WtmField entityKey="Name_Filter" />
    <WtmField entityKey="IsValid_Filter" />
  </WtmFilter>
</template>



<script lang="ts">
import { Vue, Options, Provide, Inject } from "vue-property-decorator";
import { FrameworkUserPageController,ExFrameworkUserPageController,ExFrameworkUserEntity } from "../../controller";
import language from '@/client/locales/languagesys';
@Options({ components: {} })
export default class extends Vue {
  @Provide({ reactive: true }) readonly PageController = ExFrameworkUserPageController;
  @Provide({ reactive: true }) readonly PageEntity = ExFrameworkUserEntity;
  @Provide({ reactive: true }) readonly formState = { 
        ITCode: '',
        Name: '',
        IsValid: false, 
  };
  //readonly EnumLocaleLabel = EnumLocaleLabel;

    get queryKey() {
        return 'adminframeworkuserindex';
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

