$.stylesheets = (function () {
    var stylesheets,
        add,
        clear;

    add = function (cssfile) {
        $('head').append('<link href="' + cssfile + '" rel="stylesheet" />');
        return stylesheets;
    };

    clear = function () {
        $('head link[rel=stylesheet]').remove();
        return stylesheets;
    };

    return stylesheets = {
        add: add,
        clear: clear
    };
} ());