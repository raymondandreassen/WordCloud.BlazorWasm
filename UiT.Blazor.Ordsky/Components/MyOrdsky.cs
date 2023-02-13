using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Runtime.Intrinsics.X86;
using System;
using UiT.Blazor.Ordsky.Components.Model;
using UiT.Blazor.Ordsky.Pages;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Colors;

namespace UiT.Blazor.Ordsky.Components
{
    public class MyOrdsky
    {
        // https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md
        public MyOrdsky(IJSRuntime js)
        {
            this.Js = js;
            MyOrdskyLoader.RandomizeWords(WordList, 100);
        }

        IJSRuntime Js{ get; set; } = null!;

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
        public bool SorterOrd { get; set; } = false;
        public object[][] WordListArray()
        {
            if(SorterOrd)
                return WordList.OrderByDescending( c => c.Count).Select(x => new object[] { x.Word, x.Count.ToString() }).ToArray();
            else
                return WordList.Select(x => new object[] { x.Word, x.Count.ToString() }).ToArray();
        }


        // JS kommunikasjon 
        public string CanvasBackgroundColor { 
            get; 
            set; } = MyOrdskyLoader.DefaultCanvasColor;
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

        public string CanvasFont { get; set; } = "Times, serif";
        public string CanvasFontWeight { get; set; } = "normal";

        public decimal CanvasMinFontSize { get; set; } = 0;
        public decimal CanvasWeightFactor { get; set; } = 0;
        public decimal CanvasMinRotation { get; set; } = 0;
        public decimal CanvasMaxRotation { get; set; } = 0;
        public decimal CanvasRotasjonssteg { get; set; } = 0;
        public decimal CanvasRotasjonssannsynlighet { get; set; } = 0;

        public int CanvasOriginDiffW { get; set; } = 800; // Ingen konfig
        public int CanvasOriginDiffH { get; set; } = 700; // Ingen konfig

        public async Task Wc_Draw()
        {
            try
            {
                object[][] ordliste = WordListArray();
                await Js.InvokeVoidAsync("SetWordlist",             (object)ordliste);
                await Js.InvokeVoidAsync("SetBackgroundColor",      (object)CanvasBackgroundColor);

                await Js.InvokeVoidAsync("SetGridSize",             (object)CanvasGridsize);
                await Js.InvokeVoidAsync("SetShrinkToFit",          (object)CanvasShrinkToFit);
                await Js.InvokeVoidAsync("SetDrawOutOfBound",       (object)CanvasDrawOutofBounds);
                await Js.InvokeVoidAsync("SetShape",                (object)CanvasShape.Name);
                await Js.InvokeVoidAsync("SetEllipticity",          (object)CanvasEllipticity);
                await Js.InvokeVoidAsync("SetRotateRatio",          (object)CanvasRotateRatio);

                await Js.InvokeVoidAsync("SetOrigin",               (object)CanvasOriginDiffW, (object)CanvasOriginDiffH );

                // Gjenstår
                // CanvasMinFontSize
                // CanvasWeightFactor
                // CanvasMinRotation
                // CanvasMaxRotation
                // CanvasRotasjonssteg
                // CanvasRotasjonssannsynlighet
                // CanvasFontWeight
                // CanvasFont

                await Js.InvokeVoidAsync("drawWordCloud");
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
