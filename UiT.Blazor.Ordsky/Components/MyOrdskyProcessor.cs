using Gutan.BlazorWasm.Ordsky.Components.Model;
using Gutan.BlazorWasm.Ordsky.Pages;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Gutan.BlazorWasm.Ordsky.Components
{
    public static class MyOrdskyProcessor
    {

        public static void Process(MyOrdsky myOrdsky)
        {
            string text = myOrdsky.Text;

            // Fjern linjeskift og annet
            //text = Regex.Replace(text, @"/^[\w]+$/", " ");
            //text = Regex.Replace(text, @"/^[a-z]+$/i", " ");
            //text = Regex.Replace(text, @"/^[a-z]+$", " ");
            // text = Regex.Replace(text, @"[^\w ]", " ", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"[^\w\s]|[\d]", " ", RegexOptions.IgnoreCase);

            Char[] noise = new Char[] { '\n', '\r', '\t', ':', '.', '(', ')', ';', '«', '»', ',', '-' };
            foreach (Char c in noise)
            {
                text = text.Replace(c, ' ');
            }
            // Sikre at siste ord blir tatt med 
            text = text + " ";

            foreach(var c in myOrdsky.WordList) { c.Count = 0; }



            // Sammensatte ord
            foreach (var sentence in myOrdsky.CombinedWords)
            {
                Console.WriteLine(sentence);

                // Process text
                int index = text.IndexOf(sentence.Word, 0, StringComparison.OrdinalIgnoreCase);
                while(index > 0)
                {
                    sentence.Count++;
                    index = text.IndexOf(sentence.Word, index + 1, StringComparison.OrdinalIgnoreCase);
                }
                text = text.Replace(sentence.Word, " ");
            }


            // Last inn øvrige ord. 
            foreach(string word in text.Split(" ", StringSplitOptions.TrimEntries))
            {
                if (word != " " && word.Length != 0)
                {
                    
                    Console.WriteLine(word);
                    ListWord? theWord = myOrdsky.GetWordListItem(word);
                    if (theWord is null)
                    {   // Ikke sett før
                        theWord = new ListWord()
                        {
                            Word = word,
                            Count = 1
                        };
                        myOrdsky.WordList.Add(theWord);
                    }
                    else
                    {   // Sett tidligere
                        theWord.Count++;
                    }
                }
            }
        }
    }
}
