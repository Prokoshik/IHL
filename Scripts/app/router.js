
define(['kendo'],
    function(kendo) {
        var router = new kendo.Router(),
            layout = new kendo.Layout("<div id='content'></div>");

        layout.render($("#app"));
        
        router.route("/", function () {
            require(['text!/home/index'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/home/index", function () {
            require(['text!/home/index'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/home/Scope", function () {
            require(['text!/home/Scope'], function (view) {
                loadView(null, view);
            });
        });
       
        router.route("/home/Client", function () {
            require(['text!/home/Client'], function (view) {
                loadView(null, view);
            });
        });
        router.route("/home/ClientApplicationDev", function () {
            require(['text!/home/ClientApplicationDev'], function (view) {
                loadView(null, view);
            });
        });
        router.route("/home/StackTechnology", function () {
            require(['text!/home/StackTechnology'], function (view) {
                loadView(null, view);
            });
        });
        var loadView = function(viewModel, view, delegate) {
            var kendoView = new kendo.View(view, { model: viewModel });
            layout.showIn("#content", kendoView);
          /*  kendo.fx($("#content")).slideInRight().reverse().then(function() {
                layout.showIn("#content", kendoView);

                if (delegate != undefined)
                    delegate();

                kendo.fx($("#content")).slideInRight().play();
            });*/
        };

        return router;
    });

