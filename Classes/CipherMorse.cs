using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    public class CipherMorse : CipherBase {
        public CipherMorse() {
            Name = "Morse";
            HasKey = false;
        }

        public override string Cipher(string text) {
            string result = "";
            for (int i = 0; i < text.Length; i++) {
                bool symbolFound = false;
                for (int d = 0; d <= codeTable.GetUpperBound(0); d++) {
                    if (text[i].ToString() == (codeTable[d, 0]) || text[i].ToString() == (codeTable[d, 1])) {
                        result += codeTable[d, 2] + "/";
                        symbolFound = true;
                    }
                }
                if (symbolFound == false) result += "@/";
            }
            return result;
        }
        
        public override string DeCipher(string code) {
            string result = "";
            string bufferWord = "";
            for (int i = 0; i < code.Length; i++) {
                if (code[i] == '/') {
                    for (int d = 0; d <= codeTable.GetUpperBound(0); d++) {
                        if (bufferWord == codeTable[d, 2]) {
                            result += codeTable[d, 0];
                            bufferWord = "";
                        } else { }
                    }
                } else if (code[i] == '.' || code[i] == '-' || code[i] == ' ') bufferWord += code[i];
            }
            return result;
        }

        private string[,] codeTable = {
            {"A", "a", ".-"},
            {"B", "b", "-..."},
            {"C", "c", "-.-."},
            {"D", "d", "-.."},
            {"E", "e", "."},
            {"F", "f", "..-."},
            {"G", "g", "--."},
            {"H", "h", "...."},
            {"CH", "ch", "----"},
            {"I", "i", ".."},
            {"J", "j", ".---"},
            {"K", "k", "-.-"},
            {"L", "l", ".-.."},
            {"M", "m", "--"},
            {"N", "n", "-."},
            {"O", "o", "---"},
            {"P", "p", ".--."},
            {"Q", "q", "--.-"},
            {"R", "r", ".-."},
            {"S", "s", "..."},
            {"T", "t", "-"},
            {"U", "u", "..-"},
            {"V", "v", "...-"},
            {"W", "w", ".--"},
            {"X", "x", "-..-"},
            {"Y", "y", "-.--"},
            {"Z", "z", "--.."},
            {"Ä", "ä", ".-.-"},
            {"Ö", "ö", "---."},
            {"Ü", "ü", "..--"},
            {"1", "1", ".----"},
            {"2", "2", "..---"},
            {"3", "3", "...--"},
            {"4", "4", "....-"},
            {"5", "5", "....."},
            {"6", "6", "-...."},
            {"7", "7", "--..."},
            {"8", "8", "---.."},
            {"9", "9", "----."},
            {"0", "0", "-----"},
            {".", ".", ".-.-.-"},
            {",", ",", "--..--"},
            {"?", "?", "..--.."},
            {"!", "!", "..--."},
            {"\"", "\"", ".-..-."},
            {"'", "'", ".----."},
            {"=", "=", "-...-"},
            {" ", " ", " "}
        };
    }
}
