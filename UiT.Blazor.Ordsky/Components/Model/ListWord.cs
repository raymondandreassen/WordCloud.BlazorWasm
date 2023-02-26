namespace Gutan.BlazorWasm.Ordsky.Components.Model
{
    public class ListWord
    {
        public string Word { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
        public WordType Wordtype { get; set; } = WordType.Normal;
    }

    public enum WordType
    {
        Normal, 
        Combined, 
        Noise
    }
}
