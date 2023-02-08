using UiT.Blazor.Ordsky.Components.Model;

namespace UiT.Blazor.Ordsky.Components
{
    public class MyOrdskyLoader
    {
        public static void RandomizeWords(List<ListWord> WordList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                WordList.Add(new ListWord { Word = Faker.Address.City(), Count = Faker.RandomNumber.Next(24) +1 });
                WordList.Add(new ListWord { Word = Faker.Address.Country(), Count = Faker.RandomNumber.Next(24) +1 });
            }
        }

        public static List<CanvasSize> LoadCanvasSizes()
        {
            return new List<CanvasSize>
            {
                new CanvasSize { Name = "Liten kvadrat  (400 x 400)",       Width = 400, Height = 400 },
                new CanvasSize { Name = "Medium kvadrat (600 x 600)",       Width = 600, Height = 600 },
                new CanvasSize { Name = "Stort kvadrat  (1024 x 1024)",     Width = 1024, Height = 1024 },
                new CanvasSize { Name = "Stort landskap (2048 x 1024)",     Width = 2048, Height = 1024 }
            };
        }

        //public static List<CanvasColor> LoadCanvasColors()
        //{
        //    return new List<CanvasColor>
        //    { 
        //        new CanvasColor { Name = "Raymonds", Color = "#ffe0e0" },
        //        new CanvasColor { Name = "Svart", Color="#000000" },
        //        new CanvasColor { Name = "Hvit", Color="#ffffff" },
        //        new CanvasColor { Name = "Rød",  Color="#00ff00" },
        //        new CanvasColor { Name = "Rosa", Color="#ff0000" }
        //    };
        //}

        public static string DefaultCanvasColor = "#ffffff";

        public static List<CanvasShape> LoadCanvasShape()
        {
            return new List<CanvasShape>
            { // CanvasShape// Available presents are circle(default ), cardioid(apple or heart shape curve, the most known polar equation), diamond, square, triangle - forward, triangle, (alias of triangle - upright), pentagon, and star.
                new CanvasShape { Name = "circle", DisplayName = "Sirkel" },
                new CanvasShape { Name = "cardioid", DisplayName = "Hjerte/Eple" },
                new CanvasShape { Name = "diamond", DisplayName = "Diamant" },
                new CanvasShape { Name = "square", DisplayName = "Firkant" },
                new CanvasShape { Name = "triangle", DisplayName = "Trekant" },
                new CanvasShape { Name = "pentagon", DisplayName = "xxx" },
                new CanvasShape { Name = "star", DisplayName = "Stjerne" }
            };
        }
    }
}
