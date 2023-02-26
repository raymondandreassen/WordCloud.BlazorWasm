
function WordCloudWrapperVersion() {
    return "1.1";
}

var _backgroundColor = '#c0c0c0';
var _ordliste = [['Hei', 20], ['Tromsø', 45]];
var _gridSize = 0.5;                // size of the grid in pixels for marking the availability of the canvas — the larger the grid size, the bigger the gap between words.
var _origin = [800, 500]; 

var _drawOutOfBound = true;         // Kan tegne utenfor canvas
var _shrinkToFit = true;            // set to true to shrink the word so it will fit into canvas. Best if drawOutOfBound is set to false.
var _shape = 'cardioid';            // shape: The shape of the "cloud" to draw. Can be any polar equation represented as a callback function, or a keyword present. 
                                    // Available presents are circle(default ), cardioid(apple or heart shape curve, the most known polar equation), diamond, square, triangle - forward, triangle, (alias of triangle - upright), pentagon, and star.
var _ellipticity = 1;               // degree of "flatness" of the shape wordcloud2.js should draw.
var _rotateRatio = 0;               // Probability for the word to rotate. Set the number to 1 to always rotate.



function SetBackgroundColor(color)          { _backgroundColor = color;     }
function SetWordlist(ordliste)              { _ordliste = ordliste; }
function SetGridSize(gridsize)              { _gridSize = gridsize; }
function SetShrinkToFit(shrinkToFit)        { _shrinkToFit = shrinkToFit; }
function SetDrawOutOfBound(drawOutOfBound)  { _drawOutOfBound = drawOutOfBound; }
function SetShape(shape)                    { _shape = shape; }
function SetEllipticity(ellipticity)        { _ellipticity = ellipticity; }
function SetRotateRatio(rotateRatio)        { _rotateRatio = rotateRatio; }

function SetOrigin(originw, originh) { _origin[0] = originw; _origin[1] = originh; }

function drawWordCloud() {
    //var ordliste = [['Hei', 20], ['Tromsø', 45], ['UiT', 120], ['Raymond', 60], ['Espen', 40], ['Gunhild', 30], ['Microsoft 365', 90], ['Nils', 25]];
    WordCloud(document.getElementById('my_wordcloud_canvas'),
        {
            list: _ordliste,
            origin: _origin,
            backgroundColor: _backgroundColor,
            gridSize: _gridSize,
            shrinkToFit: _shrinkToFit,
            drawOutOfBound: _drawOutOfBound,
            shape: _shape,
            ellipticity: _ellipticity,
            rotateRatio: _rotateRatio
        });
}

//{
//    gridSize: Math.round(16 * $('#canvas').width() / 1024),
//        weightFactor: function (size) {
//            return Math.pow(size, 2.3) * $('#canvas').width() / 1024;
//        },
//    fontFamily: 'Times, serif',
//        color: function (word, weight) {
//            return (weight === 12) ? '#f02222' : '#c09292';
//        },
//    rotateRatio: 0.5,
//        rotationSteps: 2,
//            backgroundColor: '#ffe0e0'
//}