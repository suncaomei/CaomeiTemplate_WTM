


import { $i18n, WTM_EntitiesField, WTM_ValueType, FieldRequest, $locales } from '@/client';
import router from '@/router';
import { ColGroupDef, GridOptions } from 'ag-grid-community';
import { ColDef } from 'ag-grid-community';
import lodash from 'lodash';
import language from '@/client/locales/languagesys';

/**
 * 页面实体
 */

class FrameworkUserEntity {
    
    readonly ITCodeAdd: WTM_EntitiesField = {
        name: ['Entity', 'ITCode'],
        label: 'FrameworkUser_ITCode',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly PasswordAdd: WTM_EntitiesField = {
        name: ['Entity', 'Password'],
        label: 'FrameworkUser_Password',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly NameAdd: WTM_EntitiesField = {
        name: ['Entity', 'Name'],
        label: 'FrameworkUser_Name',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly IsValidAdd: WTM_EntitiesField = {
        name: ['Entity', 'IsValid'],
        label: 'Sys_IsValid',
        rules:[{ required: true }],
        request: async (formState) => {
            return [
                { label: $i18n.t($locales.tips_bool_true), value: true },
                { label: $i18n.t($locales.tips_bool_false), value: false }
            ]
        },
        valueType: WTM_ValueType.switch,
    }
    readonly PhotoIdAdd: WTM_EntitiesField = {
        name: ['Entity', 'PhotoId'],
        label: 'FrameworkUser_Photo',
        valueType: WTM_ValueType.image,
    }
    readonly SelectedFrameworkRoleFrameworkUser_MT_WtmsIDsAdd: WTM_EntitiesField = {
        name: 'SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs',
        request: async () => FieldRequest('/api/_Admin/FrameworkUser/GetFrameworkRoles'),
        fieldProps: { mode: 'tags' },
        label: 'FrameworkUser_Role',
        valueType: WTM_ValueType.checkbox,
    }
    readonly SelectedFrameworkGroupFrameworkUser_MT_WtmsIDsAdd: WTM_EntitiesField = {
        name: 'SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs',
        request: async () => FieldRequest('/api/_Admin/FrameworkUser/GetFrameworkGroups'),
        fieldProps: { mode: 'tags' },
        label: 'FrameworkUser_Group',
        valueType: WTM_ValueType.checkbox,
    }
    readonly EmailAdd: WTM_EntitiesField = {
        name: ['Entity', 'Email'],
        label: 'FrameworkUser_Email',
        valueType: WTM_ValueType.text,
    }
    readonly GenderAdd: WTM_EntitiesField = {
        name: ['Entity', 'Gender'],
        label: 'FrameworkUser_Gender',
        request: async (formState) => {
            return [
                
                { label: $i18n.t($locales.GenderEnum_Male), value: 'Male' },
                { label: $i18n.t($locales.GenderEnum_Female), value: 'Female' },
            ]
        },
        valueType: WTM_ValueType.select,
    }
    readonly CellPhoneAdd: WTM_EntitiesField = {
        name: ['Entity', 'CellPhone'],
        label: 'FrameworkUser_CellPhone',
        valueType: WTM_ValueType.text,
    }
    readonly HomePhoneAdd: WTM_EntitiesField = {
        name: ['Entity', 'HomePhone'],
        label: 'FrameworkUser_HomePhone',
        valueType: WTM_ValueType.text,
    }
    readonly AddressAdd: WTM_EntitiesField = {
        name: ['Entity', 'Address'],
        label: 'FrameworkUser_Address',
        valueType: WTM_ValueType.text,
    }
    readonly ZipCodeAdd: WTM_EntitiesField = {
        name: ['Entity', 'ZipCode'],
        label: 'FrameworkUser_ZipCode',
        valueType: WTM_ValueType.text,
    }
    readonly ITCodeEdit: WTM_EntitiesField = {
        name: ['Entity', 'ITCode'],
        label: 'FrameworkUser_ITCode',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly NameEdit: WTM_EntitiesField = {
        name: ['Entity', 'Name'],
        label: 'FrameworkUser_Name',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly IsValidEdit: WTM_EntitiesField = {
        name: ['Entity', 'IsValid'],
        label: 'Sys_IsValid',
        rules:[{ required: true }],
        request: async (formState) => {
            return [
                { label: $i18n.t($locales.tips_bool_true), value: true },
                { label: $i18n.t($locales.tips_bool_false), value: false }
            ]
        },
        valueType: WTM_ValueType.switch,
    }
    readonly PhotoIdEdit: WTM_EntitiesField = {
        name: ['Entity', 'PhotoId'],
        label: 'FrameworkUser_Photo',
        valueType: WTM_ValueType.image,
    }
    readonly SelectedFrameworkRoleFrameworkUser_MT_WtmsIDsEdit: WTM_EntitiesField = {
        name: 'SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs',
        request: async () => FieldRequest('/api/_Admin/FrameworkUser/GetFrameworkRoles'),
        fieldProps: { mode: 'tags' },
        label: 'FrameworkUser_Role',
        valueType: WTM_ValueType.checkbox,
    }
    readonly SelectedFrameworkGroupFrameworkUser_MT_WtmsIDsEdit: WTM_EntitiesField = {
        name: 'SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs',
        request: async () => FieldRequest('/api/_Admin/FrameworkUser/GetFrameworkGroups'),
        fieldProps: { mode: 'tags' },
        label: 'FrameworkUser_Group',
        valueType: WTM_ValueType.checkbox,
    }
    readonly EmailEdit: WTM_EntitiesField = {
        name: ['Entity', 'Email'],
        label: 'FrameworkUser_Email',
        valueType: WTM_ValueType.text,
    }
    readonly GenderEdit: WTM_EntitiesField = {
        name: ['Entity', 'Gender'],
        label: 'FrameworkUser_Gender',
        request: async (formState) => {
            return [
                
                { label: $i18n.t($locales.GenderEnum_Male), value: 'Male' },
                { label: $i18n.t($locales.GenderEnum_Female), value: 'Female' },
            ]
        },
        valueType: WTM_ValueType.select,
    }
    readonly CellPhoneEdit: WTM_EntitiesField = {
        name: ['Entity', 'CellPhone'],
        label: 'FrameworkUser_CellPhone',
        valueType: WTM_ValueType.text,
    }
    readonly HomePhoneEdit: WTM_EntitiesField = {
        name: ['Entity', 'HomePhone'],
        label: 'FrameworkUser_HomePhone',
        valueType: WTM_ValueType.text,
    }
    readonly AddressEdit: WTM_EntitiesField = {
        name: ['Entity', 'Address'],
        label: 'FrameworkUser_Address',
        valueType: WTM_ValueType.text,
    }
    readonly ZipCodeEdit: WTM_EntitiesField = {
        name: ['Entity', 'ZipCode'],
        label: 'FrameworkUser_ZipCode',
        valueType: WTM_ValueType.text,
    }
    readonly ITCode_Filter : WTM_EntitiesField = {
        name: 'ITCode',
        label: 'FrameworkUser_ITCode',
        valueType: WTM_ValueType.text,
    }
    readonly Name_Filter : WTM_EntitiesField = {
        name: 'Name',
        label: 'FrameworkUser_Name',
        valueType: WTM_ValueType.text,
    }
    readonly IsValid_Filter : WTM_EntitiesField = {
        name: 'IsValid',
        label: 'Sys_IsValid',
        valueType: WTM_ValueType.select,
        request: async (formState) => {
            return [
                { label: $i18n.t($locales.tips_bool_true), value: true },
                { label: $i18n.t($locales.tips_bool_false), value: false }
            ]
        },
    }
    readonly PasswordEdit: WTM_EntitiesField = {
        name: ['Entity', 'Password'],
        label: 'FrameworkUser_Password',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly EmailDetail: WTM_EntitiesField = {
        name: ['Entity', 'Email'],
        label: 'FrameworkUser_Email',
        valueType: WTM_ValueType.text,
    }
    readonly GenderDetail: WTM_EntitiesField = {
        name: ['Entity', 'Gender'],
        label: 'FrameworkUser_Gender',
        request: async (formState) => {
            return [
                
                { label: $i18n.t($locales.GenderEnum_Male), value: 'Male' },
                { label: $i18n.t($locales.GenderEnum_Female), value: 'Female' },
            ]
        },
        valueType: WTM_ValueType.select,
    }
    readonly CellPhoneDetail: WTM_EntitiesField = {
        name: ['Entity', 'CellPhone'],
        label: 'FrameworkUser_CellPhone',
        valueType: WTM_ValueType.text,
    }
    readonly HomePhoneDetail: WTM_EntitiesField = {
        name: ['Entity', 'HomePhone'],
        label: 'FrameworkUser_HomePhone',
        valueType: WTM_ValueType.text,
    }
    readonly AddressDetail: WTM_EntitiesField = {
        name: ['Entity', 'Address'],
        label: 'FrameworkUser_Address',
        valueType: WTM_ValueType.text,
    }
    readonly ZipCodeDetail: WTM_EntitiesField = {
        name: ['Entity', 'ZipCode'],
        label: 'FrameworkUser_ZipCode',
        valueType: WTM_ValueType.text,
    }
    readonly ITCodeDetail: WTM_EntitiesField = {
        name: ['Entity', 'ITCode'],
        label: 'FrameworkUser_ITCode',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly NameDetail: WTM_EntitiesField = {
        name: ['Entity', 'Name'],
        label: 'FrameworkUser_Name',
        rules:[{ required: true }],
        valueType: WTM_ValueType.text,
    }
    readonly IsValidDetail: WTM_EntitiesField = {
        name: ['Entity', 'IsValid'],
        label: 'Sys_IsValid',
        rules:[{ required: true }],
        request: async (formState) => {
            return [
                { label: $i18n.t($locales.tips_bool_true), value: true },
                { label: $i18n.t($locales.tips_bool_false), value: false }
            ]
        },
        valueType: WTM_ValueType.text,
    }
    readonly PhotoIdDetail: WTM_EntitiesField = {
        name: ['Entity', 'PhotoId'],
        label: 'FrameworkUser_Photo',
        valueType: WTM_ValueType.image,
    }
    readonly CreateTimeDetail: WTM_EntitiesField = {
        name: ['Entity', 'CreateTime'],
        label: 'Sys_CreateTime',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateTimeDetail: WTM_EntitiesField = {
        name: ['Entity', 'UpdateTime'],
        label: 'Sys_UpdateTime',
        valueType: WTM_ValueType.text,
    }
    readonly CreateByDetail: WTM_EntitiesField = {
        name: ['Entity', 'CreateBy'],
        label: 'Sys_CreateBy',
        valueType: WTM_ValueType.text,
    }
    readonly UpdateByDetail: WTM_EntitiesField = {
        name: ['Entity', 'UpdateBy'],
        label: 'Sys_UpdateBy',
        valueType: WTM_ValueType.text,
    }
    readonly LinkedVM_Email: WTM_EntitiesField = {
        name: ['LinkedVM', 'Email'],
        label: 'FrameworkUser_Email',
        valueType: WTM_ValueType.text,
    }
    readonly LinkedVM_Gender: WTM_EntitiesField = {
        name: ['LinkedVM', 'Gender'],
        label: 'FrameworkUser_Gender',
        request: async (formState) => {
            return [
                
                { label: $i18n.t($locales.GenderEnum_Male), value: 'Male' },
                { label: $i18n.t($locales.GenderEnum_Female), value: 'Female' },
            ]
        },
        valueType: WTM_ValueType.select,
    }
    readonly LinkedVM_CellPhone: WTM_EntitiesField = {
        name: ['LinkedVM', 'CellPhone'],
        label: 'FrameworkUser_CellPhone',
        valueType: WTM_ValueType.text,
    }
    readonly LinkedVM_HomePhone: WTM_EntitiesField = {
        name: ['LinkedVM', 'HomePhone'],
        label: 'FrameworkUser_HomePhone',
        valueType: WTM_ValueType.text,
    }
    readonly LinkedVM_Address: WTM_EntitiesField = {
        name: ['LinkedVM', 'Address'],
        label: 'FrameworkUser_Address',
        valueType: WTM_ValueType.text,
    }
    readonly LinkedVM_ZipCode: WTM_EntitiesField = {
        name: ['LinkedVM', 'ZipCode'],
        label: 'FrameworkUser_ZipCode',
        valueType: WTM_ValueType.text,
    }
    readonly LinkedVM_SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs: WTM_EntitiesField = {
        name: ['LinkedVM','SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs'],
        request: async () => FieldRequest('/api/_Admin/FrameworkUser/GetFrameworkRoles'),
        fieldProps: { mode: 'tags' },
        label: 'FrameworkUser_Role',
        valueType: WTM_ValueType.select,
    }
    readonly LinkedVM_SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs: WTM_EntitiesField = {
        name: ['LinkedVM','SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs'],
        request: async () => FieldRequest('/api/_Admin/FrameworkUser/GetFrameworkGroups'),
        fieldProps: { mode: 'tags' },
        label: 'FrameworkUser_Group',
        valueType: WTM_ValueType.select,
    }
}

export const ExFrameworkUserEntity = new FrameworkUserEntity()

