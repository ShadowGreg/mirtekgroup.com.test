using HtmlAgilityPack;

namespace HTMLParse;

//https://vc.ru/u/1389654-machine-learning/748044-7-luchshih-bibliotek-c-dlya-parsinga-veb-stranic-v-2023-godu
public class HTMLRead {
    static HtmlDocument GetDocument(string url) {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        return doc;
    }
    
    // var doc = GetDocument("https://scrapeme.live/shop/"); 
    //
    // HtmlNodeCollection names = doc.DocumentNode.SelectNodes("//a/h2"); 
    // HtmlNodeCollection prices = doc.DocumentNode.SelectNodes("//div/main/ul/li/a/span"); 
    //
    //     for (int i = 0; i < names.Count(); i++){ 
    //     Console.WriteLine("Name: {0}, Price: {1}", names[i].InnerText, prices[i].InnerText); 
    // }
}