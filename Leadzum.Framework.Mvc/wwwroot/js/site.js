// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
 * jQuery Extension 
 * $.tms.urls({
 *       adduser: "@Url.Action("AddUser", "User")"
 * });
 * 
 * $.tms.url.adduser;
 * 
 * 
 */
(function ($) {
    "use strict";
    $.extend({
        leadzum: {
            url: {},
            task: {},
            format: {},
            loginUrl: "/Admin/Login",
            addTask: function (path) {
                $.extend($.tms.task, path);
            },
            urls: function (path) {
                $.extend($.tms.url, path);
            },
            setFormat: function (path) {
                $.extend($.tms.format, path);
            },
            setLoginUrl: function (path) {
                $.tms.loginUrl = path;
            }
        }
    });
})(jQuery);