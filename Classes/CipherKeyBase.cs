using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes { //base class for crypting methods with keyValue
    public abstract class CipherKeyBase : CipherBase {
        private int keyMinConstraint;
        private int keyMaxConstraint;
        private int keyValue;

        public CipherKeyBase(int keyMin, int keyMax, int keyVal) {
            this.KeyMinConstraint = keyMin;
            this.KeyMaxConstraint = keyMax;
            this.keyValue = keyVal;
        }

        public int KeyMinConstraint { get => keyMinConstraint; set => keyMinConstraint = value; }
        public int KeyMaxConstraint { get => keyMaxConstraint; set => keyMaxConstraint = value; }
        public virtual int KeyValue {
            get => keyValue;
            set {
                if (value >= this.KeyMinConstraint && value <= this.KeyMaxConstraint) keyValue = value;
                else if (value < this.KeyMinConstraint) keyValue = this.KeyMinConstraint;
                else if (value > this.KeyMaxConstraint) keyValue = this.KeyMaxConstraint;
            }
        }

        public override abstract string Cipher(string text);

        public override abstract string DeCipher(string code);
    }
}
