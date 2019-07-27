//Class with App settings
using CryptingMethods;
using System.Collections.Generic;

namespace AppOptions
{ //App options storage
    public static class Options
    {
        private static int keyValue;

        public static List<CipherBase> Ciphers { get; set; }
        public static CipherBase CryptingMethod { get; set; }
        public static string LbKeyText { get; set; }
        public static bool NudKeyVisible { get; set; }
        public static int NudKeyMinimum { get; set; }
        public static int NudKeyMaximum { get; set; }

        public static int VBetweenRBs = 20;
        public static int HBetweenRBs = 70;
        public static int basicLeftOffset = 5;
        public static int basicTopOffset = 12;
        public static int maxRbsOnLine = 4;
        public static int KeyValue {
            get => keyValue;
            set 
            {
                if (CryptingMethod is CipherKeyBase 
                    && value >= ((CipherKeyBase)CryptingMethod).KeyMinConstraint 
                    && value <= ((CipherKeyBase)CryptingMethod).KeyMaxConstraint)
                {
                    ((CipherKeyBase)CryptingMethod).KeyValue = value;
                    keyValue = value;
                }
                else
                {
                    keyValue = 0;
                }
            }
        }
    }
}
