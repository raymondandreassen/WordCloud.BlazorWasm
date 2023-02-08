# Uit Ordsky
P� engelsk Wordcloud, men de kaller det gjerne Tag Cloud.  

* [Github Repo: UiT.WordCloud.BlazorServer](https://github.com/UiT-ITA/UiT.WordCloud.BlazorServer/tree/master/UiT.Blazor.Ordsky)
* 

## Prinsipp
En tekst (Index siden) blir kopiert inn.  
Den blir filterert mot "Uttrykk", som er flere ord man gjerne �nsker � finne. Setning om man vil. Alle uttrykk man finner skal inn i listen, med antall.  
Det resterende blir filtrert mot "St�y", hvor alle ord oppgitt der fjernes i det gjenst�ende.  
Resten blir telt opp og lagt til i listen. 

## Kode 
Det er i realiten to komponenter som fores opp. MyOrdsky holder orden p� alle ord og innstillinger. 
``` 
[Inject] Components.MyOrdsky Ordsky { get; set; } = null!;
``` 

Den neste er wordcloud2.js. 
* [Github](https://github.com/timdream/wordcloud2.js)
* [Api, p� Github](https://github.com/timdream/wordcloud2.js/blob/gh-pages/API.md)