using System;
using System.Drawing;

namespace visualnovella
{
    public class NovellaPage
    {
        public string Dialog { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public Bitmap Person { get; set; }
        public Bitmap Background { get; set; }
        public Point CodeEditorLocation { get; set; }
        public PageType PageType { get; set; }
        public Tuple<NovellaPage[], NovellaPage[]> Options { get; set; }
        public NovellaPage(string dialog, Bitmap person, Bitmap background, string location)
        { 
            Dialog = dialog;
            Person = person;
            Background = background;
            PageType = PageType.Text;
            Location = location;
        }
        public NovellaPage(string dialog, Bitmap person, Bitmap background, string code, Point codeEditorLocation, string location)
        {
            Dialog = dialog;
            Person = person;
            Background = background;
            Code = code;
            CodeEditorLocation = codeEditorLocation;
            PageType = PageType.Code;
            Location = location;
        }
        public NovellaPage(string title, string location) 
        { 
            Title = title;
            PageType = PageType.Empty;
            Location = location;
        }
    }
}
