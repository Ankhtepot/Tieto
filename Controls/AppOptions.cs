using Classes;
//Class with App settings
namespace Controls
{ //App options storage
    public static class AppOptions
    {
        public static ICipher CryptingMethod { get; set; }
        private static int keyValue;
        public static string LbKeyText { get; set; }
        public static bool NudKeyVisible { get; set; }
        public static int NudKeyMinimum { get; set; }
        public static int NudKeyMaximum { get; set; }
        public static int KeyValue {
            get => keyValue;
            set 
            {
                if (CryptingMethod is CipherKeyBase)
                {
                    ((CipherKeyBase)CryptingMethod).KeyValue = value;
                    keyValue = value;
                }
            }
        }
    }
}
