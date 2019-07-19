using Cipher;
using System;
//Class with App settings
namespace AppOptions
{ //App options storage
    public static class Options
    {
        public static CipherBase CryptingMethod { get; set; }
        public static string LbKeyText { get; set; }
        public static bool NudKeyVisible { get; set; }
        public static int NudKeyMinimum { get; set; }
        public static int NudKeyMaximum { get; set; }

        private static int keyValue;
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
