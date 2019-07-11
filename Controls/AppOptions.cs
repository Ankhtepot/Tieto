using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Class with App settings
namespace Controls { //App options storage
    public static class AppOptions {
        public static ICipher CryptingMethod { get; set; }
        public static int KeyValue { get; set; }
        public static string LbKeyText { get; set; }
        public static bool NudKeyVisible { get; set; }
        public static int NudKeyMinimum { get; set; }
        public static int NudKeyMaximum { get; set; }
    }
}
