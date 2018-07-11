using System;
using System.Windows.Forms;
using Classes;

namespace Controlls {
    public static class Ctrls {
        public static void BuConvert_Click(object o, EventArgs e) {
            ICipher CryptingMethod = GetCipher(AppOptions.CipherSelection);
            FrMain
        }

        public static ICipher GetCipher(int methodSelection) {
            switch (methodSelection) {
                case 1: return new CipherMorse();
                default: return new CipherMorse();
            }
        }
    }
}
