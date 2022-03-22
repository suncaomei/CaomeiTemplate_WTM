基于WTM框架Blazor版修改了一些自定义的地方

1.移除无效多语言翻译资源并自定义多语言翻译资源 
    model=>Model.{ModelName}
    model=>{ModelName}.{ModelField}
    controller=>MenuKey.{Name}
    page=>MenuKey.{Name}

2.修复自带的代码生成器无法生成BatchEdit的问题
3.修复自带的初始化数据导致(用户管理)菜单无效的问题
4.增加了生成Model和翻译资源的API 可见CodeGenController
5.增加了公共主页
6.美化了界面 
7.修改默认的提示框由BB的Toast改为Message
8.增加了一些我忘记了功能
