using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptingMethods.Utils
{
    public class CipherDescription
    {
        public string Name;
        public string ResourcePath;
        public int Key;

        public override bool Equals(object obj)
        {
            return obj is CipherDescription description &&
                   Name == description.Name &&
                   ResourcePath == description.ResourcePath &&
                   Key == description.Key;
        }

        public override int GetHashCode()
        {
            var hashCode = 1889184264;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ResourcePath);
            hashCode = hashCode * -1521134295 + Key.GetHashCode();
            return hashCode;
        }
    }
}
