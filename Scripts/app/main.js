﻿require.config({
    paths: {
        // Пакеты
        'jquery': '/scripts/kendo//2013.3.1119/jquery.min',
        'kendo': '/scripts/kendo/2013.3.1119/kendo.web.min',
        'text': '/scripts/text',
        'router': '/scripts/app/router'
    },
    shim: {
        'kendo': ['jquery']
    },
    priority: ['text', 'router', 'app'],
    jquery: '2.0.3',
    waitSeconds: 30
});
require([
  'app'
], function (app) {
    app.initialize();
});