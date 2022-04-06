
<template>
  <div>
    <FormViewDetailsDetail @refreshGrid="refreshGridArticle" />

  </div>

</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ExArticlePageController,} from "../controller";
import FormViewDetailsDetail from "./widgets/formViewDetailsDetail.vue";
@Options({
    name: "Sys_Details",  
    components: {
    FormViewDetailsDetail,
  },
})
export default class extends Vue {

    readonly ExArticlePageController = ExArticlePageController;

    
    get queryKey() {
      return "blogarticledetails";
    }

    
    refreshGridArticle() {
        this.$emit('refreshGrid');
    }
    created() {}
    mounted() {}
}
</script>
<style lang="less">
</style>

