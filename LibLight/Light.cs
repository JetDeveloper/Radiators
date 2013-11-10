using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LibLight
{
    [Guid("6F4E9367-2EC0-4A64-AE8B-847380861E22")]
    public interface LightCOM_Interface
    {
        [DispId(1)]
        int getNumberLED(double F, double F_LED);

 
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
        public double LEDPlateWidth, LEDPlateHeight;

        public int getNumberLED(double F, double F_LED)
        {
            this.F = F;
            return (int)(F / F_LED);
        }

        public double getPower(double P_LED, int numberLED)
        {
            return numberLED * P_LED;
        }

        public double getPlateWidth(double LED_length, double l, double m, double k, int numberLED)
        {
            return numberLED * LED_length + l * m + k; 
        }
        public double getPlateHeight(double LED_width, double l, double m, double k, int numberLED)
        {
            return numberLED * LED_width + l * m + k;
        }
        public double getAngle(double d, double hp)
        {
            return Math.Atan(d / hp); 
        }

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
        public void calculateE(double mu, double k)
        {
            //TODO:
            return;
        }
        public void exportResults(string fileName)
        {
           //TODO:
           return;
        }
        public void calculateLigth(double F, double F_LED, double P_LED, double mu, double k)
        {
            numberLED = getNumberLED(F, F_LED);
            LEDPower = getPower(P_LED, numberLED);
            LED[] table = new LED[numberLED];
            table = getFirstTable(table, F);
            calculateE(mu, k);
            //TODO:
        }

    }
}
