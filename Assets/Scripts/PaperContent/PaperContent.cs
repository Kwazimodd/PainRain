using System;
using System.Collections.Generic;
class PaperContent : IPaperContentProvider
{
    public List<string> Content { get; set; } = new List<string>();
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
                var value = webClient.DownloadString(from);
                Content.Add(value);
            }
        }
        //https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1
    }
}
