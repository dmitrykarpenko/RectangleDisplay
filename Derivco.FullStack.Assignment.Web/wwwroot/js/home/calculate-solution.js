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

    var totalWidth = getTotalWidth(rectangles);
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

    function getTotalWidth(rectangles) {
        var leftmost = getLeftmost(rectangles);
        var rightmost = getRightmost(rectangles);

        return rightmost - leftmost;

        // functions are left here as they aren't used anywhere else:

        function getLeftmost(rectangles) {
            var leftmost = rectangles[0].Left;
            for (var i = 1; i < rectangles.length; i++) {
                var rect = rectangles[i];
                if (leftmost > rect.Left) {
                    leftmost = rect.Left;
                }
            }
            return leftmost;
        }

        function getRightmost(rectangles) {
            var rightmost = rectangles[0].Left + rectangles[0].Width;
            for (var i = 1; i < rectangles.length; i++) {
                var rect = rectangles[i];
                var right = rect.Left + rect.Width;
                if (rightmost < right) {
                    rightmost = right;
                }
            }
            return rightmost;
        }
    }
}

