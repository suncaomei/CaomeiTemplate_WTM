<template>
  <div class="container">
    <div class="post-center">
      <div class="nickname">代码生成器</div>
      <div class="description">
        <p>Caomei自用版 <br />深度强迫症患者</p>
      </div>
      <el-row :gutter="20">
        <el-table :data="entity" style="width: 100%">
          <el-table-column label="序号" type="index" />
          <el-table-column prop="FieldName" label="字段名称" />
          <el-table-column prop="FieldDes" label="字段描述" />
          <!-- <el-table-column prop="SubIdField" label="关联表显示字段" /> -->
          <el-table-column label="关联表显示字段">
            <template #default="scope">
              <!-- <el-switch v-model="scope.row.SubIdField" /> -->
              <el-select
                v-show="!isEmpty(scope.row.LinkedType)"
                v-model="scope.row.SubField"
                class="m-2"
                placeholder="请选择关联表显示字段"
                size="large"
              >
                <el-option
                  v-for="item in scope.row.SubFieldOptions"
                  :key="item.Value"
                  :label="item.Text"
                  :value="item.Value"
                />
              </el-select>
            </template>
          </el-table-column>
          <el-table-column label="搜索条件">
            <template #default="scope">
              <el-switch v-model="scope.row.IsSearcherField" />
            </template>
          </el-table-column>
          <el-table-column label="列表展示">
            <template #default="scope">
              <el-switch v-model="scope.row.IsListField" />
            </template>
          </el-table-column>
          <el-table-column label="表单字段">
            <template #default="scope">
              <el-switch v-model="scope.row.IsFormField" />
            </template>
          </el-table-column>
          <el-table-column label="导入字段">
            <template #default="scope">
              <el-switch v-model="scope.row.IsImportField" />
            </template>
          </el-table-column>
          <el-table-column label="批量更新字段">
            <template #default="scope">
              <el-switch v-model="scope.row.IsBatchField" />
            </template>
          </el-table-column>
        </el-table>
      </el-row>

      <div class="post-center">
        <el-button type="primary" @click="onSubmit">下一步</el-button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      formInline: {},
      entity: [],
      options: [],
    };
  },
  components: {},
  methods: {
    Gen() {
      var FieldInfos = [];
      for (var i = 0; i < this.entity.length; i++) {
        if (!this.isEmpty(this.entity[i].LinkedType)) {
          if (this.isEmpty(this.entity[i].SubField)) {
            this.$message.error(this.entity[i].FieldName + "关联显示字段未填");

            return;
          }
        }

        FieldInfos.push({
          FieldName: this.entity[i].FieldName,
          FieldDes: this.entity[i].FieldDes,
          IsSearcherField: this.entity[i].IsSearcherField,
          IsListField: this.entity[i].IsListField,
          IsFormField: this.entity[i].IsFormField,
          SubField: this.entity[i].SubField,
          SubIdField: this.entity[i].SubIdField,
          IsImportField: this.entity[i].IsImportField,
          IsBatchField: this.entity[i].IsBatchField,
          RelatedField: this.entity[i].LinkedType,
        });
      }
      this.formInline.FieldInfos = FieldInfos;
      this.$router.push({
        name: "Gen",
        params: {
          formInline: JSON.stringify(this.formInline),
        },
      });
    },
    onSubmit() {
      this.Gen();
    },
    //判断字符是否为空的方法
    isEmpty(obj) {
      if (typeof obj == "undefined" || obj == null || obj == "") {
        return true;
      } else {
        return false;
      }
    },
  },
  mounted() {},
  created() {
    if (
      this.isEmpty(this.$route.params.formInline) ||
      this.isEmpty(this.$route.params.entity) ||
      this.$route.params.formInline == "{}" ||
      this.$route.params.entity == "[]]"
    ) {
      this.$router.push({ name: "Home" });
    } else {
      this.formInline = JSON.parse(this.$route.params.formInline);
      this.entity = JSON.parse(this.$route.params.entity);
      this.options = this.entity.SubFieldOptions;
    }
  },
};
</script>
