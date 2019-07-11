﻿using Classes;
using System;
using System.Windows.Forms;

namespace Controls {
    public static class Ctrls {
        //method to cipher/decipher
        public static string Transform(string input, bool cipherDirection) =>
             cipherDirection ? AppOptions.CryptingMethod.Cipher(input) : AppOptions.CryptingMethod.DeCipher(input);
        

        //just demonstration of possibility to check if all is ready to Exit app
        public static bool ExitCheck() {
            return true;
        }

        //sets AppOptions when crypting method changes
        public static void SetAppOptionsCryptingMethod(int newValue) {
            ICipher checkMethod = GetCipher(newValue);

            if (checkMethod != null) {
                AppOptions.CryptingMethod = checkMethod;
            } else {
                MessageBox.Show("Setting the crypting method failed");
                return;
            }

            if (((CipherBase)AppOptions.CryptingMethod).HasKey) {
                CipherKeyBase keyCipherMethod = (CipherKeyBase)AppOptions.CryptingMethod;
                AppOptions.LbKeyText = string.Format($"{keyCipherMethod.Name}" +
                    $" method Key value ({keyCipherMethod.KeyMinConstraint}" +
                    $" - {keyCipherMethod.KeyMaxConstraint}):");
                AppOptions.NudKeyVisible = true;
                AppOptions.NudKeyMinimum = keyCipherMethod.KeyMinConstraint;
                AppOptions.NudKeyMaximum = keyCipherMethod.KeyMaxConstraint;
            } else {
                AppOptions.LbKeyText = string.Format($"{((CipherBase)AppOptions.CryptingMethod).Name} method is not using crypting key value");
                AppOptions.NudKeyVisible = false;
            }
        }

        //for getting cipher method
        public static ICipher GetCipher(int methodSelection) {
            switch (methodSelection) {
                case 1: return new CipherMorse();
                case 2: return new CipherCaesar(AppOptions.KeyValue);
                default: return null;
            }
        }

        //Sets AppOptions KeyValue and when crypting method with key is chosen
        //also keyValue of this method
        public static void SetValueOfKey(int value) {
            if (AppOptions.CryptingMethod is CipherKeyBase) {
                ((CipherKeyBase)AppOptions.CryptingMethod).KeyValue = value;
                AppOptions.KeyValue = value;
            }
        }

        //Serves as check if chosen crypting method supports keyValue
        public static bool IsCryptingMethodWithKey() =>
            ((CipherBase)AppOptions.CryptingMethod).HasKey ? true : false;
    }
}

