using System.Drawing;

namespace visualnovella
{
    public class NovellaPage
    {
        public string Dialog { get; set; }
        public string Code { get; set; }
        public Bitmap Person { get; set; }
        public Bitmap Background { get; set; }
        public Point CodeEditorLocation { get; set; }
        public PageType PageType { get; set; }
        public NovellaPage(string dialog, Bitmap person, Bitmap background, PageType pageType)
        { 
            Dialog = dialog;
            Person = person;
            Background = background;
            PageType = pageType;
        }
        public NovellaPage(string dialog, Bitmap person, Bitmap background, string code, Point codeEditorLocation, PageType pageType)
        {
            Dialog = dialog;
            Person = person;
            Background = background;
            Code = code;
            CodeEditorLocation = codeEditorLocation;
            PageType = pageType;
        }
    }
}
