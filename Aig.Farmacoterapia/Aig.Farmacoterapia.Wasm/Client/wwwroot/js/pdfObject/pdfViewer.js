window.webviewerFunctions = {
    initWebViewer: function (source, viewer) {
        var options = {};
        PDFObject.embed(source, viewer, options);
    }
};
