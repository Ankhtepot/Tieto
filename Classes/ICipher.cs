using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{   //Interface to ensure crypting classes can serve theyr purpose
    public interface ICipher 
    {
        String Cipher(String text);
        String DeCipher(String code);
    }
}
