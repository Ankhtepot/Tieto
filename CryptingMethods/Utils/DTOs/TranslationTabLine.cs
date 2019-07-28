using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptingMethods.Utils
{
    class TranslationTabLine
    {
        public string primaryString;
        public string secondaryString;
        public string translatedString;

        public override bool Equals(object obj)
        {
            return obj is TranslationTabLine line &&
                   primaryString == line.primaryString &&
                   secondaryString == line.secondaryString &&
                   translatedString == line.translatedString;
        }

        public override int GetHashCode()
        {
            var hashCode = -228515482;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(primaryString);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(secondaryString);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(translatedString);
            return hashCode;
        }
    }
}
