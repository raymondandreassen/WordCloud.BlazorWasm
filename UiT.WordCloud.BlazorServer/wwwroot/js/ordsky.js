
var ordliste = [['Hei', 20], ['Tromsø', 45], ['UiT', 120], ['Raymond', 60], ['Espen', 40], ['Gunhild', 30], ['Microsoft 365', 90], ['Nils', 25]];

function drawWordCloud() {
    WordCloud(document.getElementById('my_wordcloud_canvas'), { list: ordliste });
}