using System;
using System.IO;
using System.Collections.Generic;

class PaperContentFromFile : IPaperContentProvider
{
    public List<string> Content { get; set; } = new List<string>();
    public string FileName { get; set; } = PaperContentFileSaver.FileName;
    public List<string> GetContent()
    {
        if (Content.Count == 0)
        {
            var buff = File.ReadAllText(FileName);
            var lines = buff.Split('\n');

            foreach (var line in lines)
            {
                Content.Add(line);
            }
        }
        return Content;
    }
}

