using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MountingEyeCalculator.Fonds
{
    /// <summary>
    /// Логика взаимодействия для TextBoxForData.xaml
    /// </summary>
    public partial class TextBoxForData : UserControl
    {
        public static readonly DependencyProperty WatermarksText = DependencyProperty.Register("Watermarks", typeof(string), typeof(TextBoxForData));
        public static readonly DependencyProperty TextBlockUnitText = DependencyProperty.Register("TextBlockUnit", typeof(string), typeof(TextBoxForData));
        public static readonly DependencyProperty WeightDeviceText = DependencyProperty.Register("TextWeightDevice", typeof(string), typeof(TextBoxForData));
        public static readonly DependencyProperty WatermarksTextColor = DependencyProperty.Register("WatermarksTextColors", typeof(Brush), typeof(TextBoxForData));

        public string TextWeightDevice
        {
            get => (string)GetValue(WeightDeviceText);
            set => SetValue(WeightDeviceText, value);
        }

        public string Watermarks
        {
            get => (string) GetValue(WatermarksText);
            set => SetValue(WatermarksText, value);
        }

        public string TextBlockUnit
        {
            get => (string)GetValue(TextBlockUnitText);
            set => SetValue(TextBlockUnitText, value);
        }

        public Brush WatermarksTextColors
        {
            get => (Brush)GetValue(WatermarksTextColor);
            set => SetValue(WatermarksTextColor, value);
        }

        public TextBoxForData()
        {
            InitializeComponent();
        }

        private void WeightDevice_TextChanged(object sender, TextChangedEventArgs e)
        {
            Watermark.Visibility = WeightDevice.Text.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void WeightDevice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
                && (!WeightDevice.Text.Contains(".")
                    && WeightDevice.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
