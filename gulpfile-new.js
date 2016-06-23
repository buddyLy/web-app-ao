var args = require('yargs').argv;
var config = require('./gulp-new.config')();
var del = require('del');
var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ lazy: true });

/**
 * yargs variables can be passed in to alter the behavior, when present.
 * Example: gulp vet
 *
 * --verbose  : Various tasks will produce more output to the console.
 */

/**
 * List the available gulp tasks
 */
gulp.task('help', $.taskListing);
gulp.task('default', ['help']);

/**
 * vet the code and create coverage report
 * @return {Stream}
 */
gulp.task('vet', function () {
    log('Analyzing source with JSHint and JSCS');
    return gulp
        .src(config.alljs)
        .pipe($.if(args.verbose, $.print()))
        .pipe($.jshint())
        .pipe($.jshint.reporter('jshint-stylish', { verbose: true }))
        .pipe($.jshint.reporter('fail'));
    //.pipe($.jscs());
});

/**
 * Compile less to css
 * @return {Stream}
 */
gulp.task('styles', ['clean-styles'], function () {
    log('Compiling Less --> CSS');

    return gulp
        .src(config.less)
        .pipe($.plumber()) // exit gracefully if something fails after this
        .pipe($.less())
//        .on('error', errorLogger) // more verbose and dupe output. requires emit.
        .pipe($.autoprefixer({ browsers: ['last 2 version', '> 5%'] }))
        .pipe(gulp.dest(config.temp));
});

gulp.task('old-styles', function () {
    log('Compiling Less --> CSS');

    return gulp
        .src(config.less)
        .pipe($.plumber()) // exit gracefully if something fails after this
        .pipe($.less())
//        .on('error', errorLogger) // more verbose and dupe output. requires emit.
        //.pipe($.autoprefixer({ browsers: ['last 2 version', '> 5%'] }))
        .pipe(gulp.dest(config.oldCss))
        .pipe($.minifyCss({}))
        .pipe($.rename({ suffix: '.min' }))
        .pipe(gulp.dest(config.oldCss));
});

/**
 * Watches for changes to less files and compiles them to css
 */
gulp.task('less-watcher', function () {
    gulp.watch([config.lessWatch], ['styles']);
});
gulp.task('old-less-watcher', function () {
    gulp.watch([config.lessWatch], ['old-styles']);
});

/**
 * Create $templateCache from the html templates
 * @return {Stream}
 */
gulp.task('templatecache', ['clean-code'], function () {
    log('Creating an AngularJS $templateCache');

    return gulp
        .src(config.htmltemplates)
        .pipe($.if(args.verbose, $.bytediff.start()))
        .pipe($.minifyHtml({ empty: true }))
        .pipe($.if(args.verbose, $.bytediff.stop(bytediffFormatter)))
        .pipe($.angularTemplatecache(
            config.templateCache.file,
            config.templateCache.options
        ))
        .pipe(gulp.dest(config.temp))
        .pipe(gulp.dest(config.clientApp));
});

/**
 * Wire-up the bower dependencies
 * @return {Stream}
 */
gulp.task('wiredep', ['templatecache'], function () {
    log('Wiring the bower dependencies into the html');

    var wiredep = require('wiredep').stream;
    var options = config.getWiredepDefaultOptions();
    var templateCache = config.clientApp + config.templateCache.file;

    return gulp
        .src(config.index)
        .pipe(wiredep(options))
        //.pipe(inject(config.modernizrjs, 'modernizr'))
        //.pipe(inject(config.thirdpartyjs, 'thirdparty', config.thirdpartyjsOrder))
        //.pipe(inject(config.appjs, '', config.appjsOrder))
        .pipe(inject(templateCache, 'templates'))
        .pipe(gulp.dest(config.clientSharedViews));
});

/**
 * Inject js and css dependencies into the html
 * @return {Stream}
 */
//gulp.task('inject', ['wiredep', 'styles', 'templatecache'], function () {
gulp.task('inject', ['wiredep'], function () {
    log('Wire up css into the html, after files are ready');

    return gulp
        .src(config.index)
        .pipe(inject(config.thirdpartycss, 'thirdparty'))
        .pipe(inject(config.css))
        .pipe(gulp.dest(config.clientSharedViews));
});

/**
 * Optimize all files, move to a build folder,
 * and inject them into the new index.html
 * @return {Stream}
 */
//gulp.task('optimize', ['inject', 'test'], function () {
gulp.task('optimize', ['inject'], function () {
    log('Optimizing the js, css, and html');

    var assets = $.useref.assets({ searchPath: './' });
    // Filters are named for the gulp-useref path
    var cssFilter = $.filter('**/*.css');
    var jsAppFilter = $.filter('**/' + config.optimized.app);
    var jsLibFilter = $.filter('**/' + config.optimized.lib);

    var templateCache = config.temp + config.templateCache.file;

    return gulp
        .src(config.index)
        .pipe($.plumber())
        .pipe(inject(templateCache, 'templates'))
        .pipe(assets) // Gather all assets from the html with useref
        .pipe($.if(args.verbose, $.print()))
        // Get the css
        .pipe(cssFilter)
        .pipe($.if(args.verbose, $.print()))
        .pipe($.minifyCss())
        .pipe(cssFilter.restore())
        // Get the custom javascript
        .pipe(jsAppFilter)
        .pipe($.ngAnnotate({ add: true }))
        .pipe($.uglify())
        .pipe(getHeader())
        .pipe(jsAppFilter.restore())
        // Get the vendor javascript
        .pipe(jsLibFilter)
        .pipe($.uglify()) // another option is to override wiredep to use min files
        .pipe(jsLibFilter.restore())
        // Take inventory of the file names for future rev numbers
        .pipe($.rev())
        // Apply the concat and file replacement with useref
        .pipe(assets.restore())
        .pipe($.useref())
        // Replace the file names in the html with rev numbers
        .pipe($.revReplace())
        .pipe(gulp.dest(config.build));
});

gulp.task('temp', function () {
    log('Running Temp task');
    var assets = $.useref.assets({ searchPath: './' });
    //var assets = $.useref.assets({ searchPath: config.client });
    // Filters are named for the gulp-useref path
    var cssFilter = $.filter('**/*.css');

    return gulp
        .src(config.index)
        .pipe(assets)
        .pipe(cssFilter)
        .pipe(assets.restore())
        .pipe($.useref())
        .pipe(gulp.dest(config.build + 'Temp'));
});

/**
 * Remove all styles from the build and temp folders
 * @param  {Function} done - callback when complete
 */
gulp.task('clean-styles', function (done) {
    var files = [].concat(
        config.temp + '**/*.css',
        config.build + 'Content/**/*.css'
    );
    clean(files, done);
});

/**
 * Remove all js and html from the build and temp folders
 * @param  {Function} done - callback when complete
 */
gulp.task('clean-code', function (done) {
    var files = [].concat(
        config.temp + '**/*.js',
        config.build + 'Scripts/**/*.js',
        config.build + '**/*.html'
    );
    clean(files, done);
});

/**
 * Bump the version
 * --type=pre will bump the prerelease version *.*.*-x
 * --type=patch or no flag will bump the patch version *.*.x
 * --type=minor will bump the minor version *.x.*
 * --type=major will bump the major version x.*.*
 * --version=1.2.3 will bump to a specific version and ignore other flags
 */
gulp.task('bump', function () {
    var msg = 'Bumping versions';
    var type = args.type;
    var version = args.ver;
    var options = {};
    if (version) {
        options.version = version;
        msg += ' to ' + version;
    } else {
        options.type = type;
        msg += ' for a ' + type;
    }
    log(msg);

    return gulp
        .src(config.packages)
        .pipe($.print())
        .pipe($.bump(options))
        .pipe(gulp.dest(config.root));
});

///////////

/**
 * Delete all files in a given path
 * @param  {Array}   path - array of paths to delete
 * @param  {Function} done - callback when complete
 */
function clean(path, done) {
    log('Cleaning: ' + $.util.colors.blue(path));
    del(path, done);
}

/**
 * Inject files in a sorted sequence at a specified inject label
 * @param   {Array} src   glob pattern for source files
 * @param   {String} label   The label name
 * @param   {Array} order   glob pattern for sort order of the files
 * @returns {Stream}   The stream
 */
function inject(src, label, order) {
    var options = {
        read: false,
        //ignorePath: 'src/Web',
        ignorePath: 'src/Web/',
        addPrefix: '~',
        addRootSlash: false
    };
    if (label) {
        options.name = 'inject:' + label;
    }

    return $.inject(orderSrc(src, order), options);
}

/**
 * Order a stream
 * @param   {Stream} src   The gulp.src stream
 * @param   {Array} order Glob array pattern
 * @returns {Stream} The ordered stream
 */
function orderSrc(src, order) {
    //order = order || ['**/*'];
    return gulp
        .src(src)
        .pipe($.if(order, $.order(order)));
}

/**
 * Formatter for bytediff to display the size changes after processing
 * @param  {Object} data - byte data
 * @return {String}      Difference in bytes, formatted
 */
function bytediffFormatter(data) {
    var difference = (data.savings > 0) ? ' smaller.' : ' larger.';
    return data.fileName + ' went from ' +
        (data.startSize / 1000).toFixed(2) + ' kB to ' +
        (data.endSize / 1000).toFixed(2) + ' kB and is ' +
        formatPercent(1 - data.percent, 2) + '%' + difference;
}

/**
 * Format a number as a percentage
 * @param  {Number} num       Number to format as a percent
 * @param  {Number} precision Precision of the decimal
 * @return {String}           Formatted perentage
 */
function formatPercent(num, precision) {
    return (num * 100).toFixed(precision);
}

/**
 * Format and return the header for files
 * @return {String}           Formatted file header
 */
function getHeader() {
    var pkg = require('./package.json');
    var template = ['/**',
        ' * <%= pkg.name %> - <%= pkg.description %>',
        ' * @authors <%= pkg.authors %>',
        ' * @version v<%= pkg.version %>',
        ' * @link <%= pkg.homepage %>',
        ' * @license <%= pkg.license %>',
        ' */',
        ''
    ].join('\n');
    return $.header(template, {
        pkg: pkg
    });
}

/**
 * Log a message or series of messages using chalk's blue color.
 * Can pass in a string, object or array.
 */
function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                util.log($.util.colors.blue(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}