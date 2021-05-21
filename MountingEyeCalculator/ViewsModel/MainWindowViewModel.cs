using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MountingEyeCalculator.Commands;
using MountingEyeCalculator.Models;
using MountingEyeCalculator.ViewsModel.Base;
using MountingEyeCalculator.Window;
using static MountingEyeCalculator.Variables;

namespace MountingEyeCalculator.ViewsModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly CalculationModule _calculationModule = new();

        private List<double?> EmptyFields => new()
        {
            WeightDevices, LBigBox, ABigBox, BBigBox, DBox, D1Box,
            AlfaBox, YBox, SigmaTBox, H1Box, H2Box, BBox,
            TBox, T1Box, T2Box, T3Box, L1Box, L2Box, K1Box
        };

        #region Window control

        #region Enter data from users

        private double? _weightDevices;
        public double? WeightDevices { get => _weightDevices; set => Set(ref _weightDevices, value); }

        private double? _lBigBox;
        public double? LBigBox { get => _lBigBox; set => Set(ref _lBigBox, value); }

        private double? _bBigBox;
        public double ?BBigBox { get => _bBigBox; set => Set(ref _bBigBox, value); }
                      
        private double? _dBox;
        public double? DBox { get => _dBox; set => Set(ref _dBox, value); }
                      
        private double? _d1Box;
        public double? D1Box { get => _d1Box; set => Set(ref _d1Box, value); }
                      
        private double? _alfaBox;
        public double? AlfaBox { get => _alfaBox; set => Set(ref _alfaBox, value); }
                      
        private double? _yBox;
        public double? YBox { get => _yBox; set => Set(ref _yBox, value); }
                      
        private double? _aBigBox;
        public double? ABigBox { get => _aBigBox; set => Set(ref _aBigBox, value); }
                      
        private double? _sigmaTBox;
        public double? SigmaTBox { get => _sigmaTBox; set => Set(ref _sigmaTBox, value); }
                      
        private double? _h1Box;
        public double? H1Box { get => _h1Box; set => Set(ref _h1Box, value); }
                      
        private double? _h2Box;
        public double? H2Box { get => _h2Box; set => Set(ref _h2Box, value); }
                      
        private double? _bBox;
        public double? BBox { get => _bBox; set => Set(ref _bBox, value); }
                      
        private double? _tBox;
        public double? TBox { get => _tBox; set => Set(ref _tBox, value); }
                      
        private double? _t1Box;
        public double? T1Box { get => _t1Box; set => Set(ref _t1Box, value); }
                      
        private double? _t2Box;
        public double? T2Box { get => _t2Box; set => Set(ref _t2Box, value); }
                      
        private double? _t3Box;
        public double? T3Box { get => _t3Box; set => Set(ref _t3Box, value); }
                      
        private double? _l1Box;
        public double? L1Box { get => _l1Box; set => Set(ref _l1Box, value); }
                      
        private double? _l2Box;
        public double? L2Box { get => _l2Box; set => Set(ref _l2Box, value); }
                      
        private double? _t7Box;
        public double? T7Box { get => _t7Box; set => Set(ref _t7Box, value); }
                      
        private double? _h7Box;
        public double? H7Box { get => _h7Box; set => Set(ref _h7Box, value); }
                      
        private double? _k1Box;
        public double? K1Box { get => _k1Box; set => Set(ref _k1Box, value); }

        #endregion

        #region Background result color

        private Brush _enterResultColorBack;
        public Brush EnterResultColorBack { get => _enterResultColorBack; set => Set(ref _enterResultColorBack, value); }

        #endregion

        #region Error text color

        private Brush _unitColorsText = Brushes.White;
        public Brush UnitColorsText { get => _unitColorsText; set => Set(ref _unitColorsText, value); }

        private Brush _watermarksTextColorsG = Brushes.Gray;
        public Brush WatermarksTextColorsG { get => _watermarksTextColorsG; set => Set(ref _watermarksTextColorsG, value); }

        private Brush _watermarksTextColorsB = Brushes.Black;
        public Brush WatermarksTextColorsB { get => _watermarksTextColorsB; set => Set(ref _watermarksTextColorsB, value); }

        #endregion

        #region Enter result in textblock

        private string _enterResult;
        public string EnterResult { get => _enterResult; set => Set(ref _enterResult, value); }

        #endregion

        #region Enable t7 and h7

        private bool _t7BoxEnable = true;
        public bool T7BoxEnable { get => _t7BoxEnable; set => Set(ref _t7BoxEnable, value); }

        private bool _h7BoxEnable = true;
        public bool H7BoxEnable { get => _h7BoxEnable; set => Set(ref _h7BoxEnable, value); }

        #endregion

        #region With or without bushing

        private bool _withBushingChecked = true;
        public bool WithBushingChecked { get => _withBushingChecked; set => Set(ref _withBushingChecked, value); }

        private bool _withoutBushingChecked;
        public bool WithoutBushingChecked { get => _withoutBushingChecked; set => Set(ref _withoutBushingChecked, value); }

#endregion

        #endregion

        #region Command

        #region Calculation

        public ICommand ResultCommand { get; }
        private bool CanResultCommandExecute(object p) => true;
        private void OnResultCommandExecuted(object p)
        {

            if (WeightDevices != null) WeightDevicess = (double) WeightDevices;
            if (LBigBox != null) LBigBoxs = (double) LBigBox;
            if (ABigBox != null) ABigBoxs = (double) ABigBox;
            if (BBigBox != null) BBigBoxs = (double) BBigBox;
            if (DBox != null) DBoxs = (double) DBox;
            if (D1Box != null) D1Boxs = (double) D1Box;
            if (AlfaBox != null) AlfaBoxs = (double) AlfaBox;
            if (YBox != null) YBoxs = (double) YBox;
            if (SigmaTBox != null) SigmaTBoxs = (double) SigmaTBox;
            if (H1Box != null) H1Boxs = (double) H1Box;
            if (H2Box != null) H2Boxs = (double) H2Box;
            if (BBox != null) BBoxs = (double) BBox;
            if (TBox != null) TBoxs = (double) TBox;
            if (T1Box != null) T1Boxs = (double) T1Box;
            if (T2Box != null) T2Boxs = (double) T2Box;
            if (T3Box != null) T3Boxs = (double) T3Box;
            if (L1Box != null) L1Boxs = (double) L1Box;
            if (L2Box != null) L2Boxs = (double) L2Box;
            if (K1Box != null) K1Boxs = (double) K1Box;
            WithOrWithoutBushing(WithoutBushingChecked);
            EmptyField();
        }

        #endregion

        #region Clear all TextBox

        public ICommand ClearFormCommand { get; }
        private bool CanClearFormCommandExecute(object p) => true;
        private void OnClearFormCommandExecuted(object p)
        {
            UnitColorsText = Brushes.White;
            WatermarksTextColorsG = Brushes.Gray;
            WatermarksTextColorsB = Brushes.Black;
            WeightDevices = null;
            LBigBox = null;
            ABigBox = null;
            BBigBox = null;
            DBox = null;
            D1Box = null;
            AlfaBox = null;
            YBox = null;
            SigmaTBox = null;
            H1Box = null;
            H2Box = null;
            BBox = null;
            TBox = null;
            T1Box = null;
            T2Box = null;
            T3Box = null;
            L1Box = null;
            L2Box = null;
            K1Box = null;
            T7Box = null;
            H7Box = null;
        }

        #endregion

        #region Command with or without bushing

        public ICommand WithBushingCommand { get; }
        private bool CanWithBushingCommandExecute(object p) => true;

        private void OnWithBushingCommandExecuted(object p)
        {
            if (WithBushingChecked is not true) return;
            UnitColorsText = Brushes.White;
            WatermarksTextColorsG = Brushes.Gray;
            WatermarksTextColorsB = Brushes.Black;
            T7BoxEnable = true;
            H7BoxEnable = true;
        }

        public ICommand WithoutBushingCommand { get; }
        private bool CanWithoutBushingCommandExecute(object p) => true;

        private void OnWithoutBushingCommandExecuted(object p)
        {
            if (WithoutBushingChecked is not true) return;
            T7BoxEnable = false;
            H7BoxEnable = false;
            T7Box = null;
            H7Box = null;
        }

        #endregion

        #region Input data in word

        public ICommand OutputInWordCommand { get; }
        private bool CanOutputInWordCommandExecute(object p) => true;
        private void OnOutputInWordCommandExecuted(object p)
        {
            if (EmptyFields.Contains(null))
                ErrorMessage();
            
            else
            {
                ToWord toWord = new();
                toWord.Words(_calculationModule.ResultCalculationInWord);
            }
           
        }

        #endregion

        #region Show window "AboutProgram"

        public ICommand ShowWindowAboutProgram { get; }
        private bool CanShowWindowAboutProgramExecute(object p) => true;
        private void OnShowWindowAboutProgramExecuted(object p)
        {
            var aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        #endregion

        #endregion


        public MainWindowViewModel()
        {
            ClearFormCommand = new LambdaCommand(OnClearFormCommandExecuted, CanClearFormCommandExecute);
            OutputInWordCommand = new LambdaCommand(OnOutputInWordCommandExecuted, CanOutputInWordCommandExecute);
            ResultCommand = new LambdaCommand(OnResultCommandExecuted, CanResultCommandExecute);
            WithBushingCommand = new LambdaCommand(OnWithBushingCommandExecuted, CanWithBushingCommandExecute);
            WithoutBushingCommand =
                new LambdaCommand(OnWithoutBushingCommandExecuted, CanWithoutBushingCommandExecute);
            ShowWindowAboutProgram =
                new LambdaCommand(OnShowWindowAboutProgramExecuted, CanShowWindowAboutProgramExecute);
        }

        private void ErrorMessage()
        {
            WatermarksTextColorsG = WatermarksTextColorsB = Brushes.Red;
            MessageBox.Show("Не все данные заполнены", "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void EmptyField()
        {
            if (EmptyFields.Contains(null))
                ErrorMessage();
            
            else
            {
                EnterResultColorBack = _calculationModule.ResultColorBrush;
                EnterResult = _calculationModule.ResultTextCalculation;
            }
        }

        private void WithOrWithoutBushing(bool withoutBushingChecked)
        {
            if (withoutBushingChecked is true)
            {
                T7Boxs = 0;
                H7Boxs = 0;
            }

            else
            {
                if (T7Box != null) T7Boxs = (double) T7Box;
                if (H7Box != null) H7Boxs = (double) H7Box;
            }
            
        }
    }
}
