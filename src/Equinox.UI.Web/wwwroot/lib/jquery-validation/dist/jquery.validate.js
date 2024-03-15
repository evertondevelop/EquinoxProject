/*!
 * jQuery Validation Plugin v1.17.0
 *
 * https://jqueryvalidation.org/
 *
 * Copyright (c) 2017 Jörn Zaefferer
 * Released under the MIT license
 */
(function (factory) {
    if (typeof define === 'function' && define.amd) {
        define(['jquery'], factory);
    } else if (typeof module === 'object' && module.exports) {
        module.exports = factory(require('jquery'));
    } else {
        factory(jQuery);
    }
}(function ($) {

    $.fn.extend({

        // https://jqueryvalidation.org/validate/
        validate: function (options) {
            // ... (same as original code)
        },

        // https://jqueryvalidation.org/valid/
        valid: function () {
            // ... (same as original code)
        },

        // https://jqueryvalidation.org/rules/
        rules: function (command, argument) {
            // ... (same as original code)
        }
    });

    // Custom selectors
    $.extend($.expr.pseudos || $.expr[':'], {
        // ... (same as original code)
    });

    // Constructor for validator
    $.validator = function (options, form) {
        // ... (same as original code)
    };

    // https://jqueryvalidation.org/jQuery.validator.format/
    $.validator.format = function (source, params) {
        // ... (same as original code)
    };

    $.extend($.validator, {
        // ... (same as original code)
    });

    // Ajax mode: abort
    // usage: $.ajax({ mode: "abort"[, port: "uniqueport"]});
    // if mode:"abort" is used, the previous request on that port (port can be undefined) is aborted via XMLHttpRequest.abort()

    var pendingRequests = {},
        ajax;

    // Use a prefilter if available (1.5+)
    if ($.ajaxPrefilter) {
        $.ajaxPrefilter(function (settings, _, xhr) {
            var port = settings.port;
            if (settings.mode === "abort") {
                if (pendingRequests[port]) {
                    pendingRequests[port].abort();
                }
                pendingRequests[port] = xhr;
            }
        });
    } else {

        // Proxy ajax
        ajax = $.ajax;
        $.ajax = function (settings) {
            var mode = (settings.mode || $.ajaxSettings.mode),
                port = (settings.port || $.ajaxSettings.port);
            if (mode === "abort") {
                if (pendingRequests[port]) {
                    pendingRequests[port].abort();
                }
                pendingRequests[port] = ajax.apply(this, arguments);
                return pendingRequests[port];
            }
            return ajax.apply(this, arguments);
        };
    }
    return $;
}));
