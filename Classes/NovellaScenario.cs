using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visualnovella.Classes
{
    public class NovellaScenario
    {
        public static Bitmap CurrentBackground { get; set; }
        public static Bitmap CurrentCharacter { get; set; }
        public static string CurrentLocation { get; set; }
        public static bool Change { get; set; }
        public List<string> Dialogs {  get; set; }

    }
}
