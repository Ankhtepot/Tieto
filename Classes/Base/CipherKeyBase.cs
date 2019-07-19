namespace Cipher
{ //base class for crypting methods with keyValue
    public abstract class CipherKeyBase : CipherBase
    {
        public int KeyMinConstraint { get; set; }
        public int KeyMaxConstraint { get; set; }
        private int keyValue;

        public CipherKeyBase(int keyMin, int keyMax, int keyVal)
        {
            KeyMinConstraint = keyMin;
            KeyMaxConstraint = keyMax;
            keyValue = keyVal;
        }
        
        public virtual int KeyValue {
            get => keyValue;
            set {
                if (value >= this.KeyMinConstraint && value <= this.KeyMaxConstraint) keyValue = value;
                else if (value <= this.KeyMinConstraint) keyValue = this.KeyMinConstraint;
                else if (value >= this.KeyMaxConstraint) keyValue = this.KeyMaxConstraint;
            }
        }

        public override abstract string Cipher(string text);

        public override abstract string DeCipher(string code);

        public abstract override bool IsKeyBasedCipher();
    }
}
