using Cipher;
using System.Windows.Forms;

namespace AppOptions
{
    public static class OptionsService
    {
        //TODO move Strings into seperate file and make them translatable via JSON
        public const string CIPHER_WITH_KEY_LABEL_PREFIX = " method Key value ";
        public const string CIPHER_WITHOUT_KEY_LABEL_PREFIX = " method is not using crypting key value.";
        //method to cipher/decipher
        public static string CipherExecute(string input, bool cipherDirection) =>
             cipherDirection ? Options.CryptingMethod.Cipher(input) : Options.CryptingMethod.DeCipher(input);


        //just demonstration of possibility to check if all is ready to Exit app
        public static bool ExitCheck()
        {
            return true;
        }

        //sets AppOptions when crypting method changes
        public static bool SetOptions(CipherBase cipher)
        {

            if (cipher == null)
            { 
                MessageBox.Show("Setting the crypting method failed");
                return false;
            }

            Options.CryptingMethod = cipher;
            Options.LbKeyText = buildLbKeyText(Options.CryptingMethod);

            if (Options.CryptingMethod.IsKeyBasedCipher())
            {
                CipherKeyBase keyCipherMethod = (CipherKeyBase)Options.CryptingMethod;
                Options.NudKeyVisible = true;
                Options.NudKeyMinimum = keyCipherMethod.KeyMinConstraint;
                Options.NudKeyMaximum = keyCipherMethod.KeyMaxConstraint;
                Options.KeyValue = keyCipherMethod.KeyValue;
            }
            else
            {
                Options.NudKeyVisible = false;
            }

            return true;
        }

        //for getting cipher method
        public static CipherBase GetCipher(int methodSelection)
        {
            switch (methodSelection)
            {
                case 1: return CipherMorse.Create();
                case 2: return CipherCaesar.Create(Options.KeyValue > 0 ? Options.KeyValue : 1);
                default: return null;
            }
        }

        //Serves as check if chosen crypting method supports keyValue
        public static bool IsCryptingMethodWithKey() =>
            Options.CryptingMethod.IsKeyBasedCipher();

        public static string buildLbKeyText(CipherBase cipher)
        {
            return string.Format($"{cipher.Name}" +
                    (cipher.IsKeyBasedCipher() ? CIPHER_WITH_KEY_LABEL_PREFIX + $"({((CipherKeyBase)cipher).KeyMinConstraint}" + $" - {((CipherKeyBase)cipher).KeyMaxConstraint})" 
                                   : CIPHER_WITHOUT_KEY_LABEL_PREFIX));
        }
    }
}

