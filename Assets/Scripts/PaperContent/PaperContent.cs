using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
class PaperContent : IPaperContentProvider
{
    public List<String> Content = new List<string>();
    public int ContentCount { get; set; } = 9;

    public List<string> GetContent()
    {
        return Content;
    }

    public void ParseData(string from)
    {
        using (var webClient = new System.Net.WebClient())
        {
            for (int i = 0; i < ContentCount; i++)
            {
                var json = webClient.DownloadString(from);
                //dynamic stuff = JObject.Parse(json);
                //var value = stuff.message;
                Content.Add(json);
            }
        }
        //https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1
    }
}
