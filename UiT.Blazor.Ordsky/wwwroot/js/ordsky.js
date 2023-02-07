

var _backgroundColor = '#c0c0c0';
var _ordliste = [['Hei', 20], ['Tromsø', 45]];
var _gridSize = 0.5;          // size of the grid in pixels for marking the availability of the canvas — the larger the grid size, the bigger the gap between words.
//var _origin = [1024, 1024]; 
var _drawOutOfBound = true; // Kan tegne utenfor canvas
// var _shrinkToFit = true; // set to true to shrink the word so it will fit into canvas. Best if drawOutOfBound is set to false.
var _shape = 'cardioid'; // shape: The shape of the "cloud" to draw. Can be any polar equation represented as a callback function, or a keyword present. 
                        // Available presents are circle(default ), cardioid(apple or heart shape curve, the most known polar equation), diamond, square, triangle - forward, triangle, (alias of triangle - upright), pentagon, and star.
var _ellipticity = 1;  // degree of "flatness" of the shape wordcloud2.js should draw.
var _rotateRatio = 0;  // Probability for the word to rotate. Set the number to 1 to always rotate.

function drawWordCloud() {
    //var ordliste = [['Hei', 20], ['Tromsø', 45], ['UiT', 120], ['Raymond', 60], ['Espen', 40], ['Gunhild', 30], ['Microsoft 365', 90], ['Nils', 25]];
    WordCloud(document.getElementById('my_wordcloud_canvas'), { list: _ordliste, backgroundColor: _backgroundColor, gridSize: _gridSize, drawOutOfBound: _drawOutOfBound, shape: _shape, ellipticity: _ellipticity, rotateRatio: _rotateRatio });
}

function SetBackgroundColor(color)  { _backgroundColor = color;     }
function SetWordlist(ordliste) { _ordliste = ordliste; }
