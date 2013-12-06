using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace LibLight
{
    [Guid("6F4E9367-2EC0-4A64-AE8B-847380861E22")]
    public interface LightCOM_Interface
    {
        [DispId(1)]
        double getPlateWidth(double LED_length, double l, double m, double k, int numberLED);
        [DispId(2)]
        double getPlateHeight(double LED_width, double l, double m, double k, int numberLED);
        [DispId(3)]
        void exportResults(string fileName, string protocolNumber, string protocolDate, string manufac,
                                  string catalogName, string description, string lampcat, string lamp,
                                  string addInfo);
        [DispId(4)]
        void calculateLigth(double F, double F_LED, double P_LED, double mu, double k, double d, double hp);
        [DispId(5)]
        double getEa();
       

    }

    [Guid("A5E2E2EB-111A-4D76-9447-F1FDF93B209A"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface LightCOM_Events
    {
    }

    [Guid("2AB2556B-8A23-45F1-B0A8-7B52568F8B02"),
    ClassInterface(ClassInterfaceType.None),
    ComSourceInterfaces(typeof(LightCOM_Events))]
    public class LigthCOM_Class : LightCOM_Interface
    {
        public const int NUMBER_ANGLE = 19;
        public const int NUMBER_C = 19;
        public struct LED
        {
            public bool isON;
            public double hp;
            public double x;
            public double y;
            public double I0;
            public double Ia;
            public double E;
        };
        public double F = 0.0;
        public int numberLED;
        public double LEDPower;
        public double LEDPlateWidth, LEDPlateHeight, LEDHeight;
        public double Ea;
        public double[,] Ia, E;
        public LED[] table;



        /**
         * Расчет количества диодов
         * F      - световой поток светильника
         * F_LED  - световой поток одного диода
         */
        public int getNumberLED(double F, double F_LED)
        {
            this.F = F;
            return (int)(F / F_LED);
        }

        /**
         * Расчет мощности светильника
         * P_LED     - мощность одного диода из паспорта
         * numberLED - количество диодов 
         */
        public double getPower(double P_LED, int numberLED)
        {
            return numberLED * P_LED;
        }

        /**
         * Расчет длины модуля со светодиодами
         * LED_length - длина диода по паспорту
         * l          - расстояние между светодиодами
         * m          - количество промежутков между СД
         * k          - расстояние отводимое на крепление
         * numberLED  - количество диодов
         */
        public double getPlateWidth(double LED_length, double l, double m, double k, int numberLED)
        {
            return numberLED * LED_length + l * m + k;
        }

        /**
         * Расчет ширины модуля со светодиодами
         * LED_width  - ширина диода по паспорту
         * l          - расстояние между светодиодами
         * m          - количество промежутков между СД
         * k          - расстояние отводимое на крепление
         * numberLED  - количество диодов
         */
        public double getPlateHeight(double LED_width, double l, double m, double k, int numberLED)
        {
            return numberLED * LED_width + l * m + k;
        }

        /**
         * Расчет угла между направлением силы света в рассчетную точку
         * и осью симметрии осветительного прибора
         * d  - расстояние от проекции светильника на расчетную плоскость О до 
         *      точки А (см. Светотехнический расчет)
         * hp - высота расчетной поверхности
         */
        public double getAngle(double d, double hp)
        {
            return Math.Atan(d / hp);
        }
        /**
         * Расчет таблицы для расчета освещенности для каждого полярного угла 
         * гамма при смещении плоскости на определенный азимутальный угол С0
         * (см. Светотехнический расчет)
         */
        public LED[] getFirstTable(LED[] table, double F)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].isON)
                    table[i].I0 = F / Math.PI;
                else
                    table[i].I0 = 0;
            }
            return table;
        }
        /**
         * Расчет горизонтальной освещенности каждого светодиода в расчетной точке
         * mu    - коэффициент, учитывающий действие удаленный от расчетной точки
         *         светильников и отраженного светового потока от стен, потолка, пола,
         *         оборудования, падающего на рабочую поверхность в расчетной точке
         *         (принимают в пределах 1,05-1,2)
         * k     - коэффициент запаса
         * Io    - сила света единичного светодиода
         * hp    - высота подвеса светильника над рабочей поверхностью
         * angle - угол между направлением силы света в рассчетную точку
         *         и осью симметрии осветительного прибора
         */
        public void calculateE(double mu, double k, double Io, double hp, double angle)
        {

            Ia = new double[NUMBER_ANGLE, NUMBER_C];
            E = new double[NUMBER_ANGLE, NUMBER_C];

            for (int i = 0; i < NUMBER_ANGLE; i++)
            {
                for (int j = 0; j < NUMBER_C; j++)
                {
                    double X = hp * Math.Tan((i * 5) * Math.PI / 180) * Math.Cos((j * 15) * Math.PI / 180);
                    double Y = hp * Math.Tan((i * 5) * Math.PI / 180) * Math.Sin((j * 15) * Math.PI / 180);
                    Ia[i, j] = (Io * (hp * hp + (Math.Pow(hp, 2) / Math.Pow(Math.Cos(angle), 2))))
                              / (Math.Pow((2 * hp * hp + X * X + Y * Y), 0.5) * (hp / Math.Cos(angle)));
                    E[i, j] = (Ia[i, j] * Math.Pow(Math.Cos(angle), 3) * mu) / (k * hp * hp);
                }
            }
            return;
        }
        /**
         * Вывод результатов в файл для импорта в DiaLux
         * filename        - имя файла (*.ies)
         * protocolNumber  - номер протокола
         * protocolDate    - Дата протокола (день.месяц.год Напр, 25.11.2013)
         * manufac         - Производитель ОП
         * catalogName     - Название ОП по каталогу
         * description     - Описание ОП
         * lampcat         - Обозначение ИС по каталогу
         * lamp            - Описание ИС
         * addInfo         - Дополнительная информация
         */
        public void exportResults(string fileName, string protocolNumber, string protocolDate, string manufac,
                                  string catalogName, string description, string lampcat, string lamp,
                                  string addInfo)
        {
            LinkedList<string> lines = new LinkedList<string>();
            lines.AddLast("IESNA:LM-63-1995");
            lines.AddLast("[TEST] " + protocolNumber);
            lines.AddLast("[DATA] " + protocolDate);
            lines.AddLast("[MANUFAC] " + manufac);
            lines.AddLast("[LUMCAT] " + catalogName);
            lines.AddLast("[LUMINAIRE] " + description);
            lines.AddLast("[LAMPCAT] " + lampcat);
            lines.AddLast("[LAMP] " + lamp);
            lines.AddLast("[OTHER] " + addInfo);
            lines.AddLast("[MORE]");
            lines.AddLast("TILT=NONE");
            lines.AddLast(numberLED.ToString());
            lines.AddLast(F.ToString());
            lines.AddLast("27");
            lines.AddLast("19");
            lines.AddLast("37");
            lines.AddLast("1");
            lines.AddLast("2");
            lines.AddLast(LEDPlateWidth.ToString());
            lines.AddLast(LEDPlateHeight.ToString());
            lines.AddLast(LEDHeight.ToString()); /* выстота в расчетную точку */
            lines.AddLast("1");
            lines.AddLast("1");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < NUMBER_ANGLE; i++)
            {
                sb.Append(table[i]+ " ");
            }
            lines.AddLast(sb.ToString());
            for (int i = 0; i < NUMBER_ANGLE; i++)
            {
                 sb = new StringBuilder();
                for (int j = 0; j < NUMBER_C; j++)
                {
                    sb.Append(E[i,j] + " ");
                }
            }
            lines.AddLast(sb.ToString());
            string[] strings = new string[lines.Count];
            lines.CopyTo(strings,0);
            File.WriteAllLines(fileName+".ies",strings);
            return;
        }
        /**
         * Светотехнический расчет
         * 
         * F     - световой поток светильника
         * F_LED - световой поток одного диода
         * P_LED - мощность одного диода
         * mu    - коэффициент, учитывающий действие удаленный от расчетной точки
         *         светильников и отраженного светового потока от стен, потолка, пола,
         *         оборудования, падающего на рабочую поверхность в расчетной точке
         *         (принимают в пределах 1,05-1,2)
         * k     - коэффициент запаса
         * Io    - сила света единичного светодиода
         * hp    - высота подвеса светильника над рабочей поверхностью
         */
        public void calculateLigth(double F, double F_LED, double P_LED, double mu, double k, double d, double hp)
        {
            numberLED = getNumberLED(F, F_LED);
            LEDPower = getPower(P_LED, numberLED);
            table = new LED[numberLED];
            table = getFirstTable(table, F);
            calculateE(mu, k, F / Math.PI, hp, getAngle(d, hp));
            double temp = 0.0;   /* for Ea computing */
            for (int i = 0; i < NUMBER_ANGLE; i++)
            {
                for (int j = 0; j < NUMBER_C; j++)
                {
                    temp += E[i, j];
                }
            }
            Ea = ((F * mu) / (1000 * k)) * temp;
        }

        /**
         * Вернуть полную освещенность светильника
         */ 
        public double getEa()
        {
            return Ea;
        }
    }
}
