using AppOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FrMain : Window
    {
        public FrMain()
        {
            InitializeComponent();

            //AppOptions default setting
            OptionsService.InitializeOptionsCiphers();
            SetAppOptionsCryptingMethod(0);

            CreateRadioButtons(OptionsService.GetCiphersNames());
            //Console.WriteLine((groupCipher.Controls.Find("RB0", false)[0] as CheckBox).Checked);// = true;

            //settings of controlls

            //Methods for controlls
            BuCipher.Click += BuCipher_Click;
            BuDecipher.Click += BuDecipher_Click;
            BuExit.Click += BuExit_Click;
            NudKey.ValueChanged += NudKey_ValueChanged;
            BuReset.Click += BuReset_Click;
            BuToInput.Click += BuToInput_Click;
        }

        private void CreateRadioButtons(List<string> names)
        {
            if(names == null || !names.Any())
            {
                return;
            }

            var maxRbsOnLine = Options.maxRbsOnLine;

            for (int i = 0; i < names.Count; i++)
            {
                var newRB = new RadioButton();

                newRB.Name = "RB" + i;
                newRB.IsChecked = false;
                newRB.Content = names[i];
                newRB.Tag = i;
                newRB.Click += RbMethodClick;
                if (i == 0) newRB.IsChecked = true; // sets first created radioButton checked

                var targetColumn = i % maxRbsOnLine;
                var targetRow = i / maxRbsOnLine;

                SetGroupCipher(names.Count(), maxRbsOnLine);

                GroupCipher.Children.Add(newRB);

                Grid.SetColumn(newRB, targetColumn);
                Grid.SetRow(newRB, targetRow);
            }
        }

        private void SetGroupCipher(int cellCount, int maxRbsOnLine)
        {
            GroupCipher.ColumnDefinitions.Clear();
            GroupCipher.RowDefinitions.Clear();

            for (int i = 0; i < maxRbsOnLine; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                GroupCipher.ColumnDefinitions.Add(colDef);
            }

            var targetNumberOfRows = cellCount / maxRbsOnLine + 1;

            for (int i = 0; i < targetNumberOfRows; i++)
            {
                GroupCipher.RowDefinitions.Add(new RowDefinition());
            }

            GroupCipher.Height = (targetNumberOfRows + 1) * Options.CellHeightForWPF;
            FrMainWindow.Height = Options.MainWindowBaseHeightWPF + GroupCipher.Height + 10;
        }

        //placeholder controlls methods
        private void BuToInput_Click(object sender, RoutedEventArgs e) => MoveResultToInput();

        private void BuReset_Click(object sender, RoutedEventArgs e) => ResetTBs();

        private void NudKey_ValueChanged(object sender, RoutedEventArgs e) => SetKeyValue((int)NudKey.Value);

        private void RbMethodClick(object sender, RoutedEventArgs e)
        {
            string extractedTag = ((sender as RadioButton).Tag).ToString();
            SetAppOptionsCryptingMethod(int.TryParse(extractedTag, out int returnInt) ? int.Parse(extractedTag) : 0);
        }

        private void BuDecipher_Click(object sender, RoutedEventArgs e) => Cipher(false);

        private void BuExit_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsService.ExitCheck())
            {
                Application.Current.Shutdown();
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
                NudKey.Visibility = Options.NudKeyVisible ? Visibility.Visible : Visibility.Collapsed;
                NudKey.Minimum = Options.NudKeyMinimum;
                NudKey.Maximum = Options.NudKeyMaximum;
            }
            else
            {
                LbKey.Text = Options.LbKeyText;
                NudKey.Visibility = Visibility.Collapsed;
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
