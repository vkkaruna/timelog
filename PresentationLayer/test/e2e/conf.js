// An example configuration file.
exports.config = {
    // The address of a running selenium server.
    seleniumAddress: 'http://localhost:4444/wd/hub',

    baseUrl: 'http://localhost:9000',

    // Capabilities to be passed to the webdriver instance.
    capabilities: {
        'browserName': 'chrome'
    },

    onPrepare: function() {
        global.dv = browser.driver;

        global.isAngularSite = function(flag) {
            browser.ignoreSynchronization = !flag;
        };
    },

    // Spec patterns are relative to the current working directly when
    // protractor is called.
    specs: ['timelog-spec.js'],

    // Options to be passed to Jasmine-node.
    jasmineNodeOpts: {
        showColors: true,
        defaultTimeoutInterval: 30000
    }
};