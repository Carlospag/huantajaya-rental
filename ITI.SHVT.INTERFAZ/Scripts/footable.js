/*!
 * FooTable - Awesome Responsive Tables
 * http://themergency.com/footable
 *
 * Requires jQuery - http://jquery.com/
 *
 * Copyright 2012 Steven Usher & Brad Vincent
 * Released under the MIT license
 * You are free to use FooTable in commercial projects as long as this copyright header is left intact.
 *
 * Date: 18 Nov 2012
 */
(function($, w, undefined) {
    w.footable = {
        options: {
            delay: 100,
            breakpoints: {
                phone: 480,
                tablet: 1024
            },
            parsers: {
                alpha: function(cell) {
                    return $(cell).data("value") || $.trim($(cell).text())
                }
            },
            toggleSelector: " > tbody > tr:not(.footable-row-detail)",
            createDetail: function(element, data) {
                for (var i = 0; i < data.length; i++) {
                    element.append("<div><strong>" + data[i].name + "</strong><br>" + data[i].display + "</div>")
                }
            },
            classes: {
                loading: "footable-loading",
                loaded: "footable-loaded",
                sorted: "footable-sorted",
                descending: "footable-sorted-desc",
                indicator: "footable-sort-indicator"
            },
            debug: false
        },
        version: {
            major: 0,
            minor: 1,
            toString: function() {
                return w.footable.version.major + "." + w.footable.version.minor
            },
            parse: function(str) {
                version = /(\d+)\.?(\d+)?\.?(\d+)?/.exec(str);
                return {
                    major: parseInt(version[1]) || 0,
                    minor: parseInt(version[2]) || 0,
                    patch: parseInt(version[3]) || 0
                }
            }
        },
        plugins: {
            _validate: function(plugin) {
                if (typeof plugin["name"] !== "string") {
                    if (w.footable.options.debug == true) console.error('Validation failed, plugin does not implement a string property called "name".', plugin);
                    return false
                }
                if (!$.isFunction(plugin["init"])) {
                    if (w.footable.options.debug == true) console.error('Validation failed, plugin "' + plugin["name"] + '" does not implement a function called "init".', plugin);
                    return false
                }
                if (w.footable.options.debug == true) console.log('Validation succeeded for plugin "' + plugin["name"] + '".', plugin);
                return true
            },
            registered: [],
            register: function(plugin, options) {
                if (w.footable.plugins._validate(plugin)) {
                    w.footable.plugins.registered.push(plugin);
                    if (options != undefined && typeof options === "object") $.extend(true, w.footable.options, options);
                    if (w.footable.options.debug == true) console.log('Plugin "' + plugin["name"] + '" has been registered with the Foobox.', plugin)
                }
            },
            init: function(instance) {
                for (var i = 0; i < w.footable.plugins.registered.length; i++) {
                    try {
                        w.footable.plugins.registered[i]["init"](instance)
                    } catch (err) {
                        if (w.footable.options.debug == true) console.error(err)
                    }
                }
            }
        }
    };
    var instanceCount = 0;
    $.fn.footable = function(options) {
        options = options || {};
        var o = $.extend(true, {}, w.footable.options, options);
        return this.each(function() {
            instanceCount++;
            this.footable = new Footable(this, o, instanceCount)
        })
    };

    function Timer() {
        var t = this;
        t.id = null;
        t.busy = false;
        t.start = function(code, milliseconds) {
            if (t.busy) {
                return
            }
            t.stop();
            t.id = setTimeout(function() {
                code();
                t.id = null;
                t.busy = false
            }, milliseconds);
            t.busy = true
        };
        t.stop = function() {
            if (t.id != null) {
                clearTimeout(t.id);
                t.id = null;
                t.busy = false
            }
        }
    }

    function Footable(t, o, id) {
        var ft = this;
        ft.id = id;
        ft.table = t;
        ft.options = o;
        ft.breakpoints = [];
        ft.breakpointNames = "";
        ft.columns = {};
        var opt = ft.options;
        var cls = opt.classes;
        ft.timers = {
            resize: new Timer,
            register: function(name) {
                ft.timers[name] = new Timer;
                return ft.timers[name]
            }
        };
        w.footable.plugins.init(ft);
        ft.init = function() {
            var $window = $(w),
                $table = $(ft.table);
            if ($table.hasClass(cls.loaded)) {
                ft.raise("footable_already_initialized");
                return
            }
            $table.addClass(cls.loading);
            $table.find("> thead > tr > th, > thead > tr > td").each(function() {
                var data = ft.getColumnData(this);
                ft.columns[data.index] = data;
                var count = data.index + 1;
                var $column = $table.find("> tbody > tr > td:nth-child(" + count + ")");
                if (data.className != null) $column.not(".footable-cell-detail").addClass(data.className)
            });
            for (var name in opt.breakpoints) {
                ft.breakpoints.push({
                    name: name,
                    width: opt.breakpoints[name]
                });
                ft.breakpointNames += name + " "
            }
            ft.breakpoints.sort(function(a, b) {
                return a["width"] - b["width"]
            });
            ft.bindToggleSelectors();
            ft.raise("footable_initializing");
            $table.bind("footable_initialized", function(e) {
                ft.resize();
                $table.removeClass(cls.loading);
                $table.find('[data-init="hide"]').hide();
                $table.find('[data-init="show"]').show();
                $table.addClass(cls.loaded)
            });
            $window.bind("resize.footable", function() {
                ft.timers.resize.stop();
                ft.timers.resize.start(function() {
                    ft.raise("footable_resizing");
                    ft.resize();
                    ft.raise("footable_resized")
                }, opt.delay)
            });
            ft.raise("footable_initialized")
        };
        ft.bindToggleSelectors = function() {
            var $table = $(ft.table);
            $table.find(opt.toggleSelector).unbind("click.footable").bind("click.footable", function(e) {
                if ($table.is(".breakpoint")) {
                    var $row = $(this).is("tr") ? $(this) : $(this).parents("tr:first");
                    ft.toggleDetail($row.get(0))
                }
            })
        };
        ft.parse = function(cell, column) {
            var parser = opt.parsers[column.type] || opt.parsers.alpha;
            return parser(cell)
        };
        ft.getColumnData = function(th) {
            var $th = $(th),
                hide = $th.data("hide");
            hide = hide || "";
            hide = hide.split(",");
            var data = {
                index: $th.index(),
                hide: {},
                type: $th.data("type") || "alpha",
                name: $th.data("name") || $.trim($th.text()),
                ignore: $th.data("ignore") || false,
                className: $th.data("class") || null
            };
            data.hide["default"] = $th.data("hide") === "all" || $.inArray("default", hide) >= 0;
            for (var name in opt.breakpoints) {
                data.hide[name] = $th.data("hide") === "all" || $.inArray(name, hide) >= 0
            }
            var e = ft.raise("footable_column_data", {
                column: {
                    data: data,
                    th: th
                }
            });
            return e.column.data
        };
        ft.getViewportWidth = function() {
            return window.innerWidth || (document.body ? document.body.offsetWidth : 0)
        };
        ft.getViewportHeight = function() {
            return window.innerHeight || (document.body ? document.body.offsetHeight : 0)
        };
        ft.hasBreakpointColumn = function(breakpoint) {
            for (var c in ft.columns) {
                if (ft.columns[c].hide[breakpoint]) {
                    return true
                }
            }
            return false
        };
        ft.resize = function() {
            var $table = $(ft.table);
            var info = {
                width: $table.width(),
                height: $table.height(),
                viewportWidth: ft.getViewportWidth(),
                viewportHeight: ft.getViewportHeight(),
                orientation: null
            };
            info.orientation = info.viewportWidth > info.viewportHeight ? "landscape" : "portrait";
            if (info.viewportWidth < info.width) info.width = info.viewportWidth;
            if (info.viewportHeight < info.height) info.height = info.viewportHeight;
            var pinfo = $table.data("footable_info");
            $table.data("footable_info", info);
            if (!pinfo || pinfo && pinfo.width && pinfo.width != info.width || pinfo && pinfo.height && pinfo.height != info.height) {
                var current = null,
                    breakpoint;
                for (var i = 0; i < ft.breakpoints.length; i++) {
                    breakpoint = ft.breakpoints[i];
                    if (breakpoint && breakpoint.width && info.width <= breakpoint.width) {
                        current = breakpoint;
                        break
                    }
                }
                var breakpointName = current == null ? "default" : current["name"];
                var hasBreakpointFired = ft.hasBreakpointColumn(breakpointName);
                $table.removeClass("default breakpoint").removeClass(ft.breakpointNames).addClass(breakpointName + (hasBreakpointFired ? " breakpoint" : "")).find("> thead > tr > th").each(function() {
                    var data = ft.columns[$(this).index()];
                    var count = data.index + 1;
                    var $column = $table.find("> tbody > tr > td:nth-child(" + count + "), > tfoot > tr > td:nth-child(" + count + "), > colgroup > col:nth-child(" + count + ")").add(this);
                    if (data.hide[breakpointName] == false) $column.show();
                    else $column.hide()
                }).end().find("> tbody > tr.footable-detail-show").each(function() {
                    ft.createOrUpdateDetailRow(this)
                });
                $table.find("> tbody > tr.footable-detail-show:visible").each(function() {
                    var $next = $(this).next();
                    if ($next.hasClass("footable-row-detail")) {
                        if (breakpointName == "default" && !hasBreakpointFired) $next.hide();
                        else $next.show()
                    }
                });
                ft.raise("footable_breakpoint_" + breakpointName, {
                    info: info
                })
            }
        };
        ft.toggleDetail = function(actualRow) {
            var $row = $(actualRow),
                created = ft.createOrUpdateDetailRow($row.get(0)),
                $next = $row.next();
            if (!created && $next.is(":visible")) {
                $row.removeClass("footable-detail-show");
                $next.hide()
            } else {
                $row.addClass("footable-detail-show");
                $next.show()
            }
        };
        ft.createOrUpdateDetailRow = function(actualRow) {
            var $row = $(actualRow),
                $next = $row.next(),
                $detail, values = [];
            if ($row.is(":hidden")) return;
            $row.find("> td:hidden").each(function() {
                var column = ft.columns[$(this).index()];
                if (column.ignore == true) return true;
                values.push({
                    name: column.name,
                    value: ft.parse(this, column),
                    display: $.trim($(this).html())
                })
            });
            var colspan = $row.find("> td:visible").length;
            var exists = $next.hasClass("footable-row-detail");
            if (!exists) {
                $next = $('<tr class="footable-row-detail"><td class="footable-cell-detail"><div class="footable-row-detail-inner"></div></td></tr>');
                $row.after($next)
            }
            $next.find("> td:first").attr("colspan", colspan);
            $detail = $next.find(".footable-row-detail-inner").empty();
            opt.createDetail($detail, values);
            return !exists
        };
        ft.raise = function(eventName, args) {
            args = args || {};
            var def = {
                ft: ft
            };
            $.extend(true, def, args);
            var e = $.Event(eventName, def);
            if (!e.ft) {
                $.extend(true, e, def)
            }
            $(ft.table).trigger(e);
            return e
        };
        ft.init();
        return ft
    }
})(jQuery, window);