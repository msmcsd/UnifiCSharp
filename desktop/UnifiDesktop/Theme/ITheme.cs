using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiDesktop.Theme
{
    internal interface ITheme
    {
        FontFamily FontFamily { get; }

        Pallete Pallete { get;}

        ThemeMode Mode { get; }


        //#region List Items
        //public Color SelectedListemItemForeColor { get; set; }

        //public Color SelectedListemItemBackColor { get; set; }

        //public Color NonSelectedListemItemForeColor { get; set; }

        //public Color NonSelectedListemItemBackColor { get; set; }

        //public int ListItemFontSize { get; set; }

        //#endregion
    }

    public class Pallete
    {
        public PalleteDetail Primary { get; set; }

        public PalleteDetail Secondary { get; set; }

        public PalleteDetail Error { get; set; }

        public PalleteDetail Warning { get; set; }

        public PalleteDetail Info { get; set; }
    }

    public class PalleteDetail 
    {
        public Color Main { get; set; }
        
        public Color Light { get; set; }
        
        public Color Dark { get; set; }
    }

    public enum ThemeMode
    {
        Light,
        Dark
    }
}
