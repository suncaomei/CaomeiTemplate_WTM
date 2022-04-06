


import { $i18n, WTM_EntitiesField, WTM_ValueType, FieldRequest, $locales } from '@/client';
import router from '@/router';
import { ColGroupDef, GridOptions } from 'ag-grid-community';
import { ColDef } from 'ag-grid-community';
import lodash from 'lodash';
import language from '@/client/locales/languagesys';

/**
 * 页面实体
 */

class ArticleEntity {
    

    readonly Content_Filter: WTM_EntitiesField = {
        name: ['Entity', 'Content'],
        label: 'Article_Content',
        valueType: WTM_ValueType.text,
    }
    readonly CreateBy_Filter: WTM_EntitiesField = {
        name: ['Entity', 'CreateBy'],
        label: 'Sys_CreateBy',
        valueType: WTM_ValueType.text,
    }
    readonly CreateTime_Filter: WTM_EntitiesField = {
        name: ['Entity', 'CreateTime'],
        label: 'Sys_CreateTime',
        valueType: WTM_ValueType.date,
    }
    readonly Title_Filter: WTM_EntitiesField = {
        name: ['Entity', 'Title'],
        label: 'Article_Title',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateBy_Filter: WTM_EntitiesField = {
        name: ['Entity', 'UpdateBy'],
        label: 'Sys_UpdateBy',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateTime_Filter: WTM_EntitiesField = {
        name: ['Entity', 'UpdateTime'],
        label: 'Sys_UpdateTime',
        valueType: WTM_ValueType.date,
    }
    readonly Content_Form: WTM_EntitiesField = {
        name: ['Entity', 'Content'],
        label: 'Article_Content',
        valueType: WTM_ValueType.text,
    }
    readonly CreateBy_Form: WTM_EntitiesField = {
        name: ['Entity', 'CreateBy'],
        label: 'Sys_CreateBy',
        valueType: WTM_ValueType.text,
    }
    readonly CreateTime_Form: WTM_EntitiesField = {
        name: ['Entity', 'CreateTime'],
        label: 'Sys_CreateTime',
        valueType: WTM_ValueType.date,
    }
    readonly Title_Form: WTM_EntitiesField = {
        name: ['Entity', 'Title'],
        label: 'Article_Title',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateBy_Form: WTM_EntitiesField = {
        name: ['Entity', 'UpdateBy'],
        label: 'Sys_UpdateBy',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateTime_Form: WTM_EntitiesField = {
        name: ['Entity', 'UpdateTime'],
        label: 'Sys_UpdateTime',
        valueType: WTM_ValueType.date,
    }
    readonly Content_LinkedVM: WTM_EntitiesField = {
        name: ['LinkedVM', 'Content'],
        label: 'Article_Content',
        valueType: WTM_ValueType.text,
    }
    readonly CreateBy_LinkedVM: WTM_EntitiesField = {
        name: ['LinkedVM', 'CreateBy'],
        label: 'Sys_CreateBy',
        valueType: WTM_ValueType.text,
    }
    readonly CreateTime_LinkedVM: WTM_EntitiesField = {
        name: ['LinkedVM', 'CreateTime'],
        label: 'Sys_CreateTime',
        valueType: WTM_ValueType.date,
    }
    readonly Title_LinkedVM: WTM_EntitiesField = {
        name: ['LinkedVM', 'Title'],
        label: 'Article_Title',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateBy_LinkedVM: WTM_EntitiesField = {
        name: ['LinkedVM', 'UpdateBy'],
        label: 'Sys_UpdateBy',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateTime_LinkedVM: WTM_EntitiesField = {
        name: ['LinkedVM', 'UpdateTime'],
        label: 'Sys_UpdateTime',
        valueType: WTM_ValueType.date,
    }

}

export const ExArticleEntity = new ArticleEntity()

