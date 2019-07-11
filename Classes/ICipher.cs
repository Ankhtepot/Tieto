using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{   //Interface to ensure crypting classes can serve theyr purpose
    public interface ICipher 
    {
        string Cipher(string text);
        string DeCipher(string code);
    }
}
