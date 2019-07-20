using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Classes.Resources
{
    public class JSONToMorseTabParser
    {
        public static string[,] getMorseTabFromJSON(string fileName)
        {
            List<Line> items = new List<Line>();

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Line>>(json);
            }

            return TransformListTo2DArray(items);
        }

        private static string[,] TransformListTo2DArray(List<Line> list)
        {
            string[,] result = new string[list.Count(), 3];

            for (int i = 0; i < list.Count; i++)
            {
                result[i, 0] = list[i].primaryString;
                result[i, 1] = list[i].secondaryString;
                result[i, 2] = list[i].morseString;
            }

            return result;
        }
    }

    public class Line
    {
        public string primaryString;
        public string secondaryString;
        public string morseString;
    }
}
