using Classes.Resources;
using System.Collections.Generic;

namespace CryptingMethods
{
    public class CipherMorse : CipherBase
    {

        private static string[,] codeTable; // = MorseTab.codeTable;

        private const string LINE_ENDING = "@/";

        private const string BASE_MORSE_JSON_TAB_FULL_PATH = "./Morse.json";

        public CipherMorse()
        {
            
        }

        private CipherMorse(string morseTableFullPath = "")
        {
            Name = "Morse";

            if (morseTableFullPath == "")
            {
                morseTableFullPath = BASE_MORSE_JSON_TAB_FULL_PATH;
            }

            loadMorseTableFromJSON(morseTableFullPath);
        }

        public static CipherMorse Create(string morseTabFullPath = "")
        {
            return new CipherMorse(morseTabFullPath);
        }

        private void loadMorseTableFromJSON(string fileFullPath)
        {
            codeTable = JSONParser.GetTranslationTabFromJSON(fileFullPath);
        }

        public override string Cipher(string text)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                bool symbolFound = false;

                for (int d = 0; d <= codeTable.GetUpperBound(0); d++)
                {
                    if (text[i].ToString() == (codeTable[d, 0]) || text[i].ToString() == (codeTable[d, 1]))
                    {
                        result += codeTable[d, 2] + "/";
                        symbolFound = true;
                    }
                }

                if (symbolFound == false) result += LINE_ENDING;
            }

            return result;
        }

        public override string DeCipher(string code)
        {
            string result = "";
            string bufferWord = "";
            List<char> exludedChars = new List<char>() { '.', '-', ' ' };

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '/')
                {
                    for (int d = 0; d <= codeTable.GetUpperBound(0); d++)
                    {
                        if (bufferWord == codeTable[d, 2])
                        {
                            result += codeTable[d, 0];
                            bufferWord = "";
                        }
                        else { }
                    }
                }
                else if (exludedChars.Contains(code[i])) bufferWord += code[i];
            }
            return result;
        }

        public override bool IsKeyBasedCipher()
        {
            return false;
        }
    }
}
