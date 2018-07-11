using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Class with App settings
namespace Controls { //App options storage
    public static class AppOptions {
        private static ICipher cryptingMethod;
        private static int keyValue;
        private static String lbKeyText;
        private static Boolean nudKeyVisible;
        private static int nudKeyMinimum;
        private static int nudKeyMaximum;

        public static ICipher CryptingMethod { get => cryptingMethod; set => cryptingMethod = value; }
        public static int KeyValue { get => keyValue; set => keyValue = value; }
        public static string LbKeyText { get => lbKeyText; set => lbKeyText = value; }
        public static bool NudKeyVisible { get => nudKeyVisible; set => nudKeyVisible = value; }
        public static int NudKeyMinimum { get => nudKeyMinimum; set => nudKeyMinimum = value; }
        public static int NudKeyMaximum { get => nudKeyMaximum; set => nudKeyMaximum = value; }
    }
}
