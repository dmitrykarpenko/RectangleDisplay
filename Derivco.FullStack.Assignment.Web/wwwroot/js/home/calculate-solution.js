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

    var totalWidth = rectangles[rectangles.length - 1].Left + rectangles[rectangles.length - 1].Width;
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
}