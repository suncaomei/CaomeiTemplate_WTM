<template>
<h1>Hello World</h1>
</template>
<script lang="ts">
import { Inject, Options, Vue } from "vue-property-decorator";
@Options({ components: {} })
export default class extends Vue {
    get locale() {
        return this.$i18n.locale
    }
    created() {

    }
}
</script>
<style lang="less" scoped>
</style>
