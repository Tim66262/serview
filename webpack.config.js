var path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
var webpack = require('webpack');
function resolve(dir) {
    return path.join(__dirname, "./ClientApp", dir);
}

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    return [{
        entry: {
            app: [path.join(__dirname, 'ClientApp/main.js')],
        },
        resolve: {
            extensions: ['.js', '.vue', '.json'],
            alias: {
                'vue$': 'vue/dist/vue.esm.js',
                '@': resolve('ClientApp')
            }
        },
        mode: "production",
        output: {
            path: path.resolve(__dirname, './wwwroot/dist'),
            publicPath: '/dist/',
            filename: '[name].js'
        },
        module: {
            rules: [
                {
                    test: /\.vue$/,
                    loader: 'vue-loader'
                },
                {
                    test: /\.js$/,
                    loader: 'babel-loader',
                    exclude: "/node_modules/",
                },
                {
                    test: /\.scss$/,
                    use: [
                        MiniCssExtractPlugin.loader,
                        //"style-loader",
                        "css-loader",
                        "sass-loader"
                    ],
                    exclude: "/node_modules/"
                },
                {
                    test: /\.(png|jpg|jpeg|gif|svg)$/,
                    use: 'url-loader?limit=25000'
                },
                {
                    test: /\.(eot|svg|ttf|woff|woff2)(\?\S*)?$/,
                    loader: 'file-loader'
                },
            ]
        },
        plugins: [
            new webpack.DefinePlugin({
                'process.env': {
                    NODE_ENV: JSON.stringify(isDevBuild ? 'development' : 'production')
                }
            }),
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ]
            .concat(isDevBuild ? [
                new webpack.SourceMapDevToolPlugin({
                    filename: '[file].map', // Remove this line if you prefer inline source maps
                    moduleFilenameTemplate: path.relative("/wwwroot/dist/", '[resourcePath]') // Point sourcemap entries to the original file locations on disk
                })
            ] : [
                    new webpack.optimize.UglifyJsPlugin(),
                    new MiniCssExtractPlugin({
                        filename: "style.css"
                    }),
                ])
    }]
}