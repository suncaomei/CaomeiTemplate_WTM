
<template>

</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ExFrameworkUserPageController,} from "../controller";
@Options({
    name: "Sys_Import",  
    components: {
  },
})
export default class extends Vue {

    readonly ExFrameworkUserPageController = ExFrameworkUserPageController;

    
    get queryKey() {
      return "adminframeworkuserimport";
    }

    
    created() {}
    mounted() {}
}
</script>
<style lang="less">
</style>

