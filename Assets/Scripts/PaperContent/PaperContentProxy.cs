using System;
using System.Collections.Generic;

class PaperContentProxy : IPaperContentProvider
{
    public bool NeedUpdate { get; set; } = false;
    private PaperContent paperContent;

    public PaperContentProxy(PaperContent paperContent)
    {
        this.paperContent = paperContent;
    }

    public List<string> GetContent()
    {
        if (paperContent.Content.Count == 0 || NeedUpdate)
        {
            paperContent.ParseData("https://baconipsum.com/api/?type=all-meat&sentences=1&start-with-lorem=1");
        }
        return paperContent.Content;
    }
}
