$.stylesheets = (function () {
    var stylesheets,
        add,
        clear;

    add = function (cssfile) {
        $('head').append('<link href="' + cssfile + '" rel="stylesheet" />');
        return stylesheet;
    };

    clear = function () {
        $('head link[rel=stylesheet]').remove();
        return stylesheet;
    };

    return stylesheets = {
        add: add,
        clear: clear
    };
} ());