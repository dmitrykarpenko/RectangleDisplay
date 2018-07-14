function drawRectangles(stageWidth, stageHeight, elementName, rectangles) {
    var renderer = PIXI.autoDetectRenderer(
        stageWidth,
        stageHeight,
        {
            antialias: true,
            transparent: false,
            backgroundColor: 0xFFFFFF,
            view: document.getElementById(elementName)
        });

    var stage = new PIXI.Container();

    stage.position.y = renderer.height / renderer.resolution;
    stage.scale.y = -1;

    var graphics = new PIXI.Graphics();
    graphics.beginFill(0xFFFFFF);
    graphics.lineStyle(1, 0x000000);

    var totalWidth = getTotalWidth(rectangles, elementName);
    var scaleX = stageWidth / totalWidth;
    var scaleY = stageHeight / 30;

    for (var i = 0; i < rectangles.length; i++) {
        var rect = rectangles[i];
        graphics.drawRect(
            rect.Left * scaleX,
            rect.Bottom * scaleY,
            rect.Width * scaleX,
            rect.Height * scaleY);
    }

    stage.addChild(graphics);

    renderer.render(stage);

    function getTotalWidth(rectangles, elementName) {
        return elementName == "input" ? getLast(rectangles).Left + getLast(rectangles).Width
             : elementName == "output" ? rectangles[0].Width
             : null;

        function getLast(items) {
            return items[items.length - 1];
        }
    }
}

