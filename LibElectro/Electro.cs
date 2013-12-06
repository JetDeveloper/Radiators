using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LibElectro
{
    [Guid("335F910F-AF28-436D-94C6-22166158A7A5")]
    public interface ElectroCOM_Interface
    {
        [DispId(1)]
        void calculate(double Vin_max, double Vin_min, double Vout, double Iout, double f, double Vf, double Al, double Vfwd);
        [DispId(2)]
        double getN1();
        [DispId(3)]
        double getN2();

    }

    [Guid("F8C223B3-3557-4D67-9A1F-44B0A126DD8E"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ElectroCOM_Events
    {
    }

    [Guid("1BE9706F-35FB-4062-978B-B6B0732781C2"),
    ClassInterface(ClassInterfaceType.None),
    ComSourceInterfaces(typeof(ElectroCOM_Events))]
    public class ElectroCOM_Class :ElectroCOM_Interface
    {
        public double N1, N2;


        /**
         * Расчет первичной и вторичной обмотки трансформатора
         *
         * Vin_min - минимальное входящее напряжение (В)
         * Vin_max - максимальное входящее напряжение (В)
         * Vout    - исходящее напряжение (В)
         * Iout    - исходящий ток (Ам)
         * f       - частота работы (Гц)
         * Vf      - внутренее опорное напряжение (В)
         * Al      - индуктивность на один виток (нГ/вит)
         * Vfwd    - прямое падение на диоде (В)
         **/
        public void calculate(double Vin_max, double Vin_min, double Vout, double Iout, double f, double Vf, double Al, double Vfwd)
        {
            
            double Vin_aver = (Vin_max + Vin_min) / 2;
            double L1 = (Vin_aver * Vin_aver) / (8 * (Vout + Vf) * Iout * f);
            N1 = Math.Pow(L1 / Al, 0.5);
            N2 = (N1*(Vout+Vfwd))/(Vin_min);
        }
        /**
         * N1 - количество витков в первичной обмотке
         */
        public double getN1()
        {
            return N1;
        }
        /**
         * N2 - количество витков во вторичной обмотке
         */
        public double getN2()
        {
            return N2;
        }

    }
}
