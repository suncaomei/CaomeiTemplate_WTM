
<template>

</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ExArticlePageController,} from "../controller";
@Options({
    name: "Sys_Import",  
    components: {
  },
})
export default class extends Vue {

    readonly ExArticlePageController = ExArticlePageController;

    
    get queryKey() {
      return "blogarticleimport";
    }

    
    created() {}
    mounted() {}
}
</script>
<style lang="less">
</style>

