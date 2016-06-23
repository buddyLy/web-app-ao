module.exports = function() {
    var client = './src/Web/';
    var clientApp = client + 'App/AssortmentoptimizationsSystem/';
    var root = './';
    var temp = client + '.tmp/';
    var bower = {
        json: require('./bower.json'),
        directory: client + '/Scripts/',
        ignorePath: '../..'
    };

    var config = {
        /**
         * File paths
         */
        // all javascript that we want to vet
        alljs: [
            clientApp + '**/*.js',
            '!' +  clientApp + 'JasmineTests/**/*.js',
            '!' +  clientApp + 'Services/columnsMasterService.js',
            '!' +  clientApp + 'Services/formula.service.js'
        ],
        build: './build/',
        client: client,
        clientApp: clientApp,
        clientSharedViews: client + 'Views/Shared/',
        //css: temp + 'site.css',
        css: client + 'Content/site.css',
        thirdpartycss: [
            client + 'Scripts/bootstrap/css/bootstrap.css',
            client + 'Content/kendo/kendo.common.min.css',
            client + 'Content/kendo/kendo.bootstrap.min.css',
            client + 'Scripts/toastr/toastr.css',
            client + 'Scripts/angular-ui-tree/angular-ui-tree.min.css'
        ],
        htmltemplates: clientApp + '**/*.html',
        index: client + 'Views/Shared/_Layout.cshtml',
        // app js, with no specs
        appjs: [
            clientApp + '**/*.module.js',
            clientApp + '**/*.js',
            '!' + clientApp + '**/*.spec.js',
            '!' + clientApp + 'templates.js'
        ],
        appjsOrder: [
            '**/app.module.js',
            '**/*.module.js',
            '**/*.js'
        ],
        less: client + 'Content/site.less',
        lessWatch: client + 'Content/*.less',
        modernizrjs: [
            client + 'Scripts/**/modernizr/*.js'
        ],
        root: root,
        thirdpartyjs: [
            client + 'Scripts/**/*.js',
            '!' + client + 'Scripts/**/_references.js',
            //'!' + client + 'Scripts/**/*.min.js',
            '!' + client + 'Scripts/kendo/**/!(kendo.all.min.js|jszip.min.js)',
            '!' + client + 'Scripts/**/jquery/*.min.js',
            '!' + client + 'Scripts/**/angular*/**/*.min.js',
            '!' + client + 'Scripts/**/bootstrap*/**/*.min.js',
            '!' + client + 'Scripts/**/angular-mocks/*.js',
            '!' + client + 'Scripts/**/angularjs-utilities/examples/**/*.js',
            '!' + client + 'Scripts/**/modernizr/*.js',
            '!' + client + 'Scripts/**/jqwidgets/**/*.js',
            '!' + client + 'Scripts/**/kendo/cultures/*.js',
            '!' + client + 'Scripts/**/kendo/messages/*.js',
            '!' + client + 'Scripts/**/moment/benchmarks/*.js',
            '!' + client + 'Scripts/**/moment/locale/*.js',
            '!' + client + 'Scripts/**/moment/meteor/*.js',
            '!' + client + 'Scripts/**/moment/min/*.js',
            '!' + client + 'Scripts/**/lodash/*.min.js',
            '!' + client + 'Scripts/**/toastr/*.min.js',
            '!' + client + 'Scripts/**/*i18next*/**/*.js',
            '!' + client + 'Scripts/**/angular-ui-router/**/*.js',
            '!' + client + 'Scripts/**/demo.js',
            '!' + client + 'Scripts/angular-dragdrop/**/*.js',
            '!' + client + 'Scripts/angular-ui-utils/**/*.js',
            '!' + client + 'Scripts/angularjs-utilities/**/*.js',
            '!' + client + 'Scripts/daterangepicker/**/*.js'
        ],
        thirdpartyjsOrder: [
            '**/jquery/jquery*.js',
            '**/bootstrap.js',
            '**/angular.js',
            '**/kendo/jszip*.js',
            '**/kendo/kendo.all.*.js',
            '**/*.js'
        ],
        temp: temp,
        oldCss: client + 'Content/',

        /**
         * optimized files
         */
        optimized: {
            app: 'app.js',
            lib: 'lib.js'
        },

        /**
         * template cache
         */
        templateCache: {
            file: 'templates-new.js',
            options: {
                module: 'AssortmentOptimization',
                root: 'App/AssortmentOptimization/',
                standAlone: false
            }
        },

        /**
         * Bower and NPM files
         */
        bower: bower,
        packages: [
            './package.json',
            './bower.json'
        ]
    };

    /**
     * wiredep and bower settings
     */
    config.getWiredepDefaultOptions = function () {
        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath
        };
        return options;
    };

    return config;
};
