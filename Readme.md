# Uit Ordsky
På engelsk Wordcloud, men de kaller det gjerne Tag Cloud.  

* [Github Repo: UiT.WordCloud.BlazorServer](https://github.com/UiT-ITA/UiT.WordCloud.BlazorServer/tree/master/UiT.Blazor.Ordsky)
* [Workflows](https://github.com/UiT-ITA/UiT.WordCloud.BlazorServer/actions)
* [Azure resource](https://portal.azure.com/#@UniversitetetiTromso.onmicrosoft.com/resource/subscriptions/115a3ce9-c18d-4dfb-a77f-6d6feaea0252/resourcegroups/ProsjektOrdsky/providers/Microsoft.Web/staticSites/Ordsky/staticsite)
* Ved commit av ny master trigges workflow og det blir bygget en ny, hvis suksess, så deployes den til Azure. 
* [App link](https://mango-meadow-0d4421803.2.azurestaticapps.net/)


## Prinsipp
En tekst (Index siden) blir kopiert inn.  
Den blir filterert mot "Uttrykk", som er flere ord man gjerne ønsker å finne. Setning om man vil. Alle uttrykk man finner skal inn i listen, med antall.  
Det resterende blir filtrert mot "Støy", hvor alle ord oppgitt der fjernes i det gjenstående.  
Resten blir telt opp og lagt til i listen. 

## Kode 
Det er i realiten to komponenter som fores opp. MyOrdsky holder orden på alle ord og innstillinger. 
``` 
[Inject] Components.MyOrdsky Ordsky { get; set; } = null!;
``` 

Den neste er wordcloud2.js. 
* [Github](https://github.com/timdream/wordcloud2.js)
* [Api, på Github](https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md)
* Denne wrappes av ordsky.js, som mottar og holder på alle parametere, som oversendes av "MyOrdsky".

```
Flyten i alt kan forenkles til: 
Div sider -> MyOrdsky -> ordsky.js -> wordcloud2.js
```

## Funksjonalitet
Jo mer av funksjonalitet man fører til klienten, mer funksjonalitet er tilgjengelig.  
My av dette under kan settes pr. ord, men det vil være en helt annen versjon. 

| Status      | Ønsket funksjonalitet | Kommentar | Hvem fikser |
| :---        |    :----:   | :---        |
| Påbegynt      | Spash screen / Loading screen | Stuff man vil ha | Raymond |
| * | Hente WordCloud.isSupported        | Kun for debugging og rapportering      | * |
| * | Hente WordCloud.minFontSize | Kun for debugging og rapportering | * |
| * | Hente ordsky.js versjon | Kun for debugging og rapportering | * |
| * | fontFamily | font to use | * |
| * | fontWeight | font weight to use, can be, normal, bold or 600.. | * |
| * | color | color of the text | * |
| * | minSize | minimum font size to draw on the canvas | * |
| * | weightFactor | function to call or number to multiply for size of each word in the list | * |
| * | clearCanvas | | * |
| Fullført | backgroundColor | color of the background. | Raymond |
| * | Color liste | For bakgrunnsfarger. | |
| * | gridSize | size of the grid in pixels for marking the availability of the canvas | Raymond |
| * | origin | origin of the “cloud” in [x, y] | * |
| Fullført | drawOutOfBound | | Raymond |
| Fullført | shrinkToFit | | Raymond |
| * | drawMask | | * |
| * | maskColor | | * |
| * | maskGapWidth | | * |
| * | minRotation | | * |
| * | maxRotation | | * |
| * | rotationSteps | | * |
| * | rotateRatio | | * |
| Fullført | shape | Det er "subshapes", burde sjekkes ut | Raymond |
| * | Custom shape | | * |
| * | ellipticity | degree of "flatness" of the shape  | * |
