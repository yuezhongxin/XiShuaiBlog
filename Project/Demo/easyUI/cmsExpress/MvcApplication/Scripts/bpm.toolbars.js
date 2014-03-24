(function ($) {
    $.fn.toolbars = function (options) {
        debug(this);
        var opts = $.extend({}, $.fn.toolbars.defaults, options);
        return this.each(function () {
            $this = $(this);
            var o = $.meta ? $.extend({}, opts, $this.data()) : opts;
            $this.css({
                backgroundColor: o.background,
                color: o.foreground
            });
            var markup = $this.html();
            markup = $.fn.toolbars.format(markup);
            $this.html(markup);
        });
    };
    function debug($obj) {
        if (window.console && window.console.log)
            window.console.log('hilight selection count: ' + $obj.size());
    };
    $.fn.toolbars.format = function (txt) {
        return '<strong>' + txt + '</strong>';
    };
    $.fn.toolbars.defaults = {
        foreground: 'red',
        background: 'yellow'
    };
})(jQuery);
