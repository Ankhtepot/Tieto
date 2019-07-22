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
            SetAppOptionsCryptingMethod(0);

            //settings of controlls
            RbMorse.Checked = true;

            //Methods for controlls
            BuCipher.Click += BuCipher_Click;
            BuDecipher.Click += BuDecipher_Click;
            BuExit.Click += BuExit_Click;
            RbMorse.Click += RbMethodClick;
            RbCaesar.Click += RbMethodClick;
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
            string extractedTag = ((sender as RadioButton).Tag).ToString();
            SetAppOptionsCryptingMethod(int.TryParse(extractedTag, out int returnInt) ? int.Parse(extractedTag) : 0 );
        }

        private void RbMorse_Click(object sender, EventArgs e)
        {
            string extractedTag = ((sender as RadioButton).Tag).ToString();
            SetAppOptionsCryptingMethod(int.TryParse(extractedTag, out int returnInt) ? int.Parse(extractedTag) : 0);
        }

        private void RbMethodClick(object sender, EventArgs e)
        {
            string extractedTag = ((sender as RadioButton).Tag).ToString();
            SetAppOptionsCryptingMethod(int.TryParse(extractedTag, out int returnInt) ? int.Parse(extractedTag) : 0);
        }

        private void BuDecipher_Click(object sender, EventArgs e) => Cipher(false);

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

        private void BuCipher_Click(object o, EventArgs e) => Cipher(true);
        

        //executive methods
        private void Cipher(bool cipherDirection) =>
            TbResult.Text = OptionsService.CipherExecute(TbInput.Text, cipherDirection);

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

        private void SetKeyValue(int value) => Options.KeyValue = value;

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
    }
}
