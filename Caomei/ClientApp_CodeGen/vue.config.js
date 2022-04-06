const webpack = require('webpack');
const path = require('path');
const proEnv = require('./src/config/pro.env'); // 生产环境
const devEnv = require('./src/config/dev.env'); // 本地环境
const env = process.env.NODE_ENV;//当前环境
let VUE_APP_URL = '';//路径
// 默认是本地环境
if (env === 'production') { // 生产环境
    console.log("生产环境");
    process.env.VUE_APP_URL = proEnv.VUE_APP_URL;
    process.env.VUE_APP_Path = proEnv.VUE_APP_Path;

    
} else { // 开发环境
    console.log("开发环境");
    process.env.VUE_APP_URL = devEnv.VUE_APP_URL;
    process.env.VUE_APP_Path = devEnv.VUE_APP_Path;

}
module.exports = {
    outputDir: "build/"+process.env.NODE_ENV,
    publicPath:process.env.VUE_APP_Path,
    filenameHashing: true,//默认情况下，生成的静态资源在它们的文件名中包含了 hash 以便更好的控制缓存。然而，这也要求 index 的 HTML 是被 Vue CLI 自动生成的。如果你无法使用 Vue CLI 生成的 index HTML，你可以通过将这个选项设为 false 来关闭文件名哈希。
    devServer: {
        proxy: VUE_APP_URL,
        hot: true,
        disableHostCheck: true,
        port: 10003,
        overlay: {
            warnings: false,
            errors: true,
        },
        headers: {
            'Access-Control-Allow-Origin': '*',
        },
        
    }
}
