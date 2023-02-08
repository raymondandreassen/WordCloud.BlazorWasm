using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using UiT.Blazor.Ordsky.Components.Model;
using UiT.Blazor.Ordsky.Pages;
using static MudBlazor.Colors;

namespace UiT.Blazor.Ordsky.Components
{
    public class MyOrdsky
    {
        // https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md
        public MyOrdsky(IJSRuntime js)
        {
            this.js = js;
            MyOrdskyLoader.RandomizeWords(WordList, 25);
        }

        IJSRuntime js { get; set; } = null!;

        public async Task GetJsInfo()
        {
            WordCloudIsSupported = await js.InvokeAsync<bool>("WordCloud.isSupported", null);
            WordCloudMinFontSize = "";
            WordCloudWrapperVersion = await js.InvokeAsync<string>("WordCloudWrapperVersion");
        }

        // Ordliste Kontroll
        public List<ListWord> WordList { get; set; } = new List<ListWord>();
        public void ClearWords() => WordList.Clear();
        public void NewRandomList() => MyOrdskyLoader.RandomizeWords(WordList, 5);
        public void FjernOrd(ListWord w)
        {
            WordList.Remove(w);
        }

        // Ordliste konfig
        public bool DenseTabell { get; set; } = true;

        public object[][] WordListArray()
        {
            return WordList.Select(x => new object[] { x.Word, x.Count.ToString() }).ToArray();
        }


        // JS kommunikasjon 
        public CanvasColor CanvasBackgroundColor { get; set; } = MyOrdskyLoader.LoadCanvasColors().First();
        public CanvasSize CanvasSize { get; set; }
        public double CanvasGridsize { get; set; } = 0.25;
        
        private bool shrinktofit = false;
        private bool drawoutofbounds = false;
        public bool CanvasShrinkToFit { get { return shrinktofit; } 
            set 
            { 
                shrinktofit = value;
                if (shrinktofit) drawoutofbounds = false;
            } 
        } 
        public bool CanvasDrawOutofBounds { get { return drawoutofbounds; } 
            set 
            { 
                drawoutofbounds = value;
                if (drawoutofbounds) shrinktofit = false;
            } 
        } 
        public CanvasShape CanvasShape { get; set; } = MyOrdskyLoader.LoadCanvasShape().First();
        public decimal CanvasEllipticity { get; set; } = 1;
        public decimal CanvasRotateRatio { get; set; } = 0;

        public string WordCloudWrapperVersion { get; set; } = string.Empty;

        public bool WordCloudIsSupported { get; set; } = false;
        public string WordCloudMinFontSize { get; set; } = string.Empty;


        public async Task Wc_Draw()
        {
            try
            {
                object[][] ordliste = WordListArray();
                await js.InvokeVoidAsync("SetWordlist",             (object)ordliste);
                await js.InvokeVoidAsync("SetBackgroundColor",      (object)CanvasBackgroundColor.Color);

                await js.InvokeVoidAsync("SetGridSize",             (object)CanvasGridsize);
                await js.InvokeVoidAsync("SetShrinkToFit",          (object)CanvasShrinkToFit);
                await js.InvokeVoidAsync("SetDrawOutOfBound",       (object)CanvasDrawOutofBounds);
                await js.InvokeVoidAsync("SetShape",                (object)CanvasShape.Name);
                await js.InvokeVoidAsync("SetEllipticity",          (object)CanvasEllipticity);
                await js.InvokeVoidAsync("SetRotateRatio",          (object)CanvasRotateRatio);

                await js.InvokeVoidAsync("drawWordCloud");

                /*
                    function SetBackgroundColor (color)             { _backgroundColor = color;     }
                    function SetWordlist        (ordliste)          { _ordliste = ordliste; }
                    function SetGridSize        (gridsize)          { _gridSize = gridsize; }
                    function SetDrawOutOfBound  (drawOutOfBound)    { _drawOutOfBound = drawOutOfBound; }
                    function SetShape           (shape)             { _shape = shape; }
                    function SetEllipticity     (ellipticity)       { _ellipticity = ellipticity; }
                    function SetRotateRatio     (rotateRatio)       { _rotateRatio = rotateRatio; }
                */
            }
            catch (JSException e)
            {
                Console.WriteLine($"Error Message: {e.Message}");
            }
        }
    }





    #region WordList for test
    //object[][] ordliste = new[] {
    //    new[] {"Hei", "54"},
    //    new[] {"Tromsø", "62"},
    //    new[] {"UiT", "130"},
    //    new[] {"Raymond", "76"},
    //    new[] {"Espen", "64"},
    //    new[] {"Gunhild", "43"},
    //    new[] {"Microsoft", "51"},
    //    new[] {"Idar", "37"},
    //    new[] {"Nils", "35"},
    //    new[] {"A-Team", "49"},
    //    new[] {"Fagkompetanse", "66"},
    //    new[] {"Handsome fuckers", "58"}
    //};
    #endregion

}
