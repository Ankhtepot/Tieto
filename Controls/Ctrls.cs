using Classes;
using System.Windows.Forms;

namespace Controls
{
    public static class Ctrls
    {
        public const string CIPHER_WITH_KEY_LABEL_PREFIX = " method Key value ";
        public const string CIPHER_WITHOUT_KEY_LABEL_PREFIX = " method is not using crypting key value.";
        //method to cipher/decipher
        public static string Transform(string input, bool cipherDirection) =>
             cipherDirection ? AppOptions.CryptingMethod.Cipher(input) : AppOptions.CryptingMethod.DeCipher(input);


        //just demonstration of possibility to check if all is ready to Exit app
        public static bool ExitCheck()
        {
            return true;
        }

        //sets AppOptions when crypting method changes
        public static void SetAppOptionsCryptingMethod(CipherBase cipher)
        {

            if (cipher == null)
            { 
                MessageBox.Show("Setting the crypting method failed");
                return;
            }

            AppOptions.CryptingMethod = cipher;
            AppOptions.LbKeyText = buildLbKeyText(AppOptions.CryptingMethod);

            if (AppOptions.CryptingMethod.HasKey)
            {
                CipherKeyBase keyCipherMethod = (CipherKeyBase)AppOptions.CryptingMethod;
                AppOptions.NudKeyVisible = true;
                AppOptions.NudKeyMinimum = keyCipherMethod.KeyMinConstraint;
                AppOptions.NudKeyMaximum = keyCipherMethod.KeyMaxConstraint;
                AppOptions.KeyValue = ((CipherKeyBase)AppOptions.CryptingMethod).KeyValue;
            }
            else
            {
                AppOptions.NudKeyVisible = false;
            }
        }

        //for getting cipher method
        public static CipherBase GetCipher(int methodSelection)
        {
            switch (methodSelection)
            {
                case 1: return new CipherMorse();
                case 2: return new CipherCaesar(AppOptions.KeyValue > 0 ? AppOptions.KeyValue : 1);
                default: return null;
            }
        }

        //Serves as check if chosen crypting method supports keyValue
        public static bool IsCryptingMethodWithKey() =>
            ((CipherBase)AppOptions.CryptingMethod).HasKey ? true : false;

        public static string buildLbKeyText(CipherBase cipher)
        {
            return string.Format($"{cipher.Name}" +
                    (cipher.HasKey ? CIPHER_WITH_KEY_LABEL_PREFIX + $"({((CipherKeyBase)cipher).KeyMinConstraint}" + $" - {((CipherKeyBase)cipher).KeyMaxConstraint})" 
                                   : CIPHER_WITHOUT_KEY_LABEL_PREFIX));
        }
    }
}

