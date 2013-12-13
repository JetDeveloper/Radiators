using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LibRadiators
{
    [Guid("C90CE3DA-A634-4003-A419-DE4C1F33B72E")]
    public interface IRadiator
    {
        [DispId(1)]
        double getK2koef(double tm);
        [DispId(2)]
        void calculateRadiator(double ledTempSwitch, double ledPower, double ledTempRestSB, double ledTempRestBR, double radLength, int numberEdge, double tempEnv, double lambda);
        [DispId(3)]
        double getWidth();
        [DispId(4)]
        double getB();
        [DispId(5)]
        double getHeigth();
    }

    [Guid("F97A0DCD-B728-4EF2-8CFE-230561C39C67"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ERadiator
    {
    }

    [Guid("9E5E5FB2-219D-4ee7-AB27-E4DBED8E123E"),
    ClassInterface(ClassInterfaceType.None),
    ComSourceInterfaces(typeof(ERadiator))]
    public class Radiator : IRadiator
    {
        public double h_opt = 0.0;    /* отпитмальная высота      */  
        public double b     = 0.0;    /* расстояние между ребрами */
        public double width = 0.0;    /* ширина ребра             */

        public double getK2koef(double tm)
        {
            if (tm <= 10)
            {
                return 1.4;
            }
            else if (tm >= 150)
            {
                return 1.24;
            }
            return 1.4 - (tm / 10) * 0.02;
        }

        /**
         * ledTempSwitch - температура перехода диода
         * ledPower - мощность диода
         * ledTempRestSB - теплосопротивление переход-корпус
         * ledTempRestBR - теплосопротивление корпус-радиатор
         * radLength - длина радиатора (из светотехнического расчета)
         * numberEdge - количество ребер (для соответсвующей модели в КОМПАС)
         * tempEnv - температура внешней среды
         * lambda - коэффициент теплопроводности материала 
         */
        public void calculateRadiator(double ledTempSwitch, double ledPower, double ledTempRestSB, double ledTempRestBR, double radLength, int numberEdge, double  tempEnv, double lambda)
        {
            double bodyTemp = ledTempSwitch - ledPower * ledTempRestSB;
            double dTemp = ledPower * ledTempRestBR;
            double ts = 0.96 * (ledTempSwitch - ledPower * (ledTempRestSB + ledTempRestBR));
            double dTempRadEnv = ts - tempEnv;
            double tm = (ts - tempEnv) / 2;
            double ak = getK2koef(tm) * (double)Math.Pow((double)(tm / radLength), 1 / 4.0);
            double al = 4; // пока тупо значение, надо написать еще функцию для расчета этого параметра
            double a = ak + al;
            double Sp = ledPower / (a * dTempRadEnv);
            double S = Sp / numberEdge;
            double Q = (double)Math.Pow((double)(3 * a * a * lambda * S), 1 / 3.0) / dTempRadEnv;
            h_opt = (1 / a) * (Q / dTempRadEnv);
            width = (1 / (a * lambda)) * (Q / dTempRadEnv) * (Q / dTempRadEnv) * (Q / dTempRadEnv);
            b = (radLength - width * radLength) / (numberEdge - 1);
        }

        // получить оптимальную ширину ребра
        public double getWidth()
        {
            return width;
        }

        // получить оптимальное расстояние между ребрами 
        public double getB()
        {
            return b;
        }

        // получить высоту ребра
        public double getHeigth()
        {
            return h_opt;
        }

    }
}
