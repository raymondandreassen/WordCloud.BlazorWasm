using MudBlazor;
using System.Reflection;

namespace UiT.Components.DI
{


    public class MyUIManager
    {
        // TODO: Sjekk ut ALT her, ny typo, etc. 

        #region Language      
        public string CurrentLanguageIcon { get { return CurrentLanguageObject.CultureIcon; } }
        public string CurrentLanguageName { get { return CurrentLanguageObject.CultureCode; } }
        public MyCulture CurrentLanguageObject { get; set; } = SupportedCulturesArray[0];
        public void SetUserLanguage(string lang)
        {
            MyCulture? c = SupportedCulturesArray.Find(c => c.CultureCode.Equals(lang));
            if (c is not null)
                CurrentLanguageObject = c;
        }
        public class MyCulture
        {
            public string CultureCode { get; set; } = "nb-NO";
            public string CultureIcon { get; set; } = "fi fi-no";
        }
        public readonly static List<MyCulture> SupportedCulturesArray = new()
        {
            new MyCulture { CultureCode = "nb-NO", CultureIcon = "fi fi-no" },
            new MyCulture { CultureCode = "en-US", CultureIcon = "fi fi-us" },
            new MyCulture { CultureCode = "en-GB", CultureIcon = "fi fi-gb" },
            new MyCulture { CultureCode = "sv-SE", CultureIcon = "fi fi-se" },
            new MyCulture { CultureCode = "de-DE", CultureIcon = "fi fi-de" }
        };
        public static string[] SupportedCultures
        {   // Get only first column in array
            get { return SupportedCulturesArray.Select(x => x.CultureCode).ToArray(); }
        }
        #endregion

        #region Global StateHasChanged event
        public event Action RefreshRequested = delegate { }; // TODO: = delegate er kanskje ikke korrekt
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
        #endregion

        #region NavDrawerUI
        public bool NavDrawerOpen { get; set; } = true;
        public void NavDrawerToggle()
        {
            NavDrawerOpen = !NavDrawerOpen;
        }
        #endregion

        #region Theming
        // Default theme: https://mudblazor.com/customization/default-theme#mudtheme
        public bool IsDarkTheme { get; set; } = false;

        private readonly MudTheme theme = new()
        {
            Palette = new Palette()
            {
                //    Black                       = "#272c34ff",
                //    BackgroundGrey              = "#27272f",
                //    Surface                     = "#ffffff",
                //    Background                  = "#faf9f8",
                //    DrawerText                  = "rgba(44,43,42,255)",
                //    DrawerBackground            = "#f0f0f0",
                //    DrawerIcon                  = "rgba(0,0,0, 0.50)",
                AppbarBackground = "#043348",                        // App bar
                AppbarText = "rgba(255,255,255, 0.70)"        // App bar text
                                                               //    TextPrimary                 = "rgba(0,0,0, 0.70)",
                                                               //    //TextSecondary             = "rgba(255,255,255, 0.50)",
                                                               //    TextSecondary               = "rgba(60,60,60, 0.50)",           // f.eks. inne i tekstbokser
                                                               //    ActionDefault               = "#adadb1",
                                                               //    ActionDisabled              = "rgba(255,255,255, 0.26)",
                                                               //    ActionDisabledBackground    = "rgba(255,255,255, 0.12)"
                                                               
            },

            //Shadows = new Shadow(),

            //ZIndex = new ZIndex(),

            LayoutProperties = new LayoutProperties()
            {
                // DrawerWidth             = "",        // Depricated
                // DrawerMiniWidthLeft     = "50px", 
                // DrawerMiniWidthRight    = "", 
                // DrawerHeightTop         = "", 
                // DrawerHeightBottom      = "", 
                DrawerWidthLeft = "250px",     // Størrelse på meny
                DrawerWidthRight = "1100px",    // Størrelse på drawer til høyre
                AppbarHeight = "48px"      // Høyden på logolinjen på topp
                // AppbarMinHeight         = "",       // Depricated
                // DefaultBorderRadius     = ""
                
            },
            //PaletteDark = new PaletteDark(),

            Typography = new Typography()
            {
                Default = new Default() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1rem", FontWeight = 400, LineHeight = 1.430, LetterSpacing = "-0.01em", TextTransform = "none" },
                H1 = new H1() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "2.0rem", FontWeight = 300, LineHeight = 1.167, LetterSpacing = "-0.01em", TextTransform = "none" },
                H2 = new H2() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.8rem", FontWeight = 300, LineHeight = 1.167, LetterSpacing = "-0.01em", TextTransform = "none" },
                H3 = new H3() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.6rem", FontWeight = 300, LineHeight = 1.200, LetterSpacing = "-0.01em", TextTransform = "none" },
                H4 = new H4() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.4rem", FontWeight = 300, LineHeight = 1.235, LetterSpacing = "-0.01em", TextTransform = "none" },
                H5 = new H5() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.3rem", FontWeight = 300, LineHeight = 1.334, LetterSpacing = "-0.01em", TextTransform = "none" },
                H6 = new H6() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.2rem", FontWeight = 300, LineHeight = 1.600, LetterSpacing = "-0.01em", TextTransform = "none" },

                Subtitle1 = new Subtitle1() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.15rem", FontWeight = 500, LineHeight = 1.750, LetterSpacing = ".00938em", TextTransform = "none" },
                Subtitle2 = new Subtitle2() { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.0rem",  FontWeight = 500, LineHeight = 1.570, LetterSpacing = ".01em", TextTransform = "none" },
                Body1 =     new Body1()     { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.0rem",  FontWeight = 400, LineHeight = 0.95, LetterSpacing = ".00938em", TextTransform = "none" },
                Body2 =     new Body2()     { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "0.9rem",  FontWeight = 400, LineHeight = 0.85, LetterSpacing = ".01071em", TextTransform = "none" },
                Button =    new Button()    { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "1.0rem",  FontWeight = 500, LineHeight = 0.0, LetterSpacing = ".03057em", TextTransform = "none" },
                Caption =   new Caption()   { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "0.75rem", FontWeight = 400, LineHeight = 0.0, LetterSpacing = ".02333em", TextTransform = "none" },
                Overline =  new Overline()  { FontFamily = new[] { "Open Sans", "Roboto", "Helvetica", "Arial", "sans-serif" }, FontSize = "0.75rem", FontWeight = 600, LineHeight = 0.0, LetterSpacing = ".06333em", TextTransform = "none" }
            }
        };

        public MudTheme GetTheme()
        {
            if (!IsDarkTheme) // Hvis Light/Dark skal "perfeksjoneres"
            {
            }
            else
            {
            }

            return theme;
        }

        #endregion
    }
}