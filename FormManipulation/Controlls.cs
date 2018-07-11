using Cipherator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManipulation
{
    public static class Controlls
    {
        public static void setLbResult(String text) {
            FrMain frMain = new FrMain();
            frMain.LbResult.Text = text;
            
        }
    }
}
