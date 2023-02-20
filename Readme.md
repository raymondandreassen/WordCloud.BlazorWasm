# Ordsky
På engelsk Wordcloud, men de kaller det gjerne Tag Cloud.  
* Bruker Github workflow, fra master branch, for å deploye til Azure Static Website. 
* [App link: Ordsky](https://mango-meadow-0d4421803.2.azurestaticapps.net/)

Status på denne appen: **UNDER UTVIKLING**, jobber på denne når jeg kjeder meg.  
Bidra gjerne. 

## Sentrale komponenter
* [Wordcloud2.js](https://github.com/timdream/wordcloud2.js)
* MudBlazor 
* Faker.Net

## Flyten
```
Flyten i alt kan forenkles til: 
Div sider for å lage en liste over ["antall", "ord"] 
-> Som bygges opp i komponenten MyOrdsky 
-> Som sender alt til wrapper ordsky.js 
-> wordcloud2.js står for magien
```
## Brukers opplevelse, slik jeg tenkte det
* "/Index", Bruker kopierer inn en tekst
* "/Uttrykk", bruker kan kurere en liste med uttrykk bruker ønsker å ta med. Dvs. flere sammensatte ord, eksempler "Tromsø kommune", "Sintef forskning", "Skatte etaten". 
* "/Noise", ord bruker IKKE ønsker med, f.eks. "jeg, deg, om, og, å, etc."
* Begge listenene over burde kunne lagres offline. 
* "/Ordliste", liste over ord den har funnet eller bruker har lagt inn manuelt, med antall. 
* "/Ordsky", generering av ordskyen. 
* "/Konfig", alt som har med konfigurasjon av ordskyen å gjøre. 

## Kode 
I sin enkelthet, så handler alt om å fore opp MyOrdsky.  
``` 
[Inject] Components.MyOrdsky Ordsky { get; set; } = null!;
``` 

Den neste er wordcloud2.js. 
* [Github](https://github.com/timdream/wordcloud2.js)
* [Api, på Github](https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md)
* Denne wrappes av ordsky.js, som mottar og holder på alle parametere, som oversendes av "MyOrdsky".

## For oppgaver, se Issues. 
Listen under er skal flyttes til Issues, når jeg får tid.  
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
