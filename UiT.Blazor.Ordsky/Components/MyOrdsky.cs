using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Runtime.Intrinsics.X86;
using System;
using Gutan.BlazorWasm.Ordsky.Components.Model;
using Gutan.BlazorWasm.Ordsky.Pages;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Colors;

namespace Gutan.BlazorWasm.Ordsky.Components
{
    public class MyOrdsky
    {
        // https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md
        public MyOrdsky(IJSRuntime js)
        {
            this.Js = js;
        }
        IJSRuntime Js { get; set; } = null!;

        public string Text { get; set; } = "";

        // Ordliste Kontroll
        public List<ListWord> WordList { get; set; } = new List<ListWord>();
        public bool SorterOrd { get; set; } = true;

        public void WordListClear()
        {
            WordList.Where(c=> c.Wordtype == WordType.Normal).ToList().ForEach(c => WordList.Remove(c));    
        }

        public IEnumerable<ListWord> CombinedWords { get { return WordList.Where(c => c.Wordtype == WordType.Combined).OrderBy(c => c.Word).ToArray(); } }
        public IEnumerable<ListWord> CloudWords { get { return WordList.Where(c => c.Wordtype == WordType.Normal).OrderBy(c => c.Word).ToArray(); } }

        public IEnumerable<ListWord> NoiseWords { get { return WordList.Where(c => c.Wordtype == WordType.Noise).OrderBy(c => c.Word).ToArray(); } }
        internal ListWord? GetWordListItem(string sentence)
        {
            return WordList.FirstOrDefault(c=>c.Word.Equals(sentence, StringComparison.OrdinalIgnoreCase));
        }


        public object[][] WordListArray()
        {
            if(SorterOrd)
                return WordList.Where(c=>c.Wordtype == WordType.Normal || c.Wordtype == WordType.Combined).OrderByDescending( c => c.Count).Select(x => new object[] { x.Word, x.Count.ToString() }).ToArray();
            else
                return WordList.Where(c=>c.Wordtype == WordType.Normal || c.Wordtype == WordType.Combined).Select(x => new object[] { x.Word, x.Count.ToString() }).ToArray();
        }


        // JS kommunikasjon 
        public string CanvasBackgroundColor
        {
            get;
            set;
        } = MyOrdskyLoader.DefaultCanvasColor;
        public CanvasSize CanvasSize { get; set; }
        public double CanvasGridsize { get; set; } = 0.25;

        private bool shrinktofit = false;
        private bool drawoutofbounds = false;
        public bool CanvasShrinkToFit
        {
            get { return shrinktofit; }
            set
            {
                shrinktofit = value;
                if (shrinktofit) drawoutofbounds = false;
            }
        }
        public bool CanvasDrawOutofBounds
        {
            get { return drawoutofbounds; }
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
                await Js.InvokeVoidAsync("SetWordlist", (object)ordliste);
                await Js.InvokeVoidAsync("SetBackgroundColor", (object)CanvasBackgroundColor);

                await Js.InvokeVoidAsync("SetGridSize", (object)CanvasGridsize);
                await Js.InvokeVoidAsync("SetShrinkToFit", (object)CanvasShrinkToFit);
                await Js.InvokeVoidAsync("SetDrawOutOfBound", (object)CanvasDrawOutofBounds);
                await Js.InvokeVoidAsync("SetShape", (object)CanvasShape.Name);
                await Js.InvokeVoidAsync("SetEllipticity", (object)CanvasEllipticity);
                await Js.InvokeVoidAsync("SetRotateRatio", (object)CanvasRotateRatio);

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
}

