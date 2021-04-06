using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honda
{
    class Program
    {
        delegate void Wash(Car c);
        class Car
        {
            public string Name;
            public bool Clear;
            public Car(string name, bool clear)
            {
                Name = name;
                Clear = clear;
            }
        }
        class Garage : Car
        {
            public static List<Car> cars = new List<Car>();

            public Garage(string name, bool clear) : base(name, clear) { }

            public static void Tesla()
            {
                cars.Add(new Garage("Tesla", false));
            }
            public static void Bmw()
            {
                cars.Add(new Garage("BMW", false));
            }
            public static void Audi()
            {
                cars.Add(new Garage("Audi", false));
            }

            public static void Show()
            {
                Console.WriteLine("Cars:");
                foreach (var item in cars)
                {
                    Console.WriteLine($"Name:" + item.Name + ", Clear: " + item.Clear);
                }
            }


        }
        class Washer
        {
            public static void Wash()
            {
                foreach (var item in Garage.cars)
                {
                    item.Clear = true;
                    Console.WriteLine($"Name:" + item.Name + ", Clear: " + item.Clear);
                }
            }
        }

        public delegate void CarsDelegate();

        public delegate void WashDelegate();
        static void Main(string[] args)
        {
            var cars = new CarsDelegate(Garage.Tesla);
            cars += Garage.Bmw;
            cars += Garage.Audi;
            cars.Invoke();

            Garage.Show();

            Console.WriteLine("\n\nWash cars:");
            Console.ReadKey();

            var wash = new WashDelegate(Washer.Wash);
            wash.Invoke();

            Console.ReadLine();
        }
    }
}
