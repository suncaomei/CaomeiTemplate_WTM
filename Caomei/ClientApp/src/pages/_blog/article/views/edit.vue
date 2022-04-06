
<template>
  <div>
    <FormViewEditEdit @refreshGrid="refreshGridArticle" />

  </div>

</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ExArticlePageController,} from "../controller";
import FormViewEditEdit from "./widgets/formViewEditEdit.vue";
@Options({
    name: "Sys_Edit",  
    components: {
    FormViewEditEdit,
  },
})
export default class extends Vue {

    readonly ExArticlePageController = ExArticlePageController;

    
    get queryKey() {
      return "blogarticleedit";
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

