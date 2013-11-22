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
       public const int NUMBER_ANGLE = 18;
       public const int NUMBER_C = 13;
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
        public double Ea;
        public double[,] Ia, E;


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
        public void calculateE(double mu, double k, double Io, double hp, double angle, double[] posX, double[] posY)
        {

            Ia = new double[NUMBER_ANGLE, NUMBER_C];
            E = new double[NUMBER_ANGLE, NUMBER_C];

            for (int i = 0; i < NUMBER_ANGLE; i++)
            {
                for (int j = 0; j < NUMBER_C; j++)
                {
                   // for(int t = 0; t<numberLED; t++)
                   // {
                        double X = hp*Math.Tan((i*5)*Math.PI/180)*Math.Cos((j*15)*Math.PI/180);
                        double Y = hp*Math.Tan((i*5)*Math.PI/180)*Math.Sin((j*15)*Math.PI/180);
                        Ia[i,j] = (Io*(hp*hp /* +(posX[t]-X)*(posX[t]-X) +(posY[t]-Y)*(posY[t]-Y) */ + (Math.Pow(hp,2)/Math.Pow(Math.Cos(angle),2))/*-(posX[t]-X)*(posX[t]-X)-(posY[t]-Y)*(posY[t]-Y)*/))
                                  /(Math.Pow((2*hp*hp+X*X+Y*Y),0.5)*(hp/Math.Cos(angle)));
                        E[i, j] = (Ia[i, j] * Math.Pow(Math.Cos(angle), 3) * mu) / (k * hp * hp);
                  //  }
                }
            }

            return;
        }
        public void exportResults(string fileName)
        {
           //TODO:
           return;
        }
        public void calculateLigth(double F, double F_LED, double P_LED, double mu, double k, double E, double S, double d, double hp)
        {
            numberLED = getNumberLED(F, F_LED);
            LEDPower = getPower(P_LED, numberLED);
            LED[] table = new LED[numberLED];
            table = getFirstTable(table, F);
            calculateE(mu, k, F/Math.PI,hp,getAngle(d,hp),null,null);
            //TODO:
        }

    }
}
