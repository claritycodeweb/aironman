using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIronMan.Utility {
    public static class Constance {
        public static string[] ReservedUrls = { "account", "admin", "error" , "blog", "portfolio"};
        public static List<String> TransitionEffect = new List<String>() { "fade", "slideTop", "slideLeft", "slideRight", "puff", "blind", "scale", "drop" };

        public static string Salt = "3EGmM/oOxh/Eg5/tHiVbbQ==";
    }
}
