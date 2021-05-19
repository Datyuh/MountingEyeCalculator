using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MountingEyeCalculator.Models
{
    class CalculationModule : Variables
    {
        public Brush ResultColorBrush => ResultColor();
        public string ResultTextCalculation => ResultText();
        public Dictionary<string, object> ResultCalculationInWord => ResultCalculation();

        private const double Corner = 180 * Math.PI;
        private const double Gravity = 9.8;

        private double Q => WeightDevicess * Gravity;
        private double R1 => DBoxs * Q * BBigBoxs / LBigBoxs;
        private double R2 => DBoxs * Q * ABigBoxs / LBigBoxs;
        private double A1 => ABigBoxs * Math.Cos(AlfaBoxs / Corner);
        private double B1 => BBigBoxs * Math.Cos(AlfaBoxs / Corner);
        private double L1 => LBigBoxs * Math.Cos(AlfaBoxs / Corner);
        private double R11 => D1Boxs * Q * B1 / L1;
        private double R21 => D1Boxs * Q * A1 / L1;
        private double a1 => R11 * Math.Sin(AlfaBoxs / Corner);
        private double b1 => R11 * Math.Cos(AlfaBoxs / Corner);
        private double c1 => R21 * Math.Sin(AlfaBoxs / Corner);
        private double d1 => R21 * Math.Cos(AlfaBoxs / Corner);
        private double M1 => c1 * YBoxs;
        private double Jx => 1 / 3F * (BBoxs * Math.Pow(H1Boxs + T1Boxs, 3) - (BBoxs - TBoxs) * Math.Pow(H2Boxs, 3) +
            BBoxs * Math.Pow(H2Boxs + T2Boxs, 3) - (BBoxs - TBoxs) * Math.Pow(H1Boxs, 3));
        private double Wxv => Jx / (H2Boxs + T2Boxs);
        private double Wxn => Jx / (H1Boxs + T1Boxs);
        private double MaxW => Math.Max(Wxv, Wxn);
        private double sigma1 => M1 / MaxW;
        private double F1 => BBoxs * (T1Boxs + T2Boxs) + (H1Boxs + H2Boxs) * TBoxs;
        private double sigma_N => d1 / F1;
        private double sigma => sigma1 + sigma_N;
        private double sigma_dop => 2 / 3F * SigmaTBoxs;
        private double teta_dop => 0.4 * SigmaTBoxs;
        private double teta1 => R2 / (2 * (T7Boxs * H7Boxs) + TBoxs * T3Boxs);
        private double teta2 => R2 / (2 * 0.7 * K1Boxs * (L1Boxs + (H1Boxs + H2Boxs) + L2Boxs));

        private Dictionary<string, object> ResultCalculation()
        {

            return new()
            {
                {"{{ Q }}", Math.Round(Q)}, {"{{ D }}", DBoxs}, {"{{ L }}", LBigBoxs}, {"{{ B }}", BBoxs},
                {"{{ A }}", ABigBoxs}, {"{{ R1 }}", Math.Round(R1)}, {"{{ R2 }}", Math.Round(R2)},
                {"{{ A1 }}", Math.Round(A1)}, {"{{ B1 }}", Math.Round(B1)}, {"{{ L_1 }}", Math.Round(L1Boxs)},
                {"{{ R11 }}", Math.Round(R11)}, {"{{ R21 }}", Math.Round(R21)},
                {"{{ a1 }}", Math.Round(a1)}, {"{{ b1 }}", Math.Round(b1)}, {"{{ c1 }}", Math.Round(c1)},
                {"{{ d1 }}", Math.Round(d1)}, {"{{ b_b }}", BBoxs}, {"{{ h1 }}", H1Boxs},
                {"{{ t }}", TBoxs}, {"{{ t1 }}", T1Boxs}, {"{{ t2 }}", T2Boxs}, {"{{ t3 }}", T3Boxs},
                {"{{ l1 }}", L1Boxs}, {"{{ l2 }}", L2Boxs}, {"{{ t7 }}", T7Boxs}, {"{{ h7 }}", H7Boxs},
                {"{{ k1 }}", K1Boxs}, {"{{ M1 }}", Math.Round(M1)}, {"{{ Jx }}", Math.Round(Jx)},
                {"{{ Wxv }}", Math.Round(Wxv)}, {"{{ D_1 }}", D1Boxs}, {"{{ Wxn }}", Math.Round(Wxn)},
                {"{{ sigma }}", Math.Round(sigma)}, {"{{ F1 }}", Math.Round(F1)}, {"{{ sigmaN }}", Math.Round(sigma_N)},
                {"{{ sigma_dop }}", Math.Round(sigma_dop)},
                {"{{ teta_1 }}", Math.Round(teta1)}, {"{{ teta_2 }}", Math.Round(teta2)},
                {"{{ teta_dop }}", Math.Round(teta_dop)}, {"{{ h2 }}", H2Boxs}, {"{{ sigma1 }}", Math.Round(sigma1)},
            };
        }

        private Brush ResultColor()
        {
            return teta1 <= teta_dop && teta2 <= teta_dop && sigma <= sigma_dop ? Brushes.Green : Brushes.Red;
        }

        private string ResultText()
        {
            return ResultColorBrush == Brushes.Green ? "Расчет пройден" : "Расчет не пройден";
        }
    }
}


