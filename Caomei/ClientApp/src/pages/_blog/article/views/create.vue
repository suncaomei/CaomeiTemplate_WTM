
<template>
  <div>
    <FormViewCreateAdd @refreshGrid="refreshGridArticle" />

  </div>

</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ExArticlePageController,} from "../controller";
import FormViewCreateAdd from "./widgets/formViewCreateAdd.vue";
@Options({
    name: "Sys_Create",  
    components: {
    FormViewCreateAdd,
  },
})
export default class extends Vue {

    readonly ExArticlePageController = ExArticlePageController;

    
    get queryKey() {
      return "blogarticlecreate";
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

