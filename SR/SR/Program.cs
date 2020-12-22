using System;
using System.Collections.Generic;

namespace SR
{
    class Program
    {
        class Car
        {
            public List<string> color = new List<string> { "red", "broun", "silver", "blue", "green" };
            public int year { get; set; }
            public int price { get; set; }
            public int numberOfGears { get; set; }

            public void Init(int _year, int _price, int _numberOfGears)
            {
                year = _year;
                price = _price;
                numberOfGears = _numberOfGears;
            }
        }

        class Cars
        {
            public List<Car> cars = new List<Car>();

            public void ShowCar(int _id)
            {
                Console.WriteLine("Price: {0}", cars[_id].price);
                Console.WriteLine("Year: {0}", cars[_id].year);
                Console.WriteLine("Number of gears: {0}", cars[_id].numberOfGears);
                Console.WriteLine("Colors: ");
                for (int i = 0; i < cars[_id].color.Count; i++)
                {
                    Console.WriteLine(cars[_id].color[i]);
                }
            }

            public void FindPrice(int _finder)
            {
                int _id = -1;

                for(int i = 0; i < cars.Count; i++)
                {
                    if(_finder == cars[i].price)
                    {
                        _id = i;
                    }
                }

                if (_id < 0)
                {
                    Console.WriteLine("Not found.");
                }
                else
                {
                    ShowCar(_id);
                }
            }

            public void FindYear(int _finder)
            {
                int _id = -1;

                for (int i = 0; i < cars.Count; i++)
                {
                    if (_finder == cars[i].year)
                    {
                        _id = i;
                    }
                }

                if (_id < 0)
                {
                    Console.WriteLine("Not found.");
                }
                else
                {
                    ShowCar(_id);
                }
            }

            public void FindGear(int _finder)
            {
                int _id = -1;

                for (int i = 0; i < cars.Count; i++)
                {
                    if (_finder == cars[i].numberOfGears)
                    {
                        _id = i;
                    }
                }

                if (_id < 0)
                {
                    Console.WriteLine("Not found.");
                }
                else
                {
                    ShowCar(_id);
                }
            }

            public void FindColor(string _finder)
            {
                int _id = -1;

                for (int i = 0; i < cars.Count; i++)
                {
                    for (int j = 0; j < cars[i].color.Count; j++)
                    {
                        if (_finder == cars[i].color[j])
                        {
                            _id = i;
                        }
                    }
                }

                if (_id < 0)
                {
                    Console.WriteLine("Not found.");
                }
                else
                {
                    ShowCar(_id);
                }
            }
        }

        static void Main(string[] args)
        {
            Cars cars = new Cars();
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();

            int id = 0;

            car1.Init(2012, 12000, 5);
            car1.color.RemoveAt(0);
            car1.color.RemoveAt(0);
            car2.Init(2016, 14000, 6);
            car2.color.RemoveAt(0);
            car3.Init(2018, 18000, 6);

            cars.cars.Add(car1);
            cars.cars.Add(car2);
            cars.cars.Add(car3);

            cars.FindColor("red");
            cars.FindColor("black");
            cars.FindPrice(12000);
            cars.FindPrice(300);
            cars.FindYear(2012);
            cars.FindYear(1488);
            cars.FindGear(5);
            cars.FindGear(7);

        }
    }
}
