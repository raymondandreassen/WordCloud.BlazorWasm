namespace UiT.Blazor.Ordsky.Components
{
    public class MyOrdskyLoader
    {
        public static void RandomizeWords(List<ListWord> WordList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                WordList.Add(new ListWord { Word = Faker.Address.City(), Count = Faker.RandomNumber.Next(20) });
                WordList.Add(new ListWord { Word = Faker.Address.Country(), Count = Faker.RandomNumber.Next(40) });
            }
        }

        public static List<CanvasSize> LoadCanvasSizes()
        {
            return new List<CanvasSize>
            {
                new CanvasSize { Name = "Liten kvadrat  (400 x 400)", Width = 400, Height = 400 },
                new CanvasSize { Name = "Medium kvadrat (600 x 600)", Width = 600, Height = 600 },
                new CanvasSize { Name = "Stort kvadrat  (1024 x 1024)", Width = 1024, Height = 1024 },
                new CanvasSize { Name = "Stort landskap (2048 x 1024)", Width = 2048, Height = 1024 }
            };
        }
    }
}
