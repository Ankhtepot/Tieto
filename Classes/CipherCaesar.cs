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
                Console.WriteLine("result:" + result);
            }
            return result;
        }

        public override string DeCipher(string code) {
            String result = "";
            for (int i = 0; i < code.Length; i++) {
                result += deCipherChar(code[i]);
                Console.WriteLine("result:" + result);
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
                if (Char.IsUpper(input)) {
                    input = Char.ToLower(input);
                    inputIsUpper = true;
                }
                int moveTo = input + KeyValue;
                while (moveTo > 122) {
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
                //Console.WriteLine("Converted number: {0}, KeyValue = {1}, number-KeyValue = {2}, 10-(number-KeyValue) = {3}", number, keyValue, number - keyValue, 10 + (number - keyValue));
                number = number >= keyValue ? number - keyValue : 10 + (number - keyValue);
                //Console.WriteLine("Returning number: {0}",number);
                return Char.Parse(number.ToString());
            } else
                if (Char.IsLetter(input)) {
                bool inputIsUpper = false;
                if (Char.IsUpper(input)) {
                    input = Char.ToLower(input);
                    inputIsUpper = true;
                }
                int moveTo = input - KeyValue;
                Console.WriteLine("Input - KeyValue: {0}",moveTo);
                while (moveTo < 97) {
                    moveTo += 26 ;
                    Console.WriteLine("Changing moveTo to: {0}",moveTo);
                }
                result = (char)moveTo;
                if (inputIsUpper) result = Char.ToUpper(result);
                return result;
            } else return '@';
            
        }
    }
}

