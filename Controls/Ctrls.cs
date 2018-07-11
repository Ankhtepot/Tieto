using Classes;
using System;

namespace Controls
{
    public static class Ctrls {
        public static String Transform(String input, Boolean cipherDirection) {
            //cipherDirection: true=text->code, false=code->text
            String result = "";
            //using (ICipher CryptingMethod = AppOptions.CryptingMethod) {
            //    result = cipherDirection ? CryptingMethod.Cipher(input) : CryptingMethod.DeCipher(input) ;
            //}
            result = cipherDirection ? AppOptions.CryptingMethod.Cipher(input) : AppOptions.CryptingMethod.DeCipher(input);
            return result;
        }

        public static Boolean ExitCheck() {
            //just demonstration of possibility to check if all is ready to Exit app
            return true;
        }

        public static void SetAppOptionsCryptingMethod(int newValue) {
            AppOptions.CryptingMethod = GetCipher(newValue);
            if (((CipherBase)AppOptions.CryptingMethod).HasKey) {
                CipherKeyBase keyCipherMethod = (CipherKeyBase)AppOptions.CryptingMethod;
                AppOptions.LbKeyText = String.Format($"{keyCipherMethod.Name}" +
                    $" method Key value ({keyCipherMethod.KeyMinConstraint}" +
                    $" - {keyCipherMethod.KeyMaxConstraint}):");
                AppOptions.NudKeyVisible = true;
                AppOptions.NudKeyMinimum = keyCipherMethod.KeyMinConstraint;
                AppOptions.NudKeyMaximum = keyCipherMethod.KeyMaxConstraint;
            } else {
                AppOptions.LbKeyText = String.Format($"{((CipherBase)AppOptions.CryptingMethod).Name} method is not using crypting key value");
                AppOptions.NudKeyVisible = false;
            }
        }

        public static ICipher GetCipher(int methodSelection) {
            switch (methodSelection) {
                case 1: return new CipherMorse();
                case 2: return new CipherCaesar(AppOptions.KeyValue);
                default: return new CipherMorse();
            }
        }

        public static void SetKeyValue(int value) {
                if (AppOptions.CryptingMethod is CipherKeyBase) {
                    ((CipherKeyBase)AppOptions.CryptingMethod).KeyValue = value;
                    AppOptions.KeyValue = value;
                }
            }

        public static bool KeyCryptingMethod() {
            return ((CipherBase)AppOptions.CryptingMethod).HasKey ? true : false;
        }
        }
    }

