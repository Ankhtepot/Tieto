using AppOptions;
using Classes.Resources;
using System;
using System.Windows.Forms;

namespace Cipherator
{
    public partial class FrMain : Form
    {
        public FrMain()
        {
            InitializeComponent();

            //AppOptions default setting
            SetAppOptionsCryptingMethod(1);

            //settings of controlls
            RbMorse.Checked = true;

            //Methods for controlls
            BuCipher.Click += BuCipher_Click;
            BuDecipher.Click += BuDecipher_Click;
            BuExit.Click += BuExit_Click;
            RbMorse.Click += RbMorse_Click;
            RbCaesar.Click += RbCaesar_Click;
            NudKey.ValueChanged += NudKey_ValueChanged;
            BuReset.Click += BuReset_Click;
            BuToInput.Click += BuToInput_Click;
        }

        //placeholder controlls methods
        private void BuToInput_Click(object sender, EventArgs e)
        {
            MoveResultToInput();
        }

        private void BuReset_Click(object sender, EventArgs e)
        {
            ResetTBs();
        }

        private void NudKey_ValueChanged(object sender, EventArgs e)
        {
            SetKeyValue((int)NudKey.Value);
        }

        private void RbCaesar_Click(object sender, EventArgs e)
        {
            SetAppOptionsCryptingMethod(2);
        }

        private void RbMorse_Click(object sender, EventArgs e)
        {
            SetAppOptionsCryptingMethod(1);
        }

        private void BuDecipher_Click(object sender, EventArgs e)
        {
            Cipher(false);
        }

        private void BuExit_Click(object sender, EventArgs e)
        {
            if (OptionsService.ExitCheck())
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Cant exit right now");
            }
        }

        private void BuCipher_Click(object o, EventArgs e)
        {
            Cipher(true);
        }

        //executive methods
        private void Cipher(Boolean cipherDirection)
        {
            TbResult.Text = OptionsService.CipherExecute(TbInput.Text, cipherDirection);
        }

        private void SetAppOptionsCryptingMethod(int newValue)
        {
            OptionsService.SetOptions(OptionsService.GetCipher(newValue));

            if (OptionsService.IsCryptingMethodWithKey())
            {
                LbKey.Text = Options.LbKeyText;
                NudKey.Value = Options.KeyValue;
                NudKey.Visible = Options.NudKeyVisible;
                NudKey.Minimum = Options.NudKeyMinimum;
                NudKey.Maximum = Options.NudKeyMaximum;
            }
            else
            {
                LbKey.Text = Options.LbKeyText;
                NudKey.Visible = false;
            }
        }

        private void SetKeyValue(int value)
        {
            Options.KeyValue = value;
        }

        private void ResetTBs()
        {
            TbInput.Text = "";
            TbResult.Text = "";
        }

        private void MoveResultToInput()
        {
            TbInput.Text = TbResult.Text;
            TbResult.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[,] testLoad = JSONToMorseTabParser.getMorseTabFromJSON("D:/Users/Petr/Documents/Visual Studio 2017/repos - docs/Tieto/Classes/Resources/Morse.json");
        }
    }
}
