using Classes.Resources;
using CryptingMethods.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CryptingMethods.test
{
    public class JSONParserTest
    {
        private const string TEST_TAB_FILEPATH = "./testTabLines.json";

        private List<TranslationTabLine> testTranslationTabList = new List<TranslationTabLine> {
            new TranslationTabLine()
            {
                primaryString = "PS1",
                secondaryString = "SS1",
                translatedString = "TS1"
            },
            new TranslationTabLine()
            {
                primaryString = "PS2",
                secondaryString = "SS2",
                translatedString = "TS2"
            }
        };

        private String[,] testTranslationTabArray = { { "PS1", "SS1", "TS1" }, { "PS2", "SS2", "TS2" } };

        [Fact]
        public void testParseJson_withValidFile()
        {
            Assert.Equal(testTranslationTabList, JSONParser.ParseJson<TranslationTabLine>(TEST_TAB_FILEPATH));
        }

        [Fact]
        public void testParseJson_withFictionalFile()
        {
            Assert.Null(JSONParser.ParseJson<TranslationTabLine>("nonExistantFile.wtf"));
        }

        [Fact]
        public void testGetTranslationTabFromJSON_withValidFile()
        {
            Assert.Equal(testTranslationTabArray, JSONParser.GetTranslationTabFromJSON(TEST_TAB_FILEPATH));
        }

        [Fact]
        public void testGetTranslationTabFromJSON_withFictionalFile()
        {
            Assert.Null(JSONParser.GetTranslationTabFromJSON("moveAlongNothingToFindHere.pig"));
        }
    }
}
