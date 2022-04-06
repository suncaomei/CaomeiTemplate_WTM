

import * as WTM from "@/client";
export * from './entity';

export class ArticlePageController extends WTM.ControllerBasics {
    constructor() {
        super()
        this.onReset({
            // 唯一标识
            key: "ID",
            // 搜索
            search: '/api/_blog/Article/Search',
            // 详情
            details: '/api/_blog/Article/{ID}',
            // 添加
            insert: '/api/_blog/Article/Create',
            // 修改
            update: '/api/_blog/Article/Edit',
            batchUpdate: { method: 'post', url: '/api/_blog/Article/BatchEdit' },
            // 删除 单&多
            delete: '/api/_blog/Article/BatchDelete',
            // 导入
            import: '/api/_blog/Article/Import',
            // 导出
            export: '/api/_blog/Article/ExportExcel',
            // 筛选导出
            exportIds: '/api/_blog/Article/ExportExcelByIds',
            // 数据模板
            template: '/api/_blog/Article/GetExcelTemplate'
        })
    }
}

export const ExArticlePageController = new ArticlePageController()
