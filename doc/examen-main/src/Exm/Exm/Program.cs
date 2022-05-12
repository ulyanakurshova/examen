using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Exm
{
    internal class Program
    {

        static void Main(string[] args)
        {
            WeatherControl wc = new WeatherControl();
            wc.init();
        }
    }
    public class WeatherControl
    {

        public void init()
        {
            try
            {
                Console.Write("Введите размер массива ");
                string mascount = Console.ReadLine();
                int imascount = Convert.ToInt32(mascount);
                Indication[] weather = new Indication[imascount];
                for (int j = 0; j < imascount; j++)
                {
                    int c = j + 1;
                    weather[j] = new Indication();
                    Console.Write("Введите температуру записи №" + c + " (дробные числа вводить через запятую) ");
                    string temp = Console.ReadLine();
                    weather[j].temp = Convert.ToDouble(temp);
                    Console.Write("Введите влажность записи №" + c + " (дробные числа вводить через запятую) ");
                    string humidity = Console.ReadLine();
                    weather[j].humidity = Convert.ToDouble(temp);
                    Console.Write("Введите давление записи №" + c + " (дробные числа вводить через запятую) ");
                    string pressure = Console.ReadLine();
                    weather[j].pressure = Convert.ToDouble(temp);
                }
                sort(weather);
                zapis(weather, imascount);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Возникла ошибка - "+ ex.Message + " программа вернеся в начало " );
                init();
            }
                
            
        }
        public void sort(Indication[] weather)
        {
            for (int i = 0; i < weather.Length; i++)
            {
                for (int j = 0; j < weather.Length - 1; j++)
                {
                    if ((weather[j].temp + weather[j].humidity) > (weather[j + 1].temp + weather[j + 1].humidity))
                    {
                        Indication z = weather[j];
                        weather[j] = weather[j + 1];
                        weather[j + 1] = z;

                    }
                }
            }
        }

        public void zapis(Indication[] weather, int imascount)
        {
            StreamWriter sw = new StreamWriter("Показание счетчика погоды.txt");
            for (int j = 0; j < imascount; j++)
            {
                sw.WriteLine("Счетчик №" + (j + 1) + " Температура = " + weather[j].temp + " влажность = " + weather[j].humidity + " Атмосферное давление = " + weather[j].pressure + ";");
            }
            sw.Close();
        }
        
    }
    public class Indication
    {
        public double temp;
        public double humidity;
        public double pressure;
    }
}
