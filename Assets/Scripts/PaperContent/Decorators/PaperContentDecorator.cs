using System;
using System.Collections.Generic;
using System.Linq;

abstract class PaperContentDecorator : IPaperContentProvider
{
    public IPaperContentProvider PaperContentProvider { get; set; }

    public PaperContentDecorator(IPaperContentProvider contentProvider)
    {
        PaperContentProvider = contentProvider;
    }
    public virtual List<string> GetContent()
    {
        return PaperContentProvider.GetContent();
    }
}
