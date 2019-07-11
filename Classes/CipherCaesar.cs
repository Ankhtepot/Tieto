using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    public class CipherCaesar : CipherKeyBase {

        private const char PLACEHOLDER_SIGN = '@';

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

            if (char.IsDigit(input)) {
                int postModuloInc = (KeyValue + int.Parse(input.ToString())) % 10;
                return char.Parse(postModuloInc.ToString());
            } else
            if (char.IsLetter(input)) {
                bool inputIsUpper = false;

                if (char.IsUpper(input)) { //buffer for to store flag if char is upperCase
                    input = char.ToLower(input);
                    inputIsUpper = true;
                }

                int moveTo = input + KeyValue;

                while (moveTo > 122) { //to ensure right overfloating of letter ANSII
                    moveTo = 97 + (moveTo - 123);
                }

                if (inputIsUpper)
                    return char.ToUpper((char)moveTo);

                return (char)moveTo;
            } else return PLACEHOLDER_SIGN;
        }

        private char deCipherChar(char input) {
            char result = ' ';

            if (char.IsDigit(input)) {
                int number = (int)char.GetNumericValue(input);
                int keyValue = KeyValue % 10;
                number = number >= keyValue ? number - keyValue : 10 + (number - keyValue);
                return char.Parse(number.ToString());
            } else
                if (char.IsLetter(input)) {
                bool inputIsUpper = false;
                if (char.IsUpper(input)) { //buffer for to store flag if char is upperCase
                    input = char.ToLower(input);
                    inputIsUpper = true;
                }
                int moveTo = input - KeyValue;
                while (moveTo < 97) { //to ensure right overfloating of letter ANSII
                    moveTo += 26 ;
                }
                result = (char)moveTo;
                if (inputIsUpper) result = char.ToUpper(result);
                return result;
            } else return PLACEHOLDER_SIGN;
            
        }
    }
}

