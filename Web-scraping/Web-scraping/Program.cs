using System.Net;
using HtmlAgilityPack;

//Console.WriteLine("Hello, World!");


//var wc = new WebClient();
var hc = new HttpClient();

//string htmlStr = wc.DownloadString("https://www.yahoo.co.jp/");
string htmlStr = await hc.GetStringAsync("https://www.yahoo.co.jp/");
if (htmlStr == null)
{
    Console.WriteLine("htmlStr is null");
    return;
}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(htmlStr);
var node = htmlDoc.DocumentNode.SelectSingleNode("/html/head/title");
Console.WriteLine(node.InnerText);

Console.WriteLine("---------------------------------------------------------");


var nodes = htmlDoc.DocumentNode.SelectNodes("/html/head/meta");
foreach (var n in nodes)
{
    foreach(HtmlAttribute attr in n.Attributes)
    {
        Console.WriteLine(attr.Name + " " + attr.Value);
    }
}

Console.WriteLine("---------------------------------------------------------");

nodes = htmlDoc.DocumentNode.SelectNodes("//span");
foreach(var n in nodes)
{
    Console.WriteLine(n.InnerText);
}