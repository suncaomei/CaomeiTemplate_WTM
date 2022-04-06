
<template>
  <div>
    <FormViewDetailsDetail @refreshGrid="refreshGridFrameworkUser" />

  </div>

</template>


<script lang="ts">
import {Inject,mixins,Options,Provide,Vue } from "vue-property-decorator";
import {$locales} from "@/client";
import { ExFrameworkUserPageController,} from "../controller";
import FormViewDetailsDetail from "./widgets/formViewDetailsDetail.vue";
@Options({
    name: "Sys_Details",  
    components: {
    FormViewDetailsDetail,
  },
})
export default class extends Vue {

    readonly ExFrameworkUserPageController = ExFrameworkUserPageController;

    
    get queryKey() {
      return "adminframeworkuserdetails";
    }

    
    refreshGridFrameworkUser() {
        this.$emit('refreshGrid');
    }
    created() {}
    mounted() {}
}
</script>
<style lang="less">
</style>

