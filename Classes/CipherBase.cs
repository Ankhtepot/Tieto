using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{ //base class for crypting methods
    public abstract class CipherBase : ICipher
    {
        public string Name { get; set; }

        public bool HasKey { get; set; }

        public abstract string DeCipher(string code);

        public abstract string Cipher(string text);

    }
}
