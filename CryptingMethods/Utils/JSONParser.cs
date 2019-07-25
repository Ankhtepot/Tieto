using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Classes.Resources
{
    public class JSONParser
    {
        public static string[,] getTranslationTabFromJSON(string fileName)
        {
            //using (StreamReader r = new StreamReader(fileName))
            //{
            //    string json = r.ReadToEnd();
            //    return TransformListTo2DArray(JsonConvert.DeserializeObject<List<Line>>(json));
            //}
            return TransformListTo2DArray(parseJson<Line>(fileName));
        }

        public static List<T> parseJson<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public static List<CipherDescription> getCipherList(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<CipherDescription>>(json);
            }
        }

        private static string[,] TransformListTo2DArray(List<Line> list)
        {
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

    public class Line
    {
        public string primaryString;
        public string secondaryString;
        public string translatedString;
    }

    public class CipherDescription
    {
        public string Name;
        public string ResourcePath;
        public int Key;
        public int OptionalInt;
        public string OptionalString;
    }
}
