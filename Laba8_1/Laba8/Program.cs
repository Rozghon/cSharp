using System;
using System.Collections.Generic;

namespace Laba8
{
    class Car
    {
        public string name { get; set; }
        public string color { get; set; }
        public string carNumber { get; set; }

        public float speed { get; set; }
        public int graduationYear { get; set; }
    }

    class Garage : Car
    {
        public List<Car> garageList = new List<Car>();
        
        public void AddElement()
        {
            Car car = new Car();

            Console.WriteLine("Enter name of car: ");
            car.name = Console.ReadLine();
            Console.WriteLine("Enter color of car: ");
            car.color = Console.ReadLine();
            Console.WriteLine("Enter car number: ");
            car.carNumber = Console.ReadLine();
            Console.WriteLine("Enter maximum car speed: ");
            car.speed = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter graduation year");
            car.graduationYear = Convert.ToInt32(Console.ReadLine());

            garageList.Add(car);
        }

        public void RemoveElement()
        {
            Console.WriteLine("Enter ID of car for removed: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            garageList.RemoveAt(carId);
        }

        public void ShowElement(int _id)
        {
            Car car = garageList[_id];

            Console.WriteLine("name:{0}",car.name);
            Console.WriteLine("color:{0}", car.color);
            Console.WriteLine("number:{0}", car.carNumber);
            Console.WriteLine("speed:{0}", car.speed);
            Console.WriteLine("year:{0}", car.graduationYear);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            string answer;
            bool isWorking = true;

            while (isWorking == true)
            {
                Console.WriteLine("Do you want Add new element? Write 1. ");
                Console.WriteLine("Do you want Delete element? Write 2.");
                Console.WriteLine("Do you want Show element? Write 3.");
                Console.WriteLine("Do you want Search element? Write 4.");
                Console.WriteLine("Do you want Exit? Write anything. ");

                answer = Console.ReadLine();
                if (answer == "1")
                {
                    garage.AddElement();
                }
                else if (answer == "2")
                {
                    garage.RemoveElement();
                }
                else if (answer == "3")
                {
                    Console.WriteLine("Write Id of element: ");
                    int elementId = Convert.ToInt32(Console.ReadLine());
                    garage.ShowElement(elementId);
                }
                else if (answer == "4")
                {
                    Console.WriteLine("What you need? (name, color, number, speed, year)");
                    answer = Console.ReadLine();
                    if (answer == "name")
                    {
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();

                        for (int i = 0; i < garage.garageList.Count; i++)
                        {
                            if (garage.garageList[i].name == name)
                            {
                                garage.ShowElement(i);
                            }
                        }
                    }
                    else if (answer == "color")
                    {
                        Console.WriteLine("Enter color: ");
                        string color = Console.ReadLine();

                        for (int i = 0; i < garage.garageList.Count; i++)
                        {
                            if (garage.garageList[i].color == color)
                            {
                                garage.ShowElement(i);
                            }
                        }
                    }
                    else if (answer == "number")
                    {
                        Console.WriteLine("Enter number: ");
                        string number = Console.ReadLine();

                        for (int i = 0; i < garage.garageList.Count; i++)
                        {
                            if (garage.garageList[i].carNumber == number)
                            {
                                garage.ShowElement(i);
                            }
                        }
                    }
                    else if (answer == "speed")
                    {
                        Console.WriteLine("Enter speed: ");
                        float speed = float.Parse(Console.ReadLine());

                        for (int i = 0; i < garage.garageList.Count; i++)
                        {
                            if (garage.garageList[i].speed == speed)
                            {
                                garage.ShowElement(i);
                            }
                        }
                    }
                    else if (answer == "year")
                    {
                        Console.WriteLine("Enter year: ");
                        int year = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < garage.garageList.Count; i++)
                        {
                            if (garage.garageList[i].graduationYear == year)
                            {
                                garage.ShowElement(i);
                            }
                        }
                    }
                }
                else
                {
                    isWorking = false;
                }
            }
        }
    }
}