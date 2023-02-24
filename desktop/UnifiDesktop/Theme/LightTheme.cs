using System;
using System.Drawing;

namespace UnifiDesktop.Theme
{
    internal class LightTheme : ITheme
    {
        private static readonly Lazy<LightTheme> lazy = new Lazy<LightTheme>(() => new LightTheme());

        public static LightTheme Theme => lazy.Value;

        public FontFamily FontFamily
        {
            get
            {
                return null;
            }
        }
        public Pallete Pallete 
        {
            get
            {
                return null;
            }
        }

        public ThemeMode Mode => ThemeMode.Light;
    }
}
