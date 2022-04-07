using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
using HtmlAgilityPack;



// For self-signed certificate
#if true
var EndPoint = "https://192.168.1.1/";
var httpClientHandler = new HttpClientHandler();
httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
{
    return true;
};
using var hc = new HttpClient(httpClientHandler) { BaseAddress = new Uri(EndPoint) };
string htmlStr = await hc.GetStringAsync(EndPoint);
#endif

//using var hc = new HttpClient();
//string htmlStr = await hc.GetStringAsync("https://www.yahoo.co.jp/");

if (htmlStr == null)
{
    Console.WriteLine("htmlStr is null");
    return;
}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(htmlStr);
var node = htmlDoc.DocumentNode.SelectSingleNode("/html/head/title");
Console.WriteLine($"title: {node.InnerText}");

Console.WriteLine("---------------------------------------------------------");

var nodes = htmlDoc.DocumentNode.SelectNodes("/html/head/meta");
if (nodes == null)
    return;

foreach (var n in nodes)
{
    foreach (HtmlAttribute attr in n.Attributes)
    {
        Console.WriteLine(attr.Name + " " + attr.Value);
    }
}

Console.WriteLine("---------------------------------------------------------");

nodes = htmlDoc.DocumentNode.SelectNodes("//span");
if (nodes == null)
    return;

foreach (var n in nodes)
{
    Console.WriteLine(n.InnerText);
}