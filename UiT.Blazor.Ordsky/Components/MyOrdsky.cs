using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
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



        // Ordliste Kontroll
        public List<ListWord> WordList { get; set; } = new List<ListWord>();
        public void ClearWords() => WordList.Clear();
        public void NewRandomList() => MyOrdskyLoader.RandomizeWords(WordList, 5);


        // Ordliste konfig
        public bool DenseTabell { get; set; } = true;

        public object[][] WordListArray()
        {
            return WordList.Select(x => new object[] { x.Word, x.Count.ToString() }).ToArray();
        }


        // JS kommunikasjon 
        public System.Drawing.Color Wc_BackgroundColor { get; set; } = System.Drawing.ColorTranslator.FromHtml("#ffe0e0");
        public CanvasSize CanvasSize { get; set; }
        public async Task Wc_Draw()
        {
            try
            {
                object[][] ordliste = WordListArray();
                await js.InvokeVoidAsync("SetWordlist", (object)ordliste);
                await js.InvokeVoidAsync("SetBackgroundColor", (object)System.Drawing.ColorTranslator.ToHtml(Wc_BackgroundColor));
                await js.InvokeVoidAsync("drawWordCloud");
            }
            catch (JSException e)
            {
                Console.WriteLine($"Error Message: {e.Message}");
            }
        }
    }

    public class ListWord
    {
        public string Word { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
    }

    public class CanvasSize
    {
        public string Name { get; set; } = string.Empty;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
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
