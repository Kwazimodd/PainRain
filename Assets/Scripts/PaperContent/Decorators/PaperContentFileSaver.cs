using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Use with PaperContentProxy or simple PaperContent
/// </summary>
class PaperContentFileSaver : PaperContentDecorator
{
    public static string FileName { get; set; } = "C:\\Users\\User\\Documents\\Unity\\PainRain\\Assets\\papercontent.txt";
    public static bool IsFileExists => File.Exists(FileName);
    public PaperContentFileSaver(IPaperContentProvider contentProvider) : base(contentProvider)
    {

    }

    public override List<string> GetContent()
    {
        var content = PaperContentProvider.GetContent();
        if (!IsFileExists)
        {
            var stream = File.Create(FileName);
            var streamtWriter = new StreamWriter(stream);

            string buff = "";
            foreach (var line in content)
            {
                buff += line + "\n";
            }
            streamtWriter.Write(buff);
            streamtWriter.Close();
        }
        return content;
    }

}
