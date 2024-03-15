(function (factory) {
    if (typeof define === "function" && define.amd) {
        define(["jquery", "jquery.validate"], factory);
    } else if (typeof module === "object" && module.exports) {
        module.exports = factory(require("jquery"));
    } else {
        factory(jQuery);
    }
}(function ($) {

    // Add methods to jQuery Validation Plugin
    $.validator.addMethod("maxWords", function (value, element, params) {
        return this.optional(element) || stripHtml(value).match(/\b\w+\b/g).length <= params;
    }, $.validator.format("Please enter {0} words or less."));

    $.validator.addMethod("minWords", function (value, element, params) {
        return this.optional(element) || stripHtml(value).match(/\b\w+\b/g).length >= params;
    }, $.validator.format("Please enter at least {0} words."));

    $.validator.addMethod("rangeWords", function (value, element, params) {
        var valueStripped = stripHtml(value),
            regex = /\b\w+\b/g;
        return this.optional(element) || valueStripped.match(regex).length >= params[0] && valueStripped.match(regex).length <= params[1];
    }, $.validator.format("Please enter between {0} and {1} words."));

    // Accept a value from a file input based on a required mimetype
    $.validator.addMethod("accept", function (value, element, param) {
        // Split mime on commas in case we have multiple types we can accept
        var typeParam = typeof param === "string" ? param.replace(/\s/g, "") : "image/*",
            optionalValue = this.optional(element),
            i, file, regex;

        // Element is optional
        if (optionalValue) {
            return optionalValue;
        }

        if ($(element).attr("type") === "file") {
            // Escape string to be used in the regex
            // see: https://stackoverflow.com/questions/3446170/escape-string-for-use-in-javascript-regex
            // Escape also "/*" as "/.*" as a wildcard
            typeParam = typeParam
                .replace(/[\-\[\]\/\{\}\(\)\+\?\.\\\^\$\|]/g, "\\$&")
                .replace(/,/g, "|")
                .replace(/\/\*/g, "/.*");

            // Check if the element has a FileList before checking each file
            if (element.files && element.files.length) {
                regex = new RegExp(".?(" + typeParam + ")$", "i");
                for (i = 0; i < element.files.length; i++) {
                    file = element.files[i];

                    // Grab the mimetype from the loaded file, verify it matches
                    if (!file.type.match(regex)) {
                        return false;
                    }
                }
            }
        }

        // Either return true because we've validated each file, or because the
        // browser does not support element.files and the FileList feature
        return true;
    }, $.validator.format("Please enter a value with a valid mimetype."));

    // Helper function to strip HTML tags and spaces
    function stripHtml(value) {
        return value.replace(/<.[^<>]*?>/g, " ").replace(/&nbsp;|&#160;/gi, " ").replace(/[.(),;:!?%#$'\"_+=\/\-“”’]*/g, "");
    }

    return $;
}));
