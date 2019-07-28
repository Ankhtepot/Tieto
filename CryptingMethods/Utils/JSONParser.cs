using CryptingMethods.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Classes.Resources
{
    public class JSONParser
    {      
        /// <summary>
        /// Generic method to parse JSON file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> ParseJson<T>(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return null;
            }

            using (StreamReader r = new StreamReader(fileName))
            {
                try
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<T>>(json);
                }
                catch (System.Exception e)
                {
                    return null;
                }
                
            }
        }

        public static string[,] GetTranslationTabFromJSON(string fileName)
        {
            return TransformListTo2DArray(ParseJson<TranslationTabLine>(fileName));
        }

        /// <summary>
        /// Transforms TranslationTabLines into 2D array usable in ciphers
        /// </summary>
        /// <param name="list">list of TranslationTabLines f.ex. extracted from json</param>
        /// <returns></returns>
        private static string[,] TransformListTo2DArray(List<TranslationTabLine> list)
        {
            if(list == null || !list.Any())
            {
                return null;
            }

            string[,] result = new string[list.Count(), 3];

            for (int i = 0; i < list.Count; i++)
            {
                result[i, 0] = list[i].primaryString;
                result[i, 1] = list[i].secondaryString;
                result[i, 2] = list[i].translatedString;
            }

            return result;
        }
    }
}
