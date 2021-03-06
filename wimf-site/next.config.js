require("dotenv").config();
const path = require('path');
const webpack = require('webpack');

module.exports = {
    target: "serverless",
    ignoreBuildErrors: false,
    webpack: (config) => {
        const definePlugin = new webpack.DefinePlugin({
           // TODO add here env variables
        });

        config.plugins.push(definePlugin);

        config.module.rules = config.module.rules.concat([{
            test: /\.(tsx|ts|js|mjs|jsx)$/,
            use: [
                'stylelint-custom-processor-loader',
            ],
            exclude: /node_modules/,
        }]);

        return config;
    },
};