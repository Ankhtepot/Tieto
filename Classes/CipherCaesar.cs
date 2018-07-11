using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    public class CipherCaesar : CipherKeyBase {

        public CipherCaesar(int keyValue) : base(1, 26, keyValue) {
            this.Name = "Caesar";
            this.HasKey = true;
        }

        public override string Cipher(string text) {
            String result = "";
            for (int i = 0; i < text.Length; i++) {
                result += cipherChar(text[i]);
            }
            return result;
        }

        public override string DeCipher(string code) {
            String result = "";
            for (int i = 0; i < code.Length; i++) {
                result += deCipherChar(code[i]);
            }
            return result;
        }

        private char cipherChar(char input) {
            char result = ' ';
            if (Char.IsDigit(input)) {
                int postModuloInc = (KeyValue + int.Parse(input.ToString())) % 10;
                result = Char.Parse(postModuloInc.ToString());
            } else
            if (Char.IsLetter(input)) {
                bool inputIsUpper = false;
                if (Char.IsUpper(input)) { //buffer for to store flag if char is upperCase
                    input = Char.ToLower(input);
                    inputIsUpper = true;
                }
                int moveTo = input + KeyValue;
                while (moveTo > 122) { //to ensure right overfloating of letter ANSII
                    moveTo = 97 + (moveTo - 123);
                }
                result = (char)moveTo;
                if (inputIsUpper) result = Char.ToUpper(result);
            } else return '@';
            return result;
        }

        private Char deCipherChar(char input) {
            char result = ' ';
            if (Char.IsDigit(input)) {
                int number = (int)Char.GetNumericValue(input);
                int keyValue = KeyValue % 10;
                number = number >= keyValue ? number - keyValue : 10 + (number - keyValue);
                return Char.Parse(number.ToString());
            } else
                if (Char.IsLetter(input)) {
                bool inputIsUpper = false;
                if (Char.IsUpper(input)) { //buffer for to store flag if char is upperCase
                    input = Char.ToLower(input);
                    inputIsUpper = true;
                }
                int moveTo = input - KeyValue;
                while (moveTo < 97) { //to ensure right overfloating of letter ANSII
                    moveTo += 26 ;
                }
                result = (char)moveTo;
                if (inputIsUpper) result = Char.ToUpper(result);
                return result;
            } else return '@';
            
        }
    }
}

