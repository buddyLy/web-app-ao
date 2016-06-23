module.exports = function() {
    var client = './src/Web/';
    var clientApp = client + 'App/AssortmentOptimization/';
    var report = './report/';
    var contentFolder = client + 'Content/';
    var root = './';
    var specRunnerFile = 'App/JasmineTests/SpecRunner.html';
    var temp = client + '.tmp/';
    var bower = {
        json: require('./bower.json'),
        directory: client + '/Scripts/',
        ignorePath: '../..'
    };
    var nodeModules = 'node_modules';

    var config = {
        /**
         * File paths
         */
        // all javascript that we want to vet
        alljs: [
            clientApp + '**/*.js',
            '!' +  clientApp + 'JasmineTests/**/*.js'
        ],
        build: './build/',
        client: client,
        clientApp: clientApp,
        clientSharedViews: client + 'Views/Shared/',
        //css: temp + 'site.css',
        css: client + 'Content/site.css',
        contentFolder: contentFolder,
        thirdpartycss: [
            client + 'Scripts/bootstrap-walmart/css/bootstrap.css',
            client + 'Content/kendo/kendo.common.min.css',
            client + 'Content/kendo/kendo.bootstrap.min.css',
            client + 'Scripts/toastr/toastr.css'
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
        appjsFiles: [
            'src/Web/App/AssortmentOptimization/**/*.module.js',
            'src/Web/App/AssortmentOptimization/**/*.js',
            'src/Web/App/JasmineTests/Formula.ServiceCalcSpecs.js',
            'src/Web/App/JasmineTests/Formula.ServiceDispSpecs.js'
        ],
        less: client + 'Content/site.less',
        lessWatch: client + 'Content/*.less',
        modernizrjs: [
            client + 'Scripts/**/modernizr/modernizr.js'
        ],
        report: report,
        root: root,
        thirdpartyjs: [
            client + 'Scripts/**/*.js',
            '!' + client + 'Scripts/**/_references.js',
            //'!' + client + 'Scripts/**/*.min.js',
            '!' + client + 'Scripts/kendo/**/!(kendo.all.min.js|jszip.min.js)',
            '!' + client + 'Scripts/**/jqwidgets/srcBuild/**/!(jqx-all.js)',
            '!' + client + 'Scripts/**/sinon/**/*.js',
            '!' + client + 'Scripts/**/jqwidgets/prodBuild/**/*.js',
            '!' + client + 'Scripts/**/jquery/**/*.min.js',
            '!' + client + 'Scripts/**/jquery/src/**/*.js',
            '!' + client + 'Scripts/**/angular*/**/*.min.js',
            '!' + client + 'Scripts/**/bootstrap*/**/*.min.js',
            '!' + client + 'Scripts/**/angular/index.js',
            '!' + client + 'Scripts/**/angular-animate/index.js',
            '!' + client + 'Scripts/**/angular-messages/index.js',
            '!' + client + 'Scripts/**/angular-resource/index.js',
            '!' + client + 'Scripts/**/angular-route/index.js',
            '!' + client + 'Scripts/**/angular-sanitize/index.js',
            '!' + client + 'Scripts/**/angular-mocks/*.js',
            '!' + client + 'Scripts/**/angularjs-utilities/examples/**/*.js',
            '!' + client + 'Scripts/**/angular-bootstrap/ui-bootstrap.js',
            '!' + client + 'Scripts/**/modernizr/**/*.js',
            '!' + client + 'Scripts/**/jasmine-core/**/*.js',
            '!' + client + 'Scripts/**/kendo/cultures/*.js',
            '!' + client + 'Scripts/**/kendo/messages/*.js',
            '!' + client + 'Scripts/**/moment/benchmarks/*.js',
            '!' + client + 'Scripts/**/moment/locale/*.js',
            '!' + client + 'Scripts/**/moment/meteor/*.js',
            '!' + client + 'Scripts/**/moment/min/*.js',
            '!' + client + 'Scripts/**/moment/src/**/*.js',
            '!' + client + 'Scripts/**/moment/templates/*.js',
            '!' + client + 'Scripts/**/lodash/*.min.js',
            '!' + client + 'Scripts/**/toastr/*.min.js',
            '!' + client + 'Scripts/**/*i18next*/**/*.js',
            '!' + client + 'Scripts/**/angular-ui-router/**/*.js',
            '!' + client + 'Scripts/**/demo.js',
            '!' + client + 'Scripts/angular-dragdrop/**/*.js',
            '!' + client + 'Scripts/angular-ui-tree/trees.js',
            '!' + client + 'Scripts/angular-ui-utils/**/*.js',
            '!' + client + 'Scripts/fallback/**/!(fallback.min.js)'
        ],
        thirdpartyjsOrder: [
            '**/jquery/dist/jquery.js',
            '**/bootstrap.js',
            '**/angular.js',
            '**/kendo/jszip*.js',
            '**/kendo/kendo.all.*.js',
            '**/*.js'
        ],
        thirdpartyJsFiles: [
            'src/Web/Scripts/jquery/dist/jquery.js',
            'src/Web/Scripts/bootstrap-walmart/js/bootstrap.js',
            'src/Web/Scripts/angular/angular.js',
            'src/Web/Scripts/kendo/jszip.min.js',
            'src/Web/Scripts/kendo/kendo.all.min.js',
            'src/Web/Scripts/angular-animate/angular-animate.js',
            'src/Web/Scripts/angular-bootstrap/ui-bootstrap-tpls.js',
            'src/Web/Scripts/angular-messages/angular-messages.js',
            'src/Web/Scripts/angular-resource/angular-resource.js',
            'src/Web/Scripts/angular-route/angular-route.js',
            'src/Web/Scripts/angular-sanitize/angular-sanitize.js',
            'src/Web/Scripts/angularjs-utilities/lib/jquery.bootstrap.wizard.js',
            'src/Web/Scripts/angularjs-utilities/lib/mailgun_validator.js',
            'src/Web/Scripts/angularjs-utilities/src/directives/rcSubmit.js',
            'src/Web/Scripts/angularjs-utilities/src/directives/rcVerifySet.js',
            'src/Web/Scripts/angularjs-utilities/src/modules/rcDisabled.js',
            'src/Web/Scripts/angularjs-utilities/src/modules/rcForm.js',
            'src/Web/Scripts/angularjs-utilities/src/modules/rcMailgun.js',
            'src/Web/Scripts/angularjs-utilities/src/modules/rcWizard.js',
            'src/Web/Scripts/extras.angular.plus/ngplus-overlay.js',
            'src/Web/Scripts/jqwidgets/srcBuild/jqx-all.js',
            'src/Web/Scripts/lodash/lodash.js',
            'src/Web/Scripts/moment/moment.js',
            'src/Web/Scripts/toastr/toastr.js',
            'src/Web/Scripts/angular-mocks/angular-mocks.js',
            'src/Web/Scripts/sinonjs/sinon.js',
            'src/Web/Scripts/bardjs/dist/bard.js',
            'src/Web/Scripts/bardjs/dist/bard-ngRouteTester.js'
        ],
        temp: temp,

        /**
         * optimized files
         */
        optimized: {
            app: 'app.js',
            lib: 'lib.js'
        },

        /**
         * plato
         */
        plato: { js: clientApp + '**/*.js' },

        /**
         * template cache
         */
        templateCache: {
            file: 'templates.js',
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
        ],

        /**
         * specs.html, our HTML spec runner
         */
        specRunner: client + specRunnerFile,
        specRunnerFile: specRunnerFile,

        /**
         * The sequence of the injections into specs.html:
         *  1 testlibraries
         *      mocha setup
         *  2 bower
         *  3 js
         *  4 spechelpers
         *  5 specs
         *  6 templates
         */
        testlibraries: [
            client + '/Scripts/jasmine-core/lib/jasmine-core/jasmine.js',
            client + '/Scripts/jasmine-core/lib/jasmine-core/jasmine-html.js',
            client + '/Scripts/jasmine-core/lib/jasmine-core/boot.js'
        ],
        specHelpers: [client + 'App/JasmineTests/test-helpers/*.js'],
        specs: [
            client + 'App/JasmineTests/**/*.spec.js',
            client + 'App/JasmineTests/**/*Specs.js',
        ],
        specjsFiles: [
            'src/Web/App/JasmineTests/**/*Specs.js',
            'src/Web/App/JasmineTests/**/*.spec.js'
        ],
//        serverIntegrationSpecs: [client + '/tests/server-integration/**/*.spec.js']
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

    /**
     * karma settings
     */
    config.karma = getKarmaOptions();

    return config;

    ////////////////

    function getKarmaOptions() {
        var options = {
            files: [].concat(
                config.thirdpartyJsFiles,
                config.specHelpers,
                config.appjsFiles,
                config.specjsFiles,
                temp + config.templateCache.file
            ),
            exclude: [],
            coverage: {
                dir: report + 'coverage',
                reporters: [
                    // reporters not supporting the `file` property
                    { type: 'html', subdir: 'report-html' },
                    { type: 'lcov', subdir: 'report-lcov' },
                    // reporters supporting the `file` property, use `subdir` to directly
                    // output them in the `dir` directory.
                    // omit `file` to output to the console.
                    // {type: 'cobertura', subdir: '.', file: 'cobertura.txt'},
                    // {type: 'lcovonly', subdir: '.', file: 'report-lcovonly.txt'},
                    // {type: 'teamcity', subdir: '.', file: 'teamcity.txt'},
                    //{type: 'text'}, //, subdir: '.', file: 'text.txt'},
                    { type: 'text-summary' } //, subdir: '.', file: 'text-summary.txt'}
                ]
            },
            preprocessors: {}
        };
        options.preprocessors[clientApp + '**/!(*.spec)+(.js)'] = ['coverage'];
        return options;
    }
};
